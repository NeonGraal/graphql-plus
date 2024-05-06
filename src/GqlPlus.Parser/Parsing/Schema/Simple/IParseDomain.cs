using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

public interface IParseDomain
{
  DomainKind Kind { get; }
  ParseItems Parser { get; }
}

public delegate IResult<DomainDefinition> ParseItems(Tokenizer tokens, string label, DomainDefinition result);
