using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputFieldTests : BaseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithParameter_ReturnsCorrectAst(string name, string fieldType, string parameter)
    => Test.TrueExpected(
      name + "(" + parameter + "):" + fieldType,
      Test.Field(name, fieldType) with {
        Parameter = new(AstNulls.At, parameter)
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterBad_ReturnsFalse(string name, string fieldType, string parameter)
    => Test.False(name + "(" + parameter + ":" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParameterModifiers_ReturnsCorrectAst(string name, string fieldType, string parameter)
    => Test.TrueExpected(
      name + "(" + parameter + "[]?):" + fieldType,
      Test.Field(name, fieldType) with {
        Parameter = new ParameterAst(AstNulls.At, parameter) with { Modifiers = TestMods() }
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterModifiersBad_ReturnsFalse(string name, string fieldType, string parameter)
    => Test.False(name + "(" + parameter + "[?):" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParameterDefault_ReturnsCorrectAst(string name, string fieldType, string parameter, string content)
    => Test.TrueExpected(
      name + "(" + parameter + "='" + content + "'):" + fieldType,
      Test.Field(name, fieldType) with {
        Parameter = new ParameterAst(AstNulls.At, parameter) with {
          Default = new FieldKeyAst(AstNulls.At, content)
        }
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldLabel_ReturnsCorrectAst(string name, string label)
    => Test.TrueExpected(
      name + "=" + label,
        Test.Field(name, "") with { Label = label });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumLabel_ReturnsCorrectAst(string name, string enumType, string label)
    => Test.TrueExpected(
      name + "=" + enumType + "." + label,
        Test.Field(name, enumType) with { Label = label });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumLabelBad_ReturnsFalse(string name, string label)
    => Test.False(name + "=." + label);

  internal override IBaseFieldChecks Checks => Test;

  private static BaseFieldChecks<OutputFieldAst, OutputReferenceAst> Test => new(
    new OutputFactories(),
    (SchemaParser parser, out OutputFieldAst? result) => parser.ParseField(new OutputParserFactories(parser)).Required(out result));
}
