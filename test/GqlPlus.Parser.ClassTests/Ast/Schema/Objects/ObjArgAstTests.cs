using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class ObjArgAstTests
  : AstAbbreviatedTests<string>
{
  [Theory, RepeatData]
  public void HashCode_WithIsTypeParam(string input)
      => ObjArgChecks.HashCode_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void String_WithIsTypeParam(string input)
    => ObjArgChecks.String_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Equality_WithIsTypeParam(string input)
    => ObjArgChecks.Equality_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => ObjArgChecks.Inequality_BetweenIsTypeParams(input, isTypeParam1);

  [Theory, RepeatData]
  public void HashCode_WithEnumValue(string input, string enumLabel)
    => ObjArgChecks.HashCode_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void String_WithEnumValue(string input, string enumLabel)
    => ObjArgChecks.String_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Equality_WithEnumValue(string input, string enumLabel)
    => ObjArgChecks.Equality_WithEnumValue(input, enumLabel);

  [Theory, RepeatData]
  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => ObjArgChecks.Inequality_BetweenEnumValues(input, enumLabel1, enumLabel2);

  [Theory, RepeatData]
  public void FullType_WithDefault(string input)
    => ObjArgChecks.FullType_WithDefault(input);

  [Theory, RepeatData]
  public void FullType_WithIsTypeParam(string input)
    => ObjArgChecks.FullType_WithIsTypeParam(input);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ObjArgChecks;

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  internal ObjArgAstChecks ObjArgChecks { get; } = new();
}

internal sealed class ObjArgAstChecks
  : AstAbbreviatedChecks<string, IGqlpObjArg>
  , IObjArgAstChecks
{
  public ObjArgAstChecks()
    : base(ArgBy)
  { }

  internal static ObjArgAst ArgBy(string input)
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
        () => ArgBy(input) with { EnumLabel = enumLabel });

  public void String_WithEnumValue(string input, string enumLabel)
    => Text(
      () => ArgBy(input) with { EnumLabel = enumLabel },
      $"( {input}.{enumLabel} )");

  public void Equality_WithEnumValue(string input, string enumLabel)
    => Equality(
      () => ArgBy(input) with { EnumLabel = enumLabel });

  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => InequalityBetween(enumLabel1, enumLabel2,
      enumLabel => ArgBy(input) with { EnumLabel = enumLabel },
      enumLabel1 == enumLabel2);

  public void FullType_WithDefault(string input)
  {
    ObjArgAst objArg = ArgBy(input);

    objArg.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    IGqlpObjArg objArg = ArgBy(input) with { IsTypeParam = true };

    objArg.FullType.ShouldBe("$" + input);
  }
}

internal interface IObjArgAstChecks
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
