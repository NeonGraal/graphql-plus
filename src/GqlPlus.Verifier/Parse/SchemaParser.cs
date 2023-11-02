using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse;

internal class SchemaParser : CommonParser
{
  public SchemaParser(Tokenizer tokens)
    : base(tokens) { }

  private delegate bool Parser<T>(SchemaParser parser, string description, out T declaration);

  private readonly Dictionary<string, Parser<AstDescribed>> _parsers = new() {
    ["category"] = ParserFor((SchemaParser parser, string description, out CategoryAst result)
      => parser.ParseCategory(out result, description)),
    ["directive"] = ParserFor((SchemaParser parser, string description, out DirectiveAst result)
      => parser.ParseDirective(out result, description)),
    ["enum"] = ParserFor((SchemaParser parser, string description, out EnumAst result)
      => parser.ParseEnum(out result, description)),
    ["output"] = ParserFor((SchemaParser parser, string description, out OutputAst result)
      => parser.ParseOutput(out result, description)),
    ["input"] = ParserFor((SchemaParser parser, string description, out InputAst result)
      => parser.ParseInput(out result, description)),
    ["scalar"] = ParserFor((SchemaParser parser, string description, out ScalarAst result)
      => parser.ParseScalar(out result, description)),
  };

  private static Parser<AstDescribed> ParserFor<T>(Parser<T> parser)
      where T : AstDescribed
    => (SchemaParser parent, string description, out AstDescribed declaration) => {
      var result = parser(parent, description, out T declared);
      declaration = declared;
      return result;
    };

  internal SchemaAst Parse()
  {
    if (_tokens.AtStart) {
      if (!_tokens.Read()) {
        return new(_tokens.At) { Errors = new[] { _tokens.Error("Unexpected") } };
      }
    }

    var at = _tokens.At;
    SchemaAst ast = new(at);

    var declarations = new List<AstDescribed>();

    while (_tokens.Identifier(out var selector)) {
      if (_parsers.TryGetValue(selector, out var parser)) {
        if (parser(this, "", out var declaration)) {
          declarations.Add(declaration);
        }
      }
    }

    if (_tokens.AtEnd) {
      ast.Result = ParseResultKind.Success;
    } else {
      Error("Schema", "no more text");
    }

    return ast with {
      Declarations = declarations.ToArray(),
      Errors = Errors.ToArray(),
    };
  }

  internal bool ParseCategory(out CategoryAst result, string description)
  {
    var at = _tokens.At;
    result = new(at, "") { Description = description };

    at = _tokens.At;
    _tokens.Identifier(out var name);

    if (!ParsePrefix("Category", out var aliases)
      || !ParseOption("Category", out CategoryOption option)
      ) {
      return false;
    }

    if (_tokens.Identifier(out var output)) {
      if (string.IsNullOrEmpty(name)) {
        name = output.Camelize();
      }

      result = new(at, name!, output) {
        Aliases = aliases,
        Option = option
      };
      return true;
    }

    return Error("Category", "output type");
  }

  private bool ParseOption<O>(string label, out O result)
    where O : struct
  {
    result = default;
    return !_tokens.Take('(')
      || (ParseEnumValue(out result)
        ? Error(label, "')' after option", _tokens.Take(')'))
        : Error(label, "valid option"));
  }

  private bool ParseEnumValue<E>(out E result)
    where E : struct
  {
    result = default;
    return _tokens.Identifier(out var option)
      && Enum.TryParse(option, true, out result);
  }

  internal bool ParseDirective(out DirectiveAst result, string description)
  {
    if (!_tokens.Prefix('@', out var name, out var at)) {
      result = new(AstNulls.At, name ?? "", description);
      return Error("Directive", "'@' name");
    }

    result = new(at, name!, description);

    if (ParseParameter(out var parameter)) {
      result.Parameter = parameter;
    }

    if (!ParsePrefix("Directive", out var aliases)
      || !ParseOption("Directive", out DirectiveOption option)
    ) {
      return false;
    }

    result.Aliases = aliases;
    result.Option = option;

    if (!ParseEnumValue(out DirectiveLocation location)) {
      return Error("Directive", "at least one location");
    }

    result.Locations = location;

    while (_tokens.Take("|")) {
      if (ParseEnumValue(out location)) {
        result.Locations |= location;
      } else {
        return Error("Directive", "location after '|'");
      }
    }

    return true;
  }

  internal bool ParseEnum(out EnumAst result, string description)
  {
    var at = _tokens.At;
    var hasName = _tokens.Identifier(out var name);
    result = new(at, name, description);

    if (!hasName) {
      return Error("Enum", "name");
    }

    if (!ParsePrefix("Enum", out var aliases)) {
      return false;
    }

    result.Aliases = aliases;

    if (_tokens.Take(':')) {
      if (_tokens.Identifier(out var extends)) {
        result.Extends = extends;
      } else {
        return Error("Enum", "type after ':'");
      }
    }

    if (ParseEnumLabel(out var label)) {
      List<EnumLabelAst> labels = new() { label };

      while (_tokens.Take("|")) {
        if (ParseEnumLabel(out label)) {
          labels.Add(label);
        } else {
          return Error("Enum", "label");
        }
      }

      result.Labels = labels.ToArray();
      return true;
    }

    return Error("Enum", "label");
  }

  private bool ParseEnumLabel(out EnumLabelAst enumLabel)
  {
    _tokens.String(out var description);
    var at = _tokens.At;
    var hasLabel = _tokens.Identifier(out var label);
    ParseAliases("Enum", out var aliases);

    enumLabel = new(at, label, description) { Aliases = aliases };

    return Error("Enum", "label", hasLabel);
  }

  private bool ParseObject<O, F, R>(out O result, string description, IObjectParser<O, F, R> factories)
    where O : AstObject<F, R> where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    var getName = _tokens.Identifier(out var name);

    result = factories.Object(at, name, description);
    if (!getName) {
      return Error(factories.Label, "name");
    }

    if (!ParseTypeParameters(factories.Label, out var parameters)) {
      return false;
    }

    result.Parameters = parameters;

    if (!ParsePrefix(factories.Label, out var aliases)) {
      return false;
    }

    result.Aliases = aliases;

    _tokens.String(out var descr);
    if (!ParseReference(out var reference, factories, descr)) {
      return false;
    }

    if (_tokens.Take('{')) {
      var fields = new List<F>();
      while (!_tokens.Take('}')) {
        if (ParseField(out var field, factories)) {
          fields.Add(field);
        } else {
          return Error(factories.Label, "more fields or '}'");
        }
      }

      if (reference is not null) {
        result.Extends = reference with { Description = descr };
      }

      result.Fields = fields.ToArray();
      if (!ParseAlternates(out var alternates, factories)) {
        return false;
      }

      result.Alternates = alternates;
    } else if (reference is not null) {
      if (!ParseAlternates(out var alternates, factories, reference)) {
        return false;
      }

      result.Alternates = alternates;
    }

    return true;
  }

  private bool ParseAlternates<R>(out R[] alternates, IReferenceParser<R> factories, params R[] initial)
    where R : AstReference<R>
  {
    var result = new List<R>(initial);
    while (_tokens.Take('|')) {
      _tokens.String(out var descr);
      if (ParseReference(out var alternate, factories, descr) && alternate is not null) {
        result.Add(alternate);
      } else {
        alternates = result.ToArray();
        return Error(factories.Label, "reference after '|'");
      }
    }

    alternates = result.ToArray();
    return true;
  }

  internal bool ParseField<F, R>(out F field, IFieldParser<F, R> parser)
    where F : AstField<R> where R : AstReference<R>
  {
    var at = _tokens.At;
    _tokens.String(out var description);
    if (!_tokens.Identifier(out var name)) {
      field = parser.NullField();
      return Error(parser.Label, "field name");
    }

    var hasParameter = parser.FieldParameter(out var parameter);
    if (!hasParameter || !ParseAliases(parser.Label, out var aliases)) {
      field = parser.NullField();
      return false;
    }

    field = parser.Field(at, name, description, parser.Reference(at, ""));

    if (_tokens.Take(':')) {
      _tokens.String(out var descr);
      if (ParseReference(out var fieldType, parser, descr) && fieldType is not null) {
        field = parser.Field(at, name, description, fieldType);
        field.Aliases = aliases;
        if (hasParameter) {
          parser.ApplyParameter(field, parameter);
        }

        var modifiers = ParseModifiers("Operation");

        if (modifiers.IsError()) {
          return false;
        }

        field.Modifiers = modifiers.Value ?? Array.Empty<ModifierAst>();
        return parser.FieldDefault(field);
      }

      return Error(parser.Label, "field type");
    }

    return Error(parser.Label, "field details", parser.FieldEnumLabel(field));
  }

  internal bool ParseReference<R>(out R?
    reference, IReferenceParser<R> factories, string description, bool isTypeArgument = false)
    where R : AstReference<R>
  {
    if (!_tokens.Prefix('$', out var param, out var at)) {
      reference = null;
      return false;
    }

    if (param is not null) {
      reference = factories.Reference(at, param) with { Description = description };
      reference.IsTypeParameter = true;
      return true;
    }

    at = _tokens.At;

    if (_tokens.Identifier(out var name)) {
      reference = factories.Reference(at, name) with { Description = description };
      if (_tokens.Take('<')) {
        var arguments = new List<R>();
        _tokens.String(out var descr);
        while (ParseReference(out var argument, factories, descr, isTypeArgument: true) && argument is not null) {
          arguments.Add(argument);
          _tokens.String(out descr);
        }

        reference.Arguments = arguments.ToArray();

        if (!_tokens.Take('>')) {
          return Error(factories.Label, "'>' after type argument(s)");
        } else if (arguments.Count < 1) {
          return Error(factories.Label, "at least one type argument after '<'");
        }
      } else if (isTypeArgument) {
        return factories.TypeEnumLabel(reference);
      }

      return true;
    }

    reference = default;
    return true;
  }

  internal bool ParseOutput(out OutputAst output, string description)
   => ParseObject(out output, description, new OutputParserFactories(this));

  internal bool ParseOutputEnumLabel(OutputReferenceAst reference)
  {
    if (_tokens.Take('.')) {
      if (_tokens.Identifier(out var label)) {
        reference.Label = label;
        return true;
      }

      return Error("Output", "label after '.'");
    }

    return true;
  }

  internal bool ParseOutputFieldLabel(OutputFieldAst field)
  {
    if (_tokens.Take('=')) {
      var at = _tokens.At;

      if (!_tokens.Identifier(out var label)) {
        return Error("Output", "label after '='");
      }

      if (!_tokens.Take('.')) {
        field.Label = label;
        return true;
      }

      if (_tokens.Identifier(out var value)) {
        field.Type = new OutputReferenceAst(at, label);
        field.Label = value;
        return true;
      }

      return Error("Output", "label after '.'");
    }

    return Error("Output", "':' or '='");
  }

  internal bool ParseParameter(out ParameterAst? parameter)
  {
    parameter = default;
    if (!_tokens.Take('(')) {
      return true;
    }

    _tokens.String(out var descr);
    var at = _tokens.At;
    if (!ParseReference(out var reference, new InputParserFactories(this), descr)
      || reference is null) {
      return Error("Parameter", "input reference after '('");
    }

    parameter = new(at, reference);
    var modifiers = ParseModifiers("Operation");

    if (modifiers.IsError(Errors.Add)) {
      return false;
    }

    parameter.Modifiers = modifiers.Value ?? Array.Empty<ModifierAst>();

    if (ParseDefault(out var constant)) {
      parameter.Default = constant;
    }

    return Error("Parameter", "')' at end", _tokens.Take(')'));
  }

  internal bool ParseInput(out InputAst output, string description)
   => ParseObject(out output, description, new InputParserFactories(this));

  private bool ParseAliases(string label, out string[] result)
  {
    var aliases = new List<string>();
    if (_tokens.Take('[')) {
      while (_tokens.Identifier(out var alias)) {
        aliases.Add(alias);
      }

      if (!_tokens.Take("]")) {
        result = aliases.ToArray();
        return Error(label, "']' to end aliases");
      } else if (aliases.Count == 0) {
        result = aliases.ToArray();
        return Error(label, "at least one alias after '['");
      }
    }

    result = aliases.ToArray();

    return true;
  }

  private bool ParsePrefix(string label, out string[] result)
    => ParseAliases(label, out result)
      && Error(label, "'=' before definition", _tokens.Take('='));

  private bool ParseTypeParameters(string label, out TypeParameterAst[] parameters)
  {
    var result = new List<TypeParameterAst>();

    if (_tokens.Take('<')) {
      parameters = Array.Empty<TypeParameterAst>();

      while (!_tokens.Take('>')) {
        _tokens.String(out var description);
        if (_tokens.Prefix('$', out var name, out var at) && name is not null) {
          result.Add(new(at, name, description));
        } else {
          return Error(label, "type parameter");
        }
      }

      if (result.Count == 0) {
        return Error(label, "at least one type parameter after '<'");
      }
    }

    parameters = result.ToArray();
    return true;
  }

  internal bool ParseScalar(out ScalarAst result, string description)
  {
    var at = _tokens.At;
    var hasName = _tokens.Identifier(out var name);
    result = new(at, name, description);

    if (!hasName) {
      return Error("Scalar", "name");
    }

    if (!ParsePrefix("Scalar", out var aliases)) {
      return false;
    }

    result.Aliases = aliases;

    if (!ParseEnumValue(out ScalarKind kind)) {
      return false;
    }

    result.Kind = kind;

    switch (kind) {
      case ScalarKind.Number:
        result.Ranges = ParseRanges();
        break;
      case ScalarKind.String:
        result.Regexes = ParseRegexes();
        break;
      default:
        return Error("Scalar", "valid kind");
    }

    return true;
  }

  private ScalarRangeAst[] ParseRanges()
  {
    var result = new List<ScalarRangeAst>();
    while (ParseRange(out var range)) {
      result.Add(range);
    }

    return result.ToArray();
  }

  private bool ParseRange(out ScalarRangeAst range)
  {
    var at = _tokens.At;
    range = new(at);
    var hasLower = _tokens.Number(out var min);
    var excludesLower = _tokens.Take('>');
    if (!_tokens.Take("..") && hasLower) {
      return Error("Scalar", "range operator ('..')");
    }

    var excludesUpper = _tokens.Take('<');
    var hasUpper = _tokens.Number(out var max);

    if (hasLower) {
      range.Lower = min;
      range.LowerExcluded = excludesLower;
    }

    if (hasUpper) {
      range.Upper = max;
      range.UpperExcluded = excludesUpper;
    }

    return hasLower || hasUpper;
  }

  private ScalarRegexAst[] ParseRegexes()
  {
    var result = new List<ScalarRegexAst>();
    var at = _tokens.At;

    while (_tokens.Regex(out var regex)) {
      var excluded = _tokens.Take('!');
      result.Add(new(at, regex, excluded));
      at = _tokens.At;
    }

    return result.ToArray();
  }
}
