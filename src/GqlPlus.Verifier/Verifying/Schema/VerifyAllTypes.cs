using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

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
  public void Verify(IGqlpType[] item, ITokenMessages errors)
  {
    IGqlpType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    IGqlpDualObject[] dualTypes = allTypes.ArrayOf<IGqlpDualObject>();
    IGqlpEnum[] enumTypes = allTypes.ArrayOf<IGqlpEnum>();
    IGqlpInputObject[] inputTypes = allTypes.ArrayOf<IGqlpInputObject>();
    IGqlpOutputObject[] outputTypes = allTypes.ArrayOf<IGqlpOutputObject>();
    IGqlpDomain[] domainTypes = allTypes.ArrayOf<IGqlpDomain>();
    IGqlpUnion[] unionTypes = allTypes.ArrayOf<IGqlpUnion>();

    dualAllTypes.Verify(new(dualTypes, allTypes), errors);
    enumAllTypes.Verify(new(enumTypes, allTypes), errors);
    inputAllTypes.Verify(new(inputTypes, allTypes), errors);
    outputAllTypes.Verify(new(outputTypes, allTypes), errors);
    domainAllTypes.Verify(new(domainTypes, allTypes), errors);
    unionAllTypes.Verify(new(unionTypes, allTypes), errors);
  }
}
