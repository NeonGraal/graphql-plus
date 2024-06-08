using GqlPlus.Abstractions.Schema;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Simple;

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
  protected override string Tag => $"_Domain{DomainKind}";

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

internal abstract class ModellerDomain<TItemAst, TItemModel>
  : ModellerType<IGqlpDomain<TItemAst>, string, BaseDomainModel<TItemModel>>
  , IDomainModeller<TItemAst, TItemModel>
  where TItemAst : IGqlpDomainItem
  where TItemModel : IBaseDomainItemModel
{
  protected ModellerDomain()
    : base(TypeKindModel.Domain)
  { }

  internal TItemModel[] ToItems(IGqlpDomain<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Items.Select(ast => ToItem(ast, typeKinds))];

  internal DomainItemModel<TItemModel>[] ToAllItems(IGqlpDomain<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Items.Select(item => new DomainItemModel<TItemModel>(ToItem(item, typeKinds), ast.Name))];

  protected abstract TItemModel ToItem(TItemAst ast, IMap<TypeKindModel> typeKinds);
}

public interface IDomainModeller<TItemAst, TItemModel>
  : IModeller<IGqlpDomain<TItemAst>, BaseDomainModel<TItemModel>>
  where TItemAst : IGqlpDomainItem
  where TItemModel : IBaseDomainItemModel
{ }

internal class DomainBooleanModeller
  : ModellerDomain<IGqlpDomainTrueFalse, DomainTrueFalseModel>
{
  protected override BaseDomainModel<DomainTrueFalseModel> ToModel(IGqlpDomain<IGqlpDomainTrueFalse> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Boolean, ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainTrueFalseModel ToItem(IGqlpDomainTrueFalse ast, IMap<TypeKindModel> typeKinds)
    => new(ast.IsTrue, ast.Excludes);
}

internal class DomainEnumModeller
  : ModellerDomain<IGqlpDomainMember, DomainMemberModel>
{
  protected override BaseDomainModel<DomainMemberModel> ToModel(IGqlpDomain<IGqlpDomainMember> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Enum, ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainMemberModel ToItem(IGqlpDomainMember ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType ?? "", ast.EnumItem, ast.Excludes);
}

internal class DomainNumberModeller
  : ModellerDomain<IGqlpDomainRange, DomainRangeModel>
{
  protected override BaseDomainModel<DomainRangeModel> ToModel(IGqlpDomain<IGqlpDomainRange> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Number, ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainRangeModel ToItem(IGqlpDomainRange ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Lower, ast.Upper, ast.Excludes);
}

internal class DomainStringModeller
  : ModellerDomain<IGqlpDomainRegex, DomainRegexModel>
{
  protected override BaseDomainModel<DomainRegexModel> ToModel(IGqlpDomain<IGqlpDomainRegex> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.String, ast.Name) {
      Aliases = [.. ast.Aliases],
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainRegexModel ToItem(IGqlpDomainRegex ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Pattern, ast.Excludes);
}
