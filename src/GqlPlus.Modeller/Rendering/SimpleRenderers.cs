
namespace GqlPlus.Rendering;

internal class BaseDomainRenderer<TItem>(
  ParentTypeRenderers<TItem, DomainItemModel<TItem>> renderers
) : ParentTypeRenderer<BaseDomainModel<TItem>, TItem, DomainItemModel<TItem>>(renderers)
  where TItem : BaseDomainItemModel
{
  protected override Func<TItem, DomainItemModel<TItem>> NewItem(string parent)
    => item => new(item, parent);

  internal override RenderStructure Render(BaseDomainModel<TItem> model, IRenderContext context)
    => base.Render(model, context)
      .Add("domainKind", model.DomainKind.RenderEnum());
}

internal class BaseDomainItemRenderer<TItem>
  : BaseRenderer<TItem>
  where TItem : BaseDomainItemModel
{
  internal override RenderStructure Render(TItem model, IRenderContext context)
    => base.Render(model, context)
      .Add("exclude", model.Exclude);
}

internal class DomainItemRenderer<TItem>(
  IRenderer<TItem> item
) : BaseRenderer<DomainItemModel<TItem>>
  where TItem : BaseDomainItemModel
{
  internal override RenderStructure Render(DomainItemModel<TItem> model, IRenderContext context)
    => base.Render(model, context)
      .Add(model.Item, item, context)
      .Add("domain", model.Domain);
}

internal class DomainMemberRenderer(
  IRenderer<EnumValueModel> enumValue
) : BaseDomainItemRenderer<DomainMemberModel>
{
  internal override RenderStructure Render(DomainMemberModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("value", model.EnumValue, enumValue, context);
}

internal class DomainRangeRenderer
  : BaseDomainItemRenderer<DomainRangeModel>
{
  internal override RenderStructure Render(DomainRangeModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("from", model.From)
      .Add("to", model.To);
}

internal class DomainRegexRenderer
  : BaseDomainItemRenderer<DomainRegexModel>
{
  internal override RenderStructure Render(DomainRegexModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("pattern", model.Pattern);
}

internal class DomainTrueFalseRenderer
  : BaseDomainItemRenderer<DomainTrueFalseModel>
{
  internal override RenderStructure Render(DomainTrueFalseModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("value", model.Value);
}

internal class TypeEnumRenderer(
  ParentTypeRenderers<AliasedModel, EnumMemberModel> renderers
) : ParentTypeRenderer<TypeEnumModel, AliasedModel, EnumMemberModel>(renderers)
{
  protected override Func<AliasedModel, EnumMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

internal class EnumMemberRenderer
  : AliasedRenderer<EnumMemberModel>
{
  internal override RenderStructure Render(EnumMemberModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("enum", model.OfEnum);
}

internal class EnumValueRenderer
  : TypeRefRenderer<EnumValueModel, SimpleKindModel>
{
  internal override RenderStructure Render(EnumValueModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("member", model.Member);
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
  internal override RenderStructure Render(UnionMemberModel model, IRenderContext context)
    => base.Render(model, context)
      .Add("union", model.OfUnion);
}
