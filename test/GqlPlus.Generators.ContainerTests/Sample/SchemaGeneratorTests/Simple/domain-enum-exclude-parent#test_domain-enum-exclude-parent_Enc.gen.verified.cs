//HintName: test_domain-enum-exclude-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-exclude-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_exclude_parent;

internal class testDmnEnumExclPrntEncoder : IEncoder<ItestDmnEnumExclPrnt>
{
  public Structured Encode(ItestDmnEnumExclPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumExclPrntEncoder : IEncoder<testEnumDmnEnumExclPrnt>
{
  public Structured Encode(testEnumDmnEnumExclPrnt input)
    => new(input.ToString(), "_EnumDmnEnumExclPrnt");
}

internal class testPrntDmnEnumExclPrntEncoder : IEncoder<testPrntDmnEnumExclPrnt>
{
  public Structured Encode(testPrntDmnEnumExclPrnt input)
    => new(input.ToString(), "_PrntDmnEnumExclPrnt");
}

internal static class test_domain_enum_exclude_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_exclude_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumExclPrnt>(_ => new testDmnEnumExclPrntEncoder())
      .AddEncoder<testEnumDmnEnumExclPrnt>(_ => new testEnumDmnEnumExclPrntEncoder())
      .AddEncoder<testPrntDmnEnumExclPrnt>(_ => new testPrntDmnEnumExclPrntEncoder());
}
