using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant15
{
    class TestData {
        public TestData() {
            foreach(var row in publishingHousesBooks)
                connectHouses(row.Key, row.Value);

            foreach (var row in authorsBooks)
                connectAuthors(row.Key, row.Value);

            foreach (var row in LibrariesBooks)
                connectLibraries(row);
        }

        public List<PublishingHouse> publishingHouses = new List<PublishingHouse>() {
            new PublishingHouse("Komubuk"),
            new PublishingHouse("Mahaon"),
            new PublishingHouse("Folio"),
            new PublishingHouse("ASSA")
        };

        public List<Author> authors = new List<Author>() {
            new Author("Albert Camus"),
            new Author("Marcel Proust"),
            new Author("Franz Kafka"),
            new Author("Antoine de Saint-Exupéry"),
            new Author("Lyuko Dashvar")
        };

        public List<Book> books = new List<Book>() {
            new Book("Outsider", 237.00, new DateTime(1942, 6, 1, 0, 0, 0)),
            new Book("In search of lost time", 455.00, new DateTime(1913, 3, 3, 0, 0, 0)),
            new Book("Process", 426.35, new DateTime(1925, 2, 12, 0, 0, 0)),
            new Book("The little prince", 698.00, new DateTime(1943, 4, 6, 0, 0, 0)),
            new Book("Night flight", 120.00, new DateTime(1931, 2, 26, 0, 0, 0)),
            new Book("The myth of Sisyphus", 347.00, new DateTime(1942, 8, 19, 0, 0, 0)),
            new Book("The little prince", 180.00, new DateTime(1943, 4, 6, 0, 0, 0)),
            new Book("On Swann's side", 124.68, new DateTime(1913, 11, 14, 0, 0, 0)),
            new Book("Found time. Volume 7", 200.00, new DateTime(1927, 2, 2, 0, 0, 0))
        };

        public List<Library> libraries = new List<Library>() {
            new Library("My library"),
            new Library("My another library"),
            new Library("Yeah, I have three library")
        };

        private List<KeyValuePair<int, int>> authorsBooks = new List<KeyValuePair<int, int>>() {
            new KeyValuePair<int, int>(0, 0),
            new KeyValuePair<int, int>(1, 1),
            new KeyValuePair<int, int>(2, 2),
            new KeyValuePair<int, int>(3, 3),
            new KeyValuePair<int, int>(3, 4),
            new KeyValuePair<int, int>(0, 5),
            new KeyValuePair<int, int>(3, 6),
            new KeyValuePair<int, int>(1, 7),
            new KeyValuePair<int, int>(1, 8)
        };

        private List<KeyValuePair<int, int>> publishingHousesBooks = new List<KeyValuePair<int, int>>() {
            new KeyValuePair<int, int>(1, 0),
            new KeyValuePair<int, int>(3, 1),
            new KeyValuePair<int, int>(3, 2),
            new KeyValuePair<int, int>(0, 3),
            new KeyValuePair<int, int>(2, 4),
            new KeyValuePair<int, int>(2, 5),
            new KeyValuePair<int, int>(2, 6),
            new KeyValuePair<int, int>(1, 7),
            new KeyValuePair<int, int>(2, 8)
        };

        private List<LibraryBook> LibrariesBooks = new List<LibraryBook>() {
            new LibraryBook(0, 2),
            new LibraryBook(0, 4),
            new LibraryBook(0, 5),
            new LibraryBook(0, 6),
            new LibraryBook(0, 8),
            new LibraryBook(1, 2),
            new LibraryBook(1, 3),
            new LibraryBook(1, 8),
            new LibraryBook(1, 7)
        };

        private void connectAuthors(int authorId, int bookId) {
            authors[authorId].books.Add(books[bookId]);
            books[bookId].authorName = authors[authorId].name;
        }
        private void connectHouses(int publishingHouseId, int bookId) {
            publishingHouses[publishingHouseId].books.Add(books[bookId]);
            books[bookId].publishingHouse = publishingHouses[publishingHouseId].name;
        }
        private void connectLibraries(LibraryBook libraryBook) {
            if (books[libraryBook.bookId].Libraries == null)
                books[libraryBook.bookId].Libraries = new List<Library>();
            if (libraries[libraryBook.libraryId].books == null)
                libraries[libraryBook.libraryId].books = new List<Book>();

            books[libraryBook.bookId].Libraries.Add(libraries[libraryBook.libraryId]);
            libraries[libraryBook.libraryId].addBooksById(libraryBook.bookId);
        }
    }
}
