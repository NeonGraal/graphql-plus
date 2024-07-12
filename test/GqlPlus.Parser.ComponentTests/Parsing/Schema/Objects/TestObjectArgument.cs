using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class TestObjectArgument<TObjArg>(
  ICheckObjectArgument<TObjArg> objectArgumentChecks
) where TObjArg : IGqlpObjArgument
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string name)
  => objectArgumentChecks.WithMinimum(name);

  [Theory, RepeatData(Repeats)]
  public void WithMany_ReturnsCorrectAsts(string[] names)
  => objectArgumentChecks.WithMany(names);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameter_ReturnsCorrectAst(string name)
  => objectArgumentChecks.WithTypeParameter(name);

  [Fact]
  public void WithTypeParameterBad_ReturnsFalse()
  => objectArgumentChecks.WithTypeParameterBad();
}

internal class CheckObjectArgument<TObjArg, TObjArgAst>(
  IObjectArgumentFactories<TObjArg, TObjArgAst> factories,
  Parser<TObjArg>.DA parser
) : ManyChecksParser<TObjArg>(parser)
  , ICheckObjectArgument<TObjArg>
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  private readonly IObjectArgumentFactories<TObjArg, TObjArgAst> _factories = factories;

  public void WithMinimum(string name)
    => TrueExpected("<" + name + ">", ObjArg(name));

  public void WithMany(string[] names)
    => TrueExpected("<" + names.Joined() + ">", [.. names.Select(ObjArg)]);

  public void WithTypeParameter(string name)
    => TrueExpected("<$" + name + ">", ObjArg(name) with { IsTypeParameter = true });

  public void WithTypeParameterBad()
    => FalseExpected("<$");

  public TObjArgAst ObjArg(string type)
    => _factories.ObjArgument(AstNulls.At, type);
}

public interface ICheckObjectArgument<TObjArg>
  : IManyChecksParser<TObjArg>
{
  void WithMinimum(string name);
  void WithMany(string[] names);
  void WithTypeParameter(string name);
  void WithTypeParameterBad();
}
