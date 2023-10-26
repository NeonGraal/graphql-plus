using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier;

public class OperationVerifier
{
  private OperationAst Ast { get; }
  private List<ParseError> Errors { get; }

  internal OperationVerifier(OperationAst ast)
    => (Ast, Errors) = (ast, new(ast.Errors));

  public static bool Verify(string operation, out List<ParseError> errors)
  {
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    OperationAst ast = parser.Parse();

    var verifier = new OperationVerifier(ast);
    errors = verifier.Errors;

    return verifier.Verify();
  }

  private bool Verify()
  {
    VerifyUsages("Variables", Ast.Usages, a => a.Variable!, Ast.Variables, VerifyVariableDefinition);
    VerifyUsages("Fragment", Ast.Spreads, s => s.Name, Ast.Fragments, f => { });

    Ast.Errors = Errors.ToArray();

    return Ast.Result == ParseResult.Success && !Ast.Errors.Any();
  }

  private void Error(ParseError error)
    => Errors.Add(error);

  private void VerifyVariableDefinition(VariableAst d)
  {
    var def = d.Default;
    if (def is null) {
      return;
    }

    var lastModifier = d.Modifers.LastOrDefault();
    if (lastModifier?.Kind == ModifierKind.Optional) {
      var secondLastModifier = d.Modifers.Length > 1 ? d.Modifers.TakeLast(2).First() : null;
      VerifyVariableDefault("Optional ", secondLastModifier, def);
    } else {
      VerifyVariableNullDefault(def);
      VerifyVariableDefault("", lastModifier, def);
    }
  }

  private void VerifyVariableDefault(string label, ModifierAst? lastModifier, ConstantAst def)
  {
    switch (lastModifier?.Kind) {
      case ModifierKind.Dict:
        if (def.Values.Length > 0 || def.Value is not null) {
          Error(def.Error($"Invalid Variable definition. {label}Dictionary Type must have Object default."));
        }

        break;
      case ModifierKind.List:
        if (def.Fields.Count > 0) {
          Error(def.Error($"Invalid Variable definition. {label}List Type cannot have Object default."));
        }

        break;
      default:
        break;
    }
  }

  private void VerifyVariableNullDefault(ConstantAst def)
  {
    if (def.Value?.EnumLabel == "Null.null") {
      Error(def.Error("Invalid Variable definition. Default of 'null' must be on Optional Type."));
    }
  }

  private void VerifyUsages<U, D>(
    string label,
    U[] usages,
    Func<U, string> key,
    D[] definitions,
    Action<D> more
  ) where U : AstBase where D : AstNamed
  {
    var used = usages.ToDictionary(key);
    var defined = definitions.ToDictionary(f => f.Name);

    foreach (var (k, u) in used) {
      if (!defined.ContainsKey(k)) {
        Error(u.Error($"Invalid {label} usage. {label} not defined."));
      }
    }

    foreach (var (k, d) in defined) {
      if (!used.ContainsKey(k)) {
        Error(d.Error($"Invalid {label} definition. {label} not used."));
      }

      more(d);
    }
  }
}
