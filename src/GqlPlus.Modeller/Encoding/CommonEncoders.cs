namespace GqlPlus.Encoding;

internal class ConstantEncoder(
  IEncoder<SimpleModel> simple
) : IEncoder<ConstantModel>
{
  public Structured Encode(ConstantModel model)
    => model.Map.Count > 0 ? new Structured(model.Map.ToDictionary(
        p => simple.Encode(p.Key).Value!,
        p => Encode(p.Value)), "_ConstantMap")
    : model.List.Count > 0 ? new(model.List.Select(Encode), "_ConstantList")
    : model.Value is not null ? simple.Encode(model.Value)
    : new("");
}

internal class SimpleEncoder
  : IEncoder<SimpleModel>
{
  Structured IEncoder<SimpleModel>.Encode(SimpleModel model)
    => model.Boolean is not null ? new(model.Boolean)
      : model.Number is not null ? new(model.Number, model.TypeRef?.TypeName ?? "")
      : model.String is not null ? new(StructureValue.Str(model.String, model.TypeRef?.TypeName ?? ""))
      : model.Value is not null ? new(model.Value, model.TypeRef?.TypeName ?? "")
      : new("null", "Basic");
}

internal class CollectionEncoder
  : BaseEncoder<CollectionModel>
{
  internal override Structured Encode(CollectionModel model)
    => base.Encode(model)
        .AddEnum("modifierKind", model.ModifierKind)
        .AddIf(model.ModifierKind is ModifierKind.Dict or ModifierKind.Param,
          s => s
            .Add("by", model.Key
              ?? throw new InvalidOperationException($"{model.ModifierKind} Modifier must have a Key specified"))
            .AddBool("optional", model.IsOptional)
            .Add("typeKind", model.KeyType?.EncodeEnum()));
}

internal class ModifierEncoder
  : CollectionEncoder
  , IEncoder<ModifierModel>
{
  Structured IEncoder<ModifierModel>.Encode(ModifierModel model)
    => Encode(model);
}
