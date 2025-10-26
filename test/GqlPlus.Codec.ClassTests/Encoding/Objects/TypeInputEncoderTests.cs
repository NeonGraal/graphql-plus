﻿namespace GqlPlus.Encoding.Objects;

public class TypeInputEncoderTests
  : TypeObjectEncoderBase<TypeInputModel, ObjBaseModel, InputFieldModel, AlternateModel>
{
  public TypeInputEncoderTests()
    => Encoder = new TypeInputEncoder(new(ObjBase, Field, ForField, DualField, Alternate, ForAlternate, DualAlternate, TypeParam));

  protected override IEncoder<TypeInputModel> Encoder { get; }

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(string name, string contents)
    => EncodeAndCheck(new(name, contents), [
      "!_TypeInput",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Input"
      ]);

  [Theory, RepeatData]
  public void Encode_WithDualModel_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string paramName)
  {
    ObjBaseModel parent = new(parentType, "");
    AlternateModel alternate = new(new ObjBaseModel(alternateType, ""));
    ObjectForModel<AlternateModel> alternateFor = new(alternate, name);
    DualFieldModel field = new(fieldName, new("", ""), "");
    ObjectForModel<DualFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, "", default!);

    TypeInputModel model = new(name, "") {
      Parent = new("", ""),
      Alternates = [new(null!)],
      AllAlternates = [alternateFor],
      Fields = [new("", new("", ""), "")],
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

    EncodeAndCheck(model, [
      "!_TypeInput",
      "allAlternates:", "  -", $"    value: !_AlternateFor '{alternateType}'",
      "allFields:", "  -", $"    value: !_DualField '{fieldName}'",
      "alternates:", "  -", $"    value: !_Alternate '{alternateType}'",
      "fields:", "  -", $"    value: !_Field '{fieldName}'",
      "name: " + name,
      "parent:", $"  value: !_Parent '{parentType}'",
      "typeKind: !_TypeKind Input",
      "typeParams:", "  -", $"    value: !_TypeParam '{paramName}'"
      ]);
  }
}
