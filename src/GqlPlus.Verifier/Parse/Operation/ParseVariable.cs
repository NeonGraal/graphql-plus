using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseVariable : IParser<VariableAst>
{
  private readonly IParserArray<ModifierAst> _modifiers;
  private readonly IParserArray<DirectiveAst> _directives;
  private readonly IParserDefault _default;
  private readonly IParserVarType _varTypeParser;

  public ParseVariable(
    IParserArray<ModifierAst> modifiers,
    IParserArray<DirectiveAst> directives,
    IParserDefault defaultParser,
    IParserVarType varTypeParser)
  {
    _modifiers = modifiers.ThrowIfNull();
    _default = defaultParser.ThrowIfNull();
    _directives = directives.ThrowIfNull();
    _varTypeParser = varTypeParser.ThrowIfNull();
  }

  public IResult<VariableAst> Parse<TContext>(TContext tokens)
    where TContext : Tokenizer
  {
    var prefix = tokens.Prefix('$', out var name, out var at);
    var variable = new VariableAst(at, name ?? "");
    if (!prefix) {
      return tokens.Partial("Variable", "identifier after '$'", () => variable);
    }

    if (name is null) {
      return variable.Empty();
    }

    if (tokens.Take(':')) {
      if (!_varTypeParser.Parse(tokens).Required(varType => variable.Type = varType)) {
        return tokens.Partial("Variable", "type after ':'", () => variable);
      }
    }

    var modifiers = _modifiers.Parse(tokens, "Variable");
    if (!modifiers.Optional(value => variable.Modifers = value)) {
      return modifiers.AsResult(variable);
    }

    var constant = _default.Parse(tokens);
    if (!constant.Optional(value => variable.Default = value)) {
      return constant.AsResult(variable);
    }

    var directives = _directives.Parse(tokens, "Variable");
    return directives.Optional(value => variable.Directives = value)
      ? variable.Ok()
      : directives.AsResult(variable);
  }
}
