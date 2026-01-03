namespace GqlPlus.Resolving.Objects;

public class TypeOutputResolverFieldTests
  : ResolverTypeObjectFieldTestBase<TypeOutputModel, OutputFieldModel>
{
  protected override IResolver<TypeOutputModel> Resolver { get; }

  public TypeOutputResolverFieldTests() => Resolver = new TypeOutputResolver();

  protected override ObjBaseModel MakeBase(string name, string description = "", params TypeArgModel[] args)
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
  protected override TypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Output, argument, "") { IsTypeParam = isParam };
}
