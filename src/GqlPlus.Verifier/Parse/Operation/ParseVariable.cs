using GqlPlus.Ast;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Operation;

internal class ParseVariable(
  Parser<ModifierAst>.DA modifiers,
  Parser<DirectiveAst>.DA directives,
  Parser<IParserDefault, ConstantAst>.D defaultParser,
  Parser<IParserVarType, string>.D varTypeParser
) : Parser<VariableAst>.I
{
  private readonly Parser<ModifierAst>.LA _modifiers = modifiers;
  private readonly Parser<DirectiveAst>.LA _directives = directives;
  private readonly Parser<IParserDefault, ConstantAst>.L _default = defaultParser;
  private readonly Parser<IParserVarType, string>.L _varTypeParser = varTypeParser;

  public IResult<VariableAst> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    bool prefix = tokens.Prefix('$', out string? name, out TokenAt? at);
    VariableAst variable = new(at, name ?? "");
    if (!prefix) {
      return tokens.Partial(label, "identifier after '$'", () => variable);
    }

    if (name is null) {
      return variable.Empty();
    }

    if (tokens.Take(':')) {
      if (!_varTypeParser.I.Parse(tokens, "Variable Type").Required(varType => variable.Type = varType)) {
        return tokens.Partial(label, "type after ':'", () => variable);
      }
    }

    IResultArray<ModifierAst> modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => variable.Modifers = value)) {
      return modifiers.AsResult(variable);
    }

    IResult<ConstantAst> constant = _default.I.Parse(tokens, label);
    if (!constant.Optional(value => variable.Default = value)) {
      return constant.AsResult(variable);
    }

    IResultArray<DirectiveAst> directives = _directives.Parse(tokens, label);
    return directives.Optional(value => variable.Directives = value)
      ? variable.Ok()
      : directives.AsResult(variable);
  }
}
