namespace GqlPlus.Models;

public enum DomainKindModel { Boolean, Enum, Number, String, Union }

internal record class DomainRefModel(
  string Name,
  DomainKind DomainKind
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Domain, Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("domainKind", DomainKind);
}

public sealed record class BaseDomainModel<TItem>(
  DomainKindModel DomainKind,
  string Name
) : ParentTypeModel<TItem, DomainItemModel<TItem>>(TypeKindModel.Domain, Name)
  where TItem : IBaseDomainItemModel
{
  internal override string Tag => $"_Domain{DomainKind}";

  protected override Func<TItem, DomainItemModel<TItem>> NewItem(string parent)
    => item => new(item, parent);

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("domainKind", DomainKind.RenderEnum());
}

public record class BaseDomainItemModel(
  bool Exclude
) : ModelBase, IBaseDomainItemModel
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("exclude", Exclude);
}

public interface IBaseDomainItemModel
  : IRendering
{ }

public record class DomainMemberModel(
  EnumValueModel EnumValue,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{
  public DomainMemberModel(string name, string member, bool exclude)
    : this(new(name, member), exclude)
  { }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", EnumValue.Render(context));
}

public record class DomainTrueFalseModel(
  bool Value,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("value", Value);
}

public record class DomainRangeModel(
  decimal? From,
  decimal? To,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("from", From)
      .Add("to", To);
}

public record class DomainRegexModel(
  string Pattern,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("pattern", Pattern);
}

public record class DomainItemModel<TItem>(
  TItem Item,
  string Domain
) : ModelBase
  where TItem : IBaseDomainItemModel
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(Item, context)
      .Add("domain", Domain);
}

public record class TypeEnumModel(
  string Name
) : ParentTypeModel<AliasedModel, EnumMemberModel>(TypeKindModel.Enum, Name)
{
  protected override Func<AliasedModel, EnumMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class EnumMemberModel(
  string Name,
  string OfEnum
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => throw new NotImplementedException();
}

public record class EnumValueModel(
  string Name,
  string Member
) : TypeRefModel<SimpleKindModel>(SimpleKindModel.Enum, Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("member", Member);
}

public record class TypeUnionModel(
  string Name
) : ParentTypeModel<AliasedModel, UnionMemberModel>(TypeKindModel.Union, Name)
{
  protected override Func<AliasedModel, UnionMemberModel> NewItem(string parent)
    => member
        => new(member.Name, parent) {
          Aliases = member.Aliases,
          Description = member.Description,
        };
}

public record class UnionMemberModel(
  string Name,
  string OfUnion
) : AliasedModel(Name)
{
  internal override RenderStructure Render(IRenderContext context)
    => throw new NotImplementedException();
}
