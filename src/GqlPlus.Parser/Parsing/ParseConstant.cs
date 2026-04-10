using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseConstant(
  IParserRepository parsers
) : ValueParser<IAstConstant>(parsers)
{
  public override IResult<IAstConstant> Parse([NotNull] ITokenizer tokens, string label)
  {
    tokens.ThrowIfNull();
#pragma warning disable CA1062 // Validate arguments of public methods
    Token.TokenAt at = tokens.At;
#pragma warning restore CA1062 // Validate arguments of public methods

    IResult<IAstFieldKey> fieldKey = FieldKey.Parse(tokens, label);
    if (fieldKey.IsError()) {
      return fieldKey.AsResult<IAstConstant>();
    }

    if (fieldKey.HasValue()) {
      return fieldKey.Select(value => new ConstantAst(value) as IAstConstant);
    }

    return base.Parse(tokens, label);
  }

  protected override Func<IAstFields<IAstConstant>, IAstConstant> NewFields(ITokenAt at)
    => fields => new ConstantAst(at, fields);
  protected override Func<IEnumerable<IAstConstant>, IAstConstant> NewList(ITokenAt at)
    => list => new ConstantAst(at, list);
}
