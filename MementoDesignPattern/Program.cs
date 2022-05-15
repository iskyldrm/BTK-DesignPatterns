using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDesignPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book { IsBn="12345", Title="ali", Author="ben"};
            book.ShowBook();
            CareTaker careTaker = new CareTaker();

            careTaker.Memento = book.CreateUndo();

            book.Author = "cop";

            book.ShowBook();

            book.RestoreFromUndo(careTaker.Memento);
            book.ShowBook();


            Console.ReadLine();

        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _IsBn;

        DateTime _date; 
        public string Title 
        {
            get { return _title; }
            set 
            {
                _title = value;
                SetLastEdited();
            } 
        }
        public string Author
        {
            get { return _author; }
            set 
            { 
                _author = value;
                SetLastEdited();
            }
        }
        public string IsBn
        {
            get { return _IsBn; }
            set 
            { 
                _IsBn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _date = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento (_title,_author,_date,_IsBn );
        }
        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _date = memento.Date;
            _IsBn = memento.IsBn;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0}, {1}, {2}, edited = {3}",IsBn,Title,Author,_date);
        }
    }

    public class Memento
    {
        public string IsBn { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }  
        public string Author { get; set; }
        public Memento(string isBn, string title, DateTime date, string author)
        {
            IsBn = isBn;
            Title = title;
            Date = date;
            Author = author;
        }
    }
    public class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
