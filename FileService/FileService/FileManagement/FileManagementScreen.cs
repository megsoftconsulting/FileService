using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace FileService
{
	public class FileManagementScreen : ContentPage
	{
		public FileManagementViewModel DataContext;

		public FileManagementScreen ()
		{
			SetContext ();

			CreatePageContent ();
		}

		void SetContext ()
		{
			DataContext = new FileManagementViewModel (new FileViewModelFactory(), new ServerClient());

			BindingContext = DataContext;
		}

		void CreatePageContent ()
		{
			this.SetBinding<FileManagementViewModel>(TitleProperty, m => m.WindowTitle);

			this.SetBinding<FileManagementViewModel>(BackgroundColorProperty, m => m.BackgroundColor);
 
			var icon = new Image {
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center,
				Aspect = Aspect.AspectFit,
				WidthRequest = 24,
				HeightRequest = 24
			};

			icon.SetBinding<FileManagementViewModel> (Image.SourceProperty, m => m.WarningIcon);

			var remaining = new Label
			{ 
				HorizontalOptions = LayoutOptions.Center,
				TextColor = Color.White
			};

			remaining.SetBinding<FileManagementViewModel> (Label.TextProperty, m => m.FilesRemainingToBeUploaded);

			var background = new StackLayout 
			{
				BackgroundColor = Color.FromHex("59ABE3"),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (16, 12),
				Opacity = 0.6,
				Children = {
					icon,
					remaining
				}
			};
			var listView = new ListView
			{ 
				BackgroundColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate(()=>{
					
					var viewcell = new FileManagementViewCell();

					viewcell.UploadCommand = DataContext.UploadToServerCommand;

					return viewcell;

				}),
				HeightRequest = 190,
				HasUnevenRows = true
			};

			listView.ItemSelected += (sender, e) => {
				
				if (e.SelectedItem == null) {
					return;
				}
			};

			listView.SetBinding<FileManagementViewModel>(ListView.ItemsSourceProperty, m => m.FilesNotSynchronized);
			listView.SetBinding<FileManagementViewModel> (ListView.SelectedItemProperty, m => m.FileSelected);

			var button = new Button 
			{
				BackgroundColor = Color.Transparent,
				TextColor = Color.Black,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			button.SetBinding<FileManagementViewModel> (Button.TextProperty, m => m.UploadAllOptionText);
			button.SetBinding<FileManagementViewModel> (Button.CommandProperty, m => m.UploadAllSelected);

			var buttonContainer = new StackLayout {
				Opacity = 0.8,
				BackgroundColor = Color.FromHex("ECF0F1"),
				Padding = new Thickness(12),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				Children = {
					button
				}
			};

			Content = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Spacing = 12,
				Children = {
					background,
					listView,
					buttonContainer
				}
			};
		}
	}
}

