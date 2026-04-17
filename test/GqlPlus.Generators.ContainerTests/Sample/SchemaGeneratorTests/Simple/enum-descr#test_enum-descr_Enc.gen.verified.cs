//HintName: test_enum-descr_Enc.gen.cs
// Generated from {CurrentDirectory}enum-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_descr;

internal class testEnumDescrEncoder : IEncoder<testEnumDescr>
{
  public Structured Encode(testEnumDescr input)
    => new(input.ToString(), "_EnumDescr");

  internal static testEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_enum_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumDescr>(testEnumDescrEncoder.Factory);
}
