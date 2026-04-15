//HintName: test_domain-enum-unique-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique_parent;

internal class testDmnEnumUnqPrntEncoder : IEncoder<ItestDmnEnumUnqPrnt>
{
  public Structured Encode(ItestDmnEnumUnqPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public Structured Encode(testEnumDmnEnumUnqPrnt input)
    => new(input.ToString(), "_EnumDmnEnumUnqPrnt");
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public Structured Encode(testPrntDmnEnumUnqPrnt input)
    => new(input.ToString(), "_PrntDmnEnumUnqPrnt");
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public Structured Encode(testDupDmnEnumUnqPrnt input)
    => new(input.ToString(), "_DupDmnEnumUnqPrnt");
}

internal static class test_domain_enum_unique_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_unique_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumUnqPrnt>(_ => new testDmnEnumUnqPrntEncoder())
      .AddEncoder<testEnumDmnEnumUnqPrnt>(_ => new testEnumDmnEnumUnqPrntEncoder())
      .AddEncoder<testPrntDmnEnumUnqPrnt>(_ => new testPrntDmnEnumUnqPrntEncoder())
      .AddEncoder<testDupDmnEnumUnqPrnt>(_ => new testDupDmnEnumUnqPrntEncoder());
}
