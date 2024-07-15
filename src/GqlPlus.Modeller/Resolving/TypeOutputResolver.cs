namespace GqlPlus.Resolving;

internal class TypeOutputResolver
    : ResolverTypeObjectType<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel>
{
  protected override string? ParentName(TypeOutputModel model)
    => model.Parent?.Base.Output;
}
