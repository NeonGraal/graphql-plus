using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;
using GqlPlus.Verifier.Verification.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyOptionAliased(
  IVerify<OptionDeclAst> definition,
  IMerge<OptionDeclAst> merger,
  ILoggerFactory logger
) : AliasedVerifier<OptionDeclAst>(definition, merger, logger)
{
  public override string Label => "Options";

  public override void Verify(OptionDeclAst[] item, ITokenMessages errors)
  {
    if (item.Select(i => i.Name).Distinct().Count() > 1) {
      errors.Add(item.Last().Error($"Multiple Schema names found."));
    }

    base.Verify(item, errors);
  }
}
