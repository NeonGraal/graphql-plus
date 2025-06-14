namespace GqlPlus.Rendering.Objects;

public class TypeDualRendererTests
  : TypeObjectRendererBase<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>
{
  public TypeDualRendererTests()
    => Renderer = new TypeDualRenderer(new(ObjBase, Field, ObjField, DualField, Alternate, ObjAlternate, DualAlternate, TypeParam));

  protected override IRenderer<TypeDualModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeDual",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Dual"
      ]);

  [Theory, RepeatData]
  public void Render_WithAllModel_ReturnsStructured(string name, string parentType, string alternateType, string fieldName, string paramName)
  {
    DualBaseModel parent = new(parentType, "");
    DualAlternateModel alternate = new(new DualBaseModel(alternateType, ""));
    ObjectForModel<DualAlternateModel> alternateFor = new(alternate, name);
    DualFieldModel field = new(fieldName, null, "");
    ObjectForModel<DualFieldModel> fieldFor = new(field, name);
    TypeParamModel typeParam = new(paramName, "");

    TypeDualModel model = new(name, "") {
      Parent = parent,
      Alternates = [alternate],
      AllAlternates = [alternateFor],
      Fields = [field],
      AllFields = [fieldFor],
      TypeParams = [typeParam],
    };

    RenderReturnsMap(ObjBase, "_Parent", parentType);
    RenderReturnsMap(Alternate, "_Alternate", alternateType);
    RenderReturnsMap(ObjAlternate, "_AlternateFor", alternateType);
    RenderReturnsMap(Field, "_Field", fieldName);
    RenderReturnsMap(ObjField, "_FieldFor", fieldName);
    RenderReturnsMap(TypeParam, "_TypeParam", paramName);

    RenderAndCheck(model, [
      "!_TypeDual",
      "allAlternates:", "  -", $"    value: !_AlternateFor '{alternateType}'",
      "allFields:", "  -", $"    value: !_FieldFor '{fieldName}'",
      "alternates:", "  -", $"    value: !_Alternate '{alternateType}'",
      "fields:", "  -", $"    value: !_Field '{fieldName}'",
      "name: " + name,
      "parent:", $"  value: !_Parent '{parentType}'",
      "typeKind: !_TypeKind Dual",
      "typeParams:", "  -", $"    value: !_TypeParam '{paramName}'"
      ]);
  }
}
