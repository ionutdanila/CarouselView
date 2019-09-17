using Java.Util;

namespace CarouselView
{
    public class SwipeTask : TimerTask
    {
        private readonly CarouselView _carouselView;
        private readonly CarouselViewPager _containerViewPager;

        public SwipeTask(CarouselView carouselView, CarouselViewPager containerViewPager)
        {
            _carouselView = carouselView;
            _containerViewPager = containerViewPager;
        }

        public override void Run()
        {
            _containerViewPager.Post(() =>
            {
                int nextPage = (_containerViewPager.CurrentItem + 1) % _carouselView.GetPageCount();
                _containerViewPager.SetCurrentItem(nextPage, 0 != nextPage || _carouselView.AnimateOnBoundary);
            });
        }
    }
}