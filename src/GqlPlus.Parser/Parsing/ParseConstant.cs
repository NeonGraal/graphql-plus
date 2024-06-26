using GqlPlus.Ast;
using GqlPlus.Result;

namespace GqlPlus.Parsing;

public class ParseConstant(
  Parser<IGqlpFieldKey>.D fieldKey,
  Parser<KeyValue<IGqlpConstant>>.D keyValueParser,
  Parser<IGqlpConstant>.DA listParser,
  Parser<IGqlpFields<IGqlpConstant>>.D objectParser
) : ValueParser<IGqlpConstant>(fieldKey, keyValueParser, listParser, objectParser)
{
  public override IResult<IGqlpConstant> Parse<TContext>(TContext tokens, string label)
  {
    ArgumentNullException.ThrowIfNull(tokens);
    Token.TokenAt at = tokens.At;

    IResult<IGqlpFieldKey> fieldKey = FieldKey.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<IGqlpConstant>();
    }

    if (fieldKey.HasValue()) {
      return fieldKey.Select(value => new ConstantAst((FieldKeyAst)value) as IGqlpConstant);
    }

    bool oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      IResultArray<IGqlpConstant> list = ListParser.Parse(tokens, label);
      return list.MapOk(
        theList => new ConstantAst(at, theList.ArrayOf<ConstantAst>()).Ok<IGqlpConstant>(),
        () => list.IsError()
          ? list.AsResult<IGqlpConstant>(AstNulls.Constant)
          : ObjectParser.Parse(tokens, label).Select(fields => new ConstantAst(at, fields) as IGqlpConstant));
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }
}
