using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

internal sealed record class SchemaAst(TokenAt At)
  : AstAbbreviated(At)
  , IEquatable<SchemaAst>
  , IGqlpSchema
{
  public ParseResultKind Result { get; set; }
  internal TokenMessages Errors { get; set; } = [];

  public IGqlpDeclaration[] Declarations { get; set; } = [];

  internal override string Abbr => "Sc";

  IEnumerable<IGqlpDeclaration> IGqlpSchema.Declarations => Declarations;
  ITokenMessages IGqlpSchema.Errors => Errors;

  public string Show()
  {
    using StringWriter sw = new();
    int indent = 0;
    string[] begins = ["(", "{", "[", "<"];
    string[] ends = [")", "}", "]", ">"];
    foreach (string? field in GetFields()) {
      if (string.IsNullOrWhiteSpace(field)) {
        continue;
      }

      if (begins.Contains(field)) {
        Write(field);
        indent++;
      } else if (ends.Contains(field)) {
        indent--;
        Write(field);
      } else {
        Write(field);
      }
    }

    return sw.ToString();

    void Write(string text)
    {
      for (int i = 0; i < indent; i++) {
        sw.Write("  ");
      }

      sw.WriteLine(text);
    }
  }

  public bool Equals(SchemaAst? other)
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
