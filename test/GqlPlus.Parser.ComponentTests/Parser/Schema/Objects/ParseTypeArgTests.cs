using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseTypeArgTests(
  IParseTypeArgChecks objectArgChecks
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

internal sealed class ParseTypeArgChecks(
  Parser<IGqlpTypeArg>.DA parser
) : ManyChecksParser<IGqlpTypeArg>(parser)
  , IParseTypeArgChecks
{
  public void WithMinimum(string name)
    => TrueExpected("<" + name + ">", TypeArg(name));

  public void WithMany(string[] names)
    => TrueExpected("<" + names.Joined() + ">", [.. names.Select(TypeArg)]);

  public void WithTypeParam(string name)
    => TrueExpected("<$" + name + ">", TypeArg(name) with { IsTypeParam = true });

  public void WithTypeParamBad()
    => FalseExpected("<$");

  public TypeArgAst TypeArg(string type)
    => new(AstNulls.At, type, "");
}

public interface IParseTypeArgChecks
  : IManyChecksParser<IGqlpTypeArg>
{
  void WithMinimum(string name);
  void WithMany(string[] names);
  void WithTypeParam(string name);
  void WithTypeParamBad();
}
