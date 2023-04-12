using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book.Library;

namespace Books.View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static List<Book1> arrBooks = new List<Book1>();
        public int NumberOfHardCoverTextBook { get; set; }
        public int NumberOfPaperTextBook { get; set; }
        public bool AddBook(Book1 book)
        {
            if (arrBooks.Contains(book))
            {
                return false;
            }
            arrBooks.Add(book);
            return true;
        }
        public bool DeleteBook(Book1 book)
        {
            if (arrBooks.Contains(book))
            {
                arrBooks.Remove(book);
                return true;
            }
            return false;
        }
        public bool DeleteBook(int iSBN)
        {
            int foundIndex = arrBooks.FindIndex(x => x.ISBN == iSBN);
            if (foundIndex != -1)
            {
                arrBooks.RemoveAt(foundIndex);
                return true;

            }
            return false;
        }

        public string DisplayAllBooks()
        {
            string message = "";
            foreach (Book1 b in arrBooks)
            {
                message += b.ToString() + "\n";
            }
            return message;
        }
   
       
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbBookType.Items.Add("EBook");
            cmbBookType.Items.Add("TextBook");
            cmbTextBookType.Items.Add(EnumTextBookType.Hardcover);
            cmbTextBookType.Items.Add(EnumTextBookType.Paperback);
            lblTextBookType.Location = lblFileSize.Location;
            cmbTextBookType.Location = txtFileSize.Location;
            lblFileSize.Visible = false;
            txtFileSize.Visible = false;
            lblTextBookType.Visible = false;
            cmbTextBookType.Visible = false;
        }
        Book1 book;
        int iSBN;
   

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string bookTitle = txtTitle.Text;
                string publisher = txtPublisher.Text;
                double price = double.Parse(txtPrice.Text);
                int year = int.Parse(txtYear.Text);
                int numOfPages = int.Parse(txtNumberPages.Text);
                iSBN = int.Parse(txtISBN.Text);
                switch (cmbBookType.SelectedIndex)
                {
                    case 0:
                        double fileSize = double.Parse(txtFileSize.Text);
                        book = new EBook(bookTitle, price, publisher, year, iSBN, numOfPages, fileSize);
                        break;
                    case 1:
                        EnumTextBookType textBookType = (EnumTextBookType)cmbTextBookType.SelectedItem;
                        if (cmbTextBookType.SelectedIndex == 0)//HardCover
                        {
                           NumberOfHardCoverTextBook++;
                        }
                        else
                        {
                           NumberOfPaperTextBook++;
                        }
                        book = new TextBook(bookTitle, price, publisher, year, iSBN, numOfPages, textBookType);
                        break;
                    default:
                        book = null;
                        break;
                }
                bool result = AddBook(book);
                string message = result ? "Added" : "Not Added";
                try
                {
                    if (result == false)
                    {
                        throw new InvalidISBNExaption();
                    }
                }
                catch (Exception exept)
                {
                    MessageBox.Show(exept.Message);
                }
                MessageBox.Show(message);
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                iSBN = int.Parse(txtISBN.Text);
                bool result = DeleteBook(iSBN);
                MessageBox.Show(result ? "Removed" : "Not Removed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DisplayAllBooks() == "" ? "No books" : DisplayAllBooks());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close application?", " ", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cmbBookType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFileSize.Visible = true;
            txtFileSize.Visible = true;
            lblTextBookType.Visible = false;
            cmbTextBookType.Visible = false;
            if (cmbBookType.SelectedIndex==0)
            {
                lblFileSize.Visible = true;
                txtFileSize.Visible = true;
                lblTextBookType.Visible = false;
                cmbTextBookType.Visible = false;
              
            }
            else
            {
                lblFileSize.Visible = false;
                txtFileSize.Visible = false;
                lblTextBookType.Visible=true;
                cmbTextBookType.Visible = true;
                lblNumberOfPage.Visible = true;
                txtNumberPages.Visible = true;

            }
                    
         }

        private void cmbTextBookType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNumberPages_TextChanged(object sender, EventArgs e)
        {

        }

       
    }

}
