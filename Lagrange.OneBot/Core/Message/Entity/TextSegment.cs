using System.Text.Json.Serialization;
using Lagrange.Core.Message;
using Lagrange.Core.Message.Entity;

namespace Lagrange.OneBot.Core.Message.Entity;

[Serializable]
public partial class TextSegment(string text)
{
    public TextSegment() : this("") { }

    [JsonPropertyName("text")] public string Text { get; set; } = text;
}

[SegmentSubscriber(typeof(TextEntity), "text")]
public partial class TextSegment : ISegment
{
    public IMessageEntity ToEntity() => new TextEntity(Text);

    public ISegment FromEntity(IMessageEntity entity)
    {
        if (entity is not TextEntity textEntity) throw new ArgumentException("Invalid entity type.");
        
        return new TextSegment(textEntity.Text);
    }
}