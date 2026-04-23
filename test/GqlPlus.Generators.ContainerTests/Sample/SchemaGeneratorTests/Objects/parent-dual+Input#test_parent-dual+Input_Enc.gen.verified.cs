//HintName: test_parent-dual+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

internal class testPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualInpObject>
{
  private readonly IEncoder<ItestRefPrntDualInpObject> _itestRefPrntDualInp = encoders.EncoderFor<ItestRefPrntDualInpObject>();
  public Structured Encode(ItestPrntDualInpObject input)
    => _itestRefPrntDualInp.Encode(input);

  internal static testPrntDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualInpEncoder : IEncoder<ItestRefPrntDualInpObject>
{
  public Structured Encode(ItestRefPrntDualInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_dual_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_dual_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntDualInpObject>(testPrntDualInpEncoder.Factory)
      .AddEncoder<ItestRefPrntDualInpObject>(testRefPrntDualInpEncoder.Factory);
}
