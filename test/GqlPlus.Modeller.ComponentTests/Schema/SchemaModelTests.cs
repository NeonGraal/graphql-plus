using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;
using GqlPlus.Schema.Globals;
using GqlPlus.Token;

namespace GqlPlus.Schema;

public class SchemaModelTests(
  ISchemaModelChecks checks
) : TestModelBase<string, SchemaModel>(checks)
{
  [Theory, RepeatData]
  public void Model_Type(string type)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) { Declarations = [new OutputDeclAst(AstNulls.At, type)] },
      ["!_Schema", .. checks.ExpectedOutputs([type])]);

  [Theory, RepeatData]
  public void Model_Types(string[] types)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [.. types.Select(d => new OutputDeclAst(AstNulls.At, d))]
      },
      ["!_Schema", .. checks.ExpectedOutputs(types)]);

  [Theory, RepeatData]
  public void Model_Setting(string name, SettingInput setting)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [new OptionDeclAst(AstNulls.At, name) { Settings = [setting.ToAst("")] }]
      },
      ["!_Schema",
        "name: " + name,
        .. checks.ExpectedSettings([setting])]);

  [Theory, RepeatData]
  public void Model_Settings(string name, [NotNull] SettingInput[] settings)
    => checks
      .SkipIf(settings.Select(s => s.Name).Distinct().Count() != settings.Length)
      .SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [new OptionDeclAst(AstNulls.At, name) {
          Settings = [.. settings.Distinct(SettingInput.CompareNames).Select(s => s.ToAst(""))]
        }]
      },
      ["!_Schema",
        "name: " + name,
        .. checks.ExpectedSettings(settings)]);

  [Theory, RepeatData]
  public void Model_Directive(string directive)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) { Declarations = [new DirectiveDeclAst(AstNulls.At, directive)] },
      ["!_Schema", .. checks.ExpectedDirectives([directive], false)]);

  [Theory, RepeatData]
  public void Model_Directives(string[] directives)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [.. directives.Select(d => new DirectiveDeclAst(AstNulls.At, d))]
      },
      ["!_Schema",
        .. checks.ExpectedDirectives(directives, false)]);

  [Theory, RepeatData]
  public void Model_DirectiveAndType(string directive)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          new DirectiveDeclAst(AstNulls.At, directive),
          new OutputDeclAst(AstNulls.At, directive),
        ]
      },
      ["!_Schema",
        .. checks.ExpectedDirectives([directive], true),
        .. checks.ExpectedOutputs([directive]),
      ]);

  [Theory, RepeatData]
  public void Model_DirectivesAndTypes(string[] directives)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          .. directives.Select(d => new DirectiveDeclAst(AstNulls.At, d)),
          .. directives.Select(d => new OutputDeclAst(AstNulls.At, d)),
        ]
      },
      ["!_Schema",
        .. checks.ExpectedDirectives(directives, true),

        .. checks.ExpectedOutputs(directives),
      ]);

  [Theory, RepeatData]
  public void Model_Category(string category)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) { Declarations = [new CategoryDeclAst(AstNulls.At, category, new TypeRefAst(AstNulls.At, category))] },
      ["!_Schema", .. checks.ExpectedCategories([category], false)]);

  [Theory, RepeatData]
  public void Model_Categories(string[] categories)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [.. categories.Select(d => new CategoryDeclAst(AstNulls.At, d, new TypeRefAst(AstNulls.At, d)))]
      },
      ["!_Schema", .. checks.ExpectedCategories(categories, false)]);

  [Theory, RepeatData]
  public void Model_CategoryAndType(string category)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          new CategoryDeclAst(AstNulls.At, category, new TypeRefAst(AstNulls.At, category)),
          new OutputDeclAst(AstNulls.At, category),
        ]
      },
      ["!_Schema",
        .. checks.ExpectedCategories([category], true),
        .. checks.ExpectedOutputs([category]),
      ]);

  [Theory, RepeatData]
  public void Model_CategoriesAndTypes(string[] categories)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          .. categories.Select(d => new CategoryDeclAst(AstNulls.At, d, new TypeRefAst(AstNulls.At, d))),
          .. categories.Select(d => new OutputDeclAst(AstNulls.At, d)),
        ]
      },
      ["!_Schema",
        .. checks.ExpectedCategories(categories, true),

        .. checks.ExpectedOutputs(categories),
      ]);

  [Theory, RepeatData]
  public void Model_Errors(string[] contents)
    => checks.SchemaExpected(
      new SchemaAst(AstNulls.At) {
        Errors = [.. contents.Select(e => new TokenMessage(AstNulls.At, e))]
      },
      ["!_Schema",
        .. checks.ExpectedErrors(contents),

      ]);
}

internal sealed class SchemaModelChecks(
  IModeller<IGqlpSchema, SchemaModel> modeller,
  IEncoder<SchemaModel> encoding
) : CheckModelBase<string, IGqlpSchema, SchemaAst, SchemaModel>(modeller, encoding)
  , ISchemaModelChecks
{
  protected override string[] ExpectedBase(string name)
    => ["!_Schema", "name: " + name];

  protected override SchemaAst NewBaseAst(string name)
    => new(AstNulls.At) { Declarations = [new OptionDeclAst(AstNulls.At, name)] };

  public IEnumerable<string> ExpectedCategories(string[] categories, bool withType)
    => categories.Order(StringComparer.Ordinal)
      .SelectMany(c => withType
        ? ExpectedCategory(c, "  category: !_Category")
          .Concat(ExpectedOutput(c, "  type: !_TypeOutput"))
          .Indent()
          .Prepend($"  !_Identifier {c}: !_Categories")
        : ExpectedCategory(c, $"  !_Identifier {c}: !_Category"))
      .Prepend("categories: !_Map_Categories");

  private IEnumerable<string> ExpectedCategory(string category, string first)
    => [first,
      "    name: " + category,
      "    output: !_TypeRef(_TypeKind)",
      "      typeKind: !_TypeKind Output",
      "      typeName: " + category,
      "    resolution: !_Resolution Parallel"];

  public IEnumerable<string> ExpectedDirectives(string[] directives, bool withType)
    => directives.Order(StringComparer.Ordinal)
      .SelectMany(d => withType
        ? ExpectedDirective(d, $"  directive: !_Directive")
          .Concat(ExpectedOutput(d, $"  type: !_TypeOutput"))
          .Indent()
          .Prepend($"  !_Identifier {d}: !_Directives")
        : ExpectedDirective(d, $"  !_Identifier {d}: !_Directive"))
      .Prepend("directives: !_Map_Directives");

  private IEnumerable<string> ExpectedDirective(string directive, string first)
    => [first, "    name: " + directive, "    repeatable: false"];

  public IEnumerable<string> ExpectedErrors(string[] errors)
    => errors
      .SelectMany(e => new[] {
        "  - !_Error",
        "    _kind: !_TokenKind Start",
        "    _message: " + e })
      .Prepend("_errors:");

  public IEnumerable<string> ExpectedOutputs(string[] outputs)
    => outputs.Order(StringComparer.Ordinal)
      .SelectMany(o => ExpectedOutput(o, $"  !_Identifier {o}: !_TypeOutput"))
      .Prepend("types: !_Map_Type");

  private IEnumerable<string> ExpectedOutput(string output, string first)
    => [first, "    name: " + output, "    typeKind: !_TypeKind Output"];

  public IEnumerable<string> ExpectedSettings(SettingInput[] settings)
    => settings
      .OrderBy(s => s.Name, StringComparer.Ordinal)
      .SelectMany(s => s.Expected([], $"!_Identifier {s.Name}: ", "  "))
      .Indent()
      .Prepend("settings: !_Map_Setting");

  public void SchemaExpected(IGqlpSchema ast, string[] expected)
    => AstExpected((SchemaAst)ast, expected);
}

public interface ISchemaModelChecks
  : ICheckModelBase<string, SchemaModel>
{
  void SchemaExpected(IGqlpSchema ast, string[] expected);

  IEnumerable<string> ExpectedCategories(string[] categories, bool withType);
  IEnumerable<string> ExpectedDirectives(string[] directives, bool withType);
  IEnumerable<string> ExpectedErrors(string[] errors);
  IEnumerable<string> ExpectedOutputs(string[] outputs);
  IEnumerable<string> ExpectedSettings(SettingInput[] settings);
}
