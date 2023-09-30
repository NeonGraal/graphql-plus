namespace GqlPlus.Verifier.Ast;

internal record class OperationAst : NamedAst
{
  internal ParseResult Result { get; set; }
  internal string Category { get; set; } = "query";
  internal VariableAst[] Variables { get; set; } = Array.Empty<VariableAst>();
  internal DirectiveAst[] Directives { get; set; } = Array.Empty<DirectiveAst>();
  internal string? ResultType { get; set; }
  internal SelectionAst[]? ResultObject { get; set; }
  internal ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  internal FragmentAst[] Fragments { get; set; } = Array.Empty<FragmentAst>();

  public OperationAst() : base("") { }
  public OperationAst(string name) : base(name) { }
}
