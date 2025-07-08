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
  void Convert();
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

  public void Convert()
  {
    for (int i = 0; i < Count; i++) {
      if (this[i].Level == MessageLevel.Error) {
        this[i] = this[i].Message.Warning();
      }
    }
  }

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

public static class MessageHelpers
{
  public static IMessage Error(this string message)
    => new AMessage(MessageLevel.Error, message);
  public static IMessage Warning(this string message)
    => new AMessage(MessageLevel.Warning, message);
  public static IMessage Info(this string message)
    => new AMessage(MessageLevel.Info, message);

  private sealed record class AMessage(
    MessageLevel Level,
    string Message
  ) : IMessage;
}
