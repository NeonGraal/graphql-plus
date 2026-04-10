using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifySchema(IVerifierRepository verifiers) : IVerify<IAstSchema>
{
  private readonly IVerifyUsage<IGqlpSchemaCategory> _categoryOutputs = verifiers.UsageFor<IGqlpSchemaCategory>();
  private readonly IVerifyUsage<IGqlpSchemaDirective> _directiveInputs = verifiers.UsageFor<IGqlpSchemaDirective>();
  private readonly IVerifyAliased<IGqlpSchemaOption> _optionsAliased = verifiers.AliasedFor<IGqlpSchemaOption>();
  private readonly IVerifyAliased<IGqlpType> _typesAliased = verifiers.AliasedFor<IGqlpType>();
  private readonly IVerify<IGqlpType[]> _types = verifiers.VerifierFor<IGqlpType[]>();

  public void Verify(IAstSchema item, IMessages errors)
  {
    IGqlpSchemaCategory[] categories = item.Declarations.ArrayOf<IGqlpSchemaCategory>();
    IGqlpSchemaDirective[] directives = item.Declarations.ArrayOf<IGqlpSchemaDirective>();
    IGqlpSchemaOption[] options = item.Declarations.ArrayOf<IGqlpSchemaOption>();

    IGqlpType[] astTypes = item.Declarations.ArrayOf<IGqlpType>();
    IGqlpType[] outputTypes = [.. astTypes.Where(TypeIs<IGqlpObject<IGqlpOutputField>>), .. BuiltIn.Basic, .. BuiltIn.Internal];
    IGqlpType[] inputTypes = [.. astTypes.Where(TypeIs<IGqlpObject<IGqlpInputField>>), .. BuiltIn.Basic, .. BuiltIn.Internal];

    _categoryOutputs.Verify(new(categories, outputTypes), errors);
    _directiveInputs.Verify(new(directives, inputTypes), errors);
    _optionsAliased.Verify(options, errors);

    _types.Verify(astTypes, errors);
    _typesAliased.Verify(astTypes, errors);

    errors.Add(item.Errors);

    static bool TypeIs<T>(IGqlpType type)
      where T : IGqlpType
      => type is T;
  }
}
