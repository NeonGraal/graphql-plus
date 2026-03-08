using GqlPlus.Ast;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing;

internal class ParseConstant(
  IParserRepository parsers
) : ValueParser<IGqlpConstant>(parsers)
{
  public override IResult<IGqlpConstant> Parse([NotNull] ITokenizer tokens, string label)
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
      return fieldKey.Select(value => new ConstantAst(value) as IGqlpConstant);
    }

    return base.Parse(tokens, label);
  }

  protected override Func<IGqlpFields<IGqlpConstant>, IGqlpConstant> NewFields(ITokenAt at)
    => fields => new ConstantAst(at, fields);
  protected override Func<IEnumerable<IGqlpConstant>, IGqlpConstant> NewList(ITokenAt at)
    => list => new ConstantAst(at, list);
}
