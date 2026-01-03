namespace GqlPlus.Resolving.Objects;

public abstract class ResolverTypeObjectTypeTestBase<TModel, TField>
  : ResolverChildTypeTestBase<TModel, ObjBaseModel>
  where TModel : TypeObjectModel<TField>
  where TField : IObjFieldModel
{
  protected sealed override ObjBaseModel NewParent(string parent, string description)
    => MakeBase(parent, description);

  protected abstract ObjBaseModel MakeBase(string name, string description = "", params TypeArgModel[] args);
  protected abstract ObjBaseModel NewParam(string paramName);
  protected abstract TypeArgModel NewArg(string argument, bool isParam = false);
}
