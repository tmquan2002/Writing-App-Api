﻿namespace WritingApp.Domain.Entities;

public class Writing
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Type { get; set; } = "";
    public required DateOnly PublishedDate { get; set; }
    public string? Description { get; set; } = "";
    public string? Article { get; set; } = "";
    public bool Completed { get; set; } = false;
    public User? Author { get; set; }
    public string UserId { get; set; } = "";
}
