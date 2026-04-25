//HintName: test_enum-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_descr;

internal class testEnumPrntDescrEncoder : IEncoder<testEnumPrntDescr>
{
  public Structured Encode(testEnumPrntDescr input)
    => input.EncodeEnum("EnumPrntDescr");

  internal static testEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntDescrEncoder : IEncoder<testPrntEnumPrntDescr>
{
  public Structured Encode(testPrntEnumPrntDescr input)
    => input.EncodeEnum("PrntEnumPrntDescr");

  internal static testPrntEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_enum_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumPrntDescr>(testEnumPrntDescrEncoder.Factory)
      .AddEncoder<testPrntEnumPrntDescr>(testPrntEnumPrntDescrEncoder.Factory);
}
