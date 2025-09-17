using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class InputBaseAstTests
  : AstObjectBaseTests<IGqlpInputBase>
{
  [Theory, RepeatData]
  public void String_ForDual(string input, string[] arguments)
    => _checks.String_ForDual(input, arguments);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpInputBase, InputBaseAst, InputArgAst> _checks
    = new(name => new InputBaseAst(AstNulls.At, name), arguments => arguments.InputArgs());

  internal override IAstObjBaseChecks<IGqlpInputBase> ObjBaseChecks => _checks;
}
