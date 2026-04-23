//HintName: test_parent-dual+Output_Enc.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

internal class testPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualOutpObject>
{
  private readonly IEncoder<ItestRefPrntDualOutpObject> _itestRefPrntDualOutp = encoders.EncoderFor<ItestRefPrntDualOutpObject>();
  public Structured Encode(ItestPrntDualOutpObject input)
    => _itestRefPrntDualOutp.Encode(input);

  internal static testPrntDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualOutpEncoder : IEncoder<ItestRefPrntDualOutpObject>
{
  public Structured Encode(ItestRefPrntDualOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_dual_OutputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_dual_OutputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntDualOutpObject>(testPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntDualOutpObject>(testRefPrntDualOutpEncoder.Factory);
}
