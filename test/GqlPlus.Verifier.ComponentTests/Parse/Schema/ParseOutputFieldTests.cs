using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputFieldTests : BaseFieldTests
{
  [Theory, RepeatData(Repeats)]
  public void WithParameters_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => _test.TrueExpected(
      name + "(" + parameters.Joined() + "):" + fieldType,
      _test.Field(name, fieldType) with {
        Parameters = parameters.Parameters()
      });

  [Theory, RepeatData(Repeats)]
  public void WithParametersBad_ReturnsFalse(string name, string fieldType, string[] parameters)
    => _test.False(name + "(" + parameters.Joined() + ":" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParametersModifiers_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => _test.TrueExpected(
      name + "(" + parameters.Joined(p => p + "[]?") + "):" + fieldType,
      _test.Field(name, fieldType) with {
        Parameters = parameters.Parameters(p => p with { Modifiers = TestMods() })
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterModifiersBad_ReturnsFalse(string name, string fieldType, string parameter)
    => _test.False(name + "(" + parameter + "[?):" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParameterConstantBad_ReturnsFalse(string name, string fieldType, string parameter)
    => _test.False(name + "(" + parameter + "=):" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParametersDefault_ReturnsCorrectAst(string name, string fieldType, string[] parameters, string content)
    => _test.TrueExpected(
      name + "(" + parameters.Joined(p => p + "='" + content + "'") + "):" + fieldType,
      _test.Field(name, fieldType) with {
        Parameters = parameters.Parameters(p => p with {
          Default = new FieldKeyAst(AstNulls.At, content)
        })
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldLabel_ReturnsCorrectAst(string name, string label)
    => _test.TrueExpected(
      name + "=" + label,
        _test.Field(name, "") with { Label = label });

  [Theory, RepeatData(Repeats)]
  public void WithFieldLabelBad_ReturnsFalse(string name)
    => _test.False(name + "=");

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumLabel_ReturnsCorrectAst(string name, string enumType, string label)
    => _test.TrueExpected(
      name + "=" + enumType + "." + label,
        _test.Field(name, enumType) with { Label = label });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumLabelBad_ReturnsFalse(string name, string label)
    => _test.False(name + "=" + label + ".");

  internal override IBaseFieldChecks Checks => _test;

  private readonly BaseFieldParserChecks<OutputFieldAst, OutputReferenceAst> _test;

  public ParseOutputFieldTests(Parser<OutputFieldAst>.D parser)
    => _test = new(new OutputFactories(), parser);
}
