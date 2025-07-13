using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Model
{
    internal class Book : INotifyPropertyChanged
    {
        public string name;
        public string author;
        public string data;

        public Book(string n, string a, string d) 
        {
            name = n;
            author = a;
            data = d;
        }
        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }
        public string Author
        {
            get => author;
            set
            {
                if (author != value)
                {
                    author = value;
                }
            }
        }
        public string Data
        {
            get => data;
            set
            {
                if(data != value)
                {
                    data = value;
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
