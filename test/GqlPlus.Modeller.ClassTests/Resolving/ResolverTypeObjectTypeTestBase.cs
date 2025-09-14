namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectTypeTestBase<TModel, TBase, TField, TAlt>
  : ResolverChildTypeTestBase<TModel, TBase>
  where TModel : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
{
  protected sealed override TBase NewParent(string parent, string description)
    => MakeBase(parent, description);

  protected abstract TBase MakeBase(string name, string description = "", params ObjTypeArgModel[] args);
  protected abstract TBase NewParam(string paramName);
  protected abstract ObjTypeArgModel NewArg(string argument, bool isParam = false);
}
