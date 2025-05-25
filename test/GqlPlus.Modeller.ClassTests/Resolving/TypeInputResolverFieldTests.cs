namespace GqlPlus.Resolving;

public class TypeInputResolverFieldTests
  : ResolverTypeObjectFieldTestBase<TypeInputModel, InputBaseModel, InputFieldModel, InputAlternateModel, InputArgModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverFieldTests()
  {
    IResolver<TypeDualModel> dual = RFor<TypeDualModel>();
    Resolver = new TypeInputResolver(dual);
  }

  protected override InputBaseModel MakeBase(string name, string description = "", params InputArgModel[] args)
    => new(name, description) { Args = args };
  protected override InputFieldModel MakeField(FieldInput field)
    => new(field.Name, new(field.Type, ""), "");
  protected override InputFieldModel MakeModifierField(FieldInput field, ModifierModel modifier)
    => new(field.Name, new(field.Type, ""), "") { Modifiers = [modifier] };
  protected override InputFieldModel MakeParamField(FieldInput field, ModifierModel modifier)
    => new(field.Name, new(field.Type, "") { IsTypeParam = true }, "") { Modifiers = [modifier] };
  protected override TypeInputModel NewModel(string name, string description)
    => new(name, description);
  protected override InputBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
  protected override InputArgModel NewArg(string argument, bool isParam = false)
    => new(argument, "") { IsTypeParam = isParam };
}
