namespace GqlPlus.Rendering.Objects;

public abstract class TypeObjectRendererBase<TObject, TBase, TField, TAlt>
  : ObjectBaseRendererBase<TObject, TBase>
  where TObject : class, ITypeObjectModel, IModelBase
  where TBase : IModelBase
  where TField : IModelBase
  where TAlt : IModelBase
{
  protected IRenderer<TField> Field { get; }
  protected IRenderer<ObjectForModel<TField>> ObjField { get; }
  protected IRenderer<ObjectForModel<DualFieldModel>> DualField { get; }
  protected IRenderer<TAlt> Alternate { get; }
  protected IRenderer<ObjectForModel<TAlt>> ObjAlternate { get; }
  protected IRenderer<ObjectForModel<DualAlternateModel>> DualAlternate { get; }
  protected IRenderer<NamedModel> TypeParam { get; }

  protected TypeObjectRendererBase()
  {
    Field = RFor<TField>();
    ObjField = RFor<ObjectForModel<TField>>();
    DualField = RFor<ObjectForModel<DualFieldModel>>();
    Alternate = RFor<TAlt>();
    ObjAlternate = RFor<ObjectForModel<TAlt>>();
    DualAlternate = RFor<ObjectForModel<DualAlternateModel>>();
    TypeParam = RFor<NamedModel>();
  }
}
