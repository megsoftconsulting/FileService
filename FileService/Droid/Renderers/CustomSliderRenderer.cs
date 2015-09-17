using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FileService;
using FileService.Droid;
using Android.Widget;
using Android.Views;
using Android.Graphics.Drawables;

[assembly: ExportRenderer (typeof (CustomSlider), typeof (CustomSliderRenderer))]
namespace FileService.Droid
{
	public class CustomSliderRenderer : SliderRenderer
	{
		Slider _model;

		SeekBar _seekbar;

		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Slider> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				
				_model = e.NewElement;
				
				var seekbarLayout = LayoutInflater.From (Context).Inflate (Resource.Layout.Seekbar, null);

				_seekbar = (SeekBar)seekbarLayout.FindViewById (Resource.Id.seekbar);

				_seekbar.Max = (int) _model.Maximum;

				_seekbar.Progress = (int) _model.Value;

				_seekbar.SetThumb (new ColorDrawable {
					Alpha = 0
				});

				SetNativeControl (_seekbar);

				e.NewElement.SizeChanged += OnSizeChanged;
			}
		}

		void OnSizeChanged (object sender, EventArgs e)
		{
			if (_seekbar == null)
				return;

			var sliderView = sender as CustomSlider;

			if (sliderView != null) {

				var width = sliderView.Width;

				var height = sliderView.Height;

				_seekbar.LayoutParameters.Height = (int) height;

				_seekbar.LayoutParameters.Width = (int) width;
			}
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing) {
				
				_model.SizeChanged -= OnSizeChanged;
			}
			base.Dispose (disposing);
		}

	}
}

