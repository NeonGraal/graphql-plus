﻿namespace GqlPlus.Encoding;

internal class ConstantEncoder(
  IEncoder<SimpleModel> simple
) : IEncoder<ConstantModel>
{
  public Structured Encode(ConstantModel model)
    => model switch {
      { Map.Count: > 0 }
        => new Structured(model.Map.ToDictionary(
          p => simple.Encode(p.Key).Value!,
          p => Encode(p.Value)), "_ConstantMap"),
      { List.Count: > 0 }
        => new(model.List.Select(Encode), "_ConstantList"),
      { Value: not null }
        => simple.Encode(model.Value),
      _ => new(""),
    };
}

internal class SimpleEncoder
  : IEncoder<SimpleModel>
{
  Structured IEncoder<SimpleModel>.Encode(SimpleModel model)
    => model switch {
      { Value: not null } when !string.IsNullOrWhiteSpace(model.Value)
        => new(model.Value, model.TypeRef?.TypeName ?? ""),
      { Boolean: not null } => new(model.Boolean),
      { Number: not null } => new(model.Number, model.TypeRef?.TypeName ?? ""),
      { Text: not null } when !string.IsNullOrEmpty(model.Text)
        => new(StructureValue.Str(model.Text, model.TypeRef?.TypeName ?? "")),
      _ => new(""), // new("null", "Basic"),
    };
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
