using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant15 {
    class Functional
    {
        private static TestData testData = new TestData();
        public static void bookNames()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Print all book names.");
            Console.ResetColor();

            var answer = from book in testData.books
                         select book.name;
            foreach (var book in answer)
                Console.WriteLine(book);
            Console.WriteLine();
        }
        public static void authorNames()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Print all author names as objects.");
            Console.ResetColor();

            var answer = from author in testData.authors
                         select new { author.name };
            foreach (var author in answer)
                Console.WriteLine(author);
            Console.WriteLine();
        }
        public static void authorNamesWithTheirBook()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3. Print all author names with their book.");
            Console.ResetColor();

            var answer = from author in testData.authors
                         join book in testData.books on author.name equals book.authorName
                         select new { book.name, book };
            foreach (var author in answer)
                Console.WriteLine(author);
            Console.WriteLine();
        }
        public static void booksWrittenByKafka()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4. Print all books written by Kafka.");
            Console.ResetColor();

            var answer = from author in testData.authors
                         join book in testData.books on author.name equals book.authorName
                         where author.name == "Franz Kafka"
                         select book.name;
            foreach (var name in answer)
                Console.WriteLine(name);
            Console.WriteLine();
        }

        public static void booksInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("5. Print all books info.");
            Console.ResetColor();

            var answer = from book in testData.books
                         select book;
            foreach (var book in answer)
                Console.WriteLine(book);
            Console.WriteLine();
        }

        public static void booksThatPublishByFolio()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("6. Print all books that was published by Folio.");
            Console.ResetColor();

            var answer = from book in testData.books
                         join publish in testData.publishingHouses on book.publishingHouse equals publish.name
                         where publish.name == "Folio"
                         orderby book.name
                         select new { publish, book.name };
            foreach (var publish in answer)
                Console.WriteLine(publish);
            Console.WriteLine();
        }

        public static void authorsWithTheirPublishHouses()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("7. Print all authors with their publish houses.");
            Console.ResetColor();

            var answer = from publish in testData.publishingHouses
                         join book in testData.books on publish.name equals book.publishingHouse
                         join author in testData.authors on book.authorName equals author.name
                         select new { publish, author.name };
            foreach (var publish in answer)
                Console.WriteLine(publish);
            Console.WriteLine();
        }

        public static void inventoryNumbersInLibrary(Library library)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("8. Print all inventory numbers of books in library '{0}'.", library.name);
            Console.ResetColor();

            var answer = from book in library.books
                         orderby book.inventoryNumber
                         select (book.inventoryNumber, book.name, book.authorName);
            foreach (var number in answer)
                Console.WriteLine(number);
            Console.WriteLine();
        }

        public static void booksInLibraryAndPublished(params Library[] libraries)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("9. Print all the books that have been published and that are in in libraries.");
            Console.ResetColor();

            var answer = (from houses in testData.publishingHouses
                         select houses.books).Union(
                         from library in libraries
                         select library.books);
            foreach (var books in answer)
                foreach (var book in books)
                    Console.WriteLine(book.name);
            Console.WriteLine();
        }

        public static void sumBooksbyAuthor(string authorName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("10. Print the sum of all books by the author {0}.", authorName);
            Console.ResetColor();

            var answer = (from author in testData.authors
                          where author.name == authorName
                          select author.books).Count();
            Console.WriteLine(answer);
            Console.WriteLine();
        }

        public static void authorsWithoutBooks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("11. Print all authors whose books are not listed.");
            Console.ResetColor();

            var answer = testData.authors.Where(author => author.books.Count == 0).Select(author => author.name);
            foreach (var name in answer)
                Console.WriteLine(name);
            Console.WriteLine();
        }

        public static void mostWrittenBooks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("12. Print name of the person who has the most written books.");
            Console.ResetColor();

            var maxCount = testData.authors.Max(author => author.books.Count);
            var answer = testData.authors.Where(author => author.books.Count == maxCount);
            foreach (var author in answer)
                    Console.WriteLine(author.name + " = " + author.books.Count);
            Console.WriteLine();
        }

        public static void fewestPublishedBooks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("13. Print publishing house person who has the fewest published books.");
            Console.ResetColor();

            var minCount = testData.publishingHouses.Min(house => house.books.Count);
            var answer = testData.publishingHouses.Where(house => house.books.Count == minCount);
            foreach (var house in answer)
                Console.WriteLine(house.name + " = " + house.books.Count);
            Console.WriteLine();
        }

        public static void authorsAndPublishersName()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("14. Display all names of authors and publishers.");
            Console.ResetColor();

            var answer = testData.authors.Select(author => author.name)
                         .Concat(testData.publishingHouses.Select(house => house.name));
            foreach (var names in answer)
                Console.WriteLine(names);
            Console.WriteLine();
        }

        public static void publishingHousesWithTheirBooks()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("15. Display all publishing houses and the books they have published.");
            Console.ResetColor();

            var answer = testData.publishingHouses.ToLookup(house => house.name, house => house.books);
            foreach (var house in answer) {
                Console.WriteLine("{0}:", house.Key);
                foreach (var books in house)
                    foreach (var book in books)
                        Console.WriteLine("- {0};", book.name);
            }
            Console.WriteLine();
        }

        public static void authorsInLibrary(params Library[] libraries)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("16. Display all names of authors whose books are in the library. (bad way)");
            Console.ResetColor();

            var answer = testData.authors.Join(testData.books, author => author.name, book => book.authorName,
                         (author, book) => new { Author = author.name, Book = book.name });
            //var x = libraries.Join(testData.books, library => library.)
            foreach (var names in answer)
                Console.WriteLine(names);
            Console.WriteLine();
        }
    }
}
