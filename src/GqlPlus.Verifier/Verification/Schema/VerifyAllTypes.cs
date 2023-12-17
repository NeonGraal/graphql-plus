using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyAllTypes(
  IVerifyUsage<EnumDeclAst, EnumDeclAst> enumAllTypes,
  IVerifyUsage<InputDeclAst, AstType> inputAllTypes,
  IVerifyUsage<OutputDeclAst, AstType> outputAllTypes,
  IVerifyAliased<ScalarDeclAst> scalarAllTypes
) : IVerify<AstType[]>
{
  public void Verify(AstType[] item, ITokenMessages errors)
  {
    var allTypes = item.Concat(BuiltIn.Basic).Concat(BuiltIn.Internal).ToArray();

    var enumTypes = allTypes.OfType<EnumDeclAst>().ToArray();
    var inputTypes = allTypes.OfType<InputDeclAst>().ToArray();
    var outputTypes = allTypes.OfType<OutputDeclAst>().ToArray();
    var scalarTypes = allTypes.OfType<ScalarDeclAst>().ToArray();

    enumAllTypes.Verify(new(enumTypes, enumTypes), errors);
    inputAllTypes.Verify(new(inputTypes, allTypes), errors);
    outputAllTypes.Verify(new(outputTypes, allTypes), errors);
    scalarAllTypes.Verify(scalarTypes, errors);
  }
}
