using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Entity
{
    public class Player : Character
    {
        public new ushort Head { get; set; }

        public new ushort Form { get; set; }

        public new byte Body { get; set; }

        public new ushort Arms { get; set; }

        public new byte Boots { get; set; }

        public new ushort Armor { get; set; }

        public new byte Shield { get; set; }

        public new ushort Weapon { get; set; }

        public new byte HeadColor { get; set; }

        public new byte BootColor { get; set; }

        public new byte Acc1Color { get; set; }

        public new ushort Acc1 { get; set; }

        public new byte Acc2Color { get; set; }

        public new byte Acc3Color { get; set; }

        public new ushort Acc3 { get; set; }

        public new ushort Acc2 { get; set; }

        public new byte Unknown { get; set; }

        public new byte RestCloak { get; set; }

        public new bool HideBoolean { get; set; }

        public new ushort Overcoat { get; set; }

        public new byte OvercoatColor { get; set; }

        public new byte SkinColor { get; set; }

        public new byte HideBool { get; set; }

        public new byte FaceShape { get; set; }

        public new string GroupName { get; set; }

        public new byte NameTagStyle { get; set; }

        public new string DisplayName { get; set; }

        public new bool NameIsRed { get; set; }

        public new byte BodySprite { get; set; }

        public new byte[] DisplayData { get; set; }
    }
}
