using GqlPlus.Verifier.Ast;

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
    var lastModifier = d.Modifers.LastOrDefault();
    var secondLastModifier = d.Modifers.Length > 1 ? d.Modifers.TakeLast(2).First() : null;

    switch (d.Default) {
      case { Value.EnumLabel: "Null.null" }:
        if (lastModifier?.Kind != ModifierKind.Optional) {
          Error(d.Error("Invalid Variable definition. Default of 'null' must be on Optional Type."));
        }

        break;
      case { Values.Length: > 0 } or { Value: not null }:
        if (lastModifier?.Kind == ModifierKind.Dict) {
          Error(d.Error("Invalid Variable definition. Dictionary Type must have Object default."));
        } else if (lastModifier?.Kind == ModifierKind.Optional
            && secondLastModifier?.Kind == ModifierKind.Dict
          ) {
          Error(d.Error("Invalid Variable definition. Optional Dictionary Type must have Object default."));
        }

        break;
      case { Fields.Count: > 0 }:
        if (lastModifier?.Kind == ModifierKind.List) {
          Error(d.Error("Invalid Variable definition. List Type cannot have Object default."));
        } else if (lastModifier?.Kind == ModifierKind.Optional
          && secondLastModifier?.Kind == ModifierKind.List
        ) {
          Error(d.Error("Invalid Variable definition. Optional List Type cannot have Object default."));
        }

        break;
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
