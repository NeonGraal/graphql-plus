namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectDualVerifierTestsBase<TObject, TField>(
  TypeKind kind
) : ObjectVerifierTestsBase<TObject, TField>(kind)
  where TObject : class, IGqlpObject<TField>
  where TField : class, IGqlpObjField
{
  protected IGqlpDualObject DefineDual(string name, string parent = "", bool isTypeParam = false)
  {
    IGqlpDualObject obj = A.Obj<IGqlpDualObject>(TypeKind.Dual, name, parent, isTypeParam);
    Definitions.Add(obj);
    return obj;
  }
}
