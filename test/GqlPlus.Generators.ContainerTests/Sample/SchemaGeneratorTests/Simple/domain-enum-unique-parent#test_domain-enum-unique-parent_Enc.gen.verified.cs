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

  internal static testDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public Structured Encode(testEnumDmnEnumUnqPrnt input)
    => new(input.ToString(), "_EnumDmnEnumUnqPrnt");

  internal static testEnumDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public Structured Encode(testPrntDmnEnumUnqPrnt input)
    => new(input.ToString(), "_PrntDmnEnumUnqPrnt");

  internal static testPrntDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public Structured Encode(testDupDmnEnumUnqPrnt input)
    => new(input.ToString(), "_DupDmnEnumUnqPrnt");

  internal static testDupDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_unique_parentEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_unique_parentEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumUnqPrnt>(testDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumUnqPrnt>(testEnumDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumUnqPrnt>(testPrntDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testDupDmnEnumUnqPrnt>(testDupDmnEnumUnqPrntEncoder.Factory);
}
