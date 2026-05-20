//HintName: test_operation-selection-mods_Enc.gen.cs
// Generated from {CurrentDirectory}operation-selection-mods.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_mods;

internal class testCatOprSelectionModsEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprSelectionModsObject>
{
  private readonly Encoder<ItestAddrOprSelectionMods> _itestAddrOprSelectionMods = encoders.EncoderFor<ItestAddrOprSelectionMods>();
  public Structured Encode(ItestCatOprSelectionModsObject input)
    => Structured.Empty()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSelectionMods);

  internal static testCatOprSelectionModsEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSelectionModsEncoder : IEncoder<ItestAddrOprSelectionModsObject>
{
  public Structured Encode(ItestAddrOprSelectionModsObject input)
    => Structured.Empty()
      .Add("street", input.Street.Encode())
      .Add("city", input.City.Encode())
      .Add("country", input.Country.Encode());

  internal static testAddrOprSelectionModsEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_selection_modsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_selection_modsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprSelectionModsObject>(testCatOprSelectionModsEncoder.Factory)
      .AddEncoder<ItestAddrOprSelectionModsObject>(testAddrOprSelectionModsEncoder.Factory);
}
