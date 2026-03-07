using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class SimpleParserClassTestBase
  : DeclarationClassTestBase
{
  private readonly Parser<IGqlpTypeRef>.I _typeRef;

  public SimpleParserClassTestBase()
  {
    _typeRef = A.Of<Parser<IGqlpTypeRef>.I>();
    _typeRef.Parse(default!, default!)
      .ReturnsForAnyArgs(default(IGqlpTypeRef).Empty());
    Parser<IGqlpTypeRef>.L typeRefLazy = new(() => _typeRef);
    Parsers.Get<IGqlpTypeRef>().Returns(typeRefLazy);
  }

  internal void ParseTypeRefOk(string input)
  {
    IGqlpTypeRef typeRef = AtFor<IGqlpTypeRef>();
    typeRef.Name.Returns(input);
    ParseOk(_typeRef, typeRef);
  }

  internal void ParseTypeRefError()
    => ParseError(_typeRef);
}
