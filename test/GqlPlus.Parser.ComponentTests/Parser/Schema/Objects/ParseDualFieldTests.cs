using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseDualFieldTests(ComponentFixture<SchemaParserTestServices> fixture)
  : TestObjectField<IAstDualField>(fixture.GetService<ICheckObjectField<IAstDualField>>())
  , IClassFixture<ComponentFixture<SchemaParserTestServices>>;

internal sealed class ParseDualFieldChecks(
  IParserRepository parsers
) : CheckObjectField<IAstDualField, DualFieldAst>(new DualFactories(), parsers);
