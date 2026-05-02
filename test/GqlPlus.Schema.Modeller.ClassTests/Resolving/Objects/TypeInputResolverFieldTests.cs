namespace GqlPlus.Resolving.Objects;

public class TypeInputResolverFieldTests
  : ResolverTypeObjectFieldTestBase<TypeInputModel, InputFieldModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverFieldTests()
  {
    IResolver<TypeDualModel> dualResolver = RFor<TypeDualModel>();
    IResolverRepository resolvers = A.Of<IResolverRepository>();
    ResolveForReturns(resolvers, dualResolver);
    Resolver = new TypeInputResolver(resolvers);
  }

  protected override ObjBaseModel MakeBase(string name, string description = "", params ITypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override InputFieldModel MakeField(FieldInput field)
    => new(field.Name, new(field.Type, ""), "");
  protected override InputFieldModel MakeModifierField(FieldInput field, ModifierModel modifier)
    => new(field.Name, new(field.Type, ""), "") { Modifiers = [modifier] };
  protected override InputFieldModel MakeParamField(FieldInput field, ModifierModel modifier)
    => new(field.Name, new(field.Type, "") { IsTypeParam = true }, "") { Modifiers = [modifier] };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ITypeArgModel NewArg(string argument, bool isParam = false)
    => new TypeArgModel(TypeKindModel.Input, argument, "") { IsTypeParam = isParam };
}
