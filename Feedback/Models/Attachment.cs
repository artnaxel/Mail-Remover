namespace Feedback.Models;

using System.IO;
using System.IO.Enumeration;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;

public class Attachment : Entity {
    public long FileSize { get; set; }
    public string FileType { get; set; }
    public string FileName { get; set; }
    [JsonConverter(typeof(Base64EncodedStringConverter))]
    public byte[] Bytes { get; set; }
}

public class Base64EncodedStringConverter : JsonConverter<byte []>
{
    public override byte[] Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        return reader.GetBytesFromBase64();
    }

    public override void Write(
        Utf8JsonWriter writer, 
        byte[] value, 
        JsonSerializerOptions options
    ) =>
        writer.WriteString("bytes", Convert.ToBase64String(value));
}