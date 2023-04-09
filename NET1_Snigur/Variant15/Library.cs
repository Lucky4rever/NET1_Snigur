using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET.Variant15 {
    class Library {
        public Library(string name) {
            this.name = name;
        }
        public string name { get; set; }
        public ICollection<Book> books { get; set; }

        public void addBooksById(params int[] numbers) {
            TestData testData = new TestData();
            foreach (int id in numbers) {
                Book book = testData.books[id];
                book.inventoryNumber = randomInventoryNumber();
                books.Add(book);
            }
        }

        private static Random random = new Random();
        public static string randomInventoryNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(
                Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)])
                .ToArray()
                );
        }
        public override string ToString() {
            return "Publishing house '" + name + "'";
        }
    }
}
