using System.Collections.Generic;
namespace Feedback.Models;

public class Admin : Entity {
    public string Name { get; set; }
    public string Role { get; set; }
    public Lazy<IEnumerable<Ticket>> Tickets { get; set; }
    public Lazy<IEnumerable<Feedback>> Feedbacks { get; set; }
}