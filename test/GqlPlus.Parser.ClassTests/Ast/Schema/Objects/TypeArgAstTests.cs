using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public partial class TypeArgAstTests
{
  [CheckTests(Inherited = true)]
  internal ITypeArgAstChecks TypeArgChecks { get; } = new TypeArgAstChecks();

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, TypeArgAst>(
      CreateTypeArg,
      (original, input) => original with { Name = input });

  internal static TypeArgAst CreateTypeArg(string input)
    => new(AstNulls.At, input, "");
}

internal sealed class TypeArgAstChecks()
  : ObjEnumChecks<string, TypeArgAst>(TypeArgAstTests.CreateTypeArg)
  , ITypeArgAstChecks
{
  public void HashCode_WithIsTypeParam(string input)
      => HashCode(() => CreateInput(input) with { IsTypeParam = true });

  public void Text_WithIsTypeParam(string input)
    => Text(
      () => CreateInput(input) with { IsTypeParam = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParam(string input)
    => Equality(() => CreateInput(input) with { IsTypeParam = true });

  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => CreateInput(input) with { IsTypeParam = isTypeParam },
      false);

  public void FullType_WithDefault(string input)
  {
    TypeArgAst objArg = CreateInput(input);

    objArg.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    IGqlpTypeArg objArg = CreateInput(input) with { IsTypeParam = true };

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
