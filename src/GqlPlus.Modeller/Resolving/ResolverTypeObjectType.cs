namespace GqlPlus.Resolving;

internal abstract class ResolverTypeObjectType<TModel, TObjBase, TObjField, TObjAlt>
  : ResolverChildType<TModel, ObjDescribedModel<TObjBase>>
  , ITypeResolver
  where TModel : TypeObjectModel<TObjBase, TObjField, TObjAlt>
  where TObjBase : IObjBaseModel
  where TObjField : IObjFieldModel
  where TObjAlt : IObjAlternateModel
{
  public bool ForType(BaseTypeModel model)
    => model is TModel;

  public BaseTypeModel ResolveType(BaseTypeModel model, IResolveContext context)
    => Resolve((TModel)model, context);

  public override TModel Resolve(TModel model, IResolveContext context)
  {
    model = base.Resolve(model, context);

    IEnumerable<ObjectForModel<TObjAlt>> allAlternates = model.Alternates.Select(NewObjectFor<TObjAlt>(model));
    IEnumerable<ObjectForModel<TObjField>> allFields = model.Fields.Select(NewObjectFor<TObjField>(model));

    if (model.ParentModel is TModel parent) {
      model.AllAlternates = [.. parent.AllAlternates, .. allAlternates];
      model.AllFields = [.. parent.AllFields, .. allFields];
    } else {
      model.AllAlternates = [.. allAlternates];
      model.AllFields = [.. allFields];
    }

    return model;
  }

  private Func<TFor, ObjectForModel<TFor>> NewObjectFor<TFor>(TModel model)
    where TFor : IModelBase
    => f => new ObjectForModel<TFor>(f, model.Name);

  protected override void ResolveParent(TModel model, IResolveContext context)
  {
    if (model.Parent?.Base.IsTypeParam == false) {
      base.ResolveParent(model, context);
    }
  }
}
