using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypes(
  IVerifyUsage<IGqlpObject<IGqlpDualField>> dualAllTypes,
  IVerifyUsage<IGqlpEnum> enumAllTypes,
  IVerifyUsage<IGqlpObject<IGqlpInputField>> inputAllTypes,
  IVerifyUsage<IGqlpObject<IGqlpOutputField>> outputAllTypes,
  IVerifyUsage<IGqlpDomain> domainAllTypes,
  IVerifyUsage<IGqlpUnion> unionAllTypes
) : IVerify<IGqlpType[]>
{
  public void Verify(IGqlpType[] item, IMessages errors)
  {
    IGqlpType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    IGqlpObject<IGqlpDualField>[] dualTypes = item.ArrayOf<IGqlpObject<IGqlpDualField>>();
    IGqlpEnum[] enumTypes = item.ArrayOf<IGqlpEnum>();
    IGqlpObject<IGqlpInputField>[] inputTypes = item.ArrayOf<IGqlpObject<IGqlpInputField>>();
    IGqlpObject<IGqlpOutputField>[] outputTypes = item.ArrayOf<IGqlpObject<IGqlpOutputField>>();
    IGqlpDomain[] domainTypes = item.ArrayOf<IGqlpDomain>();
    IGqlpUnion[] unionTypes = item.ArrayOf<IGqlpUnion>();

    dualAllTypes.Verify(new(dualTypes, allTypes), errors);
    enumAllTypes.Verify(new(enumTypes, allTypes), errors);
    inputAllTypes.Verify(new(inputTypes, allTypes), errors);
    outputAllTypes.Verify(new(outputTypes, allTypes), errors);
    domainAllTypes.Verify(new(domainTypes, allTypes), errors);
    unionAllTypes.Verify(new(unionTypes, allTypes), errors);
  }
}
