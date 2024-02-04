﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Merging;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyEnumTypes(
  IVerifyAliased<EnumDeclAst> aliased,
  IMerge<EnumMemberAst> mergeMembers
) : AstParentItemVerifier<EnumDeclAst, string, UsageContext, EnumMemberAst>(aliased, mergeMembers)
{
  protected override IEnumerable<EnumMemberAst> GetItems(EnumDeclAst usage)
    => usage.Members;

  protected override string GetParent(AstType<string> usage)
    => usage.Parent ?? "";

  protected override UsageContext MakeContext(EnumDeclAst usage, AstType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);
}
