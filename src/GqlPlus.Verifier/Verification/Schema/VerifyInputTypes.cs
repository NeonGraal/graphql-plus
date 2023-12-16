using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Verification.Schema;

internal class VerifyInputTypes(
  IVerifyAliased<InputDeclAst> aliased
) : AstObjectTypesVerifier<InputDeclAst, InputFieldAst, InputReferenceAst>(aliased)
{
  public override string Label => "Input";

  protected override void UsageField(InputFieldAst field, IMap<AstType[]> byId, ITokenMessages errors)
  {
    base.UsageField(field, byId, errors);

    if (field.Default?.Value?.EnumValue == "Null.null" && !(field.Modifiers.LastOrDefault()?.Kind == ModifierKind.Optional)) {
      errors.AddError(field, $"Invalid Input Field Default. 'null' default requires Optional type, not '{field.ModifiedType}'.");
    }
  }
}
