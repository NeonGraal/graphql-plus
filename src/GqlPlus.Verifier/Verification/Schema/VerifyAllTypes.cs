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
  public ITokenMessages Verify(AstType[] target)
  {
    var errors = new TokenMessages();

    var enumTypes = target.OfType<EnumDeclAst>().ToArray();
    var inputTypes = target.OfType<InputDeclAst>().ToArray();
    var outputTypes = target.OfType<OutputDeclAst>().ToArray();
    var scalarTypes = target.OfType<ScalarDeclAst>().ToArray();

    var allInputTypes = target.Except(outputTypes).ToArray();
    var allOutputTypes = target.Except(inputTypes).ToArray();

    errors.AddRange(enumAllTypes.Verify(new(enumTypes, enumTypes)));
    errors.AddRange(inputAllTypes.Verify(new(inputTypes, allInputTypes)));
    errors.AddRange(outputAllTypes.Verify(new(outputTypes, allOutputTypes)));
    errors.AddRange(scalarAllTypes.Verify(new(scalarTypes, target)));

    return errors;
  }
}
