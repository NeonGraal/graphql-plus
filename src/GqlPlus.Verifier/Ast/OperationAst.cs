namespace GqlPlus.Verifier.Ast;

internal record class OperationAst(string Name)
  : AstNamedDirectives(Name)
{
  internal ParseResult Result { get; set; }
  internal string Category { get; set; } = "query";
  internal VariableAst[] Variables { get; set; } = Array.Empty<VariableAst>();
  internal string? ResultType { get; set; }
  public ArgumentAst? Argument { get; set; }
  internal AstSelection[]? Object { get; set; }
  internal ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  internal FragmentAst[] Fragments { get; set; } = Array.Empty<FragmentAst>();
  protected override string Abbr => "O";

  public OperationAst() : this("") { }
}
