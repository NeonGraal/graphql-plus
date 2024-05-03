﻿using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Parse.Schema.Simple;
using GqlPlus.Result;
using NSubstitute;

namespace GqlPlus.Parse.Schema;

public class ParseDomainClassTests : ClassTestBase
{
  [Theory, RepeatData(Repeats)]
  public void Parse_UnknownKind_ReturnsExpected(string name)
  {
    var tokens = Tokens("{ ");

    var simpleName = NameFor<ISimpleName>(name);
    var param = ArrayParserFor<NullAst>();
    var aliases = ArrayParserFor<string>();
    var option = OptionParserFor<NullOption>();
    var definition = ParserFor<DomainDefinition>(out var definitionParser);
    definitionParser.Parse(tokens, default!)
      .ReturnsForAnyArgs(new DomainDefinition() { Kind = (DomainKind)99 }.Ok());

    var domain = new ParseDomain(simpleName, param, aliases, option, definition);

    var result = domain.Parse(tokens, "test");

    result.Should().BeAssignableTo<IResultOk<AstDomain>>();
  }
}
