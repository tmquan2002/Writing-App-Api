namespace WritingApp.Application.Writings.Dtos
{
    public class WritingDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateOnly PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; }
        public string UserId { get; set; } = string.Empty;
    }

    public class WritingCreateDto
    {
        public required string Title { get; set; }
        public string Type { get; set; } = string.Empty;
        public required DateOnly PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
    }

    public class WritingUpdateDto
    {
        public required string Title { get; set; }
        public string Type { get; set; } = string.Empty;
        public required DateOnly PublishedDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Completed { get; set; } = false;
    }
}
