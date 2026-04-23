namespace GqlPlus.Modelling.Simple;

internal abstract class ModellerDomain<TItemAst, TItemModel>
  : ModellerType<IAstDomain<TItemAst>, IAstTypeRef, BaseDomainModel<TItemModel>>
  , IDomainModeller<TItemAst, TItemModel>
  where TItemAst : IAstDomainItem
  where TItemModel : BaseDomainItemModel
{
  protected ModellerDomain()
    : base(TypeKindModel.Domain)
  { }

  internal TItemModel[] ToItems(IAstDomain<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Items.Select(ast => ToItem(ast, typeKinds))];

  internal DomainItemModel<TItemModel>[] ToAllItems(IAstDomain<TItemAst> ast, IMap<TypeKindModel> typeKinds)
    => [.. ast.Items.Select(item => new DomainItemModel<TItemModel>(ToItem(item, typeKinds), ast.Name))];

  protected abstract TItemModel ToItem(TItemAst ast, IMap<TypeKindModel> typeKinds);
}

public interface IDomainModeller<TItemAst, TItemModel>
  : IModeller<IAstDomain<TItemAst>, BaseDomainModel<TItemModel>>
  where TItemAst : IAstDomainItem
  where TItemModel : BaseDomainItemModel
{ }
