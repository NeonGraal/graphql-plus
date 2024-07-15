namespace GqlPlus.Resolving;

internal class TypeInputResolver
    : ResolverTypeObjectType<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel>
{
  protected override string? ParentName(TypeInputModel model)
    => model.Parent?.Base.Input;
}
