using GqlPlus.Ast.Schema;

namespace GqlPlus.Encoding.Objects;

public class TypeOutputEncoderTests
  : TypeObjectEncoderBase<TypeOutputModel, ObjBaseModel, OutputFieldModel, AlternateModel>
{
  public TypeOutputEncoderTests()
    => Encoder = new TypeOutputEncoder(Encoders);

  [Theory, RepeatData]
  public void Encode_WithAll_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string fieldType, string paramName)
  {
    ObjBaseModel parent = new(parentType, string.Empty);
    AlternateModel alternate = new(new ObjBaseModel(alternateType, string.Empty));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);
    OutputFieldModel field = new(fieldName, new(fieldType, string.Empty), string.Empty);
    ObjectForModel<OutputFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, string.Empty, default!);

    TypeOutputModel model = new(name, string.Empty) {
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
      TagAll("_TypeOutput",
      ":allAlternates.0:value=[_AlternateFor]" + alternateType.QuotedIdentifier(),
      ":allFields.0:value=[_FieldFor]" + fieldName.QuotedIdentifier(),
      ":alternates.0:value=[_Alternate]" + alternateType.QuotedIdentifier(),
      ":fields.0:value=[_Field]" + fieldName.QuotedIdentifier(),
      ":name=" + name,
      ":parent:value=[_Parent]" + parentType.QuotedIdentifier(),
      ":typeKind=[_TypeKind]Output",
      ":typeParams.0:value=[_TypeParam]" + paramName.QuotedIdentifier()));
  }

  [Theory, RepeatData]
  public void Encode_WithOutputField_ReturnsStructured(string name, string fieldName, string fieldType)
  {
    OutputFieldModel field = new(fieldName, new(fieldType, string.Empty), string.Empty);
    ObjectForModel<OutputFieldModel> fieldFor = new(field, name);

    TypeOutputModel model = new(name, string.Empty) {
      Fields = [new(fieldName, new(fieldType, string.Empty), string.Empty)],
      AllFields = [fieldFor],
    };

    EncodeReturnsMap(Field, "_Field", fieldName);
    EncodeReturnsMap(ForField, "_FieldFor", fieldName);

    EncodeAndCheck(model,
      TagAll("_TypeOutput",
      ":allFields.0:value=[_FieldFor]" + fieldName.QuotedIdentifier(),
      ":fields.0:value=[_Field]" + fieldName.QuotedIdentifier(),
      ":name=" + name,
      ":typeKind=[_TypeKind]Output"));
  }

  protected override IEncoder<TypeOutputModel> Encoder { get; }
  protected override TypeKind ObjectKind => TypeKind.Output;

  protected override TypeOutputModel NewObject(string name, string description)
    => new(name, description);
}
