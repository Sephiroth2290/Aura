using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.MapRelated
{
    public class Location
    {
        public Direction Facing;
        public DateTime LastActive;

        public Direction Direction { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Location(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Location operator +(Location a, Direction b)
        {
            Location location = new Location(a.X, a.Y);
            switch (b)
            {
                case Direction.North:
                    --location.Y;
                    return location;
                case Direction.East:
                    ++location.X;
                    return location;
                case Direction.South:
                    ++location.Y;
                    return location;
                case Direction.West:
                    --location.X;
                    return location;
                default:
                    return location;
            }
        }

        public static Direction operator -(Location a, Location b)
        {
            if (a.X == b.X && a.Y == b.Y + 1)
                return Direction.North;
            if (a.X == b.X && a.Y == b.Y - 1)
                return Direction.South;
            if (a.X == b.X + 1 && a.Y == b.Y)
                return Direction.West;
            return a.X == b.X - 1 && a.Y == b.Y ? Direction.East : Direction.None;
        }

        public bool WithinSquare(Location loc, int num)
        {
            if (Math.Abs(this.X - loc.X) <= num)
                return Math.Abs(this.Y - loc.Y) <= num;
            return false;
        }

        public int DistanceFrom(Location loc)
        {
            return Math.Abs(this.X - loc.X) + Math.Abs(this.Y - loc.Y);
        }

        public int DistanceFrom(int x, int y)
        {
            return Math.Abs(this.X - x) + Math.Abs(this.Y - y);
        }
        public override string ToString()
        {
            return string.Format("{0}{1}{2} Direction: {3}", (string)(object)X, ",", (string)(object)Y, (string)(object)Facing);
        }
    }
}
