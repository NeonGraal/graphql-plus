//HintName: test_union-same_Enc.gen.cs
// Generated from {CurrentDirectory}union-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_union_same;

internal class testUnionSameEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSame>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSame input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();
}

internal static class test_union_sameEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_union_sameEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestUnionSame>(r => new testUnionSameEncoder(r));
}
