using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

internal class VerifyDualTypes(IVerifierRepository verifiers)
  : AstObjectVerifier<IAstDualField>(verifiers, TypeKind.Dual)
{ }
