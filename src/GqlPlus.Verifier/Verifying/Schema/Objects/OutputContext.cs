using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class OutputContext(
  IMap<IGqlpDescribed> types,
  ITokenMessages errors,
  IMap<string> enumValues
) : EnumContext(types, errors, enumValues)
{

  internal override void CheckArgType<TObjBase>(TObjBase type, string labelSuffix)
  {
    if (type is IGqlpOutputArg output) {
      if (string.IsNullOrWhiteSpace(output.EnumLabel) && GetEnumValue(type.TypeName, out string? enumType)) {
        output.SetEnumType(enumType);
      }

      if (!string.IsNullOrWhiteSpace(output.EnumLabel)) {
        CheckEnumValue("Arg", output);
      }

      base.CheckArgType(type, labelSuffix);
    }
  }

  internal void CheckEnumValue(string label, IGqlpOutputEnum output)
  {
    if (GetEnumType(output.EnumType, out IGqlpEnum? theType)) {
      if (!GetEnumValueType(theType, output.EnumLabel ?? "", out IGqlpEnum? _)) {
        AddError(output, $"Output {label} Enum Value", $"'{output.EnumLabel}' not a Value of '{output.EnumType}'");
      }
    } else {
      AddError(output, $"Output {label} Enum", $"'{output.EnumType}' is not an Enum type");
    }
  }
}
