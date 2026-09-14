using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseDualTests(ComponentFixture<SchemaParserTestServices> fixture)
  : TestObject<IAstDualField>(fixture.GetService<ICheckObject<IAstDualField>>())
  , IClassFixture<ComponentFixture<SchemaParserTestServices>>;

internal sealed class ParseDualChecks(
  IParserRepository parsers
) : CheckObject<IAstDualField, DualFieldAst>(new DualFactories(), parsers);
