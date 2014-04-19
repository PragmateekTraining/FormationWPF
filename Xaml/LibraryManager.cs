using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xaml;

namespace Xaml
{
    public class Library
    {
        public IList<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }
    }

    internal class LibraryManager
    {
        private const string LibraryPath = "Library.xaml";

        private readonly IDictionary<string, Action> commands;

        private bool exitRequested = false;

        public LibraryManager()
        {
            commands = new Dictionary<string, Action>
            {
                { "add", Add },
                { "cat", Cat },
                { "exit", Exit },
                { "list", List },
            };
        }

        private void Add()
        {
            Library library = null;

            if (File.Exists(LibraryPath))
            {
                library = XamlServices.Load(LibraryPath) as Library;
            }
            else
            {
                library = new Library();
            }

            Console.Write("\tTitle? ");

            string title = Console.ReadLine();

            Console.Write("\tISBN? ");

            string ISBN = Console.ReadLine();

            Book newBook = new Book
            {
                Title = title,
                ISBN = ISBN
            };

            library.Books.Add(newBook);

            XamlServices.Save(LibraryPath, library);
        }

        private void Cat()
        {
            Console.WriteLine(File.ReadAllText(LibraryPath));
        }

        private void Exit()
        {
            Console.WriteLine("Bye!");
            exitRequested = true;
        }

        private void List()
        {
            Library library = null;

            if (File.Exists(LibraryPath))
            {
                library = XamlServices.Load(LibraryPath) as Library;
            }

            if (library == null)
            {
                Console.WriteLine("No library found!");
                return;
            }

            for (int i = 0; i < library.Books.Count; ++i)
            {
                Book book = library.Books[i];

                Console.WriteLine("{0}) {1} [{2}]", i, book.Title, book.ISBN);
            }
        }

        public void Run()
        {
            exitRequested = false;
            while (!exitRequested)
            {
                Console.Write("> ");

                string command = Console.ReadLine()
                                        .Trim()
                                        .ToLower();

                if (commands.ContainsKey(command))
                {
                    commands[command]();
                }
                else if (command != "")
                {
                    Console.WriteLine("Unkown command '{0}'!", command);
                }
            }
        }
    }
}
