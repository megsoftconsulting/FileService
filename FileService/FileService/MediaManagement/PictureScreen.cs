using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace FileService
{
	public class PictureScreen : ContentPage
	{
		public PictureViewModel DataContext;

		public PictureScreen ()
		{
			SetContext ();

			CreatePageContent ();

			//TODO: Implement Notification Service
			DataContext.PropertyChanged += OnPropertyChanged;
		}

		void OnPropertyChanged (object sender, PropertyChangedEventArgs e)
		{
			//TODO: Implement Notification Service
			switch (e.PropertyName) {
			case "Saved":
				{
					var pictureIsNotNull = DataContext.Picture != null;

					if (pictureIsNotNull) {
					
						DisplayAlert ("Picture", "The picture was saved correctly", "OK");
					}
				}
				break;
			}
		}

		void SetContext ()
		{
			DataContext = new PictureViewModel (new CameraClient (),
				new DatabaseClient<PhotoRecordTable> (new Logger ()),
				new Logger (), new MediaManagementService());

			BindingContext = DataContext;
		}

		void CreatePageContent ()
		{
			BackgroundColor = Color.White;

			this.SetBinding<PictureViewModel>(TitleProperty, m => m.WindowTitle);

			var remaining = new Label
			{ 
				HorizontalOptions = LayoutOptions.Center,
				TextColor = Color.White,
				Text = "Let's take a picture!"
			};

			remaining.SetBinding<PictureViewModel>(TitleProperty, m => m.HeaderLabel);

			var background = new StackLayout 
			{
				BackgroundColor = Color.FromHex("59ABE3"),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness (16, 12),
				Opacity = 0.6,
				Children = {
					remaining
				}
			};

			var takenPicture = new Image
			{ 
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromHex("ECF0F1"),
				HeightRequest = 300
			};
			takenPicture.SetBinding<PictureViewModel> (Image.SourceProperty, m => m.PictureTaken);

			var pictureRawPath = new Label
			{ 
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				TextColor = Color.Gray,
				FontSize = 14
			};

			pictureRawPath.SetBinding<PictureViewModel> (Label.TextProperty, m => m.PicturePath);

			var takePictureButton = new Button
			{ 
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.End,
				Text = "Take picture",
				TextColor = Color.Black
			};

			takePictureButton.SetBinding<PictureViewModel> (Button.CommandProperty, m => m.TakePictureSelected);

			var takePictureLayout = new StackLayout
			{
				BackgroundColor = Color.FromHex("BDC3C7"),
				Opacity = 0.8,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					takePictureButton
				}
			};

			var savePictureButton = new Button
			{ 
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Text = "Save picture",
				TextColor = Color.Black
			};

			savePictureButton.SetBinding<PictureViewModel> (Button.CommandProperty, m => m.SavePicture);

			var savePictureLayout = new StackLayout
			{
				BackgroundColor = Color.FromHex("BDC3C7"),
				Opacity = 0.8,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = {
					savePictureButton
				}
			};

			Content = new StackLayout
			{
				Spacing = 0,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{
					background,
					takenPicture,
					new StackLayout{
						Padding = new Thickness(16,16),
						Children = {
							pictureRawPath
						}
					},
					new StackLayout
					{
						Spacing = 0,
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = 
						{
							takePictureLayout,
							savePictureLayout
						}
					}
				}
			};
		}
	}
}