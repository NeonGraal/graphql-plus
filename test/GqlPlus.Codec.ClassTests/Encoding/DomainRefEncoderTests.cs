﻿namespace GqlPlus.Encoding;

public class DomainRefEncoderTests
  : EncoderClassTestBase<DomainRefModel>
{
  protected override IEncoder<DomainRefModel> Encoder { get; }
    = new DomainRefEncoder();

  [Theory, RepeatData]
  public void Encode_WithAll_ReturnsExpected(string name, DomainKindModel domainKind, string description)
  {
    // Arrange
    EncodeAndCheck(new DomainRefModel(name, domainKind, description), [
        "!_DomainRef",
        "description: " + description.Quoted("'"),
        $"domainKind: !_DomainKind {domainKind}",
        "name: "  + name,
        "typeKind: !_SimpleKind Domain"
      ]);
  }
}
