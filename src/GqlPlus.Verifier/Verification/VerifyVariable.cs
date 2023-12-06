using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyVariable : IVerify<VariableAst>
{
  public ITokenMessages Verify(VariableAst target)
  {
    var def = target.Default;
    if (def is null) {
      return new TokenMessages();
    }

    var lastModifier = target.Modifers.LastOrDefault();
    if (lastModifier?.Kind == ModifierKind.Optional) {
      var secondLastModifier = target.Modifers.Length > 1 ? target.Modifers.TakeLast(2).First() : null;
      return VerifyVariableDefault("Optional ", secondLastModifier, def);
    }

    var errors = VerifyVariableNullDefault(def);
    errors.AddRange(VerifyVariableDefault("", lastModifier, def));

    return errors;
  }
  private TokenMessages VerifyVariableDefault(string label, ModifierAst? lastModifier, ConstantAst def)
    => lastModifier?.Kind == ModifierKind.Dict && (def.Values.Length > 0 || def.Value is not null)
      ? ([def.Error($"Invalid Variable definition. {label}Dictionary Type must have Object default.")])
      : lastModifier?.Kind == ModifierKind.List && def.Fields.Count > 0
      ? ([def.Error($"Invalid Variable definition. {label}List Type cannot have Object default.")])
      : new TokenMessages();

  private TokenMessages VerifyVariableNullDefault(ConstantAst def)
    => def.Value?.EnumLabel == "Null.null"
      ? ([def.Error("Invalid Variable definition. Default of 'null' must be on Optional Type.")])
      : new TokenMessages();
}
