using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Decoding.Objects;

public class TypeFilterModelDecoderTests
  : FilterModelDecoderTestBase<TypeFilterModel>
{
  private IDecoder<TypeKindModel?> Kind { get; }
    = DFor<TypeKindModel?>();

  public TypeFilterModelDecoderTests()
  {
    IDecoderRepository decoders = A.Of<IDecoderRepository>();
    decoders.DecoderForReturns(Boolean);
    decoders.DecoderForReturns<INameFilterDecoder, string>(NameFilter);
    decoders.DecoderForReturns(Kind);
    Decoder = new TypeFilterModelDecoder(decoders);
  }

  protected override IDecoder<TypeFilterModel> Decoder { get; }

  [Theory, RepeatData]
  public void Decode_Kinds_ReturnsExpected(
    [NotNull] TypeKindModel[] kinds)
  {
    IValue input = DecoderTestValue.FromMap([
      new("kinds", DecoderTestValue.FromList(kinds.Select(kind => (IValue)new ScalarValue(kind.ToString())))),
    ]);

    DecodeReturns(Kind, TypeKindModel.Internal);

    IMessages messages = Decoder.Decode(input, out TypeFilterModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(0),
        () => result.Kinds.Length.ShouldBe(kinds.Length),
        DecoderCalled(Kind, kinds.ThrowIfNull().Length),
        MessagesEmpty(messages, result)
      );
  }

  [Theory, RepeatData]
  public void Decode_NamesAndKinds_ReturnsExpected(
    [NotNull] string[] names,
    [NotNull] TypeKindModel[] kinds)
  {
    IValue input = DecoderTestValue.FromMap([
      new("names", DecoderTestValue.FromList(names.Select(name => (IValue)new ScalarValue(name)))),
      new("kinds", DecoderTestValue.FromList(kinds.Select(kind => (IValue)new ScalarValue(kind.ToString())))),
    ]);

    DecodeReturns(Kind, TypeKindModel.Internal);

    IMessages messages = Decoder.Decode(input, out TypeFilterModel? result);

    result.ShouldNotBeNull()
      .ShouldSatisfyAllConditions(
        () => result.Names.Length.ShouldBe(names.Length),
        () => result.Kinds.Length.ShouldBe(kinds.Length),
        DecoderCalled(NameFilter, names.ThrowIfNull().Length),
        DecoderCalled(Kind, kinds.ThrowIfNull().Length),
        MessagesEmpty(messages, result)
      );
  }
}
