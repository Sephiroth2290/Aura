using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Aura;
using Aura.Entity;
using Aura.ClientStuff;
using System.Threading.Tasks;

namespace Aura.MapRelated
{
    public class Map
    {
        public byte Bitmask { get; set; }

        public ushort Checksum { get; set; }

        public int Height { get; set; }

        public bool IsLoaded { get; private set; }

        public Point this[int x, int y]
        {
            get
            {
                if (((x + 1) * (y + 1)) <= Tiles.Length)
                {
                    return Tiles[x, y];
                }
                return new Point(-1, -1);
            }
        }

        public string Name { get; set; }

        public int Number { get; set; }

        public static byte[] Sotp { get; private set; }

        public Point[,] Tiles { get; private set; }

        public int Width { get; set; }

        public Point[] FindPath(int startX, int startY, int endX, int endY, bool ignoreentities)
        {
            var list = new List<Point>();
            var list2 = new List<Point>();
            var list3 = new List<Point>();
            var list4 = new List<Point>();
            var array = new bool[Width, Height];
            bool flag = false;
            Point[] result;
            if ((startX + 1) * (startY + 1) > Tiles.Length)
            {
                result = new Point[0];
            }
            else
            {
                if ((endX + 1) * (endY + 1) > Tiles.Length)
                {
                    result = new Point[0];
                }
                else
                {
                    Point[,] tiles = Tiles;
                    int upperBound = tiles.GetUpperBound(0);
                    int upperBound2 = tiles.GetUpperBound(1);
                    for (int i = tiles.GetLowerBound(0); i <= upperBound; i++)
                    {
                        for (int j = tiles.GetLowerBound(1); j <= upperBound2; j++)
                        {
                            Point point = tiles[i, j];
                            point.StepCount = -1;
                        }
                    }
                    Tiles[startX, startY].StepCount = 0;
                    list2.Add(Tiles[startX, startY]);
                    while (!flag)
                    {
                        var list5 = new List<Point>();
                        foreach (Point current in list2)
                        {
                            Point[] array2 = SurroundingPoints(current);
                            Point[] array3 = array2;
                            for (int i = 0; i < array3.Length; i++)
                            {
                                Point point = array3[i];
                                if (!array[point.X, point.Y])
                                {
                                    if (!ignoreentities)
                                    {
                                        if (point.Passable || (point.X == endX && point.Y == endY))
                                        {
                                            list5.Add(point);
                                            array[point.X, point.Y] = true;
                                            point.StepCount = current.StepCount + 1;
                                            if (point.X == endX && point.Y == endY)
                                            {
                                                flag = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (!point.IsWall || (point.X == endX && point.Y == endY))
                                        {
                                            list5.Add(point);
                                            array[point.X, point.Y] = true;
                                            point.StepCount = current.StepCount + 1;
                                            if (point.X == endX && point.Y == endY)
                                            {
                                                flag = true;
                                            }
                                        }
                                    }
                                }
                                list.Add(current);
                                array[current.X, current.Y] = true;
                            }
                        }
                        list2 = list5;
                        if (list2.Count < 1)
                        {
                            result = new Point[0];
                            return result;
                        }
                    }
                    Point point2 = Tiles[endX, endY];
                    list3.Add(Tiles[endX, endY]);
                    while (point2.StepCount > 1)
                    {
                        Point[] array4 = SurroundingPoints(point2);
                        Point[] array3 = array4;
                        for (int i = 0; i < array3.Length; i++)
                        {
                            Point point = array3[i];
                            array[point.X, point.Y] = false;
                            if (point.StepCount == point2.StepCount - 1)
                            {
                                list3.Add(point);
                                point2 = point;
                                break;
                            }
                        }
                    }
                    list3.Reverse();
                    if (ignoreentities)
                    {
                        Point pt = Tiles[endX, endY];
                        foreach (Point point in list3)
                        {
                            if (point.HasBlock)
                            {
                                Point[] array5 = SurroundingPoints(pt);
                                Point[] array3 = array5;
                                for (int i = 0; i < array3.Length; i++)
                                {
                                    Point point3 = array3[i];
                                    if (point3.Passable)
                                    {
                                        Point[] array6 = SurroundingPoints(point);
                                        Point[] array7 = array6;
                                        for (int k = 0; k < array7.Length; k++)
                                        {
                                            Point point4 = array7[k];
                                            if (point4.Passable)
                                            {
                                                if (Math.Abs(point4.X - point3.X) + Math.Abs(point4.Y - point3.Y) == 1)
                                                {
                                                    list4.Add(point3);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                            list4.Add(point);
                            pt = point;
                        }
                        result = list4.ToArray();
                    }
                    else
                    {
                        result = list3.ToArray();
                    }
                }
            }
            return result;
        }

        public void Initialize()
        {
            Tiles = new Point[Width, Height];
            string path = string.Concat(new object[] { Settings.MapsDirectory, @"\lod", Number, ".map" });
            IsLoaded = false;
            if (File.Exists(path))
            {
                FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        Tiles[j, i] = new Point(j, i);
                        Tiles[j, i].StepCount = -1;
                        stream.ReadByte();
                        stream.ReadByte();
                        ushort num3 = (ushort)(stream.ReadByte() | (stream.ReadByte() << 8));
                        ushort num4 = (ushort)(stream.ReadByte() | (stream.ReadByte() << 8));
                        Tiles[j, i].IsWall = ((num3 != 0) && (Sotp[num3 - 1] != 0)) || ((num4 != 0) && (Sotp[num4 - 1] != 0));
                    }
                }
                stream.Close();
                IsLoaded = true;
            }
        }

        public static bool LoadSotp(string iaDatPath)
        {
            if ((Sotp == null) && File.Exists(iaDatPath))
            {
                using (FileStream stream = File.Open(iaDatPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        int count = reader.ReadInt32() - 1;
                        for (int i = 0; i < count; i++)
                        {
                            int num3 = reader.ReadInt32();
                            byte[] bytes = reader.ReadBytes(13);
                            reader.ReadInt32();
                            if (Encoding.ASCII.GetString(bytes).StartsWith("sotp.dat\0"))
                            {
                                stream.Position = num3;
                                Sotp = reader.ReadBytes(count);
                                goto Label_00AA;
                            }
                            stream.Position -= 4L;
                        }
                    }
                }
            }
            Label_00AA:
            return (Sotp != null);
        }

        public Point[] SurroundingPoints(Point pt)
        {
            List<Point> list = new List<Point>();
            if (pt.X > 0)
            {
                list.Add(Tiles[pt.X - 1, pt.Y]);
            }
            if (pt.Y > 0)
            {
                list.Add(Tiles[pt.X, pt.Y - 1]);
            }
            if (pt.X < (Width - 1))
            {
                list.Add(Tiles[pt.X + 1, pt.Y]);
            }
            if (pt.Y < (Height - 1))
            {
                list.Add(Tiles[pt.X, pt.Y + 1]);
            }
            return list.ToArray();
        }

        public void UpdateBlocks(Client client)
        {
            //Point[,] tiles = Tiles;
            //int upperBound = tiles.GetUpperBound(0);
            //int upperBound2 = tiles.GetUpperBound(1);
            //for (int i = tiles.GetLowerBound(0); i <= upperBound; i++)
            //{
            //    for (int j = tiles.GetLowerBound(1); j <= upperBound2; j++)
            //    {
            //        Point point = tiles[i, j];
            //        if (Number == 3058 &&
            //            ((point.X == 3 && point.Y == 9) || (point.X == 3 && point.Y == 10) ||
            //             (point.X == 3 && point.Y == 11) || (point.X == 4 && point.Y == 9) ||
            //             (point.X == 4 && point.Y == 10) || (point.X == 4 && point.Y == 11) ||
            //             (point.X == 5 && point.Y == 9) || (point.X == 5 && point.Y == 10) ||
            //             (point.X == 5 && point.Y == 11)))
            //        {
            //            point.HasBlock = true;
            //        }
            //        else
            //        {
            //            if (Number == 3612 && point.X == 63 && point.Y == 71)
            //            {
            //                point.HasBlock = true;
            //            }
            //            else
            //            {
            //                point.HasBlock = false;
            //            }
            //        }
            //    }
            //}
            //foreach (Character current in client.Characters.Values)
            //{
            //    if (current != null && current.IsOnScreen && current.ID != client.PlayerID)
            //    {
            //        if (!(current is Npc) ||
            //            ((current as Npc).Type != Npc.NpcType.PassableMonster && current.Map == client.MapInfo.Number &&
            //             (current as Npc).Type != Npc.NpcType.Item))
            //        {
            //            client.MapInfo.Tiles[current.Location.X, current.Location.Y].HasBlock = true;
            //        }
            //    }
            //}
        }

        public new string ToString()
        {
            return string.Format("{0} / ({1}", Name, Number);
        }
    }
}
