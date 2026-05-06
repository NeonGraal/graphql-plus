using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseArgValue(
  IParserRepository parsers
) : ValueParser<IAstArg>(parsers)
{
  private readonly Parser<IAstConstant>.L _constant = parsers.ParserFor<IAstConstant>();

  public override IResult<IAstArg> Parse([NotNull] ITokenizer tokens, string label)
  {
    _ = tokens.At;
    if (!tokens.Prefix('$', out string? variable, out TokenAt at)) {
      return tokens.Error<IAstArg>(label, "identifier after '$'");
    }

    if (!string.IsNullOrWhiteSpace(variable)) {
      ArgAst argument = new(at, variable!);

      if (tokens is IOperationContext context) {
        context.AddVariable(argument);
      }

      return argument.Ok<IAstArg>();
    }

    IResult<IAstArg> baseValue = base.Parse(tokens, label);
    return baseValue.IsEmpty()
      ? _constant.Parse(tokens, "Constant").MapOk(
        constant => new ArgAst(constant).Ok<IAstArg>(),
        () => default(IAstArg).Empty())
      : baseValue;
  }

  protected override Func<IAstFields<IAstArg>, IAstArg> NewFields(ITokenAt at)
    => fields => new ArgAst(at, fields);
  protected override Func<IEnumerable<IAstArg>, IAstArg> NewList(ITokenAt at)
    => list => new ArgAst(at, list);

  internal static IValueParserFactories<IAstArg> Factories { get; } = new ParseArgValueFactories();

  private class ParseArgValueFactories
    : IValueParserFactories<IAstArg>
  {
    public ValueParser<IAstArg> Value(IParserRepository repo)
      => new ParseArgValue(repo);
    public ValueKeyValueParser<IAstArg> ValueKey(IParserRepository repo)
      => new(repo);
    public ValueListParser<IAstArg> ValueList(IParserRepository repo)
      => new(repo);
    public ValueObjectParser<IAstArg> ValueObject(IParserRepository repo)
      => new(repo);
  }
}
