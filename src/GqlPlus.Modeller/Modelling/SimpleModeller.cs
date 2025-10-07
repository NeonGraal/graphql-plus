namespace GqlPlus.Modelling;

internal class SimpleModeller(
  IModeller<IGqlpEnumValue, EnumValueModel> enumValue
) : ModellerBase<IGqlpFieldKey, SimpleModel>
{
  protected override SimpleModel ToModel(IGqlpFieldKey ast, IMap<TypeKindModel> typeKinds)
    => ast switch {
      null => throw new ModelTypeException<IGqlpFieldKey>("Null ast"),
      { Number: not null } => SimpleModel.Num(ast.Number.Value),
      { Text: not null } when !string.IsNullOrEmpty(ast.Text)
        => SimpleModel.Str(ast.Text),
      { EnumValue: not null } when "Boolean".Equals(ast.EnumValue.EnumType, StringComparison.OrdinalIgnoreCase)
        => SimpleModel.Bool("true".Equals(ast.EnumValue.EnumLabel, StringComparison.OrdinalIgnoreCase)),
      { EnumValue: not null }
        => SimpleModel.Enum(enumValue.ToModel(ast.EnumValue, typeKinds)),
      _ => new("")
    };
}
