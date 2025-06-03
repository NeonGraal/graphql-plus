namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectTypeTestBase<TModel, TBase, TField, TAlt, TArg>
  : ResolverChildTypeTestBase<TModel, TBase>
  where TModel : TypeObjectModel<TBase, TField, TAlt>
  where TBase : IObjBaseModel
  where TField : IObjFieldModel
  where TAlt : IObjAlternateModel
  where TArg : IObjTypeArgModel
{
  protected sealed override TBase NewParent(string parent, string description)
    => MakeBase(parent, description);

  protected abstract TBase MakeBase(string name, string description = "", params TArg[] args);
  protected abstract TBase NewParam(string paramName);
  protected abstract TArg NewArg(string argument, bool isParam = false);
}
