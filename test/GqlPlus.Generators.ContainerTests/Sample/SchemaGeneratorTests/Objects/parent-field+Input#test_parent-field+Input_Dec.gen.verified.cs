//HintName: test_parent-field+Input_Dec.gen.cs
// Generated from {CurrentDirectory}parent-field+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

internal class testPrntFieldInpDecoder
{
  public decimal Field { get; set; }
}

internal class testRefPrntFieldInpDecoder
{
  public decimal Parent { get; set; }
}

internal static class test_parent_field_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_parent_field_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestPrntFieldInpObject>(r => new testPrntFieldInpDecoder(r))
      .AddDecoder<ItestRefPrntFieldInpObject>(r => new testRefPrntFieldInpDecoder(r));
}
