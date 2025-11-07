using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class ObjBaseAstTests
  : AstAbbreviatedTests<string>
{
  [Theory, RepeatData]
  public void HashCode_WithIsTypeParam(string input)
      => ObjBaseChecks.HashCode_WithIsTypeParam(input);

  [Theory, RepeatData]
  public void String_WithIsTypeParam(string input)
    => ObjBaseChecks.String_WithIsTypeParam(input);

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
  public void String_WithArgs(string input, string[] arguments)
    => ObjBaseChecks.String_WithArgs(input, arguments);

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

internal sealed class ObjBaseAstChecks
  : AstAbbreviatedChecks<string, ObjBaseAst>
  , IObjBaseAstChecks
{
  public ObjBaseAstChecks()
    : base(BaseBy, (original, input) => original with { Name = input })
  { }

  internal static ObjBaseAst BaseBy(string input)
    => new(AstNulls.At, input, "");

  public void HashCode_WithIsTypeParam(string input)
      => HashCode(() => BaseBy(input) with { IsTypeParam = true });

  public void String_WithIsTypeParam(string input)
    => Text(
      () => BaseBy(input) with { IsTypeParam = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParam(string input)
    => Equality(() => BaseBy(input) with { IsTypeParam = true });

  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => BaseBy(input) with { IsTypeParam = isTypeParam },
      false);

  public void HashCode_WithArgs(string input, string[] arguments)
    => HashCode(() => BaseBy(input) with { Args = arguments.TypeArgs() });

  public void String_WithArgs(string input, string[] arguments)
    => Text(
      () => BaseBy(input) with { Args = arguments.TypeArgs() },
      $"( {input} < {arguments.Joined()} > )");

  public void Equality_WithArgs(string input, string[] arguments)
    => Equality(() => BaseBy(input) with { Args = arguments.TypeArgs() });

  public void Inequality_BetweenArgs(string input, string[] arguments1, string[] arguments2)
  => InequalityBetween(arguments1, arguments2,
    arguments => BaseBy(input) with { Args = arguments.TypeArgs() },
    arguments1.OrderedEqual(arguments2));

  public void FullType_WithDefault(string input)
  {
    ObjBaseAst objBase = BaseBy(input);

    objBase.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    IGqlpObjBase objBase = BaseBy(input) with { IsTypeParam = true };

    objBase.FullType.ShouldBe("$" + input);
  }

  public void FullType_WithArgs(string input, string[] arguments)
  {
    IGqlpObjBase objBase = BaseBy(input) with { Args = arguments.TypeArgs() };

    objBase.FullType.ShouldBe(input + $" < {arguments.Joined()} >");
  }

  public void FullType_WithIsTypeParamAndArgs(string input, string[] arguments)
  {
    IGqlpObjBase objBase = BaseBy(input) with {
      IsTypeParam = true,
      Args = arguments.TypeArgs(),
    };

    objBase.FullType.ShouldBe($"${input} < {arguments.Joined()} >");
  }
}

internal interface IObjBaseAstChecks
  : IAstAbbreviatedChecks<string>
{
  void HashCode_WithIsTypeParam(string input);
  void String_WithIsTypeParam(string input);
  void Equality_WithIsTypeParam(string input);
  void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1);
  void HashCode_WithArgs(string input, string[] arguments);
  void String_WithArgs(string input, string[] arguments);
  void Equality_WithArgs(string input, string[] arguments);
  void Inequality_BetweenArgs(string input, string[] arguments1, string[] arguments2);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParam(string input);
  void FullType_WithArgs(string input, string[] arguments);
  void FullType_WithIsTypeParamAndArgs(string input, string[] arguments);
}
