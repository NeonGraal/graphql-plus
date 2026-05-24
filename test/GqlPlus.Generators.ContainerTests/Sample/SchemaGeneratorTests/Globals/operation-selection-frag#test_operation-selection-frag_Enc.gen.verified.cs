//HintName: test_operation-selection-frag_Enc.gen.cs
// Generated from {CurrentDirectory}operation-selection-frag.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_frag;

internal class testCatOprSlctFragEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprSlctFragObject>
{
  private readonly Encoder<ItestAddrOprSlctFrag> _itestAddrOprSlctFrag = encoders.EncoderFor<ItestAddrOprSlctFrag>();
  public Structured Encode(ItestCatOprSlctFragObject input)
    => Structured.Empty()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlctFrag);

  internal static testCatOprSlctFragEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctFragEncoder : IEncoder<ItestAddrOprSlctFragObject>
{
  public Structured Encode(ItestAddrOprSlctFragObject input)
    => Structured.Empty()
      .Add("street", input.Street.Encode())
      .Add("city", input.City.Encode())
      .Add("country", input.Country.Encode());

  internal static testAddrOprSlctFragEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_selection_fragEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_selection_fragEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprSlctFragObject>(testCatOprSlctFragEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctFragObject>(testAddrOprSlctFragEncoder.Factory);
}
