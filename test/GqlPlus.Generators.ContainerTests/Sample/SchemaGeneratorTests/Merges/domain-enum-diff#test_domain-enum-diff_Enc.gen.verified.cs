//HintName: test_domain-enum-diff_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-diff.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_diff;

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public Structured Encode(ItestDmnEnumDiff input)
    => new((decimal?)input.Value);
}
