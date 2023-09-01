using System.Text;
using SharpGits.Console.GitObjects;

namespace SharpGits.Console.Data;

public class BlobSerializer
{
    private readonly byte[] nullByte = { 0x0 };
    private readonly byte[] blobAscii = Encoding.ASCII.GetBytes("blob ");
    public byte[] Serialize(Blob blob)
    {
        if (blob == null)
        {
            throw new ArgumentNullException(nameof(blob), "Blob to serialize cannot be null");
        }
        var content = new List<byte>();
        var blobLengthAscii = Encoding.ASCII.GetBytes(blob.Content.Length.ToString());
        content.AddRange(blobAscii);
        content.AddRange(blobLengthAscii);
        content.AddRange(nullByte);
        content.AddRange(blob.Content);
        return content.ToArray();
    }

    public Blob Deserialize(byte[] blobBytes)
    {
        //This skips all header information until the null byte and skips past the null byte
        return new Blob()
        {
            Content = blobBytes.SkipWhile(x => x != 0x0).Skip(1).ToArray(),
        };
    }
}