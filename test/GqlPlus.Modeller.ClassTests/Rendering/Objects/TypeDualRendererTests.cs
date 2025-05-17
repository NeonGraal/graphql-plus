namespace GqlPlus.Rendering.Objects;

public class TypeDualRendererTests
  : RendererClassTestBase<TypeDualModel>
{
  private readonly IRenderer<DualBaseModel> _parent;
  private readonly IRenderer<DualFieldModel> _field;
  private readonly IRenderer<ObjectForModel<DualFieldModel>> _objField;
  private readonly IRenderer<ObjectForModel<DualFieldModel>> _dualField;
  private readonly IRenderer<DualAlternateModel> _alternate;
  private readonly IRenderer<ObjectForModel<DualAlternateModel>> _objAlternate;
  private readonly IRenderer<ObjectForModel<DualAlternateModel>> _dualAlternate;
  private readonly IRenderer<NamedModel> _typeParam;

  public TypeDualRendererTests()
  {
    _parent = RFor<DualBaseModel>();
    _field = RFor<DualFieldModel>();
    _objField = RFor<ObjectForModel<DualFieldModel>>();
    _dualField = RFor<ObjectForModel<DualFieldModel>>();
    _alternate = RFor<DualAlternateModel>();
    _objAlternate = RFor<ObjectForModel<DualAlternateModel>>();
    _dualAlternate = RFor<ObjectForModel<DualAlternateModel>>();
    _typeParam = RFor<NamedModel>();

    Renderer = new TypeDualRenderer(new(_parent, _field, _objField, _dualField, _alternate, _objAlternate, _dualAlternate, _typeParam));
  }

  protected override IRenderer<TypeDualModel> Renderer { get; }

  [Theory, RepeatData]
  public void Render_WithValidModel_ReturnsStructured(string name, string contents)
    => RenderAndCheck(new(name, contents), [
      "!_TypeDual",
      "description: " + contents.Quoted("'"),
      "name: " + name,
      "typeKind: !_TypeKind Dual"
      ]);
}
