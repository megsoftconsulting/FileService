using System;
using Xamarin.Forms;
using System.Windows.Input;

namespace FileService
{
	public class FileManagementViewCell : ViewCell
	{
		public Command<FileViewModel> UploadCommand { get; set; }

		public FileManagementViewCell ()
		{
			var fileType = new Image
			{ 
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 48,
				HeightRequest = 48,
				Aspect = Aspect.AspectFit
			};

			fileType.SetBinding<FileViewModel>(Image.SourceProperty, m => m.FileTypeIcon);

			var fileName = new Label
			{ 
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.Start,
				TextColor = Color.Black,
				FontSize = 16
			};

			fileName.SetBinding<FileViewModel>(Label.TextProperty, m => m.FileName);

			var fileSize = new Label 
			{ 
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.Start,
				TextColor = Color.Gray,
				FontSize = 10
			};

			fileSize.SetBinding<FileViewModel>(Label.TextProperty, m => m.FileSize);

			var lastDateModified = new Label 
			{ 
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				TextColor = Color.Gray,
				FontSize = 10
			};

			lastDateModified.SetBinding<FileViewModel>(Label.TextProperty, m => m.LastDateModified);

			var uploadProgress = new ProgressBar
			{
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Fill
			};

			uploadProgress.SetBinding<FileViewModel>(ProgressBar.ProgressProperty, m => m.Progress);
				
			var uploadButton = new Image
			{ 
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				WidthRequest = 32,
				HeightRequest = 32,
				Aspect = Aspect.AspectFit
			};

			uploadButton.SetBinding<FileViewModel>(Image.SourceProperty, m => m.ProgressStatusImage);

			var gestureTap = new TapGestureRecognizer
			{ 
				Command = new Command((obj)=>{

					if(UploadCommand == null)
						throw new Exception("UploadCommand is null");

					UploadCommand.Execute(BindingContext);

				})
			};

			uploadButton.GestureRecognizers.Add (gestureTap);

			var lastPanelStack = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Spacing = 8,
				Children = {
					lastDateModified,
					uploadButton 
				}
			};

			var stackHead = new RelativeLayout
			{
				Children = { {
						fileName,
						Constraint.RelativeToParent (p => 0),
						Constraint.RelativeToParent (p => 0)
					}, {
						fileSize,
						Constraint.RelativeToView (fileName, (p, s) => s.X + s.Width + 8),
						Constraint.RelativeToView (fileName, (p, s) => s.Y + 4)
					}
				}
			};

			var stackProgressAndNameAndSize = new StackLayout {
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				Children = {
					stackHead,
					uploadProgress
				}
			};

			//TODO: Factory
			var divider = new BoxView
			{
				Color = Color.FromHex("59ABE3"),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.End,
				HeightRequest = 1,
				Opacity = 0.2
			};

			var layout = new StackLayout
			{ 
				Spacing = 16,
				Padding = new Thickness(16,16),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					fileType,
					stackProgressAndNameAndSize,
					lastPanelStack
				}
			};

			View = new StackLayout{
				Children = {
					layout,
					divider
				}
			};

		}
	}
}

