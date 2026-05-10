using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseOperation(
  IParserRepository parsers
) : IParser<IAstOperation>
{
  private readonly ParserOne<IParserArg, IAstArg> _argument = parsers.ParserFor<IParserArg, IAstArg>();
  private readonly ParserArray<IAstDirective> _directives = parsers.ArrayFor<IAstDirective>();
  private readonly ParserArray<IParserStartFragments, IAstFragment> _startFragments = parsers.ArrayFor<IParserStartFragments, IAstFragment>();
  private readonly ParserArray<IParserEndFragments, IAstFragment> _endFragments = parsers.ArrayFor<IParserEndFragments, IAstFragment>();
  private readonly ParserArray<IAstModifier> _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly ParserArray<IAstSelection> _object = parsers.ArrayFor<IAstSelection>();
  private readonly ParserArray<IAstVariable> _variables = parsers.ArrayFor<IAstVariable>();

  public IResult<IAstOperation> Parse([NotNull] ITokenizer tokens, string label)
  {
    if (tokens is not IOperationContext) {
      tokens = new OperationContext(tokens);
    }

    if (tokens.AtStart) {
      if (!tokens.Read()) {
        return tokens.Error<IAstOperation>(label, "text");
      }
    }

    OperationAst ast = ParseCategory(tokens);

    IResult<IAstOperation>? value = ErrorParsingStart(tokens, label, ast);
    if (value is not null) {
      return value;
    }

    value = ErrorParsingResult(tokens, label, ast);
    if (value is not null) {
      return value;
    }

    _endFragments.I.Parse(tokens, label).WithResult(value =>
      ast.Fragments = [.. ast.Fragments.Concat(value)]);

    if (tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      return tokens.Partial(label, "no more text", () => Final(tokens, ast));
    }

    return Final(tokens, ast).Ok();
  }

  private IResult<IAstOperation>? ErrorParsingResult(ITokenizer tokens, string label, OperationAst ast)
  {
    if (!tokens.Prefix(':', out string? result, out _)) {
      return tokens.Partial(label, "identifier to follow ':'", () => Final(tokens, ast));
    }

    if (!string.IsNullOrWhiteSpace(result)) {
      ast.ResultType = result;
      IResult<IAstArg> argument = _argument.I.Parse(tokens, "Arg");
      if (!argument.Optional(arg => ast.Arg = arg)) {
        return argument.AsPartial(Final(tokens, ast));
      }
    } else if (!_object.Parse(tokens, label).Required(selections => ast.ResultObject = [.. selections])) {
      return tokens.Partial(label, "Object or Type", () => Final(tokens, ast));
    }

    IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, label);

    if (modifiers.IsError()) {
      return modifiers.AsPartial(Final(tokens, ast));
    }

    modifiers.WithResult(mods => ast.Modifiers = [.. mods]);

    return null;
  }

  private IResult<IAstOperation>? ErrorParsingStart(ITokenizer tokens, string label, OperationAst ast)
  {
    IResultArray<IAstVariable> variables = _variables.Parse(tokens, label);
    if (!variables.Optional(vars => ast.Variables = [.. vars])) {
      return variables.AsPartial(Final(tokens, ast));
    }

    _directives.Parse(tokens, label).Required(directives => ast.Directives = [.. directives]);

    _startFragments.I.Parse(tokens, label).WithResult(frags => ast.Fragments = [.. frags]);
    return null;
  }

  private static IAstOperation Final(ITokenizer tokens, OperationAst ast)
    => tokens is IOperationContext context
      ? ast with {
        Errors = tokens.Errors,
        Usages = [.. context.Variables],
        Spreads = [.. context.Spreads],
      }
      : ast with { Errors = tokens.Errors, };

  private static OperationAst ParseCategory(ITokenizer tokens)

  {
    TokenAt at = tokens.At;
    return tokens.Identifier(out string? category)
      ? tokens.Identifier(out string? name)
        ? new(at, name) { Category = category }
        : new(at) { Category = category }
      : new(at);
  }

  internal static ParseOperation Factory(IParserRepository p) => new(p);
}
