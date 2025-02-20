namespace GqlPlus.Rendering;

internal class ConstantRenderer(
  IRenderer<SimpleModel> simple
) : IRenderer<ConstantModel>
{
  public Structured Render(ConstantModel model)
    => model.Map.Count > 0 ? new Structured(model.Map.ToDictionary(
        p => simple.Render(p.Key).Value!,
        p => Render(p.Value)), "_ConstantMap")
    : model.List.Count > 0 ? new(model.List.Select(Render), "_ConstantList")
    : model.Value is not null ? simple.Render(model.Value)
    : new("");
}

internal class SimpleRenderer
  : IRenderer<SimpleModel>
{
  Structured IRenderer<SimpleModel>.Render(SimpleModel model)
    => model.Boolean is not null ? new(model.Boolean)
      : model.Number is not null ? new(model.Number, model.TypeRef?.Name ?? "")
      : model.String is not null ? new(StructureValue.Str(model.String), model.TypeRef?.Name ?? "")
      : model.Value is not null ? new(model.Value, model.TypeRef?.Name ?? "")
      : new("null", "Basic");
}

internal class CollectionRenderer
  : BaseRenderer<CollectionModel>
{
  internal override Structured Render(CollectionModel model)
    => base.Render(model)
        .AddEnum("modifierKind", model.ModifierKind)
        .AddIf(model.ModifierKind is ModifierKind.Dict or ModifierKind.Param,
          s => s
            .Add("by", model.Key
              ?? throw new InvalidOperationException($"{model.ModifierKind} Modifier must have a Key specified"))
            .AddBool("optional", model.IsOptional, true)
            .Add("typeKind", model.KeyType?.RenderEnum()));
}

internal class ModifierRenderer
  : CollectionRenderer
  , IRenderer<ModifierModel>
{
  Structured IRenderer<ModifierModel>.Render(ModifierModel model)
    => Render(model);
}
