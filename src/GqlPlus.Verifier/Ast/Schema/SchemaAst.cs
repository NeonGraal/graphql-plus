namespace GqlPlus.Verifier.Ast.Schema;

internal record class SchemaAst(ParseAt At, string Name)
  : AstDirectives(At, Name)
{
  public ParseResult Result { get; set; }
  public ParseError[] Errors { get; set; } = Array.Empty<ParseError>();

  public AstDescribed[] Declarations { get; set; } = Array.Empty<AstDescribed>();

  internal override string Abbr => "G";

  public SchemaAst(ParseAt at)
    : this(at, "") { }

  public string Render()
  {
    using var sw = new StringWriter();
    var indent = 0;
    var begins = new[] { "(", "{", "[", "<" };
    var ends = new[] { ")", "}", "]", ">" };
    foreach (var field in GetFields()) {
      if (field is null) {
        continue;
      }

      if (begins.Contains(field)) {
        Write(field);
        indent++;
      } else if (ends.Contains(field)) {
        indent--;
        Write(field);
      } else {
        Write(field);
      }
    }

    return sw.ToString();

    void Write(string text)
    {
      for (var i = 0; i < indent; i++) {
        sw.Write("  ");
      }

      sw.WriteLine(text);
    }
  }

  internal override IEnumerable<string?> GetFields()
    => // base.GetFields()
      new[] { AbbrAt, $"{Result}" }
      .Concat(Errors.Bracket("<", ">"))
      .Concat(Declarations.SelectMany(d => d.Bracket("{", "}")));
}
