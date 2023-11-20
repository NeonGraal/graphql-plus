using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

public class ParseConstant : ParseValue<ConstantAst>
{
  public ParseConstant(
      IParser<FieldKeyAst> fieldKey)
    : base(fieldKey) { }

  protected override string Label => "Constant";

  public override IResult<ConstantAst> Parse(Tokenizer tokens)
  {
    var at = tokens.At;

    var fieldKey = _fieldKey.Parse(tokens);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<ConstantAst>();
    }

    if (fieldKey.HasValue()) {
      return fieldKey.Select(value => new ConstantAst(value));
    }

    var oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;

      var list = ParseList(tokens);
      return list.MapOk(
        theList => new ConstantAst(at, theList).Ok(),
        () => list.IsError()
          ? list.AsResult(AstNulls.Constant)
          : ParseObject(tokens).Select(fields => new ConstantAst(at, fields)));
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }

  protected override AstValue<ConstantAst>.ObjectAst NewObject(AstValue<ConstantAst>.ObjectAst? fields = null)
    => fields is null
      ? new ConstantAst.ObjectAst()
      : new ConstantAst.ObjectAst(fields);
}
