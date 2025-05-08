using GqlPlus.Ast.Operation;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class OperationContext
  : Tokenizer
  , IOperationContext
{
  public OperationContext(ITokenizer tokens)
    : base(tokens) { }

  internal OperationContext(string operation)
    : base(operation) { }

  List<ArgAst> IOperationContext.Variables { get; } = [];
  List<SpreadAst> IOperationContext.Spreads { get; } = [];
}

internal interface IOperationContext
{
  List<ArgAst> Variables { get; }
  List<SpreadAst> Spreads { get; }
}
