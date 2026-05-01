//HintName: test_field-object+Input_Enc.gen.cs
// Generated from {CurrentDirectory}field-object+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Input;

internal class testFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjInpObject>
{
  private readonly IEncoder<ItestFldFieldObjInp> _itestFldFieldObjInp = encoders.EncoderFor<ItestFldFieldObjInp>();
  public Structured Encode(ItestFieldObjInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjInp);

  internal static testFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjInpEncoder : IEncoder<ItestFldFieldObjInpObject>
{
  public Structured Encode(ItestFldFieldObjInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_object_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_object_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldObjInpObject>(testFieldObjInpEncoder.Factory)
      .AddEncoder<ItestFldFieldObjInpObject>(testFldFieldObjInpEncoder.Factory);
}
