using System;
using Xamarin.Forms;

namespace FileService
{
	public class PictureScreen : ContentPage
	{
		public PictureViewModel DataContext;

		public PictureScreen ()
		{
			SetContext ();

			CreatePageContent ();
		}

		void SetContext ()
		{
			DataContext = new PictureViewModel (new CameraClient (),
				new DatabaseClient<PhotoRecordTable> (new Logger ()),
				new Logger ());

			BindingContext = DataContext;
		}

		void CreatePageContent ()
		{
			BackgroundColor = Color.White;

			var takenPicture = new Image
			{ 
				Aspect = Aspect.AspectFit,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Blue
			};
			takenPicture.SetBinding<PictureViewModel> (Image.SourceProperty, m => m.PictureTaken);

			var pictureRawPath = new Label
			{ 
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.Black,
				BackgroundColor = Color.Red
			};

			pictureRawPath.SetBinding<PictureViewModel> (Label.TextProperty, m => m.PicturePath);

			var takePictureButton = new Button
			{ 
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				Text = "Take picture"
			};

			takePictureButton.SetBinding<PictureViewModel> (Button.CommandProperty, m => m.TakePictureSelected);

			var savePictureButton = new Button
			{ 
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.End,
				Text = "Save picture"
			};

			savePictureButton.SetBinding<PictureViewModel> (Button.CommandProperty, m => m.SavePicture);

			Content = new StackLayout
			{ 
				Padding = new Thickness(16,16),
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{
					takenPicture,

					pictureRawPath,

					new StackLayout
					{
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Children = 
						{
							takePictureButton,
							savePictureButton
						}
					}
				}
			};
		}
	}
}