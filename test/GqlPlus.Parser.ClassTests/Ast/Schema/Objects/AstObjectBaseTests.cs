using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectBaseTests<TObjBase, TObjBaseAst>
  : AstAbbreviatedTests<string>
  where TObjBase : IGqlpObjBase<TObjBase>
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithIsTypeParameter(string input)
      => ObjBaseChecks.HashCode_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void String_WithIsTypeParameter(string input)
    => ObjBaseChecks.String_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithIsTypeParameter(string input)
    => ObjBaseChecks.Equality_WithIsTypeParameter(input);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => ObjBaseChecks.Inequality_BetweenIsTypeParameters(input, isTypeParam1);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArguments(string input, string[] arguments)
    => ObjBaseChecks.HashCode_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void String_WithArguments(string input, string[] arguments)
    => ObjBaseChecks.String_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArguments(string input, string[] arguments)
    => ObjBaseChecks.Equality_WithArguments(input, arguments);

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenArguments(string input, string[] arguments1, string[] arguments2)
    => ObjBaseChecks.Inequality_BetweenArguments(input, arguments1, arguments2);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithDefault(string input)
    => ObjBaseChecks.FullType_WithDefault(input);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithIsTypeParameter(string input)
    => ObjBaseChecks.FullType_WithIsTypeParameter(input);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithArguments(string input, string[] arguments)
    => ObjBaseChecks.FullType_WithArguments(input, arguments);

  [Theory, RepeatData(Repeats)]
  public void FullType_WithIsTypeParameterAndArguments(string input, string[] arguments)
    => ObjBaseChecks.FullType_WithIsTypeParameterAndArguments(input, arguments);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ObjBaseChecks;

  internal abstract IAstObjBaseChecks<TObjBase, TObjBaseAst> ObjBaseChecks { get; }
}

internal sealed class AstObjBaseChecks<TObjBase, TObjBaseAst>
  : AstAbbreviatedChecks<string, TObjBase>
  , IAstObjBaseChecks<TObjBase, TObjBaseAst>
  where TObjBase : IGqlpObjBase<TObjBase>
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  private readonly BaseBy _createBase;
  private readonly ArgumentsBy _createArguments;

  internal delegate TObjBaseAst BaseBy(string input);
  internal delegate TObjBase[] ArgumentsBy(string[] argument);

  public AstObjBaseChecks(BaseBy createBase, AstObjBaseChecks<TObjBase, TObjBaseAst>.ArgumentsBy createArguments)
    : base(input => createBase(input))
  {
    _createBase = createBase;
    _createArguments = createArguments;
  }

  public void HashCode_WithIsTypeParameter(string input)
      => HashCode(() => _createBase(input) with { IsTypeParameter = true });

  public void String_WithIsTypeParameter(string input)
    => Text(
      () => _createBase(input) with { IsTypeParameter = true },
      $"( ${input} )");

  public void Equality_WithIsTypeParameter(string input)
    => Equality(() => _createBase(input) with { IsTypeParameter = true });

  public void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1)
    => InequalityBetween(isTypeParam1, !isTypeParam1,
      isTypeParam => _createBase(input) with { IsTypeParameter = isTypeParam },
      false);

  public void HashCode_WithArguments(string input, string[] arguments)
    => HashCode(() => _createBase(input) with { TypeArguments = _createArguments(arguments) });

  public void String_WithArguments(string input, string[] arguments)
    => Text(
      () => _createBase(input) with { TypeArguments = _createArguments(arguments) },
      $"( {input} < {arguments.Joined()} > )");

  public void Equality_WithArguments(string input, string[] arguments)
    => Equality(() => _createBase(input) with { TypeArguments = _createArguments(arguments) });

  public void Inequality_BetweenArguments(string input, string[] arguments1, string[] arguments2)
  => InequalityBetween(arguments1, arguments2,
    arguments => _createBase(input) with { TypeArguments = _createArguments(arguments) },
    arguments1.OrderedEqual(arguments2));

  public void FullType_WithDefault(string input)
  {
    TObjBase objBase = _createBase(input);

    objBase.FullType.Should().Be(input);
  }

  public void FullType_WithIsTypeParameter(string input)
  {
    TObjBase objBase = _createBase(input) with { IsTypeParameter = true };

    objBase.FullType.Should().Be("$" + input);
  }

  public void FullType_WithArguments(string input, string[] arguments)
  {
    TObjBase objBase = _createBase(input) with { TypeArguments = _createArguments(arguments) };

    objBase.FullType.Should().Be(input + $" < {arguments.Joined()} >");
  }

  public void FullType_WithIsTypeParameterAndArguments(string input, string[] arguments)
  {
    TObjBase objBase = _createBase(input) with {
      IsTypeParameter = true,
      TypeArguments = _createArguments(arguments)
    };

    objBase.FullType.Should().Be($"${input} < {arguments.Joined()} >");
  }
}

internal interface IAstObjBaseChecks<TObjBase, TObjBaseAst>
  : IAstAbbreviatedChecks<string>
  where TObjBase : IGqlpObjBase<TObjBase>
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  void HashCode_WithIsTypeParameter(string input);
  void String_WithIsTypeParameter(string input);
  void Equality_WithIsTypeParameter(string input);
  void Inequality_BetweenIsTypeParameters(string input, bool isTypeParam1);
  void HashCode_WithArguments(string input, string[] arguments);
  void String_WithArguments(string input, string[] arguments);
  void Equality_WithArguments(string input, string[] arguments);
  void Inequality_BetweenArguments(string input, string[] arguments1, string[] arguments2);
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParameter(string input);
  void FullType_WithArguments(string input, string[] arguments);
  void FullType_WithIsTypeParameterAndArguments(string input, string[] arguments);
}
