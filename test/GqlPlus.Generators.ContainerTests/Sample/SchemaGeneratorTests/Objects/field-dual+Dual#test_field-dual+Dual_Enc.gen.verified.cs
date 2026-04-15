//HintName: test_field-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}field-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_field_dual_Dual;

internal class testFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualDualObject>
{
  private readonly IEncoder<ItestFldFieldDualDual> _itestFldFieldDualDual = encoders.EncoderFor<ItestFldFieldDualDual>();
  public Structured Encode(ItestFieldDualDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualDual);
}

internal class testFldFieldDualDualEncoder : IEncoder<ItestFldFieldDualDualObject>
{
  public Structured Encode(ItestFldFieldDualDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal static class test_field_dual_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_field_dual_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestFieldDualDualObject>(r => new testFieldDualDualEncoder(r))
      .AddEncoder<ItestFldFieldDualDualObject>(_ => new testFldFieldDualDualEncoder());
}
