namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectDualVerifierTestsBase<TObject, TField>
  : ObjectVerifierTestsBase<TObject, TField>
  where TObject : class, IGqlpObject<TField>
  where TField : class, IGqlpObjField
{
  protected IGqlpDualObject DefineDual(string name, string parent = "", bool isTypeParam = false)
  {
    IGqlpDualObject obj = A.Obj<IGqlpDualObject>(name, parent, isTypeParam);
    Definitions.Add(obj);
    return obj;
  }
}
