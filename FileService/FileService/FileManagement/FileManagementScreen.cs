using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace FileService
{
	public class FileManagementScreen : ContentPage
	{
		public FileManagementScreen ()
		{
			CreatePageContent ();	
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
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (16, 12),
				Opacity = 0.6,
				Children = {
					icon,
					remaining
				}
			};

			background.SetBinding<FileManagementViewModel>(StackLayout.BackgroundColorProperty, m => m.HeaderTileBackground);

			var listView = new ListView
			{ 
				BackgroundColor = Color.White,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				ItemTemplate = new DataTemplate(()=>new FileManagementViewCell()),
				HeightRequest = 190,
				HasUnevenRows = true
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
				Padding = new Thickness(12),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				Children = {
					button
				}
			};

			buttonContainer.SetBinding<FileManagementViewModel> (StackLayout.BackgroundColorProperty, m => m.BottomTileBackground);

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

