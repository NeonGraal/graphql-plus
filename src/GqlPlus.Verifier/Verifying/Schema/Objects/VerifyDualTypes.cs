using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  ObjectVerifierParams<IGqlpDualObject, IGqlpDualField, IGqlpDualAlternate> verifiers
) : AstObjectVerifier<IGqlpDualObject, IGqlpDualBase, IGqlpDualField, IGqlpDualAlternate>(verifiers)
{ }
