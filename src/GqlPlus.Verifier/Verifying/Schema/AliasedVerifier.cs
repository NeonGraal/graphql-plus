using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

internal abstract class AliasedVerifier<TAliased>(
  IVerifierRepository verifiers
) : GroupedVerifier<TAliased>(verifiers)
 where TAliased : IAstAliased
{
  private readonly Defer<IVerify<TAliased>>.L _verifier = verifiers.VerifierFor<TAliased>();

  public override void Verify(TAliased[] item, IMessages errors)
  {
    base.Verify(item, errors);

    foreach (TAliased each in item) {
      _verifier.I.Verify(each, errors);
    }
  }
}
