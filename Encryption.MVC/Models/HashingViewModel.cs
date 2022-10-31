using Microsoft.AspNetCore.Mvc.Rendering;

namespace Encryption.MVC.Models
{
	public class HashingViewModel
    {
		#region fields
		private List<SelectListItem> _hashingTypes;
		private int _selectedHashingType;
		private string _input;
		private string _output;
		#endregion

		#region Constructor
		public HashingViewModel()
		{
			HashingTypes = new List<SelectListItem>();
			PopulateHashingTypes();
		}
		#endregion

		#region Methods
		private void PopulateHashingTypes()
		{
			HashingTypes.Add(new SelectListItem { Value = "1", Text = "SHA160"});
			HashingTypes.Add(new SelectListItem { Value = "2", Text = "SHA256"});
			HashingTypes.Add(new SelectListItem { Value = "3", Text = "SHA384"});
			HashingTypes.Add(new SelectListItem { Value = "4", Text = "SHA512"});
			HashingTypes.Add(new SelectListItem { Value = "5", Text = "MD5"});
	}
        #endregion

        #region Properties
        public List<SelectListItem> HashingTypes
		{
			get { return _hashingTypes; }
			set { _hashingTypes = value; }
		}
		public int SelectedHashingTypes
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
