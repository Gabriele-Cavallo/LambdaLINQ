var myBook = new Book("Jane Eyre", "Charlotte Brontë", 1847);

List<Book> books = new() {
    new Book("To Kill a Mockingbird", "Harper Lee", 1960),
    new Book("1984", "George Orwell", 1949),
    new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925),
    new Book("Pride and Prejudice", "Jane Austen", 1813),
    new Book("Moby-Dick", "Herman Melville", 1851),
    new Book("The Catcher in the Rye", "J.D. Salinger", 1951),
    new Book("Brave New World", "Aldous Huxley", 1932),
    new Book("The Lord of the Rings", "J.R.R. Tolkien", 1954),
    new Book("Animal Farm", "George Orwell", 1945),
};
books.Add(myBook);
void showBooks(string title)
{
    Console.WriteLine($"Title is {title}");
}
List<Book> oldBooks = new();
// foreach (var book in books)
// {
//     if(book.PublicationYear < 1900){
//         oldBooks.Add(book);
//     }
// }


// LAMBDA
// oldBooks = books.Where(book => book.PublicationYear < 1900).OrderBy(book => book.Title).ToList();
// Console.WriteLine(books.Count);
// Console.WriteLine(oldBooks.Count);
// foreach (var book in oldBooks)
// {
//     Console.WriteLine(book.Title);
// }



var orwellBooks = books
.Where(book => book.Author == "George Orwell")
.Select(book => book.Title)
.ToList();
// LINQ
var orwellBooks2 = from book in books
                   where book.Author == "George Orwell"
                   orderby book.Author ascending
                   select book.Title;
foreach (var book in orwellBooks2)
{
    Console.WriteLine(book);
}

// orwellBooks.ForEach(book => Console.WriteLine(book));
orwellBooks.ForEach(Console.WriteLine);
orwellBooks.ForEach(showBooks);

var bookAfter1900 = books.Count(book => book.PublicationYear >= 1900);
Console.WriteLine($"There are {bookAfter1900} after 1900");
var bookAfter1900_2 = (from book in books
                       where book.PublicationYear >= 1900
                       select book)
                    .Count();

var mostRecentBook = books.
OrderByDescending(book => book.PublicationYear >= 1900)
.FirstOrDefault();
var mostRecentBook_2 = (from book in books
                        where book.PublicationYear >= 1900
                        orderby book.PublicationYear descending
                        select book).FirstOrDefault();

Console.WriteLine($"The most recent book is {mostRecentBook?.Title}");

Console.WriteLine(books.Contains(myBook));
