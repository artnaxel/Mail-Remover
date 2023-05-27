namespace Models;

using M = Feedback.Models;

public class CSTM : M.Entity {
    public string Role { get; set; }
    public Lazy<IEnumerable<M.Ticket>> AssignedTickets { get; set; }

}