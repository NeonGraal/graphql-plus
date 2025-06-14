namespace GqlPlus.Rendering.Objects;

public class TypeInputRendererTests
  : TypeObjectRendererBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
  public TypeInputRendererTests()
    => Renderer = new TypeInputRenderer(new(ObjBase, Field, ObjField, DualField, Alternate, ObjAlternate, DualAlternate, TypeParam));

  protected override IRenderer<TypeInputModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeInput",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Input"
      ]);

  [Theory, RepeatData]
  public void Render_WithDualModel_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string paramName)
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

    RenderReturnsMap(ObjBase, "_Parent", parentType);
    RenderReturnsMap(Alternate, "_Alternate", alternateType);
    RenderReturnsMap(DualAlternate, "_DualAlternate", alternateType);
    RenderReturnsMap(ObjAlternate, "_AlternateFor", alternateType);
    RenderReturnsMap(Field, "_Field", fieldName);
    RenderReturnsMap(DualField, "_DualField", fieldName);
    RenderReturnsMap(ObjField, "_FieldFor", fieldName);
    RenderReturnsMap(TypeParam, "_TypeParam", paramName);

    RenderAndCheck(model, [
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
