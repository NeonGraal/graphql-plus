//HintName: test_field-object+Output_Enc.gen.cs
// Generated from {CurrentDirectory}field-object+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Output;

internal class testFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjOutpObject>
{
  private readonly IEncoder<ItestFldFieldObjOutp> _itestFldFieldObjOutp = encoders.EncoderFor<ItestFldFieldObjOutp>();
  public Structured Encode(ItestFieldObjOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjOutp);
}

internal class testFldFieldObjOutpEncoder : IEncoder<ItestFldFieldObjOutpObject>
{
  public Structured Encode(ItestFldFieldObjOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal static class test_field_object_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_object_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldObjOutpObject>(r => new testFieldObjOutpEncoder(r))
      .AddEncoder<ItestFldFieldObjOutpObject>(_ => new testFldFieldObjOutpEncoder());
}
