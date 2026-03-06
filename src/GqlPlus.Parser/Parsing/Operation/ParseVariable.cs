using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Operation;

internal class ParseVariable(
  IParserRepository parsers
) : Parser<IGqlpVariable>.I
{
  private readonly Parser<IGqlpModifier>.LA _modifiers = parsers.GetArray<IGqlpModifier>();
  private readonly Parser<IGqlpDirective>.LA _directives = parsers.GetArray<IGqlpDirective>();
  private readonly Parser<IParserDefault, IGqlpConstant>.L _default = parsers.GetInterface<IParserDefault, IGqlpConstant>();
  private readonly Parser<IParserVarType, string>.L _varTypeParser = parsers.GetInterface<IParserVarType, string>();

  public IResult<IGqlpVariable> Parse(ITokenizer tokens, string label)

  {
    bool prefix = tokens.Prefix('$', out string? name, out TokenAt at);
    VariableAst variable = new(at, name.IfWhiteSpace());
    if (!prefix) {
      return tokens.Partial<IGqlpVariable>(label, "identifier after '$'", () => variable);
    }

    if (name is null) {
      return variable.Empty<IGqlpVariable>();
    }

    if (tokens.Take(':')) {
      if (!_varTypeParser.I.Parse(tokens, "Variable Type").Required(varType => variable.Type = varType)) {
        return tokens.Partial<IGqlpVariable>(label, "type after ':'", () => variable);
      }
    }

    IResultArray<IGqlpModifier> modifiers = _modifiers.Parse(tokens, label);
    if (!modifiers.Optional(value => variable.Modifiers = [.. value])) {
      return modifiers.AsResult<IGqlpVariable>(variable);
    }

    IResult<IGqlpConstant> constant = _default.I.Parse(tokens, label);
    if (!constant.Optional(value => variable.DefaultValue = value)) {
      return constant.AsResult<IGqlpVariable>(variable);
    }

    IResultArray<IGqlpDirective> directives = _directives.Parse(tokens, label);
    return directives.Optional(value => variable.Directives = [.. value])
      ? variable.Ok<IGqlpVariable>()
      : directives.AsResult<IGqlpVariable>(variable);
  }
}
