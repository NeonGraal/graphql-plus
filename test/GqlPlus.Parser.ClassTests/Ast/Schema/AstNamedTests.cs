using System.Runtime.CompilerServices;

namespace GqlPlus.Ast.Schema;

public abstract class AstNamedTests
  : AstNamedTests<string>
{
  protected override string InputName(string input) => input;
}

public abstract class AstNamedTests<TInput>
  : AstAbbreviatedTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithDescription(TInput input, string description)
  => NamedChecks.HashCode_WithDescription(input, description);

  [Theory, RepeatData]
  public void String_WithDescription(TInput input, string description)
    => NamedChecks.String_WithDescription(input, DescriptionString(input, description), description);

  [Theory, RepeatData]
  public void Equality_WithDescription(TInput input, string description)
    => NamedChecks.Equality_WithDescription(input, description);

  [Theory, RepeatData]
  public void Inequality_WithDescription(TInput input, string description)
    => NamedChecks.Inequality_WithDescription(input, description);

  [Theory, RepeatData]
  public void Inequality_ByDescription(TInput input, string description1, string description2)
    => NamedChecks
      .SkipEqual(description1, description2)
      .Inequality_ByDescription(input, description1, description2);

  [Theory, RepeatData]
  public void Inequality_WithDescriptionByInputs(TInput input1, TInput input2, string description)
    => NamedChecks
      .SkipEqual(input1, input2)
      .Inequality_WithDescriptionByInputs(input1, input2, description);

  protected virtual string DescriptionString(TInput input, string description)
    => $"( {DescriptionNameString(input, description)} )";

  protected string DescriptionNameString(TInput input, string description)
    => string.IsNullOrWhiteSpace(description)
      ? $"!{NamedChecks.Abbr} {InputName(input)}"
      : $"'{description}' !{NamedChecks.Abbr} {InputName(input)}";

  protected abstract string InputName(TInput input);

  protected sealed override string AbbreviatedString(TInput input) => DescriptionString(input, "");

  internal sealed override IAstAbbreviatedChecks<TInput> AbbreviatedChecks => NamedChecks;

  internal abstract IAstNamedChecks<TInput> NamedChecks { get; }
}

internal sealed class AstNamedChecks<TNamed>(
  BaseAstChecks<TNamed>.CreateBy<string> createInput,
  BaseAstChecks<TNamed>.CloneBy<string> cloneInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstNamedChecks<string, TNamed>(createInput, cloneInput, createExpression)
  , IAstNamedChecks
  where TNamed : AstNamed
{ }

internal class AstNamedChecks<TInput, TNamed>(
  BaseAstChecks<TNamed>.CreateBy<TInput> createInput,
  BaseAstChecks<TNamed>.CloneBy<TInput> cloneInput,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstAbbreviatedChecks<TInput, TNamed>(createInput, cloneInput, createExpression)
  , IAstNamedChecks<TInput>
  where TNamed : AstNamed
{
  public void HashCode_WithDescription(TInput input, string description)
    => HashCode(
      () => CreateDescription(input, description),
      CreateExpression);

  public void Equality_WithDescription(TInput input, string description)
    => Equality(
      () => CreateDescription(input, description),
      CreateExpression);

  public void Inequality_WithDescription(TInput input, string description)
    => Inequality(
      () => CreateDescription(input, description),
      () => CreateInput(input),
      factory1Expression: CreateExpression);

  public void Inequality_ByDescription(TInput input, string description1, string description2)
    => InequalityBetween(description1, description2,
      description => CreateDescription(input, description),
      CreateExpression);

  public void Inequality_WithDescriptionByInputs(TInput input1, TInput input2, string description)
    => InequalityBetween(input1, input2,
      input => CreateDescription(input, description),
      CreateExpression);

  public void String_WithDescription(TInput input, string expected, string description)
    => Text(
      () => CreateDescription(input, description), expected,
      factoryExpression: CreateExpression);

  private TNamed CreateDescription(TInput input, string description)
    => CreateInput(input) with { Description = description };
}

internal interface IAstNamedChecks
  : IAstNamedChecks<string>
  , IAstBaseChecks
{ }

internal interface IAstNamedChecks<TInput>
  : IAstAbbreviatedChecks<TInput>
{
  void HashCode_WithDescription(TInput input, string description);
  void String_WithDescription(TInput input, string expected, string description);
  void Equality_WithDescription(TInput input, string description);
  void Inequality_WithDescription(TInput input, string description);
  void Inequality_WithDescriptionByInputs(TInput input1, TInput input2, string description);
  void Inequality_ByDescription(TInput input, string description1, string description2);
}
