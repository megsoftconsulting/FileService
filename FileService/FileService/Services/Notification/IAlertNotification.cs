using System;
using Xamarin.Forms;

namespace FileService
{
	public interface IAlertNotification
	{
		void ShowAlert(string title, string message);
	}
	public class AlertNotification : IAlertNotification
	{
		
		public void ShowAlert (string title, string message)
		{


		}
	}
}

