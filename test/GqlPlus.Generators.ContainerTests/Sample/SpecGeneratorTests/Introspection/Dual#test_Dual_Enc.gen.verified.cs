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
  private readonly IEncoder<Itest_ObjFieldObject<Itest_ObjFieldType>> _itest_ObjField = encoders.EncoderFor<Itest_ObjFieldObject<Itest_ObjFieldType>>();
  public Structured Encode(Itest_DualFieldObject input)
    => _itest_ObjField.Encode(input);

  internal static test_DualFieldEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<Itest_DualFieldObject>(test_DualFieldEncoder.Factory);
}
