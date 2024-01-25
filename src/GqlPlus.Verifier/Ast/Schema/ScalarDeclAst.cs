using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarDeclAstOld(
  TokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description), IEquatable<ScalarDeclAstOld>
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public string? Extends { get; set; }

  public string? EnumType { get; set; }
  public ScalarMemberEnumAst[] Enums { get; set; } = [];

  public ScalarRangeAst[] Numbers { get; set; } = [];
  public ScalarRegexAst[] Regexes { get; set; } = [];
  public ScalarReferenceAst[] References { get; set; } = [];

  internal override string Abbr => "S";
  public override string Label => "Scalar";

  public ScalarDeclAstOld(TokenAt at, string name)
    : this(at, name, "") { }

  public ScalarDeclAstOld(TokenAt at, string name, ScalarRangeAst[] numbers)
    : this(at, name, "")
    => Numbers = numbers;
  public ScalarDeclAstOld(TokenAt at, string name, string enumType, ScalarMemberEnumAst[] enums)
    : this(at, name, "")
    => (EnumType, Enums) = (enumType, enums);
  public ScalarDeclAstOld(TokenAt at, string name, ScalarRegexAst[] regexes)
    : this(at, name, "")
    => (Kind, Regexes) = (ScalarKind.String, regexes);
  public ScalarDeclAstOld(TokenAt at, string name, ScalarReferenceAst[] references)
    : this(at, name, "")
    => (Kind, References) = (ScalarKind.Union, references);

  public bool Equals(ScalarDeclAstOld? other)
    => base.Equals(other)
      && Kind == other.Kind
      && Extends.NullEqual(other.Extends)
      && EnumType.NullEqual(other.EnumType)
      && Enums.SequenceEqual(other.Enums)
      && Numbers.SequenceEqual(other.Numbers)
      && References.SequenceEqual(other.References)
      && Regexes.SequenceEqual(other.Regexes);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Kind, Extends, EnumType, Numbers.Length, Enums.Length, References.Length, Regexes.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Kind.ToString())
      .Append(Extends.Prefixed(":"))
      .Append(EnumType)
      .Concat(Numbers.Bracket())
      .Concat(Enums.Bracket())
      .Concat(References.Bracket())
      .Concat(Regexes.Bracket());
}
