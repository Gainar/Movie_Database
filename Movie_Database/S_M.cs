using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Database
{
    class S_M
    {
        private string _Title;
        private int _Year;
        private string _Genre;
        private string _Type;
        private byte _Rating;
        private string _Creator;

        public string Title
        {
            get { return _Title; }
            set
            {
                if (string.IsNullOrEmpty(value))
                { Console.WriteLine("Enter a title"); }
                else
                { _Title = value; }
            }
        }
        public int Year
        {
            get { return _Year; }
            set
            {
                _Year = value;
            }
        }
        public string Genre
        {
            get { return _Genre; }
            set
            {
                if (string.IsNullOrEmpty(value))
                { Console.WriteLine("Enter a Genre"); }
                else
                { _Genre = value; }


            }
        }
        public string Type
        {
            get { return _Type; }
            set
            {
                if (string.IsNullOrEmpty(value))
                { Console.WriteLine("Enter a type"); }
                else
                { _Type = value; }


            }
        }
        public byte Rating
        {
            get { return _Rating; }
            set
            {
                _Rating = value;
            }
        }
        public string Creator
        {
            get { return _Creator; }
            set
            {
                if (string.IsNullOrEmpty(value))
                { Console.WriteLine("Enter the Creators"); }
                else
                { _Creator = value; }


            }
        }


    }
}
