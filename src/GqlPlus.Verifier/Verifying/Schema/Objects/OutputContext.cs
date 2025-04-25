﻿using GqlPlus.Abstractions.Schema;

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
      if (string.IsNullOrWhiteSpace(output.EnumLabel) && GetEnumValue(type.Name, out string? enumType)) {
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
    string enumType = output.EnumType.Name;
    if (GetTyped(enumType, out IGqlpEnum? theType)) {
      if (!GetEnumValueType(theType, output.EnumLabel ?? "", out IGqlpEnum? _)) {
        AddError(output, $"Output {label} Enum Value", $"'{output.EnumLabel}' not a Value of '{enumType}'");
      }
    } else {
      AddError(output, $"Output {label} Enum", $"'{enumType}' is not an Enum type");
    }
  }
}
