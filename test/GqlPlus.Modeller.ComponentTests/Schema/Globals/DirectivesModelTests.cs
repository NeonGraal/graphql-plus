using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Modelling;
using GqlPlus.Schema;

namespace GqlPlus.Schema.Globals;

public class DirectivesModelTests(
  IDirectivesModelChecks checks
) : TestModelBase<string, DirectivesModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string input)
    => checks
    .Model_Expected(
      checks.ToModel(null, input),
      ["!_TypeInput",
        "name: " + input,
        "typeKind: !_TypeKind Input"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Both(
    string input,
    string name
  ) => checks
    .Model_Expected(
      checks.ToModel(new DirectiveDeclAst(AstNulls.At, name), input),
      ["!_Directives",
        "directive: !_Directive",
        "  name: " + name,
        "  repeatable: false",
        "type: !_TypeInput",
        "  name: " + input,
        "  typeKind: !_TypeKind Input"]);
}

internal sealed class DirectivesModelChecks(
  IModeller<IGqlpSchemaDirective, DirectiveModel> modeller,
  IRenderer<DirectivesModel> rendering
) : CheckModelBase<string, IGqlpSchemaDirective, DirectiveDeclAst, DirectiveModel, DirectivesModel>(modeller, rendering)
  , IDirectivesModelChecks
{
  protected override string[] ExpectedBase(string name)
  => ["!_Directive",
    "name: " + name,
    "repeatable: false"];

  protected override DirectiveDeclAst NewBaseAst(string name)
    => new(AstNulls.At, name);

  IModelBase ICheckModelBase.ToModel(IGqlpError ast)
    => new DirectivesModel() { And = _modeller.ToModel((DirectiveDeclAst)ast, TypeKinds) };

  public DirectivesModel ToModel(IGqlpSchemaDirective? ast, string input)
    => new() {
      And = _modeller.TryModel((DirectiveDeclAst?)ast, TypeKinds),
      Type = new TypeInputModel(input),
    };
}

public interface IDirectivesModelChecks
  : ICheckModelBase<string, DirectivesModel>
{
  DirectivesModel ToModel(IGqlpSchemaDirective? ast, string input);
}
