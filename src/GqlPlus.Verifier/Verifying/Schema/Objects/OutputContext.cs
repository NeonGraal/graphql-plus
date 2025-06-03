using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class OutputContext(
  IMap<IGqlpDescribed> types,
  ITokenMessages errors,
  IMap<string> enumValues
) : EnumContext(types, errors, enumValues)
{
  internal void CheckEnumValue(string label, IGqlpOutputEnum output)
  {
    string enumType = output.EnumType.Name;
    if (GetTyped(enumType, out IGqlpEnum? theType)) {
      if (!GetEnumValueType(theType, output.EnumLabel ?? "", out IGqlpEnum? _)) {
        AddError(output, $"Output {label} Enum Value", $"'{output.EnumLabel}' not a Value of '{enumType}'");
      }
    } else {
      AddError(output, $"Output {label} Enum", $"'{enumType}' not an Enum type");
    }
  }
}
