using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  ObjectVerifierParams<IGqlpDualObject, IGqlpDualField> verifiers
) : AstObjectVerifier<IGqlpDualObject, IGqlpDualField>(verifiers)
{ }
