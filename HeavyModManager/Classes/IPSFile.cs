using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyModManager.Classes.IPS
{
    public class IPSFile
    {
        public (int Offset, byte[] Data)[] Patches;
        public int MaxSize = 0;
        public int ResizeValue = 0;

        public IPSFile(byte[] blob)
        {
            using (EndianBinaryReader reader = new EndianBinaryReader(new MemoryStream(blob), Endianness.Big))
            {
                if (Encoding.ASCII.GetString(reader.ReadBytes(5)) != "PATCH")
                {
                    MessageBox.Show("Invalid IPS File!");
                    return;
                }

                List<(int, byte[])> patches = new List<(int, byte[])>();

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int offset = ReadInt(reader);
                    if (offset == 0x454F46) // EOF
                        break;

                    ushort size = reader.ReadUInt16();

                    byte[] data;
                    if (size == 0)
                    {
                        size = reader.ReadUInt16();
                        byte _byte = reader.ReadByte();
                        data = Enumerable.Repeat(_byte, size).ToArray();
                    }
                    else
                    {
                        data = reader.ReadBytes(size);
                    }
                    patches.Add((offset, data));
                    MaxSize = offset + data.Length;
                }

                Patches = patches.ToArray();

                try { ResizeValue = ReadInt(reader); }
                catch { }
            }
        }
        private int ReadInt(BinaryReader reader)
        {
            byte b1 = reader.ReadByte();
            byte b2 = reader.ReadByte();
            byte b3 = reader.ReadByte();
            return BitConverter.ToInt32(new byte[] { b3, b2, b1, 0 }, 0);
        }
    }

}