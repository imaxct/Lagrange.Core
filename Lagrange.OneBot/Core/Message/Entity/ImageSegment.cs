using System.Text.Json.Serialization;
using Lagrange.Core.Message;
using Lagrange.Core.Message.Entity;

namespace Lagrange.OneBot.Core.Message.Entity;

[Serializable]
public partial class ImageSegment(string url)
{
    public ImageSegment() : this("") { }
    
    [JsonPropertyName("file")] public string Url { get; set; } = url;
}

[SegmentSubscriber(typeof(ImageEntity), "image")]
public partial class ImageSegment : ISegment
{
    public IMessageEntity ToEntity() => new ImageEntity(url);

    public ISegment FromEntity(IMessageEntity entity)
    {
        if (entity is not ImageEntity imageEntity) throw new ArgumentException("Invalid entity type.");

        return new ImageSegment(imageEntity.ImageUrl);
    }
}