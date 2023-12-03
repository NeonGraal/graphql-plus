using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

internal class ParseObject : IParserObject
{
  private readonly Parser<ModifierAst>.LA _modifiers;
  private readonly IParserArray<DirectiveAst> _directives;
  private readonly Parser<IParserArgument, ArgumentAst>.L _argument;

  public ParseObject(
    Parser<ModifierAst>.DA modifiers,
    IParserArray<DirectiveAst> directives,
    Parser<IParserArgument, ArgumentAst>.D argument)
  {
    _modifiers = modifiers;
    _directives = directives.ThrowIfNull();
    _argument = argument;
  }

  public IResultArray<IAstSelection> Parse<TContext>(TContext tokens, string label)
    where TContext : Tokenizer
  {
    var fields = new List<IAstSelection>();
    if (!tokens.Take('{')) {
      return fields.EmptyArray();
    }

    while (!tokens.Take('}')) {
      var selection = ParseSelection(tokens);
      if (selection.IsError()) {
        return selection.AsResultArray(fields);
      } else if (selection.Required(fields.Add)) {
        continue;
      }

      var field = ParseField(tokens);
      if (field.IsError()) {
        return field.AsResultArray(fields);
      }

      field.WithResult(fields.Add);
    }

    return fields.Any()
      ? fields.OkArray()
      : tokens.PartialArray("Object", "at least one field or selection", () => fields);
  }

  public IResult<FieldAst> ParseField(Tokenizer tokens)
  {
    var at = tokens.At;
    if (!tokens.Identifier(out var alias)) {
      return tokens.Error<FieldAst>("Field", "initial identifier");
    }

    var result = new FieldAst(at, alias);

    if (tokens.Take(':')) {
      at = tokens.At;
      if (!tokens.Identifier(out var name)) {
        return tokens.Error<FieldAst>("Field", "a name after an alias");
      }

      result = new FieldAst(at, name) { Alias = alias };
    }

    _argument.Parse(tokens, "Argument").Required(argument => result.Argument = argument);

    var modifiers = _modifiers.Parse(tokens, "Field");
    if (!modifiers.Optional(value => result.Modifiers = value)) {
      return modifiers.AsResult<FieldAst>();
    }

    _directives.Parse(tokens, alias).WithResult(directives => result.Directives = directives);

    var selections = Parse(tokens, "Field");
    return !selections.Optional(value => result.Selections = value)
      ? selections.AsResult<FieldAst>()
      : result.Ok();
  }

  public IResult<IAstSelection> ParseSelection(Tokenizer tokens)
  {
    if (tokens.Take("...") || tokens.Take('|')) {
      var at = tokens.At;
      string? onType = null;
      if (tokens.Take("on") || tokens.Take(':')) {
        if (!tokens.Identifier(out onType)) {
          return tokens.Error<IAstSelection>("Spread", "a type");
        }
      } else {
        if (tokens.Identifier(out var name)) {
          var selection = new SpreadAst(at, name);
          _directives.Parse(tokens, "Spread").Optional(directives => selection.Directives = directives);

          if (tokens is OperationContext context) {
            context.Spreads.Add(selection);
          }

          return selection.Ok<IAstSelection>();
        }
      }

      {
        var directives = _directives.Parse(tokens, "Inline");
        var selections = Parse(tokens, "Object");
        if (selections.IsOk()) {
          return selections.Select(values => {
            var selection = new InlineAst(at, values) {
              OnType = onType,
            };
            directives.Optional(directives => selection.Directives = directives);
            return selection as IAstSelection;
          });
        }
      }

      return tokens.Error<IAstSelection>("Inline", "an object");
    }

    return AstNulls.Selection.Empty();
  }

  IResult<IAstSelection> IParser<IAstSelection>.Parse<TContext>(TContext tokens)
    => ParseSelection(tokens);

  IResult<FieldAst> IParser<FieldAst>.Parse<TContext>(TContext tokens)
    => ParseField(tokens);
}

internal interface IParserObject
  : IParserArray<IAstSelection>, IParser<FieldAst>, IParser<IAstSelection>
{
  IResult<FieldAst> ParseField(Tokenizer tokens);
  IResult<IAstSelection> ParseSelection(Tokenizer tokens);
}
