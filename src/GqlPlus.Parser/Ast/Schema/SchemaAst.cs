using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

internal sealed record class SchemaAst(
  ITokenAt At
) : AstAbbreviated(At)
  , IGqlpSchema
{
  public ParseResultKind Result { get; set; }
  internal Messages Errors { get; set; } = [];

  public IGqlpDeclaration[] Declarations { get; set; } = [];

  internal override string Abbr => "Sc";

  IEnumerable<IGqlpDeclaration> IGqlpSchema.Declarations => Declarations;
  IMessages IGqlpSchema.Errors => Errors;

  public bool Equals(SchemaAst? other)
    => other is IGqlpSchema schema && Equals(schema);
  public bool Equals(IGqlpSchema? other)
    => base.Equals(other)
      && Result == other.Result
      && Declarations.OrderedEqual(other.Declarations, s_comparer)
      && Errors.SequenceEqual(other.Errors);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Result, Declarations.Length, Errors.Count);

  internal override IEnumerable<string?> GetFields()
    => // base.GetFields()
      new[] { AbbrAt, $"{Result}" }
      .Concat(Errors.Bracket("<", ">", true))
      .Concat(Declarations.SelectMany(d => d.Bracket("{", "}")));

  private static readonly DeclarationComparer s_comparer = new();

  private class DeclarationComparer : IComparer<IGqlpDeclaration>
  {
    public int Compare(IGqlpDeclaration? x, IGqlpDeclaration? y)
    {
      if (x is null || y is null) {
        return -1;
      }

      int label = string.Compare(x.Label, y.Label, StringComparison.Ordinal);
      if (label != 0) {
        return label;
      }

      return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
    }
  }
}
