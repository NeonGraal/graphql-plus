using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualField(
  Parser<string>.DA aliases,
  Parser<IGqlpModifier>.DA modifiers,
  Parser<IGqlpDualBase>.D parseBase
) : ObjectFieldParser<IGqlpDualField, DualFieldAst, IGqlpDualBase>(aliases, modifiers, parseBase)
{
  protected override void ApplyFieldParameters(DualFieldAst field, IGqlpInputParameter[] parameters)
    => throw new InvalidOperationException();

  protected override DualFieldAst ObjField(TokenAt at, string name, string description, IGqlpDualBase typeBase)
    => new(at, name, description, typeBase);

  protected override IResult<IGqlpDualField> FieldDefault<TContext>(TContext tokens, DualFieldAst field)
    => field.Ok<IGqlpDualField>();

  protected override IResult<IGqlpDualField> FieldEnumValue<TContext>(TContext tokens, DualFieldAst field)
    => tokens.Error<IGqlpDualField>("Dual", "':'", field);

  protected override IResultArray<IGqlpInputParameter> FieldParameter<TContext>(TContext tokens)
    => 0.EmptyArray<IGqlpInputParameter>();

  protected override DualBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
