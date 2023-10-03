public class BodyObject
{


    public class BodyToken
    {
        public string? username { get; set; }
        public string? password { get; set; }

        public BodyToken(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        
    }

    public class CollectionOfIsbn
    {
        public string? Isbn { get; set; }
        public CollectionOfIsbn(string Isbn)
        {
            this.Isbn = Isbn;
        }
    }

    public class BodyAddBook
    {
        public string? UserId { get; set; }

        public List<CollectionOfIsbn>? CollectionOfIsbns { get; set; }

        public BodyAddBook(string userId, List<CollectionOfIsbn> listIsbn)
        {
            UserId = userId;
            CollectionOfIsbns = listIsbn;
        }

    }

    public class BodyDeleteBook
    {
        public string? Isbn { get; set; }

        public string? UserId { get; set; }

        public BodyDeleteBook(string isbn, string userId)
        {
            Isbn = isbn;
            UserId = userId;
        }
    }


}