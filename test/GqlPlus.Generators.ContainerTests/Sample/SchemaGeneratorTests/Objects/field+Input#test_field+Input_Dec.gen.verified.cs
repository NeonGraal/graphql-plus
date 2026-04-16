//HintName: test_field+Input_Dec.gen.cs
// Generated from {CurrentDirectory}field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_Input;

internal class testFieldInpDecoder
{
  public string Field { get; set; }

  internal static testFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal static class test_field_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_field_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestFieldInpObject>(testFieldInpDecoder.Factory);
}
