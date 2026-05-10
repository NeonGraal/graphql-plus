using GqlPlus.Ast.Schema;

namespace GqlPlus.Verifying.Schema;

internal class VerifySchema(IVerifierRepository verifiers) : IVerify<IAstSchema>
{
  private readonly DeferOne<IVerifyUsage<IAstSchemaCategory>> _categoryOutputs = verifiers.UsageFor<IAstSchemaCategory>();
  private readonly DeferOne<IVerifyUsage<IAstSchemaDirective>> _directiveInputs = verifiers.UsageFor<IAstSchemaDirective>();
  private readonly DeferOne<IVerifyAliased<IAstSchemaOption>> _optionsAliased = verifiers.AliasedFor<IAstSchemaOption>();
  private readonly DeferOne<IVerifyAliased<IAstType>> _typesAliased = verifiers.AliasedFor<IAstType>();
  private readonly DeferOne<IVerify<IAstType[]>> _types = verifiers.VerifierFor<IAstType[]>();

  public void Verify(IAstSchema item, IMessages errors)
  {
    IAstSchemaCategory[] categories = item.Declarations.ArrayOf<IAstSchemaCategory>();
    IAstSchemaDirective[] directives = item.Declarations.ArrayOf<IAstSchemaDirective>();
    IAstSchemaOption[] options = item.Declarations.ArrayOf<IAstSchemaOption>();

    IAstType[] astTypes = item.Declarations.ArrayOf<IAstType>();
    IAstType[] outputTypes = [.. astTypes.Where(ObjectTypeIs<IAstOutputField>), .. BuiltIn.Basic, .. BuiltIn.Internal];
    IAstType[] inputTypes = [.. astTypes.Where(ObjectTypeIs<IAstInputField>), .. BuiltIn.Basic, .. BuiltIn.Internal];

    _categoryOutputs.I.Verify(new(categories, outputTypes), errors);
    _directiveInputs.I.Verify(new(directives, inputTypes), errors);
    _optionsAliased.I.Verify(options, errors);

    _types.I.Verify(astTypes, errors);
    _typesAliased.I.Verify(astTypes, errors);

    errors.Add(item.Errors);

    static bool ObjectTypeIs<T>(IAstType type)
      where T : IAstObjField
      => type is IAstObject<T> or IAstObject<IAstDualField>;
  }

  internal static VerifySchema Factory(IVerifierRepository v) => new(v);
}
