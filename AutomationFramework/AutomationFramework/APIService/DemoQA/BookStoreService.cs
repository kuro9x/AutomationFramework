using System.Text.Json.Nodes;
using ProjectCore.API;
using RestSharp;
using TestScript;

public class BookStoreService
{

    private readonly APIClient _client;
    public BookStoreService(APIClient apiClient)
    {
        _client = apiClient;
    }
    public Task<RestResponse<BookObject.Books>> GetAllBook()
    {
        return _client.CreateRequest(APIConstant.booksEndpoint)
                        .AddHeader("accept", "application/json")
                        .ExecuteGetAsync<BookObject.Books>();
    }

    public Task<RestResponse> AddBookToCollection(string userId, string bearerToken, List<BodyObject.CollectionOfIsbn> listISBN)
    {
        BodyObject.BodyAddBook body = new BodyObject.BodyAddBook(userId, listISBN);
        return _client.CreateRequest(APIConstant.booksEndpoint)
                        .AddAuthorizationHeader(bearerToken)
                        .AddHeader("accept", "application/json")
                        .AddHeader("Content-Type", "application/json")
                        .AddBody(body)
                        .ExecutePostAsync();
    }

    public Task<RestResponse> DeleteAllBook(string userId, string bearerToken)
    {
        return _client.CreateRequest(APIConstant.booksEndpoint)
                        .AddParameter("UserId", userId)
                        .AddAuthorizationHeader(bearerToken)
                        .AddHeader("accept", "application/json")
                        .ExecuteDeleteAsync();
    }

    public Task<RestResponse<BookObject.Book>> GetABookDetails(string bookIsbn)
    {
        return _client.CreateRequest(APIConstant.bookEndpoint)
                        .AddParameter("ISBN", bookIsbn)
                        .AddHeader("accept", "application/json")
                        .ExecuteGetAsync<BookObject.Book>();
    }

    public Task<RestResponse> DeleteBook(string isbn, string userId)
    {
        BodyObject.BodyDeleteBook body = new BodyObject.BodyDeleteBook(isbn, userId);
        return _client.CreateRequest(APIConstant.bookEndpoint)
                        .AddHeader("accept", "application/json")
                        .AddHeader("Content-Type", "application/json")
                        .AddBody(body)
                        .ExecuteDeleteAsync();
    }
    public Task<RestResponse<UserObject.UserInfo>> UpdateBookIsbn(string oldIsbn, string isbn, string userId)
    {
        BodyObject.BodyDeleteBook body = new BodyObject.BodyDeleteBook(isbn, userId);
        return _client.CreateRequest(APIConstant.bookEndpoint + $"/{oldIsbn}")
                        .AddHeader("accept", "application/json")
                        .AddHeader("Content-Type", "application/json")
                        .AddBody(body)
                        .ExecutePutAsync<UserObject.UserInfo>();
    }
}