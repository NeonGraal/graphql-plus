using GqlPlus.Ast.Operation;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class OperationContext : Tokenizer
{
  internal OperationContext(string operation)
    : base(operation) { }

  internal readonly List<ArgumentAst> Variables = [];
  internal readonly List<SpreadAst> Spreads = [];
}
