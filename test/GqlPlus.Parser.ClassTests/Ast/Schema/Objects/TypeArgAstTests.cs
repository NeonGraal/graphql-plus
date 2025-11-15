using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

[CheckTestsFor(nameof(TypeArgChecks), typeof(ITypeArgAstChecks))]
public partial class TypeArgAstTests
  : ObjEnumBaseTests<string>
{
  //[Theory, RepeatData]
  //public void HashCode_WithIsTypeParam_Old(string input)
  //    => TypeArgChecks.HashCode_WithIsTypeParam(input);

  //[Theory, RepeatData]
  //public void Text_WithIsTypeParam_Old(string input)
  //  => TypeArgChecks.Text_WithIsTypeParam(input);

  //[Theory, RepeatData]
  //public void Equality_WithIsTypeParam_Old(string input)
  //  => TypeArgChecks.Equality_WithIsTypeParam(input);

  //[Theory, RepeatData]
  //public void Inequality_BetweenIsTypeParams_Old(string input, bool isTypeParam1)
  //  => TypeArgChecks.Inequality_BetweenIsTypeParams(input, isTypeParam1);

  //[Theory, RepeatData]
  //public void FullType_WithDefault_Old(string input)
  //  => TypeArgChecks.FullType_WithDefault(input);

  //[Theory, RepeatData]
  //public void FullType_WithIsTypeParam_Old(string input)
  //  => TypeArgChecks.FullType_WithIsTypeParam(input);

  internal sealed override IObjEnumChecks<string> EnumChecks => TypeArgChecks;

  internal TypeArgAstChecks TypeArgChecks { get; } = new();
}

internal sealed class TypeArgAstChecks()
  : ObjEnumChecks<string, TypeArgAst>(CreateTypeArg, CloneTypeArg)
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
  protected override TypeArgAst CreateEnum(string input, string enumLabel)
    => CreateInput(input) with { EnumValue = new EnumValueAst(AstNulls.At, input, enumLabel) };
}

internal interface ITypeArgAstChecks
  : IObjEnumChecks<string>
{
  void HashCode_WithIsTypeParam(string input);
  void Text_WithIsTypeParam(string input);
  void Equality_WithIsTypeParam(string input);
  void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParam(string input);
}
