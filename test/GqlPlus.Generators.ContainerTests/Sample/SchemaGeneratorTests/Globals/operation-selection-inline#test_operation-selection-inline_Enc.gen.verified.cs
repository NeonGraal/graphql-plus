//HintName: test_operation-selection-inline_Enc.gen.cs
// Generated from {CurrentDirectory}operation-selection-inline.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_inline;

internal class testCatOprSlctInlnEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprSlctInlnObject>
{
  private readonly Encoder<ItestAddrOprSlctInln> _itestAddrOprSlctInln = encoders.EncoderFor<ItestAddrOprSlctInln>();
  public Structured Encode(ItestCatOprSlctInlnObject input)
    => Structured.Empty()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlctInln);

  internal static testCatOprSlctInlnEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctInlnEncoder : IEncoder<ItestAddrOprSlctInlnObject>
{
  public Structured Encode(ItestAddrOprSlctInlnObject input)
    => Structured.Empty();

  internal static testAddrOprSlctInlnEncoder Factory(IEncoderRepository _) => new();
}

internal class testFullOprSlctInlnEncoder : IEncoder<ItestFullOprSlctInlnObject>
{
  public Structured Encode(ItestFullOprSlctInlnObject input)
    => Structured.Empty()
      .Add("street", input.Street.Encode())
      .Add("city", input.City.Encode())
      .Add("country", input.Country.Encode());

  internal static testFullOprSlctInlnEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_selection_inlineEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_selection_inlineEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprSlctInlnObject>(testCatOprSlctInlnEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctInlnObject>(testAddrOprSlctInlnEncoder.Factory)
      .AddEncoder<ItestFullOprSlctInlnObject>(testFullOprSlctInlnEncoder.Factory);
}
