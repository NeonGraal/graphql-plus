namespace GqlPlus.Encoding;

internal class BaseDomainEncoder<TItem>(
  IEncoderRepository encoders
) : ParentTypeEncoder<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>>(encoders)
  where TItem : BaseDomainItemModel
{
  internal override Structured Encode(BaseDomainModel<TItem> model)
    => base.Encode(model)
      .Add("domainKind", model.DomainKind.EncodeEnum());

  internal static new BaseDomainEncoder<TItem> Factory(IEncoderRepository r) => new(r);
}

internal class BaseDomainItemEncoder<TItem>
  : DescribedEncoder<TItem>
  where TItem : BaseDomainItemModel
{
  internal override Structured Encode(TItem model)
    => base.Encode(model)
      .Add("exclude", model.Exclude);
}

internal class DomainItemEncoder<TItem>(
  IEncoderRepository encoders
) : BaseEncoder<DomainItemModel<TItem>>
  where TItem : BaseDomainItemModel
{
  private readonly IEncoder<TItem> _item = encoders.EncoderFor<TItem>();

  internal override Structured Encode(DomainItemModel<TItem> model)
    => base.Encode(model)
      .IncludeEncoded(model.Item, _item)
      .Add("domain", model.Domain);

  internal static DomainItemEncoder<TItem> Factory(IEncoderRepository r) => new(r);
}

internal class DomainLabelEncoder(
  IEncoderRepository encoders
) : BaseDomainItemEncoder<DomainLabelModel>
{
  private readonly IEncoder<EnumValueModel> _enumValue = encoders.EncoderFor<EnumValueModel>();

  internal override Structured Encode(DomainLabelModel model)
    => base.Encode(model)
      .AddEncoded("value", model.EnumValue, _enumValue);

  internal static new DomainLabelEncoder Factory(IEncoderRepository r) => new(r);
}

internal class DomainRangeEncoder
  : BaseDomainItemEncoder<DomainRangeModel>
{
  internal override Structured Encode(DomainRangeModel model)
    => base.Encode(model)
      .Add("from", model.From)
      .Add("to", model.To);

  internal static new DomainRangeEncoder Factory(IEncoderRepository _) => new();
}

internal class DomainRegexEncoder
  : BaseDomainItemEncoder<DomainRegexModel>
{
  internal override Structured Encode(DomainRegexModel model)
    => base.Encode(model)
      .Add("pattern", model.Pattern);

  internal static new DomainRegexEncoder Factory(IEncoderRepository _) => new();
}

internal class DomainTrueFalseEncoder
  : BaseDomainItemEncoder<DomainTrueFalseModel>
{
  internal override Structured Encode(DomainTrueFalseModel model)
    => base.Encode(model)
      .Add("value", model.Value);

  internal static new DomainTrueFalseEncoder Factory(IEncoderRepository _) => new();
}

internal class TypeEnumEncoder(
  IEncoderRepository encoders
) : ParentTypeEncoder<TypeEnumModel, AliasedModel, EnumLabelModel>(encoders)

{
  internal static new TypeEnumEncoder Factory(IEncoderRepository r) => new(r);
}

internal class EnumLabelEncoder
  : AliasedEncoder<EnumLabelModel>
{
  internal override Structured Encode(EnumLabelModel model)
    => base.Encode(model)
      .Add("enum", model.OfEnum);

  internal static new EnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class EnumValueEncoder
  : TypeRefEncoder<EnumValueModel, SimpleKindModel>
{
  internal override Structured Encode(EnumValueModel model)
    => base.Encode(model)
      .Add("label", model.Label);

  internal static new EnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class TypeUnionEncoder(
  IEncoderRepository encoders
) : ParentTypeEncoder<TypeUnionModel, NamedModel, UnionMemberModel>(encoders)

{
  internal static new TypeUnionEncoder Factory(IEncoderRepository r) => new(r);
}

internal class UnionMemberEncoder
  : NamedEncoder<UnionMemberModel>
{
  internal override Structured Encode(UnionMemberModel model)
    => base.Encode(model)
      .Add("union", model.OfUnion);

  internal static new UnionMemberEncoder Factory(IEncoderRepository _) => new();
}
