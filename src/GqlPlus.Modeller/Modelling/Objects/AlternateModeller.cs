namespace GqlPlus.Modelling.Objects;

internal class AlternateModeller<TObjBaseAst, TObjBase>(
  IModeller<TObjBaseAst, TObjBase> refBase,
  IModeller<IGqlpModifier, CollectionModel> modifier
) : ModellerBase<IGqlpAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  , IAlternateModeller<TObjBaseAst, TObjBase>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>, IEquatable<TObjBaseAst>
  where TObjBase : IObjBaseModel
{
  protected override AlternateModel<TObjBase> ToModel(IGqlpAlternate<TObjBaseAst> ast, IMap<TypeKindModel> typeKinds)
    => new(new(BaseModel(ast.Type, typeKinds), ast.Description)) {
      Collections = modifier.ToModels(ast.Modifiers, typeKinds)
    };

  private TObjBase BaseModel(TObjBaseAst ast, IMap<TypeKindModel> typeKinds)
    => refBase.ToModel(ast, typeKinds);
}

public interface IAlternateModeller<TObjBaseAst, TObjBase>
  : IModeller<IGqlpAlternate<TObjBaseAst>, AlternateModel<TObjBase>>
  where TObjBaseAst : IGqlpObjectBase<TObjBaseAst>, IEquatable<TObjBaseAst>
  where TObjBase : IObjBaseModel
{ }
