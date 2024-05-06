using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Verification.Schema;

internal class VerifyAllTypes(
  IVerifyUsage<DualDeclAst, IGqlpType> dualAllTypes,
  IVerifyUsage<IGqlpEnum, IGqlpType> enumAllTypes,
  IVerifyUsage<InputDeclAst, IGqlpType> inputAllTypes,
  IVerifyUsage<OutputDeclAst, IGqlpType> outputAllTypes,
  IVerifyUsage<IGqlpDomain, IGqlpType> domainAllTypes,
  IVerifyUsage<IGqlpUnion, IGqlpType> unionAllTypes
) : IVerify<IGqlpType[]>
{
  public void Verify(IGqlpType[] item, ITokenMessages errors)
  {
    IGqlpType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    DualDeclAst[] dualTypes = allTypes.ArrayOf<DualDeclAst>();
    IGqlpEnum[] enumTypes = allTypes.ArrayOf<IGqlpEnum>();
    InputDeclAst[] inputTypes = allTypes.ArrayOf<InputDeclAst>();
    OutputDeclAst[] outputTypes = allTypes.ArrayOf<OutputDeclAst>();
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
