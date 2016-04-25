using System;
using Aura;
using Aura.Server;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ClientStuff
{
    public class Dialog
    {
        private DateTime lastResponse;
        private string m_bottomCaption;
        private Client m_client;
        private byte m_color1;
        private byte m_color2;
        private ushort m_dialogId;
        private byte m_dialogType;
        private uint m_gameObjectId;
        private string m_gameObjectName;
        private byte m_gameObjectType;
        private byte m_inputLength;
        private string m_message;
        private bool m_nextButton;
        private string[] m_options;
        private bool m_prevButton;
        private ushort m_pursuitId;
        private ushort m_sprite1;
        private ushort m_sprite2;
        private string m_topCaption;
        private byte m_unknown1;
        private byte m_unknown2;
        private byte m_unknown3;

        public string BottomCaption
        {
            get
            {
                return m_bottomCaption;
            }
            internal set
            {
                m_bottomCaption = value;
            }
        }

        public byte Color1
        {
            get
            {
                return m_color1;
            }
            internal set
            {
                m_color1 = value;
            }
        }

        public byte Color2
        {
            get
            {
                return m_color2;
            }
            internal set
            {
                m_color2 = value;
            }
        }

        public ushort DialogId
        {
            get
            {
                return m_dialogId;
            }
            internal set
            {
                m_dialogId = value;
            }
        }

        public byte DialogType
        {
            get
            {
                return m_dialogType;
            }
            internal set
            {
                m_dialogType = value;
            }
        }

        public uint GameObjectId
        {
            get
            {
                return m_gameObjectId;
            }
            internal set
            {
                m_gameObjectId = value;
            }
        }

        public string GameObjectName
        {
            get
            {
                return m_gameObjectName;
            }
            internal set
            {
                m_gameObjectName = value;
            }
        }

        public byte GameObjectType
        {
            get
            {
                return m_gameObjectType;
            }
            internal set
            {
                m_gameObjectType = value;
            }
        }

        public byte InputLength
        {
            get
            {
                return m_inputLength;
            }
            internal set
            {
                m_inputLength = value;
            }
        }

        public string Message
        {
            get
            {
                return m_message;
            }
            internal set
            {
                m_message = value;
            }
        }

        public bool NextButton
        {
            get
            {
                return m_nextButton;
            }
            internal set
            {
                m_nextButton = value;
            }
        }

        public string[] Options
        {
            get
            {
                return m_options;
            }
            internal set
            {
                m_options = value;
            }
        }

        public bool PrevButton
        {
            get
            {
                return m_prevButton;
            }
            internal set
            {
                m_prevButton = value;
            }
        }

        public ushort PursuitId
        {
            get
            {
                return m_pursuitId;
            }
            internal set
            {
                m_pursuitId = value;
            }
        }

        public ushort Sprite1
        {
            get
            {
                return m_sprite1;
            }
            internal set
            {
                m_sprite1 = value;
            }
        }

        public ushort Sprite2
        {
            get
            {
                return m_sprite2;
            }
            internal set
            {
                m_sprite2 = value;
            }
        }

        public string TopCaption
        {
            get
            {
                return m_topCaption;
            }
            internal set
            {
                m_topCaption = value;
            }
        }

        public byte Unknown1
        {
            get
            {
                return m_unknown1;
            }
            set
            {
                m_unknown1 = value;
            }
        }

        public byte Unknown2
        {
            get
            {
                return m_unknown2;
            }
            internal set
            {
                m_unknown2 = value;
            }
        }

        public byte Unknown3
        {
            get
            {
                return m_unknown3;
            }
            internal set
            {
                m_unknown3 = value;
            }
        }

        public Dialog(byte dialogType, byte gameObjectType, uint gameObjectId, byte unknown1, ushort sprite1, byte color1, byte unknown2, ushort sprite2, byte color2, ushort pursuitId, ushort dialogId, bool prevButton, bool nextButton, byte unknown3, string gameObjectName, string message, Client client)
        {
            m_dialogType = dialogType;
            m_gameObjectType = gameObjectType;
            m_gameObjectId = gameObjectId;
            m_unknown1 = unknown1;
            m_sprite1 = sprite1;
            m_color1 = color1;
            m_unknown2 = unknown2;
            m_sprite2 = sprite2;
            m_color2 = color2;
            m_pursuitId = pursuitId;
            m_dialogId = dialogId;
            m_prevButton = prevButton;
            m_nextButton = nextButton;
            m_unknown3 = unknown3;
            m_gameObjectName = gameObjectName;
            m_message = message;
            m_options = new string[0];
            m_topCaption = string.Empty;
            m_bottomCaption = string.Empty;
            m_client = client;
        }

        public Dialog(byte dialogType, byte gameObjectType, uint gameObjectId, byte unknown1, ushort sprite1, byte color1, byte unknown2, ushort sprite2, byte color2, ushort pursuitId, ushort dialogId, bool prevButton, bool nextButton, byte unknown3, string gameObjectName, string message, string[] options, Client client)
          : this(dialogType, gameObjectType, gameObjectId, unknown1, sprite1, color1, unknown2, sprite2, color2, pursuitId, dialogId, prevButton, nextButton, unknown3, gameObjectName, message, client)
        {
            m_options = options;
        }

        public Dialog(byte dialogType, byte gameObjectType, uint gameObjectId, byte unknown1, ushort sprite1, byte color1, byte unknown2, ushort sprite2, byte color2, ushort pursuitId, ushort dialogId, bool prevButton, bool nextButton, byte unknown3, string gameObjectName, string message, string topCaption, byte inputLength, string bottomCaption, Client client)
          : this(dialogType, gameObjectType, gameObjectId, unknown1, sprite1, color1, unknown2, sprite2, color2, pursuitId, dialogId, prevButton, nextButton, unknown3, gameObjectName, message, client)
        {
            m_topCaption = topCaption;
            m_inputLength = inputLength;
            m_bottomCaption = bottomCaption;
        }

        public Dialog(byte dialogType, byte gameObjectType, uint gameObjectId, byte unknown1, ushort sprite1, byte color1, byte unknown2, ushort sprite2, byte color2, ushort pursuitId, ushort dialogId, bool prevButton, bool nextButton, byte unknown3, string gameObjectName, string message, string[] options, string topCaption, byte inputLength, string bottomCaption, Client client)
          : this(dialogType, gameObjectType, gameObjectId, unknown1, sprite1, color1, unknown2, sprite2, color2, pursuitId, dialogId, prevButton, nextButton, unknown3, gameObjectName, message, client)
        {
            m_options = options;
            m_topCaption = topCaption;
            m_inputLength = inputLength;
            m_bottomCaption = bottomCaption;
        }

        public void Show()
        {
            //ServerPacket p = new ServerPacket(48);
            //p.WriteByte(m_dialogType);
            //if (m_dialogType != 10)
            //{
            //    p.WriteByte(m_gameObjectType);
            //    p.WriteUInt32(m_gameObjectId);
            //    p.WriteByte(m_unknown1);
            //    p.WriteUInt16(m_sprite1);
            //    p.WriteByte(m_color1);
            //    p.WriteByte(m_unknown2);
            //    p.WriteUInt16(m_sprite2);
            //    p.WriteByte(m_color2);
            //    p.WriteUInt16(m_pursuitId);
            //    p.WriteUInt16(m_dialogId);
            //    p.WriteBoolean(m_prevButton);
            //    p.WriteBoolean(m_nextButton);
            //    p.WriteByte(m_unknown3);
            //    p.WriteString8(m_gameObjectName);
            //    p.WriteString16(m_message);
            //    if (m_dialogType == 2)
            //    {
            //        p.WriteByte((byte)m_options.Length);
            //        foreach (string str in m_options)
            //            p.WriteString8(str);
            //    }
            //    if (m_dialogType == 4)
            //    {
            //        p.WriteString8(m_topCaption);
            //        p.WriteByte(m_inputLength);
            //        p.WriteString8(m_bottomCaption);
            //    }
            //}
            //m_client.SendPacketToClient(p);
        }
    }
}
