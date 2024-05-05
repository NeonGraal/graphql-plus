using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Verification.Schema;

internal class VerifyAllTypes(
  IVerifyUsage<DualDeclAst, IGqlpType> dualAllTypes,
  IVerifyUsage<EnumDeclAst, IGqlpType> enumAllTypes,
  IVerifyUsage<InputDeclAst, IGqlpType> inputAllTypes,
  IVerifyUsage<OutputDeclAst, IGqlpType> outputAllTypes,
  IVerifyUsage<AstDomain, IGqlpType> domainAllTypes,
  IVerifyUsage<UnionDeclAst, IGqlpType> unionAllTypes
) : IVerify<IGqlpType[]>
{
  public void Verify(IGqlpType[] item, ITokenMessages errors)
  {
    IGqlpType[] allTypes = [.. item, .. BuiltIn.Basic, .. BuiltIn.Internal];

    DualDeclAst[] dualTypes = allTypes.ArrayOf<DualDeclAst>();
    EnumDeclAst[] enumTypes = allTypes.ArrayOf<EnumDeclAst>();
    InputDeclAst[] inputTypes = allTypes.ArrayOf<InputDeclAst>();
    OutputDeclAst[] outputTypes = allTypes.ArrayOf<OutputDeclAst>();
    AstDomain[] domainTypes = allTypes.ArrayOf<AstDomain>();
    UnionDeclAst[] unionTypes = allTypes.ArrayOf<UnionDeclAst>();

    dualAllTypes.Verify(new(dualTypes, allTypes), errors);
    enumAllTypes.Verify(new(enumTypes, allTypes), errors);
    inputAllTypes.Verify(new(inputTypes, allTypes), errors);
    outputAllTypes.Verify(new(outputTypes, allTypes), errors);
    domainAllTypes.Verify(new(domainTypes, allTypes), errors);
    unionAllTypes.Verify(new(unionTypes, allTypes), errors);
  }
}
