namespace NoteApp.Domain.Entities;

public class Note: BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Content { get; set; }
}