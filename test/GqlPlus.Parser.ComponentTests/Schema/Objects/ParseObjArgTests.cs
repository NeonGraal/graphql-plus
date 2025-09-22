using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;

namespace GqlPlus.Schema.Objects;

public class ParseObjArgTests(
  IParseObjArgChecks objectArgChecks
)
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

  //[Theory, RepeatData]
  //public void WithArgEnumValues_ReturnsCorrectAst(string enumType, string[] enumValues)
  //  => checks.TrueExpected(
  //    "<" + enumValues.Joined(s => enumType + "." + s) + ">",
  //    [.. enumValues.Select(enumLabel
  //      => new OutputArgAst(AstNulls.At, enumType) { EnumLabel = enumLabel })]);

  //[Theory, RepeatData]
  //public void WithArgEnumValueBad_ReturnsFalse(string enumType)
  //  => checks.FalseExpected("<" + enumType + ".");
}

internal sealed class ParseObjArgChecks(
  Parser<IGqlpObjArg>.DA parser
) : ManyChecksParser<IGqlpObjArg>(parser)
  , IParseObjArgChecks
{
  public void WithMinimum(string name)
    => TrueExpected("<" + name + ">", ObjArg(name));

  public void WithMany(string[] names)
    => TrueExpected("<" + names.Joined() + ">", [.. names.Select(ObjArg)]);

  public void WithTypeParam(string name)
    => TrueExpected("<$" + name + ">", ObjArg(name) with { IsTypeParam = true });

  public void WithTypeParamBad()
    => FalseExpected("<$");

  public ObjArgAst ObjArg(string type)
    => new(AstNulls.At, type, "");
}

public interface IParseObjArgChecks
  : IManyChecksParser<IGqlpObjArg>
{
  void WithMinimum(string name);
  void WithMany(string[] names);
  void WithTypeParam(string name);
  void WithTypeParamBad();
}
