namespace GqlPlus.Resolving;

public class TypeInputResolverFieldTests
  : ResolverTypeObjectFieldTestBase<TypeInputModel, InputFieldModel>
{
  protected override IResolver<TypeInputModel> Resolver { get; }

  public TypeInputResolverFieldTests() => Resolver = new TypeInputResolver();

  protected override ObjBaseModel MakeBase(string name, string description = "", params ObjTypeArgModel[] args)
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
  protected override ObjTypeArgModel NewArg(string argument, bool isParam = false)
    => new(TypeKindModel.Input, argument, "") { IsTypeParam = isParam };
}
