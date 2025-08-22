using System.Runtime.CompilerServices;

namespace GqlPlus.Ast.Schema;

public abstract class AstAliasedTests
  : AstAliasedTests<string>
{
  protected override string InputName(string input) => input;
}

public abstract class AstAliasedTests<TInput>
  : AstNamedTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithAlias(TInput input, string aliased)
  => AliasedChecks.HashCode_WithAliases(input, aliased);

  [Theory, RepeatData]
  public void HashCode_WithAliases(TInput input, string alias1, string alias2)
  => AliasedChecks.HashCode_WithAliases(input, alias1, alias2);

  [Theory, RepeatData]
  public void String_WithAlias(TInput input, string aliased)
    => AliasedChecks.String_WithAliases(input, AliasesString(input, "", Aliases(aliased)), aliased);

  [Theory, RepeatData]
  public void String_WithAliases(TInput input, string[] aliases)
    => AliasedChecks.String_WithAliases(input, AliasesString(input, "", Aliases(aliases)), aliases);

  [Theory, RepeatData]
  public void Equality_WithAlias(TInput input, string aliased)
    => AliasedChecks.Equality_WithAliases(input, aliased);

  [Theory, RepeatData]
  public void Equality_WithAliases(TInput input, string alias1, string alias2)
    => AliasedChecks.Equality_WithAliases(input, alias1, alias2);

  [Theory, RepeatData]
  public void Inequality_WithAlias(TInput input, string aliased)
    => AliasedChecks.Inequality_WithAliases(input, aliased + "Z");

  [Theory, RepeatData]
  public void Inequality_WithAliases(TInput input, string alias1, string alias2)
    => AliasedChecks.Inequality_WithAliases(input, alias1, alias2);

  [Theory, RepeatData]
  public void Inequality_ByAliases(TInput input, string alias1, string alias2)
    => AliasedChecks
      .SkipEqual(alias1, alias2)
      .Inequality_ByAliases(input, alias1, alias2);

  [Theory, RepeatData]
  public void Inequality_WithAliasByInputs(TInput input1, TInput input2, string aliased)
    => AliasedChecks
      .SkipEqual(input1, input2)
      .Inequality_WithAliasByInputs(input1, input2, aliased);

  protected virtual string AliasesString(TInput input, string description, string aliases)
    => $"( {DescriptionNameString(input, description)}{aliases} )";

  protected sealed override string DescriptionString(TInput input, string description)
    => AliasesString(input, description, "");

  private static string Aliases(params string[] aliases)
    => aliases.Bracket(" [", "]", true).Joined();

  internal sealed override IAstNamedChecks<TInput> NamedChecks => AliasedChecks;

  internal abstract IAstAliasedChecks<TInput> AliasedChecks { get; }
}

internal class AstAliasedChecks<TAliased>(
  BaseAstChecks<TAliased>.CreateBy<string> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAliasedChecks<string, TAliased>(createInput, createExpression)
  , IAstAliasedChecks
  where TAliased : AstAliased
{ }

internal class AstAliasedChecks<TInput, TAliased>(
  BaseAstChecks<TAliased>.CreateBy<TInput> createInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstNamedChecks<TInput, TAliased>(createInput, createExpression)
  , IAstAliasedChecks<TInput>
  where TAliased : AstAliased
{
  public void HashCode_WithAliases(TInput input, params string[] aliases)
    => HashCode(
      () => CreateAliases(input, aliases),
      CreateExpression);

  public void Equality_WithAliases(TInput input, params string[] aliases)
    => Equality(
      () => CreateAliases(input, aliases),
      CreateExpression);

  public void Inequality_WithAliases(TInput input, params string[] aliases)
    => Inequality(
      () => CreateAliases(input, aliases),
      () => CreateInput(input),
      factoryExpression: CreateExpression);

  public void Inequality_ByAliases(TInput input, string aliases1, string aliases2)
    => InequalityBetween(aliases1, aliases2,
      aliases => CreateAliases(input, aliases),
      CreateExpression);

  public void Inequality_WithAliasByInputs(TInput input1, TInput input2, string aliased)
    => InequalityBetween(input1, input2,
      input => CreateAliases(input, aliased),
      CreateExpression);

  public void String_WithAliases(TInput input, string expected, params string[] aliases)
    => Text(
      () => CreateAliases(input, aliases), expected,
      factoryExpression: CreateExpression);

  private TAliased CreateAliases(TInput input, params string[] aliases)
    => CreateInput(input) with { Aliases = aliases };
}

internal interface IAstAliasedChecks
  : IAstAliasedChecks<string>
  , IAstBaseChecks
{ }

internal interface IAstAliasedChecks<TInput>
  : IAstNamedChecks<TInput>
{
  void HashCode_WithAliases(TInput input, params string[] aliases);
  void String_WithAliases(TInput input, string expected, params string[] aliases);
  void Equality_WithAliases(TInput input, params string[] aliases);
  void Inequality_WithAliases(TInput input, params string[] aliases);
  void Inequality_WithAliasByInputs(TInput input1, TInput input2, string alias);
  void Inequality_ByAliases(TInput input, string alias1, string alias2);
}
