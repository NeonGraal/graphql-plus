namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstAliasedTests
  : AstAliasedTests<string>
{ }

public abstract class AstAliasedTests<I> : AstBaseTests<I>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlias(I input, string aliased)
  => AliasedChecks.HashCode(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAliases(I input, string alias1, string alias2)
  => AliasedChecks.HashCode(input, alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(I input, string aliased)
    => AliasedChecks.String(input, AliasesString(input, aliased), aliased);

  [Theory, RepeatData(Repeats)]
  public void String_WithAliases(I input, string alias1, string alias2)
    => AliasedChecks.String(input, AliasesString(input, alias1, alias2), alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlias(I input, string aliased)
    => AliasedChecks.Equality(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAliases(I input, string alias1, string alias2)
    => AliasedChecks.Equality(input, alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAlias(I input, string aliased)
    => AliasedChecks.Inequality_WithAliases(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAliases(I input, string alias1, string alias2)
    => AliasedChecks.Inequality_WithAliases(input, alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByAliased(I input, string aliased1, string aliased2)
    => AliasedChecks.Inequality_ByAliased(input, aliased1, aliased2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByNames(I input1, I input2, string aliased)
    => AliasedChecks.Inequality_ByInputs(input1, input2, aliased);

  protected virtual string AliasesString(I input, params string[] aliases)
    => AliasedChecks.AliasesString(input, aliases);

  internal override IAstBaseChecks<I> NamedChecks => AliasedChecks;

  internal abstract IAstAliasedChecks<I> AliasedChecks { get; }
}
