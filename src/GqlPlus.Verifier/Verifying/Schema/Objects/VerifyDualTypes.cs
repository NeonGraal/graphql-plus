﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(IVerifierRepository verifiers)
  : AstObjectVerifier<IAstDualField>(verifiers, TypeKind.Dual)
{
  internal static VerifyDualTypes Factory(IVerifierRepository v) => new(v);
}
