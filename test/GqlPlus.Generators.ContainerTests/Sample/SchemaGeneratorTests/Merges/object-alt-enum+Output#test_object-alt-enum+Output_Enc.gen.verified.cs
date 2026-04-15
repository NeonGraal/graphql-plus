//HintName: test_object-alt-enum+Output_Enc.gen.cs
// Generated from {CurrentDirectory}object-alt-enum+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_alt_enum_Output;

internal class testObjAltEnumOutpEncoder : IEncoder<ItestObjAltEnumOutpObject>
{
  public Structured Encode(ItestObjAltEnumOutpObject input)
    => Structured.Empty();

  internal static testObjAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_object_alt_enum_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_object_alt_enum_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestObjAltEnumOutpObject>(testObjAltEnumOutpEncoder.Factory);
}
