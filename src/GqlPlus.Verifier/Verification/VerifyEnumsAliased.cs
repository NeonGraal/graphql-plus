using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Verification;

internal class VerifyEnumsAliased(
  IVerify<EnumDeclAst> definition,
   IMerge<EnumDeclAst> merger
) : AliasedVerifier<EnumDeclAst>(definition, merger)
{
  public override string Label => "Enums";

  protected override object GroupKey(EnumDeclAst item) => item.Name + "-" + (item.Extends ?? "");
}
