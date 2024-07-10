using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputFieldTests(
  ICheckObjectField<IGqlpOutputField> checks
) : TestObjectField<IGqlpOutputField>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void WithParameters_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => checks.TrueExpected(
      name + "(" + parameters.Joined() + "):" + fieldType,
      Field(name, fieldType) with {
        Parameters = parameters.Parameters()
      });

  [Theory, RepeatData(Repeats)]
  public void WithParametersBad_ReturnsFalse(string name, string fieldType, string[] parameters)
    => checks.FalseExpected(name + "(" + parameters.Joined() + ":" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParametersModifiers_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => checks.TrueExpected(
      name + "(" + parameters.Joined(p => p + "[]?") + "):" + fieldType,
      Field(name, fieldType) with {
        Parameters = parameters.Parameters(p => p with { Modifiers = TestMods() })
      });

  [Theory, RepeatData(Repeats)]
  public void WithParameterModifiersBad_ReturnsFalse(string name, string fieldType, string parameter)
    => checks.FalseExpected(name + "(" + parameter + "[?):" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParameterConstantBad_ReturnsFalse(string name, string fieldType, string parameter)
    => checks.FalseExpected(name + "(" + parameter + "=):" + fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParametersDefault_ReturnsCorrectAst(string name, string fieldType, string[] parameters, string content)
    => checks.TrueExpected(
      name + "(" + parameters.Joined(p => p + "='" + content + "'") + "):" + fieldType,
      Field(name, fieldType) with {
        Parameters = parameters.Parameters(p => p with {
          DefaultValue = new(new FieldKeyAst(AstNulls.At, content))
        })
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumValue_ReturnsCorrectAst(string name, string enumMember)
    => checks.TrueExpected(
      name + "=" + enumMember,
        FieldEnum(name, "", enumMember));

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumAliasValue_ReturnsCorrectAst(string name, string enumMember, string alias)
    => checks.TrueExpected(
      name + "[" + alias + "]=" + enumMember,
        FieldEnum(name, "", enumMember) with { Aliases = [alias] });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumValueBad_ReturnsFalse(string name)
    => checks.FalseExpected(name + "=");

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumMember)
    => checks.TrueExpected(
      name + "=" + enumType + "." + enumMember,
        FieldEnum(name, enumType, enumMember));

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumAliasTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumMember, string alias)
    => checks.TrueExpected(
      name + "[" + alias + "]=" + enumType + "." + enumMember,
        FieldEnum(name, enumType, enumMember) with { Aliases = [alias] });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumTypeAndValueBad_ReturnsFalse(string name, string enumMember)
    => checks.FalseExpected(name + "=" + enumMember + ".");

  private static OutputFieldAst Field(string name, string enumType)
    => new(AstNulls.At, name, new OutputBaseAst(AstNulls.At, enumType));

  private static OutputFieldAst FieldEnum(string name, string enumType, string enumMember)
    => new(AstNulls.At, name, new OutputBaseAst(AstNulls.At, enumType) { EnumMember = enumMember });
}

internal sealed class ParseOutputFieldChecks(
  Parser<IGqlpOutputField>.D parser
) : CheckObjectField<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArgument, OutputArgumentAst>(new OutputFactories(), parser)
{ }
