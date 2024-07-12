using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class TestObjectBase<TObjBase>(
  ICheckObjectBase<TObjBase> objectBaseChecks
) where TObjBase : IGqlpObjBase
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => objectBaseChecks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => objectBaseChecks.WithTypeParameter(name);

  [Fact]
  public void WithTypeParameterBad_ReturnsFalse()
  => objectBaseChecks.WithTypeParameterBad();

  [Theory]
  [RepeatInlineData(Repeats, "Boolean")]
  [RepeatInlineData(Repeats, "Number")]
  [RepeatInlineData(Repeats, "String")]
  [RepeatInlineData(Repeats, "^")]
  [RepeatInlineData(Repeats, "0")]
  [RepeatInlineData(Repeats, "*")]
  public void WithSimpleArguments_ReturnsCorrectAst(string argument, string name)
  => objectBaseChecks.WithTypeArguments(name, [argument]);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArguments_ReturnsCorrectAst(string name, string[] objBases)
  => objectBaseChecks.WithTypeArguments(name, objBases);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsBad_ReturnsCorrectAst(string name, string[] objBases)
  => objectBaseChecks.WithTypeArgumentsBad(name, objBases);

  [Theory, RepeatData(Repeats)]
  public void WithTypeArgumentsNone_ReturnsFalse(string name)
  => objectBaseChecks.WithTypeArgumentsNone(name);
}

internal class CheckObjectBase<TObjBase, TObjBaseAst, TObjArg, TObjArgAst>(
  IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArg, TObjArgAst> factories,
  Parser<TObjBase>.D parser
) : OneChecksParser<TObjBase>(parser)
  , ICheckObjectBase<TObjBase>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  private readonly IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArg, TObjArgAst> _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected(name, ObjBase(name));

  public void WithTypeParameter(string name)
    => TrueExpected("$" + name, ObjBase(name) with { IsTypeParameter = true });

  public void WithTypeParameterBad()
    => FalseExpected("$");

  public void WithTypeArguments(string name, string[] objBases)
    => TrueExpected(
      name + "<" + objBases.Joined() + ">",
      ObjBase(name) with {
        BaseArguments = [.. objBases.Select(ObjArg)]
      });

  public void WithTypeArgumentsBad(string name, string[] objBases)
    => FalseExpected(name + "<" + objBases.Joined());

  public void WithTypeArgumentsNone(string name)
    => FalseExpected(name + "<>");

  public TObjBaseAst ObjBase(string type)
    => _factories.ObjBase(AstNulls.At, type);

  public TObjArgAst ObjArg(string type)
    => _factories.ObjArgument(AstNulls.At, type);
}

public interface ICheckObjectBase<TObjBase>
  : IOneChecksParser<TObjBase>
  where TObjBase : IGqlpObjBase
{
  void WithMinimum(string name);
  void WithTypeParameter(string name);
  void WithTypeParameterBad();
  void WithTypeArguments(string name, string[] objBases);
  void WithTypeArgumentsBad(string name, string[] objBases);
  void WithTypeArgumentsNone(string name);
}
