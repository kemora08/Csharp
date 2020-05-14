//add the following imports to the top for your file
namespace BooksInventory
{
    class book
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public book(string title, string author)
        {
            this.Title = Title;
            this.Author = Author;
        }
    }
}