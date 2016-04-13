using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Aura.Server
{
    public abstract class Packet
    {
        protected byte[] m_data;
        protected byte m_opcode;
        protected byte[] m_original;
        protected int m_position;
        protected byte m_sequence;
        protected byte m_signature;
        protected byte[] bodyData;

        public byte[] Data
        {
            get
            {
                return this.m_data;
            }
        }

        internal abstract EncryptMethod EncryptMethod { get; }

        internal byte Opcode
        {
            get
            {
                return this.m_opcode;
            }
            set
            {
                this.Opcode = value;
            }
        }

        internal byte[] Original
        {
            get
            {
                return this.m_original;
            }
        }

        internal int Position
        {
            get
            {
                return this.m_position;
            }
            set
            {
                this.m_position = value;
            }
        }

        internal byte Sequence
        {
            get
            {
                return this.m_sequence;
            }
            set
            {
                this.m_sequence = value;
            }
        }

        internal bool ShouldEncrypt
        {
            get
            {
                return (uint)this.EncryptMethod > 0U;
            }
        }

        internal byte Signature
        {
            get
            {
                return this.m_signature;
            }
        }

        public byte[] BodyData
        {
            get
            {
                return this.bodyData;
            }
            set
            {
                this.bodyData = value;
            }
        }

        internal Packet(byte opcode)
        {
            this.m_signature = (byte)170;
            this.m_opcode = opcode;
            this.m_data = new byte[0];
        }

        internal Packet(byte[] buffer)
        {
            this.m_original = buffer;
            this.m_signature = buffer[0];
            this.m_opcode = buffer[3];
            this.m_sequence = buffer[4];
            int length = buffer.Length - (this.ShouldEncrypt ? 5 : 4);
            this.m_data = new byte[length];
            Array.Copy((Array)buffer, buffer.Length - length, (Array)this.m_data, 0, length);
        }

        internal void Clear()
        {
            this.m_position = 0;
            this.m_data = new byte[0];
        }

        public abstract void Decrypt(Crypto crypto);

        public abstract void Encrypt(Crypto crypto);

        internal string GetAsciiString()
        {
            char[] chArray = new char[this.m_data.Length + 1];
            byte[] numArray = new byte[this.m_data.Length + 1];
            numArray[0] = this.m_opcode;
            Array.Copy((Array)this.m_data, 0, (Array)numArray, 1, this.m_data.Length);
            for (int index = 0; index < numArray.Length; ++index)
            {
                byte num = numArray[index];
                chArray[index] = (int)num < 32 || (int)num > 126 ? '.' : (char)num;
            }
            return new string(chArray);
        }

        internal string GetHexString()
        {
            byte[] numArray = new byte[this.m_data.Length + 1];
            numArray[0] = this.m_opcode;
            Array.Copy((Array)this.m_data, 0, (Array)numArray, 1, this.m_data.Length);
            return BitConverter.ToString(numArray).Replace('-', ' ');
        }

        internal byte[] Read(int length)
        {
            if (this.m_position + length > this.m_data.Length)
                throw new EndOfStreamException();
            byte[] numArray = new byte[length];
            Array.Copy((Array)this.m_data, this.m_position, (Array)numArray, 0, length);
            this.m_position = this.m_position + length;
            return numArray;
        }

        internal bool ReadBoolean()
        {
            if (this.m_position >= this.m_data.Length)
                throw new EndOfStreamException();
            byte[] numArray = this.m_data;
            int num = this.m_position;
            this.m_position = num + 1;
            int index = num;
            return (uint)numArray[index] > 0U;
        }

        internal byte ReadByte()
        {
            if (this.m_position >= this.m_data.Length)
                throw new EndOfStreamException();
            byte[] numArray = this.m_data;
            int num = this.m_position;
            this.m_position = num + 1;
            int index = num;
            return numArray[index];
        }

        internal short ReadInt16()
        {
            byte[] numArray = this.Read(2);
            return (short)((int)numArray[0] << 8 | (int)numArray[1]);
        }

        internal int ReadInt32()
        {
            byte[] numArray = this.Read(4);
            return (int)numArray[0] << 24 | (int)numArray[1] << 16 | (int)numArray[2] << 8 | (int)numArray[3];
        }

        internal sbyte ReadSByte()
        {
            if (this.m_position >= this.m_data.Length)
                throw new EndOfStreamException();
            byte[] numArray = this.m_data;
            int num = this.m_position;
            this.m_position = num + 1;
            int index = num;
            return (sbyte)numArray[index];
        }

        internal string ReadString()
        {
            int num = this.m_data.Length;
            for (int index = 0; index < this.m_data.Length; ++index)
            {
                if ((int)this.m_data[index] == 0)
                {
                    num = index;
                    break;
                }
            }
            byte[] bytes = new byte[num - this.m_position];
            Buffer.BlockCopy((Array)this.m_data, this.m_position, (Array)bytes, 0, bytes.Length);
            this.m_position = num + 1;
            if (this.m_position > this.m_data.Length)
                this.m_position = this.m_data.Length;
            return Encoding.GetEncoding(949).GetString(bytes);
        }

        internal string ReadString(int length)
        {
            if (this.m_position >= this.m_data.Length)
                throw new EndOfStreamException();
            if (this.m_position + length > this.m_data.Length)
            {
                this.m_position = this.m_position - 1;
                throw new EndOfStreamException();
            }
            return Encoding.GetEncoding(949).GetString(this.Read(length));
        }

        internal string ReadString16()
        {
            if (this.m_position + 1 > this.m_data.Length)
                throw new EndOfStreamException();
            int length = (int)this.ReadUInt16();
            if (this.m_position + length > this.m_data.Length)
            {
                this.m_position = this.m_position - 2;
                throw new EndOfStreamException();
            }
            return Encoding.GetEncoding(949).GetString(this.Read(length));
        }

        internal byte[] ReadBytes(int length)
        {
            if (this.m_position + length > this.m_data.Length)
                throw new EndOfStreamException();
            byte[] numArray = new byte[length];
            Array.Copy((Array)this.m_data, this.m_position, (Array)numArray, 0, length);
            this.m_position = this.m_position + length;
            return numArray;
        }

        public string ReadString8Pass()
        {
            return this.ReadString((int)this.ReadByte());
        }

        internal string ReadString8()
        {
            if (this.m_position >= this.m_data.Length)
                throw new EndOfStreamException();
            int length = (int)this.ReadByte();
            if (this.m_position + length > this.m_data.Length)
            {
                this.m_position = this.m_position - 1;
                throw new EndOfStreamException();
            }
            return Encoding.GetEncoding(949).GetString(this.Read(length));
        }

        internal ushort ReadUInt16()
        {
            byte[] numArray = this.Read(2);
            return (ushort)((uint)numArray[0] << 8 | (uint)numArray[1]);
        }

        internal uint ReadUInt32()
        {
            byte[] numArray = this.Read(4);
            return (uint)((int)numArray[0] << 24 | (int)numArray[1] << 16 | (int)numArray[2] << 8) | (uint)numArray[3];
        }

        internal byte[] ToArray()
        {
            int num = this.m_data.Length + (this.ShouldEncrypt ? 5 : 4) - 3;
            byte[] numArray = new byte[num + 3];
            numArray[0] = this.m_signature;
            numArray[1] = (byte)(num / 256);
            numArray[2] = (byte)(num % 256);
            numArray[3] = this.m_opcode;
            numArray[4] = this.m_sequence;
            Array.Copy((Array)this.m_data, 0, (Array)numArray, numArray.Length - this.m_data.Length, this.m_data.Length);
            return numArray;
        }

        internal void Write(byte[] buffer)
        {
            int newSize = this.m_position + buffer.Length;
            if (newSize > this.m_data.Length)
                Array.Resize<byte>(ref this.m_data, newSize);
            Array.Copy((Array)buffer, 0, (Array)this.m_data, this.m_position, buffer.Length);
            this.m_position = this.m_position + buffer.Length;
        }

        internal void WriteArray(Array value)
        {
            foreach (object obj in value)
            {
                if (obj is byte)
                    this.WriteByte((byte)obj);
                if (obj is sbyte)
                    this.WriteSByte((sbyte)obj);
                if (obj is bool)
                    this.WriteBoolean((bool)obj);
                if (obj is short)
                    this.WriteInt16((short)obj);
                if (obj is ushort)
                    this.WriteUInt16((ushort)obj);
                if (obj is int)
                    this.WriteInt32((int)obj);
                if (obj is uint)
                    this.WriteUInt32((uint)obj);
                if (obj is string)
                    this.WriteString8((string)obj);
                if (obj is Array)
                    this.WriteArray((Array)obj);
            }
        }

        internal void WriteBoolean(bool value)
        {
            this.WriteByte(value ? (byte)1 : (byte)0);
        }

        internal void WriteByte(byte value)
        {
            byte[] buffer = new byte[1];
            int index = 0;
            int num = (int)value;
            buffer[index] = (byte)num;
            this.Write(buffer);
        }

        internal void WriteInt16(short value)
        {
            byte[] buffer = new byte[2];
            int index1 = 0;
            int num1 = (int)(byte)((uint)value >> 8);
            buffer[index1] = (byte)num1;
            int index2 = 1;
            int num2 = (int)(byte)value;
            buffer[index2] = (byte)num2;
            this.Write(buffer);
        }

        internal void WriteInt32(int value)
        {
            byte[] buffer = new byte[4];
            int index1 = 0;
            int num1 = (int)(byte)(value >> 24);
            buffer[index1] = (byte)num1;
            int index2 = 1;
            int num2 = (int)(byte)(value >> 16);
            buffer[index2] = (byte)num2;
            int index3 = 2;
            int num3 = (int)(byte)(value >> 8);
            buffer[index3] = (byte)num3;
            int index4 = 3;
            int num4 = (int)(byte)value;
            buffer[index4] = (byte)num4;
            this.Write(buffer);
        }

        internal void WriteSByte(sbyte value)
        {
            byte[] buffer = new byte[1];
            int index = 0;
            int num = (int)(byte)value;
            buffer[index] = (byte)num;
            this.Write(buffer);
        }

        internal void WriteString(string value, bool terminate = false)
        {
            this.Write(Encoding.GetEncoding(949).GetBytes(value));
            if (!terminate)
                return;
            this.WriteByte((byte)0);
        }

        internal void WriteString16(string value)
        {
            byte[] bytes = Encoding.GetEncoding(949).GetBytes(value);
            if (bytes.Length > (int)ushort.MaxValue)
                throw new ArgumentOutOfRangeException("value", (object)value, "Length of string must not exceed 65535 characters");
            this.WriteUInt16((ushort)bytes.Length);
            this.Write(bytes);
        }

        internal void WriteString8(string value)
        {
            byte[] bytes = Encoding.GetEncoding(949).GetBytes(value);
            this.WriteByte((byte)bytes.Length);
            this.Write(bytes);
        }

        internal void WriteUInt16(ushort value)
        {
            byte[] buffer = new byte[2];
            int index1 = 0;
            int num1 = (int)(byte)((uint)value >> 8);
            buffer[index1] = (byte)num1;
            int index2 = 1;
            int num2 = (int)(byte)value;
            buffer[index2] = (byte)num2;
            this.Write(buffer);
        }

        internal void WriteUInt32(uint value)
        {
            byte[] buffer = new byte[4];
            int index1 = 0;
            int num1 = (int)(byte)(value >> 24);
            buffer[index1] = (byte)num1;
            int index2 = 1;
            int num2 = (int)(byte)(value >> 16);
            buffer[index2] = (byte)num2;
            int index3 = 2;
            int num3 = (int)(byte)(value >> 8);
            buffer[index3] = (byte)num3;
            int index4 = 3;
            int num4 = (int)(byte)value;
            buffer[index4] = (byte)num4;
            this.Write(buffer);
        }
    }
}
