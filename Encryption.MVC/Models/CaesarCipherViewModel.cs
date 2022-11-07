using Microsoft.AspNetCore.Mvc.Rendering;

namespace Encryption.MVC.Models
{
	public class CaesarCipherViewModel
	{
		#region fields
		private List<SelectListItem> _encryptOrDecrypt;
		private string _selectedEncryptDecrypt;
		private List<SelectListItem> _cipherIndexes;
		private string _selectedChiperIndex;
		private string _input;
		private List<PreviousCiphers> _previousCiphersList;
		#endregion

		#region Constructors
		public CaesarCipherViewModel()
		{
			EncryptOrDecrypt = new List<SelectListItem>();
			EncryptOrDecrypt.Add(new SelectListItem { Text = "Encrypt", Value = "false" });
			EncryptOrDecrypt.Add(new SelectListItem { Text = "Decrypt", Value = "true" });
			CipherIndexes = new List<SelectListItem>();
			for (int i = 1; i < 27; i++)
			{
				CipherIndexes.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
			};
			PreviousCiphersList = new List<PreviousCiphers>();
		}

		public CaesarCipherViewModel(List<PreviousCiphers> previousCiphers)
		{
			EncryptOrDecrypt = new List<SelectListItem>();
			EncryptOrDecrypt.Add(new SelectListItem { Text = "Encrypt", Value = "false" });
			EncryptOrDecrypt.Add(new SelectListItem { Text = "Decrypt", Value = "true" });
			CipherIndexes = new List<SelectListItem>();
			for (int i = 1; i < 27; i++)
			{
				CipherIndexes.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
			};
			PreviousCiphersList = previousCiphers;
		}
		#endregion

		#region Properties
		public List<SelectListItem> EncryptOrDecrypt
		{
			get { return _encryptOrDecrypt; }
			set { _encryptOrDecrypt = value; }
		}
		public string SelectedEncryptDecrypt
		{
			get { return _selectedEncryptDecrypt; }
            set { _selectedEncryptDecrypt = value; }
		}
		public List<SelectListItem> CipherIndexes
		{
			get { return _cipherIndexes; }
            set { _cipherIndexes = value; }
		}
		public string SelectedChiperIndex
		{
			get { return _selectedChiperIndex; }
            set { _selectedChiperIndex = value; }
		}
		public string Input
		{
			get { return _input; }
            set { _input = value; }
		}
		public List<PreviousCiphers> PreviousCiphersList 
		{ 
			get { return _previousCiphersList; }
            set { _previousCiphersList = value; } 
		}
		#endregion
	}

	public class PreviousCiphers
	{
		#region fields
		private string output;
		private string type;
		private string input;
		private string chiperIndex;
		#endregion

		#region Constructor
		public PreviousCiphers(string output, string input, string type, string chiperIndex)
		{
			Output = output;
			Type = type;
			Input = input;
			ChiperIndex = chiperIndex;
		}
		#endregion

		#region Properties
		public string Output { get => output; set => output = value; }
		public string Type { get => type; set => type = value; }
		public string Input { get => input; set => input = value; }
		public string ChiperIndex { get => chiperIndex; set => chiperIndex = value; }
		#endregion
	}
}
