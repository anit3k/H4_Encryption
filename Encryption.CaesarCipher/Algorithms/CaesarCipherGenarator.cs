using System.Text;

namespace Encryption.CaesarCipher.Algorithms
{
    public class CaesarCipherGenarator : ICaesarCipherGenerator
    {
        private List<string> _alphabetUpper = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Æ", "Ø", "Å" };
        private List<string> _alphabetLower = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "y", "z", "æ", "ø", "å" };
               
        public string CipherText(string data, int shiftIndex, bool isDecrypt)
        {
            // list of chars from input
            List<string> original = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                original.Add(data[i].ToString());
            }

            List<string> result = new List<string>();
            for (int i = 0; i < original.Count; i++)
            {
                Tuple<List<string>, int> indexFromAlphabet = GetIndexFromAlphabet(original[i]);
                switch (indexFromAlphabet.Item2)
                {
                    case -1:
                        result.Add(original[i]);
                        break;
                    default:
                        var newIndex = CalculateNewIndex(indexFromAlphabet.Item2, shiftIndex, isDecrypt);
                        result.Add(indexFromAlphabet.Item1[newIndex].ToString());
                        break;
                }
            }

            StringBuilder builder = new StringBuilder();
            foreach (var item in result)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }


        private Tuple<List<string>, int> GetIndexFromAlphabet(string character)
        {
            if (_alphabetLower.IndexOf(character) != -1)
            {
                return new Tuple<List<string>, int>(_alphabetLower, _alphabetLower.IndexOf(character));
            }
            return new Tuple<List<string>, int>(_alphabetUpper, _alphabetUpper.IndexOf(character));
        }


        private int CalculateNewIndex(int currentIndex, int move, bool isDecrypt)
        {
            int difference = 0;

            if (isDecrypt == false)
            {
                if (currentIndex + move < _alphabetUpper.Count)
                {
                    return currentIndex + move;
                }
                difference = _alphabetUpper.Count - currentIndex;
                int rest = 0;
                if (difference < move)
                {
                    rest = move - difference;
                }
                else
                {
                    rest = difference - move;
                }
                return rest;
            }

            if (currentIndex - move > 0)
            {
                return currentIndex - move;
            }
            difference = move - currentIndex;
            return _alphabetUpper.Count - difference;
        }



    }
}
