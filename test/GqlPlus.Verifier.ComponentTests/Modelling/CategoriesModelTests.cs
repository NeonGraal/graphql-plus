using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public class CategoriesModelTests(
  IModeller<CategoryDeclAst, CategoryModel> category,
  IModeller<OutputDeclAst, TypeOutputModel> typeOutput
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string output)
    => _checks
    .Model_Expected(
      _checks.ToModel(null, output),
      ["!_TypeOutput",
        "kind: !_TypeKind Output",
        "name: " + output]);

  [Theory, RepeatData(Repeats)]
  public void Model_Both(
    string output,
    string name
  ) => _checks
    .Model_Expected(
      _checks.ToModel(new(AstNulls.At, name, output), output),
      ["!_Categories",
        "category: !_Category",
        "  name: " + name,
        .. output.TypeRefFor(TypeKindModel.Output).Indent(),
        "  resolution: !_Resolution Parallel",
        "type: !_TypeOutput",
        "  kind: !_TypeKind Output",
        "  name: " + output]);

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly CategoriesModelChecks _checks = new(category, typeOutput);
}

internal sealed class CategoriesModelChecks(
  IModeller<CategoryDeclAst, CategoryModel> modeller,
  IModeller<OutputDeclAst, TypeOutputModel> typeOutput
) : CheckModelBase<string, CategoryDeclAst, CategoryModel>(modeller), ICheckModelBase
{
  protected override string[] ExpectedBase(string name)
  => ["!_Category",
      "name: " + name.Camelize(),
      .. name.TypeRefFor(TypeKindModel.Output, "output"),
      "resolution: !_Resolution Parallel"];

  protected override CategoryDeclAst NewBaseAst(string name)
    => new(AstNulls.At, name);

  IRendering ICheckModelBase.ToModel(AstBase ast)
    => new CategoriesModel() { Category = _modeller.ToModel((CategoryDeclAst)ast, TypeKinds) };

  internal CategoriesModel ToModel(CategoryDeclAst? ast, string output)
    => new() {
      Category = _modeller.TryModel(ast, TypeKinds),
      Type = string.IsNullOrWhiteSpace(output) ? null : typeOutput.ToModel(new(AstNulls.At, output), TypeKinds),
    };
}
