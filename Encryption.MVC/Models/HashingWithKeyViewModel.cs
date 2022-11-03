using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Encryption.MVC.Models
{
    /// <summary>
    /// View Model for Hashing With Key
    /// </summary>
    public class HashingWithKeyViewModel
    {
        #region fields
        private List<SelectListItem> _hashingTypes;
        private string _selectedHashingType;
        private int _keyLength;
        private string _input;
        private string _outputKey;
        private string _outputHashedString;
        private string _outputHashValue;
        #endregion

        #region Constructor
        public HashingWithKeyViewModel()
        {
            HashingTypes = new List<SelectListItem>();
            PopulateHashingTypes();
            _keyLength = 8;
        }
        public HashingWithKeyViewModel(string key, string hashedString, string hashValue)
        {
            HashingTypes = new List<SelectListItem>();
            PopulateHashingTypes();
            _outputKey = key;
            _outputHashedString = hashedString;
            _outputHashValue = hashValue;
            _keyLength = 8;
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
        [Required]
        public string SelectedHashingTypes
        {
            get { return _selectedHashingType; }
            set { _selectedHashingType = value; }
        }
        [Required]
        public int KeyLength
        {
            get { return _keyLength; }
            set { _keyLength = value; }
        }
        [Required]
        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }
        public string OutputKey
        {
            get { return _outputKey; }
            set { _outputKey = value; }
        }
        public string OutputHashedString
        {
            get { return _outputHashedString; }
            set { _outputHashedString = value; }
        }
        public string OutputHashValue
        {
            get { return _outputHashValue; }
            set { _outputHashValue = value; }
        }
        #endregion
    }
}
