using System;

namespace Belhard.Training
{
    class Program
    {
        static void Main()
        {
            var clrViaCSharp = new Book("CLR via C#, Fourth Edition", 894);
            clrViaCSharp.BookOpened += OnBookOpened;
            clrViaCSharp.BookClosed += OnBookClosed;
            clrViaCSharp.PageChanged += OnPageChanged;

            clrViaCSharp.CurrentPage = 5;
        }

        private static void OnBookOpened(object sender, EventArgs e)
        {

        }

        private static void OnBookClosed(object sender, EventArgs e)
        {

        }

        private static void OnPageChanged(object sender, PageChangedEventArgs e)
        {
            Book book = (Book)sender;
            Console.WriteLine("Вы читаете страницу №{0} в книге '{1}'", e.PageNumber, book.Title);
        }
    }
}
