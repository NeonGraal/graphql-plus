using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class TypeArgAstTests
  : AstAbbreviatedTests<string>
{
  [Theory, RepeatData]
  public void HashCode_WithIsTypeParam(string input)
      => TypeArgChecks.HashCode_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void String_WithIsTypeParam(string input)
    => TypeArgChecks.String_WithIsTypeParam(input);

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
  public void String_WithEnumValue(string input, string enumLabel)
    => TypeArgChecks.String_WithEnumValue(input, enumLabel);

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

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  internal TypeArgAstChecks TypeArgChecks { get; } = new();
}

internal sealed class TypeArgAstChecks
  : AstAbbreviatedChecks<string, IGqlpTypeArg>
  , ITypeArgAstChecks
{
  public TypeArgAstChecks()
    : base(ArgBy)
  { }

  internal static TypeArgAst ArgBy(string input)
    => new(AstNulls.At, input, "");

  public void HashCode_WithIsTypeParam(string input)
      => HashCode(() => ArgBy(input) with { IsTypeParam = true });

  public void String_WithIsTypeParam(string input)
    => Text(
      () => ArgBy(input) with { IsTypeParam = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParam(string input)
    => Equality(() => ArgBy(input) with { IsTypeParam = true });

  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => ArgBy(input) with { IsTypeParam = isTypeParam },
      false);

  public void HashCode_WithEnumValue(string input, string enumLabel)
      => HashCode(
        () => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) });

  public void String_WithEnumValue(string input, string enumLabel)
    => Text(
      () => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) },
      $"( {input}.{enumLabel} )");

  public void Equality_WithEnumValue(string input, string enumLabel)
    => Equality(
      () => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) });

  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => InequalityBetween(enumLabel1, enumLabel2,
      enumLabel => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) },
      enumLabel1 == enumLabel2);

  public void FullType_WithDefault(string input)
  {
    TypeArgAst objArg = ArgBy(input);

    objArg.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    IGqlpTypeArg objArg = ArgBy(input) with { IsTypeParam = true };

    objArg.FullType.ShouldBe("$" + input);
  }
}

internal interface ITypeArgAstChecks
  : IAstAbbreviatedChecks<string>
{
  void HashCode_WithIsTypeParam(string input);
  void String_WithIsTypeParam(string input);
  void Equality_WithIsTypeParam(string input);
  void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1);
  void HashCode_WithEnumValue(string input, string enumLabel);
  void String_WithEnumValue(string input, string enumLabel);
  void Equality_WithEnumValue(string input, string enumLabel);
  void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParam(string input);
}
