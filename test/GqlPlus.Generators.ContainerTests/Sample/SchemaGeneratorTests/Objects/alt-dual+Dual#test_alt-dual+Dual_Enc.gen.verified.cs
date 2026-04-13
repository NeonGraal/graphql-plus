//HintName: test_alt-dual+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}alt-dual+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Dual;

internal class testAltDualDualEncoder : IEncoder<ItestAltDualDualObject>
{
  public Structured Encode(ItestAltDualDualObject input)
    => Structured.Empty();
}

internal class testObjDualAltDualDualEncoder : IEncoder<ItestObjDualAltDualDualObject>
{
  public Structured Encode(ItestObjDualAltDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}
