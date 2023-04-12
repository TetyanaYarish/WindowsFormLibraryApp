using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Library
{
    public enum EnumTextBookType
    {
        Hardcover,
        Paperback
    }
    public class TextBook:Book1, IDElivery
    {
        public EnumTextBookType BookType { get; set; }
        public TextBook(string bookTitle, double price, string publisher, int year, int iSBN, int numberOfPages) : base(bookTitle, price, publisher, year, iSBN, numberOfPages)
        {

        }
        public TextBook(string bookTitle, double price, string publisher, int year, int iSBN, int numberOfPages, EnumTextBookType bookType) : base(bookTitle, price, publisher, year, iSBN, numberOfPages)
        {
            BookType = bookType;
        }
        public override string ToString()
        {
            return base.ToString()+"\n BookType" + BookType;
        }
        public double CalculateDeliveryFee()
        {
            int numberOfBooks = 0;
            if (BookType == EnumTextBookType.Hardcover)
            {
                return 5;
            }
            else
            {
                return 2;
            }

            //int Fee = 0;
            //EnumTextBookType type = EnumTextBookType.Hardcover;
            //switch (type)
            //{
            //    case EnumTextBookType.Hardcover:
            //        Fee = 5;
            //        break;
            //    case EnumTextBookType.Paperback:
            //       Fee = 2;
            //        break;

            //}
            //return Fee;
        }

    }
}
