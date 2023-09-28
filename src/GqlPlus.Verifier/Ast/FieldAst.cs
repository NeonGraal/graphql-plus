namespace GqlPlus.Verifier.Ast;

internal record class FieldAst : NamedAst, SelectionAst
{
  public FieldAst(string name) : base(name) { }

  internal string? Alias { get; init; }
}
