using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

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
  DomainKindModel Domain,
  string Name
) : ParentTypeModel<TItem, DomainItemModel<TItem>>(TypeKindModel.Domain, Name)
  where TItem : IBaseDomainItemModel
{
  protected override string Tag => $"_Domain{Domain}";

  protected override Func<TItem, DomainItemModel<TItem>> NewItem(string parent)
    => item => new(item, parent);

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("domain", Domain.RenderEnum());
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
  public DomainMemberModel(string name, string value, bool exclude)
    : this(new(name, value), exclude)
  { }

  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add(EnumValue, context);
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
  string Regex,
  bool Exclude
) : BaseDomainItemModel(Exclude)
{
  internal override RenderStructure Render(IRenderContext context)
    => base.Render(context)
      .Add("regex", Regex);
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
  : ModellerType<AstDomain<TItemAst>, string, BaseDomainModel<TItemModel>>
  , IDomainModeller<TItemAst, TItemModel>
  where TItemAst : AstAbbreviated, IAstDomainItem
  where TItemModel : IBaseDomainItemModel
{
  protected ModellerDomain()
    : base(TypeKindModel.Domain)
  { }

  internal TItemModel[] ToItems(AstDomain<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Members.Select(ast => ToItem(ast, typeKinds))];

  internal DomainItemModel<TItemModel>[] ToAllItems(AstDomain<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Members.Select(item => new DomainItemModel<TItemModel>(ToItem(item, typeKinds), ast.Name))];

  protected abstract TItemModel ToItem(TItemAst ast, IMap<TypeKindModel> typeKinds);
}

public interface IDomainModeller<TItemAst, TItemModel>
  : IModeller<AstDomain<TItemAst>, BaseDomainModel<TItemModel>>
  where TItemAst : AstAbbreviated, IAstDomainItem
  where TItemModel : IBaseDomainItemModel
{ }

internal class DomainBooleanModeller
  : ModellerDomain<DomainTrueFalseAst, DomainTrueFalseModel>
{
  protected override BaseDomainModel<DomainTrueFalseModel> ToModel(AstDomain<DomainTrueFalseAst> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Boolean, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainTrueFalseModel ToItem(DomainTrueFalseAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Value, ast.Excludes);
}

internal class DomainEnumModeller
  : ModellerDomain<DomainMemberAst, DomainMemberModel>
{
  protected override BaseDomainModel<DomainMemberModel> ToModel(AstDomain<DomainMemberAst> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Enum, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainMemberModel ToItem(DomainMemberAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.EnumType ?? "", ast.Member, ast.Excludes);
}

internal class DomainNumberModeller
  : ModellerDomain<DomainRangeAst, DomainRangeModel>
{
  protected override BaseDomainModel<DomainRangeModel> ToModel(AstDomain<DomainRangeAst> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.Number, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainRangeModel ToItem(DomainRangeAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Lower, ast.Upper, ast.Excludes);
}

internal class DomainStringModeller
  : ModellerDomain<DomainRegexAst, DomainRegexModel>
{
  protected override BaseDomainModel<DomainRegexModel> ToModel(AstDomain<DomainRegexAst> ast, IMap<TypeKindModel> typeKinds)
    => new(DomainKindModel.String, ast.Name) {
      Aliases = ast.Aliases,
      Description = ast.Description,
      Parent = ast.Parent.TypeRef(SimpleKindModel.Domain),
      Items = ToItems(ast, typeKinds),
    };

  protected override DomainRegexModel ToItem(DomainRegexAst ast, IMap<TypeKindModel> typeKinds)
    => new(ast.Regex, ast.Excludes);
}
