using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

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
  public void FullType_WithDefault(string input)
    => ObjArgChecks.FullType_WithDefault(input);

  [Theory, RepeatData]
  public void FullType_WithIsTypeParam(string input)
    => ObjArgChecks.FullType_WithIsTypeParam(input);

  internal sealed override IAstAbbreviatedChecks<string> AbbreviatedChecks => ObjArgChecks;

  internal abstract IAstObjArgChecks<TObjArg> ObjArgChecks { get; }
}

internal sealed class AstObjArgChecks<TObjArg, TObjArgAst>(
  AstObjArgChecks<TObjArg, TObjArgAst>.ArgBy createArg
) : AstAbbreviatedChecks<string, TObjArg>(input => createArg(input))
  , IAstObjArgChecks<TObjArg>
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
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
  void FullType_WithDefault(string input);
  void FullType_WithIsTypeParam(string input);
}
