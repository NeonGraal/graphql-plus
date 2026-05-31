//HintName: test_operation-selection-mods_Enc.gen.cs
// Generated from {CurrentDirectory}operation-selection-mods.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_operation_selection_mods;

internal class testCatOprSlctModsEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprSlctModsObject>
{
  private readonly Encoder<ItestAddrOprSlctMods> _itestAddrOprSlctMods = encoders.EncoderFor<ItestAddrOprSlctMods>();
  public Structured Encode(ItestCatOprSlctModsObject input)
    => Structured.Empty()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlctMods);

  internal static testCatOprSlctModsEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctModsEncoder : IEncoder<ItestAddrOprSlctModsObject>
{
  public Structured Encode(ItestAddrOprSlctModsObject input)
    => Structured.Empty()
      .Add("street", input.Street.Encode())
      .Add("city", input.City.Encode())
      .Add("country", input.Country.Encode());

  internal static testAddrOprSlctModsEncoder Factory(IEncoderRepository _) => new();
}

internal static class test_operation_selection_modsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest_operation_selection_modsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCatOprSlctModsObject>(testCatOprSlctModsEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctModsObject>(testAddrOprSlctModsEncoder.Factory);
}
