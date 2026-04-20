using GqlPlus.Ast.Schema;

namespace GqlPlus.Encoding.Objects;

public class TypeInputEncoderTests
  : TypeObjectEncoderBase<TypeInputModel, ObjBaseModel, InputFieldModel, AlternateModel>
{
  public TypeInputEncoderTests()
    => Encoder = new TypeInputEncoder(Encoders);

  [Theory, RepeatData]
  public void Encode_WithAll_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string fieldType, string paramName)
  {
    ObjBaseModel parent = new(parentType, string.Empty);
    AlternateModel alternate = new(new ObjBaseModel(alternateType, string.Empty));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);
    InputFieldModel field = new(fieldName, new(fieldType, string.Empty), string.Empty);
    ObjectForModel<InputFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, string.Empty, default!);

    TypeInputModel model = new(name, string.Empty) {
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
      TagAll("_TypeInput",
      ":allAlternates.0:value=[_AlternateFor]" + alternateType.QuotedIdentifier(),
      ":allFields.0:value=[_FieldFor]" + fieldName.QuotedIdentifier(),
      ":alternates.0:value=[_Alternate]" + alternateType.QuotedIdentifier(),
      ":fields.0:value=[_Field]" + fieldName.QuotedIdentifier(),
      ":name=" + name,
      ":parent:value=[_Parent]" + parentType.QuotedIdentifier(),
      ":typeKind=[_TypeKind]Input",
      ":typeParams.0:value=[_TypeParam]" + paramName.QuotedIdentifier()));
  }

  [Theory, RepeatData]
  public void Encode_WithInputField_ReturnsStructured(string name, string fieldName, string fieldType)
  {
    InputFieldModel field = new(fieldName, new(fieldType, string.Empty), string.Empty);
    ObjectForModel<InputFieldModel> fieldFor = new(field, name);

    TypeInputModel model = new(name, string.Empty) {
      Fields = [new(fieldName, new(fieldType, string.Empty), string.Empty)],
      AllFields = [fieldFor],
    };

    EncodeReturnsMap(Field, "_Field", fieldName);
    EncodeReturnsMap(ForField, "_FieldFor", fieldName);

    EncodeAndCheck(model,
      TagAll("_TypeInput",
      ":allFields.0:value=[_FieldFor]" + fieldName.QuotedIdentifier(),
      ":fields.0:value=[_Field]" + fieldName.QuotedIdentifier(),
      ":name=" + name,
      ":typeKind=[_TypeKind]Input"));
  }

  protected override IEncoder<TypeInputModel> Encoder { get; }
  protected override TypeKind ObjectKind => TypeKind.Input;

  protected override TypeInputModel NewObject(string name, string description)
    => new(name, description);
}
