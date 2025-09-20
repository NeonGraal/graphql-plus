namespace GqlPlus.Ast.Schema.Objects;

public class OutputBaseAstTests
  : AstObjectBaseTests
{
  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<OutputBaseAst, OutputArgAst> _checks
    = new(name => new OutputBaseAst(AstNulls.At, name), arguments => arguments.OutputArgs());

  internal override IAstObjBaseChecks ObjBaseChecks => _checks;
}
