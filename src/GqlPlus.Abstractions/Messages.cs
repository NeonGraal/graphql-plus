namespace GqlPlus;

public interface IMessage
{
  MessageLevel Level { get; }
  string Message { get; }
}

public interface IMessages
  : IReadOnlyList<IMessage>
{
  void Clear();
  IMessages Add(IMessage message);
  IMessages Add(IEnumerable<IMessage> messages);
}

public enum MessageLevel
{
  Error,
  Warning,
  Info
}

public class Messages(
  params IMessage[] collection
) : List<IMessage>(collection)
  , IMessages
{
  public static IMessages New
    => new Messages();

  IMessages IMessages.Add(IEnumerable<IMessage> messages)
    => messages.Aggregate(this as IMessages, (a, m) => a.Add(m));

  IMessages IMessages.Add(IMessage message)
  {
    if (!Contains(message)) {
      Add(message);
    }

    return this;
  }
}
