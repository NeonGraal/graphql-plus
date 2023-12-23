using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Operation;

internal class VerifyVariable : IVerify<VariableAst>
{
  public void Verify(VariableAst item, ITokenMessages errors)
  {
    var def = item.Default;
    if (def is null) {
      return;
    }

    var lastModifier = item.Modifers.LastOrDefault();
    if (lastModifier?.Kind == ModifierKind.Optional) {
      var secondLastModifier = item.Modifers.Length > 1 ? item.Modifers.TakeLast(2).First() : null;
      VerifyVariableDefault("Optional ", secondLastModifier, def, errors);
      return;
    }

    VerifyVariableNullDefault(def, errors);
    VerifyVariableDefault("", lastModifier, def, errors);
  }

  private static void VerifyVariableDefault(string label, ModifierAst? lastModifier, ConstantAst def, ITokenMessages errors)
  {
    if (lastModifier?.Kind == ModifierKind.Dict && (def.Values.Length > 0 || def.Value is not null)) {
      errors.AddError(def, $"Invalid Variable definition. {label}Dictionary Type must have Object default.");
    }

    if (lastModifier?.Kind == ModifierKind.List && def.Fields.Count > 0) {
      errors.AddError(def, $"Invalid Variable definition. {label}List Type cannot have Object default.");
    }
  }

  private static void VerifyVariableNullDefault(ConstantAst def, ITokenMessages errors)
  {
    if (def.Value?.EnumValue == "Null.null") {
      errors.AddError(def, "Invalid Variable definition. Default of 'null' must be on Optional Type.");
    }
  }
}
