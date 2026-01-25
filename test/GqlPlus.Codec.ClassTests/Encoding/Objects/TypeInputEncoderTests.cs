namespace GqlPlus.Encoding.Objects;

public class TypeInputEncoderTests
  : TypeObjectEncoderBase<TypeInputModel, ObjBaseModel, InputFieldModel, AlternateModel>
{
  public TypeInputEncoderTests()
    => Encoder = new TypeInputEncoder(new(ObjBase, Field, ForField, DualField, Alternate, ForAlternate, DualAlternate, TypeParam));

  protected override IEncoder<TypeInputModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(new(name, contents),
      TagAll("_TypeInput",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name,
      ":typeKind=[_TypeKind]Input"));

  [Theory, RepeatData]
  public void Encode_WithDualModel_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string paramName)
  {
    ObjBaseModel parent = new(parentType, string.Empty);
    AlternateModel alternate = new(new ObjBaseModel(alternateType, string.Empty));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);
    DualFieldModel field = new(fieldName, new(string.Empty, string.Empty), string.Empty);
    ObjectForModel<DualFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, string.Empty, default!);

    TypeInputModel model = new(name, string.Empty) {
      Parent = new(string.Empty, string.Empty),
      Alternates = [new(null!)],
      AllAlternates = [alternateFor],
      Fields = [new(string.Empty, new(string.Empty, string.Empty), string.Empty)],
      AllFields = [fieldFor],
      TypeParams = [typeParam],
    };

    EncodeReturnsMap(ObjBase, "_Parent", parentType);
    EncodeReturnsMap(Alternate, "_Alternate", alternateType);
    EncodeReturnsMap(DualAlternate, "_DualAlternate", alternateType);
    EncodeReturnsMap(ForAlternate, "_AlternateFor", alternateType);
    EncodeReturnsMap(Field, "_Field", fieldName);
    EncodeReturnsMap(DualField, "_DualField", fieldName);
    EncodeReturnsMap(ForField, "_FieldFor", fieldName);
    EncodeReturnsMap(TypeParam, "_TypeParam", paramName);

    EncodeAndCheck(model,
      TagAll("_TypeInput",
      ":allAlternates.0:value=[_AlternateFor]" + alternateType.QuotedIdentifier(),
      ":allFields.0:value=[_DualField]" + fieldName.QuotedIdentifier(),
      ":alternates.0:value=[_Alternate]" + alternateType.QuotedIdentifier(),
      ":fields.0:value=[_Field]" + fieldName.QuotedIdentifier(),
      ":name=" + name,
      ":parent:value=[_Parent]" + parentType.QuotedIdentifier(),
      ":typeKind=[_TypeKind]Input",
      ":typeParams.0:value=[_TypeParam]" + paramName.QuotedIdentifier()));
  }
}
