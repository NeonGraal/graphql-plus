using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifySchema(
  IVerifyAliased<CategoryAst> categories,
  IVerifyUsageAliased<CategoryAst, OutputAst> categoryOutputs,
  IVerifyUsageAliased<EnumAst, AstType> enumAllTypes,
  IVerifyUsageAliased<InputAst, AstType> inputAllTypes,
  IVerifyUsageAliased<OutputAst, AstType> outputAllTypes,
  IVerifyUsageAliased<ScalarAst, AstType> scalarAllTypes
) : IVerify<SchemaAst>
{
  public ITokenMessages Verify(SchemaAst target)
  {
    var errors = new TokenMessages();

    var categoryDeclarations = target.Declarations.OfType<CategoryAst>().ToArray();

    errors.AddRange(categories.Verify(categoryDeclarations));

    var allTypes = target.Declarations.OfType<AstType>().ToArray();

    var enumTypes = allTypes.OfType<EnumAst>().ToArray();
    var inputTypes = allTypes.OfType<InputAst>().ToArray();
    var outputTypes = allTypes.OfType<OutputAst>().ToArray();
    var scalarTypes = allTypes.OfType<ScalarAst>().ToArray();

    var allInputTypes = allTypes.Except(outputTypes).ToArray();
    var allOutputTypes = allTypes.Except(inputTypes).ToArray();

    errors.AddRange(categoryOutputs.Verify(new(categoryDeclarations, outputTypes)));

    errors.AddRange(enumAllTypes.Verify(new(enumTypes, allTypes)));
    errors.AddRange(inputAllTypes.Verify(new(inputTypes, allInputTypes)));
    errors.AddRange(outputAllTypes.Verify(new(outputTypes, allOutputTypes)));
    errors.AddRange(scalarAllTypes.Verify(new(scalarTypes, allTypes)));

    errors.AddRange(target.Errors);
    return errors;
  }
}
