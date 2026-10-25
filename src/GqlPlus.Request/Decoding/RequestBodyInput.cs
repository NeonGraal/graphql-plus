namespace GqlPlus.Decoding;

public record RequestBodyInput(
  string? Category,
  string? Operation,
  string Definition,
  IGqlpValue? Parameters
)
{
  public IMessages Errors { get; init; } = Messages.New;
}
