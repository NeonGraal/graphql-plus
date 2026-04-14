//HintName: test_domain-enum-all-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-all-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_all_descr;

internal class testDmnEnumAllDescrEncoder : IEncoder<ItestDmnEnumAllDescr>
{
  public Structured Encode(ItestDmnEnumAllDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllDescrEncoder : IEncoder<testEnumDmnEnumAllDescr>
{
  public Structured Encode(testEnumDmnEnumAllDescr input)
    => new(input.ToString(), "_EnumDmnEnumAllDescr");
}

internal static class test_domain_enum_all_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_all_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumAllDescr>(_ => new testDmnEnumAllDescrEncoder())
      .AddEncoder<testEnumDmnEnumAllDescr>(_ => new testEnumDmnEnumAllDescrEncoder());
}
