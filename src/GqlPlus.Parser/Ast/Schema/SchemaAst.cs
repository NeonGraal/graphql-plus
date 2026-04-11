using GqlPlus;

namespace GqlPlus.Ast.Schema;

internal sealed record class SchemaAst(
  ITokenAt At
) : AstAbbreviated(At)
  , IAstSchema
{
  public ParseResultKind Result { get; set; }
  internal IMessages Errors { get; set; } = Messages.New;

  public IAstDeclaration[] Declarations { get; set; } = [];

  internal override string Abbr => "Sc";

  IEnumerable<IAstDeclaration> IAstSchema.Declarations => Declarations;
  IMessages IAstSchema.Errors => Errors;

  public bool Equals(SchemaAst? other)
    => other is IAstSchema schema && Equals(schema);
  public bool Equals(IAstSchema? other)
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

  private class DeclarationComparer : IComparer<IAstDeclaration>
  {
    public int Compare(IAstDeclaration? x, IAstDeclaration? y)
    {
      if (x is null || y is null) {
        return x is null ? y is null ? 0 : -1 : 1;
      }

      int label = x.Label.Compare(y.Label);
      if (label != 0) {
        return label;
      }

      return x.Name.Compare(y.Name);
    }
  }
}
