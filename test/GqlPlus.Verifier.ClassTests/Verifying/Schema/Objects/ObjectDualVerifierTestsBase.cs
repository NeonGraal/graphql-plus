namespace GqlPlus.Verifying.Schema.Objects;

public abstract class ObjectDualVerifierTestsBase<TObject, TBase, TField, TAlt, TArg>
  : ObjectVerifierTestsBase<TObject, TBase, TField, TAlt, TArg>
  where TObject : class, IGqlpObject<TBase, TField, TAlt>
  where TBase : class, IGqlpObjBase<TArg>, IGqlpToDual<IGqlpDualBase>
  where TField : class, IGqlpObjField<TBase>
  where TAlt : class, IGqlpObjAlternate<TArg>
  where TArg : class, IGqlpObjArg
{
  protected IGqlpDualObject DefineDual(string name, string parent = "", bool isTypeParam = false)
  {
    IGqlpDualObject obj = A.Obj<IGqlpDualObject, IGqlpDualBase>(name, parent, isTypeParam);
    Definitions.Add(obj);
    return obj;
  }
}
