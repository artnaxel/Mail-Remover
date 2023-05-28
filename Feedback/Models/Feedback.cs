using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System;
namespace Feedback.Models;

public class Feedback : Entity {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string category { get; set; }
    public int UserId { get; set; }
    // public User User { get; set; } // Lazy???
    public IList<Attachment> Attachments { get; set; } = new Attachment[] {};
}