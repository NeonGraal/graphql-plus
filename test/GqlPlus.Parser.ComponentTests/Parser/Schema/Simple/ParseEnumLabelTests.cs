using GqlPlus.Ast.Schema;

namespace GqlPlus.Parser.Schema.Simple;

public sealed class ParseEnumLabelTests(ComponentFixture<Startup> fixture)
  : BaseAliasedTests<string, IAstEnumLabel>(fixture.GetService<IBaseAliasedChecks<string, IAstEnumLabel>>())
  , IClassFixture<ComponentFixture<Startup>>;
