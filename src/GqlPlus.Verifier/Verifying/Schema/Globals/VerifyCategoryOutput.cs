﻿using GqlPlus.Abstractions.Schema;
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
    if (context.GetType(usage.Output, out IGqlpDescribed? type) && type is IGqlpOutputObject output) {
      context.AddError(usage, "Category Output", $"'{usage.Output}' is a generic Output type", output.TypeParams.Any());
    } else {
      context.AddError(usage, "Category Output", $"'{usage.Output}' not defined or not an Output type");
    }

    context.CheckModifiers(usage);
  }
}
