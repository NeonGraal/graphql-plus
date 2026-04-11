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

  internal IEncoderRepository Encoders { get; }

  protected TypeObjectEncoderBase()
  {
    Field = RFor<TField>();
    ForField = RFor<ObjectForModel<TField>>();
    DualField = RFor<ObjectForModel<DualFieldModel>>();
    Alternate = RFor<TAlt>();
    ForAlternate = RFor<ObjectForModel<TAlt>>();
    DualAlternate = RFor<ObjectForModel<AlternateModel>>();
    TypeParam = RFor<TypeParamModel>();

    IEncoderRepository encoders = A.Of<IEncoderRepository>();
    encoders.EncoderFor<ObjBaseModel>().Returns((IEncoder<ObjBaseModel>)(object)ObjBase);
    encoders.EncoderFor<TField>().Returns(Field);
    encoders.EncoderFor<ObjectForModel<TField>>().Returns(ForField);
    encoders.EncoderFor<ObjectForModel<DualFieldModel>>().Returns(DualField);
    encoders.EncoderFor<TAlt>().Returns(Alternate);
    encoders.EncoderFor<ObjectForModel<AlternateModel>>().Returns((IEncoder<ObjectForModel<AlternateModel>>)(object)ForAlternate);
    encoders.EncoderFor<TypeParamModel>().Returns(TypeParam);
    Encoders = encoders;
  }
}
