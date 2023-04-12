using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Library
{
    public class EBook:Book1
    {
        public double FileSize { get; set; }
        public EBook(string bookTitle, double price, string publisher, int year, int iSBN, int numberOfPages):base(bookTitle, price, publisher, year, iSBN, numberOfPages)
        {

        }
        public EBook(string bookTitle, double price, string publisher, int year, int iSBN, int numberOfPages, double fileSize) : base(bookTitle, price, publisher, year, iSBN, numberOfPages)
        {
            FileSize = fileSize;
        }
        public override string ToString()
        {
            return base.ToString()+"\n File Size "+FileSize+ " megabytes";

        }
    }
}
