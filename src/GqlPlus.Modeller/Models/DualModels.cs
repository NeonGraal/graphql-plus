namespace GqlPlus.Models;

public record class TypeDualModel(
  string Name
) : TypeObjectModel<DualBaseModel, DualFieldModel>(TypeKindModel.Dual, Name)
{
  protected override string? ParentName(BaseDescribedModel<DualBaseModel>? parent)
    => parent?.Base.Dual;
}

public record class DualBaseModel(
  string Dual
) : ObjBaseModel<DualBaseModel>
{
  internal override RenderStructure Render(IRenderContext context)
    => IsTypeParameter
    ? new(Dual, "_TypeParameter")
    : base.Render(context)
      .Add("dual", Dual);
}

public record class DualFieldModel(
  string Name,
  DualBaseModel Type
) : ObjFieldModel<DualBaseModel>(Name, Type)
{ }
