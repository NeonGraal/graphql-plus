//HintName: test_Output_Enc.gen.cs
// Generated from {CurrentDirectory}Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Output;

internal class test_OutputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OutputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_OutputFieldObject input)
    => _itest_ObjField.Encode(input);
}

internal class test_OutputFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_OutputFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjFieldTypeObject> _itest_ObjFieldType = encoders.EncoderFor<Itest_ObjFieldTypeObject>();
  private readonly IEncoder<Itest_InputFieldType> _itest_InputFieldType = encoders.EncoderFor<Itest_InputFieldType>();
  public Structured Encode(Itest_OutputFieldTypeObject input)
    => _itest_ObjFieldType.Encode(input)
      .AddEncoded("parameter", input.Parameter, _itest_InputFieldType);
}

internal static class test_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_OutputFieldObject>(r => new test_OutputFieldEncoder(r))
      .AddEncoder<Itest_OutputFieldTypeObject>(r => new test_OutputFieldTypeEncoder(r));
}
