using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public class ParseOutputTests(
  Parser<OutputDeclAst>.D parser
) : TestObject
{
  internal override ICheckObject ObjectChecks => _checks;

  private readonly CheckObject<OutputDeclAst, OutputFieldAst, IGqlpOutputBase, OutputBaseAst> _checks
    = new(new OutputFactories(), parser);
}
