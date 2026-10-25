//HintName: test_parent+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

internal class testPrntInpDecoder : NullDecoder<ItestPrntInpObject>
{

  internal static testPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntInpDecoder : NullDecoder<ItestRefPrntInpObject>
{
  public decimal Parent { get; set; } = default!;

  internal static testRefPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_parent_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntInpObject>(testPrntInpDecoder.Factory)
      .AddDecoder<ItestRefPrntInpObject>(testRefPrntInpDecoder.Factory);
}
