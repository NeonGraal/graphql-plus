using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Token;

namespace GqlPlus.Verification.Schema;

internal class VerifyAllTypes(
  IVerifyUsage<DualDeclAst, AstType> dualAllTypes,
  IVerifyUsage<EnumDeclAst, AstType> enumAllTypes,
  IVerifyUsage<InputDeclAst, AstType> inputAllTypes,
  IVerifyUsage<OutputDeclAst, AstType> outputAllTypes,
  IVerifyUsage<AstDomain, AstType> domainAllTypes,
  IVerifyUsage<UnionDeclAst, AstType> unionAllTypes
) : IVerify<AstType[]>
{
  public void Verify(AstType[] item, ITokenMessages errors)
  {
    AstType[] allTypes = item.Concat(BuiltIn.Basic).Concat(BuiltIn.Internal).ToArray();

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
