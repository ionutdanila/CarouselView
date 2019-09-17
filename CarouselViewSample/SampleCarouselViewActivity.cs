using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using CarouselView;
using FFImageLoading;
using FFImageLoading.Views;
using System;

namespace CarouselViewSample
{
    [Activity(Label = "CarouselView Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class SampleCarouselViewActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_sample_carousel_view);

            CarouselView.CarouselView _customCarouselView = (CarouselView.CarouselView)FindViewById(Resource.Id.customCarouselView);
            _customCarouselView.SetViewListener(new SampleViewListener(_customCarouselView));
            _customCarouselView.SetPageCount(2);
            _customCarouselView.SetSlideInterval(4000);
            _customCarouselView.SetIndicatorGravity(GravityFlags.CenterHorizontal | GravityFlags.Bottom);
        }
    }

    public class SampleViewListener : Java.Lang.Object, IViewListener
    {
        private readonly CarouselView.CarouselView _customCarouselView;

        public SampleViewListener(CarouselView.CarouselView customCarouselView)
        {
            _customCarouselView = customCarouselView;
        }

        public View SetViewForPosition(int position)
        {
            View customView = LayoutInflater.FromContext(_customCarouselView.Context).Inflate(Resource.Layout.view_custom, null);

            TextView labelTextView = (TextView)customView.FindViewById(Resource.Id.labelTextView);

            labelTextView.Text = "$1.77";


            return customView;
        }
    }
}

