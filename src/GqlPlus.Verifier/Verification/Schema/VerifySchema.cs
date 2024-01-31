using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifySchema(
  IVerifyUsage<CategoryDeclAst, OutputDeclAst> categoryOutputs,
  IVerifyUsage<DirectiveDeclAst, InputDeclAst> directiveInputs,
  IVerifyAliased<OptionDeclAst> optionsAliased,
  IVerifyAliased<AstType> typesAliased,
  IVerify<AstType[]> types
) : IVerify<SchemaAst>
{
  public void Verify(SchemaAst item, ITokenMessages errors)
  {
    var categories = item.Declarations.ArrayOf<CategoryDeclAst>();
    var directives = item.Declarations.ArrayOf<DirectiveDeclAst>();
    var options = item.Declarations.ArrayOf<OptionDeclAst>();
    var astTypes = item.Declarations.ArrayOf<AstType>();
    var allTypes = astTypes.Concat(BuiltIn.Basic).Concat(BuiltIn.Internal);

    categoryOutputs.Verify(new(categories, [.. allTypes.OfType<OutputDeclAst>()]), errors);

    directiveInputs.Verify(new(directives, [.. allTypes.OfType<InputDeclAst>()]), errors);

    optionsAliased.Verify(options, errors);

    types.Verify(astTypes, errors);
    typesAliased.Verify(astTypes, errors);

    errors.Add(item.Errors);
  }
}
