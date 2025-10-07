namespace GqlPlus.Resolving;

public class TypeInputResolverParentTests
  : ResolverTypeObjectParentTestBase<TypeInputModel, InputFieldModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverParentTests() => Resolver = new TypeInputResolver();

  protected override ObjBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
