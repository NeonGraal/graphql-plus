//HintName: test_parent-alt+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent-alt+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_alt_Input;

internal class testPrntAltInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltInpObject>
{
  private readonly IEncoder<ItestRefPrntAltInpObject> _itestRefPrntAltInp = encoders.EncoderFor<ItestRefPrntAltInpObject>();
  public Structured Encode(ItestPrntAltInpObject input)
    => _itestRefPrntAltInp.Encode(input);

  internal static testPrntAltInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltInpEncoder : IEncoder<ItestRefPrntAltInpObject>
{
  public Structured Encode(ItestRefPrntAltInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_alt_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_alt_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntAltInpObject>(testPrntAltInpEncoder.Factory)
      .AddEncoder<ItestRefPrntAltInpObject>(testRefPrntAltInpEncoder.Factory);
}
