using System.Collections.Generic;
namespace Feedback.Models;

public class Admin : Entity {
    public string Name { get; set; }
    public string Role { get; set; }
    public IList<Ticket> Tickets { get; set; } = new Ticket[] {};
    public IList<Feedback> Feedbacks { get; set; } = new Feedback[] {};
}