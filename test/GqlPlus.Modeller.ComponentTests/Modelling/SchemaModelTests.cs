using System.Diagnostics.CodeAnalysis;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling.Globals;
using GqlPlus.Token;

namespace GqlPlus.Modelling;

public class SchemaModelTests(
  IModeller<IGqlpSchema, SchemaModel> modeller,
  IRenderer<SchemaModel> rendering
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string type)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) { Declarations = [new OutputDeclAst(AstNulls.At, type)] },
      ["!_Schema", .. _checks.ExpectedOutputs([type])]);

  [Theory, RepeatData(Repeats)]
  public void Model_Types(string[] types)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [.. types.Select(d => new OutputDeclAst(AstNulls.At, d))]
      },
      ["!_Schema", .. _checks.ExpectedOutputs(types)]);

  [Theory, RepeatData(Repeats)]
  public void Model_Setting(string name, SettingInput setting)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [new OptionDeclAst(AstNulls.At, name) { Settings = [setting.ToAst("")] }]
      },
      ["!_Schema",
        "name: " + name,
        .. _checks.ExpectedSettings([setting])]);

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_Settings(string name, [NotNull] SettingInput[] settings)
    => _checks
      .SkipIf(settings.Select(s => s.Name).Distinct().Count() != settings.Length)
      .AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [new OptionDeclAst(AstNulls.At, name) {
          Settings = [.. settings.Distinct(SettingInput.CompareNames).Select(s => s.ToAst(""))]
        }]
      },
      ["!_Schema",
        "name: " + name,
        .. _checks.ExpectedSettings(settings)]);

  [Theory, RepeatData(Repeats)]
  public void Model_Directive(string directive)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) { Declarations = [new DirectiveDeclAst(AstNulls.At, directive)] },
      ["!_Schema", .. _checks.ExpectedDirectives([directive], false)]);

  [Theory, RepeatData(Repeats)]
  public void Model_Directives(string[] directives)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [.. directives.Select(d => new DirectiveDeclAst(AstNulls.At, d))]
      },
      ["!_Schema",
        .. _checks.ExpectedDirectives(directives, false)]);

  [Theory, RepeatData(Repeats)]
  public void Model_DirectiveAndType(string directive)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          new DirectiveDeclAst(AstNulls.At, directive),
          new OutputDeclAst(AstNulls.At, directive),
        ]
      },
      ["!_Schema",
        .. _checks.ExpectedDirectives([directive], true),
        .. _checks.ExpectedOutputs([directive]),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_DirectivesAndTypes(string[] directives)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          .. directives.Select(d => new DirectiveDeclAst(AstNulls.At, d)),
          .. directives.Select(d => new OutputDeclAst(AstNulls.At, d)),
        ]
      },
      ["!_Schema",
        .. _checks.ExpectedDirectives(directives, true),

        .. _checks.ExpectedOutputs(directives),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_Category(string category)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) { Declarations = [new CategoryDeclAst(AstNulls.At, category, category)] },
      ["!_Schema", .. _checks.ExpectedCategories([category], false)]);

  [Theory, RepeatData(Repeats)]
  public void Model_Categories(string[] categories)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [.. categories.Select(d => new CategoryDeclAst(AstNulls.At, d, d))]
      },
      ["!_Schema", .. _checks.ExpectedCategories(categories, false)]);

  [Theory, RepeatData(Repeats)]
  public void Model_CategoryAndType(string category)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          new CategoryDeclAst(AstNulls.At, category, category),
          new OutputDeclAst(AstNulls.At, category),
        ]
      },
      ["!_Schema",
        .. _checks.ExpectedCategories([category], true),

        .. _checks.ExpectedOutputs([category]),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_CategoriesAndTypes(string[] categories)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Declarations = [
          .. categories.Select(d => new CategoryDeclAst(AstNulls.At, d, d)),
          .. categories.Select(d => new OutputDeclAst(AstNulls.At, d)),
        ]
      },
      ["!_Schema",
        .. _checks.ExpectedCategories(categories, true),

        .. _checks.ExpectedOutputs(categories),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_Errors(string[] contents)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At) {
        Errors = [.. contents.Select(e => new TokenMessage(AstNulls.At, e))]
      },
      ["!_Schema",
        .. _checks.ExpectedErrors(contents),

      ]);

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly SchemaModelChecks _checks = new(modeller, rendering);
}

internal sealed class SchemaModelChecks(
  IModeller<IGqlpSchema, SchemaModel> modeller,
  IRenderer<SchemaModel> rendering
) : CheckModelBase<string, IGqlpSchema, SchemaAst, SchemaModel>(modeller, rendering)
{
  protected override string[] ExpectedBase(string name)
    => ["!_Schema", "name: " + name];

  protected override SchemaAst NewBaseAst(string name)
    => new(AstNulls.At) { Declarations = [new OptionDeclAst(AstNulls.At, name)] };

  internal IEnumerable<string> ExpectedCategories(string[] categories, bool withType)
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
      "      name: " + category,
      "      typeKind: !_TypeKind Output",
      "    resolution: !_Resolution Parallel"];

  internal IEnumerable<string> ExpectedDirectives(string[] directives, bool withType)
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

  internal IEnumerable<string> ExpectedErrors(string[] errors)
    => errors
      .SelectMany(e => new[] {
        "- !_Error",
        "  _kind: !_TokenKind Start",
        "  _message: " + e })
      .Prepend("_errors:");

  internal IEnumerable<string> ExpectedOutputs(string[] outputs)
    => outputs.Order(StringComparer.Ordinal)
      .SelectMany(o => ExpectedOutput(o, $"  !_Identifier {o}: !_TypeOutput"))
      .Prepend("types: !_Map_Type");

  private IEnumerable<string> ExpectedOutput(string output, string first)
    => [first, "    name: " + output, "    typeKind: !_TypeKind Output"];

  internal IEnumerable<string> ExpectedSettings(SettingInput[] settings)
    => settings
      .OrderBy(s => s.Name, StringComparer.Ordinal)
      .SelectMany(s => s.Expected([], $"!_Identifier {s.Name}: ", "  "))
      .Indent()
      .Prepend("settings: !_Map_Setting");
}
