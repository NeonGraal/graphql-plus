using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyAllTypes(
  IVerifyUsageAliased<EnumDeclAst, EnumDeclAst> enumAllTypes,
  IVerifyUsageAliased<InputDeclAst, AstType> inputAllTypes,
  IVerifyUsageAliased<OutputDeclAst, AstType> outputAllTypes,
  IVerifyUsageAliased<ScalarDeclAst, AstType> scalarAllTypes
) : IVerify<AstType[]>
{
  public void Verify(AstType[] item, ITokenMessages errors)
  {
    var enumTypes = item.OfType<EnumDeclAst>().ToArray();
    var inputTypes = item.OfType<InputDeclAst>().ToArray();
    var outputTypes = item.OfType<OutputDeclAst>().ToArray();
    var scalarTypes = item.OfType<ScalarDeclAst>().ToArray();

    var allInputTypes = item.Except(outputTypes).ToArray();
    var allOutputTypes = item.Except(inputTypes).ToArray();

    enumAllTypes.Verify(new(enumTypes, enumTypes), errors);
    inputAllTypes.Verify(new(inputTypes, allInputTypes), errors);
    outputAllTypes.Verify(new(outputTypes, allOutputTypes), errors);
    scalarAllTypes.Verify(new(scalarTypes, item), errors);
  }
}
