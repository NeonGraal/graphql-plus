namespace GqlPlus.Encoding.Objects;

public class TypeDualEncoderTests
  : TypeObjectEncoderBase<TypeDualModel, ObjBaseModel, DualFieldModel, AlternateModel>
{
  public TypeDualEncoderTests()
    => Encoder = new TypeDualEncoder(new(ObjBase, Field, ForField, DualField, Alternate, ForAlternate, DualAlternate, TypeParam));

  protected override IEncoder<TypeDualModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(new(name, contents),
      TagAll("_TypeDual",
      ":description=" + contents.QuotedIdentifier(),
      ":name=" + name,
      ":typeKind=[_TypeKind]Dual"));

  [Theory, RepeatData]
  public void Encode_WithAllModel_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string paramName, string description)
  {
    ObjBaseModel parent = new(parentType, description);
    AlternateModel alternate = new(new ObjBaseModel(alternateType, description));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);
    DualFieldModel field = new(fieldName, null, description);
    ObjectForModel<DualFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, description, default!);

    TypeDualModel model = new(name, description) {
      Parent = parent,
      Alternates = [alternate],
      AllAlternates = [alternateFor],
      Fields = [field],
      AllFields = [fieldFor],
      TypeParams = [typeParam],
    };

    EncodeReturnsMap(ObjBase, "_Parent", parentType);
    EncodeReturnsMap(Alternate, "_Alternate", alternateType);
    EncodeReturnsMap(ForAlternate, "_AlternateFor", alternateType);
    EncodeReturnsMap(Field, "_Field", fieldName);
    EncodeReturnsMap(ForField, "_FieldFor", fieldName);
    EncodeReturnsMap(TypeParam, "_TypeParam", paramName);

    EncodeAndCheck(model,
      TagAll("_TypeDual",
      ":allAlternates.0:value=[_AlternateFor]" + alternateType.QuotedIdentifier(),
      ":allFields.0:value=[_FieldFor]" + fieldName.QuotedIdentifier(),
      ":alternates.0:value=[_Alternate]" + alternateType.QuotedIdentifier(),
      ":fields.0:value=[_Field]" + fieldName.QuotedIdentifier(),
      ":name=" + name,
      ":parent:value=[_Parent]" + parentType.QuotedIdentifier(),
      ":typeKind=[_TypeKind]Dual",
      ":typeParams.0:value=[_TypeParam]" + paramName.QuotedIdentifier()));
  }

  [Theory, RepeatData]
  public void Encode_WithInvalidFieldModel_ThrowsInValidCastException(string name, string fieldName)
  {
    DualFieldModel field = new(fieldName, null, "");
    ObjectForModel<InputFieldModel> fieldFor = new(new(fieldName, null, ""), name);

    TypeDualModel model = new(name, "") {
      Fields = [field],
      AllFields = [fieldFor],
    };

    EncodeReturnsMap(Field, "_Field", fieldName);
    EncodeReturnsMap(ForField, "_FieldFor", fieldName);

    Action act = () => Encoder.Encode(model);

    act.ShouldThrow<InvalidCastException>();
  }
}
