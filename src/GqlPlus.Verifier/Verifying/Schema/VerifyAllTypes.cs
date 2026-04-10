using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypes(IVerifierRepository verifiers) : IVerify<IAstType[]>
{
  private readonly IVerifyUsage<IGqlpObject<IGqlpDualField>> _dualAllTypes = verifiers.UsageFor<IGqlpObject<IGqlpDualField>>();
  private readonly IVerifyUsage<IAstEnum> _enumAllTypes = verifiers.UsageFor<IAstEnum>();
  private readonly IVerifyUsage<IGqlpObject<IGqlpInputField>> _inputAllTypes = verifiers.UsageFor<IGqlpObject<IGqlpInputField>>();
  private readonly IVerifyUsage<IGqlpObject<IGqlpOutputField>> _outputAllTypes = verifiers.UsageFor<IGqlpObject<IGqlpOutputField>>();
  private readonly IVerifyUsage<IAstDomain> _domainAllTypes = verifiers.UsageFor<IAstDomain>();
  private readonly IVerifyUsage<IAstUnion> _unionAllTypes = verifiers.UsageFor<IAstUnion>();

  public void Verify(IAstType[] item, IMessages errors)
  {
    IAstType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    IGqlpObject<IGqlpDualField>[] dualTypes = item.ArrayOf<IGqlpObject<IGqlpDualField>>();
    IAstEnum[] enumTypes = item.ArrayOf<IAstEnum>();
    IGqlpObject<IGqlpInputField>[] inputTypes = item.ArrayOf<IGqlpObject<IGqlpInputField>>();
    IGqlpObject<IGqlpOutputField>[] outputTypes = item.ArrayOf<IGqlpObject<IGqlpOutputField>>();
    IAstDomain[] domainTypes = item.ArrayOf<IAstDomain>();
    IAstUnion[] unionTypes = item.ArrayOf<IAstUnion>();

    _dualAllTypes.Verify(new(dualTypes, allTypes), errors);
    _enumAllTypes.Verify(new(enumTypes, allTypes), errors);
    _inputAllTypes.Verify(new(inputTypes, allTypes), errors);
    _outputAllTypes.Verify(new(outputTypes, allTypes), errors);
    _domainAllTypes.Verify(new(domainTypes, allTypes), errors);
    _unionAllTypes.Verify(new(unionTypes, allTypes), errors);
  }
}
