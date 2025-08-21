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

  private readonly List<IGqlpArg> _variables = [];
  private readonly List<IGqlpSpread> _spreads = [];

  public IEnumerable<IGqlpArg> Variables => _variables;
  public IEnumerable<IGqlpSpread> Spreads => _spreads;

  public void AddVariable(IGqlpArg variable)
    => _variables.Add(variable);
  public void AddSpread(IGqlpSpread spread)
    => _spreads.Add(spread);
}

internal interface IOperationContext
  : ITokenizer
{
  void AddVariable(IGqlpArg variable);
  void AddSpread(IGqlpSpread spread);
  IEnumerable<IGqlpArg> Variables { get; }
  IEnumerable<IGqlpSpread> Spreads { get; }
}
