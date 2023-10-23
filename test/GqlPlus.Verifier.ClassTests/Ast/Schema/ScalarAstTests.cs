namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstTests : BaseAliasedAstTests
{

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithKind(string name, ScalarKind kind)
      => _checks.HashCode(
        () => new ScalarAst(AstNulls.At, name) { Kind = kind });

  [Theory, RepeatData(Repeats)]
  public void String_WithKind(string name, ScalarKind kind)
    => _checks.String(
      () => new ScalarAst(AstNulls.At, name) { Kind = kind },
      $"( !S {name} {kind} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithKind(string name, ScalarKind kind)
    => _checks.Equality(
      () => new ScalarAst(AstNulls.At, name) { Kind = kind });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenKinds(string name, ScalarKind kind1, ScalarKind kind2)
    => _checks.InequalityBetween(kind1, kind2,
      kind => new ScalarAst(AstNulls.At, name) { Kind = kind },
      kind1 == kind2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithRanges(string name, decimal min, decimal max)
      => _checks.HashCode(
        () => new ScalarAst(AstNulls.At, name, min.ScalarRanges(max)));

  [Theory, RepeatData(Repeats)]
  public void String_WithRanges(string name, decimal min, decimal max)
    => _checks.String(
      () => new ScalarAst(AstNulls.At, name, min.ScalarRanges(max)),
      $"( !S {name} Number !SR " + (max < min ? $"{max} .. {min} )" : $"{min} .. {max} )"));

  [Theory, RepeatData(Repeats)]
  public void Equality_WithRanges(string name, decimal min, decimal max)
    => _checks.Equality(
      () => new ScalarAst(AstNulls.At, name, min.ScalarRanges(max)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenRanges(string name, decimal min1, decimal min2, decimal max)
    => _checks.InequalityBetween(min1, min2,
      min => new ScalarAst(AstNulls.At, name, min.ScalarRanges(max)),
      min1 == min2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithRegexes(string name, string regex)
      => _checks.HashCode(
        () => new ScalarAst(AstNulls.At, name, regex.ScalarRegexes()));

  [Theory, RepeatData(Repeats)]
  public void String_WithRegexes(string name, string regex)
    => _checks.String(
      () => new ScalarAst(AstNulls.At, name, regex.ScalarRegexes()),
      $"( !S {name} String !SX ~/{regex}/ )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithRegexes(string name, string regex)
    => _checks.Equality(
      () => new ScalarAst(AstNulls.At, name, regex.ScalarRegexes()));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenRegexes(string name, string regex1, string regex2)
    => _checks.InequalityBetween(regex1, regex2,
      regex => new ScalarAst(AstNulls.At, name, regex.ScalarRegexes()),
      regex1 == regex2);

  protected override string InputString(string input)
   => $"( !S {input} Number )";

  protected override string AliasesString(string input, params string[] aliases)
    => $"( !S {input} [ {string.Join(" ", aliases)} ] Number )";

  private readonly BaseAliasedAstChecks<ScalarAst> _checks
    = new(name => new ScalarAst(AstNulls.At, name));

  internal override IBaseAliasedAstChecks<string> AliasedChecks => _checks;
}
