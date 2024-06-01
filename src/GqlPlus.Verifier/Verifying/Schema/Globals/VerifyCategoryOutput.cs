﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyCategoryOutput(
  IVerifyAliased<IGqlpSchemaCategory> aliased
) : UsageVerifier<IGqlpSchemaCategory, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(IGqlpSchemaCategory usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpSchemaCategory usage, UsageContext context)
  {
    if (context.GetType(usage.Output, out IGqlpDescribed? type) && type is OutputDeclAst output) {
      if (output.TypeParameters.Length > 0) {
        context.AddError(usage, "Category Output", $"'{usage.Output}' is a generic Output type");
      }
    } else {
      context.AddError(usage, "Category Output", $"'{usage.Output}' not defined or not an Output type");
    }
  }
}
