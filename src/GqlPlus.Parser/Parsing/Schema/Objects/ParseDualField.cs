using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpDualBase>.D objBase
) : ObjectFieldParser<DualFieldAst, IGqlpDualBase>(aliases, modifiers, objBase)
{
  protected override void ApplyFieldParameters(DualFieldAst field, InputParameterAst[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst ObjField(TokenAt at, string name, string description, IGqlpDualBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<DualFieldAst> FieldDefault<TContext>(TContext tokens, DualFieldAst field)
    => field.Ok();

  protected override IResult<DualFieldAst> FieldEnumValue<TContext>(TContext tokens, DualFieldAst field)
    => tokens.Error("Dual", "':'", field);

  protected override IResultArray<InputParameterAst> FieldParameter<TContext>(TContext tokens)
    => 0.EmptyArray<InputParameterAst>();

  protected override DualBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
