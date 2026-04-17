//HintName: test_domain-enum-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_enum_descr;

internal class testDmnEnumDescrEncoder : IEncoder<ItestDmnEnumDescr>
{
  public Structured Encode(ItestDmnEnumDescr input)
    => new((decimal?)input.Value);

  internal static testDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumDescrEncoder : IEncoder<testEnumDmnEnumDescr>
{
  public Structured Encode(testEnumDmnEnumDescr input)
    => new(input.ToString(), "_EnumDmnEnumDescr");

  internal static testEnumDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_domain_enum_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_enum_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnEnumDescr>(testDmnEnumDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumDescr>(testEnumDmnEnumDescrEncoder.Factory);
}
