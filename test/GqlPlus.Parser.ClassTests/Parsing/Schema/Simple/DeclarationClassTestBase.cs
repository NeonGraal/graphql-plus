using GqlPlus.Ast.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class SimpleParserClassTestBase
  : DeclarationClassTestBase
{
  private readonly Parser<IAstTypeRef>.I _typeRef;

  public SimpleParserClassTestBase()
  {
    _typeRef = A.Of<Parser<IAstTypeRef>.I>();
    _typeRef.Parse(default!, default!)
      .ReturnsForAnyArgs(default(IAstTypeRef).Empty());
    Parser<IAstTypeRef>.L typeRefLazy = new(() => _typeRef);
    Parsers.ParserFor<IAstTypeRef>().ReturnsForAnyArgs(typeRefLazy);
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
