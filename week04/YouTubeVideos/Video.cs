public class Video
{
    // Attributes
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }

    // List of comments
    private List<Comment> _comments = new List<Comment>();

    // Methods
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}
