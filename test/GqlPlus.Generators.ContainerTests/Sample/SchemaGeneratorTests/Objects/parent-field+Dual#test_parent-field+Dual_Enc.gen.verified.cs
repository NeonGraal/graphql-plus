//HintName: test_parent-field+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-field+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Dual;

internal class testPrntFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldDualObject>
{
  private readonly IEncoder<ItestRefPrntFieldDualObject> _itestRefPrntFieldDual = encoders.EncoderFor<ItestRefPrntFieldDualObject>();
  public Structured Encode(ItestPrntFieldDualObject input)
    => _itestRefPrntFieldDual.Encode(input)
      .Add("field", input.Field);

  internal static testPrntFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldDualEncoder : IEncoder<ItestRefPrntFieldDualObject>
{
  public Structured Encode(ItestRefPrntFieldDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

  internal static testRefPrntFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_field_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_field_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntFieldDualObject>(testPrntFieldDualEncoder.Factory)
      .AddEncoder<ItestRefPrntFieldDualObject>(testRefPrntFieldDualEncoder.Factory);
}
