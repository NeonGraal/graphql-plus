namespace GqlPlus.Resolving;

public abstract class ResolverTypeObjectTypeTestBase<TModel, TField>
  : ResolverChildTypeTestBase<TModel, ObjBaseModel>
  where TModel : TypeObjectModel<TField>
  where TField : IObjFieldModel
{
  protected sealed override ObjBaseModel NewParent(string parent, string description)
    => MakeBase(parent, description);

  protected abstract ObjBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args);
  protected abstract ObjBaseModel NewParam(string paramName);
  protected abstract ObjTypeArgModel NewArg(string argument, bool isParam = false);
}
