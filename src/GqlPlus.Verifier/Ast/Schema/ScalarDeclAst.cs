﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarDeclAst(
  TokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description), IEquatable<ScalarDeclAst>
{
  public ScalarKind Kind { get; set; } = ScalarKind.Number;
  public ScalarRangeAst[] Ranges { get; set; } = Array.Empty<ScalarRangeAst>();
  public ScalarRegexAst[] Regexes { get; set; } = Array.Empty<ScalarRegexAst>();

  internal override string Abbr => "S";

  public ScalarDeclAst(TokenAt at, string name)
    : this(at, name, "") { }

  public ScalarDeclAst(TokenAt at, string name, ScalarRangeAst[] ranges)
    : this(at, name, "")
    => Ranges = ranges;
  public ScalarDeclAst(TokenAt at, string name, ScalarRegexAst[] regexes)
    : this(at, name, "")
    => (Kind, Regexes) = (ScalarKind.String, regexes);

  public bool Equals(ScalarDeclAst? other)
    => base.Equals(other)
      && Kind == other.Kind
      && Ranges.SequenceEqual(other.Ranges)
      && Regexes.SequenceEqual(other.Regexes);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Kind, Ranges.Length, Regexes.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Kind.ToString())
      .Concat(Ranges.Bracket())
      .Concat(Regexes.Bracket());
}

public enum ScalarKind
{
  Number,
  String,
}
