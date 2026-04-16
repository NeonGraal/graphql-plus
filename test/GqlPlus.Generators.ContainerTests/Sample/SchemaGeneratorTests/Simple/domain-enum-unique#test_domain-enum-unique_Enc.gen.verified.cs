//HintName: test_domain-enum-unique_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-unique.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_unique;

internal class testDmnEnumUnqEncoder : IEncoder<ItestDmnEnumUnq>
{
  public Structured Encode(ItestDmnEnumUnq input)
    => new((decimal?)input.Value);

  internal static testDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqEncoder : IEncoder<testEnumDmnEnumUnq>
{
  public Structured Encode(testEnumDmnEnumUnq input)
    => new(input.ToString(), "_EnumDmnEnumUnq");

  internal static testEnumDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqEncoder : IEncoder<testDupDmnEnumUnq>
{
  public Structured Encode(testDupDmnEnumUnq input)
    => new(input.ToString(), "_DupDmnEnumUnq");

  internal static testDupDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_uniqueEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_uniqueEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumUnq>(testDmnEnumUnqEncoder.Factory)
      .AddEncoder<testEnumDmnEnumUnq>(testEnumDmnEnumUnqEncoder.Factory)
      .AddEncoder<testDupDmnEnumUnq>(testDupDmnEnumUnqEncoder.Factory);
}
