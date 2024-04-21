using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

public interface IParseDomain
{
  DomainDomain Kind { get; }
  ParseItems Parser { get; }
}

public delegate IResult<DomainDefinition> ParseItems(Tokenizer tokens, string label, DomainDefinition result);
