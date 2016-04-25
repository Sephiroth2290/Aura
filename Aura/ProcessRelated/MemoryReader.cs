using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    public class MemoryReader
    {
        public static byte[] ReadBytes(Process hProcess, int lpBaseAddress, int nSize)
        {
            byte[] numArray = new byte[nSize];
            try
            {
                IntPtr num1 = Kernel32.OpenProcess(ProcessAccess.VmRead, false, hProcess.Id);
                int lpBaseAddress1 = lpBaseAddress;
                byte[] lpBuffer = numArray;
                int nSize1 = nSize;
                int num2 = 0;
                Kernel32.ReadProcessMemory(num1, lpBaseAddress1, lpBuffer, nSize1, (byte)num2);
                Kernel32.CloseHandle(num1);
            }
            catch
            {
            }
            return numArray;
        }

        public static byte ReadByte(Process hProcess, int lpBaseAddress)
        {
            return MemoryReader.ReadBytes(hProcess, lpBaseAddress, 1)[0];
        }

        public static sbyte ReadSByte(Process hProcess, int lpBaseAddress)
        {
            return (sbyte)MemoryReader.ReadBytes(hProcess, lpBaseAddress, 1)[0];
        }

        public static short ReadInt16(Process hProcess, int lpBaseAddress)
        {
            byte[] numArray = MemoryReader.ReadBytes(hProcess, lpBaseAddress, 2);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse((Array)numArray);
            return BitConverter.ToInt16(numArray, 0);
        }

        public static ushort ReadUInt16(Process hProcess, int lpBaseAddress)
        {
            byte[] numArray = MemoryReader.ReadBytes(hProcess, lpBaseAddress, 2);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse((Array)numArray);
            return BitConverter.ToUInt16(numArray, 0);
        }

        public static int ReadInt32(Process hProcess, int lpBaseAddress)
        {
            byte[] numArray = MemoryReader.ReadBytes(hProcess, lpBaseAddress, 4);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse((Array)numArray);
            return BitConverter.ToInt32(numArray, 0);
        }

        public static uint ReadUInt32(Process hProcess, int lpBaseAddress)
        {
            byte[] numArray = MemoryReader.ReadBytes(hProcess, lpBaseAddress, 4);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse((Array)numArray);
            return BitConverter.ToUInt32(numArray, 0);
        }

        public static long ReadInt64(Process hProcess, int lpBaseAddress)
        {
            byte[] numArray = MemoryReader.ReadBytes(hProcess, lpBaseAddress, 4);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse((Array)numArray);
            return BitConverter.ToInt64(numArray, 0);
        }

        public static ulong ReadUInt64(Process hProcess, int lpBaseAddress)
        {
            byte[] numArray = MemoryReader.ReadBytes(hProcess, lpBaseAddress, 4);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse((Array)numArray);
            return BitConverter.ToUInt64(numArray, 0);
        }

        public static string ReadString(Process hProcess, int lpBaseAddress, int length)
        {
            byte[] array = MemoryReader.ReadBytes(hProcess, lpBaseAddress, length);
            for (int newSize = 0; newSize < length; ++newSize)
            {
                if ((int)array[newSize] == 0)
                {
                    Array.Resize<byte>(ref array, newSize);
                    break;
                }
            }
            return Encoding.GetEncoding(949).GetString(array);
        }

        public static string ReadString(Process hProcess, int lpBaseAddress)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte num;
            do
            {
                num = MemoryReader.ReadByte(hProcess, lpBaseAddress);
                if ((int)num != 0)
                    stringBuilder.Append((char)num);
            }
            while ((int)num != 0);
            return stringBuilder.ToString();
        }
    }
}
