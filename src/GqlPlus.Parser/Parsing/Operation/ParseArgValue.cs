using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseArgValue(
  IParserRepository parsers
) : ValueParser<IGqlpArg>(
    parsers.Get<IGqlpFieldKey>(),
    parsers.Get<KeyValue<IGqlpArg>>(),
    parsers.GetArray<IGqlpArg>(),
    parsers.Get<IGqlpFields<IGqlpArg>>())
{
  private readonly Parser<IGqlpConstant>.L _constant = parsers.Get<IGqlpConstant>();

  public override IResult<IGqlpArg> Parse([NotNull] ITokenizer tokens, string label)
  {
    _ = tokens.At;
    if (!tokens.Prefix('$', out string? variable, out TokenAt at)) {
      return tokens.Error<IGqlpArg>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(variable)) {
      ArgAst argument = new(at, variable!);

      if (tokens is IOperationContext context) {
        context.AddVariable(argument);
      }

      return argument.Ok<IGqlpArg>();
    }

    IResult<IGqlpArg> baseValue = base.Parse(tokens, label);
    return baseValue.IsEmpty()
      ? _constant.Parse(tokens, "Constant").MapOk(
        constant => new ArgAst(constant).Ok<IGqlpArg>(),
        () => default(IGqlpArg).Empty())
      : baseValue;
  }

  protected override Func<IGqlpFields<IGqlpArg>, IGqlpArg> NewFields(ITokenAt at)
    => fields => new ArgAst(at, fields);
  protected override Func<IEnumerable<IGqlpArg>, IGqlpArg> NewList(ITokenAt at)
    => list => new ArgAst(at, list);
}
