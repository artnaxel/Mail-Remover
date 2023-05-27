using System.IO;
using System.IO.Enumeration;
namespace Feedback.Models;

public class Attachment : Entity {
    public long FileSize { get; set; }
    public string FileType { get; set; }
    public string FileName { get; set; }
}