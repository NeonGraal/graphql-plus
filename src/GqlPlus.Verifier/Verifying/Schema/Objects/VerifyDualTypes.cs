using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(
  ObjectVerifierParams<IGqlpDualObject, IGqlpDualField, IGqlpDualAlternate, IGqlpObjArg> verifiers
) : AstObjectVerifier<IGqlpDualObject, IGqlpDualBase, IGqlpObjArg, IGqlpDualField, IGqlpDualAlternate>(verifiers)
{ }
