using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class SimpleParserClassTestBase
  : DeclarationClassTestBase
{
  private readonly IParser<IAstTypeRef> _typeRef;

  public SimpleParserClassTestBase()
  {
    _typeRef = A.Of<IParser<IAstTypeRef>>();
    _typeRef.Parse(default!, default!)
      .ReturnsForAnyArgs(default(IAstTypeRef).Empty());
    Parsers.ParserFor<IAstTypeRef>().ReturnsForAnyArgs(() => _typeRef);
  }

  internal void ParseTypeRefOk(string input)
  {
    IAstTypeRef typeRef = AtFor<IAstTypeRef>();
    typeRef.Name.Returns(input);
    ParseOk(_typeRef, typeRef);
  }

  internal void ParseTypeRefError()
    => ParseError(_typeRef);
}
