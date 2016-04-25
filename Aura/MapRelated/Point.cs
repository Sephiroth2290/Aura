using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.MapRelated
{
    public class Point
    {
        public DateTime AnimationTimer = DateTime.MinValue;
        public DateTime GemPolishTimer = DateTime.MinValue;
        public DateTime PrayerTimer = DateTime.MinValue;
        public bool prayermessagesent;

        public int X { get; set; }

        public int Y { get; set; }

        public bool IsWall { get; set; }

        public int StepCount { get; set; }

        public bool HasBlock { get; set; }

        public bool PlayAnimation
        {
            get
            {
                return DateTime.UtcNow.Subtract(this.AnimationTimer).TotalSeconds > 3.0;
            }
        }

        public bool HasPrayerSpell
        {
            get
            {
                if (!(this.PrayerTimer == DateTime.MinValue))
                    return DateTime.UtcNow.Subtract(this.PrayerTimer).TotalSeconds < 121.0;
                return false;
            }
        }

        public bool SafeToDropNecklace
        {
            get
            {
                if (!(this.PrayerTimer == DateTime.MinValue))
                    return DateTime.UtcNow.Subtract(this.PrayerTimer).TotalSeconds < 110.0;
                return false;
            }
        }

        public bool HasGemPolish
        {
            get
            {
                if (!(this.GemPolishTimer == DateTime.MinValue))
                    return DateTime.UtcNow.Subtract(this.GemPolishTimer).TotalSeconds < 50.0;
                return false;
            }
        }

        public bool Passable
        {
            get
            {
                if (!this.IsWall)
                    return !this.HasBlock;
                return false;
            }
        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int DistanceFrom(Location loc)
        {
            return Math.Abs(this.X - loc.X) + Math.Abs(this.Y - loc.Y);
        }

        public bool WithinSquare(Location loc, int num)
        {
            if (Math.Abs(this.X - loc.X) <= num)
                return Math.Abs(this.Y - loc.Y) <= num;
            return false;
        }
    }
}
