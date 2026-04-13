//HintName: test_Input_Enc.gen.cs
// Generated from {CurrentDirectory}Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Input;

internal class test_InputFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_InputFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_InputFieldType>> _itest_ObjFieldObject<Itest_InputFieldType> = encoders.EncoderFor<Itest_ObjFieldObject<Itest_InputFieldType>>();
  public Structured Encode(Itest_InputFieldObject input)
    => _itest_ObjFieldObject<Itest_InputFieldType>.Encode(input);
}

internal class test_InputFieldTypeEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_InputFieldTypeObject>
{
  private readonly IEncoder<Itest_ObjFieldTypeObject> _itest_ObjFieldType = encoders.EncoderFor<Itest_ObjFieldTypeObject>();
  private readonly IEncoder<GqlpValue> _gqlpValue = encoders.EncoderFor<GqlpValue>();
  public Structured Encode(Itest_InputFieldTypeObject input)
    => _itest_ObjFieldType.Encode(input)
      .AddEncoded("defaultValue", input.DefaultValue, _gqlpValue);
}
