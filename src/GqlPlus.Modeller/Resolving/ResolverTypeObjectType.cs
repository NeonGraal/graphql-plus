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

    IEnumerable<ObjectForModel> allAlternates = Apply(model.Alternates, ObjectAlt(model.Name));
    IEnumerable<ObjectForModel> allFields = Apply(model.Fields, ObjectField(model.Name));

    model.AllAlternates = [.. ParentAlternatives(model.ParentModel), .. allAlternates];
    model.AllFields = [.. ParentFields(model.ParentModel), .. allFields];

    return model;
  }

  protected override void ResolveParent(TModel model, IResolveContext context)
  {
    if (model.Parent?.Base.IsTypeParam == false) {
      base.ResolveParent(model, context);
    }
  }

  protected delegate ObjectForModel<TFor> MakeFor<TFor>(TFor obj)
    where TFor : IModelBase;

  protected IEnumerable<ObjectForModel> Apply<TFor>(IEnumerable<TFor> list, MakeFor<TFor> convert)
    where TFor : IModelBase
    => list.Select(f => convert(f));

  protected abstract MakeFor<TObjAlt> ObjectAlt(string obj);
  protected abstract MakeFor<TObjField> ObjectField(string obj);
  protected abstract IEnumerable<ObjectForModel> ParentAlternatives(IModelBase? parent);
  protected abstract IEnumerable<ObjectForModel> ParentFields(IModelBase? parent);
}
