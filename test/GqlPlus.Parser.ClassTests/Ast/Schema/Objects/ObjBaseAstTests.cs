namespace GqlPlus.Ast.Schema.Objects;

public partial class ObjBaseAstTests
{
  [CheckTests(Inherited = true)]
  internal IObjBaseAstChecks BaseAstChecks { get; }
    = new ObjBaseAstChecks();

  [CheckTests]
  internal ICloneChecks<string> BaseAstCloneChecks { get; } = new CloneChecks<string, ObjBaseAst>(
    ObjBaseAstChecks.CreateBase,
    (original, input) => original with { Name = input });
}

internal sealed class ObjBaseAstChecks()
  : AstAbbreviatedChecks<string, ObjBaseAst>(CreateBase)
  , IObjBaseAstChecks
{
  internal static ObjBaseAst CreateBase(string input)
    => new(AstNulls.At, input, string.Empty);

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
    IAstObjBase objBase = CreateBase(input) with { IsTypeParam = true };

    objBase.FullType.ShouldBe("$" + input);
  }

  public void FullType_WithArgs(string input, string[] arguments)
  {
    IAstObjBase objBase = CreateBase(input) with { Args = arguments.TypeArgs() };

    objBase.FullType.ShouldBe(input + $" < {arguments.Joined()} >");
  }

  public void FullType_WithIsTypeParamAndArgs(string input, string[] arguments)
  {
    IAstObjBase objBase = CreateBase(input) with {
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
