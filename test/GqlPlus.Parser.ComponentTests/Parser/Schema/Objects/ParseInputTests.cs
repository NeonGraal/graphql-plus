using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public class ParseInputTests(ComponentFixture<SchemaParserTestServices> fixture)
  : TestObject<IAstInputField>(fixture.GetService<ICheckObject<IAstInputField>>())
  , IClassFixture<ComponentFixture<SchemaParserTestServices>>;

internal sealed class ParseInputChecks(
  IParserRepository parsers
) : CheckObject<IAstInputField, InputFieldAst>(new InputFactories(), parsers);
