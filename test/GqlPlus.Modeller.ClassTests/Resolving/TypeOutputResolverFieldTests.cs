namespace GqlPlus.Resolving;

public class TypeOutputResolverFieldTests
  : ResolverTypeObjectFieldTestBase<TypeOutputModel, OutputBaseModel, OutputFieldModel, OutputAlternateModel, ObjTypeArgModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverFieldTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeOutputResolver(dual);
  }

  protected override OutputBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
    => new(name, description) { Args = args };
  protected override OutputFieldModel MakeField(FieldInput field)
    => new(field.Name, new(field.Type, ""), "");
  protected override OutputFieldModel MakeModifierField(FieldInput field, ModifierModel modifier)
        => new(field.Name, new(field.Type, ""), "") { Modifiers = [modifier] };
  protected override OutputFieldModel MakeParamField(FieldInput field, ModifierModel modifier)
    => new(field.Name, new(field.Type, "") { IsTypeParam = true }, "") { Modifiers = [modifier] };
  protected override TypeOutputModel NewModel(string name, string description)
    => new(name, description);
  protected override OutputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
