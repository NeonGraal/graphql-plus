using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Parse.Common;

public class ParseConstant : ParseValues<ConstantAst>
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

      var list = ParseConstList(tokens);
      return list.MapOk(
        theList => new ConstantAst(at, theList).Ok(),
        () => list.IsError()
          ? list.AsResult(AstNulls.Constant)
          : ParseConstObject(tokens).Select(fields => new ConstantAst(at, fields)));
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }
  }
  private IResultArray<ConstantAst> ParseConstList(Tokenizer tokens)
  {
    var list = new List<ConstantAst>();

    if (!tokens.Take('[')) {
      return list.EmptyArray();
    }

    while (!tokens.Take(']')) {
      var constant = Parse(tokens);
      if (!constant.Required(list.Add)) {
        return tokens.PartialArray("Constant", "value in list", list.ToArray);
      }

      tokens.Take(',');
    }

    return list.OkArray();
  }

  private IResult<ConstantAst.ObjectAst> ParseConstObject(Tokenizer tokens)
  {
    var fields = new ConstantAst.ObjectAst();

    if (!tokens.Take('{')) {
      return fields.Empty();
    }

    while (!tokens.Take('}')) {
      var field = ParseField(tokens, "Constant");

      if (!field.Required(value => fields.Add(value.Key, value.Value))) {
        return field.AsResult(fields);
      }

      tokens.Take(',');
    }

    return fields.Ok();
  }
}
