using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Modelling;

public class SchemaModelTests(
  IModeller<SchemaAst, SchemaModel> modeller
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string name, string type)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) { Declarations = [new OutputDeclAst(AstNulls.At, type)] },
      ["!_Schema", "name: " + name, .. _checks.ExpectedOutputs([type])]);

  [Theory, RepeatData(Repeats)]
  public void Model_Types(string name, string[] types)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [.. types.Select(d => new OutputDeclAst(AstNulls.At, d))]
      },
      ["!_Schema", "name: " + name, .. _checks.ExpectedOutputs(types)]);

  [Theory, RepeatData(Repeats)]
  public void Model_Setting(string name, SettingInput setting)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [new OptionDeclAst(AstNulls.At, name) { Settings = [setting.ToAst("")] }]
      },
      ["!_Schema", "name: " + name, .. _checks.ExpectedSettings([setting])]);

  [Theory, RepeatData(Repeats)]
  public void Model_Settings(string name, SettingInput[] settings)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [new OptionDeclAst(AstNulls.At, name) {
          Settings = [.. settings.Distinct(SettingInput.CompareNames).Select(s => s.ToAst(""))]
        }]
      },
      ["!_Schema",
        "name: " + name,
        .. _checks.ExpectedSettings(settings)]);

  [Theory, RepeatData(Repeats)]
  public void Model_Directive(string name, string directive)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) { Declarations = [new DirectiveDeclAst(AstNulls.At, directive)] },
      ["!_Schema", .. _checks.ExpectedDirectives([directive], false), "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_Directives(string name, string[] directives)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [.. directives.Select(d => new DirectiveDeclAst(AstNulls.At, d))]
      },
      ["!_Schema",
        .. _checks.ExpectedDirectives(directives, false),
        "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_DirectiveAndType(string name, string directive)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [
          new DirectiveDeclAst(AstNulls.At, directive),
          new OutputDeclAst(AstNulls.At, directive),]
      },
      ["!_Schema",
        .. _checks.ExpectedDirectives([directive], true),
        "name: " + name,
        .. _checks.ExpectedOutputs([directive]),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_DirectivesAndTypes(string name, string[] directives)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [
          .. directives.Select(d => new DirectiveDeclAst(AstNulls.At, d)),
          .. directives.Select(d => new OutputDeclAst(AstNulls.At, d)),
        ]
      },
      ["!_Schema",
        .. _checks.ExpectedDirectives(directives, true),
        "name: " + name,
        .. _checks.ExpectedOutputs(directives),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_Category(string name, string category)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) { Declarations = [new CategoryDeclAst(AstNulls.At, category, category)] },
      ["!_Schema", .. _checks.ExpectedCategories([category], false), "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_Categories(string name, string[] categories)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [.. categories.Select(d => new CategoryDeclAst(AstNulls.At, d, d))]
      },
      ["!_Schema", .. _checks.ExpectedCategories(categories, false), "name: " + name]);

  [Theory, RepeatData(Repeats)]
  public void Model_CategoryAndType(string name, string category)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [
          new CategoryDeclAst(AstNulls.At, category, category),
          new OutputDeclAst(AstNulls.At, category),
        ]
      },
      ["!_Schema",
        .. _checks.ExpectedCategories([category], true),
        "name: " + name,
        .. _checks.ExpectedOutputs([category]),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_CategoriesAndTypes(string name, string[] categories)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [
          .. categories.Select(d => new CategoryDeclAst(AstNulls.At, d, d)),
          .. categories.Select(d => new OutputDeclAst(AstNulls.At, d)),
        ]
      },
      ["!_Schema",
        .. _checks.ExpectedCategories(categories, true),
        "name: " + name,
        .. _checks.ExpectedOutputs(categories),
      ]);

  [Theory, RepeatData(Repeats)]
  public void Model_Errors(string name, string[] contents)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Errors = [.. contents.Select(e => new TokenMessage(AstNulls.At, e))]
      },
      ["!_Schema",
        .. _checks.ExpectedErrors(contents),
        "name: " + name,
      ]);

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly SchemaModelChecks _checks = new(modeller);
}

internal sealed class SchemaModelChecks(
  IModeller<SchemaAst, SchemaModel> modeller
) : CheckModelBase<string, SchemaAst, SchemaModel>(modeller)
{
  protected override string[] ExpectedBase(string name)
    => ["!_Schema " + name];

  protected override SchemaAst NewBaseAst(string name)
    => new(AstNulls.At, name);

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
    => [ first,
        "    name: " + category,
        "    output: !_TypeRef(_TypeKind)",
        "      kind: !_TypeKind Output",
        "      name: " + category,
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
    => [first, "    kind: !_TypeKind Output", "    name: " + output];

  internal IEnumerable<string> ExpectedSettings(SettingInput[] settings)
    => settings
      .OrderBy(s => s.Name, StringComparer.Ordinal)
      .SelectMany(s => s.Expected([], $"!_Identifier {s.Name}: ", "  "))
      .Indent()
      .Prepend("settings: !_Map_Setting");
}
