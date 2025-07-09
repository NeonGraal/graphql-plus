﻿namespace GqlPlus.Encoding.Simple;

public class EnumValueEncoderTests
  : EncoderClassTestBase<EnumValueModel>
{
  protected override IEncoder<EnumValueModel> Encoder { get; }
    = new EnumValueEncoder();

  [Theory, RepeatData]
  public void Encode_WithValidModel_ReturnsStructured(EnumLabelInput input, string contents)
    => EncodeAndCheck(new(input.EnumType, input.Label, contents), [
      "!_EnumValue",
      "description: " + contents.Quoted("'"),
      "label: " + input.Label,
      "typeKind: !_SimpleKind Enum",
      "typeName: " + input.EnumType
      ]);
}
