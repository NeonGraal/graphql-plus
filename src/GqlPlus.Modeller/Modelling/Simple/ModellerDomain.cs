namespace GqlPlus.Modelling.Simple;

internal abstract class ModellerDomain<TItemAst, TItemModel>
  : ModellerType<IGqlpDomain<TItemAst>, string, BaseDomainModel<TItemModel>>
  , IDomainModeller<TItemAst, TItemModel>
  where TItemAst : IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
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
  where TItemModel : BaseDomainItemModel
{ }
