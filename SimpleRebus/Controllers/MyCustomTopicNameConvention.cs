using Rebus.Topic;

namespace SimpleRebus.Controllers;

public class MyCustomTopicNameConvention : ITopicNameConvention
{
    public string GetTopic(Type eventType)
    {
        var name = eventType.Name;
        var nameoff = nameof(name);
        return nameoff;
    }
}
