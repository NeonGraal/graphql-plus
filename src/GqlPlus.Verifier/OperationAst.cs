namespace GqlPlus.Verifier;

internal class OperationAst
{
  internal ParseResult Result { get; set; }
  internal string Category { get; set; } = "query";
  internal string Name { get; set; } = "";
  internal VariableAst[] Variables { get; set; } = Array.Empty<VariableAst>();
  internal DirectiveAst[] Directives { get; set; } = Array.Empty<DirectiveAst>();
  internal string? ResultType { get; set; }
  internal SelectionAst[]? ResultObject { get; set; }
  internal ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();
  internal DefinitionAst[] Definitions { get; set; } = Array.Empty<DefinitionAst>();
}
