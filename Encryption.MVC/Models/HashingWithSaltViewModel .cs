using Microsoft.AspNetCore.Mvc.Rendering;

namespace Encryption.MVC.Models
{
    /// <summary>
    /// View Model for Hashing With Salt
    /// </summary>
    public class HashingWithSaltViewModel
    {
        #region fields
        private List<SelectListItem> _hashingTypes;
        private string _selectedHashingType;
        private int _saltLenght;
        private string _inputSalt;
        private string _input;
        private string _outputSaltString;
        private string _outputHashedString;
        private string _outputHashValue;
        #endregion

        #region Constructor
        public HashingWithSaltViewModel()
        {
            HashingTypes = new List<SelectListItem>();
            PopulateHashingTypes();
            _saltLenght = 8;
        }
        public HashingWithSaltViewModel(string salt, string hashedString, string Hashvalue)
        {
            HashingTypes = new List<SelectListItem>();
            PopulateHashingTypes();
            _outputSaltString = salt;
            _outputHashedString = hashedString;
            _outputHashValue = Hashvalue;
            _saltLenght = 8;
        }
        #endregion

        #region Methods
        private void PopulateHashingTypes()
        {
            HashingTypes.Add(new SelectListItem { Value = "SHA1", Text = "SHA1" });
            HashingTypes.Add(new SelectListItem { Value = "SHA256", Text = "SHA256" });
            HashingTypes.Add(new SelectListItem { Value = "SHA384", Text = "SHA384" });
            HashingTypes.Add(new SelectListItem { Value = "SHA512", Text = "SHA512" });
            HashingTypes.Add(new SelectListItem { Value = "MD5", Text = "MD5" });
        }
        #endregion

        #region Properties
        public List<SelectListItem> HashingTypes
        {
            get { return _hashingTypes; }
            set { _hashingTypes = value; }
        }
        public string SelectedHashingTypes
        {
            get { return _selectedHashingType; }
            set { _selectedHashingType = value; }
        }
        public int SaltLength
        {
            get { return _saltLenght; }
            set { _saltLenght = value; }
        }

        public string InputSalt
        {
            get { return _inputSalt; }
            set { _inputSalt = value; }
        }

        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }
        public string OutputHashValue
        {
            get { return _outputHashValue; }
            set { _outputHashValue = value; }
        }
        public string OutputHashedString
        {
            get { return _outputHashedString; }
            set { _outputHashedString = value; }
        }
        public string OutputSaltString
        {
            get { return _outputSaltString; }
            set { _outputSaltString = value; }
        }
        #endregion
    }
}
