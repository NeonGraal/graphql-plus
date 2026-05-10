using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseVariable(
  IParserRepository parsers
) : IParser<IAstVariable>
{
  private readonly ParserArray<IAstModifier> _modifiers = parsers.ArrayFor<IAstModifier>();
  private readonly ParserArray<IAstDirective> _directives = parsers.ArrayFor<IAstDirective>();
  private readonly ParserOne<IParserDefault, IAstConstant> _default = parsers.ParserFor<IParserDefault, IAstConstant>();
  private readonly ParserOne<IParserVarType, string> _varTypeParser = parsers.ParserFor<IParserVarType, string>();

  public IResult<IAstVariable> Parse([NotNull] ITokenizer tokens, string label)

  {
    bool prefix = tokens.Prefix('$', out string? name, out TokenAt at);
    VariableAst variable = new(at, name.IfWhiteSpace());
    if (!prefix) {
      return tokens.Partial<IAstVariable>(label, "identifier after '$'", () => variable);
    }

    if (name is null) {
      return variable.Empty<IAstVariable>();
    }

    if (tokens.Take(':')) {
      if (!_varTypeParser.I.Parse(tokens, "Variable Type").Required(varType => variable.Type = varType)) {
        return tokens.Partial<IAstVariable>(label, "type after ':'", () => variable);
      }
    }

    IResultArray<IAstModifier> modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => variable.Modifiers = [.. value])) {
      return modifiers.AsResult<IAstVariable>(variable);
    }

    IResult<IAstConstant> constant = _default.I.Parse(tokens, label);
    if (!constant.Optional(value => variable.DefaultValue = value)) {
      return constant.AsResult<IAstVariable>(variable);
    }

    IResultArray<IAstDirective> directives = _directives.Parse(tokens, label);
    return directives.Optional(value => variable.Directives = [.. value])
      ? variable.Ok<IAstVariable>()
      : directives.AsResult<IAstVariable>(variable);
  }

  internal static ParseVariable Factory(IParserRepository p) => new(p);
}
