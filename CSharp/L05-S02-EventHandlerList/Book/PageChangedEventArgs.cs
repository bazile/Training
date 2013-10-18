using System;

namespace Belhard.Training
{
    public class PageChangedEventArgs : EventArgs
    {
        private readonly int _pageNumber;

        public int PageNumber { get { return _pageNumber; } }

        public PageChangedEventArgs(int pageNumber)
        {
            _pageNumber = pageNumber;
        }
    }
}
