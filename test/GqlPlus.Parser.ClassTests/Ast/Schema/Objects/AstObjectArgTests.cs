﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectArgTests<TObjArg>
  : AstAbbreviatedTests<string>
  where TObjArg : IGqlpObjArg
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

  internal abstract IAstObjArgChecks<TObjArg> ObjArgChecks { get; }
}

internal sealed class AstObjArgChecks<TObjArg, TObjArgAst>(
  AstObjArgChecks<TObjArg, TObjArgAst>.ArgBy createArg
) : AstAbbreviatedChecks<string, TObjArg>(input => createArg(input))
  , IAstObjArgChecks<TObjArg>
  where TObjArg : IGqlpObjArg
  where TObjArgAst : ObjArgAst, TObjArg
{
  internal delegate TObjArgAst ArgBy(string input);

  public void HashCode_WithIsTypeParam(string input)
      => HashCode(() => createArg(input) with { IsTypeParam = true });

  public void String_WithIsTypeParam(string input)
    => Text(
      () => createArg(input) with { IsTypeParam = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParam(string input)
    => Equality(() => createArg(input) with { IsTypeParam = true });

  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => createArg(input) with { IsTypeParam = isTypeParam },
      false);

  public void HashCode_WithEnumValue(string input, string enumLabel)
      => HashCode(
        () => createArg(input) with { EnumLabel = enumLabel });

  public void String_WithEnumValue(string input, string enumLabel)
    => Text(
      () => createArg(input) with { EnumLabel = enumLabel },
      $"( {input}.{enumLabel} )");

  public void Equality_WithEnumValue(string input, string enumLabel)
    => Equality(
      () => createArg(input) with { EnumLabel = enumLabel });

  public void Inequality_BetweenEnumValues(string input, string enumLabel1, string enumLabel2)
    => InequalityBetween(enumLabel1, enumLabel2,
      enumLabel => createArg(input) with { EnumLabel = enumLabel },
      enumLabel1 == enumLabel2);

  public void FullType_WithDefault(string input)
  {
    TObjArg objArg = createArg(input);

    objArg.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    TObjArg objArg = createArg(input) with { IsTypeParam = true };

    objArg.FullType.ShouldBe("$" + input);
  }
}

internal interface IAstObjArgChecks<TObjArg>
  : IAstAbbreviatedChecks<string>
  where TObjArg : IGqlpObjArg
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
