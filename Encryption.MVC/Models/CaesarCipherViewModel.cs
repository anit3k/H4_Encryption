using Microsoft.AspNetCore.Mvc.Rendering;

namespace Encryption.MVC.Models
{
	public class CaesarCipherViewModel
	{
		private List<SelectListItem> _encryptOrDecrypt;
		private string _selectedEncryptDecrypt;
		private List<SelectListItem> _cipherIndexes;
		private string _selectedChiperIndex;
		private bool _isDecrypt;
		private int _cipherIndex;
		private string _input;
		private string _previousInput;
		private string _output;
		private List<PreviousCiphers> _previousCiphersList;

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
	}

	public class PreviousCiphers
	{
		public PreviousCiphers(string output, string input, string type, string chiperIndex)
		{
			Output = output;
			Type = type;
			Input = input;
			ChiperIndex = chiperIndex;
		}
	
		public string Output { get; set; }
		public string Type { get; set; }
		public string Input { get; set; }
		public string ChiperIndex { get; set; }
	}
}
