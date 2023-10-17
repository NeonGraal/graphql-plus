﻿namespace GqlPlus.Verifier.Ast;

internal record class OperationAst(ParseAt At, string Name)
  : AstNamedDirectives(At, Name)
{
  public ParseResult Result { get; set; }
  public ParseError[] Errors { get; set; } = Array.Empty<ParseError>();

  public string Category { get; set; } = "query";

  public VariableAst[] Variables { get; set; } = Array.Empty<VariableAst>();
  public ArgumentAst[] Usages { get; init; } = Array.Empty<ArgumentAst>();

  public string? ResultType { get; set; }
  public ArgumentAst? Argument { get; set; }
  public AstSelection[]? Object { get; set; }
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();

  public FragmentAst[] Fragments { get; set; } = Array.Empty<FragmentAst>();
  public SpreadAst[] Spreads { get; set; } = Array.Empty<SpreadAst>();

  protected override string Abbr => "O";

  public OperationAst(ParseAt at) : this(at, "") { }

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
      new[] { AbbrAt, Category, $"{Result}" }
      .Concat(Errors.Bracket("<", ">"))
      .Concat(Variables.Bracket("[", "]"))
      .Concat(Directives.AsString())
      .Append(ResultType)
      .Concat(AstExtensions.Bracket("(", ")", new[] { Argument }))
      .Concat(AstExtensions.Bracket("{", "}", Object))
      .Append(string.Join("", Modifiers.AsString()))
      .Concat(AstExtensions.Bracket(string.Empty, string.Empty, Fragments));
}
