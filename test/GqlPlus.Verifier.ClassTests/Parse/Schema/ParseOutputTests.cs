using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class ParseOutputTests : BaseObjectTests
{
  [Theory, RepeatData(Repeats)]
  public void WithExtendsGenericEnumLabelField_ReturnsCorrectAst(string name, string extends, string enumType, string label, string field, string fieldType)
    => Test.TrueExpected(
      name + "=" + extends + "<" + enumType + "." + label + ">{" + field + ":" + fieldType + "}",
      Test.Object(name) with {
        Extends = Test.Reference(extends) with {
          Arguments = new[] { Test.Reference(enumType) with { Label = label } }
        },
        Fields = new[] { Test.Field(field, fieldType) },
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldParameter_ReturnsCorrectAst(string name, string field, string parameter, string fieldType)
    => Test.TrueExpected(
      name + "={" + field + "(" + parameter + "):" + fieldType + "}",
      Test.Object(name) with {
        Fields = new[] { Test.Field(field, fieldType) with {
          Parameter = new ParameterAst(AstNulls.At, parameter)
        } },
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldLabel_ReturnsCorrectAst(string name, string field, string label)
    => Test.TrueExpected(
      name + "={" + field + "=" + label + "}",
      Test.Object(name) with {
        Fields = new[] { Test.Field(field, "") with {
          Label = label
        } },
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldEnumLabel_ReturnsCorrectAst(string name, string field, string label, string fieldType)
    => Test.TrueExpected(
      name + "={" + field + "=" + fieldType + "." + label + "}",
      Test.Object(name) with {
        Fields = new[] { Test.Field(field, fieldType) with {
          Label = label
        } },
      });

  [Theory, RepeatData(Repeats)]
  public void WithFieldGenericEnumLabel_ReturnsCorrectAst(string name, string field, string fieldType, string enumType, string label)
    => Test.TrueExpected(
      name + "={" + field + ":" + fieldType + "<" + enumType + "." + label + ">}",
      Test.Object(name) with {
        Fields = new[] { Test.Field(field, Test.Reference(fieldType) with {
          Arguments = new[] { Test.Reference(enumType) with { Label = label } }
        }) },
      });

  //[Theory, RepeatData(Repeats)]
  //public void WithAll_ReturnsCorrectAst(string name, string name, OutputOption option, string alias1, string alias2)
  //  => Test.TrueExpected(
  //    name + "[" + alias1 + " " + alias2 + "](" + option.ToString().ToLowerInvariant() + ")=" + name,
  //    new OutputAst(AstNulls.At, name, name) {
  //      Option = option,
  //      Aliases = new[] { alias1, alias2 },
  //    });

  internal override IBaseObjectChecks Checks => Test;

  private static BaseObjectChecks<OutputAst, OutputFieldAst, OutputReferenceAst> Test => new(
    new OutputFactories(),
    (SchemaParser parser, out OutputAst result) => parser.ParseOutput(out result, ""));
}
