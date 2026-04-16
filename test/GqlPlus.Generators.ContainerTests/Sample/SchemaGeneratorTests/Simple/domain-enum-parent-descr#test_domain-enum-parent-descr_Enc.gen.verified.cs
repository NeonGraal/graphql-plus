//HintName: test_domain-enum-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_parent_descr;

internal class testDmnEnumPrntDescrEncoder : IEncoder<ItestDmnEnumPrntDescr>
{
  public Structured Encode(ItestDmnEnumPrntDescr input)
    => new((decimal?)input.Value);

  internal static testDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrEncoder : IEncoder<ItestPrntDmnEnumPrntDescr>
{
  public Structured Encode(ItestPrntDmnEnumPrntDescr input)
    => new((decimal?)input.Value);

  internal static testPrntDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrEncoder : IEncoder<testEnumDmnEnumPrntDescr>
{
  public Structured Encode(testEnumDmnEnumPrntDescr input)
    => new(input.ToString(), "_EnumDmnEnumPrntDescr");

  internal static testEnumDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumPrntDescr>(testEnumDmnEnumPrntDescrEncoder.Factory);
}
