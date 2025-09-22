using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseObjBaseTests(
  IParseObjBaseChecks objectBaseChecks
)
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

internal sealed class ParseObjBaseChecks(
  Parser<IGqlpObjBase>.D parser
) : OneChecksParser<IGqlpObjBase>(parser)
  , IParseObjBaseChecks
{
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
        Args = [.. objBases.Select(ObjArg)]
      });

  public void WithTypeArgsBad(string name, string[] objBases)
    => FalseExpected(name + "<" + objBases.Joined());

  public void WithTypeArgsNone(string name)
    => FalseExpected(name + "<>");

  public static ObjBaseAst ObjBase(string type)
    => new(AstNulls.At, type, "");

  public static ObjArgAst ObjArg(string type)
    => new(AstNulls.At, type, "");
}

public interface IParseObjBaseChecks
  : IOneChecksParser<IGqlpObjBase>
{
  void WithMinimum(string name);
  void WithTypeParam(string name);
  void WithTypeParamBad();
  void WithTypeArgs(string name, string[] objBases);
  void WithTypeArgsBad(string name, string[] objBases);
  void WithTypeArgsNone(string name);
}
