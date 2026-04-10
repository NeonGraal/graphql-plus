using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyOperation(IVerifierRepository verifiers) : IVerify<IAstOperation>
{
  private readonly IVerifyIdentified<IGqlpArg, IAstVariable> _usages = verifiers.IdentifiedFor<IGqlpArg, IAstVariable>();
  private readonly IVerifyIdentified<IGqlpSpread, IAstFragment> _spreads = verifiers.IdentifiedFor<IGqlpSpread, IAstFragment>();

  public void Verify(IAstOperation item, IMessages errors)
  {
    _usages.Verify(new(item.Usages, item.Variables), errors);
    _spreads.Verify(new(item.Spreads, item.Fragments), errors);
    errors.Add(item.Errors);
  }
}
