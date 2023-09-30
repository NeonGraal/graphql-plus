namespace GqlPlus.Verifier.Ast;

internal record class OperationAst(string Name) : NamedDirectivesAst(Name)
{
  internal ParseResult Result { get; set; }
  internal string Category { get; set; } = "query";
  internal VariableAst[] Variables { get; set; } = Array.Empty<VariableAst>();
  internal string? ResultType { get; set; }
  internal SelectionAst[]? ResultObject { get; set; }
  internal ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  internal FragmentAst[] Fragments { get; set; } = Array.Empty<FragmentAst>();

  public OperationAst() : this("") { }
}
