using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Modelling;

namespace GqlPlus.Schema.Globals;

public class CategoriesModelTests(
  ICategoriesModelChecks checks
) : TestModelBase<string, CategoriesModel>(checks)
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string output)
    => checks
    .Model_Expected(
      checks.ToModel(null, output),
      ["!_TypeOutput",
        "name: " + output,
        "typeKind: !_TypeKind Output"]);

  [Theory, RepeatData(Repeats)]
  public void Model_Both(
    string output,
    string name
  ) => checks
    .Model_Expected(
      checks.ToModel(new CategoryDeclAst(AstNulls.At, name, output), output),
      ["!_Categories",
        "category: !_Category",
        "  name: " + name,
        .. output.TypeRefFor(TypeKindModel.Output).Indent(),
        "  resolution: !_Resolution Parallel",
        "type: !_TypeOutput",
        "  name: " + output,
        "  typeKind: !_TypeKind Output"]);
}

internal sealed class CategoriesModelChecks(
  IModeller<IGqlpSchemaCategory, CategoryModel> modeller,
  IRenderer<CategoriesModel> rendering,
  IModeller<IGqlpOutputObject, TypeOutputModel> typeOutput
) : CheckModelBase<string, IGqlpSchemaCategory, CategoryDeclAst, CategoryModel, CategoriesModel>(modeller, rendering)
  , ICategoriesModelChecks
{
  protected override string[] ExpectedBase(string name)
  => ["!_Category",
    "name: " + name.Camelize(),
    .. name.TypeRefFor(TypeKindModel.Output, "output"),
    "resolution: !_Resolution Parallel"];

  protected override CategoryDeclAst NewBaseAst(string name)
    => new(AstNulls.At, name);

  IModelBase ICheckModelBase.ToModel(IGqlpError ast)
    => new CategoriesModel() { And = _modeller.ToModel((CategoryDeclAst)ast, TypeKinds) };

  public CategoriesModel ToModel(IGqlpSchemaCategory? ast, string output)
    => new() {
      And = _modeller.TryModel(ast, TypeKinds),
      Type = string.IsNullOrWhiteSpace(output) ? null : typeOutput.ToModel(new OutputDeclAst(AstNulls.At, output), TypeKinds),
    };
}

public interface ICategoriesModelChecks
  : ICheckModelBase<string, CategoriesModel>
{
  CategoriesModel ToModel(IGqlpSchemaCategory? ast, string input);
}
