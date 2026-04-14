//HintName: test_parent-descr+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-descr+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Input;

internal class testPrntDescrInpDecoder
{
}

internal class testRefPrntDescrInpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_descr_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_descr_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntDescrInpObject>(_ => new testPrntDescrInpDecoder())
      .AddDecoder<ItestRefPrntDescrInpObject>(r => new testRefPrntDescrInpDecoder(r));
}
