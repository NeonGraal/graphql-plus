//HintName: test_object+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_Output;

internal class testObjOutpDecoder
{
}

internal static class test_object_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjOutpObject>(_ => new testObjOutpDecoder());
}
