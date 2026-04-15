//HintName: test_enum-same_Enc.gen.cs
// Generated from {CurrentDirectory}enum-same.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_same;

internal class testEnumSameEncoder : IEncoder<testEnumSame>
{
  public Structured Encode(testEnumSame input)
    => new(input.ToString(), "_EnumSame");
}

internal static class test_enum_sameEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_sameEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumSame>(_ => new testEnumSameEncoder());
}
