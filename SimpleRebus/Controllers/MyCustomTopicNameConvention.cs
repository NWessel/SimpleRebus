using Rebus.Topic;

namespace SimpleRebus.Controllers;

public class MyCustomTopicNameConvention : ITopicNameConvention
{
    public string GetTopic(Type eventType) => eventType.Name;
}
