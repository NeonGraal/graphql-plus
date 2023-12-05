using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

public class VerificationContext
{
  internal List<TokenMessage> Errors { get; set; } = [];

  internal void Error<TAst>(TAst ast, string message)
    where TAst : AstBase
    => Errors.Add(ast.Error(message));
}
