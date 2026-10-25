namespace GqlPlus.Encoding;

internal class BaseDomainEncoder<TItem>(
  IEncoderRepository encoders
) : ParentTypeEncoder<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>>(encoders)
  where TItem : BaseDomainItemModel
{
  internal override IGqlpValue Encode(BaseDomainModel<TItem> model)
    => base.Encode(model)
      .Add("domainKind", model.DomainKind.EncodeEnum());

  internal static BaseDomainEncoder<TItem> Factory(IEncoderRepository r) => new(r);
}

internal class BaseDomainItemEncoder<TItem>
  : DescribedEncoder<TItem>
  where TItem : BaseDomainItemModel
{
  internal override IGqlpValue Encode(TItem model)
    => base.Encode(model)
      .Add("exclude", model.Exclude.Encode());
}

internal class DomainItemEncoder<TItem>(
  IEncoderRepository encoders
) : BaseEncoder<DomainItemModel<TItem>>
  where TItem : BaseDomainItemModel
{
  private readonly Encoder<TItem> _item = encoders.EncoderFor<TItem>();

  internal override IGqlpValue Encode(DomainItemModel<TItem> model)
    => base.Encode(model)
      .IncludeEncoded(model.Item, _item)
      .Add("domain", model.Domain.Encode());

  internal static DomainItemEncoder<TItem> Factory(IEncoderRepository r) => new(r);
}

internal class DomainLabelEncoder(
  IEncoderRepository encoders
) : BaseDomainItemEncoder<DomainLabelModel>
{
  private readonly Encoder<EnumValueModel> _enumValue = encoders.EncoderFor<EnumValueModel>();

  internal override IGqlpValue Encode(DomainLabelModel model)
    => base.Encode(model)
      .AddEncoded("value", model.EnumValue, _enumValue);

  internal static DomainLabelEncoder Factory(IEncoderRepository r) => new(r);
}

internal class DomainRangeEncoder
  : BaseDomainItemEncoder<DomainRangeModel>
{
  internal override IGqlpValue Encode(DomainRangeModel model)
    => base.Encode(model)
      .Add("from", model.From.Encode())
      .Add("to", model.To.Encode());

  internal static DomainRangeEncoder Factory(IEncoderRepository _) => new();
}

internal class DomainRegexEncoder
  : BaseDomainItemEncoder<DomainRegexModel>
{
  internal override IGqlpValue Encode(DomainRegexModel model)
    => base.Encode(model)
      .Add("pattern", model.Pattern.Encode());

  internal static DomainRegexEncoder Factory(IEncoderRepository _) => new();
}

internal class DomainTrueFalseEncoder
  : BaseDomainItemEncoder<DomainTrueFalseModel>
{
  internal override IGqlpValue Encode(DomainTrueFalseModel model)
    => base.Encode(model)
      .Add("value", model.Value.Encode());

  internal static DomainTrueFalseEncoder Factory(IEncoderRepository _) => new();
}

internal class TypeEnumEncoder(
  IEncoderRepository encoders
) : ParentTypeEncoder<TypeEnumModel, AliasedModel, EnumLabelModel>(encoders)

{
  internal static TypeEnumEncoder Factory(IEncoderRepository r) => new(r);
}

internal class EnumLabelEncoder
  : AliasedEncoder<EnumLabelModel>
{
  internal override IGqlpValue Encode(EnumLabelModel model)
    => base.Encode(model)
      .Add("enum", model.OfEnum.Encode());

  internal static EnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class EnumValueEncoder
  : TypeRefEncoder<EnumValueModel, SimpleKindModel>
{
  internal override IGqlpValue Encode(EnumValueModel model)
    => base.Encode(model)
      .Add("label", model.Label.Encode());

  internal static new EnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class TypeUnionEncoder(
  IEncoderRepository encoders
) : ParentTypeEncoder<TypeUnionModel, NamedModel, UnionMemberModel>(encoders)

{
  internal static TypeUnionEncoder Factory(IEncoderRepository r) => new(r);
}

internal class UnionMemberEncoder
  : NamedEncoder<UnionMemberModel>
{
  internal override IGqlpValue Encode(UnionMemberModel model)
    => base.Encode(model)
      .Add("union", model.OfUnion.Encode());

  internal static UnionMemberEncoder Factory(IEncoderRepository _) => new();
}
