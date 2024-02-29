namespace GqlPlus.Verifier.Ast.Schema;

public abstract class AstAliasedTests
  : AstAliasedTests<string>
{ }

public abstract class AstAliasedTests<TInput>
  : AstAbbreviatedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlias(TInput input, string aliased)
  => AliasedChecks.HashCode(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAliases(TInput input, string alias1, string alias2)
  => AliasedChecks.HashCode(input, alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(TInput input, string aliased)
    => AliasedChecks.String(input, AliasesString(input, Aliases(aliased)), aliased);

  [Theory, RepeatData(Repeats)]
  public void String_WithAliases(TInput input, string[] aliases)
    => AliasedChecks.String(input, AliasesString(input, Aliases(aliases)), aliases);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlias(TInput input, string aliased)
    => AliasedChecks.Equality(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAliases(TInput input, string alias1, string alias2)
    => AliasedChecks.Equality(input, alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAlias(TInput input, string aliased)
    => AliasedChecks.Inequality_WithAliases(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAliases(TInput input, string alias1, string alias2)
    => AliasedChecks.Inequality_WithAliases(input, alias1, alias2);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_ByAliased(TInput input, string aliased1, string aliased2)
    => AliasedChecks.Inequality_ByAliased(input, aliased1, aliased2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_ByInputs(TInput input1, TInput input2, string aliased)
    => AliasedChecks.Inequality_ByInputs(input1, input2, aliased);

  protected virtual string AliasesString(TInput input, string aliases)
    => $"( !{AliasedChecks.Abbr} {input}{aliases} )";

  protected override string AbbreviatedString(TInput input) => AliasesString(input, "");

  private static string Aliases(params string[] aliases)
    => aliases.Bracket(" [", "]").Joined();

  internal sealed override IAstAbbreviatedChecks<TInput> AbbreviatedChecks => AliasedChecks;

  internal abstract IAstAliasedChecks<TInput> AliasedChecks { get; }
}

internal sealed class AstAliasedChecks<TAliased>
  : AstAliasedChecks<string, TAliased>, IAstAliasedChecks
  where TAliased : AstAliased
{
  public AstAliasedChecks(CreateBy<string> create)
    : base(create) { }
}

internal class AstAliasedChecks<TInput, TAliased>
  : AstAbbreviatedChecks<TInput, TAliased>, IAstAliasedChecks<TInput>
  where TAliased : AstAliased
{
  public AstAliasedChecks(CreateBy<TInput> create)
    : base(create) { }

  public void HashCode(TInput input, params string[] aliases)
    => HashCode(
      () => CreateAliases(input, aliases),
      _createExpression);

  public void Equality(TInput input, params string[] aliases)
    => Equality(
      () => CreateAliases(input, aliases),
      _createExpression);

  public void Inequality_WithAliases(TInput input, params string[] aliases)
    => Inequality(
      () => CreateAliases(input, aliases),
      () => CreateInput(input),
      factoryExpression: _createExpression);

  public void Inequality_ByAliased(TInput input, string aliased1, string aliased2)
    => InequalityBetween(aliased1, aliased2,
      aliased => CreateAliases(input, aliased),
      aliased1 == aliased2, _createExpression);

  public void Inequality_ByInputs(TInput input1, TInput input2, string aliased)
    => InequalityBetween(input1, input2,
      input => CreateAliases(input, aliased),
      input1!.Equals(input2), _createExpression);

  public void String(TInput input, string expected, params string[] aliases)
    => Text(
      () => CreateAliases(input, aliases), expected,
      factoryExpression: _createExpression);

  private TAliased CreateAliases(TInput input, params string[] aliases)
    => CreateInput(input) with { Aliases = aliases };
}

internal interface IAstAliasedChecks
  : IAstAliasedChecks<string>, IAstBaseChecks
{ }

internal interface IAstAliasedChecks<TInput> : IAstAbbreviatedChecks<TInput>
{
  void HashCode(TInput input, params string[] aliases);
  void String(TInput input, string expected, params string[] aliases);
  void Equality(TInput input, params string[] aliases);
  void Inequality_WithAliases(TInput input, params string[] aliases);
  void Inequality_ByInputs(TInput input1, TInput input2, string aliased);
  void Inequality_ByAliased(TInput input, string aliased1, string aliased2);
}
