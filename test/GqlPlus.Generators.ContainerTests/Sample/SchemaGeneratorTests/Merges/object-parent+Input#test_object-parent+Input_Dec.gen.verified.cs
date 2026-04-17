//HintName: test_object-parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}object-parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_parent_Input;

internal class testObjPrntInpDecoder
{

  internal static testObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntInpDecoder
{

  internal static testRefObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_object_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_object_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestObjPrntInpObject>(testObjPrntInpDecoder.Factory)
      .AddDecoder<ItestRefObjPrntInpObject>(testRefObjPrntInpDecoder.Factory);
}
