namespace GqlPlus.Encoding;

internal class BaseDomainEncoder<TItem>(
  ParentTypeEncoders<TItem, DomainItemModel<TItem>> encoders
) : ParentTypeEncoder<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>>(encoders)
  where TItem : BaseDomainItemModel
{
  internal override Structured Encode(BaseDomainModel<TItem> model)
    => base.Encode(model)
      .Add("domainKind", model.DomainKind.EncodeEnum());
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
  IEncoder<TItem> item
) : BaseEncoder<DomainItemModel<TItem>>
  where TItem : BaseDomainItemModel
{
  internal override Structured Encode(DomainItemModel<TItem> model)
    => base.Encode(model)
      .IncludeEncoded(model.Item, item)
      .Add("domain", model.Domain);
}

internal class DomainLabelEncoder(
  IEncoder<EnumValueModel> enumValue
) : BaseDomainItemEncoder<DomainLabelModel>
{
  internal override Structured Encode(DomainLabelModel model)
    => base.Encode(model)
      .AddEncoded("value", model.EnumValue, enumValue);
}

internal class DomainRangeEncoder
  : BaseDomainItemEncoder<DomainRangeModel>
{
  internal override Structured Encode(DomainRangeModel model)
    => base.Encode(model)
      .Add("from", model.From)
      .Add("to", model.To);
}

internal class DomainRegexEncoder
  : BaseDomainItemEncoder<DomainRegexModel>
{
  internal override Structured Encode(DomainRegexModel model)
    => base.Encode(model)
      .Add("pattern", model.Pattern);
}

internal class DomainTrueFalseEncoder
  : BaseDomainItemEncoder<DomainTrueFalseModel>
{
  internal override Structured Encode(DomainTrueFalseModel model)
    => base.Encode(model)
      .Add("value", model.Value);
}

internal class TypeEnumEncoder(
  ParentTypeEncoders<AliasedModel, EnumLabelModel> encoders
) : ParentTypeEncoder<TypeEnumModel, AliasedModel, EnumLabelModel>(encoders)
{ }

internal class EnumLabelEncoder
  : AliasedEncoder<EnumLabelModel>
{
  internal override Structured Encode(EnumLabelModel model)
    => base.Encode(model)
      .Add("enum", model.OfEnum);
}

internal class EnumValueEncoder
  : TypeRefEncoder<EnumValueModel, SimpleKindModel>
{
  internal override Structured Encode(EnumValueModel model)
    => base.Encode(model)
      .Add("label", model.Label);
}

internal class TypeUnionEncoder(
  ParentTypeEncoders<NamedModel, UnionMemberModel> encoders
) : ParentTypeEncoder<TypeUnionModel, NamedModel, UnionMemberModel>(encoders)
{ }

internal class UnionMemberEncoder
  : NamedEncoder<UnionMemberModel>
{
  internal override Structured Encode(UnionMemberModel model)
    => base.Encode(model)
      .Add("union", model.OfUnion);
}
