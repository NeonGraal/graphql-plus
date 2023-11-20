using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Parse.Common;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseArgumentValue : ParseValue<ArgumentAst>
{
  private readonly IParser<ConstantAst> _constant;

  public ParseArgumentValue(
      IParser<FieldKeyAst> fieldKey,
      IParser<ConstantAst> constant)
    : base(fieldKey)
    => _constant = constant.ThrowIfNull();

  protected override string Label => "Argument";

  public override IResult<ArgumentAst> Parse(Tokenizer tokens)
  {
    _ = tokens.At;
    if (!tokens.Prefix('$', out var variable, out ParseAt? at)) {
      return tokens.Error<ArgumentAst>("Argument", "identifier after '$'");
    }

    if (variable is not null) {
      var argument = new ArgumentAst(at, variable);

      // TODO: Variables.Add(argument);

      return argument.Ok();
    }

    var oldSeparators = tokens.IgnoreSeparators;
    try {
      tokens.IgnoreSeparators = false;
      at = tokens.At;

      var list = ParseList(tokens);
      if (!list.IsEmpty()) {
        return list.Select(value => new ArgumentAst(at, value));
      }

      var fields = ParseObject(tokens);
      if (!fields.IsEmpty()) {
        return fields.Select(value => new ArgumentAst(at, value));
      }
    } finally {
      tokens.IgnoreSeparators = oldSeparators;
    }

    return _constant.Parse(tokens).MapOk(
      constant => new ArgumentAst(constant).Ok(),
      () => 0.Empty<ArgumentAst>());
  }

  protected override AstValue<ArgumentAst>.ObjectAst NewObject(AstValue<ArgumentAst>.ObjectAst? fields = null)
    => fields is null
      ? new AstValue<ArgumentAst>.ObjectAst()
      : new AstValue<ArgumentAst>.ObjectAst(fields);
}
