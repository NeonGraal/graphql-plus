using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Globals;

public class DirectivesModelTests(
  IModeller<IGqlpSchemaDirective, DirectiveModel> directive,
  IRenderer<DirectivesModel> rendering
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string input)
    => _checks
    .Model_Expected(
      _checks.ToModel(null, input),
      ["!_TypeInput",
        "name: " + input,
        "typeKind: !_TypeKind Input"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Both(
    string input,
    string name
  ) => _checks
    .Model_Expected(
      _checks.ToModel(new(AstNulls.At, name), input),
      ["!_Directives",
        "directive: !_Directive",
        "  name: " + name,
        "  repeatable: false",
        "type: !_TypeInput",
        "  name: " + input,
        "  typeKind: !_TypeKind Input"]);

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly DirectivesModelChecks _checks = new(directive, rendering);
}

internal sealed class DirectivesModelChecks(
  IModeller<IGqlpSchemaDirective, DirectiveModel> modeller,
  IRenderer<DirectivesModel> rendering
) : CheckModelBase<string, IGqlpSchemaDirective, DirectiveDeclAst, DirectiveModel, DirectivesModel>(modeller, rendering), ICheckModelBase
{
  protected override string[] ExpectedBase(string name)
  => ["!_Directive",
    "name: " + name,
    "repeatable: false"];

  protected override DirectiveDeclAst NewBaseAst(string name)
    => new(AstNulls.At, name);

  IRendering ICheckModelBase.ToModel(IGqlpError ast)
    => new DirectivesModel() { And = _modeller.ToModel((DirectiveDeclAst)ast, TypeKinds) };

  internal DirectivesModel ToModel(DirectiveDeclAst? ast, string input)
    => new() {
      And = _modeller.TryModel(ast, TypeKinds),
      Type = new TypeInputModel(input),
    };
}
