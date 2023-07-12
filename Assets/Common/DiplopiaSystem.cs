using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria;
using System.Reflection;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Conquest.Assets.Common
{
    public class DiplopiaSystem : GlobalTile
    {
        public override bool CanDrop(int i, int j, int type)
        {
            if (WorldGen.gen && WorldGen.generatingWorld) return false;
            Point16 spot = new Point16(i, j);

            Player player = Main.LocalPlayer;
            MyPlayer modPlayer = player.GetWorldPlayer();
            if (!DoubleOreDrop.placedSpots.Contains(spot))
            {
                if (TileID.Sets.Ore[type] && modPlayer.Diplopia)
                {
                    if (WorldGen.genRand.NextFloat() <= Conquest.DropChance)
                    {
                        DropTheGoods(i, j, type);
                    }
                }
            }
            else
            {
                DoubleOreDrop.RemoveSpot(spot);
            }
            return true;
        }
        public override void PlaceInWorld(int i, int j, int type, Item item)
        {
            if (Conquest.oreItemToTile.ContainsKey(item.type))
            {
                Point16 spot = new Point16(i, j);
                DoubleOreDrop.TryAddSpot(spot, clientWantsBroadcast: true);
            }
        }
        public void DropTheGoods(int i, int j, int type)
        {
            ModTile modTile = TileLoader.GetTile(type);
            if (modTile == null)
            {
                if (TileID.Sets.Ore[type] && Conquest.oreTileToItem.TryGetValue(type, out int item))
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 32, item, Stack: 1);
                }
            }
            else
            {
                if (TileID.Sets.Ore[type])
                {
                    Item.NewItem(WorldGen.GetItemSource_FromTileBreak(i, j), i * 16, j * 16, 16, 16, 1);
                }
            }
        }
    }
    public abstract class MPPacket
    {
        public void Send(int to = -1, int from = -1, Func<Player, bool> bcCondition = null)
        {
            NetHandler.Send(this, to, from, bcCondition);
        }

        public abstract void Send(BinaryWriter writer);

        public abstract void Receive(BinaryReader reader, int sender);
    }
    public class RemoveSpotPacket : SpotPacket
    {
        public RemoveSpotPacket() : base() { }

        public RemoveSpotPacket(Point16 spot) : base(spot) { }

        public override void PostReceiveSpot(BinaryReader reader, Point16 recvSpot, int sender)
        {
            DoubleOreDrop.RemoveSpot(recvSpot);
        }
    }
    public class DoubleOreDrop : ModSystem
    {
        public static HashSet<Point16> placedSpots;

        public override void OnWorldLoad()
        {
            placedSpots = new HashSet<Point16>();
        }

        public override void PreWorldGen()
        {
            placedSpots = new HashSet<Point16>();
        }

        public override void SaveWorldData(TagCompound tag)
        {
            /*For some reason on world generation this method is called at the end of the generation and
			before we have a chance to initialize the hashset so we add the null check*/
            if (placedSpots == null) return;

            //Because tml TagCompound doesn't support HashSet<Point16>, we have to do some conversions here to List<Point16>
            int count = placedSpots.Count;
            if (count > 0)
            {
                Point16[] Point16Array = new Point16[count];
                placedSpots.CopyTo(Point16Array);

                List<Point16> Point16List = Point16Array.ToList();

                tag["placedSpots"] = Point16List;
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            //Because tml TagCompound doesn't support HashSet<Point16>, we have to do some conversions here from List<Point16>
            var Point16IList = tag.GetList<Point16>("placedSpots");
            placedSpots = new HashSet<Point16>(Point16IList);
        }

        public override void NetReceive(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            Point16[] Point16Array = new Point16[count];

            for (int i = 0; i < count; i++)
            {
                short x = reader.ReadInt16();
                short y = reader.ReadInt16();
                Point16Array[i] = new Point16(x, y);
            }

            placedSpots = new HashSet<Point16>(Point16Array);
        }

        public override void NetSend(BinaryWriter writer)
        {
            int count = placedSpots.Count;
            Point16[] Point16Array = new Point16[count];
            placedSpots.CopyTo(Point16Array);

            writer.Write((int)count);

            for (int i = 0; i < count; i++)
            {
                Point16 spot = Point16Array[i];
                writer.Write(spot.X);
                writer.Write(spot.Y);
            }
        }

        #region Methods
        public static void TryAddSpot(Point16 spot, bool clientWantsBroadcast = false)
        {
            //if (Main.netMode == NetmodeID.Server)
            //{
            //	System.Console.WriteLine("added spot");
            //}
            //else
            //{
            //	Main.NewText("added spot");
            //}

            if (!placedSpots.Contains(spot))
            {
                //Don't allow duplicates to be added
                placedSpots.Add(spot);
            }

            if (Main.netMode == NetmodeID.MultiplayerClient && clientWantsBroadcast)
            {
                new AddSpotPacket(spot).Send();
            }
        }

        public static void RemoveSpot(Point16 spot)
        {

            placedSpots.Remove(spot);

            if (Main.netMode == NetmodeID.Server)
            {
                new RemoveSpotPacket(spot).Send();
            }
        }
        #endregion
    }
    public static class NetHandler
    {
        private static List<MPPacket> Packets { get; set; }
        public static Dictionary<Type, byte> ID { get; private set; }

        public static Mod Mod { get; private set; }

        public static void Load()
        {
            Packets = new List<MPPacket>();
            ID = new Dictionary<Type, byte>();

            Mod = ModContent.GetInstance<Conquest>();

            RegisterPackets();
        }

        public static void Unload()
        {
            Packets = null;
            ID = null;
            Mod = null;
        }

        private static void RegisterPackets()
        {
            Type mpPacketType = typeof(MPPacket);
            IEnumerable<Type> mpPacketTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(mpPacketType));

            foreach (var type in mpPacketTypes)
            {
                MPPacket packet = (MPPacket)Activator.CreateInstance(type);

                int count = Packets.Count;

                Packets.Add(packet);
                if (count > byte.MaxValue)
                {
                    throw new Exception($"Packet limit of {byte.MaxValue} reached!");
                }

                byte id = (byte)count;
                ID[type] = id;
            }
        }

        public static void HandlePackets(BinaryReader reader, int sender)
        {
            byte ID = reader.ReadByte();

            try
            {
                if (ID >= Packets.Count)
                {
                    return;
                }

                MPPacket packet = Packets[ID];

                packet.Receive(reader, sender);
            }
            catch (Exception e)
            {
                Mod.Logger.Warn($"Exception handling packet #{ID}: {e}");
            }
        }


        public static void Send<T>(T packet, int to = -1, int from = -1, Func<Player, bool> bcCondition = null) where T : MPPacket
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                return;
            }

            Type type = packet.GetType();
            ModPacket modPacket = Mod.GetPacket();

            modPacket.Write((byte)ID[type]);
            packet.Send(modPacket);

            try
            {
                if (Main.netMode == NetmodeID.MultiplayerClient)
                {
                    modPacket.Send();
                }
                else if (to != -1)
                {
                    modPacket.Send(to, from);
                }
                else
                {
                    for (int i = 0; i < Main.maxPlayers; i++)
                    {
                        if (i != from && Netplay.Clients[i].State >= 10 && (bcCondition?.Invoke(Main.player[i]) ?? true))
                        {
                            modPacket.Send(i);
                        }
                    }
                }
            }
            catch { }
        }
    }
    public abstract class SpotPacket : MPPacket
    {
        readonly Point16 spot;

        public SpotPacket() { }

        public SpotPacket(Point16 spot)
        {
            this.spot = spot;
        }

        public override void Send(BinaryWriter writer)
        {
            writer.Write(spot.X);
            writer.Write(spot.Y);
        }

        public sealed override void Receive(BinaryReader reader, int sender)
        {
            short x = reader.ReadInt16();
            short y = reader.ReadInt16();

            Point16 recvSpot = new Point16(x, y);

            PostReceiveSpot(reader, recvSpot, sender);
        }

        public abstract void PostReceiveSpot(BinaryReader reader, Point16 recvSpot, int sender);
    }
    public class AddSpotPacket : SpotPacket
    {
        public AddSpotPacket() : base() { }

        public AddSpotPacket(Point16 spot) : base(spot) { }

        public override void PostReceiveSpot(BinaryReader reader, Point16 recvSpot, int sender)
        {
            DoubleOreDrop.TryAddSpot(recvSpot);

            if (Main.netMode == NetmodeID.Server)
            {
                new AddSpotPacket(recvSpot).Send(from: sender);
            }
        }
    }
}
