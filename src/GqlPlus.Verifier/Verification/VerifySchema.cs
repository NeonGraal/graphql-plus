using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifySchema(
  IVerifyAliased<CategoryDeclAst> categoriesAliased,
  IVerifyUsageAliased<CategoryDeclAst, OutputDeclAst> categoryOutputs,
  IVerifyAliased<DirectiveDeclAst> directivesAliased,
  IVerifyUsageAliased<DirectiveDeclAst, InputDeclAst> directiveInputs,
  IVerifyAliased<AstType> typesAliased,
  IVerify<AstType[]> types
) : IVerify<SchemaAst>
{
  public ITokenMessages Verify(SchemaAst target)
  {
    var errors = new TokenMessages();

    var categories = target.Declarations.OfType<CategoryDeclAst>().ToArray();
    var directives = target.Declarations.OfType<DirectiveDeclAst>().ToArray();
    var allTypes = target.Declarations.OfType<AstType>().ToArray();

    errors.AddRange(categoriesAliased.Verify(categories));
    errors.AddRange(categoryOutputs.Verify(new(categories, [.. allTypes.OfType<OutputDeclAst>()])));

    errors.AddRange(directivesAliased.Verify(directives));
    errors.AddRange(directiveInputs.Verify(new(directives, [.. allTypes.OfType<InputDeclAst>()])));

    errors.AddRange(types.Verify(allTypes));
    errors.AddRange(typesAliased.Verify(allTypes));

    errors.AddRange(target.Errors);
    return errors;
  }
}
