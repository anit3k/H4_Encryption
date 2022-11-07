using System.Text;

namespace Encryption.CaesarCipher.Algorithms
{
    public class CaesarCipherGenarator : ICaesarCipherGenerator
    {
        #region fields
        private List<string> _alphabetUpper = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Æ", "Ø", "Å" };
        private List<string> _alphabetLower = new List<string> { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "z", "y", "z", "æ", "ø", "å" };
        private List<string> addedCharString = new List<string>();
        #endregion

        #region Public Method
        public string CipherText(string data, int shiftIndex, bool isDecrypt)
        {
            // list of chars from input
            List<string> input = ExtractDataToSingleChars(data);

            for (int i = 0; i < input.Count; i++)
            {
                Tuple<List<string>, int> currentIndex = GetIndexFromCorrectAlphabet(input[i]);
                switch (currentIndex.Item2)
                {
                    case -1: // non alphanumeric value, could be " " or symbols like "." etc
                        addedCharString.Add(input[i]); 
                        break;
                    default: // alphanumeric value
                        var newIndex = CalculateNewIndex(currentIndex.Item2, shiftIndex, isDecrypt);
                        addedCharString.Add(currentIndex.Item1[newIndex].ToString());
                        break;
                }
            }

            return BuildFinalResult();
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Gets a list that contains string of each character in the data to be ciphered
        /// </summary>
        /// <param name="data"></param>
        /// <returns>list of strings/chars</returns>
        private List<string> ExtractDataToSingleChars(string data)
        {
            List<string> original = new List<string>();
            for (int i = 0; i < data.Length; i++)
            {
                original.Add(data[i].ToString());
            }

            return original;
        }
        /// <summary>
        /// Gets the current index from the alphabet
        /// </summary>
        /// <param name="character">character in string format to find the current index in the alphabet</param>
        /// <returns>interger of current alphabet</returns>
        private Tuple<List<string>, int> GetIndexFromCorrectAlphabet(string character)
        {
            if (_alphabetLower.IndexOf(character) != -1)
            {
                return new Tuple<List<string>, int>(_alphabetLower, _alphabetLower.IndexOf(character));
            }
            return new Tuple<List<string>, int>(_alphabetUpper, _alphabetUpper.IndexOf(character));
        }
        /// <summary>
        /// Algorithm to calculate new index
        /// </summary>
        /// <param name="currentIndex">integer of the current index in the alphabet</param>
        /// <param name="move">Spaces to move the index</param>
        /// <param name="isDecrypt">used to measure right/encrypt or left/decrypt</param>
        /// <returns></returns>
        private int CalculateNewIndex(int currentIndex, int move, bool isDecrypt)
        {
            int difference = 0;

            // algorithm to count right to find new index - Encrypt
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

            // Algorithm to count left - Decrypt
            if (currentIndex - move > 0)
            {
                return currentIndex - move;
            }
            difference = move - currentIndex;
            return _alphabetUpper.Count - difference;
        }
        /// <summary>
        /// Convert list of result to a string
        /// </summary>
        /// <returns>string of result</returns>
        private string BuildFinalResult()
        {            
            StringBuilder builder = new StringBuilder();
            foreach (var item in addedCharString)
            {
                builder.Append(item);
            }
            return builder.ToString();
        }
        #endregion
    }
}
