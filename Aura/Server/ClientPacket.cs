using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Aura.Server
{
    public class ClientPacket : Packet
    {
        private static ushort[] dialogCrcTable = new ushort[256]
        {
      0x0000, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7,
            0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF,
            0x1231, 0x0210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6,
            0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE,
            0x2462, 0x3443, 0x0420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485,
            0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
            0x3653, 0x2672, 0x1611, 0x0630, 0x76D7, 0x66F6, 0x5695, 0x46B4,
            0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC,
            0x48C4, 0x58E5, 0x6886, 0x78A7, 0x0840, 0x1861, 0x2802, 0x3823,
            0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
            0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0x0A50, 0x3A33, 0x2A12,
            0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
            0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0x0C60, 0x1C41,
            0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
            0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0x0E70,
            0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78,
            0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F,
            0x1080, 0x00A1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
            0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E,
            0x02B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
            0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
            0x34E2, 0x24C3, 0x14A0, 0x0481, 0x7466, 0x6447, 0x5424, 0x4405,
            0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 0xC71D, 0xD73C,
            0x26D3, 0x36F2, 0x0691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
            0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB,
            0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x08E1, 0x3882, 0x28A3,
            0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A,
            0x4A75, 0x5A54, 0x6A37, 0x7A16, 0x0AF1, 0x1AD0, 0x2AB3, 0x3A92,
            0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9,
            0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0x0CC1,
            0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8,
            0x6E17, 0x7E36, 0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0x0ED1, 0x1EF0
        };

        internal override EncryptMethod EncryptMethod
        {
            get
            {
                byte num = this.m_opcode;
                if ((uint)num <= 67U)
                {
                    if ((uint)num <= 38U)
                    {
                        if ((uint)num <= 11U)
                        {
                            switch (num)
                            {
                                case (byte)0:
                                    break;
                                case (byte)2:
                                case (byte)3:
                                case (byte)4:
                                case (byte)11:
                                    goto label_18;
                                default:
                                    goto label_19;
                            }
                        }
                        else if ((int)num != 16)
                        {
                            if ((int)num == 38)
                                goto label_18;
                            else
                                goto label_19;
                        }
                    }
                    else if ((uint)num <= 58U)
                    {
                        if ((int)num == 45 || (int)num == 58)
                            goto label_18;
                        else
                            goto label_19;
                    }
                    else if ((int)num == 66 || (int)num == 67)
                        goto label_18;
                    else
                        goto label_19;
                }
                else if ((uint)num <= 98U)
                {
                    if ((uint)num <= 75U)
                    {
                        if ((int)num != 72)
                        {
                            if ((int)num == 75)
                                goto label_18;
                            else
                                goto label_19;
                        }
                    }
                    else if ((int)num == 87 || (int)num == 98)
                        goto label_18;
                    else
                        goto label_19;
                }
                else if ((uint)num <= 113U)
                {
                    if ((int)num == 104 || (int)num == 113)
                        goto label_18;
                    else
                        goto label_19;
                }
                else if ((int)num == 115 || (int)num == 123)
                    goto label_18;
                else
                    goto label_19;
                return EncryptMethod.None;
                label_18:
                return EncryptMethod.Normal;
                label_19:
                return EncryptMethod.MD5Key;
            }
        }

        internal bool IsDialog
        {
            get
            {
                if ((int)this.m_opcode != 57)
                    return (int)this.m_opcode == 58;
                return true;
            }
        }

        public bool UseDefaultKey
        {
            get
            {
                if ((int)this.Opcode != 2 && (int)this.Opcode != 3 && ((int)this.Opcode != 4 && (int)this.Opcode != 11) && ((int)this.Opcode != 38 && (int)this.Opcode != 45 && ((int)this.Opcode != 58 && (int)this.Opcode != 66)) && ((int)this.Opcode != 67 && (int)this.Opcode != 75 && ((int)this.Opcode != 87 && (int)this.Opcode != 98) && ((int)this.Opcode != 104 && (int)this.Opcode != 113 && (int)this.Opcode != 115)))
                    return (int)this.Opcode == 123;
                return true;
            }
        }

        internal ClientPacket(byte opcode)
          : base(opcode)
        {
        }

        internal ClientPacket(byte[] buffer)
          : base(buffer)
        {
        }

        internal ClientPacket Copy()
        {
            ClientPacket clientPacket = new ClientPacket(this.m_opcode);
            byte[] buffer = this.m_data;
            clientPacket.Write(buffer);
            return clientPacket;
        }

        public override void Decrypt(Crypto crypto)
        {
            int num = this.m_data.Length - 7;
            ushort a = (ushort)(((int)this.m_data[num + 6] << 8 | (int)this.m_data[num + 4]) ^ 29808);
            byte b = (byte)((uint)this.m_data[num + 5] ^ 35U);
            int newSize;
            byte[] numArray;
            switch (this.EncryptMethod)
            {
                case EncryptMethod.Normal:
                    newSize = num - 1;
                    numArray = crypto.Key;
                    break;
                case EncryptMethod.MD5Key:
                    newSize = num - 2;
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

        internal void DecryptDialog()
        {
            int num1 = (int)(byte)((uint)this.m_data[1] ^ (uint)(byte)((uint)this.m_data[0] - 45U));
            int num2 = 114;
            byte num3 = (byte)(num1 + num2);
            int num4 = 40;
            byte num5 = (byte)(num1 + num4);
            this.m_data[2] = (byte)((uint)this.m_data[2] ^ (uint)num3);
            this.m_data[3] = (byte)((uint)this.m_data[3] ^ (uint)(byte)(((int)num3 + 1) % 256));
            int num6 = (int)this.m_data[2] << 8 | (int)this.m_data[3];
            for (int index = 0; index < num6; ++index)
                this.m_data[4 + index] = (byte)((uint)this.m_data[4 + index] ^ (uint)(byte)(((int)num5 + index) % 256));
            Buffer.BlockCopy((Array)this.m_data, 6, (Array)this.m_data, 0, this.m_data.Length - 6);
            Array.Resize<byte>(ref this.m_data, this.m_data.Length - 6);
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
                    this.WriteByte((byte)0);
                    numArray = crypto.Key;
                    break;
                case EncryptMethod.MD5Key:
                    this.WriteByte((byte)0);
                    this.WriteByte(this.m_opcode);
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
            byte[] buffer = new byte[this.m_data.Length + 2];
            buffer[0] = this.m_opcode;
            buffer[1] = this.m_sequence;
            Buffer.BlockCopy((Array)this.m_data, 0, (Array)buffer, 2, this.m_data.Length);
            byte[] hash = MD5.Create().ComputeHash(buffer);
            this.WriteByte(hash[13]);
            this.WriteByte(hash[3]);
            this.WriteByte(hash[11]);
            this.WriteByte(hash[7]);
            this.WriteByte((byte)((int)a % 256 ^ 112));
            this.WriteByte((byte)((uint)b ^ 35U));
            this.WriteByte((byte)(((int)a >> 8) % 256 ^ 116));
        }

        internal void EncryptDialog()
        {
            Array.Resize<byte>(ref this.m_data, this.m_data.Length + 6);
            Buffer.BlockCopy((Array)this.m_data, 0, (Array)this.m_data, 6, this.m_data.Length - 6);
            this.GenerateDialogHeader();
            int num1 = (int)this.m_data[2] << 8 | (int)this.m_data[3];
            int num2 = (int)(byte)((uint)this.m_data[1] ^ (uint)(byte)((uint)this.m_data[0] - 45U));
            int num3 = 114;
            byte num4 = (byte)(num2 + num3);
            int num5 = 40;
            byte num6 = (byte)(num2 + num5);
            this.m_data[2] = (byte)((uint)this.m_data[2] ^ (uint)num4);
            this.m_data[3] = (byte)((uint)this.m_data[3] ^ (uint)(byte)(((int)num4 + 1) % 256));
            for (int index = 0; index < num1; ++index)
                this.m_data[4 + index] = (byte)((uint)this.m_data[4 + index] ^ (uint)(byte)(((int)num6 + index) % 256));
        }

        public void GenerateDialogHeader()
        {
            ushort num = (ushort)0;
            for (int index = 0; index < this.m_data.Length - 6; ++index)
                num = (ushort)((uint)this.m_data[6 + index] ^ ((uint)(ushort)((uint)num << 8) ^ (uint)ClientPacket.dialogCrcTable[(int)num >> 8]));
            this.m_data[0] = (byte)Utility.Random();
            this.m_data[1] = (byte)Utility.Random();
            this.m_data[2] = (byte)((this.m_data.Length - 4) / 256);
            this.m_data[3] = (byte)((this.m_data.Length - 4) % 256);
            this.m_data[4] = (byte)((uint)num / 256U);
            this.m_data[5] = (byte)((uint)num % 256U);
        }

        public override string ToString()
        {
            return string.Format("[Send] {0}", (object)this.GetHexString());
        }
    }
}
