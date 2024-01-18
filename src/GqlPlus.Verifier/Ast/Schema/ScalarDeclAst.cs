using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description), IEquatable<ScalarDeclAst>
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public string? Extends { get; set; }

  public string? EnumType { get; set; }
  public ScalarRangeEnumAst[] Enums { get; set; } = [];

  public ScalarRangeNumberAst[] Numbers { get; set; } = [];
  public ScalarRegexAst[] Regexes { get; set; } = [];
  public ScalarReferenceAst[] References { get; set; } = [];

  internal override string Abbr => "S";
  public override string Label => "Scalar";

  public ScalarDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public ScalarDeclAst(TokenAt at, string name, ScalarRangeNumberAst[] numbers)
    : this(at, name, "")
    => Numbers = numbers;
  public ScalarDeclAst(TokenAt at, string name, string enumType, ScalarRangeEnumAst[] enums)
    : this(at, name, "")
    => (EnumType, Enums) = (enumType, enums);
  public ScalarDeclAst(TokenAt at, string name, ScalarRegexAst[] regexes)
    : this(at, name, "")
    => (Kind, Regexes) = (ScalarKind.String, regexes);
  public ScalarDeclAst(TokenAt at, string name, ScalarReferenceAst[] references)
    : this(at, name, "")
    => (Kind, References) = (ScalarKind.Union, references);

  public bool Equals(ScalarDeclAst? other)
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

public enum ScalarKind
{
  Boolean,
  Enum,
  Number,
  String,
  Union,
}
