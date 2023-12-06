using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification;

internal class VerifySchema(
  IVerifyAliased<CategoryDeclAst> categories,
  IVerifyUsageAliased<CategoryDeclAst, OutputDeclAst> categoryOutputs,
  IVerifyAliased<DirectiveDeclAst> directives,
  IVerifyUsageAliased<DirectiveDeclAst, InputDeclAst> directiveInputs,
  IVerify<AstType[]> types
) : IVerify<SchemaAst>
{
  public ITokenMessages Verify(SchemaAst target)
  {
    var errors = new TokenMessages();

    var allCategories = target.Declarations.OfType<CategoryDeclAst>().ToArray();
    var allDirectives = target.Declarations.OfType<DirectiveDeclAst>().ToArray();
    var allTypes = target.Declarations.OfType<AstType>().ToArray();

    errors.AddRange(categories.Verify(allCategories));
    errors.AddRange(categoryOutputs.Verify(new(allCategories, [.. allTypes.OfType<OutputDeclAst>()])));
    errors.AddRange(directives.Verify(allDirectives));
    errors.AddRange(directiveInputs.Verify(new(allDirectives, [.. allTypes.OfType<InputDeclAst>()])));
    errors.AddRange(types.Verify(allTypes));

    errors.AddRange(target.Errors);
    return errors;
  }
}
