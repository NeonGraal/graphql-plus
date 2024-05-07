using System.Runtime.CompilerServices;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

public abstract class AstAliasedTests
  : AstAliasedTests<string>
{ }

public abstract class AstAliasedTests<TInput>
  : AstAbbreviatedTests<TInput>
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlias(TInput input, string aliased)
  => AliasedChecks.HashCode_WithAliases(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAliases(TInput input, string alias1, string alias2)
  => AliasedChecks.HashCode_WithAliases(input, alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(TInput input, string aliased)
    => AliasedChecks.String_WithAliases(input, AliasesString(input, Aliases(aliased)), aliased);

  [Theory, RepeatData(Repeats)]
  public void String_WithAliases(TInput input, string[] aliases)
    => AliasedChecks.String_WithAliases(input, AliasesString(input, Aliases(aliases)), aliases);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlias(TInput input, string aliased)
    => AliasedChecks.Equality_WithAliases(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAliases(TInput input, string alias1, string alias2)
    => AliasedChecks.Equality_WithAliases(input, alias1, alias2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAlias(TInput input, string aliased)
    => AliasedChecks.Inequality_WithAliases(input, aliased);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAliases(TInput input, string alias1, string alias2)
    => AliasedChecks.Inequality_WithAliases(input, alias1, alias2);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_ByAliases(TInput input, string alias1, string alias2)
    => AliasedChecks
      .SkipIf(alias1 == alias2)
      .Inequality_ByAliases(input, alias1, alias2);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_ByInputs(TInput input1, TInput input2, string aliased)
    => AliasedChecks
      .SkipIf(input1!.Equals(input2))
      .Inequality_ByInputs(input1, input2, aliased);

  protected virtual string AliasesString(TInput input, string aliases)
    => $"( !{AliasedChecks.Abbr} {input}{aliases} )";

  protected override string AbbreviatedString(TInput input) => AliasesString(input, "");

  private static string Aliases(params string[] aliases)
    => aliases.Bracket(" [", "]").Joined();

  internal sealed override IAstAbbreviatedChecks<TInput> AbbreviatedChecks => AliasedChecks;

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
) : AstAbbreviatedChecks<TInput, TAliased>(createInput, createExpression)
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

  public void Inequality_ByInputs(TInput input1, TInput input2, string aliased)
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
  : IAstAbbreviatedChecks<TInput>
{
  void HashCode_WithAliases(TInput input, params string[] aliases);
  void String_WithAliases(TInput input, string expected, params string[] aliases);
  void Equality_WithAliases(TInput input, params string[] aliases);
  void Inequality_WithAliases(TInput input, params string[] aliases);
  void Inequality_ByInputs(TInput input1, TInput input2, string alias);
  void Inequality_ByAliases(TInput input, string alias1, string alias2);
}
