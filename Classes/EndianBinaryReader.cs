namespace HeavyModManager.Classes
{
    public enum Endianness
    {
        Little,
        Big
    }

    public class EndianBinaryReader : BinaryReader
    {
        public readonly Endianness endianness;

        public EndianBinaryReader(Stream stream, Endianness endianness) : base(stream)
        {
            this.endianness = endianness;
        }

        public override float ReadSingle()
        {
            if (endianness == Endianness.Little)
                return base.ReadSingle();
            return BitConverter.ToSingle(ReadReverse4(), 0);
        }

        public override short ReadInt16()
        {
            if (endianness == Endianness.Little)
                return base.ReadInt16();
            return BitConverter.ToInt16(ReadReverse2(), 0);
        }

        public override int ReadInt32()
        {
            if (endianness == Endianness.Little)
                return base.ReadInt32();
            return BitConverter.ToInt32(ReadReverse4(), 0);
        }

        public override ushort ReadUInt16()
        {
            if (endianness == Endianness.Little)
                return base.ReadUInt16();
            return BitConverter.ToUInt16(ReadReverse2(), 0);
        }

        public override uint ReadUInt32()
        {
            if (endianness == Endianness.Little)
                return base.ReadUInt32();
            return BitConverter.ToUInt32(ReadReverse4(), 0);
        }

        private byte[] ReadReverse2()
        {
            var b0 = base.ReadByte();
            var b1 = base.ReadByte();
            return new byte[2] { b1, b0 };
        }

        private byte[] ReadReverse4()
        {
            var b0 = base.ReadByte();
            var b1 = base.ReadByte();
            var b2 = base.ReadByte();
            var b3 = base.ReadByte();
            return new byte[4] { b3, b2, b1, b0 };
        }

        public override string ReadString()
        {
            var chars = new List<char>();
            do
                chars.Add((char)ReadByte());
            while (chars.Last() != '\0');
            chars.Remove('\0');

            return new string(chars.ToArray());
        }

        public bool EndOfStream => BaseStream.Position == BaseStream.Length;
    }
}
