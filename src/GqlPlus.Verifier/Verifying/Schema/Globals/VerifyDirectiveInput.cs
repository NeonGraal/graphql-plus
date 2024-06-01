﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Globals;

internal class VerifyDirectiveInput(
  IVerifyAliased<IGqlpSchemaDirective> aliased
) : UsageVerifier<IGqlpSchemaDirective, UsageContext>(aliased)
{
  protected override UsageContext MakeContext(IGqlpSchemaDirective usage, IGqlpType[] aliased, ITokenMessages errors)
    => MakeUsageContext(aliased, errors);

  protected override void UsageValue(IGqlpSchemaDirective usage, UsageContext context)
  {
    foreach (Ast.Schema.InputParameterAst parameter in usage.Parameters) {
      if (!context.GetType(parameter.Type.FullName, out IGqlpDescribed? _)) {
        context.AddError(parameter, "Directive Parameter", $"'{parameter.Type}' not defined");
      }
    }
  }
}
