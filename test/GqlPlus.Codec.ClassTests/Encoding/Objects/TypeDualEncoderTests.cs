namespace GqlPlus.Encoding.Objects;

public class TypeDualEncoderTests
  : TypeObjectEncoderBase<TypeDualModel, ObjBaseModel, DualFieldModel, AlternateModel>
{
  public TypeDualEncoderTests()
    => Encoder = new TypeDualEncoder(new(ObjBase, Field, ForField, DualField, Alternate, ForAlternate, DualAlternate, TypeParam));

  protected override IEncoder<TypeDualModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(new(name, contents), [
      "!_TypeDual",
      "description: " + contents.QuotedIdentifier(),
      "name: " + name,
      "typeKind: !_TypeKind Dual"
      ]);

  [Theory, RepeatData]
  public void Encode_WithAllModel_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string paramName)
  {
    ObjBaseModel parent = new(parentType, "");
    AlternateModel alternate = new(new ObjBaseModel(alternateType, ""));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);
    DualFieldModel field = new(fieldName, null, "");
    ObjectForModel<DualFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, "", default!);

    TypeDualModel model = new(name, "") {
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

    EncodeAndCheck(model, [
      "!_TypeDual",
      "allAlternates:", "  -", $"    value: !_AlternateFor " + alternateType.QuotedIdentifier(),
      "allFields:", "  -", $"    value: !_FieldFor " + fieldName.QuotedIdentifier(),
      "alternates:", "  -", $"    value: !_Alternate " + alternateType.QuotedIdentifier(),
      "fields:", "  -", $"    value: !_Field " + fieldName.QuotedIdentifier(),
      "name: " + name,
      "parent:", $"  value: !_Parent " + parentType.QuotedIdentifier(),
      "typeKind: !_TypeKind Dual",
      "typeParams:", "  -", $"    value: !_TypeParam " + paramName.QuotedIdentifier()
      ]);
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
