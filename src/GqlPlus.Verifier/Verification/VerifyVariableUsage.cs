using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Verification;

internal class VerifyVariableUsage : UsageVerifier<ArgumentAst, VariableAst>
{
  public override string Label => "Variable";

  public override string UsageKey(ArgumentAst item) => item.Variable!;

  public override bool Verify<TContext>(TContext context, ArgumentAst[] target)
  {
    if (context is VariablesContext variables) {
      VerifyUsages(target, variables.Variables, context);
    }

    return true;
  }

  protected override void VerifyDefinition(VariableAst d, VerificationContext context)
  {
    var def = d.Default;
    if (def is null) {
      return;
    }

    var lastModifier = d.Modifers.LastOrDefault();
    if (lastModifier?.Kind == ModifierKind.Optional) {
      var secondLastModifier = d.Modifers.Length > 1 ? d.Modifers.TakeLast(2).First() : null;
      VerifyVariableDefault("Optional ", secondLastModifier, def, context);
    } else {
      VerifyVariableNullDefault(def, context);
      VerifyVariableDefault("", lastModifier, def, context);
    }
  }

  protected override void VerifyUsage(ArgumentAst u, VerificationContext context) { }

  private void VerifyVariableDefault(string label, ModifierAst? lastModifier, ConstantAst def, VerificationContext context)
  {
    switch (lastModifier?.Kind) {
      case ModifierKind.Dict:
        if (def.Values.Length > 0 || def.Value is not null) {
          context.Error(def, $"Invalid Variable definition. {label}Dictionary Type must have Object default.");
        }

        break;
      case ModifierKind.List:
        if (def.Fields.Count > 0) {
          context.Error(def, $"Invalid Variable definition. {label}List Type cannot have Object default.");
        }

        break;
      default:
        break;
    }
  }

  private void VerifyVariableNullDefault(ConstantAst def, VerificationContext context)
  {
    if (def.Value?.EnumLabel == "Null.null") {
      context.Error(def, "Invalid Variable definition. Default of 'null' must be on Optional Type.");
    }
  }
}
