using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  ObjectVerifierParams<IGqlpDualObject, IGqlpDualField, IGqlpDualAlternate, IGqlpDualArg> verifiers
) : AstObjectVerifier<IGqlpDualObject, IGqlpDualBase, IGqlpDualArg, IGqlpDualField, IGqlpDualAlternate>(verifiers)
{ }
