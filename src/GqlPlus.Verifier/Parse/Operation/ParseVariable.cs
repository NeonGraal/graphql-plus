using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Parse.Common;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseVariable : IParser<VariableAst>
{
  private readonly IParserArray<ModifierAst> _modifiers;
  private readonly IParserDefault _default;
  private readonly IParserArray<DirectiveAst> _directives;

  public ParseVariable(
    IParserArray<ModifierAst> modifiers,
    IParserDefault defaultParser,
    IParserArray<DirectiveAst> directives)
  {
    _modifiers = modifiers.ThrowIfNull();
    _default = defaultParser.ThrowIfNull();
    _directives = directives.ThrowIfNull();
  }

  public IResult<VariableAst> Parse(Tokenizer tokens)
  {
    var prefix = tokens.Prefix('$', out var name, out var at);
    var variable = new VariableAst(at, name ?? "");
    if (!prefix) {
      return tokens.Partial("Variable", "identifier after '$'", variable);
    }

    if (name is null) {
      return variable.Empty();
    }

    if (tokens.Take(':')) {
      if (!ParseVarType(tokens).Required(varType => variable.Type = varType)) {
        return tokens.Partial("Variable", "type after ':'", variable);
      }
    }

    var modifiers = _modifiers.Parse(tokens);
    if (!modifiers.Optional(value => variable.Modifers = value)) {
      return modifiers.AsResult(variable);
    }

    var constant = _default.Parse(tokens);
    if (!constant.Optional(value => variable.Default = value)) {
      return constant.AsResult(variable);
    }

    var directives = _directives.Parse(tokens); ;
    return directives.Optional(value => variable.Directives = value)
      ? variable.Ok()
      : directives.AsResult(variable);
  }

  internal IResult<string> ParseVarType(Tokenizer tokens)
    => ParseVarNull(tokens).Select(nullType
      => tokens.Take('!') ? nullType + '!' : nullType);

  internal IResult<string> ParseVarNull(Tokenizer tokens)
  {
    if (tokens.Take('[')) {
      return ParseVarType(tokens).MapOk(
        varType => tokens.Take(']')
          ? $"[{varType}]".Ok()
          : tokens.Partial("Variable Type", "an inner variable type", varType),
        () => tokens.Error("Variable Type", "an inner variable type", ""));
    } else if (tokens.Identifier(out var varNull)) {
      return varNull.Ok();
    }

    return "".Empty();
  }
}
