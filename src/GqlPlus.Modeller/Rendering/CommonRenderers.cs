using static System.Runtime.InteropServices.JavaScript.JSType;
using YamlDotNet.Core.Tokens;

namespace GqlPlus.Rendering;

internal class ConstantRenderer
  : IRenderer<ConstantModel>
{
  RenderStructure IRenderer<ConstantModel>.Render(ConstantModel model, IRenderContext context)
    => model.Map.Count > 0 ? new RenderStructure(model.Map.ToDictionary(
        p => p.Key.Render(context).Value!,
        p => p.Value.Render(context)), "_ConstantMap")
    : model.List.Count > 0 ? model.List.Render(context, "_ConstantList")
    : model.Value is not null ? model.Value.Render(context)
    : new("");
}

internal class SimpleRenderer
  : IRenderer<SimpleModel>
{
  RenderStructure IRenderer<SimpleModel>.Render(SimpleModel model, IRenderContext context)
    => model.Boolean is not null ? new(model.Boolean)
      : model.Number is not null ? new(model.Number, model.TypeRef?.Name ?? "")
      : model.String is not null ? new(RenderValue.Str(model.String), model.TypeRef?.Name ?? "")
      : model.Value is not null ? new(model.Value, model.TypeRef?.Name ?? "")
      : new("null", "Basic");
}

internal class CollectionRenderer
  : BaseRenderer<CollectionModel>
{
  internal override RenderStructure Render(CollectionModel model, IRenderContext context)
    => base.Render(model, context)
        .Add("modifierKind", model.ModifierKind)
        .Add(model.ModifierKind is ModifierKind.Dict or ModifierKind.Param,
          s => s
            .Add("by", model.Key
              ?? throw new InvalidOperationException($"{model.ModifierKind} Modifier must have a Key specified"))
            .Add("optional", model.IsOptional, true));
}

internal class ModifierRenderer
  : CollectionRenderer
  , IRenderer<ModifierModel>
{
  RenderStructure IRenderer<ModifierModel>.Render(ModifierModel model, IRenderContext context)
    => Render(model, context);
}
