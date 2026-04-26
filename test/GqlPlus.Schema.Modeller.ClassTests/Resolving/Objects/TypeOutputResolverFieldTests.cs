namespace GqlPlus.Resolving.Objects;

public class TypeOutputResolverFieldTests
  : ResolverTypeObjectFieldTestBase<TypeOutputModel, OutputFieldModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverFieldTests()
  {
    IResolver<TypeDualModel> dualResolver = RFor<TypeDualModel>();
    IResolverRepository resolvers = A.Of<IResolverRepository>();
    resolvers.ResolverFor<TypeDualModel>().Returns(dualResolver);
    Resolver = new TypeOutputResolver(resolvers);
  }

  protected override ObjBaseModel MakeBase(string name, string description = "", params ITypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override OutputFieldModel MakeField(FieldInput field)
    => new(field.Name, new(field.Type, ""), "");
  protected override OutputFieldModel MakeModifierField(FieldInput field, ModifierModel modifier)
        => new(field.Name, new(field.Type, ""), "") { Modifiers = [modifier] };
  protected override OutputFieldModel MakeParamField(FieldInput field, ModifierModel modifier)
    => new(field.Name, new(field.Type, "") { IsTypeParam = true }, "") { Modifiers = [modifier] };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override ObjBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ITypeArgModel NewArg(string argument, bool isParam = false)
    => new TypeArgModel(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
