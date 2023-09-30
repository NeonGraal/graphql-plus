namespace GqlPlus.Verifier.Ast;

internal record class SpreadAst(string Name) : NamedDirectivesAst(Name), SelectionAst { }
