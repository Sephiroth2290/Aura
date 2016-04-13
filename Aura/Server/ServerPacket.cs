using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.Server
{
    public sealed class ServerPacket : Packet
    {
        public bool UseDefaultKey
        {
            get
            {
                if (Opcode != 1 && Opcode != 2 && (Opcode != 10 && Opcode != 86) && (Opcode != 96 && Opcode != 98 && Opcode != 102))
                    return Opcode == 111;
                return true;
            }
        }

        internal override EncryptMethod EncryptMethod
        {
            get
            {
                byte num = m_opcode;
                if (num <= 86)
                {
                    if (num <= 10U)
                    {
                        switch (num)
                        {
                            case 0:
                            case 3:
                                break;
                            case 1:
                            case 2:
                            case 10:
                                goto label_10;
                            default:
                                goto label_11;
                        }
                    }
                    else if ((int)num != 64)
                    {
                        if ((int)num == 86)
                            goto label_10;
                        else
                            goto label_11;
                    }
                }
                else if ((int)num <= 102)
                {
                    if ((int)num == 96 || (int)num == 98 || (int)num == 102)
                        goto label_10;
                    else
                        goto label_11;
                }
                else if ((int)num != 111)
                {
                    if ((int)num != 126)
                        goto label_11;
                }
                else
                    goto label_10;
                return EncryptMethod.None;
                label_10:
                return EncryptMethod.Normal;
                label_11:
                return EncryptMethod.MD5Key;
            }
        }

        internal ServerPacket(byte opcode)
          : base(opcode)
        {
        }

        internal ServerPacket(byte[] buffer)
          : base(buffer)
        {
        }

        internal ServerPacket Copy()
        {
            ServerPacket serverPacket = new ServerPacket(this.m_opcode);
            byte[] buffer = this.m_data;
            serverPacket.Write(buffer);
            return serverPacket;
        }

        public override void Decrypt(Crypto crypto)
        {
            int newSize = this.m_data.Length - 3;
            ushort a = (ushort)(((int)this.m_data[newSize + 2] << 8 | (int)this.m_data[newSize]) ^ 25716);
            byte b = (byte)((uint)this.m_data[newSize + 1] ^ 36U);
            byte[] numArray;
            switch (this.EncryptMethod)
            {
                case EncryptMethod.Normal:
                    numArray = crypto.Key;
                    break;
                case EncryptMethod.MD5Key:
                    numArray = crypto.GenerateKey(a, b);
                    break;
                default:
                    return;
            }
            for (int index1 = 0; index1 < newSize; ++index1)
            {
                int index2 = index1 / crypto.Key.Length % 256;
                this.m_data[index1] = (byte)((uint)this.m_data[index1] ^ (uint)(byte)((uint)crypto.Salt[index2] ^ (uint)numArray[index1 % numArray.Length]));
                if (index2 != (int)this.m_sequence)
                    this.m_data[index1] = (byte)((uint)this.m_data[index1] ^ (uint)crypto.Salt[(int)this.m_sequence]);
            }
            Array.Resize<byte>(ref this.m_data, newSize);
        }

        public override void Encrypt(Crypto crypto)
        {
            this.m_position = this.m_data.Length;
            ushort a = (ushort)(Utility.Random(65277) + 256);
            byte b = (byte)(Utility.Random(155) + 100);
            byte[] numArray;
            switch (this.EncryptMethod)
            {
                case EncryptMethod.Normal:
                    numArray = crypto.Key;
                    break;
                case EncryptMethod.MD5Key:
                    numArray = crypto.GenerateKey(a, b);
                    break;
                default:
                    return;
            }
            for (int index1 = 0; index1 < this.m_data.Length; ++index1)
            {
                int index2 = index1 / crypto.Key.Length % 256;
                this.m_data[index1] = (byte)((uint)this.m_data[index1] ^ (uint)(byte)((uint)crypto.Salt[index2] ^ (uint)numArray[index1 % numArray.Length]));
                if (index2 != (int)this.m_sequence)
                    this.m_data[index1] = (byte)((uint)this.m_data[index1] ^ (uint)crypto.Salt[(int)this.m_sequence]);
            }
            this.WriteByte((byte)((int)a % 256 ^ 116));
            this.WriteByte((byte)((uint)b ^ 36U));
            this.WriteByte((byte)(((int)a >> 8) % 256 ^ 100));
        }

        public override string ToString()
        {
            return string.Format("[Recv] {0}", (object)this.GetHexString());
        }
    }

}
