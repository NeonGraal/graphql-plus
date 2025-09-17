namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectDualVerifierTestsBase<TObject, TBase, TField, TAlt>
  : ObjectVerifierTestsBase<TObject, TBase, TField, TAlt>
  where TObject : class, IGqlpObject<TBase, TField, TAlt>
  where TBase : class, IGqlpObjBase, IGqlpToDual<IGqlpDualBase>
  where TField : class, IGqlpObjField<TBase>
  where TAlt : class, IGqlpObjAlternate
{
  protected IGqlpDualObject DefineDual(string name, string parent = "", bool isTypeParam = false)
  {
    IGqlpDualObject obj = A.Obj<IGqlpDualObject, IGqlpDualBase>(name, parent, isTypeParam);
    Definitions.Add(obj);
    return obj;
  }
}
