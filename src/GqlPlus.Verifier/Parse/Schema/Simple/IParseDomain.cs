using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Simple;

public interface IParseDomain
{
  DomainDomain Kind { get; }
  ParseItems Parser { get; }
}

public delegate IResult<DomainDefinition> ParseItems(Tokenizer tokens, string label, DomainDefinition result);
