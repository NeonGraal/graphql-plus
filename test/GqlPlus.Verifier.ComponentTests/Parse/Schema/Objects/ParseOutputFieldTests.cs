using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

public class ParseOutputFieldTests(
  Parser<OutputFieldAst>.D parser
) : TestObjectField
{
  [Theory, RepeatData(Repeats)]
  public void WithParameters_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => _checks.TrueExpected(
      name + "(" + parameters.Joined() + "):" + fieldType,
      _checks.Field(name, fieldType) with {
        Parameters = parameters.Parameters()
      });

  [Theory, RepeatData(Repeats)]
  public void WithParametersBad_ReturnsFalse(string name, string fieldType, string[] parameters)
    => _checks.False(name + "(" + parameters.Joined() + ":" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParametersModifiers_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => _checks.TrueExpected(
      name + "(" + parameters.Joined(p => p + "[]?") + "):" + fieldType,
      _checks.Field(name, fieldType) with {
        Parameters = parameters.Parameters(p => p with { Modifiers = TestMods() })
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterModifiersBad_ReturnsFalse(string name, string fieldType, string parameter)
    => _checks.False(name + "(" + parameter + "[?):" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParameterConstantBad_ReturnsFalse(string name, string fieldType, string parameter)
    => _checks.False(name + "(" + parameter + "=):" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParametersDefault_ReturnsCorrectAst(string name, string fieldType, string[] parameters, string content)
    => _checks.TrueExpected(
      name + "(" + parameters.Joined(p => p + "='" + content + "'") + "):" + fieldType,
      _checks.Field(name, fieldType) with {
        Parameters = parameters.Parameters(p => p with {
          Default = new FieldKeyAst(AstNulls.At, content)
        })
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumValue_ReturnsCorrectAst(string name, string enumValue)
    => _checks.TrueExpected(
      name + "=" + enumValue,
        FieldEnum(name, "", enumValue));

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumAliasValue_ReturnsCorrectAst(string name, string enumValue, string alias)
    => _checks.TrueExpected(
      name + "[" + alias + "]=" + enumValue,
        FieldEnum(name, "", enumValue) with { Aliases = [alias] });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumValueBad_ReturnsFalse(string name)
    => _checks.False(name + "=");

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumValue)
    => _checks.TrueExpected(
      name + "=" + enumType + "." + enumValue,
        FieldEnum(name, enumType, enumValue));

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumAliasTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumValue, string alias)
    => _checks.TrueExpected(
      name + "[" + alias + "]=" + enumType + "." + enumValue,
        FieldEnum(name, enumType, enumValue) with { Aliases = [alias] });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumTypeAndValueBad_ReturnsFalse(string name, string enumValue)
    => _checks.False(name + "=" + enumValue + ".");

  internal override ICheckObjectField FieldChecks => _checks;

  private readonly CheckObjectField<OutputFieldAst, OutputReferenceAst> _checks = new(new OutputFactories(), parser);

  private static OutputFieldAst FieldEnum(string name, string enumType, string enumValue)
    => new(AstNulls.At, name, new(AstNulls.At, enumType) { EnumValue = enumValue });
}
