using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema.Objects;

internal class VerifyDualTypes(
  IVerifyAliased<DualDeclAst> aliased,
  IMerge<DualFieldAst> fields,
  IMerge<AstAlternate<DualReferenceAst>> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<DualDeclAst, DualFieldAst, DualReferenceAst, UsageContext>(aliased, fields, mergeAlternates, logger)
{
  protected override UsageContext MakeContext(DualDeclAst usage, AstType[] aliased, ITokenMessages errors)
  {
    var validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }
}
