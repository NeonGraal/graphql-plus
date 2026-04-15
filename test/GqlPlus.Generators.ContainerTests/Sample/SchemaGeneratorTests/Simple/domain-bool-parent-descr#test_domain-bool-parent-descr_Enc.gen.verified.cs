//HintName: test_domain-bool-parent-descr_Enc.gen.cs
// Generated from {CurrentDirectory}domain-bool-parent-descr.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_domain_bool_parent_descr;

internal class testDmnBoolPrntDescrEncoder : IEncoder<ItestDmnBoolPrntDescr>
{
  public Structured Encode(ItestDmnBoolPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnBoolPrntDescrEncoder : IEncoder<ItestPrntDmnBoolPrntDescr>
{
  public Structured Encode(ItestPrntDmnBoolPrntDescr input)
    => new(input.Value);
}

internal static class test_domain_bool_parent_descrEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_domain_bool_parent_descrEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestDmnBoolPrntDescr>(_ => new testDmnBoolPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnBoolPrntDescr>(_ => new testPrntDmnBoolPrntDescrEncoder());
}
