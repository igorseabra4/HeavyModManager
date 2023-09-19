namespace HeavyModManager.Classes
{
    /// <summary>
    /// The endianness of the stream.
    /// </summary>
    public enum Endianness
    {
        Little,
        Big
    }

    /// <summary>
    /// A binary reader that can read in big or little endian.
    /// </summary>
    public class EndianBinaryReader : BinaryReader
    {
        /// <summary>
        /// The stream endianness.
        /// </summary>
        public Endianness Endianness { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EndianBinaryReader"/> class.
        /// </summary>
        /// <param name="stream">The stream to read from</param>
        /// <param name="endianness">The endianness of the stream</param>
        public EndianBinaryReader(Stream stream, Endianness endianness) : base(stream)
        {
            Endianness = endianness;
        }

        /// <summary>
        /// Reads a 4-byte float from the stream.
        /// </summary>
        /// <returns>The 4-byte float</returns>
        public override float ReadSingle()
        {
            if (Endianness == Endianness.Little)
                return base.ReadSingle();
            return BitConverter.ToSingle(ReadReverse4(), 0);
        }

        /// <summary>
        /// Reads a 2-byte integer from the stream.
        /// </summary>
        /// <returns>The 2-byte integer</returns>
        public override short ReadInt16()
        {
            if (Endianness == Endianness.Little)
                return base.ReadInt16();
            return BitConverter.ToInt16(ReadReverse2(), 0);
        }

        /// <summary>
        /// Reads a 4-byte integer from the stream.
        /// </summary>
        /// <returns>The 4-byte integer</returns>
        public override int ReadInt32()
        {
            if (Endianness == Endianness.Little)
                return base.ReadInt32();
            return BitConverter.ToInt32(ReadReverse4(), 0);
        }

        /// <summary>
        /// Reads an unsigned 2-byte integer from the stream.
        /// </summary>
        /// <returns>The 2-byte integer</returns>
        public override ushort ReadUInt16()
        {
            if (Endianness == Endianness.Little)
                return base.ReadUInt16();
            return BitConverter.ToUInt16(ReadReverse2(), 0);
        }

        /// <summary>
        /// Reads an unsigned 4-byte integer from the stream.
        /// </summary>
        /// <returns>The unsigned 4-byte integer</returns>
        public override uint ReadUInt32()
        {
            if (Endianness == Endianness.Little)
                return base.ReadUInt32();
            return BitConverter.ToUInt32(ReadReverse4(), 0);
        }

        /// <summary>
        /// Reads two bytes from the stream in reverse order.
        /// </summary>
        /// <returns>The 2-byte array with the values in reverse order</returns>
        private byte[] ReadReverse2()
        {
            var b0 = base.ReadByte();
            var b1 = base.ReadByte();
            return new byte[2] { b1, b0 };
        }

        /// <summary>
        /// Reads four bytes from the stream in reverse order.
        /// </summary>
        /// <returns>The 4-byte array with the values in reverse order</returns>
        private byte[] ReadReverse4()
        {
            var b0 = base.ReadByte();
            var b1 = base.ReadByte();
            var b2 = base.ReadByte();
            var b3 = base.ReadByte();
            return new byte[4] { b3, b2, b1, b0 };
        }

        /// <summary>
        /// Reads a null-terminated string from the stream.
        /// </summary>
        /// <returns>The string, without the null character</returns>
        public override string ReadString()
        {
            var chars = new List<char>();
            do
                chars.Add((char)ReadByte());
            while (chars.Last() != '\0');
            chars.Remove('\0');

            return new string(chars.ToArray());
        }

        /// <summary>
        /// Whether the reader has reached the end of the stream.
        /// </summary>
        public bool EndOfStream => BaseStream.Position == BaseStream.Length;
    }
}
