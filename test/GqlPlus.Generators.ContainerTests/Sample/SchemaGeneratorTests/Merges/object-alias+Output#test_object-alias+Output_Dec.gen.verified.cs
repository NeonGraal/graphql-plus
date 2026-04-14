//HintName: test_object-alias+Output_Dec.gen.cs
// Generated from {CurrentDirectory}object-alias+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Output;

internal class testObjAliasOutpDecoder
{
}

internal static class test_object_alias_OutputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alias_OutputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAliasOutpObject>(_ => new testObjAliasOutpDecoder());
}
