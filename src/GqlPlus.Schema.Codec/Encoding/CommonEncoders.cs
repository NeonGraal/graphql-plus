namespace GqlPlus.Encoding;

internal class ConstantEncoder(
  IEncoderRepository encoders
) : IEncoder<ConstantModel>
{
  private readonly IEncoder<SimpleModel> _simple = encoders.EncoderFor<SimpleModel>();

  public Structured Encode(ConstantModel model)
    => model switch {
      { Map.Count: > 0 }
        => new Structured(model.Map.ToDictionary(
          p => _simple.Encode(p.Key).Value!,
          p => Encode(p.Value)), "_ConstantMap"),
      { List.Count: > 0 }
        => new(model.List.Select(Encode), "_ConstantList"),
      { Value: not null }
        => _simple.Encode(model.Value),
      _ => "".Encode(),
    };

  internal static ConstantEncoder Factory(IEncoderRepository r) => new(r);
}

internal class SimpleEncoder
  : IEncoder<SimpleModel>
{
  Structured IEncoder<SimpleModel>.Encode(SimpleModel model)
    => model switch {
      { EnumValue: not null } => model.EnumValue.Label.Encode(model.TypeName.IfWhiteSpace(model.EnumValue.Name)),
      { Boolean: not null } => model.Boolean.Encode(model.TypeName)!,
      { Number: not null } => model.Number.Encode(model.TypeName)!,
      { Text: not null } when !string.IsNullOrEmpty(model.Text)
        => model.Text.Encode(model.TypeName),
      _ => "".Encode(),
    };

  internal static SimpleEncoder Factory(IEncoderRepository _) => new();
}

internal class CollectionEncoder
  : BaseEncoder<CollectionModel>
{
  internal override Structured Encode(CollectionModel model)
    => base.Encode(model)
        .AddEnum("modifierKind", model.ModifierKind)
        .AddIf(model.ModifierKind is ModifierKindModel.Dict or ModifierKindModel.Param,
          s => s
            .Add("by", model.Key?.Encode()
              ?? throw new InvalidOperationException($"{model.ModifierKind} Modifier must have a Key specified"))
            .AddBool("optional", model.IsOptional)
            .Add("typeKind", model.KeyType?.EncodeEnum()));

  internal static CollectionEncoder Factory(IEncoderRepository _) => new();
}

internal class ModifierEncoder
  : CollectionEncoder
  , IEncoder<ModifierModel>
{
  Structured IEncoder<ModifierModel>.Encode(ModifierModel model)
    => Encode(model);

  internal static new ModifierEncoder Factory(IEncoderRepository _) => new();
}
