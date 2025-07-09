using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifyAllTypes(
  IVerifyUsage<IGqlpDualObject> dualAllTypes,
  IVerifyUsage<IGqlpEnum> enumAllTypes,
  IVerifyUsage<IGqlpInputObject> inputAllTypes,
  IVerifyUsage<IGqlpOutputObject> outputAllTypes,
  IVerifyUsage<IGqlpDomain> domainAllTypes,
  IVerifyUsage<IGqlpUnion> unionAllTypes
) : IVerify<IGqlpType[]>
{
  public void Verify(IGqlpType[] item, IMessages errors)
  {
    IGqlpType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    IGqlpDualObject[] dualTypes = item.ArrayOf<IGqlpDualObject>();
    IGqlpEnum[] enumTypes = item.ArrayOf<IGqlpEnum>();
    IGqlpInputObject[] inputTypes = item.ArrayOf<IGqlpInputObject>();
    IGqlpOutputObject[] outputTypes = item.ArrayOf<IGqlpOutputObject>();
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
