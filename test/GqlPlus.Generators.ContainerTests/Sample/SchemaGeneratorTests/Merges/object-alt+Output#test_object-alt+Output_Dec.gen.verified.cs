//HintName: test_object-alt+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-alt+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_Output;

internal class testObjAltOutpDecoder
{
}

internal class testObjAltOutpTypeDecoder
{
}

internal static class test_object_alt_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alt_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAltOutpObject>(_ => new testObjAltOutpDecoder())
      .AddDecoder<ItestObjAltOutpTypeObject>(_ => new testObjAltOutpTypeDecoder());
}
