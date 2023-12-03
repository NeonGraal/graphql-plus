using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse;

public class ParseConstant : ValueParser<ConstantAst>
{
  public ParseConstant(
    Parser<FieldKeyAst>.D fieldKey,
    Parser<AstKeyValue<ConstantAst>>.D keyValueParser,
    Parser<ConstantAst>.DA listParser,
    Parser<AstObject<ConstantAst>>.D objectParser
  ) : base(fieldKey, keyValueParser, listParser, objectParser) { }

  protected override string Label => "Constant";

  public override IResult<ConstantAst> Parse<TContext>(TContext tokens, string label)
  {
    var at = tokens.At;

    var fieldKey = FieldKey.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<ConstantAst>();
    }

    if (fieldKey.HasValue()) {
      return fieldKey.Select(value => new ConstantAst(value));
    }

    var oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      var list = ListParser.Parse(tokens, label);
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
