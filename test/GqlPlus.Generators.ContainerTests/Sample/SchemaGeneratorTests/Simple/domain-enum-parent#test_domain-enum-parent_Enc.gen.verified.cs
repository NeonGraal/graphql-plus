//HintName: test_domain-enum-parent_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent;

internal class testDmnEnumPrntEncoder : IEncoder<ItestDmnEnumPrnt>
{
  public Structured Encode(ItestDmnEnumPrnt input)
    => new((decimal?)input.Value);
}

internal class testPrntDmnEnumPrntEncoder : IEncoder<ItestPrntDmnEnumPrnt>
{
  public Structured Encode(ItestPrntDmnEnumPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumPrntEncoder : IEncoder<testEnumDmnEnumPrnt>
{
  public Structured Encode(testEnumDmnEnumPrnt input)
    => new(input.ToString(), "_EnumDmnEnumPrnt");
}

internal static class test_domain_enum_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumPrnt>(_ => new testDmnEnumPrntEncoder())
      .AddEncoder<ItestPrntDmnEnumPrnt>(_ => new testPrntDmnEnumPrntEncoder())
      .AddEncoder<testEnumDmnEnumPrnt>(_ => new testEnumDmnEnumPrntEncoder());
}
