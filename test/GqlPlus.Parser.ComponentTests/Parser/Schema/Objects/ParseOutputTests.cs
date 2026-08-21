using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseOutputTests(ComponentFixture<SchemaParserTestServices> fixture)
  : TestObject<IAstOutputField>(fixture.GetService<ICheckObject<IAstOutputField>>())
  , IClassFixture<ComponentFixture<SchemaParserTestServices>>;

internal sealed class ParseOutputChecks(
  IParserRepository parsers
) : CheckObject<IAstOutputField, OutputFieldAst>(new OutputFactories(), parsers);
