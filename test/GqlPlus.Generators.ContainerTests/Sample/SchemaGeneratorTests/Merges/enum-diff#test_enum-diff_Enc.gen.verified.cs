//HintName: test_enum-diff_Enc.gen.cs
// Generated from {CurrentDirectory}enum-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_diff;

internal class testEnumDiffEncoder : IEncoder<testEnumDiff>
{
  public Structured Encode(testEnumDiff input)
    => new(input.ToString(), "_EnumDiff");
}

internal static class test_enum_diffEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_diffEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumDiff>(_ => new testEnumDiffEncoder());
}
