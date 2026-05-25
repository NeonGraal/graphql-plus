//HintName: test_+Globals_Enc.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testCtgrDscrsEncoder : IEncoder<ItestCtgrDscrsObject>
{
  public Structured Encode(ItestCtgrDscrsObject input)
    => Structured.Empty();

  internal static testCtgrDscrsEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpEncoder : IEncoder<ItestCtgrOutpObject>
{
  public Structured Encode(ItestCtgrOutpObject input)
    => Structured.Empty();

  internal static testCtgrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpDescrEncoder : IEncoder<ItestCtgrOutpDescrObject>
{
  public Structured Encode(ItestCtgrOutpDescrObject input)
    => Structured.Empty();

  internal static testCtgrOutpDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpDictEncoder : IEncoder<ItestCtgrOutpDictObject>
{
  public Structured Encode(ItestCtgrOutpDictObject input)
    => Structured.Empty();

  internal static testCtgrOutpDictEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpListEncoder : IEncoder<ItestCtgrOutpListObject>
{
  public Structured Encode(ItestCtgrOutpListObject input)
    => Structured.Empty();

  internal static testCtgrOutpListEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpOptlEncoder : IEncoder<ItestCtgrOutpOptlObject>
{
  public Structured Encode(ItestCtgrOutpOptlObject input)
    => Structured.Empty();

  internal static testCtgrOutpOptlEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrEncoder : IEncoder<ItestDescrObject>
{
  public Structured Encode(ItestDescrObject input)
    => Structured.Empty();

  internal static testDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrBcksEncoder : IEncoder<ItestDescrBcksObject>
{
  public Structured Encode(ItestDescrBcksObject input)
    => Structured.Empty();

  internal static testDescrBcksEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrBtwnEncoder : IEncoder<ItestDescrBtwnObject>
{
  public Structured Encode(ItestDescrBtwnObject input)
    => Structured.Empty();

  internal static testDescrBtwnEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrCmplEncoder : IEncoder<ItestDescrCmplObject>
{
  public Structured Encode(ItestDescrCmplObject input)
    => Structured.Empty();

  internal static testDescrCmplEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrDblEncoder : IEncoder<ItestDescrDblObject>
{
  public Structured Encode(ItestDescrDblObject input)
    => Structured.Empty();

  internal static testDescrDblEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrSnglEncoder : IEncoder<ItestDescrSnglObject>
{
  public Structured Encode(ItestDescrSnglObject input)
    => Structured.Empty();

  internal static testDescrSnglEncoder Factory(IEncoderRepository _) => new();
}

internal class testDscrsEncoder : IEncoder<ItestDscrsObject>
{
  public Structured Encode(ItestDscrsObject input)
    => Structured.Empty();

  internal static testDscrsEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprCtgrEncoder : IEncoder<ItestCatOprCtgrObject>
{
  public Structured Encode(ItestCatOprCtgrObject input)
    => Structured.Empty();

  internal static testCatOprCtgrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnEncoder : IEncoder<ItestCatOprDmnObject>
{
  public Structured Encode(ItestCatOprDmnObject input)
    => Structured.Empty();

  internal static testCatOprDmnEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnArgEncoder : IEncoder<ItestCatOprDmnArgObject>
{
  public Structured Encode(ItestCatOprDmnArgObject input)
    => Structured.Empty();

  internal static testCatOprDmnArgEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnModsEncoder : IEncoder<ItestCatOprDmnModsObject>
{
  public Structured Encode(ItestCatOprDmnModsObject input)
    => Structured.Empty();

  internal static testCatOprDmnModsEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnVarEncoder : IEncoder<ItestCatOprDmnVarObject>
{
  public Structured Encode(ItestCatOprDmnVarObject input)
    => Structured.Empty();

  internal static testCatOprDmnVarEncoder Factory(IEncoderRepository _) => new();
}

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

internal static class test__GlobalsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__GlobalsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrDscrsObject>(testCtgrDscrsEncoder.Factory)
      .AddEncoder<ItestCtgrOutpObject>(testCtgrOutpEncoder.Factory)
      .AddEncoder<ItestCtgrOutpDescrObject>(testCtgrOutpDescrEncoder.Factory)
      .AddEncoder<ItestCtgrOutpDictObject>(testCtgrOutpDictEncoder.Factory)
      .AddEncoder<ItestCtgrOutpListObject>(testCtgrOutpListEncoder.Factory)
      .AddEncoder<ItestCtgrOutpOptlObject>(testCtgrOutpOptlEncoder.Factory)
      .AddEncoder<ItestDescrObject>(testDescrEncoder.Factory)
      .AddEncoder<ItestDescrBcksObject>(testDescrBcksEncoder.Factory)
      .AddEncoder<ItestDescrBtwnObject>(testDescrBtwnEncoder.Factory)
      .AddEncoder<ItestDescrCmplObject>(testDescrCmplEncoder.Factory)
      .AddEncoder<ItestDescrDblObject>(testDescrDblEncoder.Factory)
      .AddEncoder<ItestDescrSnglObject>(testDescrSnglEncoder.Factory)
      .AddEncoder<ItestDscrsObject>(testDscrsEncoder.Factory)
      .AddEncoder<ItestCatOprCtgrObject>(testCatOprCtgrEncoder.Factory)
      .AddEncoder<ItestCatOprDmnObject>(testCatOprDmnEncoder.Factory)
      .AddEncoder<ItestCatOprDmnArgObject>(testCatOprDmnArgEncoder.Factory)
      .AddEncoder<ItestCatOprDmnModsObject>(testCatOprDmnModsEncoder.Factory)
      .AddEncoder<ItestCatOprDmnVarObject>(testCatOprDmnVarEncoder.Factory)
      .AddEncoder<ItestCatOprSlctObject>(testCatOprSlctEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctObject>(testAddrOprSlctEncoder.Factory)
      .AddEncoder<ItestCatOprSlctInlnObject>(testCatOprSlctInlnEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctInlnObject>(testAddrOprSlctInlnEncoder.Factory)
      .AddEncoder<ItestFullOprSlctInlnObject>(testFullOprSlctInlnEncoder.Factory)
      .AddEncoder<ItestCatOprSlctModsObject>(testCatOprSlctModsEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctModsObject>(testAddrOprSlctModsEncoder.Factory)
      .AddEncoder<ItestCatOprSlctSprdObject>(testCatOprSlctSprdEncoder.Factory)
      .AddEncoder<ItestAddrOprSlctSprdObject>(testAddrOprSlctSprdEncoder.Factory);
}
