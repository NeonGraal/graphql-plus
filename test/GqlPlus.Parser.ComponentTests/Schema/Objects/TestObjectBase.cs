using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public abstract class TestObjectBase<TObjBase>(
  ICheckObjectBase<TObjBase> objectBaseChecks
) where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => objectBaseChecks.WithMinimum(name);

  [Theory, RepeatData]
  public void WithTypeParam_ReturnsCorrectAst(string name)
  => objectBaseChecks.WithTypeParam(name);

  [Fact]
  public void WithTypeParamBad_ReturnsFalse()
  => objectBaseChecks.WithTypeParamBad();

  [Theory]
  [RepeatInlineData(Repeats, "Boolean")]
  [RepeatInlineData(Repeats, "Number")]
  [RepeatInlineData(Repeats, "String")]
  [RepeatInlineData(Repeats, "^")]
  [RepeatInlineData(Repeats, "0")]
  [RepeatInlineData(Repeats, "*")]
  public void WithSimpleArgs_ReturnsCorrectAst(string argument, string name)
  => objectBaseChecks.WithTypeArgs(name, [argument]);

  [Theory, RepeatData]
  public void WithTypeArgs_ReturnsCorrectAst(string name, string[] objBases)
  => objectBaseChecks.WithTypeArgs(name, objBases);

  [Theory, RepeatData]
  public void WithTypeArgsBad_ReturnsCorrectAst(string name, string[] objBases)
  => objectBaseChecks.WithTypeArgsBad(name, objBases);

  [Theory, RepeatData]
  public void WithTypeArgsNone_ReturnsFalse(string name)
  => objectBaseChecks.WithTypeArgsNone(name);
}

internal class CheckObjectBase<TObjBase, TObjBaseAst, TObjArg, TObjArgAst>(
  IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArg, TObjArgAst> factories,
  Parser<TObjBase>.D parser
) : OneChecksParser<TObjBase>(parser)
  , ICheckObjectBase<TObjBase>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  private readonly IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArg, TObjArgAst> _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected(name, ObjBase(name));

  public void WithTypeParam(string name)
    => TrueExpected("$" + name, ObjBase(name) with { IsTypeParam = true });

  public void WithTypeParamBad()
    => FalseExpected("$");

  public void WithTypeArgs(string name, string[] objBases)
    => TrueExpected(
      name + "<" + objBases.Joined() + ">",
      ObjBase(name) with {
        BaseArgs = [.. objBases.Select(ObjArg)]
      });

  public void WithTypeArgsBad(string name, string[] objBases)
    => FalseExpected(name + "<" + objBases.Joined());

  public void WithTypeArgsNone(string name)
    => FalseExpected(name + "<>");

  public TObjBaseAst ObjBase(string type)
    => _factories.ObjBase(AstNulls.At, type);

  public TObjArgAst ObjArg(string type)
    => _factories.ObjArg(AstNulls.At, type);
}

public interface ICheckObjectBase<TObjBase>
  : IOneChecksParser<TObjBase>
  where TObjBase : IGqlpObjBase
{
  void WithMinimum(string name);
  void WithTypeParam(string name);
  void WithTypeParamBad();
  void WithTypeArgs(string name, string[] objBases);
  void WithTypeArgsBad(string name, string[] objBases);
  void WithTypeArgsNone(string name);
}
