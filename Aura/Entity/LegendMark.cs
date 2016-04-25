using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Entity
{
    public class LegendMark
    {
        private byte _icon;
        private byte _color;
        private string _key;
        private string _text;

        public byte Icon
        {
            get
            {
                return this._icon;
            }
        }

        public byte Color
        {
            get
            {
                return this._color;
            }
        }

        public string Key
        {
            get
            {
                return this._key;
            }
        }

        public string Text
        {
            get
            {
                return this._text;
            }
        }

        internal LegendMark(byte icon, byte color, string key, string text)
        {
            this._icon = icon;
            this._color = color;
            this._key = key;
            this._text = text;
        }
    }
}
