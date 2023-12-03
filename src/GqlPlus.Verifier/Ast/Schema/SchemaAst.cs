namespace GqlPlus.Verifier.Ast.Schema;

public record class SchemaAst(TokenAt At, string Name)
  : AstNamed(At, Name)
{
  public ParseResultKind Result { get; set; }
  public TokenMessage[] Errors { get; set; } = Array.Empty<TokenMessage>();

  public AstDeclaration[] Declarations { get; set; } = Array.Empty<AstDeclaration>();

  internal override string Abbr => "G";

  public SchemaAst(TokenAt at)
    : this(at, "") { }

  public string Render()
  {
    using var sw = new StringWriter();
    var indent = 0;
    var begins = new[] { "(", "{", "[", "<" };
    var ends = new[] { ")", "}", "]", ">" };
    foreach (var field in GetFields()) {
      if (string.IsNullOrWhiteSpace(field)) {
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
