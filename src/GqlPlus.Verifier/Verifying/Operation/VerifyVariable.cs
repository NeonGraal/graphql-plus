using GqlPlus.Ast.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyVariable
  : IVerify<IAstVariable>
{
  public void Verify(IAstVariable item, IMessages errors)
  {
    IAstConstant? def = item.DefaultValue;
    if (def is null) {
      return;
    }

    IAstModifier? lastModifier = item.Modifiers.LastOrDefault();
    if (lastModifier?.ModifierKind == ModifierKind.Optional) {
      int count = item.Modifiers.Count();
      IAstModifier? secondLastModifier = count > 1 ? item.Modifiers.Skip(count - 2).First() : null;
      VerifyVariableDefault("Optional ", secondLastModifier, def, errors);
      return;
    }

    VerifyVariableNullDefault(def, errors);
    VerifyVariableDefault("", lastModifier, def, errors);
  }

  private static void VerifyVariableDefault(
    string label,
    IAstModifier? lastModifier,
    IAstConstant def,
    IMessages errors)
  {
    if (lastModifier?.ModifierKind == ModifierKind.Dict && (def.Values.Any() || def.Value is not null)) {
      errors.Add(def.MakeError($"Invalid Variable definition. {label}Dictionary Type must have Object default."));
    }

    if (lastModifier?.ModifierKind == ModifierKind.List && def.Fields.Count > 0) {
      errors.Add(def.MakeError($"Invalid Variable definition. {label}List Type cannot have Object default."));
    }
  }

  private static void VerifyVariableNullDefault(IAstConstant def, IMessages errors)
  {
    if (def.Value?.EnumValue?.EnumValue == "Null.null") {
      errors.Add(def.MakeError("Invalid Variable definition. Default of 'null' must be on Optional Type."));
    }
  }

  internal static VerifyVariable Factory(IVerifierRepository _) => new();
}
