namespace GqlPlus.Reading;

public record GqReqInput(
  string? Category,
  string? Operation,
  string Definition,
  IReadOnlyList<(string Path, string Value)> Parameters
);
