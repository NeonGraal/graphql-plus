﻿using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Decoding.Objects;

public class TypeFilterModelDecoderTests
  : FilterModelDecoderTestBase<TypeFilterModel>
{
  private IDecoder<TypeKindModel?> Kind { get; }
    = DFor<TypeKindModel?>();

  public TypeFilterModelDecoderTests()
    => Decoder = new TypeFilterModelDecoder(Boolean, NameFilter, Kind);

  protected override IDecoder<TypeFilterModel> Decoder { get; }

  [Theory, RepeatData]
  public void Decode_Kinds_ReturnsExpected(
    [NotNull] TypeKindModel[] kinds)
  {
    Map<Structured> input = new() {
      ["kinds"] = kinds.Encode()
    };

    DecodeReturns(Kind, TypeKindModel.Internal);

    IMessages messages = Decoder.Decode(input.Encode(), out TypeFilterModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(0),
        () => result.Kinds.Length.ShouldBe(kinds.Length),
        DecoderCalled(Kind, kinds.Length),
        MessagesEmpty(messages, result)
      );
  }

  [Theory, RepeatData]
  public void Decode_NamesAndKinds_ReturnsExpected(
    [NotNull] string[] names,
    [NotNull] TypeKindModel[] kinds)
  {
    Map<Structured> input = new() {
      ["names"] = names.Encode(),
      ["kinds"] = kinds.Encode()
    };

    DecodeReturns(Kind, TypeKindModel.Internal);

    IMessages messages = Decoder.Decode(input.Encode(), out TypeFilterModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        () => result.Kinds.Length.ShouldBe(kinds.Length),
        DecoderCalled(NameFilter, names.Length),
        DecoderCalled(Kind, kinds.Length),
        MessagesEmpty(messages, result)
      );
  }
}
