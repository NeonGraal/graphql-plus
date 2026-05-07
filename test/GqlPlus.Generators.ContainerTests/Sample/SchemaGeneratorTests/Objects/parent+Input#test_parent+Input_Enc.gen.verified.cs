//HintName: test_parent+Input_Enc.gen.cs
// Generated from {CurrentDirectory}parent+Input.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_Input;

internal class testPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntInpObject>
{
  private readonly IEncoder<ItestRefPrntInpObject> _itestRefPrntInp = encoders.EncoderFor<ItestRefPrntInpObject>();
  public Structured Encode(ItestPrntInpObject input)
    => _itestRefPrntInp.Encode(input);

  internal static testPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntInpEncoder : IEncoder<ItestRefPrntInpObject>
{
  public Structured Encode(ItestRefPrntInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_InputEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_InputEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntInpObject>(testPrntInpEncoder.Factory)
      .AddEncoder<ItestRefPrntInpObject>(testRefPrntInpEncoder.Factory);
}
