namespace GqlPlus.Encoding.Objects;

public abstract class TypeObjectEncoderBase<TObject, TBase, TField, TAlt>
  : ObjectBaseEncoderBase<TObject, TBase>
  where TObject : class, ITypeObjectModel, IModelBase
  where TBase : IModelBase
  where TField : IModelBase
  where TAlt : IModelBase
{
  protected IEncoder<TField> Field { get; }
  protected IEncoder<ObjectForModel<TField>> ObjField { get; }
  protected IEncoder<ObjectForModel<DualFieldModel>> DualField { get; }
  protected IEncoder<TAlt> Alternate { get; }
  protected IEncoder<ObjectForModel<TAlt>> ObjAlternate { get; }
  protected IEncoder<ObjectForModel<DualAlternateModel>> DualAlternate { get; }
  protected IEncoder<TypeParamModel> TypeParam { get; }

  protected TypeObjectEncoderBase()
  {
    Field = RFor<TField>();
    ObjField = RFor<ObjectForModel<TField>>();
    DualField = RFor<ObjectForModel<DualFieldModel>>();
    Alternate = RFor<TAlt>();
    ObjAlternate = RFor<ObjectForModel<TAlt>>();
    DualAlternate = RFor<ObjectForModel<DualAlternateModel>>();
    TypeParam = RFor<TypeParamModel>();
  }
}
