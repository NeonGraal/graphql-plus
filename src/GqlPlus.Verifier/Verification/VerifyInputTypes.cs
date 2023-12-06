﻿using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifyInputTypes : UsageAliasedVerifier<InputDeclAst, AstType>
{
  //  protected override string UsageKey(InputAst item) => item.Extends?.Name ?? "";
  protected override ITokenMessages UsageValue(InputDeclAst usage, IMap<AstType[]> byId) => TokenMessages.Empty;
}
