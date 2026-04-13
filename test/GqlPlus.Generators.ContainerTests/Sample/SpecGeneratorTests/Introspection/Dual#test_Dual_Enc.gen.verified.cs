//HintName: test_Dual_Enc.gen.cs
// Generated from {CurrentDirectory}Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_Dual;

internal class test_DualFieldEncoder(
  IEncoderRepository encoders
) : IEncoder<Itest_DualFieldObject>
{
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjFieldObject<Itest_ObjFieldType> = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_DualFieldObject input)
    => _itest_ObjFieldObject<Itest_ObjFieldType>.Encode(input);
}
