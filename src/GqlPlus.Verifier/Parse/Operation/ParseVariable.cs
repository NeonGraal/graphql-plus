using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseVariable : Parser<VariableAst>.I
{
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly Parser<DirectiveAst>.LA _directives;
  private readonly Parser<IParserDefault, ConstantAst>.L _default;
  private readonly Parser<IParserVarType, string>.L _varTypeParser;

  public ParseVariable(
    Parser<ModifierAst>.DA modifiers,
    Parser<DirectiveAst>.DA directives,
    Parser<IParserDefault, ConstantAst>.D defaultParser,
    Parser<IParserVarType, string>.D varTypeParser)
  {
    _modifiers = modifiers;
    _default = defaultParser;
    _directives = directives;
    _varTypeParser = varTypeParser;
  }

  public IResult<VariableAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var prefix = tokens.Prefix('$', out var name, out var at);
    var variable = new VariableAst(at, name ?? "");
    if (!prefix) {
      return tokens.Partial(label, "identifier after '$'", () => variable);
    }

    if (name is null) {
      return variable.Empty();
    }

    if (tokens.Take(':')) {
      if (!_varTypeParser.Parse(tokens, "Variable Type").Required(varType => variable.Type = varType)) {
        return tokens.Partial(label, "type after ':'", () => variable);
      }
    }

    var modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => variable.Modifers = value)) {
      return modifiers.AsResult(variable);
    }

    var constant = _default.Parse(tokens, label);
    if (!constant.Optional(value => variable.Default = value)) {
      return constant.AsResult(variable);
    }

    var directives = _directives.Parse(tokens, label);
    return directives.Optional(value => variable.Directives = value)
      ? variable.Ok()
      : directives.AsResult(variable);
  }
}
