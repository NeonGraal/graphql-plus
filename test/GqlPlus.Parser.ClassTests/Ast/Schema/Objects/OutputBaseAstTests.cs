using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class OutputBaseAstTests
  : AstObjectBaseTests<IGqlpOutputBase>
{
  [Theory, RepeatData]
  public void String_ForDual(string input, string[] arguments)
    => _checks.String_ForDual(input, arguments);

  protected override string AbbreviatedString(string input)
    => $"( {input} )";

  private readonly AstObjBaseChecks<IGqlpOutputBase, OutputBaseAst, IGqlpObjArg, OutputArgAst> _checks
    = new(name => new OutputBaseAst(AstNulls.At, name), arguments => arguments.OutputArgs());

  internal override IAstObjBaseChecks<IGqlpOutputBase> ObjBaseChecks => _checks;
}
