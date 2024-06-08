﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Globals;

public record class CategoriesModel
  : ModelBase
{
  public CategoryModel? Category { get; init; }
  public BaseTypeModel? Type { get; init; }

  internal override RenderStructure Render(IRenderContext context)
    => Type is null
      ? Category is null
        ? new("")
        : Category.Render(context)
      : Category is null
        ? Type.Render(context)
        : base.Render(context)
          .Add("category", Category.Render(context))
          .Add("type", Type.Render(context));
}

public record class CategoryModel(
  string Name, TypeRefModel<TypeKindModel> Output
) : AliasedModel(Name)
{
  public CategoryOption Resolution { get; set; } = CategoryOption.Parallel;
  public ModifierModel[] Modifiers { get; set; } = [];

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("resolution", Resolution, "_Resolution")
      .Add("output", Output.Render(context))
      .Add("modifiers", Modifiers.Render(context, flow: true));
}

// ResolutionModel => CategoryOption

internal class CategoryModeller(
  IModeller<IGqlpModifier, ModifierModel> modifier
) : ModellerBase<IGqlpSchemaCategory, CategoryModel>
{
  protected override CategoryModel ToModel(IGqlpSchemaCategory ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Name, ast.Output.TypeRef(TypeKindModel.Output)) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Resolution = ast.CategoryOption,
      Modifiers = modifier.ToModels(ast.Modifiers, typeKinds),
    };
}
