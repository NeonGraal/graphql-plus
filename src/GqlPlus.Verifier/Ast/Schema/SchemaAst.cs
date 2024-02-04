﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class SchemaAst(TokenAt At, string Name)
  : AstNamed(At, Name), IEquatable<SchemaAst>
{
  public ParseResultKind Result { get; set; }
  internal TokenMessages Errors { get; set; } = [];

  public AstDeclaration[] Declarations { get; set; } = [];

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

  public bool Equals(SchemaAst? other)
    => base.Equals(other)
      && Result == other.Result
      && Errors.SequenceEqual(other.Errors);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Result, Errors.Count);

  internal override IEnumerable<string?> GetFields()
    => // base.GetFields()
      new[] { AbbrAt, Name, $"{Result}" }
      .Concat(Errors.Bracket("<", ">", true))
      .Concat(Declarations.SelectMany(d => d.Bracket("{", "}")));
}
