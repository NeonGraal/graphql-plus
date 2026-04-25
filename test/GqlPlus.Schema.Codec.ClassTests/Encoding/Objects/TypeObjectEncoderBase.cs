using GqlPlus.Ast.Schema;

namespace GqlPlus.Encoding.Objects;

public abstract class TypeObjectEncoderBase<TObject, TBase, TField, TAlt>
  : ObjectBaseEncoderBase<TObject, TBase>
  where TObject : TypeObjectModel<TField>, IModelBase
  where TBase : IModelBase
  where TField : IObjFieldModel
  where TAlt : IModelBase
{
  protected IEncoder<TField> Field { get; }
  protected IEncoder<ObjectForModel<TField>> ForField { get; }
  protected IEncoder<ObjectForModel<DualFieldModel>> DualField { get; }
  protected IEncoder<TAlt> Alternate { get; }
  protected IEncoder<ObjectForModel<TAlt>> ForAlternate { get; }
  protected IEncoder<TypeParamModel> TypeParam { get; }

  internal IEncoderRepository Encoders { get; }

  protected TypeObjectEncoderBase()
  {
    Field = RFor<TField>();
    ForField = RFor<ObjectForModel<TField>>();
    DualField = RFor<ObjectForModel<DualFieldModel>>();
    Alternate = RFor<TAlt>();
    ForAlternate = RFor<ObjectForModel<TAlt>>();
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

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(NewObject(name, contents),
      TagAll($"_Type{ObjectKind}",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name,
      $":typeKind=[_TypeKind]{ObjectKind}"));

  [Theory, RepeatData]
  public void Encode_WithoutField_ReturnsStructured(string name, string parentType, string alternateType, string paramName)
  {
    ObjBaseModel parent = new(parentType, string.Empty);
    AlternateModel alternate = new(new ObjBaseModel(alternateType, string.Empty));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);
    TypeParamModel typeParam = new(paramName, string.Empty, default!);

    TObject model = NewObject(name, string.Empty) with {
      Parent = parent,
      Alternates = [alternate],
      AllAlternates = [alternateFor],
      TypeParams = [typeParam],
    };

    EncodeReturnsMap(ObjBase, "_Parent", parentType);
    EncodeReturnsMap(Alternate, "_Alternate", alternateType);
    EncodeReturnsMap(ForAlternate, "_AlternateFor", alternateType);
    EncodeReturnsMap(TypeParam, "_TypeParam", paramName);

    EncodeAndCheck(model,
      TagAll($"_Type{ObjectKind}",
      ":allAlternates.0:value=[_AlternateFor]" + alternateType.QuotedIdentifier(),
      ":alternates.0:value=[_Alternate]" + alternateType.QuotedIdentifier(),
      ":name=" + name,
      ":parent:value=[_Parent]" + parentType.QuotedIdentifier(),
      $":typeKind=[_TypeKind]{ObjectKind}",
      ":typeParams.0:value=[_TypeParam]" + paramName.QuotedIdentifier()));
  }

  [Theory, RepeatData]
  public void Encode_WithDualField_ReturnsStructured(string name, string fieldName, string fieldType)
  {
    DualFieldModel field = new(fieldName, new(fieldType, string.Empty), string.Empty);
    ObjectForModel<DualFieldModel> fieldFor = new(field, name);

    TObject model = NewObject(name, string.Empty) with {
      AllFields = [fieldFor],
    };

    EncodeReturnsMap(DualField, "_DualFieldFor", fieldName);

    EncodeAndCheck(model,
      TagAll($"_Type{ObjectKind}",
      ":allFields.0:value=[_DualFieldFor]" + fieldName.QuotedIdentifier(),
      ":name=" + name,
      $":typeKind=[_TypeKind]{ObjectKind}"));
  }

  [Theory, RepeatData]
  public void Encode_WithParent_ReturnsStructured(string name, string parentType)
  {
    ObjBaseModel parent = new(parentType, string.Empty);

    TObject model = NewObject(name, string.Empty) with {
      Parent = parent,
    };

    EncodeReturnsMap(ObjBase, "_Parent", parentType);

    EncodeAndCheck(model,
      TagAll($"_Type{ObjectKind}",
      ":name=" + name,
      ":parent:value=[_Parent]" + parentType.QuotedIdentifier(),
      $":typeKind=[_TypeKind]{ObjectKind}"));
  }

  [Theory, RepeatData]
  public void Encode_WithAlternate_ReturnsStructured(string name, string alternateType)
  {
    AlternateModel alternate = new(new ObjBaseModel(alternateType, string.Empty));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);

    TObject model = NewObject(name, string.Empty) with {
      Alternates = [alternate],
      AllAlternates = [alternateFor],
    };

    EncodeReturnsMap(Alternate, "_Alternate", alternateType);
    EncodeReturnsMap(ForAlternate, "_AlternateFor", alternateType);

    EncodeAndCheck(model,
            TagAll($"_Type{ObjectKind}",
      ":allAlternates.0:value=[_AlternateFor]" + alternateType.QuotedIdentifier(),
      ":alternates.0:value=[_Alternate]" + alternateType.QuotedIdentifier(),
      ":name=" + name,
      $":typeKind=[_TypeKind]{ObjectKind}"));
  }

  [Theory, RepeatData]
  public void Encode_WithTypeParam_ReturnsStructured(string name, string paramName)
  {
    TypeParamModel typeParam = new(paramName, string.Empty, default!);

    TObject model = NewObject(name, string.Empty) with {
      TypeParams = [typeParam],
    };

    EncodeReturnsMap(TypeParam, "_TypeParam", paramName);

    EncodeAndCheck(model,
      TagAll($"_Type{ObjectKind}",
      ":name=" + name,
      $":typeKind=[_TypeKind]{ObjectKind}",
      ":typeParams.0:value=[_TypeParam]" + paramName.QuotedIdentifier()));
  }

  protected abstract TObject NewObject(string name, string description);
  protected abstract TypeKind ObjectKind { get; }
}
