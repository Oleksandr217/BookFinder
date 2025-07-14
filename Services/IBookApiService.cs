using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookFinder.Model;

namespace BookFinder.Services
{
    internal interface IBookApiService
    {   
        Task<List<Book>> SearchBooksAsync(string query);
    }
}
    