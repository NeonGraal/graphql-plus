namespace GqlPlus.Decoding;

public record RequestBodyInput(
  string? Category,
  string? Operation,
  string Definition,
  Structured? Parameters
)
{
  public IMessages Errors { get; init; } = Messages.New;
}
