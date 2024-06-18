using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputFieldTests(
  Parser<IGqlpOutputField>.D parser
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
          DefaultValue = new FieldKeyAst(AstNulls.At, content)
        })
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumValue_ReturnsCorrectAst(string name, string enumMember)
    => _checks.TrueExpected(
      name + "=" + enumMember,
        FieldEnum(name, "", enumMember));

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumAliasValue_ReturnsCorrectAst(string name, string enumMember, string alias)
    => _checks.TrueExpected(
      name + "[" + alias + "]=" + enumMember,
        FieldEnum(name, "", enumMember) with { Aliases = [alias] });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumValueBad_ReturnsFalse(string name)
    => _checks.False(name + "=");

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumMember)
    => _checks.TrueExpected(
      name + "=" + enumType + "." + enumMember,
        FieldEnum(name, enumType, enumMember));

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumAliasTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumMember, string alias)
    => _checks.TrueExpected(
      name + "[" + alias + "]=" + enumType + "." + enumMember,
        FieldEnum(name, enumType, enumMember) with { Aliases = [alias] });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumTypeAndValueBad_ReturnsFalse(string name, string enumMember)
    => _checks.False(name + "=" + enumMember + ".");

  internal override ICheckObjectField FieldChecks => _checks;

  private readonly CheckObjectField<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase, OutputBaseAst> _checks = new(new OutputFactories(), parser);

  private static OutputFieldAst FieldEnum(string name, string enumType, string enumMember)
    => new(AstNulls.At, name, new OutputBaseAst(AstNulls.At, enumType) { EnumMember = enumMember });
}
