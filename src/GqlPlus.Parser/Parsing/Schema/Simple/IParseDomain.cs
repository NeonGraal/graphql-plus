using GqlPlus.Abstractions.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Simple;

internal interface IParseDomain
{
  DomainKind Kind { get; }
  ParseItems Parser { get; }
}

internal delegate IResult<DomainDefinition> ParseItems(ITokenizer tokens, string label, DomainDefinition result);
