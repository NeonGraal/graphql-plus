using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class ObjBaseAstTests
  : AstAbbreviatedBaseTests<string>
{
  [Theory, RepeatData]
  public void HashCode_WithIsTypeParam(string input)
      => ObjBaseChecks.HashCode_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Text_WithIsTypeParam(string input)
    => ObjBaseChecks.Text_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Equality_WithIsTypeParam(string input)
    => ObjBaseChecks.Equality_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => ObjBaseChecks.Inequality_BetweenIsTypeParams(input, isTypeParam1);

  [Theory, RepeatData]
  public void HashCode_WithArgs(string input, string[] arguments)
    => ObjBaseChecks.HashCode_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void Text_WithArgs(string input, string[] arguments)
    => ObjBaseChecks.Text_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void Equality_WithArgs(string input, string[] arguments)
    => ObjBaseChecks.Equality_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void Inequality_BetweenArgs(string input, string[] arguments1, string[] arguments2)
    => ObjBaseChecks.Inequality_BetweenArgs(input, arguments1, arguments2);

  [Theory, RepeatData]
  public void FullType_WithDefault(string input)
    => ObjBaseChecks.FullType_WithDefault(input);

  [Theory, RepeatData]
  public void FullType_WithIsTypeParam(string input)
    => ObjBaseChecks.FullType_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void FullType_WithArgs(string input, string[] arguments)
    => ObjBaseChecks.FullType_WithArgs(input, arguments);

  [Theory, RepeatData]
  public void FullType_WithIsTypeParamAndArgs(string input, string[] arguments)
    => ObjBaseChecks.FullType_WithIsTypeParamAndArgs(input, arguments);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ObjBaseChecks;

  protected override string InputString(string input)
    => $"( {input} )";

  internal ObjBaseAstChecks ObjBaseChecks { get; } = new();
}

internal sealed class ObjBaseAstChecks()
  : AstAbbreviatedChecks<string, ObjBaseAst>(CreateBase)
  , IObjBaseAstChecks
{
  private static ObjBaseAst CloneBase(ObjBaseAst original, string input)
    => original with { Name = input };
  internal static ObjBaseAst CreateBase(string input)
    => new(AstNulls.At, input, "");

  public void HashCode_WithIsTypeParam(string input)
      => HashCode(() => CreateBase(input) with { IsTypeParam = true });

  public void Text_WithIsTypeParam(string input)
    => Text(
      () => CreateBase(input) with { IsTypeParam = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParam(string input)
    => Equality(() => CreateBase(input) with { IsTypeParam = true });

  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => CreateBase(input) with { IsTypeParam = isTypeParam },
      false);

  public void HashCode_WithArgs(string input, string[] arguments)
    => HashCode(() => CreateBase(input) with { Args = arguments.TypeArgs() });

  public void Text_WithArgs(string input, string[] arguments)
    => Text(
      () => CreateBase(input) with { Args = arguments.TypeArgs() },
      $"( {input} < {arguments.Joined()} > )");

  public void Equality_WithArgs(string input, string[] arguments)
    => Equality(() => CreateBase(input) with { Args = arguments.TypeArgs() });

  public void Inequality_BetweenArgs(string input, string[] arguments1, string[] arguments2)
  => InequalityBetween(arguments1, arguments2,
    arguments => CreateBase(input) with { Args = arguments.TypeArgs() },
    arguments1.OrderedEqual(arguments2));

  public void FullType_WithDefault(string input)
  {
    ObjBaseAst objBase = CreateBase(input);

    objBase.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    IGqlpObjBase objBase = CreateBase(input) with { IsTypeParam = true };

    objBase.FullType.ShouldBe("$" + input);
  }

  public void FullType_WithArgs(string input, string[] arguments)
  {
    IGqlpObjBase objBase = CreateBase(input) with { Args = arguments.TypeArgs() };

    objBase.FullType.ShouldBe(input + $" < {arguments.Joined()} >");
  }

  public void FullType_WithIsTypeParamAndArgs(string input, string[] arguments)
  {
    IGqlpObjBase objBase = CreateBase(input) with {
      IsTypeParam = true,
      Args = arguments.TypeArgs(),
    };

    objBase.FullType.ShouldBe($"${input} < {arguments.Joined()} >");
  }

  protected override string InputString(string input)
    => $"( {input} )";
}

internal interface IObjBaseAstChecks
  : IAstAbbreviatedChecks<string>
{
  void HashCode_WithIsTypeParam(string input);
  void Text_WithIsTypeParam(string input);
  void Equality_WithIsTypeParam(string input);
  void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1);
  void HashCode_WithArgs(string input, string[] arguments);
  void Text_WithArgs(string input, string[] arguments);
  void Equality_WithArgs(string input, string[] arguments);
  void Inequality_BetweenArgs(string input, string[] arguments1, string[] arguments2);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParam(string input);
  void FullType_WithArgs(string input, string[] arguments);
  void FullType_WithIsTypeParamAndArgs(string input, string[] arguments);
}
