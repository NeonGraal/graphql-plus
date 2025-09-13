﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyOutputTypes(
  ObjectVerifierParams<IGqlpOutputObject, IGqlpOutputField, IGqlpOutputAlternate, IGqlpObjArg> verifiers
) : AstObjectVerifier<IGqlpOutputObject, IGqlpOutputBase, IGqlpObjArg, IGqlpOutputField, IGqlpOutputAlternate>(verifiers)
{
  protected override void UsageField(IGqlpOutputField field, IGqlpOutputObject usage, EnumContext context)
  {
    base.UsageField(field, usage, context);

    foreach (IGqlpInputParam parameter in field.Params) {
      CheckTypeRef(context, parameter.Type, " Param");
      context.CheckModifiers(parameter);
    }
  }
}
