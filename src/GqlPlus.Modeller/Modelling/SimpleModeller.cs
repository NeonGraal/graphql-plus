using GqlPlus.Ast;

namespace GqlPlus.Modelling;

internal class SimpleModeller(
  IModellerRepository modellers
) : ModellerBase<IAstFieldKey, SimpleModel>
{
  private readonly IModeller<IAstEnumValue, EnumValueModel> _enumValue = modellers.ModellerFor<IAstEnumValue, EnumValueModel>();

  protected override SimpleModel ToModel(IAstFieldKey ast, IMap<TypeKindModel> typeKinds)
    => ast switch {
      null => throw new ModelTypeException<IAstFieldKey>("Null ast"),
      { Number: not null } => SimpleModel.Num(ast.Number.Value),
      { Text: not null } when !string.IsNullOrEmpty(ast.Text)
        => SimpleModel.Str(ast.Text),
      { EnumValue: not null } when BuiltIn.BooleanType.Equals(ast.EnumValue.EnumType, StringComparison.OrdinalIgnoreCase)
        => SimpleModel.Bool(BuiltIn.BooleanTrue.Equals(ast.EnumValue.EnumLabel, StringComparison.OrdinalIgnoreCase)),
      { EnumValue: not null }
        => SimpleModel.Enum(_enumValue.ToModel(ast.EnumValue, typeKinds)),
      _ => new("")
    };
}
