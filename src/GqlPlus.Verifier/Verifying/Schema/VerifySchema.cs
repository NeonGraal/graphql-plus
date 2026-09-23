using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifySchema(IVerifierRepository verifiers) : IVerify<IAstSchema>
{
  private readonly UsageVerifier<IAstSchemaCategory> _categoryOutputs = verifiers.UsageFor<IAstSchemaCategory>();
  private readonly UsageVerifier<IAstSchemaDirective> _directiveInputs = verifiers.UsageFor<IAstSchemaDirective>();
  private readonly AliasVerifier<IAstSchemaOption> _optionsAliased = verifiers.AliasedFor<IAstSchemaOption>();
  private readonly AliasVerifier<IAstType> _typesAliased = verifiers.AliasedFor<IAstType>();
  private readonly Verifier<IAstType[]> _types = verifiers.VerifierFor<IAstType[]>();

  // TODO: Enforce the reserved built-in and introspection-name checks from the schema plan.
  // The verifier includes BuiltIn.Basic and BuiltIn.Internal in the lookup set for type resolution,
  // but it does not yet reject user declarations that reuse names such as "Boolean", "Null",
  // "Unit", "Void", or the "_Schema" family before the merged schema is accepted.
  public void Verify(IAstSchema item, IMessages errors)
  {
    IAstSchemaCategory[] categories = item.Declarations.ArrayOf<IAstSchemaCategory>();
    IAstSchemaDirective[] directives = item.Declarations.ArrayOf<IAstSchemaDirective>();
    IAstSchemaOption[] options = item.Declarations.ArrayOf<IAstSchemaOption>();

    IAstType[] astTypes = item.Declarations.ArrayOf<IAstType>();
    IAstType[] outputTypes = [.. astTypes.Where(ObjectTypeIs<IAstOutputField>), .. BuiltIn.Basic, .. BuiltIn.Internal];
    IAstType[] inputTypes = [.. astTypes.Where(ObjectTypeIs<IAstInputField>), .. BuiltIn.Basic, .. BuiltIn.Internal];

    _categoryOutputs.Verify(new(categories, outputTypes), errors);
    _directiveInputs.Verify(new(directives, inputTypes), errors);
    _optionsAliased.Verify(options, errors);

    _types.Verify(astTypes, errors);
    _typesAliased.Verify(astTypes, errors);

    errors.Add(item.Errors);

    static bool ObjectTypeIs<T>(IAstType type)
      where T : IAstObjField
      => type is IAstObject<T> or IAstObject<IAstDualField>;
  }

  internal static VerifySchema Factory(IVerifierRepository v) => new(v);
}
