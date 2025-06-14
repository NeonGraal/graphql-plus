using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema.Simple;

public class SimpleParserClassTestBase
  : DeclarationClassTestBase
{
  private readonly Parser<IGqlpTypeRef>.I _typeRef;

  internal Parser<IGqlpTypeRef>.D TypeRef { get; }

  public SimpleParserClassTestBase()
    => TypeRef = ParserFor(out _typeRef);

  internal void ParseTypeRefOk(string input)
  {
    IGqlpTypeRef typeRef = AtFor<IGqlpTypeRef>();
    typeRef.Name.Returns(input);
    ParseOk(_typeRef, typeRef);
  }

  internal void ParseTypeRefError()
    => ParseError(_typeRef);

}
