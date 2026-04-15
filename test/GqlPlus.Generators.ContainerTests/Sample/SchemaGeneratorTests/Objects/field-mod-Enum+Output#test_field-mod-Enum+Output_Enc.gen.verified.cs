//HintName: test_field-mod-Enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-mod-Enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_mod_Enum_Output;

internal class testFieldModEnumOutpEncoder : IEncoder<ItestFieldModEnumOutpObject>
{
  public Structured Encode(ItestFieldModEnumOutpObject input)
    => Structured.Empty();
}

internal class testEnumFieldModEnumOutpEncoder : IEncoder<testEnumFieldModEnumOutp>
{
  public Structured Encode(testEnumFieldModEnumOutp input)
    => new(input.ToString(), "_EnumFieldModEnumOutp");
}

internal static class test_field_mod_Enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_mod_Enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldModEnumOutpObject>(_ => new testFieldModEnumOutpEncoder())
      .AddEncoder<testEnumFieldModEnumOutp>(_ => new testEnumFieldModEnumOutpEncoder());
}
