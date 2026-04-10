using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypes(IVerifierRepository verifiers) : IVerify<IAstType[]>
{
  private readonly IVerifyUsage<IGqlpObject<IGqlpDualField>> _dualAllTypes = verifiers.UsageFor<IGqlpObject<IGqlpDualField>>();
  private readonly IVerifyUsage<IGqlpEnum> _enumAllTypes = verifiers.UsageFor<IGqlpEnum>();
  private readonly IVerifyUsage<IGqlpObject<IGqlpInputField>> _inputAllTypes = verifiers.UsageFor<IGqlpObject<IGqlpInputField>>();
  private readonly IVerifyUsage<IGqlpObject<IGqlpOutputField>> _outputAllTypes = verifiers.UsageFor<IGqlpObject<IGqlpOutputField>>();
  private readonly IVerifyUsage<IGqlpDomain> _domainAllTypes = verifiers.UsageFor<IGqlpDomain>();
  private readonly IVerifyUsage<IGqlpUnion> _unionAllTypes = verifiers.UsageFor<IGqlpUnion>();

  public void Verify(IAstType[] item, IMessages errors)
  {
    IAstType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    IGqlpObject<IGqlpDualField>[] dualTypes = item.ArrayOf<IGqlpObject<IGqlpDualField>>();
    IGqlpEnum[] enumTypes = item.ArrayOf<IGqlpEnum>();
    IGqlpObject<IGqlpInputField>[] inputTypes = item.ArrayOf<IGqlpObject<IGqlpInputField>>();
    IGqlpObject<IGqlpOutputField>[] outputTypes = item.ArrayOf<IGqlpObject<IGqlpOutputField>>();
    IGqlpDomain[] domainTypes = item.ArrayOf<IGqlpDomain>();
    IGqlpUnion[] unionTypes = item.ArrayOf<IGqlpUnion>();

    _dualAllTypes.Verify(new(dualTypes, allTypes), errors);
    _enumAllTypes.Verify(new(enumTypes, allTypes), errors);
    _inputAllTypes.Verify(new(inputTypes, allTypes), errors);
    _outputAllTypes.Verify(new(outputTypes, allTypes), errors);
    _domainAllTypes.Verify(new(domainTypes, allTypes), errors);
    _unionAllTypes.Verify(new(unionTypes, allTypes), errors);
  }
}
