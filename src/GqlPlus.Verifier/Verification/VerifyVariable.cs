using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;
internal class VerifyVariable : IVerify<VariableAst>
{
  public IEnumerable<TokenMessage> Verify(VariableAst target)
  {
    var def = target.Default;
    if (def is null) {
      return Enumerable.Empty<TokenMessage>();
    }

    var lastModifier = target.Modifers.LastOrDefault();
    if (lastModifier?.Kind == ModifierKind.Optional) {
      var secondLastModifier = target.Modifers.Length > 1 ? target.Modifers.TakeLast(2).First() : null;
      return VerifyVariableDefault("Optional ", secondLastModifier, def);
    }

    return VerifyVariableNullDefault(def)
      .Union(VerifyVariableDefault("", lastModifier, def));
  }
  private IEnumerable<TokenMessage> VerifyVariableDefault(string label, ModifierAst? lastModifier, ConstantAst def)
  {
    return lastModifier?.Kind == ModifierKind.Dict && (def.Values.Length > 0 || def.Value is not null)
      ? ([def.Error($"Invalid Variable definition. {label}Dictionary Type must have Object default.")])
      : lastModifier?.Kind == ModifierKind.List && def.Fields.Count > 0
      ? ([def.Error($"Invalid Variable definition. {label}List Type cannot have Object default.")])
      : Enumerable.Empty<TokenMessage>();
  }

  private IEnumerable<TokenMessage> VerifyVariableNullDefault(ConstantAst def)
  {
    return def.Value?.EnumLabel == "Null.null"
      ? ([def.Error("Invalid Variable definition. Default of 'null' must be on Optional Type.")])
      : Enumerable.Empty<TokenMessage>();
  }
}
