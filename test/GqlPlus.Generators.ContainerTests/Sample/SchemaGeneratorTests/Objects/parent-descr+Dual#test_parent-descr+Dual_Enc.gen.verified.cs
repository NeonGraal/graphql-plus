//HintName: test_parent-descr+Dual_Enc.gen.cs
// Generated from {CurrentDirectory}parent-descr+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_descr_Dual;

internal class testPrntDescrDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrDualObject>
{
  private readonly IEncoder<ItestRefPrntDescrDualObject> _itestRefPrntDescrDual = encoders.EncoderFor<ItestRefPrntDescrDualObject>();
  public Structured Encode(ItestPrntDescrDualObject input)
    => _itestRefPrntDescrDual.Encode(input);

  internal static testPrntDescrDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDescrDualEncoder : IEncoder<ItestRefPrntDescrDualObject>
{
  public Structured Encode(ItestRefPrntDescrDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

  internal static testRefPrntDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_parent_descr_DualEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_parent_descr_DualEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestPrntDescrDualObject>(testPrntDescrDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDescrDualObject>(testRefPrntDescrDualEncoder.Factory);
}
