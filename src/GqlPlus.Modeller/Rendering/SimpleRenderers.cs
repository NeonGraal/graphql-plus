
namespace GqlPlus.Rendering;

internal class BaseDomainRenderer<TItem>(
  ParentTypeRenderers<TItem, DomainItemModel<TItem>> renderers
) : ParentTypeRenderer<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>>(renderers)
  where TItem : BaseDomainItemModel
{
  protected override Func<TItem, DomainItemModel<TItem>> NewItem(string parent)
    => item => new(item, parent);

  internal override Structured Render(BaseDomainModel<TItem> model)
    => base.Render(model)
      .Add("domainKind", model.DomainKind.RenderEnum());
}

internal class BaseDomainItemRenderer<TItem>
  : BaseRenderer<TItem>
  where TItem : BaseDomainItemModel
{
  internal override Structured Render(TItem model)
    => base.Render(model)
      .Add("exclude", model.Exclude);
}

internal class DomainItemRenderer<TItem>(
  IRenderer<TItem> item
) : BaseRenderer<DomainItemModel<TItem>>
  where TItem : BaseDomainItemModel
{
  internal override Structured Render(DomainItemModel<TItem> model)
    => base.Render(model)
      .IncludeRendered(model.Item, item)
      .Add("domain", model.Domain);
}

internal class DomainLabelRenderer(
  IRenderer<EnumValueModel> enumValue
) : BaseDomainItemRenderer<DomainLabelModel>
{
  internal override Structured Render(DomainLabelModel model)
    => base.Render(model)
      .AddRendered("value", model.EnumValue, enumValue);
}

internal class DomainRangeRenderer
  : BaseDomainItemRenderer<DomainRangeModel>
{
  internal override Structured Render(DomainRangeModel model)
    => base.Render(model)
      .Add("from", model.From)
      .Add("to", model.To);
}

internal class DomainRegexRenderer
  : BaseDomainItemRenderer<DomainRegexModel>
{
  internal override Structured Render(DomainRegexModel model)
    => base.Render(model)
      .Add("pattern", model.Pattern);
}

internal class DomainTrueFalseRenderer
  : BaseDomainItemRenderer<DomainTrueFalseModel>
{
  internal override Structured Render(DomainTrueFalseModel model)
    => base.Render(model)
      .Add("value", model.Value);
}

internal class TypeEnumRenderer(
  ParentTypeRenderers<AliasedModel, EnumLabelModel> renderers
) : ParentTypeRenderer<TypeEnumModel, AliasedModel, EnumLabelModel>(renderers)
{
  protected override Func<AliasedModel, EnumLabelModel> NewItem(string parent)
    => label
        => new(label.Name, parent) {
          Aliases = label.Aliases,
          Description = label.Description,
        };
}

internal class EnumLabelRenderer
  : AliasedRenderer<EnumLabelModel>
{
  internal override Structured Render(EnumLabelModel model)
    => base.Render(model)
      .Add("enum", model.OfEnum);
}

internal class EnumValueRenderer
  : TypeRefRenderer<EnumValueModel, SimpleKindModel>
{
  internal override Structured Render(EnumValueModel model)
    => base.Render(model)
      .Add("label", model.Label);
}

internal class TypeUnionRenderer(
  ParentTypeRenderers<AliasedModel, UnionMemberModel> renderers
) : ParentTypeRenderer<TypeUnionModel, AliasedModel, UnionMemberModel>(renderers)
{
  protected override Func<AliasedModel, UnionMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

internal class UnionMemberRenderer
  : AliasedRenderer<UnionMemberModel>
{
  internal override Structured Render(UnionMemberModel model)
    => base.Render(model)
      .Add("union", model.OfUnion);
}
