using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant15
{
    class LibraryBook
    {
        public LibraryBook(int libraryId, int bookId)
        {
            this.libraryId = libraryId;
            this.bookId = bookId;
        }
        public int libraryId { get; set; }
        public int bookId { get; set; }
    }
}
