namespace GqlPlus.Encoding.Objects;

public class TypeInputEncoderTests
  : TypeObjectEncoderBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
  public TypeInputEncoderTests()
    => Encoder = new TypeInputEncoder(new(ObjBase, Field, ObjField, DualField, Alternate, ObjAlternate, DualAlternate, TypeParam));

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
    DualBaseModel parent = new(parentType, "");
    DualAlternateModel alternate = new(new DualBaseModel(alternateType, ""));
    ObjectForModel<DualAlternateModel> alternateFor = new(alternate, name);
    DualFieldModel field = new(fieldName, new("", ""), "");
    ObjectForModel<DualFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, "", default!);

    TypeInputModel model = new(name, "") {
      Parent = new("", "") { Dual = parent },
      Alternates = [new(null!) { Dual = alternate }],
      AllAlternates = [alternateFor],
      Fields = [new("", new("", "") { Dual = field.Type }, "")],
      AllFields = [fieldFor],
      TypeParams = [typeParam],
    };

    EncodeReturnsMap(ObjBase, "_Parent", parentType);
    EncodeReturnsMap(Alternate, "_Alternate", alternateType);
    EncodeReturnsMap(DualAlternate, "_DualAlternate", alternateType);
    EncodeReturnsMap(ObjAlternate, "_AlternateFor", alternateType);
    EncodeReturnsMap(Field, "_Field", fieldName);
    EncodeReturnsMap(DualField, "_DualField", fieldName);
    EncodeReturnsMap(ObjField, "_FieldFor", fieldName);
    EncodeReturnsMap(TypeParam, "_TypeParam", paramName);

    EncodeAndCheck(model, [
      "!_TypeInput",
      "allAlternates:", "  -", $"    value: !_DualAlternate '{alternateType}'",
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
