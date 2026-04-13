//HintName: test_parent-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Dual;

internal class testPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualDualObject>
{
  private readonly IEncoder<ItestRefPrntDualDualObject> _itestRefPrntDualDual = encoders.EncoderFor<ItestRefPrntDualDualObject>();
  public Structured Encode(ItestPrntDualDualObject input)
    => _itestRefPrntDualDual.Encode(input);
}

internal class testRefPrntDualDualEncoder : IEncoder<ItestRefPrntDualDualObject>
{
  public Structured Encode(ItestRefPrntDualDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}
