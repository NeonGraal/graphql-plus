using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public class SchemaModelTests(
  IModeller<SchemaAst, SchemaModel> modeller
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Settings(string name, SettingInput[] settings)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [new OptionDeclAst(AstNulls.At, name) {
          Settings = [.. settings.Select(s => s.ToAst(""))]
        }]
      },
      ["!_Schema",
        "name: " + name,
        .. _checks.ExpectedSettings(settings)]);

  [Theory, RepeatData(Repeats)]
  public void Model_Directives(string name, string[] directives)
    => _checks.AstExpected(
      new SchemaAst(AstNulls.At, name) {
        Declarations = [.. directives.Select(d => new DirectiveDeclAst(AstNulls.At, d))]
      },
      ["!_Schema",
        .. _checks.ExpectedDirectives(directives),
        "name: " + name]);

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
  internal IEnumerable<string> ExpectedDirectives(string[] directives)
    => directives.Order(StringComparer.Ordinal)
      .SelectMany(d => new[] { $"  !_Identifier {d}: !_Directive", "    name: " + d, "    repeatable: false" })
      .Prepend("directives: !_Map_Directives");

  internal IEnumerable<string> ExpectedSettings(SettingInput[] settings)
    => settings
      .OrderBy(s => s.Name, StringComparer.Ordinal)
      .SelectMany(s => s.Expected([], $"!_Identifier {s.Name}: ", "  "))
      .Indent()
      .Prepend("settings: !_Map_Setting");
}
