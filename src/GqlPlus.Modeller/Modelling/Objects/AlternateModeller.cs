namespace GqlPlus.Modelling.Objects;

internal class AlternateModeller<TObjBaseAst, TObjBase>(
  IModeller<TObjBaseAst, TObjBase> refBase,
  IModeller<IGqlpModifier, CollectionModel> modifier
) : ModellerBase<IGqlpObjAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  , IAlternateModeller<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjBase<TObjBaseAst>, IEquatable<TObjBaseAst>
  where TObjBase : IObjBaseModel
{
  protected override AlternateModel<TObjBase> ToModel(IGqlpObjAlternate<TObjBaseAst> ast, IMap<TypeKindModel> typeKinds)
    => new(new(BaseModel(ast.Type, typeKinds), ast.Description)) {
      Collections = modifier.ToModels(ast.Modifiers, typeKinds)
    };

  private TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => refBase.ToModel(ast, typeKinds);
}

public interface IAlternateModeller<TObjBaseAst, TObjBase>
  : IModeller<IGqlpObjAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  where TObjBaseAst : IGqlpObjBase<TObjBaseAst>, IEquatable<TObjBaseAst>
  where TObjBase : IObjBaseModel
{ }
