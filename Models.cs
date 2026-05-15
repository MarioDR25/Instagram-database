namespace InstagramDatabase;


public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}




public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public List<Post> Posts { get; set; } = [];
    public List<Comment> Comments { get; set; } = [];
    public List<Follower> Following { get; set; } = [];
    public List<Follower> Followers { get; set; } = [];
}


public class Post : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public int UserId { get; set; }
    public required User User { get; set; }

    public List<Comment> Comments { get; set; } = [];
    public List<Media> MediaFiles { get; set; } = [];



}


public class Comment : BaseEntity
{
    public string Description { get; set; } = String.Empty;
    public int AuthorId { get; set; }
    public required User Author { get; set; }
    public int PostId { get; set; }
    public required Post Post { get; set; }

}


public class Media : BaseEntity
{
    public string Url { get; set; } = string.Empty;
    public int PostId { get; set; }
    public required Post Post { get; set; }
}


public class Follower 
{
    public int UserFromId { get; set; }
    public required User UserFrom { get; set; }

    public int UserToId { get; set; }
    public required User UserTo { get; set; }
}


