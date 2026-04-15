//HintName: test_enum-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}enum-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_enum_parent_descr;

internal class testEnumPrntDescrEncoder : IEncoder<testEnumPrntDescr>
{
  public Structured Encode(testEnumPrntDescr input)
    => new(input.ToString(), "_EnumPrntDescr");
}

internal class testPrntEnumPrntDescrEncoder : IEncoder<testPrntEnumPrntDescr>
{
  public Structured Encode(testPrntEnumPrntDescr input)
    => new(input.ToString(), "_PrntEnumPrntDescr");
}

internal static class test_enum_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_enum_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<testEnumPrntDescr>(_ => new testEnumPrntDescrEncoder())
      .AddEncoder<testPrntEnumPrntDescr>(_ => new testPrntEnumPrntDescrEncoder());
}
