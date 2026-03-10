using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(IVerifierRepository verifiers) : AstObjectVerifier<IGqlpDualField>(verifiers)
{ }
