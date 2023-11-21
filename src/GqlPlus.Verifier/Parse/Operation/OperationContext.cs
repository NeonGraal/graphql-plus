using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class OperationContext : Tokenizer
{
  internal OperationContext(string operation)
    : base(operation) { }

  internal readonly List<ArgumentAst> Variables = new();
  internal readonly List<SpreadAst> Spreads = new();
}
