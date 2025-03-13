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
    tokens.ThrowIfNull();
#pragma warning disable CA1062 // Validate arguments of public methods
    Token.TokenAt at = tokens.At;
#pragma warning restore CA1062 // Validate arguments of public methods

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
          ? list.AsResult<IGqlpConstant>()
          : ObjectParser.Parse(tokens, label).Select(fields => new ConstantAst(at, fields) as IGqlpConstant));
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }
}
