//HintName: test_object-alias+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-alias+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alias_Input;

internal class testObjAliasInpDecoder
{

  internal static testObjAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_alias_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_alias_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjAliasInpObject>(testObjAliasInpDecoder.Factory);
}
