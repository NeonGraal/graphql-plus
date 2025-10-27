using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  ObjectVerifierParams<IGqlpDualField> verifiers
) : AstObjectVerifier<IGqlpDualField>(verifiers)
{ }
