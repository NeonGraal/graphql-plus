using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifySchema(IVerifierRepository verifiers) : IVerify<IAstSchema>
{
  private readonly IVerifyUsage<IGqlpSchemaCategory> _categoryOutputs = verifiers.UsageFor<IGqlpSchemaCategory>();
  private readonly IVerifyUsage<IGqlpSchemaDirective> _directiveInputs = verifiers.UsageFor<IGqlpSchemaDirective>();
  private readonly IVerifyAliased<IGqlpSchemaOption> _optionsAliased = verifiers.AliasedFor<IGqlpSchemaOption>();
  private readonly IVerifyAliased<IAstType> _typesAliased = verifiers.AliasedFor<IAstType>();
  private readonly IVerify<IAstType[]> _types = verifiers.VerifierFor<IAstType[]>();

  public void Verify(IAstSchema item, IMessages errors)
  {
    IGqlpSchemaCategory[] categories = item.Declarations.ArrayOf<IGqlpSchemaCategory>();
    IGqlpSchemaDirective[] directives = item.Declarations.ArrayOf<IGqlpSchemaDirective>();
    IGqlpSchemaOption[] options = item.Declarations.ArrayOf<IGqlpSchemaOption>();

    IAstType[] astTypes = item.Declarations.ArrayOf<IAstType>();
    IAstType[] outputTypes = [.. astTypes.Where(TypeIs<IGqlpObject<IGqlpOutputField>>), .. BuiltIn.Basic, .. BuiltIn.Internal];
    IAstType[] inputTypes = [.. astTypes.Where(TypeIs<IGqlpObject<IGqlpInputField>>), .. BuiltIn.Basic, .. BuiltIn.Internal];

    _categoryOutputs.Verify(new(categories, outputTypes), errors);
    _directiveInputs.Verify(new(directives, inputTypes), errors);
    _optionsAliased.Verify(options, errors);

    _types.Verify(astTypes, errors);
    _typesAliased.Verify(astTypes, errors);

    errors.Add(item.Errors);

    static bool TypeIs<T>(IAstType type)
      where T : IAstType
      => type is T;
  }
}
