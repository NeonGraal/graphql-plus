using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

public class OperationContext
  : Tokenizer
  , IOperationContext
{
  public OperationContext(ITokenizer tokens)
    : base(tokens) { }

  public OperationContext(string operation)
    : base(operation) { }

  private readonly List<IAstArg> _variables = [];
  private readonly List<IAstSpread> _spreads = [];

  public IEnumerable<IAstArg> Variables => _variables;
  public IEnumerable<IAstSpread> Spreads => _spreads;

  public void AddVariable(IAstArg variable)
    => _variables.Add(variable);
  public void AddSpread(IAstSpread spread)
    => _spreads.Add(spread);
}

internal interface IOperationContext
  : ITokenizer
{
  void AddVariable(IAstArg variable);
  void AddSpread(IAstSpread spread);
  IEnumerable<IAstArg> Variables { get; }
  IEnumerable<IAstSpread> Spreads { get; }
}
