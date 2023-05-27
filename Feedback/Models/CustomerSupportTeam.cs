using System.Collections.Generic;
namespace Feedback.Models;

public class CustomerSupportTeam : Entity {
    public string Role { get; set; }
    public IEnumerable<Ticket> Tickets { get; set; }
}