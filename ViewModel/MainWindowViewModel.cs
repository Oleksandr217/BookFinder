using BookFinder.Model;
using BookFinder.Services;
using BookFinder.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BookFinder.ViewModel
{   
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly IBookApiService _apiService;

        public MainViewModel()
        {
            _apiService = new GoogleBooksApiService();
            SearchCommand = new RelayCommand(async _ => await SearchBooks());
            Books = new ObservableCollection<Book>();
        }

        private string _searchText; 
        public string SearchText
        {
            get => _searchText;
            set { _searchText = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Book> Books { get; set; }
        public ICommand SearchCommand { get; }

        private async Task SearchBooks()
        {
            Books.Clear();

            if (string.IsNullOrWhiteSpace(SearchText))
            {

                MessageBox.Show("Введіть назву книги для пошуку.", "Порожній запит", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = await _apiService.SearchBooksAsync(SearchText);
            foreach (var book in result)
                Books.Add(book);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
