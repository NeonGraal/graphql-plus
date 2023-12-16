using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Operation;

public record class OperationAst(TokenAt At, string Name)
  : AstDirectives(At, Name), IAstModified
{
  public ParseResultKind Result { get; set; }
  public TokenMessages Errors { get; set; } = [];

  public string Category { get; set; } = "query";

  public VariableAst[] Variables { get; set; } = [];
  public ArgumentAst[] Usages { get; init; } = [];

  public string? ResultType { get; set; }
  public ArgumentAst? Argument { get; set; }
  public IAstSelection[]? Object { get; set; }
  public ModifierAst[] Modifiers { get; set; } = [];

  public FragmentAst[] Fragments { get; set; } = [];
  public SpreadAst[] Spreads { get; set; } = [];

  internal override string Abbr => "g";

  public OperationAst(TokenAt at)
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
      new[] { AbbrAt, Category, $"{Result}" }
      .Concat(Errors.Bracket("<", ">"))
      .Concat(Variables.Bracket("[", "]"))
      .Concat(Directives.AsString())
      .Append(ResultType)
      .Concat(Argument.Bracket("(", ")"))
      .Concat(Object.Bracket("{", "}"))
      .Append(Modifiers.AsString().Joined(""))
      .Concat(Fragments.Bracket());
}
