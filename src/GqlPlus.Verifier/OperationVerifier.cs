using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier;

public class OperationVerifier
{
  public static bool Verify(string operation, out List<ParseError> errors)
  {
    Tokenizer tokenizer = new(operation);
    OperationParser parser = new(tokenizer);
    OperationAst ast = parser.Parse();

    return Verify(ast, out errors);
  }

  private static bool Verify(OperationAst ast, out List<ParseError> errors)
  {
    errors = ast.Errors.ToList();

    var definitions = ast.Variables.ToDictionary(v => v.Name);
    var usages = ast.Usages.ToDictionary(a => a.Variable!);

    foreach (var (k, u) in usages) {
      if (!definitions.ContainsKey(k)) {
        errors.Add(u.Error("Invalid Variable usage. Variable not defined."));
      }
    }

    foreach (var (k, d) in definitions) {
      if (!usages.ContainsKey(k)) {
        errors.Add(d.Error("Invalid Variable definition. Variable not used."));
      }
    }

    ast.Errors = errors.ToArray();

    return ast.Result == ParseResult.Success && !ast.Errors.Any();
  }
}
