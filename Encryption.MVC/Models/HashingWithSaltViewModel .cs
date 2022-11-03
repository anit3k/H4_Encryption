using Microsoft.AspNetCore.Mvc.Rendering;

namespace Encryption.MVC.Models
{
	public class HashingWithSaltViewModel
    {
		#region fields
		private List<SelectListItem> _hashingTypes;
		private string _selectedHashingType;
		private string _input;
		private string _output;
		#endregion

		#region Constructor
		public HashingWithSaltViewModel()
		{
			HashingTypes = new List<SelectListItem>();
			PopulateHashingTypes();
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
		public string SelectedHashingTypes
		{
			get { return _selectedHashingType; }
			set { _selectedHashingType = value; }
		}
		public string Input
		{
			get { return _input; }
			set { _input = value; }
		}
		public string Output
		{
			get { return _output; }
			set { _output = value; }
		}
		#endregion
	}
}
