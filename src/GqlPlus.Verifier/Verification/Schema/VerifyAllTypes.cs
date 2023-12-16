using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyAllTypes(
  IVerifyUsageAliased<EnumDeclAst, EnumDeclAst> enumAllTypes,
  IVerifyUsageAliased<InputDeclAst, AstType> inputAllTypes,
  IVerifyUsageAliased<OutputDeclAst, AstType> outputAllTypes,
  IVerifyAliased<ScalarDeclAst> scalarAllTypes
) : IVerify<AstType[]>
{
  public void Verify(AstType[] item, ITokenMessages errors)
  {
    var allTypes = item.Concat(BuiltIn.Basic).Concat(BuiltIn.Internal);

    var enumTypes = allTypes.OfType<EnumDeclAst>().ToArray();
    var inputTypes = allTypes.OfType<InputDeclAst>().ToArray();
    var outputTypes = allTypes.OfType<OutputDeclAst>().ToArray();
    var scalarTypes = allTypes.OfType<ScalarDeclAst>().ToArray();

    var allInputTypes = allTypes.Except(outputTypes).ToArray();
    var allOutputTypes = allTypes.Except(inputTypes).ToArray();

    enumAllTypes.Verify(new(enumTypes, enumTypes), errors);
    inputAllTypes.Verify(new(inputTypes, allInputTypes), errors);
    outputAllTypes.Verify(new(outputTypes, allOutputTypes), errors);
    scalarAllTypes.Verify(scalarTypes, errors);
  }
}
