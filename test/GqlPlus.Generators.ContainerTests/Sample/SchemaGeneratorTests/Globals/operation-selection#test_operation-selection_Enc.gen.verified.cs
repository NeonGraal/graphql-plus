//HintName: test_operation-selection_Enc.gen.cs
// Generated from {CurrentDirectory}operation-selection.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection;

internal class testCatOprSlctEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprSlctObject>
{
  private readonly Encoder<ItestAddrOprSlct> _itestAddrOprSlct = encoders.EncoderFor<ItestAddrOprSlct>();
  public Structured Encode(ItestCatOprSlctObject input)
    => Structured.Empty()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlct);

  internal static testCatOprSlctEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctEncoder : IEncoder<ItestAddrOprSlctObject>
{
  public Structured Encode(ItestAddrOprSlctObject input)
    => Structured.Empty()
      .Add("street", input.Street.Encode())
      .Add("city", input.City.Encode())
      .Add("country", input.Country.Encode());

  internal static testAddrOprSlctEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_selectionEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_selectionEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprSlctObject>(testCatOprSlctEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctObject>(testAddrOprSlctEncoder.Factory);
}
