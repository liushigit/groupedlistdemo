using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroupedList
{
    public class Author
    {
        private ObservableCollection<Book> _books =
            new ObservableCollection<Book>();
        public string Name {
            set; get;
        }
        public ObservableCollection<Book> Books
        {
            get
            {
                return _books;
            }
        }
    }


    public class Book
    {
        public string Author { set; get; }
        public string Title { set; get; }

    }

    public class BooksViewModel
    {
        public ObservableCollection<Author> Authors;

        public BooksViewModel() {
            AuthorGroup = from a in Books group a by a.Author;

            Authors = new ObservableCollection<Author>();
            foreach (var i in AuthorGroup) {
                var author = new Author() { Name = i.Key };
                Authors.Add(author);
                foreach (var book in i) {

                    author.Books.Add(book);
                }
            }
        }

        public ObservableCollection<Book> Books = new ObservableCollection<Book>()
        {
            new Book() {Author="曹雪芹", Title="红楼梦" },
            new Book() {Author="曹雪芹", Title="红楼梦2"},
            new Book() {Author="施耐庵", Title="水浒传"},
            new Book() {Author="施耐庵", Title="水浒传2"}
        };

        public IEnumerable<IGrouping<string, Book>> AuthorGroup;

    }
}
