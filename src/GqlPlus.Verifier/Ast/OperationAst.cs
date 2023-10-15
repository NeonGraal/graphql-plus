namespace GqlPlus.Verifier.Ast;

internal record class OperationAst(ParseAt At, string Name)
  : AstNamedDirectives(At, Name)
{
  internal ParseResult Result { get; set; }
  internal ParseError[] Errors { get; set; } = Array.Empty<ParseError>();

  internal string Category { get; set; } = "query";

  internal VariableAst[] Variables { get; set; } = Array.Empty<VariableAst>();
  internal ArgumentAst[] Usages { get; init; } = Array.Empty<ArgumentAst>();

  internal string? ResultType { get; set; }
  public ArgumentAst? Argument { get; set; }
  internal AstSelection[]? Object { get; set; }
  internal ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();

  internal FragmentAst[] Fragments { get; set; } = Array.Empty<FragmentAst>();
  internal SpreadAst[] Spreads { get; set; } = Array.Empty<SpreadAst>();

  protected override string Abbr => "O";

  public OperationAst(ParseAt at) : this(at, "") { }
}
