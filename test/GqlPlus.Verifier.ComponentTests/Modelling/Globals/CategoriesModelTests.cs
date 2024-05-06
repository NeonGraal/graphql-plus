﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Globals;

public class CategoriesModelTests(
  IModeller<IGqlpSchemaCategory, CategoryModel> category,
  IModeller<OutputDeclAst, TypeOutputModel> typeOutput
) : TestModelBase<string>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Type(string output)
    => _checks
    .Model_Expected(
      _checks.ToModel(null, output),
      ["!_TypeOutput",
        "name: " + output,
        "typeKind: !_TypeKind Output"]);

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
        "  name: " + output,
        "  typeKind: !_TypeKind Output"]);

  internal override ICheckModelBase<string> BaseChecks => _checks;

  private readonly CategoriesModelChecks _checks = new(category, typeOutput);
}

internal sealed class CategoriesModelChecks(
  IModeller<IGqlpSchemaCategory, CategoryModel> modeller,
  IModeller<OutputDeclAst, TypeOutputModel> typeOutput
) : CheckModelBase<string, IGqlpSchemaCategory, CategoryDeclAst, CategoryModel>(modeller), ICheckModelBase
{
  protected override string[] ExpectedBase(string name)
  => ["!_Category",
      "name: " + name.Camelize(),
      .. name.TypeRefFor(TypeKindModel.Output, "output"),
      "resolution: !_Resolution Parallel"];

  protected override CategoryDeclAst NewBaseAst(string name)
    => new(AstNulls.At, name);

  IRendering ICheckModelBase.ToModel(IGqlpError ast)
    => new CategoriesModel() { Category = _modeller.ToModel((CategoryDeclAst)ast, TypeKinds) };

  internal CategoriesModel ToModel(CategoryDeclAst? ast, string output)
    => new() {
      Category = _modeller.TryModel(ast, TypeKinds),
      Type = string.IsNullOrWhiteSpace(output) ? null : typeOutput.ToModel(new(AstNulls.At, output), TypeKinds),
    };
}
