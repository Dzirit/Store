using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests
{
    class StubBookRepository : IBookRepository
    {
        public Book[] ResultOfGetAllByIsbn { get; set; }
        public Book[] ResultOfGetAllByTitleOrAuthorn { get; set; }

        public Book[] GetAllByIsbn(string isbn)
        {
            return ResultOfGetAllByIsbn;
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            return ResultOfGetAllByTitleOrAuthorn;
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
