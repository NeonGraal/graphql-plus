using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseOperation(
  IParserRepository parsers
) : Parser<IAstOperation>.I
{
  private readonly Parser<IParserArg, IGqlpArg>.L _argument = parsers.ParserFor<IParserArg, IGqlpArg>();
  private readonly Parser<IAstDirective>.LA _directives = parsers.ArrayFor<IAstDirective>();
  private readonly ParserArray<IParserStartFragments, IAstFragment>.LA _startFragments = parsers.ArrayFor<IParserStartFragments, IAstFragment>();
  private readonly ParserArray<IParserEndFragments, IAstFragment>.LA _endFragments = parsers.ArrayFor<IParserEndFragments, IAstFragment>();
  private readonly Parser<IAstModifier>.LA _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly Parser<IGqlpSelection>.LA _object = parsers.ArrayFor<IGqlpSelection>();
  private readonly Parser<IAstVariable>.LA _variables = parsers.ArrayFor<IAstVariable>();

  public IResult<IAstOperation> Parse(ITokenizer tokens, string label)
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
      IResult<IGqlpArg> argument = _argument.I.Parse(tokens, "Arg");
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
}
