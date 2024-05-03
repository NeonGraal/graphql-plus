using GqlPlus.Ast;
using GqlPlus.Result;

namespace GqlPlus.Parse;

public class ParseConstant : ValueParser<ConstantAst>
{
  public ParseConstant(
    Parser<FieldKeyAst>.D fieldKey,
    Parser<KeyValue<ConstantAst>>.D keyValueParser,
    Parser<ConstantAst>.DA listParser,
    Parser<AstFields<ConstantAst>>.D objectParser
  ) : base(fieldKey, keyValueParser, listParser, objectParser) { }

  public override IResult<ConstantAst> Parse<TContext>(TContext tokens, string label)
  {
    ArgumentNullException.ThrowIfNull(tokens);
    Token.TokenAt at = tokens.At;

    IResult<FieldKeyAst> fieldKey = FieldKey.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<ConstantAst>();
    }

    if (fieldKey.HasValue()) {
      return fieldKey.Select(value => new ConstantAst(value));
    }

    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      IResultArray<ConstantAst> list = ListParser.Parse(tokens, label);
      return list.MapOk(
        theList => new ConstantAst(at, theList).Ok(),
        () => list.IsError()
          ? list.AsResult(AstNulls.Constant)
          : ObjectParser.Parse(tokens, label).Select(fields => new ConstantAst(at, fields)));
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }
}
