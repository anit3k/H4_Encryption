﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Encryption.MVC.Models
{
	/// <summary>
	/// View Model for Hashing
	/// </summary>
	public class HashingViewModel
    {
		#region fields
		private List<SelectListItem> _hashingTypes;
		private string _selectedHashingType;
		private string _input;
		private string _outputHashedString;
		private string _outputHashValue;
		#endregion

		#region Constructor
		public HashingViewModel()
		{
			HashingTypes = new List<SelectListItem>();
			PopulateHashingTypes();
		}
        public HashingViewModel(string outputString, string outputValue)
        {
            HashingTypes = new List<SelectListItem>();
            PopulateHashingTypes();
			_outputHashedString = outputString;
			_outputHashValue = outputValue;
        }
        #endregion

        #region Methods
        private void PopulateHashingTypes()
		{
			HashingTypes.Add(new SelectListItem { Value = "SHA1", Text = "SHA1"});
			HashingTypes.Add(new SelectListItem { Value = "SHA256", Text = "SHA256"});
			HashingTypes.Add(new SelectListItem { Value = "SHA384", Text = "SHA384"});
			HashingTypes.Add(new SelectListItem { Value = "SHA512", Text = "SHA512"});
			HashingTypes.Add(new SelectListItem { Value = "MD5", Text = "MD5"});
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
		public string Input
		{
			get { return _input; }
			set { _input = value; }
		}
		public string OutputHashString
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
