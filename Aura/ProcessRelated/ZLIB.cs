using System;
using System.IO;
using zlib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aura.ProcessRelated
{
    internal static class ZLIB
    {
        internal static MemoryStream Compress(byte[] buffer)
        {
            MemoryStream memoryStream1 = new MemoryStream();
            using (MemoryStream memoryStream2 = new MemoryStream(buffer))
            {
                using (ZOutputStream zoutputStream = new ZOutputStream((Stream)memoryStream1, -1))
                {
                    memoryStream2.Seek(0L, SeekOrigin.Begin);
                    byte[] buffer1 = new byte[2000];
                    int count;
                    while ((count = memoryStream2.Read(buffer1, 0, 2000)) > 0)
                        zoutputStream.Write(buffer1, 0, count);
                    zoutputStream.Flush();
                }
            }
            return memoryStream1;
        }

        internal static MemoryStream Decompress(byte[] buffer)
        {
            MemoryStream memoryStream = new MemoryStream();
            ZOutputStream zoutputStream = new ZOutputStream((Stream)memoryStream);
            int offset = 0;
            while (offset < buffer.Length)
            {
                int num = buffer.Length - offset;
                int count = num > 2000 ? 2000 : num;
                zoutputStream.Write(buffer, offset, count);
                offset += count;
            }
            zoutputStream.Flush();
            memoryStream.Seek(0L, SeekOrigin.Begin);
            return memoryStream;
        }

        internal static void Compress(string inFile, string outFile)
        {
            FileStream fileStream1 = new FileStream(outFile, FileMode.Create);
            ZOutputStream zoutputStream = new ZOutputStream((Stream)fileStream1, -1);
            FileStream fileStream2 = new FileStream(inFile, FileMode.Open);
            try
            {
                ZLIB.CopyStream((Stream)fileStream2, (Stream)zoutputStream);
            }
            finally
            {
                zoutputStream.Close();
                fileStream1.Close();
                fileStream2.Close();
            }
        }

        internal static void Decompress(string inFile, string outFile)
        {
            FileStream fileStream1 = new FileStream(outFile, FileMode.Create);
            ZOutputStream zoutputStream = new ZOutputStream((Stream)fileStream1);
            FileStream fileStream2 = new FileStream(inFile, FileMode.Open);
            try
            {
                ZLIB.CopyStream((Stream)fileStream2, (Stream)zoutputStream);
            }
            finally
            {
                zoutputStream.Close();
                fileStream1.Close();
                fileStream2.Close();
            }
        }

        internal static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[2000];
            int count;
            while ((count = input.Read(buffer, 0, 2000)) > 0)
                output.Write(buffer, 0, count);
            output.Flush();
        }
    }
}
