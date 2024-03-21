using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class ParseDualField(
  Parser<string>.DA aliases,
  Parser<ModifierAst>.DA modifiers,
  Parser<DualReferenceAst>.D reference
) : ObjectFieldParser<DualFieldAst, DualReferenceAst>(aliases, modifiers, reference)
{

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParameters(DualFieldAst field, ParameterAst[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst Field(TokenAt at, string name, string description, DualReferenceAst typeReference)
    => new(at, name, description, typeReference);

  protected override IResult<DualFieldAst> FieldDefault<TContext>(TContext tokens, DualFieldAst field)
    => field.Ok();

  protected override IResult<DualFieldAst> FieldEnumValue<TContext>(TContext tokens, DualFieldAst field)
    => tokens.Error("Dual", "':'", field);

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => 0.EmptyArray<ParameterAst>();

  protected override DualReferenceAst Reference(TokenAt at, string param, string description)
    => new(at, param, description);
}
