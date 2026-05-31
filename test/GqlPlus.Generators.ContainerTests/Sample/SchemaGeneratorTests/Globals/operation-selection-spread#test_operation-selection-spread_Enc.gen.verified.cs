//HintName: test_operation-selection-spread_Enc.gen.cs
// Generated from {CurrentDirectory}operation-selection-spread.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_spread;

internal class testCatOprSlctSprdEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprSlctSprdObject>
{
  private readonly Encoder<ItestAddrOprSlctSprd> _itestAddrOprSlctSprd = encoders.EncoderFor<ItestAddrOprSlctSprd>();
  public Structured Encode(ItestCatOprSlctSprdObject input)
    => Structured.Empty()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlctSprd);

  internal static testCatOprSlctSprdEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctSprdEncoder : IEncoder<ItestAddrOprSlctSprdObject>
{
  public Structured Encode(ItestAddrOprSlctSprdObject input)
    => Structured.Empty()
      .Add("street", input.Street.Encode())
      .Add("city", input.City.Encode())
      .Add("country", input.Country.Encode());

  internal static testAddrOprSlctSprdEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_selection_spreadEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_selection_spreadEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprSlctSprdObject>(testCatOprSlctSprdEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctSprdObject>(testAddrOprSlctSprdEncoder.Factory);
}
