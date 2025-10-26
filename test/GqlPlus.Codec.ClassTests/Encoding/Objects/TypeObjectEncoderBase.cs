namespace GqlPlus.Encoding.Objects;

public abstract class TypeObjectEncoderBase<TObject, TBase, TField, TAlt>
  : ObjectBaseEncoderBase<TObject, TBase>
  where TObject : class, ITypeObjectModel, IModelBase
  where TBase : IModelBase
  where TField : IModelBase
  where TAlt : IModelBase
{
  protected IEncoder<TField> Field { get; }
  protected IEncoder<ObjectForModel<TField>> ForField { get; }
  protected IEncoder<ObjectForModel<DualFieldModel>> DualField { get; }
  protected IEncoder<TAlt> Alternate { get; }
  protected IEncoder<ObjectForModel<TAlt>> ForAlternate { get; }
  protected IEncoder<ObjectForModel<AlternateModel>> DualAlternate { get; }
  protected IEncoder<TypeParamModel> TypeParam { get; }

  protected TypeObjectEncoderBase()
  {
    Field = RFor<TField>();
    ForField = RFor<ObjectForModel<TField>>();
    DualField = RFor<ObjectForModel<DualFieldModel>>();
    Alternate = RFor<TAlt>();
    ForAlternate = RFor<ObjectForModel<TAlt>>();
    DualAlternate = RFor<ObjectForModel<AlternateModel>>();
    TypeParam = RFor<TypeParamModel>();
  }
}
