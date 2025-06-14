using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

[ExcludeFromCodeCoverage]
public class OperationContext
  : Tokenizer
  , IOperationContext
{
  public OperationContext(ITokenizer tokens)
    : base(tokens) { }

  public OperationContext(string operation)
    : base(operation) { }

  List<IGqlpArg> IOperationContext.Variables { get; } = [];
  List<IGqlpSpread> IOperationContext.Spreads { get; } = [];
}

internal interface IOperationContext
  : ITokenizer
{
  List<IGqlpArg> Variables { get; }
  List<IGqlpSpread> Spreads { get; }
}
