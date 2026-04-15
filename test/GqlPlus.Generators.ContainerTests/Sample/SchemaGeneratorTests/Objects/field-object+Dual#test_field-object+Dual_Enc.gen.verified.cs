//HintName: test_field-object+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-object+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_object_Dual;

internal class testFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjDualObject>
{
  private readonly IEncoder<ItestFldFieldObjDual> _itestFldFieldObjDual = encoders.EncoderFor<ItestFldFieldObjDual>();
  public Structured Encode(ItestFieldObjDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjDual);

  internal static testFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjDualEncoder : IEncoder<ItestFldFieldObjDualObject>
{
  public Structured Encode(ItestFldFieldObjDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFldFieldObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_field_object_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_object_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldObjDualObject>(testFieldObjDualEncoder.Factory)
      .AddEncoder<ItestFldFieldObjDualObject>(testFldFieldObjDualEncoder.Factory);
}
