namespace GqlPlus.Verifier.Ast;

internal record class DefinitionAst : NamedAst, IEquatable<DefinitionAst>
{
  internal DefinitionAst(string name) : base(name) { }

  internal string? OnType { get; set; }

  internal SelectionAst[] Object { get; set; } = Array.Empty<SelectionAst>();

  bool IEquatable<DefinitionAst>.Equals(DefinitionAst? other) =>
    base.Equals(other) &&
    OnType == other.OnType &&
    Object.SequenceEqual(other.Object);
}
