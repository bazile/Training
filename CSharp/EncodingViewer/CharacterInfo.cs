using System.Collections.Generic;

namespace EncodingViewer
{
    class CharacterInfo
    {
        private readonly char _character;

        public char Character
        {
            get { return _character; }
        }

        public string EncodingName { get; set; }
        public IEnumerable<byte> Bytes { get; set; }

        public CharacterInfo(char character)
        {
            _character = character;
        }
    }
}
