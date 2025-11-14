using System.Runtime.CompilerServices;

namespace GqlPlus.Ast.Schema;

public abstract class AstNamedBaseTests<TInput>
  : AstAbbreviatedBaseTests<TInput>
{
  [Theory, RepeatData]
  public void HashCode_WithDescription(TInput input, string description)
  => NamedChecks.HashCode_WithDescription(input, description);

  [Theory, RepeatData]
  public void Text_WithDescription(TInput input, string description)
    => NamedChecks.Text_WithDescription(input, description);

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
{
  protected override string InputName(string input) => input;
}

internal abstract class AstNamedChecks<TInput, TNamed>(
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

  public void Text_WithDescription(TInput input, string description)
    => Text(
      () => CreateDescription(input, description),
      DescriptionString(input, description),
      factoryExpression: CreateExpression);

  private TNamed CreateDescription(TInput input, string description)
    => CreateInput(input) with { Description = description };

  protected virtual string DescriptionString(TInput input, string description)
    => $"( {DescriptionNameString(input, description)} )";

  protected string DescriptionNameString(TInput input, string description)
    => string.IsNullOrWhiteSpace(description)
      ? $"!{Abbr} {InputName(input)}"
      : $"'{description}' !{Abbr} {InputName(input)}";

  protected abstract string InputName(TInput input);

  protected sealed override string AbbreviatedString(TInput input) => DescriptionString(input, "");
}

internal interface IAstNamedChecks
  : IAstNamedChecks<string>
  , IAstBaseChecks
{ }

internal interface IAstNamedChecks<TInput>
  : IAstAbbreviatedChecks<TInput>
{
  void HashCode_WithDescription(TInput input, string description);
  void Text_WithDescription(TInput input, string description);
  void Equality_WithDescription(TInput input, string description);
  void Inequality_WithDescription(TInput input, string description);
  void Inequality_WithDescriptionByInputs(TInput input1, TInput input2, string description);
  void Inequality_ByDescription(TInput input, string description1, string description2);
}
