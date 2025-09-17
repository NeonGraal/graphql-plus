using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectBaseTests<TObjBase>
  : AstAbbreviatedTests<string>
  where TObjBase : IGqlpObjBase
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

  internal abstract IAstObjBaseChecks<TObjBase> ObjBaseChecks { get; }
}

internal sealed class AstObjBaseChecks<TObjBase, TObjBaseAst, TObjArgAst>(
AstObjBaseChecks<TObjBase, TObjBaseAst, TObjArgAst>.BaseBy createBase,
AstObjBaseChecks<TObjBase, TObjBaseAst, TObjArgAst>.ArgsBy createArgs
) : AstAbbreviatedChecks<string, TObjBase>(input => createBase(input))
  , IAstObjBaseChecks<TObjBase>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase, TObjBase
  where TObjArgAst : AstObjArg
{
  private readonly BaseBy _createBase = createBase;
  private readonly ArgsBy _createArgs = createArgs;

  internal delegate TObjBaseAst BaseBy(string input);
  internal delegate IGqlpObjArg[] ArgsBy(string[] argument);

  public void HashCode_WithIsTypeParam(string input)
      => HashCode(() => _createBase(input) with { IsTypeParam = true });

  public void String_WithIsTypeParam(string input)
    => Text(
      () => _createBase(input) with { IsTypeParam = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParam(string input)
    => Equality(() => _createBase(input) with { IsTypeParam = true });

  public void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => _createBase(input) with { IsTypeParam = isTypeParam },
      false);

  public void HashCode_WithArgs(string input, string[] arguments)
    => HashCode(() => _createBase(input) with { Args = _createArgs(arguments) });

  public void String_WithArgs(string input, string[] arguments)
    => Text(
      () => _createBase(input) with { Args = _createArgs(arguments) },
      $"( {input} < {arguments.Joined()} > )");

  public void Equality_WithArgs(string input, string[] arguments)
    => Equality(() => _createBase(input) with { Args = _createArgs(arguments) });

  public void Inequality_BetweenArgs(string input, string[] arguments1, string[] arguments2)
  => InequalityBetween(arguments1, arguments2,
    arguments => _createBase(input) with { Args = _createArgs(arguments) },
    arguments1.OrderedEqual(arguments2));

  public void String_ForDual(string input, string[] arguments)
  {
    TObjBaseAst theBase = _createBase(input) with { Args = _createArgs(arguments) };
    if (theBase is not IGqlpToDual<IGqlpDualBase> objDual) {
      return;
    }

    IGqlpDualBase dual = objDual.ToDual;

    string result = $"{dual}";

    result.ShouldBe($"( {input} < {arguments.Joined()} > )", "CreateInput(input).ToDual");
  }

  public void FullType_WithDefault(string input)
  {
    TObjBase objBase = _createBase(input);

    objBase.FullType.ShouldBe(input);
  }

  public void FullType_WithIsTypeParam(string input)
  {
    TObjBase objBase = _createBase(input) with { IsTypeParam = true };

    objBase.FullType.ShouldBe("$" + input);
  }

  public void FullType_WithArgs(string input, string[] arguments)
  {
    TObjBase objBase = _createBase(input) with { Args = _createArgs(arguments) };

    objBase.FullType.ShouldBe(input + $" < {arguments.Joined()} >");
  }

  public void FullType_WithIsTypeParamAndArgs(string input, string[] arguments)
  {
    TObjBase objBase = _createBase(input) with {
      IsTypeParam = true,
      Args = _createArgs(arguments)
    };

    objBase.FullType.ShouldBe($"${input} < {arguments.Joined()} >");
  }
}

internal interface IAstObjBaseChecks<TObjBase>
  : IAstAbbreviatedChecks<string>
  where TObjBase : IGqlpObjBase
{
  void HashCode_WithIsTypeParam(string input);
  void String_WithIsTypeParam(string input);
  void Equality_WithIsTypeParam(string input);
  void Inequality_BetweenIsTypeParams(string input, bool isTypeParam1);
  void HashCode_WithArgs(string input, string[] arguments);
  void String_WithArgs(string input, string[] arguments);
  void Equality_WithArgs(string input, string[] arguments);
  void Inequality_BetweenArgs(string input, string[] arguments1, string[] arguments2);
  void String_ForDual(string input, string[] arguments);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParam(string input);
  void FullType_WithArgs(string input, string[] arguments);
  void FullType_WithIsTypeParamAndArgs(string input, string[] arguments);
}
