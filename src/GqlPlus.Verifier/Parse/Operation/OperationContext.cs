using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Operation;

internal class OperationContext : Tokenizer
{
  internal OperationContext(string operation)
    : base(operation) { }

  internal readonly List<ArgumentAst> Variables = [];
  internal readonly List<SpreadAst> Spreads = [];
}
