using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Library
{
    public abstract class Book1
    {
        public string BookTitle { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }
        public int YearPublisher { get; set; }
        public int ISBN { get; set; }
        public int NumberOfPages { get; set; }
        public Book1()
        {

        }
        public Book1(string bookTitle, double price, string publisher, int year, int iSBN, int numberOfPages)
        {
            BookTitle = bookTitle;
            Price = price;
            Publisher = publisher;
            YearPublisher = year;
            ISBN = iSBN;
            NumberOfPages = numberOfPages;
        }
        public override string ToString()
        {
            return "Book title: " +BookTitle+"\n Price $ "+Price+"\n Publisher: "+Publisher+"\n Year "+YearPublisher+"\n ISBN "+ISBN+"\n Number of pages "+NumberOfPages;
        }
        public override bool Equals(object obj)
        {
            Book1 book = (Book1)obj;
            if(book.ISBN==this.ISBN)
            { return true; }
            else
            {
                return false;
            }
        }
    }
}
