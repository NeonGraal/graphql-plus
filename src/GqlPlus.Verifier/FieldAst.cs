namespace GqlPlus.Verifier;

internal class FieldAst : SelectionAst
{
  public FieldAst(string name) => Name = name;

  internal string Name { get; }
  internal string? Alias { get; init; }
}
