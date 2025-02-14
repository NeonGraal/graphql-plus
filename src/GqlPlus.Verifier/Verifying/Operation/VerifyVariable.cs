using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyVariable
  : IVerify<IGqlpVariable>
{
  public void Verify(IGqlpVariable item, ITokenMessages errors)
  {
    IGqlpConstant? def = item.DefaultValue;
    if (def is null) {
      return;
    }

    IGqlpModifier? lastModifier = item.Modifiers.LastOrDefault();
    if (lastModifier?.ModifierKind == ModifierKind.Optional) {
      var count = item.Modifiers.Count();
      IGqlpModifier? secondLastModifier = count > 1 ? item.Modifiers.Skip(count - 2).First() : null;
      VerifyVariableDefault("Optional ", secondLastModifier, def, errors);
      return;
    }

    VerifyVariableNullDefault(def, errors);
    VerifyVariableDefault("", lastModifier, def, errors);
  }

  private static void VerifyVariableDefault(string label, IGqlpModifier? lastModifier, IGqlpConstant def, ITokenMessages errors)
  {
    if (lastModifier?.ModifierKind == ModifierKind.Dict && (def.Values.Any() || def.Value is not null)) {
      errors.Add(def.MakeError($"Invalid Variable definition. {label}Dictionary Type must have Object default."));
    }

    if (lastModifier?.ModifierKind == ModifierKind.List && def.Fields.Count > 0) {
      errors.Add(def.MakeError($"Invalid Variable definition. {label}List Type cannot have Object default."));
    }
  }

  private static void VerifyVariableNullDefault(IGqlpConstant def, ITokenMessages errors)
  {
    if (def.Value?.EnumValue == "Null.null") {
      errors.Add(def.MakeError("Invalid Variable definition. Default of 'null' must be on Optional Type."));
    }
  }
}
