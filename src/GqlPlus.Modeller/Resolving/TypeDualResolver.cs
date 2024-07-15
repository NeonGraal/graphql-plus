namespace GqlPlus.Resolving;

internal class TypeDualResolver
    : ResolverTypeObjectType<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel>
{
  protected override string? ParentName(TypeDualModel model)
    => model.Parent?.Base.Dual;
}
