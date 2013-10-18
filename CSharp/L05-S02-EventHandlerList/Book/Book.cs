using System;
using System.ComponentModel;

namespace Belhard.Training
{
    public class Book
    {
        private int _currentPage;
        private bool _isOpened;
        private readonly EventHandlerList _eventHandlerList;

        public Book(string title, int pageCount)
        {
            _eventHandlerList = new EventHandlerList();
            Title = title;
            PageCount = pageCount;
        }

        private static readonly object BookOpenedEventKey = new object();
        private static readonly object BookClosedEventKey = new object();
        private static readonly object PageChangedEventKey = new object();

        public event EventHandler BookOpened
        {
            add { _eventHandlerList.AddHandler(BookOpenedEventKey, value); }
            remove { _eventHandlerList.RemoveHandler(BookOpenedEventKey, value); }
        }

        public event EventHandler BookClosed
        {
            add { _eventHandlerList.AddHandler(BookClosedEventKey, value); }
            remove { _eventHandlerList.RemoveHandler(BookClosedEventKey, value); }
        }

        public event EventHandler<PageChangedEventArgs> PageChanged
        {
            add { _eventHandlerList.AddHandler(PageChangedEventKey, value); }
            remove { _eventHandlerList.RemoveHandler(PageChangedEventKey, value); }
        }

        public bool IsOpened
        {
            get { return _isOpened; }
            private set
            {
                if (_isOpened == value) return;
                _isOpened = value;
                if (_isOpened) OnBookOpened();
                else OnBookClosed();
            }
        }

        public int CurrentPage
        {
            get
            {
                if (!_isOpened) throw new InvalidOperationException("Book is closed");
                return _currentPage;
            }
            set
            {
                //if (_currentPage == value) return; //?
                IsOpened = true;
                _currentPage = value;
                OnPageChanged(_currentPage);
            }
        }

        public string Title { get; private set; }
        public int PageCount { get; private set; }

        private void OnBookClosed()
        {
            var bookClosedDelegate = (EventHandler)_eventHandlerList[BookClosedEventKey];
            bookClosedDelegate(this, EventArgs.Empty);
        }

        private void OnBookOpened()
        {
            var bookOpenedDelegate = (EventHandler)_eventHandlerList[BookOpenedEventKey];
            bookOpenedDelegate(this, EventArgs.Empty);
        }

        private void OnPageChanged(int pageNumber)
        {
            var pageChangedDelegate = (EventHandler<PageChangedEventArgs>)_eventHandlerList[PageChangedEventKey];
            pageChangedDelegate(this, new PageChangedEventArgs(pageNumber));
        }
    }
}
