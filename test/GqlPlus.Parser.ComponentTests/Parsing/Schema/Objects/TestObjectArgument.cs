using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class TestObjectArg<TObjArg>(
  ICheckObjectArg<TObjArg> objectArgChecks
) where TObjArg : IGqlpObjArg
{
  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => objectArgChecks.WithMinimum(name);

  [Theory, RepeatData]
  public void WithMany_ReturnsCorrectAsts(string[] names)
  => objectArgChecks.WithMany(names);

  [Theory, RepeatData]
  public void WithTypeParam_ReturnsCorrectAst(string name)
  => objectArgChecks.WithTypeParam(name);

  [Fact]
  public void WithTypeParamBad_ReturnsFalse()
  => objectArgChecks.WithTypeParamBad();
}

internal class CheckObjectArg<TObjArg, TObjArgAst>(
  IObjectArgFactories<TObjArg, TObjArgAst> factories,
  Parser<TObjArg>.DA parser
) : ManyChecksParser<TObjArg>(parser)
  , ICheckObjectArg<TObjArg>
  where TObjArg : IGqlpObjArg
  where TObjArgAst : AstObjArg, TObjArg
{
  private readonly IObjectArgFactories<TObjArg, TObjArgAst> _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected("<" + name + ">", ObjArg(name));

  public void WithMany(string[] names)
    => TrueExpected("<" + names.Joined() + ">", [.. names.Select(ObjArg)]);

  public void WithTypeParam(string name)
    => TrueExpected("<$" + name + ">", ObjArg(name) with { IsTypeParam = true });

  public void WithTypeParamBad()
    => FalseExpected("<$");

  public TObjArgAst ObjArg(string type)
    => _factories.ObjArg(AstNulls.At, type);
}

public interface ICheckObjectArg<TObjArg>
  : IManyChecksParser<TObjArg>
{
  void WithMinimum(string name);
  void WithMany(string[] names);
  void WithTypeParam(string name);
  void WithTypeParamBad();
}
