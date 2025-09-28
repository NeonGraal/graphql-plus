using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class ObjTypeArgAstTests
  : AstAbbreviatedTests<string>
{
  [Theory, RepeatData]
  public void HashCode_WithIsTypeParam(string input)
      => ObjTypeArgChecks.HashCode_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void String_WithIsTypeParam(string input)
    => ObjTypeArgChecks.String_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Equality_WithIsTypeParam(string input)
    => ObjTypeArgChecks.Equality_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => ObjTypeArgChecks.Inequality_BetweenIsTypeParams(input, isTypeParam1);

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(string input, string enumLabel)
    => ObjTypeArgChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void String_WithEnumValue(string input, string enumLabel)
    => ObjTypeArgChecks.String_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string input, string enumLabel)
    => ObjTypeArgChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => ObjTypeArgChecks.Inequality_BetweenEnumValues(input, enumLabel1, enumLabel2);

  [Theory, RepeatData]
  public void FullType_WithDefault(string input)
    => ObjTypeArgChecks.FullType_WithDefault(input);

  [Theory, RepeatData]
  public void FullType_WithIsTypeParam(string input)
    => ObjTypeArgChecks.FullType_WithIsTypeParam(input);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ObjTypeArgChecks;

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  internal ObjTypeArgAstChecks ObjTypeArgChecks { get; } = new();
}

internal sealed class ObjTypeArgAstChecks
  : AstAbbreviatedChecks<string, IGqlpObjTypeArg>
  , IObjTypeArgAstChecks
{
  public ObjTypeArgAstChecks()
    : base(ArgBy)
  { }

  internal static ObjTypeArgAst ArgBy(string input)
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
        () => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) });

  public void String_WithEnumValue(string input, string enumLabel)
    => Text(
      () => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) },
      $"( {input}.{enumLabel} )");

  public void Equality_WithEnumValue(string input, string enumLabel)
    => Equality(
      () => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) });

  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => InequalityBetween(enumLabel1, enumLabel2,
      enumLabel => ArgBy(input) with { EnumValue = new EnumValueAst(AstNulls.At, enumLabel) },
      enumLabel1 == enumLabel2);

  public void FullType_WithDefault(string input)
  {
    ObjTypeArgAst objArg = ArgBy(input);

    objArg.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    IGqlpObjTypeArg objArg = ArgBy(input) with { IsTypeParam = true };

    objArg.FullType.ShouldBe("$" + input);
  }
}

internal interface IObjTypeArgAstChecks
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
