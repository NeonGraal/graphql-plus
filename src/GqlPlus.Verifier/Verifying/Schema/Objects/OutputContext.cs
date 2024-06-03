using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Verifying.Schema.Objects;

internal class OutputContext(
  IMap<IGqlpDescribed> types,
  ITokenMessages errors,
  IMap<string> enumValues
) : EnumContext(types, errors, enumValues)
{

  internal override void CheckArgumentType<TObjBase>(TObjBase type, string labelSuffix)
  {
    if (type is OutputBaseAst output)
    {
      if (string.IsNullOrWhiteSpace(output.EnumValue) && GetEnumValue(type.TypeName, out string? enumType))
      {
        output.EnumValue = type.TypeName;
        output.Name = enumType!;
      }

      if (!string.IsNullOrWhiteSpace(output.EnumValue))
      {
        CheckEnumValue("Argument", output);
      }

      base.CheckArgumentType(type, labelSuffix);
    }
  }

  internal void CheckEnumValue(string label, IGqlpOutputBase output)
  {
    if (GetEnumType(output.TypeName, out Ast.Schema.Simple.EnumDeclAst? theType))
    {
      if (!GetEnumValueType(theType, output.EnumValue ?? "", out Ast.Schema.Simple.EnumDeclAst? _))
      {
        AddError(output, $"Output {label} Enum Value", $"'{output.EnumValue}' not a Value of '{output.TypeName}'");
      }
    } else
    {
      AddError(output, $"Output {label} Enum", $"'{output.TypeName}' is not an Enum type");
    }
  }
}
