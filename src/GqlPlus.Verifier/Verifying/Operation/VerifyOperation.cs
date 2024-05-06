using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Verifying.Operation;

internal class VerifyOperation(
  IVerifyNamed<IGqlpArgument, IGqlpVariable> usages,
  IVerifyNamed<IGqlpSpread, IGqlpFragment> spreads
) : IVerify<IGqlpOperation>
{
  public void Verify(IGqlpOperation item, ITokenMessages errors)
  {
    usages.Verify(new(item.Usages, item.Variables), errors);
    spreads.Verify(new(item.Spreads, item.Fragments), errors);
    errors.Add(item.Errors);
  }
}
