using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyAllTypes(
  IVerifyUsage<DualDeclAst, AstType> dualAllTypes,
  IVerifyUsage<EnumDeclAst, AstType> enumAllTypes,
  IVerifyUsage<InputDeclAst, AstType> inputAllTypes,
  IVerifyUsage<OutputDeclAst, AstType> outputAllTypes,
  IVerifyUsage<AstScalar, AstType> scalarAllTypes,
  IVerifyUsage<UnionDeclAst, AstType> unionAllTypes
) : IVerify<AstType[]>
{
  public void Verify(AstType[] item, ITokenMessages errors)
  {
    var allTypes = item.Concat(BuiltIn.Basic).Concat(BuiltIn.Internal).ToArray();

    var dualTypes = allTypes.ArrayOf<DualDeclAst>();
    var enumTypes = allTypes.ArrayOf<EnumDeclAst>();
    var inputTypes = allTypes.ArrayOf<InputDeclAst>();
    var outputTypes = allTypes.ArrayOf<OutputDeclAst>();
    var scalarTypes = allTypes.ArrayOf<AstScalar>();
    var unionTypes = allTypes.ArrayOf<UnionDeclAst>();

    dualAllTypes.Verify(new(dualTypes, allTypes), errors);
    enumAllTypes.Verify(new(enumTypes, allTypes), errors);
    inputAllTypes.Verify(new(inputTypes, allTypes), errors);
    outputAllTypes.Verify(new(outputTypes, allTypes), errors);
    scalarAllTypes.Verify(new(scalarTypes, allTypes), errors);
    unionAllTypes.Verify(new(unionTypes, allTypes), errors);
  }
}
