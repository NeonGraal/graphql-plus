//HintName: test_object-parent+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-parent+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Output;

internal class testObjPrntOutpDecoder
{
}

internal class testRefObjPrntOutpDecoder
{
}

internal static class test_object_parent_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_parent_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjPrntOutpObject>(_ => new testObjPrntOutpDecoder())
      .AddDecoder<ItestRefObjPrntOutpObject>(_ => new testRefObjPrntOutpDecoder());
}
