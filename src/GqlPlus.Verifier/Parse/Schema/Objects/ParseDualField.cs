using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal class ParseDualField(
  Parser<string>.DA aliases,
  Parser<ModifierAst>.DA modifiers,
  Parser<DualBaseAst>.D objBase
) : ObjectFieldParser<DualFieldAst, DualBaseAst>(aliases, modifiers, objBase)
{

  [ExcludeFromCodeCoverage]
  protected override void ApplyFieldParameters(DualFieldAst field, ParameterAst[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst ObjField(TokenAt at, string name, string description, DualBaseAst typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<DualFieldAst> FieldDefault<TContext>(TContext tokens, DualFieldAst field)
    => field.Ok();

  protected override IResult<DualFieldAst> FieldEnumValue<TContext>(TContext tokens, DualFieldAst field)
    => tokens.Error("Dual", "':'", field);

  protected override IResultArray<ParameterAst> FieldParameter<TContext>(TContext tokens)
    => 0.EmptyArray<ParameterAst>();

  protected override DualBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
