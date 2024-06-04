using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifySchema(
  IVerifyUsage<IGqlpSchemaCategory> categoryOutputs,
  IVerifyUsage<IGqlpSchemaDirective> directiveInputs,
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
    IGqlpType[] outputTypes = [.. astTypes.Where(t => t is IGqlpOutputObject), .. BuiltIn.Basic, .. BuiltIn.Internal];
    IGqlpType[] inputTypes = [.. astTypes.Where(t => t is IGqlpInputObject), .. BuiltIn.Basic, .. BuiltIn.Internal];

    categoryOutputs.Verify(new(categories, outputTypes), errors);
    directiveInputs.Verify(new(directives, inputTypes), errors);
    optionsAliased.Verify(options, errors);

    types.Verify(astTypes, errors);
    typesAliased.Verify(astTypes, errors);

    errors.Add(item.Errors);
  }
}
