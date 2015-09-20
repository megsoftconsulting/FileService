using System;

using Xamarin.Forms;

namespace FileService
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new NavigationPage(new PictureScreen ());

		}

		protected override void OnStart ()
		{
		}

		protected override void OnSleep ()
		{
		}

		protected override void OnResume ()
		{
		}
	}
}

