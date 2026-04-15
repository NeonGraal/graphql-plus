//HintName: test_generic-value+Input_Dec.gen.cs
// Generated from {CurrentDirectory}generic-value+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_value_Input;

internal class testGnrcValueInpDecoder
{
}

internal class testRefGnrcValueInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcValueInpDecoder
{
  public string gnrcValueInp { get; set; }
}

internal static class test_generic_value_InputDecoders
{
  internal static IDecoderRepositoryBuilder Addtest_generic_value_InputDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestGnrcValueInpObject>(_ => new testGnrcValueInpDecoder())
      .AddDecoder<testEnumGnrcValueInp>(_ => new testEnumGnrcValueInpDecoder());
}
