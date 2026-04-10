using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifySchema(IVerifierRepository verifiers) : IVerify<IAstSchema>
{
  private readonly IVerifyUsage<IAstSchemaCategory> _categoryOutputs = verifiers.UsageFor<IAstSchemaCategory>();
  private readonly IVerifyUsage<IAstSchemaDirective> _directiveInputs = verifiers.UsageFor<IAstSchemaDirective>();
  private readonly IVerifyAliased<IAstSchemaOption> _optionsAliased = verifiers.AliasedFor<IAstSchemaOption>();
  private readonly IVerifyAliased<IAstType> _typesAliased = verifiers.AliasedFor<IAstType>();
  private readonly IVerify<IAstType[]> _types = verifiers.VerifierFor<IAstType[]>();

  public void Verify(IAstSchema item, IMessages errors)
  {
    IAstSchemaCategory[] categories = item.Declarations.ArrayOf<IAstSchemaCategory>();
    IAstSchemaDirective[] directives = item.Declarations.ArrayOf<IAstSchemaDirective>();
    IAstSchemaOption[] options = item.Declarations.ArrayOf<IAstSchemaOption>();

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
