using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Schema;

public class SchemaAstTests
  : AstAbbreviatedTests
{
  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new AstAbbreviatedChecks<SchemaAst>(name => new SchemaAst(AstNulls.At) { Declarations = [new OptionDeclAst(AstNulls.At, name)] });

  protected override string AbbreviatedString(string input)
    => $"( !Sc Failure {{ !Op {input} }} )";
}
