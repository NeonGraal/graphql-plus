//HintName: test_+Globals_Enc.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

internal class testCtgrDscrsEncoder : IEncoder<ItestCtgrDscrsObject>
{
  public IGqlpValue Encode(ItestCtgrDscrsObject input)
    => new GqlpUnit();

  internal static testCtgrDscrsEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpEncoder : IEncoder<ItestCtgrOutpObject>
{
  public IGqlpValue Encode(ItestCtgrOutpObject input)
    => new GqlpUnit();

  internal static testCtgrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpDescrEncoder : IEncoder<ItestCtgrOutpDescrObject>
{
  public IGqlpValue Encode(ItestCtgrOutpDescrObject input)
    => new GqlpUnit();

  internal static testCtgrOutpDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpDictEncoder : IEncoder<ItestCtgrOutpDictObject>
{
  public IGqlpValue Encode(ItestCtgrOutpDictObject input)
    => new GqlpUnit();

  internal static testCtgrOutpDictEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpListEncoder : IEncoder<ItestCtgrOutpListObject>
{
  public IGqlpValue Encode(ItestCtgrOutpListObject input)
    => new GqlpUnit();

  internal static testCtgrOutpListEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrOutpOptlEncoder : IEncoder<ItestCtgrOutpOptlObject>
{
  public IGqlpValue Encode(ItestCtgrOutpOptlObject input)
    => new GqlpUnit();

  internal static testCtgrOutpOptlEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrEncoder : IEncoder<ItestDescrObject>
{
  public IGqlpValue Encode(ItestDescrObject input)
    => new GqlpUnit();

  internal static testDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrBcksEncoder : IEncoder<ItestDescrBcksObject>
{
  public IGqlpValue Encode(ItestDescrBcksObject input)
    => new GqlpUnit();

  internal static testDescrBcksEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrBtwnEncoder : IEncoder<ItestDescrBtwnObject>
{
  public IGqlpValue Encode(ItestDescrBtwnObject input)
    => new GqlpUnit();

  internal static testDescrBtwnEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrCmplEncoder : IEncoder<ItestDescrCmplObject>
{
  public IGqlpValue Encode(ItestDescrCmplObject input)
    => new GqlpUnit();

  internal static testDescrCmplEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrDblEncoder : IEncoder<ItestDescrDblObject>
{
  public IGqlpValue Encode(ItestDescrDblObject input)
    => new GqlpUnit();

  internal static testDescrDblEncoder Factory(IEncoderRepository _) => new();
}

internal class testDescrSnglEncoder : IEncoder<ItestDescrSnglObject>
{
  public IGqlpValue Encode(ItestDescrSnglObject input)
    => new GqlpUnit();

  internal static testDescrSnglEncoder Factory(IEncoderRepository _) => new();
}

internal class testDscrsEncoder : IEncoder<ItestDscrsObject>
{
  public IGqlpValue Encode(ItestDscrsObject input)
    => new GqlpUnit();

  internal static testDscrsEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamDictEncoder : IEncoder<ItestInDrctParamDictObject>
{
  public IGqlpValue Encode(ItestInDrctParamDictObject input)
    => new GqlpUnit();

  internal static testInDrctParamDictEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamInEncoder : IEncoder<ItestInDrctParamInObject>
{
  public IGqlpValue Encode(ItestInDrctParamInObject input)
    => new GqlpUnit();

  internal static testInDrctParamInEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamListEncoder : IEncoder<ItestInDrctParamListObject>
{
  public IGqlpValue Encode(ItestInDrctParamListObject input)
    => new GqlpUnit();

  internal static testInDrctParamListEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamOptEncoder : IEncoder<ItestInDrctParamOptObject>
{
  public IGqlpValue Encode(ItestInDrctParamOptObject input)
    => new GqlpUnit();

  internal static testInDrctParamOptEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprCtgrEncoder : IEncoder<ItestCatOprCtgrObject>
{
  public IGqlpValue Encode(ItestCatOprCtgrObject input)
    => new GqlpUnit();

  internal static testCatOprCtgrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnEncoder : IEncoder<ItestCatOprDmnObject>
{
  public IGqlpValue Encode(ItestCatOprDmnObject input)
    => new GqlpUnit();

  internal static testCatOprDmnEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnArgEncoder : IEncoder<ItestCatOprDmnArgObject>
{
  public IGqlpValue Encode(ItestCatOprDmnArgObject input)
    => new GqlpUnit();

  internal static testCatOprDmnArgEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnModsEncoder : IEncoder<ItestCatOprDmnModsObject>
{
  public IGqlpValue Encode(ItestCatOprDmnModsObject input)
    => new GqlpUnit();

  internal static testCatOprDmnModsEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprDmnVarEncoder : IEncoder<ItestCatOprDmnVarObject>
{
  public IGqlpValue Encode(ItestCatOprDmnVarObject input)
    => new GqlpUnit();

  internal static testCatOprDmnVarEncoder Factory(IEncoderRepository _) => new();
}

internal class testCatOprSlctEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCatOprSlctObject>
{
  private readonly Encoder<ItestAddrOprSlct> _itestAddrOprSlct = encoders.EncoderFor<ItestAddrOprSlct>();
  public IGqlpValue Encode(ItestCatOprSlctObject input)
    => new GqlpUnit()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlct);

  internal static testCatOprSlctEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctEncoder : IEncoder<ItestAddrOprSlctObject>
{
  public IGqlpValue Encode(ItestAddrOprSlctObject input)
    => new GqlpUnit()
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
  public IGqlpValue Encode(ItestCatOprSlctInlnObject input)
    => new GqlpUnit()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlctInln);

  internal static testCatOprSlctInlnEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctInlnEncoder : IEncoder<ItestAddrOprSlctInlnObject>
{
  public IGqlpValue Encode(ItestAddrOprSlctInlnObject input)
    => new GqlpUnit();

  internal static testAddrOprSlctInlnEncoder Factory(IEncoderRepository _) => new();
}

internal class testFullOprSlctInlnEncoder : IEncoder<ItestFullOprSlctInlnObject>
{
  public IGqlpValue Encode(ItestFullOprSlctInlnObject input)
    => new GqlpUnit()
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
  public IGqlpValue Encode(ItestCatOprSlctModsObject input)
    => new GqlpUnit()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlctMods);

  internal static testCatOprSlctModsEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctModsEncoder : IEncoder<ItestAddrOprSlctModsObject>
{
  public IGqlpValue Encode(ItestAddrOprSlctModsObject input)
    => new GqlpUnit()
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
  public IGqlpValue Encode(ItestCatOprSlctSprdObject input)
    => new GqlpUnit()
      .Add("first", input.First.Encode())
      .Add("last", input.Last.Encode())
      .AddEncoded("address", input.Address, _itestAddrOprSlctSprd);

  internal static testCatOprSlctSprdEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAddrOprSlctSprdEncoder : IEncoder<ItestAddrOprSlctSprdObject>
{
  public IGqlpValue Encode(ItestAddrOprSlctSprdObject input)
    => new GqlpUnit()
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
      .AddEncoder<ItestInDrctParamDictObject>(testInDrctParamDictEncoder.Factory)
      .AddEncoder<ItestInDrctParamInObject>(testInDrctParamInEncoder.Factory)
      .AddEncoder<ItestInDrctParamListObject>(testInDrctParamListEncoder.Factory)
      .AddEncoder<ItestInDrctParamOptObject>(testInDrctParamOptEncoder.Factory)
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
