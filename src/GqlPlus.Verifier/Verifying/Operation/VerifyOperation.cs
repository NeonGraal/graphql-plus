using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyOperation(IVerifierRepository verifiers) : IVerify<IGqlpOperation>
{
  private readonly IVerifyIdentified<IGqlpArg, IGqlpVariable> _usages = verifiers.IdentifiedFor<IGqlpArg, IGqlpVariable>();
  private readonly IVerifyIdentified<IGqlpSpread, IGqlpFragment> _spreads = verifiers.IdentifiedFor<IGqlpSpread, IGqlpFragment>();

  public void Verify(IGqlpOperation item, IMessages errors)
  {
    _usages.Verify(new(item.Usages, item.Variables), errors);
    _spreads.Verify(new(item.Spreads, item.Fragments), errors);
    errors.Add(item.Errors);
  }
}
