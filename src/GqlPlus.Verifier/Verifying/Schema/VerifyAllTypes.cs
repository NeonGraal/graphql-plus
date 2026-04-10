using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypes(IVerifierRepository verifiers) : IVerify<IAstType[]>
{
  private readonly IVerifyUsage<IAstObject<IAstDualField>> _dualAllTypes = verifiers.UsageFor<IAstObject<IAstDualField>>();
  private readonly IVerifyUsage<IAstEnum> _enumAllTypes = verifiers.UsageFor<IAstEnum>();
  private readonly IVerifyUsage<IAstObject<IAstInputField>> _inputAllTypes = verifiers.UsageFor<IAstObject<IAstInputField>>();
  private readonly IVerifyUsage<IAstObject<IAstOutputField>> _outputAllTypes = verifiers.UsageFor<IAstObject<IAstOutputField>>();
  private readonly IVerifyUsage<IAstDomain> _domainAllTypes = verifiers.UsageFor<IAstDomain>();
  private readonly IVerifyUsage<IAstUnion> _unionAllTypes = verifiers.UsageFor<IAstUnion>();

  public void Verify(IAstType[] item, IMessages errors)
  {
    IAstType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    IAstObject<IAstDualField>[] dualTypes = item.ArrayOf<IAstObject<IAstDualField>>();
    IAstEnum[] enumTypes = item.ArrayOf<IAstEnum>();
    IAstObject<IAstInputField>[] inputTypes = item.ArrayOf<IAstObject<IAstInputField>>();
    IAstObject<IAstOutputField>[] outputTypes = item.ArrayOf<IAstObject<IAstOutputField>>();
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
