using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.MapRelated
{
    public class PathFinder
    {
        public class PathFinderNode
        {
            public PathFinder.PathFinderNode LastNode;

            public PathFinder.PathFinderNode NextNode;

            public int X
            {
                get;
                set;
            }

            public int Y
            {
                get;
                set;
            }

            public int Heuristic
            {
                get;
                set;
            }
        }

        public static List<PathFinder.PathFinderNode> FindPath(Tile[,] Matrix, Location Start, Location End)
        {
            bool[,] array = new bool[Matrix.GetUpperBound(0) + 1, Matrix.GetUpperBound(1) + 1];
            List<PathFinder.PathFinderNode> list = new List<PathFinder.PathFinderNode>(new PathFinder.PathFinderNode[]
              {
                new PathFinder.PathFinderNode
                {
                    X = Start.X,
                    Y = Start.Y,
                    Heuristic = 0
                }
              });
            PathFinder.PathFinderNode pathFinderNode = null;
            int num = 0;
            while (pathFinderNode == null && list.Count > 0)
            {
                List<PathFinder.PathFinderNode> list2 = new List<PathFinder.PathFinderNode>();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Heuristic > num)
                    {
                        list2.Add(list[i]);
                    }
                    else
                    {
                        if (list[i].X - 1 <= Matrix.GetUpperBound(0) && list[i].X - 1 >= 0 && !array[list[i].X - 1, list[i].Y] && Matrix[list[i].X - 1, list[i].Y] != Tile.Wall)
                        {
                            PathFinder.PathFinderNode pathFinderNode2 = new PathFinder.PathFinderNode
                            {
                                LastNode = list[i].LastNode,
                                X = list[i].X,
                                Y = list[i].Y,
                                Heuristic = list[i].Heuristic
                            };
                            PathFinder.PathFinderNode pathFinderNode3 = new PathFinder.PathFinderNode
                            {
                                X = list[i].X - 1,
                                Y = list[i].Y,
                                NextNode = null,
                                Heuristic = pathFinderNode2.Heuristic + (int)((byte)Matrix[list[i].X - 1, list[i].Y])
                            };
                            pathFinderNode2.NextNode = pathFinderNode3;
                            pathFinderNode3.LastNode = pathFinderNode2;
                            if (list[i].X - 1 == End.X && list[i].Y == End.Y)
                            {
                                pathFinderNode = pathFinderNode3;
                                break;
                            }
                            array[list[i].X - 1, list[i].Y] = true;
                            list2.Add(pathFinderNode3);
                        }
                        if (list[i].X + 1 <= Matrix.GetUpperBound(0) && list[i].X + 1 >= 0 && !array[list[i].X + 1, list[i].Y] && Matrix[list[i].X + 1, list[i].Y] != Tile.Wall)
                        {
                            PathFinder.PathFinderNode pathFinderNode4 = new PathFinder.PathFinderNode
                            {
                                LastNode = list[i].LastNode,
                                X = list[i].X,
                                Y = list[i].Y,
                                Heuristic = list[i].Heuristic
                            };
                            PathFinder.PathFinderNode pathFinderNode5 = new PathFinder.PathFinderNode
                            {
                                X = list[i].X + 1,
                                Y = list[i].Y,
                                NextNode = null,
                                Heuristic = pathFinderNode4.Heuristic + (int)((byte)Matrix[list[i].X + 1, list[i].Y])
                            };
                            pathFinderNode4.NextNode = pathFinderNode5;
                            pathFinderNode5.LastNode = pathFinderNode4;
                            if (list[i].X + 1 == End.X && list[i].Y == End.Y)
                            {
                                pathFinderNode = pathFinderNode5;
                                break;
                            }
                            array[list[i].X + 1, list[i].Y] = true;
                            list2.Add(pathFinderNode5);
                        }
                        if (list[i].Y - 1 <= Matrix.GetUpperBound(1) && list[i].Y - 1 >= 0 && !array[list[i].X, list[i].Y - 1] && Matrix[list[i].X, list[i].Y - 1] != Tile.Wall)
                        {
                            PathFinder.PathFinderNode pathFinderNode6 = new PathFinder.PathFinderNode
                            {
                                LastNode = list[i].LastNode,
                                X = list[i].X,
                                Y = list[i].Y,
                                Heuristic = list[i].Heuristic
                            };
                            PathFinder.PathFinderNode pathFinderNode7 = new PathFinder.PathFinderNode
                            {
                                X = list[i].X,
                                Y = list[i].Y - 1,
                                NextNode = null,
                                Heuristic = pathFinderNode6.Heuristic + (int)((byte)Matrix[list[i].X, list[i].Y - 1])
                            };
                            pathFinderNode6.NextNode = pathFinderNode7;
                            pathFinderNode7.LastNode = pathFinderNode6;
                            if (list[i].X == End.X && list[i].Y - 1 == End.Y)
                            {
                                pathFinderNode = pathFinderNode7;
                                break;
                            }
                            array[list[i].X, list[i].Y - 1] = true;
                            list2.Add(pathFinderNode7);
                        }
                        if (list[i].Y + 1 <= Matrix.GetUpperBound(1) && list[i].Y + 1 >= 0 && !array[list[i].X, list[i].Y + 1] && Matrix[list[i].X, list[i].Y + 1] != Tile.Wall)
                        {
                            PathFinder.PathFinderNode pathFinderNode8 = new PathFinder.PathFinderNode
                            {
                                LastNode = list[i].LastNode,
                                X = list[i].X,
                                Y = list[i].Y,
                                Heuristic = list[i].Heuristic
                            };
                            PathFinder.PathFinderNode pathFinderNode9 = new PathFinder.PathFinderNode
                            {
                                X = list[i].X,
                                Y = list[i].Y + 1,
                                NextNode = null,
                                Heuristic = pathFinderNode8.Heuristic + (int)((byte)Matrix[list[i].X, list[i].Y + 1])
                            };
                            pathFinderNode8.NextNode = pathFinderNode9;
                            pathFinderNode9.LastNode = pathFinderNode8;
                            if (list[i].X == End.X && list[i].Y + 1 == End.Y)
                            {
                                pathFinderNode = pathFinderNode9;
                                break;
                            }
                            array[list[i].X, list[i].Y + 1] = true;
                            list2.Add(pathFinderNode9);
                        }
                    }
                }
                num++;
                list = list2;
            }
            List<PathFinder.PathFinderNode> result;
            if (pathFinderNode != null)
            {
                list = new List<PathFinder.PathFinderNode>();
                while (pathFinderNode != null)
                {
                    list.Add(pathFinderNode);
                    pathFinderNode = pathFinderNode.LastNode;
                }
                list.Reverse();
                result = list;
            }
            else
            {
                result = null;
            }
            return result;
        }
    }
}
