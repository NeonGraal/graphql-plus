using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class DirectivesModelTests(
  IModeller<DirectiveDeclAst, DirectiveModel> directive
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string input)
    => _checks
    .Model_Expected(
      _checks.ToModel(null, input),
      ["!_TypeInput",
        "kind: !_TypeKind Input",
        "name: " + input]);

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
          "  kind: !_TypeKind Input",
          "  name: " + input]);

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly DirectivesModelChecks _checks = new(directive);
}

internal sealed class DirectivesModelChecks(
  IModeller<DirectiveDeclAst, DirectiveModel> modeller
) : CheckModelBase<string, DirectiveDeclAst, DirectiveModel>(modeller), ICheckModelBase
{
  protected override string[] ExpectedBase(string name)
  => ["!_Directive",
      "name: " + name,
      "repeatable: false"];

  protected override DirectiveDeclAst NewBaseAst(string name)
    => new(AstNulls.At, name);

  IRendering ICheckModelBase.ToModel(AstBase ast)
    => new DirectivesModel() { Directive = _modeller.ToModel((DirectiveDeclAst)ast, TypeKinds) };

  internal DirectivesModel ToModel(DirectiveDeclAst? ast, string input)
    => new() {
      Directive = _modeller.TryModel(ast, TypeKinds),
      Type = new TypeInputModel(input),
    };
}
