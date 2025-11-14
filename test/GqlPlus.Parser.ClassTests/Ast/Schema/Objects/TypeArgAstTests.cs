using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class TypeArgAstTests
  : AstAbbreviatedTests<string>
{
  [Theory, RepeatData]
  public void HashCode_WithIsTypeParam(string input)
      => TypeArgChecks.HashCode_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Text_WithIsTypeParam(string input)
    => TypeArgChecks.Text_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Equality_WithIsTypeParam(string input)
    => TypeArgChecks.Equality_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => TypeArgChecks.Inequality_BetweenIsTypeParams(input, isTypeParam1);

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(string input, string enumLabel)
    => TypeArgChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Text_WithEnumValue(string input, string enumLabel)
    => TypeArgChecks.Text_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string input, string enumLabel)
    => TypeArgChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => TypeArgChecks.Inequality_BetweenEnumValues(input, enumLabel1, enumLabel2);

  [Theory, RepeatData]
  public void FullType_WithDefault(string input)
    => TypeArgChecks.FullType_WithDefault(input);

  [Theory, RepeatData]
  public void FullType_WithIsTypeParam(string input)
    => TypeArgChecks.FullType_WithIsTypeParam(input);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => TypeArgChecks;

  internal TypeArgAstChecks TypeArgChecks { get; } = new();
}

internal sealed class TypeArgAstChecks()
  : AstAbbreviatedChecks<string, TypeArgAst>(CreateTypeArg, CloneTypeArg)
  , ITypeArgAstChecks
{
  private static TypeArgAst CloneTypeArg(TypeArgAst original, string input)
    => original with { Name = input };
  internal static TypeArgAst CreateTypeArg(string input)
    => new(AstNulls.At, input, "");

  public void HashCode_WithIsTypeParam(string input)
      => HashCode(() => CreateTypeArg(input) with { IsTypeParam = true });

  public void Text_WithIsTypeParam(string input)
    => Text(
      () => CreateTypeArg(input) with { IsTypeParam = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParam(string input)
    => Equality(() => CreateTypeArg(input) with { IsTypeParam = true });

  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => CreateTypeArg(input) with { IsTypeParam = isTypeParam },
      false);

  public void HashCode_WithEnumValue(string input, string enumLabel)
      => HashCode(
        () => CreateTypeArg(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) });

  public void Text_WithEnumValue(string input, string enumLabel)
    => Text(
      () => CreateTypeArg(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) },
      $"( {input}.{enumLabel} )");

  public void Equality_WithEnumValue(string input, string enumLabel)
    => Equality(
      () => CreateTypeArg(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) });

  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => InequalityBetween(enumLabel1, enumLabel2,
      enumLabel => CreateTypeArg(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) },
      enumLabel1 == enumLabel2);

  public void FullType_WithDefault(string input)
  {
    TypeArgAst objArg = CreateTypeArg(input);

    objArg.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    IGqlpTypeArg objArg = CreateTypeArg(input) with { IsTypeParam = true };

    objArg.FullType.ShouldBe("$" + input);
  }

  protected override string AbbreviatedString(string input)
    => $"( {input} )";
}

internal interface ITypeArgAstChecks
  : IAstAbbreviatedChecks<string>
{
  void HashCode_WithIsTypeParam(string input);
  void Text_WithIsTypeParam(string input);
  void Equality_WithIsTypeParam(string input);
  void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1);
  void HashCode_WithEnumValue(string input, string enumLabel);
  void Text_WithEnumValue(string input, string enumLabel);
  void Equality_WithEnumValue(string input, string enumLabel);
  void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParam(string input);
}
