﻿namespace GqlPlus.Rendering;

internal class ConstantRenderer(
  IRenderer<SimpleModel> simple
) : IRenderer<ConstantModel>
{
  public RenderStructure Render(ConstantModel model)
    => model.Map.Count > 0 ? new RenderStructure(model.Map.ToDictionary(
        p => simple.Render(p.Key).Value!,
        p => Render(p.Value)), "_ConstantMap")
    : model.List.Count > 0 ? new(model.List.Select(Render), "_ConstantList")
    : model.Value is not null ? simple.Render(model.Value)
    : new("");
}

internal class SimpleRenderer
  : IRenderer<SimpleModel>
{
  RenderStructure IRenderer<SimpleModel>.Render(SimpleModel model)
    => model.Boolean is not null ? new(model.Boolean)
      : model.Number is not null ? new(model.Number, model.TypeRef?.Name ?? "")
      : model.String is not null ? new(RenderValue.Str(model.String), model.TypeRef?.Name ?? "")
      : model.Value is not null ? new(model.Value, model.TypeRef?.Name ?? "")
      : new("null", "Basic");
}

internal class CollectionRenderer
  : BaseRenderer<CollectionModel>
{
  internal override RenderStructure Render(CollectionModel model)
    => base.Render(model)
        .Add("modifierKind", model.ModifierKind)
        .Add(model.ModifierKind is ModifierKind.Dict or ModifierKind.Param,
          s => s
            .Add("by", model.Key
              ?? throw new InvalidOperationException($"{model.ModifierKind} Modifier must have a Key specified"))
            .Add("optional", model.IsOptional, true)
            .Add("typeKind", model.KeyType?.RenderEnum()));
}

internal class ModifierRenderer
  : CollectionRenderer
  , IRenderer<ModifierModel>
{
  RenderStructure IRenderer<ModifierModel>.Render(ModifierModel model)
    => Render(model);
}
