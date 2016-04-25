using System;
using System.Collections.Generic;
using Aura.ClientStuff;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aura.MapRelated;

namespace Aura.Entity
{
    public class Character
    {
        public int BestTargetCount = int.MinValue;
        public List<string> _npcOptions = new List<string>();
        public bool IsCupping;
        public bool Counted;
        public bool justdioned;
        public bool makexml;
        public bool timed;
        public bool clicked;
        public bool hasbeensensed;
        public bool hasbeenattacked;

        public ushort Form { get; set; }

        public byte Body { get; set; }

        public ushort Arms { get; set; }

        public byte Boots { get; set; }

        public ushort Armor { get; set; }

        public byte Shield { get; set; }

        public ushort Weapon { get; set; }

        public byte HeadColor { get; set; }

        public byte BootColor { get; set; }

        public byte Acc1Color { get; set; }

        public ushort Acc1 { get; set; }

        public byte Acc2Color { get; set; }

        public byte Acc3Color { get; set; }

        public ushort Acc3 { get; set; }

        public ushort Acc2 { get; set; }

        public byte Unknown { get; set; }

        public byte RestCloak { get; set; }

        public bool HideBoolean { get; set; }

        public ushort Overcoat { get; set; }

        public byte OvercoatColor { get; set; }

        public byte SkinColor { get; set; }

        public byte HideBool { get; set; }

        public byte FaceShape { get; set; }

        public string DisplayName { get; set; }

        public bool NameIsRed { get; set; }

        public string GroupName { get; set; }

        public ushort Head { get; set; }

        public byte[] DisplayData { get; set; }

        public byte NameTagStyle { get; set; }

        public Client Client { get; set; }

        public byte BodySprite { get; set; }

        public Dictionary<int, int> AnimationFrom { get; set; }

        public int AnotherCurseCount { get; set; }

        public int DeathCount { get; set; }

        public DateTime CreateTime { get; set; }

        public bool hascatshearing
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(124))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[124]).TotalSeconds < 240.0;
            }
        }

        public bool hasaite
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(231))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[231]).TotalSeconds < 600.0;
            }
        }

        public bool hasardcradh
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(257))
                    return false;
                return DateTime.UtcNow.Subtract(SpellAnimationHistory[257]).TotalSeconds < 240.0;
            }
        }

        public bool hasardfas
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(273))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[273]).TotalSeconds < 225.0;
            }
        }

        public bool hasreflection
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(195))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[195]).TotalSeconds < 19.0;
            }
        }

        public bool hasarmachd
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(20))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[20]).TotalSeconds < 150.0;
            }
        }

        public bool hasbardo
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(44))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[44]).TotalSeconds < 180.0;
            }
        }

        public bool hasincregen
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(170))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[170]).TotalSeconds < 35.0;
            }
        }

        public bool hasbeagcradh
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(259))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[259]).TotalSeconds < 150.0;
            }
        }

        public bool hasbeann
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(280))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[280]).TotalSeconds < 240.0;
            }
        }

        public bool hasbubblepoison
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(247))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[247]).TotalSeconds < 0.5;
            }
        }

        public bool hasca
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(184))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[184]).TotalSeconds < 21.0;
            }
        }

        public bool hascradh
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(258))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[258]).TotalSeconds < 180.0;
            }
        }

        public bool hascreagneart
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(6))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[6]).TotalSeconds < 163.0;
            }
        }

        public bool hasct
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(295))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[295]).TotalSeconds < 3.5;
            }
        }

        public bool hasdall
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(42))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[42]).TotalSeconds < 18.0;
            }
        }

        public bool hasdarkerseal
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(82))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[82]).TotalSeconds < 153.0;
            }
        }

        public bool hasdarkseal
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(104) || DateTime.UtcNow.Subtract(this.SpellAnimationHistory[104]).TotalSeconds >= 153.0)
                    return this.hasdarkerseal;
                return true;
            }
        }

        public bool hasdion
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(244))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[244]).TotalSeconds < 19.0;
            }
        }

        public bool hasdioncomlha
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(93))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[93]).TotalSeconds < 18.0;
            }
        }

        public bool hasdragonsfire
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(34))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[34]).TotalSeconds < 600.0;
            }
        }

        public bool hasfas
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(273))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[273]).TotalSeconds < 450.0;
            }
        }

        public bool hasironskin
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(89))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[89]).TotalSeconds < 16.0;
            }
        }

        public bool hasmonsterdion
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(271))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[271]).TotalSeconds < 9.0;
            }
        }

        public bool hasmonstermordion
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(271))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[271]).TotalSeconds < 19.0;
            }
        }

        public bool hasmorcradh
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(243))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[243]).TotalSeconds < 210.0;
            }
        }

        public bool haspramh
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(32))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[32]).TotalSeconds < 2.0;
            }
        }

        public bool hasmesmerize
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(117))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[117]).TotalSeconds < 2.0;
            }
        }

        public bool hasaffliction
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(85))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[85]).TotalSeconds < 26.3;
            }
        }

        public bool hasregen
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(187))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[187]).TotalSeconds < 1.5;
            }
        }

        public bool hascounterattack
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(184))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[184]).TotalSeconds < 15.0;
            }
        }

        public bool justCK
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(287))
                    return false;
                this.SpellAnimationHistory.Remove(287);
                return true;
            }
        }

        public bool justRA
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(264))
                    return false;
                this.SpellAnimationHistory.Remove(264);
                return true;
            }
        }

        public bool justRS
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(163))
                    return false;
                this.SpellAnimationHistory.Remove(163);
                return true;
            }
        }

        public bool justWK
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(261))
                    return false;
                this.SpellAnimationHistory.Remove(261);
                return true;
            }
        }

        public bool hassuain
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(40) || this.AnimationFrom[40] == 208 || this.AnimationFrom[40] == 204)
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[40]).TotalSeconds < 2.0;
            }
        }

        public bool hasswirlpoison
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(25))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[25]).TotalSeconds < 2.0;
            }
        }

        public bool hashidetrinket
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(10))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[10]).TotalSeconds < 60.0;
            }
        }

        public bool haswff
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(40) || this.AnimationFrom[40] != 208 && this.AnimationFrom[40] != 204)
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[40]).TotalSeconds < 2.0;
            }
        }

        public bool haswingsofprot
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(86))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[86]).TotalSeconds < 14.0;
            }
        }

        public int HpAmount { get; set; }

        public uint ID { get; set; }

        public string Guild { get; set; }

        public uint Staff { get; set; }

        public bool IsLoggedOn { get; set; }

        public bool IsOnScreen { get; set; }

        public bool isskulled
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(24))
                    return false;
                return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[24]).TotalSeconds < 1.0;
            }
        }

        public bool justAS
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(70))
                    return false;
                this.SpellAnimationHistory.Remove(70);
                return true;
            }
        }

        public bool justcrashered
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(50))
                    return false;
                this.SpellAnimationHistory.Remove(50);
                return true;
            }
        }

        public bool justhpcupped
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(162))
                    return false;
                this.SpellAnimationHistory.Remove(162);
                return true;
            }
        }

        public bool hasasgall
        {
            get
            {
                if (this.SpellAnimationHistory.ContainsKey(66))
                    return DateTime.UtcNow.Subtract(this.SpellAnimationHistory[66]).TotalSeconds < 13.0;
                return false;
            }
        }

        public bool justkelbed
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(48))
                    return false;
                this.SpellAnimationHistory.Remove(48);
                return true;
            }
        }

        public bool justmadsouled
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(53))
                    return false;
                this.SpellAnimationHistory.Remove(53);
                return true;
            }
        }

        public bool justspioraded
        {
            get
            {
                if (!this.SpellAnimationHistory.ContainsKey(1))
                    return false;
                this.SpellAnimationHistory.Remove(1);
                return true;
            }
        }

        public Location Location { get; set; }

        public int Map { get; set; }

        public string MapName { get; set; }

        public string Name { get; set; }

        public Dictionary<int, DateTime> SpellAnimationHistory { get; set; }

        public Character()
        {
            this.ID = 0U;
            this.Name = string.Empty;
            this.HpAmount = 100;
            this.Location = new Location(0, 0);
            this.SpellAnimationHistory = new Dictionary<int, DateTime>();
            this.AnimationFrom = new Dictionary<int, int>();
            this.IsOnScreen = true;
            this.IsLoggedOn = true;
            this.AnotherCurseCount = 0;
            this.CreateTime = DateTime.UtcNow;
        }

        public void ResetDisplayData()
        {
            this.Armor = (ushort)0;
            this.Boots = (byte)0;
            this.Shield = (byte)0;
            this.Weapon = (ushort)0;
            this.Head = (ushort)0;
            this.BootColor = (byte)0;
            this.Acc1Color = (byte)0;
            this.Acc1 = (ushort)0;
            this.Acc2Color = (byte)0;
            this.Acc2 = (ushort)0;
            this.Acc2Color = (byte)0;
            this.Unknown = (byte)0;
            this.Overcoat = (ushort)0;
            this.OvercoatColor = (byte)0;
        }

        public int DistanceFrom(Location loc)
        {
            return Math.Abs(this.Location.X - loc.X) + Math.Abs(this.Location.Y - loc.Y);
        }

        public bool IsInFront(Location loc)
        {
            if (this.Location.X == loc.X)
            {
                if (this.Location.Y > loc.Y && loc.Direction == Direction.South)
                    return true;
                if (this.Location.Y < loc.Y)
                    return loc.Direction == Direction.North;
                return false;
            }
            if (this.Location.Y != loc.Y)
                return false;
            if (this.Location.X > loc.X && loc.Direction == Direction.East)
                return true;
            if (this.Location.X < loc.X)
                return loc.Direction == Direction.West;
            return false;
        }

        public bool IsInRSRange(Location loc)
        {
            if (this.Location.X == loc.X && Math.Abs(this.Location.Y - loc.Y) < 5)
                return true;
            if (this.Location.Y == loc.Y)
                return Math.Abs(this.Location.X - loc.X) < 5;
            return false;
        }

        public bool IsInSenseRange(Location loc)
        {
            if (this.Location.X == loc.X && Math.Abs(this.Location.Y - loc.Y) < 4)
                return true;
            if (this.Location.Y == loc.Y)
                return Math.Abs(this.Location.X - loc.X) < 4;
            return false;
        }
    }
}
