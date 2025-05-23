namespace GqlPlus.Resolving;

public class TypeDualResolverFieldTests
  : ResolverTypeObjectFieldTestBase<TypeDualModel, DualBaseModel, DualFieldModel, DualAlternateModel, DualArgModel>
{
  protected override IResolver<TypeDualModel> Resolver { get; } = new TypeDualResolver();

  protected override DualBaseModel MakeBase(string name, string description = "", params DualArgModel[] args)
    => new(name, description) { Args = args };
  protected override DualFieldModel MakeField(FieldInput field)
    => new(field.Name, new(field.Type, ""), "");
  protected override DualFieldModel MakeModifierField(FieldInput field, ModifierModel modifier)
    => new(field.Name, new(field.Type, ""), "") { Modifiers = [modifier] };
  protected override DualFieldModel MakeParamField(FieldInput field)
    => new(field.Name, new(field.Type, "") { IsTypeParam = true }, "");
  protected override DualArgModel NewArg(string argument, bool isParam = false)
    => new(argument, "") { IsTypeParam = isParam };
  protected override TypeDualModel NewModel(string name, string description)
    => new(name, description);
  protected override DualBaseModel NewParam(string paramName)
    => new(paramName, "") { IsTypeParam = true };
}
