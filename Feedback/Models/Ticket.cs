using System;
namespace Feedback.Models;

public class Ticket : Entity {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueBy { get; set; }
    public DateTime Created { get; set; }
    public string Status { get; set; }
    public string Priotity { get; set; }
    public Feedback Feedback { get; set; }
}