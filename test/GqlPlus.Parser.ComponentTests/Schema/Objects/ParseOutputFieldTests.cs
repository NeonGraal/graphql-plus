using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public class ParseOutputFieldTests(
  ICheckObjectField<IGqlpOutputField> checks
) : TestObjectField<IGqlpOutputField>(checks)
{
  [Theory, RepeatData]
  public void WithParams_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => checks.TrueExpected(
      name + "(" + parameters.Joined() + "):" + fieldType,
      Field(name, FieldBase(fieldType)) with {
        Params = parameters.Params()
      });

  [Theory, RepeatData]
  public void WithParamsBad_ReturnsFalse(string name, string fieldType, string[] parameters)
    => checks.FalseExpected(name + "(" + parameters.Joined() + ":" + fieldType);

  [Theory, RepeatData]
  public void WithParamsModifiers_ReturnsCorrectAst(string name, string fieldType, string[] parameters)
    => checks.TrueExpected(
      name + "(" + parameters.Joined(p => p + "[]?") + "):" + fieldType,
      Field(name, FieldBase(fieldType)) with {
        Params = parameters.Params(p => p with { Modifiers = TestMods() })
      });

  [Theory, RepeatData]
  public void WithParamModifiersBad_ReturnsFalse(string name, string fieldType, string parameter)
    => checks.FalseExpected(name + "(" + parameter + "[?):" + fieldType);

  [Theory, RepeatData]
  public void WithParamConstantBad_ReturnsFalse(string name, string fieldType, string parameter)
    => checks.FalseExpected(name + "(" + parameter + "=):" + fieldType);

  [Theory, RepeatData]
  public void WithParamsDefault_ReturnsCorrectAst(string name, string fieldType, string[] parameters, string content)
    => checks.TrueExpected(
      name + "(" + parameters.Joined(p => p + "='" + content + "'") + "):" + fieldType,
      Field(name, FieldBase(fieldType)) with {
        Params = parameters.Params(p => p with {
          DefaultValue = new(new FieldKeyAst(AstNulls.At, content))
        })
      });

  [Theory, RepeatData]
  public void WithFieldEnumValue_ReturnsCorrectAst(string name, string enumLabel)
    => checks.TrueExpected(
      name + "=" + enumLabel,
        Field(name, FieldBase("") with { EnumLabel = enumLabel }));

  [Theory, RepeatData]
  public void WithFieldEnumAliasValue_ReturnsCorrectAst(string name, string enumLabel, string alias)
    => checks.TrueExpected(
      name + "[" + alias + "]=" + enumLabel,
        Field(name, FieldBase("") with { EnumLabel = enumLabel }) with { Aliases = [alias] });

  [Theory, RepeatData]
  public void WithFieldEnumValueBad_ReturnsFalse(string name)
    => checks.FalseExpected(name + "=");

  [Theory, RepeatData]
  public void WithFieldEnumTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumLabel)
    => checks.TrueExpected(
      name + "=" + enumType + "." + enumLabel,
        Field(name, FieldBase(enumType) with { EnumLabel = enumLabel }));

  [Theory, RepeatData]
  public void WithFieldEnumAliasTypeAndValue_ReturnsCorrectAst(string name, string enumType, string enumLabel, string alias)
    => checks.TrueExpected(
      name + "[" + alias + "]=" + enumType + "." + enumLabel,
        Field(name, FieldBase(enumType) with { EnumLabel = enumLabel }) with { Aliases = [alias] });

  [Theory, RepeatData]
  public void WithFieldEnumTypeAndValueBad_ReturnsFalse(string name, string enumLabel)
    => checks.FalseExpected(name + "=" + enumLabel + ".");

  private static OutputFieldAst Field(string name, OutputBaseAst enumType)
    => new(AstNulls.At, name, enumType);

  private static OutputBaseAst FieldBase(string enumType)
    => new(AstNulls.At, enumType);
}

internal sealed class ParseOutputFieldChecks(
  Parser<IGqlpOutputField>.D parser
) : CheckObjectField<IGqlpOutputField, OutputFieldAst, IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg, OutputArgAst>(new OutputFactories(), parser)
{ }
