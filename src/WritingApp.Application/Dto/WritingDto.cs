namespace WritingApp.Application.Dto
{
    public class WritingDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Type { get; set; } = "";
        public DateOnly PublishedDate { get; set; }
        public string Description { get; set; } = "";
        public string Article { get; set; } = "";
        public bool Completed { get; set; }
        public string UserId { get; set; } = "";
        public string Author { get; set; } = "";
    }

    public class WritingCreateDto
    {
        public required string Title { get; set; }
        public string Type { get; set; } = "";
        public required DateOnly PublishedDate { get; set; }
        public string Description { get; set; } = "";
        public string Article { get; set; } = "";
        public bool Completed { get; set; } = false;
    }

    public class WritingUpdateDto
    {
        public required string Title { get; set; }
        public string Type { get; set; } = "";
        public required DateOnly PublishedDate { get; set; }
        public string Description { get; set; } = "";
        public string Article { get; set; } = "";
        public bool Completed { get; set; } = false;
    }
}
