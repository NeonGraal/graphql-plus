using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Token;

namespace GqlPlus.Verification.Schema.Objects;

internal class VerifyDualTypes(
  IVerifyAliased<DualDeclAst> aliased,
  IMerge<DualFieldAst> fields,
  IMerge<AstAlternate<DualBaseAst>> mergeAlternates,
  ILoggerFactory logger
) : AstObjectVerifier<DualDeclAst, DualFieldAst, DualBaseAst, UsageContext>(aliased, fields, mergeAlternates, logger)
{
  protected override UsageContext MakeContext(DualDeclAst usage, AstType[] aliased, ITokenMessages errors)
  {
    Map<AstDescribed> validTypes = aliased.AliasedGroup()
      .Select(p => (Id: p.Key, Type: (AstDescribed)p.First()))
      .Concat(usage.TypeParameters.Select(p => (Id: "$" + p.Name, Type: (AstDescribed)p)))
      .ToMap(p => p.Id, p => p.Type);

    return new(validTypes, errors);
  }
}
