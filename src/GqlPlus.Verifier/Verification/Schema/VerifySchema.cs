using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Verification.Schema;

internal class VerifySchema(
  IVerifyUsage<IGqlpSchemaCategory, OutputDeclAst> categoryOutputs,
  IVerifyUsage<IGqlpSchemaDirective, InputDeclAst> directiveInputs,
  IVerifyAliased<IGqlpSchemaOption> optionsAliased,
  IVerifyAliased<IGqlpType> typesAliased,
  IVerify<IGqlpType[]> types
) : IVerify<IGqlpSchema>
{
  public void Verify(IGqlpSchema item, ITokenMessages errors)
  {
    IGqlpSchemaCategory[] categories = item.Declarations.ArrayOf<IGqlpSchemaCategory>();
    IGqlpSchemaDirective[] directives = item.Declarations.ArrayOf<IGqlpSchemaDirective>();
    IGqlpSchemaOption[] options = item.Declarations.ArrayOf<IGqlpSchemaOption>();
    IGqlpType[] astTypes = item.Declarations.ArrayOf<IGqlpType>();
    IEnumerable<IGqlpType> allTypes = astTypes.Concat(BuiltIn.Basic).Concat(BuiltIn.Internal);

    categoryOutputs.Verify(new(categories, allTypes.ArrayOf<OutputDeclAst>()), errors);

    directiveInputs.Verify(new(directives, allTypes.ArrayOf<InputDeclAst>()), errors);

    optionsAliased.Verify(options, errors);

    types.Verify(astTypes, errors);
    typesAliased.Verify(astTypes, errors);

    errors.Add(item.Errors);
  }
}
