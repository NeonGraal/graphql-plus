using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifySchema(
  IVerifyUsageAliased<CategoryDeclAst, OutputDeclAst> categoryOutputs,
  IVerifyUsageAliased<DirectiveDeclAst, InputDeclAst> directiveInputs,
  IVerifyAliased<AstType> typesAliased,
  IVerify<AstType[]> types
) : IVerify<SchemaAst>
{
  public void Verify(SchemaAst item, ITokenMessages errors)
  {
    var categories = item.Declarations.OfType<CategoryDeclAst>().ToArray();
    var directives = item.Declarations.OfType<DirectiveDeclAst>().ToArray();
    var allTypes = item.Declarations.OfType<AstType>().ToArray();

    categoryOutputs.Verify(new(categories, [.. allTypes.OfType<OutputDeclAst>()]), errors);

    directiveInputs.Verify(new(directives, [.. allTypes.OfType<InputDeclAst>()]), errors);

    types.Verify(allTypes, errors);
    typesAliased.Verify(allTypes, errors);

    foreach (var error in item.Errors) {
      errors.Add(error);
    }
  }
}
