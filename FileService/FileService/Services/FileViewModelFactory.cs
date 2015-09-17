using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using PropertyChanged;
using System.Windows.Input;
using Xamarin.Forms;

namespace FileService
{

	public class FileViewModelFactory : IFileViewModelFactory
	{ 
		public FileViewModel Build ()
		{
			return new FileViewModel ();
		}
	}

}

