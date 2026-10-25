//HintName: test_-ALL_Enc.gen.cs
// Generated from {CurrentDirectory}-ALL.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__ALL;

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

internal class testAltDualEncoder : IEncoder<ItestAltDualObject>
{
  public IGqlpValue Encode(ItestAltDualObject input)
    => new GqlpUnit();

  internal static testAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltDualEncoder : IEncoder<ItestAltAltDualObject>
{
  public IGqlpValue Encode(ItestAltAltDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltInpEncoder : IEncoder<ItestAltInpObject>
{
  public IGqlpValue Encode(ItestAltInpObject input)
    => new GqlpUnit();

  internal static testAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltInpEncoder : IEncoder<ItestAltAltInpObject>
{
  public IGqlpValue Encode(ItestAltAltInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltOutpEncoder : IEncoder<ItestAltOutpObject>
{
  public IGqlpValue Encode(ItestAltOutpObject input)
    => new GqlpUnit();

  internal static testAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltOutpEncoder : IEncoder<ItestAltAltOutpObject>
{
  public IGqlpValue Encode(ItestAltAltOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDescrDualEncoder : IEncoder<ItestAltDescrDualObject>
{
  public IGqlpValue Encode(ItestAltDescrDualObject input)
    => new GqlpUnit();

  internal static testAltDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDescrInpEncoder : IEncoder<ItestAltDescrInpObject>
{
  public IGqlpValue Encode(ItestAltDescrInpObject input)
    => new GqlpUnit();

  internal static testAltDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDescrOutpEncoder : IEncoder<ItestAltDescrOutpObject>
{
  public IGqlpValue Encode(ItestAltDescrOutpObject input)
    => new GqlpUnit();

  internal static testAltDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDualDualEncoder : IEncoder<ItestAltDualDualObject>
{
  public IGqlpValue Encode(ItestAltDualDualObject input)
    => new GqlpUnit();

  internal static testAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualDualEncoder : IEncoder<ItestObjDualAltDualDualObject>
{
  public IGqlpValue Encode(ItestObjDualAltDualDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDualInpEncoder : IEncoder<ItestAltDualInpObject>
{
  public IGqlpValue Encode(ItestAltDualInpObject input)
    => new GqlpUnit();

  internal static testAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualInpEncoder : IEncoder<ItestObjDualAltDualInpObject>
{
  public IGqlpValue Encode(ItestObjDualAltDualInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDualOutpEncoder : IEncoder<ItestAltDualOutpObject>
{
  public IGqlpValue Encode(ItestAltDualOutpObject input)
    => new GqlpUnit();

  internal static testAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualOutpEncoder : IEncoder<ItestObjDualAltDualOutpObject>
{
  public IGqlpValue Encode(ItestObjDualAltDualOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltEnumDualEncoder : IEncoder<ItestAltEnumDualObject>
{
  public IGqlpValue Encode(ItestAltEnumDualObject input)
    => new GqlpUnit();

  internal static testAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumDualEncoder : IEncoder<testEnumAltEnumDual>
{
  public IGqlpValue Encode(testEnumAltEnumDual input)
    => input.EncodeEnum("EnumAltEnumDual");

  internal static testEnumAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltEnumInpEncoder : IEncoder<ItestAltEnumInpObject>
{
  public IGqlpValue Encode(ItestAltEnumInpObject input)
    => new GqlpUnit();

  internal static testAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumInpEncoder : IEncoder<testEnumAltEnumInp>
{
  public IGqlpValue Encode(testEnumAltEnumInp input)
    => input.EncodeEnum("EnumAltEnumInp");

  internal static testEnumAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltEnumOutpEncoder : IEncoder<ItestAltEnumOutpObject>
{
  public IGqlpValue Encode(ItestAltEnumOutpObject input)
    => new GqlpUnit();

  internal static testAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumOutpEncoder : IEncoder<testEnumAltEnumOutp>
{
  public IGqlpValue Encode(testEnumAltEnumOutp input)
    => input.EncodeEnum("EnumAltEnumOutp");

  internal static testEnumAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModBoolDualEncoder : IEncoder<ItestAltModBoolDualObject>
{
  public IGqlpValue Encode(ItestAltModBoolDualObject input)
    => new GqlpUnit();

  internal static testAltModBoolDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolDualEncoder : IEncoder<ItestAltAltModBoolDualObject>
{
  public IGqlpValue Encode(ItestAltAltModBoolDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModBoolInpEncoder : IEncoder<ItestAltModBoolInpObject>
{
  public IGqlpValue Encode(ItestAltModBoolInpObject input)
    => new GqlpUnit();

  internal static testAltModBoolInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolInpEncoder : IEncoder<ItestAltAltModBoolInpObject>
{
  public IGqlpValue Encode(ItestAltAltModBoolInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModBoolOutpEncoder : IEncoder<ItestAltModBoolOutpObject>
{
  public IGqlpValue Encode(ItestAltModBoolOutpObject input)
    => new GqlpUnit();

  internal static testAltModBoolOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolOutpEncoder : IEncoder<ItestAltAltModBoolOutpObject>
{
  public IGqlpValue Encode(ItestAltAltModBoolOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModParamDualEncoder<TMod> : IEncoder<ItestAltModParamDualObject<TMod>>
{
  public IGqlpValue Encode(ItestAltModParamDualObject<TMod> input)
    => new GqlpUnit();
}

internal class testAltAltModParamDualEncoder : IEncoder<ItestAltAltModParamDualObject>
{
  public IGqlpValue Encode(ItestAltAltModParamDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModParamInpEncoder<TMod> : IEncoder<ItestAltModParamInpObject<TMod>>
{
  public IGqlpValue Encode(ItestAltModParamInpObject<TMod> input)
    => new GqlpUnit();
}

internal class testAltAltModParamInpEncoder : IEncoder<ItestAltAltModParamInpObject>
{
  public IGqlpValue Encode(ItestAltAltModParamInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModParamOutpEncoder<TMod> : IEncoder<ItestAltModParamOutpObject<TMod>>
{
  public IGqlpValue Encode(ItestAltModParamOutpObject<TMod> input)
    => new GqlpUnit();
}

internal class testAltAltModParamOutpEncoder : IEncoder<ItestAltAltModParamOutpObject>
{
  public IGqlpValue Encode(ItestAltAltModParamOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltSmplDualEncoder : IEncoder<ItestAltSmplDualObject>
{
  public IGqlpValue Encode(ItestAltSmplDualObject input)
    => new GqlpUnit();

  internal static testAltSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltSmplInpEncoder : IEncoder<ItestAltSmplInpObject>
{
  public IGqlpValue Encode(ItestAltSmplInpObject input)
    => new GqlpUnit();

  internal static testAltSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltSmplOutpEncoder : IEncoder<ItestAltSmplOutpObject>
{
  public IGqlpValue Encode(ItestAltSmplOutpObject input)
    => new GqlpUnit();

  internal static testAltSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDualEncoder<TType> : IEncoder<ItestCnstAltDualObject<TType>>
{
  public IGqlpValue Encode(ItestCnstAltDualObject<TType> input)
    => new GqlpUnit();
}

internal class testCnstAltInpEncoder<TType> : IEncoder<ItestCnstAltInpObject<TType>>
{
  public IGqlpValue Encode(ItestCnstAltInpObject<TType> input)
    => new GqlpUnit();
}

internal class testCnstAltOutpEncoder<TType> : IEncoder<ItestCnstAltOutpObject<TType>>
{
  public IGqlpValue Encode(ItestCnstAltOutpObject<TType> input)
    => new GqlpUnit();
}

internal class testCnstAltDmnDualEncoder : IEncoder<ItestCnstAltDmnDualObject>
{
  public IGqlpValue Encode(ItestCnstAltDmnDualObject input)
    => new GqlpUnit();

  internal static testCnstAltDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnDualEncoder<TRef> : IEncoder<ItestRefCnstAltDmnDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDmnDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testDomCnstAltDmnDualEncoder : IEncoder<ItestDomCnstAltDmnDual>
{
  public IGqlpValue Encode(ItestDomCnstAltDmnDual input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDmnInpEncoder : IEncoder<ItestCnstAltDmnInpObject>
{
  public IGqlpValue Encode(ItestCnstAltDmnInpObject input)
    => new GqlpUnit();

  internal static testCnstAltDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnInpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDmnInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testDomCnstAltDmnInpEncoder : IEncoder<ItestDomCnstAltDmnInp>
{
  public IGqlpValue Encode(ItestDomCnstAltDmnInp input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDmnOutpEncoder : IEncoder<ItestCnstAltDmnOutpObject>
{
  public IGqlpValue Encode(ItestCnstAltDmnOutpObject input)
    => new GqlpUnit();

  internal static testCnstAltDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDmnOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testDomCnstAltDmnOutpEncoder : IEncoder<ItestDomCnstAltDmnOutp>
{
  public IGqlpValue Encode(ItestDomCnstAltDmnOutp input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDualDualEncoder : IEncoder<ItestCnstAltDualDualObject>
{
  public IGqlpValue Encode(ItestCnstAltDualDualObject input)
    => new GqlpUnit();

  internal static testCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualDualEncoder<TRef> : IEncoder<ItestRefCnstAltDualDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDualDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltDualDualEncoder : IEncoder<ItestPrntCnstAltDualDualObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltDualDualObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualDualObject>
{
  private readonly Encoder<ItestPrntCnstAltDualDualObject> _itestPrntCnstAltDualDual = encoders.EncoderFor<ItestPrntCnstAltDualDualObject>();
  public IGqlpValue Encode(ItestAltCnstAltDualDualObject input)
    => _itestPrntCnstAltDualDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltDualInpEncoder : IEncoder<ItestCnstAltDualInpObject>
{
  public IGqlpValue Encode(ItestCnstAltDualInpObject input)
    => new GqlpUnit();

  internal static testCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualInpEncoder<TRef> : IEncoder<ItestRefCnstAltDualInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDualInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltDualInpEncoder : IEncoder<ItestPrntCnstAltDualInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltDualInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualInpObject>
{
  private readonly Encoder<ItestPrntCnstAltDualInpObject> _itestPrntCnstAltDualInp = encoders.EncoderFor<ItestPrntCnstAltDualInpObject>();
  public IGqlpValue Encode(ItestAltCnstAltDualInpObject input)
    => _itestPrntCnstAltDualInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltDualOutpEncoder : IEncoder<ItestCnstAltDualOutpObject>
{
  public IGqlpValue Encode(ItestCnstAltDualOutpObject input)
    => new GqlpUnit();

  internal static testCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDualOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltDualOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltDualOutpEncoder : IEncoder<ItestPrntCnstAltDualOutpObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltDualOutpObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualOutpObject>
{
  private readonly Encoder<ItestPrntCnstAltDualOutpObject> _itestPrntCnstAltDualOutp = encoders.EncoderFor<ItestPrntCnstAltDualOutpObject>();
  public IGqlpValue Encode(ItestAltCnstAltDualOutpObject input)
    => _itestPrntCnstAltDualOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltObjDualEncoder : IEncoder<ItestCnstAltObjDualObject>
{
  public IGqlpValue Encode(ItestCnstAltObjDualObject input)
    => new GqlpUnit();

  internal static testCnstAltObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjDualEncoder<TRef> : IEncoder<ItestRefCnstAltObjDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltObjDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltObjDualEncoder : IEncoder<ItestPrntCnstAltObjDualObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltObjDualObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjDualObject>
{
  private readonly Encoder<ItestPrntCnstAltObjDualObject> _itestPrntCnstAltObjDual = encoders.EncoderFor<ItestPrntCnstAltObjDualObject>();
  public IGqlpValue Encode(ItestAltCnstAltObjDualObject input)
    => _itestPrntCnstAltObjDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltObjInpEncoder : IEncoder<ItestCnstAltObjInpObject>
{
  public IGqlpValue Encode(ItestCnstAltObjInpObject input)
    => new GqlpUnit();

  internal static testCnstAltObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjInpEncoder<TRef> : IEncoder<ItestRefCnstAltObjInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltObjInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltObjInpEncoder : IEncoder<ItestPrntCnstAltObjInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltObjInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjInpObject>
{
  private readonly Encoder<ItestPrntCnstAltObjInpObject> _itestPrntCnstAltObjInp = encoders.EncoderFor<ItestPrntCnstAltObjInpObject>();
  public IGqlpValue Encode(ItestAltCnstAltObjInpObject input)
    => _itestPrntCnstAltObjInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltObjOutpEncoder : IEncoder<ItestCnstAltObjOutpObject>
{
  public IGqlpValue Encode(ItestCnstAltObjOutpObject input)
    => new GqlpUnit();

  internal static testCnstAltObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjOutpEncoder<TRef> : IEncoder<ItestRefCnstAltObjOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstAltObjOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstAltObjOutpEncoder : IEncoder<ItestPrntCnstAltObjOutpObject>
{
  public IGqlpValue Encode(ItestPrntCnstAltObjOutpObject input)
    => new GqlpUnit();

  internal static testPrntCnstAltObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjOutpObject>
{
  private readonly Encoder<ItestPrntCnstAltObjOutpObject> _itestPrntCnstAltObjOutp = encoders.EncoderFor<ItestPrntCnstAltObjOutpObject>();
  public IGqlpValue Encode(ItestAltCnstAltObjOutpObject input)
    => _itestPrntCnstAltObjOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstDomEnumDualEncoder : IEncoder<ItestCnstDomEnumDualObject>
{
  public IGqlpValue Encode(ItestCnstDomEnumDualObject input)
    => new GqlpUnit();

  internal static testCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstDomEnumDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumDualEncoder : IEncoder<testEnumCnstDomEnumDual>
{
  public IGqlpValue Encode(testEnumCnstDomEnumDual input)
    => input.EncodeEnum("EnumCnstDomEnumDual");

  internal static testEnumCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumDualEncoder : IEncoder<ItestJustCnstDomEnumDual>
{
  public IGqlpValue Encode(ItestJustCnstDomEnumDual input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumDual")!;

  internal static testJustCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstDomEnumInpEncoder : IEncoder<ItestCnstDomEnumInpObject>
{
  public IGqlpValue Encode(ItestCnstDomEnumInpObject input)
    => new GqlpUnit();

  internal static testCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstDomEnumInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumInpEncoder : IEncoder<testEnumCnstDomEnumInp>
{
  public IGqlpValue Encode(testEnumCnstDomEnumInp input)
    => input.EncodeEnum("EnumCnstDomEnumInp");

  internal static testEnumCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumInpEncoder : IEncoder<ItestJustCnstDomEnumInp>
{
  public IGqlpValue Encode(ItestJustCnstDomEnumInp input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumInp")!;

  internal static testJustCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstDomEnumOutpEncoder : IEncoder<ItestCnstDomEnumOutpObject>
{
  public IGqlpValue Encode(ItestCnstDomEnumOutpObject input)
    => new GqlpUnit();

  internal static testCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstDomEnumOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumOutpEncoder : IEncoder<testEnumCnstDomEnumOutp>
{
  public IGqlpValue Encode(testEnumCnstDomEnumOutp input)
    => input.EncodeEnum("EnumCnstDomEnumOutp");

  internal static testEnumCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpEncoder : IEncoder<ItestJustCnstDomEnumOutp>
{
  public IGqlpValue Encode(ItestJustCnstDomEnumOutp input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumOutp")!;

  internal static testJustCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumDualEncoder : IEncoder<ItestCnstEnumDualObject>
{
  public IGqlpValue Encode(ItestCnstEnumDualObject input)
    => new GqlpUnit();

  internal static testCnstEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstEnumDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumDualEncoder : IEncoder<testEnumCnstEnumDual>
{
  public IGqlpValue Encode(testEnumCnstEnumDual input)
    => input.EncodeEnum("EnumCnstEnumDual");

  internal static testEnumCnstEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumInpEncoder : IEncoder<ItestCnstEnumInpObject>
{
  public IGqlpValue Encode(ItestCnstEnumInpObject input)
    => new GqlpUnit();

  internal static testCnstEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstEnumInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumInpEncoder : IEncoder<testEnumCnstEnumInp>
{
  public IGqlpValue Encode(testEnumCnstEnumInp input)
    => input.EncodeEnum("EnumCnstEnumInp");

  internal static testEnumCnstEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumOutpEncoder : IEncoder<ItestCnstEnumOutpObject>
{
  public IGqlpValue Encode(ItestCnstEnumOutpObject input)
    => new GqlpUnit();

  internal static testCnstEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstEnumOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumOutpEncoder : IEncoder<testEnumCnstEnumOutp>
{
  public IGqlpValue Encode(testEnumCnstEnumOutp input)
    => input.EncodeEnum("EnumCnstEnumOutp");

  internal static testEnumCnstEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumPrntDualEncoder : IEncoder<ItestCnstEnumPrntDualObject>
{
  public IGqlpValue Encode(ItestCnstEnumPrntDualObject input)
    => new GqlpUnit();

  internal static testCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstEnumPrntDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntDualEncoder : IEncoder<testEnumCnstEnumPrntDual>
{
  public IGqlpValue Encode(testEnumCnstEnumPrntDual input)
    => input.EncodeEnum("EnumCnstEnumPrntDual");

  internal static testEnumCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntDualEncoder : IEncoder<testParentCnstEnumPrntDual>
{
  public IGqlpValue Encode(testParentCnstEnumPrntDual input)
    => input.EncodeEnum("ParentCnstEnumPrntDual");

  internal static testParentCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumPrntInpEncoder : IEncoder<ItestCnstEnumPrntInpObject>
{
  public IGqlpValue Encode(ItestCnstEnumPrntInpObject input)
    => new GqlpUnit();

  internal static testCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstEnumPrntInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntInpEncoder : IEncoder<testEnumCnstEnumPrntInp>
{
  public IGqlpValue Encode(testEnumCnstEnumPrntInp input)
    => input.EncodeEnum("EnumCnstEnumPrntInp");

  internal static testEnumCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpEncoder : IEncoder<testParentCnstEnumPrntInp>
{
  public IGqlpValue Encode(testParentCnstEnumPrntInp input)
    => input.EncodeEnum("ParentCnstEnumPrntInp");

  internal static testParentCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumPrntOutpEncoder : IEncoder<ItestCnstEnumPrntOutpObject>
{
  public IGqlpValue Encode(ItestCnstEnumPrntOutpObject input)
    => new GqlpUnit();

  internal static testCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstEnumPrntOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntOutpEncoder : IEncoder<testEnumCnstEnumPrntOutp>
{
  public IGqlpValue Encode(testEnumCnstEnumPrntOutp input)
    => input.EncodeEnum("EnumCnstEnumPrntOutp");

  internal static testEnumCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpEncoder : IEncoder<testParentCnstEnumPrntOutp>
{
  public IGqlpValue Encode(testParentCnstEnumPrntOutp input)
    => input.EncodeEnum("ParentCnstEnumPrntOutp");

  internal static testParentCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDmnDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnDualObject>
{
  private readonly Encoder<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>> _itestRefCnstFieldDmnDual = encoders.EncoderFor<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>>();
  public IGqlpValue Encode(ItestCnstFieldDmnDualObject input)
    => _itestRefCnstFieldDmnDual.Encode(input);

  internal static testCnstFieldDmnDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDmnDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnDualEncoder : IEncoder<ItestDomCnstFieldDmnDual>
{
  public IGqlpValue Encode(ItestDomCnstFieldDmnDual input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDmnInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnInpObject>
{
  private readonly Encoder<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>> _itestRefCnstFieldDmnInp = encoders.EncoderFor<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>>();
  public IGqlpValue Encode(ItestCnstFieldDmnInpObject input)
    => _itestRefCnstFieldDmnInp.Encode(input);

  internal static testCnstFieldDmnInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDmnInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnInpEncoder : IEncoder<ItestDomCnstFieldDmnInp>
{
  public IGqlpValue Encode(ItestDomCnstFieldDmnInp input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDmnOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnOutpObject>
{
  private readonly Encoder<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>> _itestRefCnstFieldDmnOutp = encoders.EncoderFor<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>>();
  public IGqlpValue Encode(ItestCnstFieldDmnOutpObject input)
    => _itestRefCnstFieldDmnOutp.Encode(input);

  internal static testCnstFieldDmnOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDmnOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnOutpEncoder : IEncoder<ItestDomCnstFieldDmnOutp>
{
  public IGqlpValue Encode(ItestDomCnstFieldDmnOutp input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualDualObject>
{
  private readonly Encoder<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>> _itestRefCnstFieldDualDual = encoders.EncoderFor<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>>();
  public IGqlpValue Encode(ItestCnstFieldDualDualObject input)
    => _itestRefCnstFieldDualDual.Encode(input);

  internal static testCnstFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDualDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualDualEncoder : IEncoder<ItestPrntCnstFieldDualDualObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldDualDualObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualDualObject>
{
  private readonly Encoder<ItestPrntCnstFieldDualDualObject> _itestPrntCnstFieldDualDual = encoders.EncoderFor<ItestPrntCnstFieldDualDualObject>();
  public IGqlpValue Encode(ItestAltCnstFieldDualDualObject input)
    => _itestPrntCnstFieldDualDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualInpObject>
{
  private readonly Encoder<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>> _itestRefCnstFieldDualInp = encoders.EncoderFor<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>>();
  public IGqlpValue Encode(ItestCnstFieldDualInpObject input)
    => _itestRefCnstFieldDualInp.Encode(input);

  internal static testCnstFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDualInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualInpEncoder : IEncoder<ItestPrntCnstFieldDualInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldDualInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualInpObject>
{
  private readonly Encoder<ItestPrntCnstFieldDualInpObject> _itestPrntCnstFieldDualInp = encoders.EncoderFor<ItestPrntCnstFieldDualInpObject>();
  public IGqlpValue Encode(ItestAltCnstFieldDualInpObject input)
    => _itestPrntCnstFieldDualInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualOutpObject>
{
  private readonly Encoder<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>> _itestRefCnstFieldDualOutp = encoders.EncoderFor<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>>();
  public IGqlpValue Encode(ItestCnstFieldDualOutpObject input)
    => _itestRefCnstFieldDualOutp.Encode(input);

  internal static testCnstFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldDualOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualOutpEncoder : IEncoder<ItestPrntCnstFieldDualOutpObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldDualOutpObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualOutpObject>
{
  private readonly Encoder<ItestPrntCnstFieldDualOutpObject> _itestPrntCnstFieldDualOutp = encoders.EncoderFor<ItestPrntCnstFieldDualOutpObject>();
  public IGqlpValue Encode(ItestAltCnstFieldDualOutpObject input)
    => _itestPrntCnstFieldDualOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjDualObject>
{
  private readonly Encoder<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>> _itestRefCnstFieldObjDual = encoders.EncoderFor<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>>();
  public IGqlpValue Encode(ItestCnstFieldObjDualObject input)
    => _itestRefCnstFieldObjDual.Encode(input);

  internal static testCnstFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldObjDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjDualEncoder : IEncoder<ItestPrntCnstFieldObjDualObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldObjDualObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjDualObject>
{
  private readonly Encoder<ItestPrntCnstFieldObjDualObject> _itestPrntCnstFieldObjDual = encoders.EncoderFor<ItestPrntCnstFieldObjDualObject>();
  public IGqlpValue Encode(ItestAltCnstFieldObjDualObject input)
    => _itestPrntCnstFieldObjDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjInpObject>
{
  private readonly Encoder<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>> _itestRefCnstFieldObjInp = encoders.EncoderFor<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>>();
  public IGqlpValue Encode(ItestCnstFieldObjInpObject input)
    => _itestRefCnstFieldObjInp.Encode(input);

  internal static testCnstFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldObjInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjInpEncoder : IEncoder<ItestPrntCnstFieldObjInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldObjInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjInpObject>
{
  private readonly Encoder<ItestPrntCnstFieldObjInpObject> _itestPrntCnstFieldObjInp = encoders.EncoderFor<ItestPrntCnstFieldObjInpObject>();
  public IGqlpValue Encode(ItestAltCnstFieldObjInpObject input)
    => _itestPrntCnstFieldObjInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjOutpObject>
{
  private readonly Encoder<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>> _itestRefCnstFieldObjOutp = encoders.EncoderFor<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>>();
  public IGqlpValue Encode(ItestCnstFieldObjOutpObject input)
    => _itestRefCnstFieldObjOutp.Encode(input);

  internal static testCnstFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestRefCnstFieldObjOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjOutpEncoder : IEncoder<ItestPrntCnstFieldObjOutpObject>
{
  public IGqlpValue Encode(ItestPrntCnstFieldObjOutpObject input)
    => new GqlpUnit();

  internal static testPrntCnstFieldObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjOutpObject>
{
  private readonly Encoder<ItestPrntCnstFieldObjOutpObject> _itestPrntCnstFieldObjOutp = encoders.EncoderFor<ItestPrntCnstFieldObjOutpObject>();
  public IGqlpValue Encode(ItestAltCnstFieldObjOutpObject input)
    => _itestPrntCnstFieldObjOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndDualObject>
{
  private readonly Encoder<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>> _itestRefCnstPrntDualGrndDual = encoders.EncoderFor<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>>();
  public IGqlpValue Encode(ItestCnstPrntDualGrndDualObject input)
    => _itestRefCnstPrntDualGrndDual.Encode(input);

  internal static testCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndDualEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntDualGrndDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testGrndCnstPrntDualGrndDualEncoder : IEncoder<ItestGrndCnstPrntDualGrndDualObject>
{
  public IGqlpValue Encode(ItestGrndCnstPrntDualGrndDualObject input)
    => new GqlpUnit();

  internal static testGrndCnstPrntDualGrndDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndDualObject>
{
  private readonly Encoder<ItestGrndCnstPrntDualGrndDualObject> _itestGrndCnstPrntDualGrndDual = encoders.EncoderFor<ItestGrndCnstPrntDualGrndDualObject>();
  public IGqlpValue Encode(ItestPrntCnstPrntDualGrndDualObject input)
    => _itestGrndCnstPrntDualGrndDual.Encode(input);

  internal static testPrntCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndDualObject>
{
  private readonly Encoder<ItestPrntCnstPrntDualGrndDualObject> _itestPrntCnstPrntDualGrndDual = encoders.EncoderFor<ItestPrntCnstPrntDualGrndDualObject>();
  public IGqlpValue Encode(ItestAltCnstPrntDualGrndDualObject input)
    => _itestPrntCnstPrntDualGrndDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndInpObject>
{
  private readonly Encoder<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>> _itestRefCnstPrntDualGrndInp = encoders.EncoderFor<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>>();
  public IGqlpValue Encode(ItestCnstPrntDualGrndInpObject input)
    => _itestRefCnstPrntDualGrndInp.Encode(input);

  internal static testCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndInpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntDualGrndInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGrndCnstPrntDualGrndInpEncoder : IEncoder<ItestGrndCnstPrntDualGrndInpObject>
{
  public IGqlpValue Encode(ItestGrndCnstPrntDualGrndInpObject input)
    => new GqlpUnit();

  internal static testGrndCnstPrntDualGrndInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndInpObject>
{
  private readonly Encoder<ItestGrndCnstPrntDualGrndInpObject> _itestGrndCnstPrntDualGrndInp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndInpObject>();
  public IGqlpValue Encode(ItestPrntCnstPrntDualGrndInpObject input)
    => _itestGrndCnstPrntDualGrndInp.Encode(input);

  internal static testPrntCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndInpObject>
{
  private readonly Encoder<ItestPrntCnstPrntDualGrndInpObject> _itestPrntCnstPrntDualGrndInp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndInpObject>();
  public IGqlpValue Encode(ItestAltCnstPrntDualGrndInpObject input)
    => _itestPrntCnstPrntDualGrndInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndOutpObject>
{
  private readonly Encoder<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>> _itestRefCnstPrntDualGrndOutp = encoders.EncoderFor<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>>();
  public IGqlpValue Encode(ItestCnstPrntDualGrndOutpObject input)
    => _itestRefCnstPrntDualGrndOutp.Encode(input);

  internal static testCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntDualGrndOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGrndCnstPrntDualGrndOutpEncoder : IEncoder<ItestGrndCnstPrntDualGrndOutpObject>
{
  public IGqlpValue Encode(ItestGrndCnstPrntDualGrndOutpObject input)
    => new GqlpUnit();

  internal static testGrndCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndOutpObject>
{
  private readonly Encoder<ItestGrndCnstPrntDualGrndOutpObject> _itestGrndCnstPrntDualGrndOutp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndOutpObject>();
  public IGqlpValue Encode(ItestPrntCnstPrntDualGrndOutpObject input)
    => _itestGrndCnstPrntDualGrndOutp.Encode(input);

  internal static testPrntCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndOutpObject>
{
  private readonly Encoder<ItestPrntCnstPrntDualGrndOutpObject> _itestPrntCnstPrntDualGrndOutp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndOutpObject>();
  public IGqlpValue Encode(ItestAltCnstPrntDualGrndOutpObject input)
    => _itestPrntCnstPrntDualGrndOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntDualObject>
{
  private readonly Encoder<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>> _itestRefCnstPrntDualPrntDual = encoders.EncoderFor<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>>();
  public IGqlpValue Encode(ItestCnstPrntDualPrntDualObject input)
    => _itestRefCnstPrntDualPrntDual.Encode(input);

  internal static testCnstPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntDualEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntDualPrntDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstPrntDualPrntDualEncoder : IEncoder<ItestPrntCnstPrntDualPrntDualObject>
{
  public IGqlpValue Encode(ItestPrntCnstPrntDualPrntDualObject input)
    => new GqlpUnit();

  internal static testPrntCnstPrntDualPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntDualObject>
{
  private readonly Encoder<ItestPrntCnstPrntDualPrntDualObject> _itestPrntCnstPrntDualPrntDual = encoders.EncoderFor<ItestPrntCnstPrntDualPrntDualObject>();
  public IGqlpValue Encode(ItestAltCnstPrntDualPrntDualObject input)
    => _itestPrntCnstPrntDualPrntDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntInpObject>
{
  private readonly Encoder<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>> _itestRefCnstPrntDualPrntInp = encoders.EncoderFor<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>>();
  public IGqlpValue Encode(ItestCnstPrntDualPrntInpObject input)
    => _itestRefCnstPrntDualPrntInp.Encode(input);

  internal static testCnstPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntInpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntDualPrntInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstPrntDualPrntInpEncoder : IEncoder<ItestPrntCnstPrntDualPrntInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstPrntDualPrntInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntInpObject>
{
  private readonly Encoder<ItestPrntCnstPrntDualPrntInpObject> _itestPrntCnstPrntDualPrntInp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntInpObject>();
  public IGqlpValue Encode(ItestAltCnstPrntDualPrntInpObject input)
    => _itestPrntCnstPrntDualPrntInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntOutpObject>
{
  private readonly Encoder<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>> _itestRefCnstPrntDualPrntOutp = encoders.EncoderFor<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>>();
  public IGqlpValue Encode(ItestCnstPrntDualPrntOutpObject input)
    => _itestRefCnstPrntDualPrntOutp.Encode(input);

  internal static testCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntDualPrntOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstPrntDualPrntOutpEncoder : IEncoder<ItestPrntCnstPrntDualPrntOutpObject>
{
  public IGqlpValue Encode(ItestPrntCnstPrntDualPrntOutpObject input)
    => new GqlpUnit();

  internal static testPrntCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntOutpObject>
{
  private readonly Encoder<ItestPrntCnstPrntDualPrntOutpObject> _itestPrntCnstPrntDualPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntOutpObject>();
  public IGqlpValue Encode(ItestAltCnstPrntDualPrntOutpObject input)
    => _itestPrntCnstPrntDualPrntOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntEnumDualEncoder : IEncoder<ItestCnstPrntEnumDualObject>
{
  public IGqlpValue Encode(ItestCnstPrntEnumDualObject input)
    => new GqlpUnit();

  internal static testCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstPrntEnumDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumDualEncoder : IEncoder<testEnumCnstPrntEnumDual>
{
  public IGqlpValue Encode(testEnumCnstPrntEnumDual input)
    => input.EncodeEnum("EnumCnstPrntEnumDual");

  internal static testEnumCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumDualEncoder : IEncoder<testParentCnstPrntEnumDual>
{
  public IGqlpValue Encode(testParentCnstPrntEnumDual input)
    => input.EncodeEnum("ParentCnstPrntEnumDual");

  internal static testParentCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstPrntEnumInpEncoder : IEncoder<ItestCnstPrntEnumInpObject>
{
  public IGqlpValue Encode(ItestCnstPrntEnumInpObject input)
    => new GqlpUnit();

  internal static testCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstPrntEnumInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumInpEncoder : IEncoder<testEnumCnstPrntEnumInp>
{
  public IGqlpValue Encode(testEnumCnstPrntEnumInp input)
    => input.EncodeEnum("EnumCnstPrntEnumInp");

  internal static testEnumCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpEncoder : IEncoder<testParentCnstPrntEnumInp>
{
  public IGqlpValue Encode(testParentCnstPrntEnumInp input)
    => input.EncodeEnum("ParentCnstPrntEnumInp");

  internal static testParentCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstPrntEnumOutpEncoder : IEncoder<ItestCnstPrntEnumOutpObject>
{
  public IGqlpValue Encode(ItestCnstPrntEnumOutpObject input)
    => new GqlpUnit();

  internal static testCnstPrntEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefCnstPrntEnumOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumOutpEncoder : IEncoder<testEnumCnstPrntEnumOutp>
{
  public IGqlpValue Encode(testEnumCnstPrntEnumOutp input)
    => input.EncodeEnum("EnumCnstPrntEnumOutp");

  internal static testEnumCnstPrntEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumOutpEncoder : IEncoder<testParentCnstPrntEnumOutp>
{
  public IGqlpValue Encode(testParentCnstPrntEnumOutp input)
    => input.EncodeEnum("ParentCnstPrntEnumOutp");

  internal static testParentCnstPrntEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntDualObject>
{
  private readonly Encoder<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>> _itestRefCnstPrntObjPrntDual = encoders.EncoderFor<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>>();
  public IGqlpValue Encode(ItestCnstPrntObjPrntDualObject input)
    => _itestRefCnstPrntObjPrntDual.Encode(input);

  internal static testCnstPrntObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntDualEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntObjPrntDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstPrntObjPrntDualEncoder : IEncoder<ItestPrntCnstPrntObjPrntDualObject>
{
  public IGqlpValue Encode(ItestPrntCnstPrntObjPrntDualObject input)
    => new GqlpUnit();

  internal static testPrntCnstPrntObjPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntDualObject>
{
  private readonly Encoder<ItestPrntCnstPrntObjPrntDualObject> _itestPrntCnstPrntObjPrntDual = encoders.EncoderFor<ItestPrntCnstPrntObjPrntDualObject>();
  public IGqlpValue Encode(ItestAltCnstPrntObjPrntDualObject input)
    => _itestPrntCnstPrntObjPrntDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntInpObject>
{
  private readonly Encoder<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>> _itestRefCnstPrntObjPrntInp = encoders.EncoderFor<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>>();
  public IGqlpValue Encode(ItestCnstPrntObjPrntInpObject input)
    => _itestRefCnstPrntObjPrntInp.Encode(input);

  internal static testCnstPrntObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntInpEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntObjPrntInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstPrntObjPrntInpEncoder : IEncoder<ItestPrntCnstPrntObjPrntInpObject>
{
  public IGqlpValue Encode(ItestPrntCnstPrntObjPrntInpObject input)
    => new GqlpUnit();

  internal static testPrntCnstPrntObjPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntInpObject>
{
  private readonly Encoder<ItestPrntCnstPrntObjPrntInpObject> _itestPrntCnstPrntObjPrntInp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntInpObject>();
  public IGqlpValue Encode(ItestAltCnstPrntObjPrntInpObject input)
    => _itestPrntCnstPrntObjPrntInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntOutpObject>
{
  private readonly Encoder<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>> _itestRefCnstPrntObjPrntOutp = encoders.EncoderFor<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>>();
  public IGqlpValue Encode(ItestCnstPrntObjPrntOutpObject input)
    => _itestRefCnstPrntObjPrntOutp.Encode(input);

  internal static testCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefCnstPrntObjPrntOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testPrntCnstPrntObjPrntOutpEncoder : IEncoder<ItestPrntCnstPrntObjPrntOutpObject>
{
  public IGqlpValue Encode(ItestPrntCnstPrntObjPrntOutpObject input)
    => new GqlpUnit();

  internal static testPrntCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntOutpObject>
{
  private readonly Encoder<ItestPrntCnstPrntObjPrntOutpObject> _itestPrntCnstPrntObjPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntOutpObject>();
  public IGqlpValue Encode(ItestAltCnstPrntObjPrntOutpObject input)
    => _itestPrntCnstPrntObjPrntOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldDualEncoder : IEncoder<ItestFieldDualObject>
{
  public IGqlpValue Encode(ItestFieldDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldInpEncoder : IEncoder<ItestFieldInpObject>
{
  public IGqlpValue Encode(ItestFieldInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldOutpEncoder : IEncoder<ItestFieldOutpObject>
{
  public IGqlpValue Encode(ItestFieldOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrDualEncoder : IEncoder<ItestFieldDescrDualObject>
{
  public IGqlpValue Encode(ItestFieldDescrDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrInpEncoder : IEncoder<ItestFieldDescrInpObject>
{
  public IGqlpValue Encode(ItestFieldDescrInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrOutpEncoder : IEncoder<ItestFieldDescrOutpObject>
{
  public IGqlpValue Encode(ItestFieldDescrOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualDualObject>
{
  private readonly Encoder<ItestFldFieldDualDual> _itestFldFieldDualDual = encoders.EncoderFor<ItestFldFieldDualDual>();
  public IGqlpValue Encode(ItestFieldDualDualObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldFieldDualDual);

  internal static testFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldDualDualEncoder : IEncoder<ItestFldFieldDualDualObject>
{
  public IGqlpValue Encode(ItestFldFieldDualDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualInpObject>
{
  private readonly Encoder<ItestFldFieldDualInp> _itestFldFieldDualInp = encoders.EncoderFor<ItestFldFieldDualInp>();
  public IGqlpValue Encode(ItestFieldDualInpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldFieldDualInp);

  internal static testFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldDualInpEncoder : IEncoder<ItestFldFieldDualInpObject>
{
  public IGqlpValue Encode(ItestFldFieldDualInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualOutpObject>
{
  private readonly Encoder<ItestFldFieldDualOutp> _itestFldFieldDualOutp = encoders.EncoderFor<ItestFldFieldDualOutp>();
  public IGqlpValue Encode(ItestFieldDualOutpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldFieldDualOutp);

  internal static testFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldDualOutpEncoder : IEncoder<ItestFldFieldDualOutpObject>
{
  public IGqlpValue Encode(ItestFldFieldDualOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumDualEncoder : IEncoder<ItestFieldEnumDualObject>
{
  public IGqlpValue Encode(ItestFieldEnumDualObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumDualEncoder : IEncoder<testEnumFieldEnumDual>
{
  public IGqlpValue Encode(testEnumFieldEnumDual input)
    => input.EncodeEnum("EnumFieldEnumDual");

  internal static testEnumFieldEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumInpEncoder : IEncoder<ItestFieldEnumInpObject>
{
  public IGqlpValue Encode(ItestFieldEnumInpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumInpEncoder : IEncoder<testEnumFieldEnumInp>
{
  public IGqlpValue Encode(testEnumFieldEnumInp input)
    => input.EncodeEnum("EnumFieldEnumInp");

  internal static testEnumFieldEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumOutpEncoder : IEncoder<ItestFieldEnumOutpObject>
{
  public IGqlpValue Encode(ItestFieldEnumOutpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumOutpEncoder : IEncoder<testEnumFieldEnumOutp>
{
  public IGqlpValue Encode(testEnumFieldEnumOutp input)
    => input.EncodeEnum("EnumFieldEnumOutp");

  internal static testEnumFieldEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumPrntDualEncoder : IEncoder<ItestFieldEnumPrntDualObject>
{
  public IGqlpValue Encode(ItestFieldEnumPrntDualObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualEncoder : IEncoder<testEnumFieldEnumPrntDual>
{
  public IGqlpValue Encode(testEnumFieldEnumPrntDual input)
    => input.EncodeEnum("EnumFieldEnumPrntDual");

  internal static testEnumFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualEncoder : IEncoder<testPrntFieldEnumPrntDual>
{
  public IGqlpValue Encode(testPrntFieldEnumPrntDual input)
    => input.EncodeEnum("PrntFieldEnumPrntDual");

  internal static testPrntFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumPrntInpEncoder : IEncoder<ItestFieldEnumPrntInpObject>
{
  public IGqlpValue Encode(ItestFieldEnumPrntInpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntInpEncoder : IEncoder<testEnumFieldEnumPrntInp>
{
  public IGqlpValue Encode(testEnumFieldEnumPrntInp input)
    => input.EncodeEnum("EnumFieldEnumPrntInp");

  internal static testEnumFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpEncoder : IEncoder<testPrntFieldEnumPrntInp>
{
  public IGqlpValue Encode(testPrntFieldEnumPrntInp input)
    => input.EncodeEnum("PrntFieldEnumPrntInp");

  internal static testPrntFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumPrntOutpEncoder : IEncoder<ItestFieldEnumPrntOutpObject>
{
  public IGqlpValue Encode(ItestFieldEnumPrntOutpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntOutpEncoder : IEncoder<testEnumFieldEnumPrntOutp>
{
  public IGqlpValue Encode(testEnumFieldEnumPrntOutp input)
    => input.EncodeEnum("EnumFieldEnumPrntOutp");

  internal static testEnumFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpEncoder : IEncoder<testPrntFieldEnumPrntOutp>
{
  public IGqlpValue Encode(testPrntFieldEnumPrntOutp input)
    => input.EncodeEnum("PrntFieldEnumPrntOutp");

  internal static testPrntFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModEnumDualEncoder : IEncoder<ItestFieldModEnumDualObject>
{
  public IGqlpValue Encode(ItestFieldModEnumDualObject input)
    => new GqlpUnit();

  internal static testFieldModEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumDualEncoder : IEncoder<testEnumFieldModEnumDual>
{
  public IGqlpValue Encode(testEnumFieldModEnumDual input)
    => input.EncodeEnum("EnumFieldModEnumDual");

  internal static testEnumFieldModEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModEnumInpEncoder : IEncoder<ItestFieldModEnumInpObject>
{
  public IGqlpValue Encode(ItestFieldModEnumInpObject input)
    => new GqlpUnit();

  internal static testFieldModEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumInpEncoder : IEncoder<testEnumFieldModEnumInp>
{
  public IGqlpValue Encode(testEnumFieldModEnumInp input)
    => input.EncodeEnum("EnumFieldModEnumInp");

  internal static testEnumFieldModEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModEnumOutpEncoder : IEncoder<ItestFieldModEnumOutpObject>
{
  public IGqlpValue Encode(ItestFieldModEnumOutpObject input)
    => new GqlpUnit();

  internal static testFieldModEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumOutpEncoder : IEncoder<testEnumFieldModEnumOutp>
{
  public IGqlpValue Encode(testEnumFieldModEnumOutp input)
    => input.EncodeEnum("EnumFieldModEnumOutp");

  internal static testEnumFieldModEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModParamDualEncoder<TMod> : IEncoder<ItestFieldModParamDualObject<TMod>>
{
  public IGqlpValue Encode(ItestFieldModParamDualObject<TMod> input)
    => new GqlpUnit();
}

internal class testFldFieldModParamDualEncoder : IEncoder<ItestFldFieldModParamDualObject>
{
  public IGqlpValue Encode(ItestFldFieldModParamDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModParamInpEncoder<TMod> : IEncoder<ItestFieldModParamInpObject<TMod>>
{
  public IGqlpValue Encode(ItestFieldModParamInpObject<TMod> input)
    => new GqlpUnit();
}

internal class testFldFieldModParamInpEncoder : IEncoder<ItestFldFieldModParamInpObject>
{
  public IGqlpValue Encode(ItestFldFieldModParamInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModParamOutpEncoder<TMod> : IEncoder<ItestFieldModParamOutpObject<TMod>>
{
  public IGqlpValue Encode(ItestFieldModParamOutpObject<TMod> input)
    => new GqlpUnit();
}

internal class testFldFieldModParamOutpEncoder : IEncoder<ItestFldFieldModParamOutpObject>
{
  public IGqlpValue Encode(ItestFldFieldModParamOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjDualObject>
{
  private readonly Encoder<ItestFldFieldObjDual> _itestFldFieldObjDual = encoders.EncoderFor<ItestFldFieldObjDual>();
  public IGqlpValue Encode(ItestFieldObjDualObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldFieldObjDual);

  internal static testFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjDualEncoder : IEncoder<ItestFldFieldObjDualObject>
{
  public IGqlpValue Encode(ItestFldFieldObjDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjInpObject>
{
  private readonly Encoder<ItestFldFieldObjInp> _itestFldFieldObjInp = encoders.EncoderFor<ItestFldFieldObjInp>();
  public IGqlpValue Encode(ItestFieldObjInpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldFieldObjInp);

  internal static testFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjInpEncoder : IEncoder<ItestFldFieldObjInpObject>
{
  public IGqlpValue Encode(ItestFldFieldObjInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjOutpObject>
{
  private readonly Encoder<ItestFldFieldObjOutp> _itestFldFieldObjOutp = encoders.EncoderFor<ItestFldFieldObjOutp>();
  public IGqlpValue Encode(ItestFieldObjOutpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldFieldObjOutp);

  internal static testFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjOutpEncoder : IEncoder<ItestFldFieldObjOutpObject>
{
  public IGqlpValue Encode(ItestFldFieldObjOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFldFieldObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplDualEncoder : IEncoder<ItestFieldSmplDualObject>
{
  public IGqlpValue Encode(ItestFieldSmplDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplInpEncoder : IEncoder<ItestFieldSmplInpObject>
{
  public IGqlpValue Encode(ItestFieldSmplInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplOutpEncoder : IEncoder<ItestFieldSmplOutpObject>
{
  public IGqlpValue Encode(ItestFieldSmplOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrDualEncoder : IEncoder<ItestFieldTypeDescrDualObject>
{
  public IGqlpValue Encode(ItestFieldTypeDescrDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldTypeDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrInpEncoder : IEncoder<ItestFieldTypeDescrInpObject>
{
  public IGqlpValue Encode(ItestFieldTypeDescrInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldTypeDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrOutpEncoder : IEncoder<ItestFieldTypeDescrOutpObject>
{
  public IGqlpValue Encode(ItestFieldTypeDescrOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testFieldTypeDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDualEncoder : IEncoder<ItestFieldValueDualObject>
{
  public IGqlpValue Encode(ItestFieldValueDualObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDualEncoder : IEncoder<testEnumFieldValueDual>
{
  public IGqlpValue Encode(testEnumFieldValueDual input)
    => input.EncodeEnum("EnumFieldValueDual");

  internal static testEnumFieldValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueInpEncoder : IEncoder<ItestFieldValueInpObject>
{
  public IGqlpValue Encode(ItestFieldValueInpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueInpEncoder : IEncoder<testEnumFieldValueInp>
{
  public IGqlpValue Encode(testEnumFieldValueInp input)
    => input.EncodeEnum("EnumFieldValueInp");

  internal static testEnumFieldValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueOutpEncoder : IEncoder<ItestFieldValueOutpObject>
{
  public IGqlpValue Encode(ItestFieldValueOutpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueOutpEncoder : IEncoder<testEnumFieldValueOutp>
{
  public IGqlpValue Encode(testEnumFieldValueOutp input)
    => input.EncodeEnum("EnumFieldValueOutp");

  internal static testEnumFieldValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDescrDualEncoder : IEncoder<ItestFieldValueDescrDualObject>
{
  public IGqlpValue Encode(ItestFieldValueDescrDualObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrDualEncoder : IEncoder<testEnumFieldValueDescrDual>
{
  public IGqlpValue Encode(testEnumFieldValueDescrDual input)
    => input.EncodeEnum("EnumFieldValueDescrDual");

  internal static testEnumFieldValueDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDescrInpEncoder : IEncoder<ItestFieldValueDescrInpObject>
{
  public IGqlpValue Encode(ItestFieldValueDescrInpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrInpEncoder : IEncoder<testEnumFieldValueDescrInp>
{
  public IGqlpValue Encode(testEnumFieldValueDescrInp input)
    => input.EncodeEnum("EnumFieldValueDescrInp");

  internal static testEnumFieldValueDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDescrOutpEncoder : IEncoder<ItestFieldValueDescrOutpObject>
{
  public IGqlpValue Encode(ItestFieldValueDescrOutpObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrOutpEncoder : IEncoder<testEnumFieldValueDescrOutp>
{
  public IGqlpValue Encode(testEnumFieldValueDescrOutp input)
    => input.EncodeEnum("EnumFieldValueDescrOutp");

  internal static testEnumFieldValueDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltDualEncoder<TType> : IEncoder<ItestGnrcAltDualObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltDualObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcAltInpEncoder<TType> : IEncoder<ItestGnrcAltInpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltInpObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcAltOutpEncoder<TType> : IEncoder<ItestGnrcAltOutpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltOutpObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcAltArgDualEncoder<TType> : IEncoder<ItestGnrcAltArgDualObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgDualObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgDualEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltArgInpEncoder<TType> : IEncoder<ItestGnrcAltArgInpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgInpObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgInpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltArgOutpEncoder<TType> : IEncoder<ItestGnrcAltArgOutpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgOutpObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltArgDescrDualEncoder<TType> : IEncoder<ItestGnrcAltArgDescrDualObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgDescrDualObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgDescrDualEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgDescrDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltArgDescrInpEncoder<TType> : IEncoder<ItestGnrcAltArgDescrInpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgDescrInpObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgDescrInpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgDescrInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltArgDescrOutpEncoder<TType> : IEncoder<ItestGnrcAltArgDescrOutpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcAltArgDescrOutpObject<TType> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltArgDescrOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltArgDescrOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltDualDualEncoder : IEncoder<ItestGnrcAltDualDualObject>
{
  public IGqlpValue Encode(ItestGnrcAltDualDualObject input)
    => new GqlpUnit();

  internal static testGnrcAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualDualEncoder<TRef> : IEncoder<ItestRefGnrcAltDualDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltDualDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltDualDualEncoder : IEncoder<ItestAltGnrcAltDualDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltDualDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltDualInpEncoder : IEncoder<ItestGnrcAltDualInpObject>
{
  public IGqlpValue Encode(ItestGnrcAltDualInpObject input)
    => new GqlpUnit();

  internal static testGnrcAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualInpEncoder<TRef> : IEncoder<ItestRefGnrcAltDualInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltDualInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltDualInpEncoder : IEncoder<ItestAltGnrcAltDualInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltDualInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltDualOutpEncoder : IEncoder<ItestGnrcAltDualOutpObject>
{
  public IGqlpValue Encode(ItestGnrcAltDualOutpObject input)
    => new GqlpUnit();

  internal static testGnrcAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltDualOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltDualOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltDualOutpEncoder : IEncoder<ItestAltGnrcAltDualOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltDualOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltModParamDualEncoder<TRef,TMod> : IEncoder<ItestRefGnrcAltModParamDualObject<TRef,TMod>>
{
  public IGqlpValue Encode(ItestRefGnrcAltModParamDualObject<TRef,TMod> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltModParamInpEncoder<TRef,TMod> : IEncoder<ItestRefGnrcAltModParamInpObject<TRef,TMod>>
{
  public IGqlpValue Encode(ItestRefGnrcAltModParamInpObject<TRef,TMod> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltModParamOutpEncoder<TRef,TMod> : IEncoder<ItestRefGnrcAltModParamOutpObject<TRef,TMod>>
{
  public IGqlpValue Encode(ItestRefGnrcAltModParamOutpObject<TRef,TMod> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltModStrDualEncoder<TRef> : IEncoder<ItestRefGnrcAltModStrDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltModStrDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltModStrInpEncoder<TRef> : IEncoder<ItestRefGnrcAltModStrInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltModStrInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testRefGnrcAltModStrOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltModStrOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltModStrOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltParamDualEncoder : IEncoder<ItestGnrcAltParamDualObject>
{
  public IGqlpValue Encode(ItestGnrcAltParamDualObject input)
    => new GqlpUnit();

  internal static testGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamDualEncoder<TRef> : IEncoder<ItestRefGnrcAltParamDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltParamDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltParamDualEncoder : IEncoder<ItestAltGnrcAltParamDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltParamDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltParamInpEncoder : IEncoder<ItestGnrcAltParamInpObject>
{
  public IGqlpValue Encode(ItestGnrcAltParamInpObject input)
    => new GqlpUnit();

  internal static testGnrcAltParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamInpEncoder<TRef> : IEncoder<ItestRefGnrcAltParamInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltParamInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltParamInpEncoder : IEncoder<ItestAltGnrcAltParamInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltParamInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltParamOutpEncoder : IEncoder<ItestGnrcAltParamOutpObject>
{
  public IGqlpValue Encode(ItestGnrcAltParamOutpObject input)
    => new GqlpUnit();

  internal static testGnrcAltParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltParamOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltParamOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcAltParamOutpEncoder : IEncoder<ItestAltGnrcAltParamOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcAltParamOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltSmplDualEncoder : IEncoder<ItestGnrcAltSmplDualObject>
{
  public IGqlpValue Encode(ItestGnrcAltSmplDualObject input)
    => new GqlpUnit();

  internal static testGnrcAltSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplDualEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltSmplDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltSmplInpEncoder : IEncoder<ItestGnrcAltSmplInpObject>
{
  public IGqlpValue Encode(ItestGnrcAltSmplInpObject input)
    => new GqlpUnit();

  internal static testGnrcAltSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplInpEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltSmplInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcAltSmplOutpEncoder : IEncoder<ItestGnrcAltSmplOutpObject>
{
  public IGqlpValue Encode(ItestGnrcAltSmplOutpObject input)
    => new GqlpUnit();

  internal static testGnrcAltSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcAltSmplOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcDescrDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestGnrcDescrDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcDescrInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestGnrcDescrInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcDescrOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestGnrcDescrOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcEnumDualEncoder : IEncoder<ItestGnrcEnumDualObject>
{
  public IGqlpValue Encode(ItestGnrcEnumDualObject input)
    => new GqlpUnit();

  internal static testGnrcEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefGnrcEnumDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumDualEncoder : IEncoder<testEnumGnrcEnumDual>
{
  public IGqlpValue Encode(testEnumGnrcEnumDual input)
    => input.EncodeEnum("EnumGnrcEnumDual");

  internal static testEnumGnrcEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcEnumInpEncoder : IEncoder<ItestGnrcEnumInpObject>
{
  public IGqlpValue Encode(ItestGnrcEnumInpObject input)
    => new GqlpUnit();

  internal static testGnrcEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefGnrcEnumInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumInpEncoder : IEncoder<testEnumGnrcEnumInp>
{
  public IGqlpValue Encode(testEnumGnrcEnumInp input)
    => input.EncodeEnum("EnumGnrcEnumInp");

  internal static testEnumGnrcEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcEnumOutpEncoder : IEncoder<ItestGnrcEnumOutpObject>
{
  public IGqlpValue Encode(ItestGnrcEnumOutpObject input)
    => new GqlpUnit();

  internal static testGnrcEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefGnrcEnumOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumOutpEncoder : IEncoder<testEnumGnrcEnumOutp>
{
  public IGqlpValue Encode(testEnumGnrcEnumOutp input)
    => input.EncodeEnum("EnumGnrcEnumOutp");

  internal static testEnumGnrcEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestGnrcFieldDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestGnrcFieldInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestGnrcFieldOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldArgDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgDualObject<TType>>
{
  private readonly Encoder<ItestRefGnrcFieldArgDual<TType>> _itestRefGnrcFieldArgDual = encoders.EncoderFor<ItestRefGnrcFieldArgDual<TType>>();
  public IGqlpValue Encode(ItestGnrcFieldArgDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgDual);
}

internal class testRefGnrcFieldArgDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldArgDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcFieldArgInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgInpObject<TType>>
{
  private readonly Encoder<ItestRefGnrcFieldArgInp<TType>> _itestRefGnrcFieldArgInp = encoders.EncoderFor<ItestRefGnrcFieldArgInp<TType>>();
  public IGqlpValue Encode(ItestGnrcFieldArgInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgInp);
}

internal class testRefGnrcFieldArgInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldArgInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcFieldArgOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgOutpObject<TType>>
{
  private readonly Encoder<ItestRefGnrcFieldArgOutp<TType>> _itestRefGnrcFieldArgOutp = encoders.EncoderFor<ItestRefGnrcFieldArgOutp<TType>>();
  public IGqlpValue Encode(ItestGnrcFieldArgOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgOutp);
}

internal class testRefGnrcFieldArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldArgOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualDualObject>
{
  private readonly Encoder<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>> _itestRefGnrcFieldDualDual = encoders.EncoderFor<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>>();
  public IGqlpValue Encode(ItestGnrcFieldDualDualObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualDual);

  internal static testGnrcFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldDualDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldDualDualEncoder : IEncoder<ItestAltGnrcFieldDualDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldDualDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualInpObject>
{
  private readonly Encoder<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>> _itestRefGnrcFieldDualInp = encoders.EncoderFor<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>>();
  public IGqlpValue Encode(ItestGnrcFieldDualInpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualInp);

  internal static testGnrcFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldDualInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldDualInpEncoder : IEncoder<ItestAltGnrcFieldDualInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldDualInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualOutpObject>
{
  private readonly Encoder<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>> _itestRefGnrcFieldDualOutp = encoders.EncoderFor<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>>();
  public IGqlpValue Encode(ItestGnrcFieldDualOutpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualOutp);

  internal static testGnrcFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldDualOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldDualOutpEncoder : IEncoder<ItestAltGnrcFieldDualOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldDualOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamDualObject>
{
  private readonly Encoder<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>> _itestRefGnrcFieldParamDual = encoders.EncoderFor<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>>();
  public IGqlpValue Encode(ItestGnrcFieldParamDualObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamDual);

  internal static testGnrcFieldParamDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldParamDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldParamDualEncoder : IEncoder<ItestAltGnrcFieldParamDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldParamDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamInpObject>
{
  private readonly Encoder<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>> _itestRefGnrcFieldParamInp = encoders.EncoderFor<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>>();
  public IGqlpValue Encode(ItestGnrcFieldParamInpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamInp);

  internal static testGnrcFieldParamInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldParamInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldParamInpEncoder : IEncoder<ItestAltGnrcFieldParamInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldParamInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamOutpObject>
{
  private readonly Encoder<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>> _itestRefGnrcFieldParamOutp = encoders.EncoderFor<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>>();
  public IGqlpValue Encode(ItestGnrcFieldParamOutpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamOutp);

  internal static testGnrcFieldParamOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcFieldParamOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcFieldParamOutpEncoder : IEncoder<ItestAltGnrcFieldParamOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcFieldParamOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualEncoder<TType> : IEncoder<ItestGnrcPrntDualObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcPrntDualObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcPrntInpEncoder<TType> : IEncoder<ItestGnrcPrntInpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcPrntInpObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcPrntOutpEncoder<TType> : IEncoder<ItestGnrcPrntOutpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcPrntOutpObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcPrntArgDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgDualObject<TType>>
{
  private readonly Encoder<ItestRefGnrcPrntArgDualObject<TType>> _itestRefGnrcPrntArgDual = encoders.EncoderFor<ItestRefGnrcPrntArgDualObject<TType>>();
  public IGqlpValue Encode(ItestGnrcPrntArgDualObject<TType> input)
    => _itestRefGnrcPrntArgDual.Encode(input);
}

internal class testRefGnrcPrntArgDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntArgDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcPrntArgInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgInpObject<TType>>
{
  private readonly Encoder<ItestRefGnrcPrntArgInpObject<TType>> _itestRefGnrcPrntArgInp = encoders.EncoderFor<ItestRefGnrcPrntArgInpObject<TType>>();
  public IGqlpValue Encode(ItestGnrcPrntArgInpObject<TType> input)
    => _itestRefGnrcPrntArgInp.Encode(input);
}

internal class testRefGnrcPrntArgInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntArgInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcPrntArgOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgOutpObject<TType>>
{
  private readonly Encoder<ItestRefGnrcPrntArgOutpObject<TType>> _itestRefGnrcPrntArgOutp = encoders.EncoderFor<ItestRefGnrcPrntArgOutpObject<TType>>();
  public IGqlpValue Encode(ItestGnrcPrntArgOutpObject<TType> input)
    => _itestRefGnrcPrntArgOutp.Encode(input);
}

internal class testRefGnrcPrntArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntArgOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testGnrcPrntDescrDualEncoder<TType> : IEncoder<ItestGnrcPrntDescrDualObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcPrntDescrDualObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcPrntDescrInpEncoder<TType> : IEncoder<ItestGnrcPrntDescrInpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcPrntDescrInpObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcPrntDescrOutpEncoder<TType> : IEncoder<ItestGnrcPrntDescrOutpObject<TType>>
{
  public IGqlpValue Encode(ItestGnrcPrntDescrOutpObject<TType> input)
    => new GqlpUnit();
}

internal class testGnrcPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualDualObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>> _itestRefGnrcPrntDualDual = encoders.EncoderFor<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>>();
  public IGqlpValue Encode(ItestGnrcPrntDualDualObject input)
    => _itestRefGnrcPrntDualDual.Encode(input);

  internal static testGnrcPrntDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualDualEncoder : IEncoder<ItestAltGnrcPrntDualDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualInpObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>> _itestRefGnrcPrntDualInp = encoders.EncoderFor<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>>();
  public IGqlpValue Encode(ItestGnrcPrntDualInpObject input)
    => _itestRefGnrcPrntDualInp.Encode(input);

  internal static testGnrcPrntDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualInpEncoder : IEncoder<ItestAltGnrcPrntDualInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualOutpObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>> _itestRefGnrcPrntDualOutp = encoders.EncoderFor<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntDualOutpObject input)
    => _itestRefGnrcPrntDualOutp.Encode(input);

  internal static testGnrcPrntDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualOutpEncoder : IEncoder<ItestAltGnrcPrntDualOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntDualObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>> _itestRefGnrcPrntDualPrntDual = encoders.EncoderFor<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>>();
  public IGqlpValue Encode(ItestGnrcPrntDualPrntDualObject input)
    => _itestRefGnrcPrntDualPrntDual.Encode(input);

  internal static testGnrcPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualPrntDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualPrntDualEncoder : IEncoder<ItestAltGnrcPrntDualPrntDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualPrntDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntInpObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>> _itestRefGnrcPrntDualPrntInp = encoders.EncoderFor<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>>();
  public IGqlpValue Encode(ItestGnrcPrntDualPrntInpObject input)
    => _itestRefGnrcPrntDualPrntInp.Encode(input);

  internal static testGnrcPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualPrntInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualPrntInpEncoder : IEncoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualPrntInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntOutpObject>
{
  private readonly Encoder<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>> _itestRefGnrcPrntDualPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntDualPrntOutpObject input)
    => _itestRefGnrcPrntDualPrntOutp.Encode(input);

  internal static testGnrcPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntDualPrntOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntDualPrntOutpEncoder : IEncoder<ItestAltGnrcPrntDualPrntOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntDualPrntOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumChildDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildDualObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>> _itestFieldGnrcPrntEnumChildDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumChildDualObject input)
    => _itestFieldGnrcPrntEnumChildDual.Encode(input);

  internal static testGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumChildDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumChildDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildDualEncoder : IEncoder<testEnumGnrcPrntEnumChildDual>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumChildDual input)
    => input.EncodeEnum("EnumGnrcPrntEnumChildDual");

  internal static testEnumGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildDualEncoder : IEncoder<testParentGnrcPrntEnumChildDual>
{
  public IGqlpValue Encode(testParentGnrcPrntEnumChildDual input)
    => input.EncodeEnum("ParentGnrcPrntEnumChildDual");

  internal static testParentGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumChildInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildInpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>> _itestFieldGnrcPrntEnumChildInp = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumChildInpObject input)
    => _itestFieldGnrcPrntEnumChildInp.Encode(input);

  internal static testGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumChildInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumChildInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildInpEncoder : IEncoder<testEnumGnrcPrntEnumChildInp>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumChildInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumChildInp");

  internal static testEnumGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpEncoder : IEncoder<testParentGnrcPrntEnumChildInp>
{
  public IGqlpValue Encode(testParentGnrcPrntEnumChildInp input)
    => input.EncodeEnum("ParentGnrcPrntEnumChildInp");

  internal static testParentGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumChildOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildOutpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>> _itestFieldGnrcPrntEnumChildOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumChildOutpObject input)
    => _itestFieldGnrcPrntEnumChildOutp.Encode(input);

  internal static testGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumChildOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumChildOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildOutpEncoder : IEncoder<testEnumGnrcPrntEnumChildOutp>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumChildOutp input)
    => input.EncodeEnum("EnumGnrcPrntEnumChildOutp");

  internal static testEnumGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpEncoder : IEncoder<testParentGnrcPrntEnumChildOutp>
{
  public IGqlpValue Encode(testParentGnrcPrntEnumChildOutp input)
    => input.EncodeEnum("ParentGnrcPrntEnumChildOutp");

  internal static testParentGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomDualObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>> _itestFieldGnrcPrntEnumDomDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumDomDualObject input)
    => _itestFieldGnrcPrntEnumDomDual.Encode(input);

  internal static testGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumDomDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumDomDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomDualEncoder : IEncoder<testEnumGnrcPrntEnumDomDual>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumDomDual input)
    => input.EncodeEnum("EnumGnrcPrntEnumDomDual");

  internal static testEnumGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomDualEncoder : IEncoder<ItestDomGnrcPrntEnumDomDual>
{
  public IGqlpValue Encode(ItestDomGnrcPrntEnumDomDual input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomDual")!;

  internal static testDomGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomInpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>> _itestFieldGnrcPrntEnumDomInp = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumDomInpObject input)
    => _itestFieldGnrcPrntEnumDomInp.Encode(input);

  internal static testGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumDomInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumDomInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomInpEncoder : IEncoder<testEnumGnrcPrntEnumDomInp>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumDomInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumDomInp");

  internal static testEnumGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public IGqlpValue Encode(ItestDomGnrcPrntEnumDomInp input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomInp")!;

  internal static testDomGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomOutpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>> _itestFieldGnrcPrntEnumDomOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumDomOutpObject input)
    => _itestFieldGnrcPrntEnumDomOutp.Encode(input);

  internal static testGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumDomOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumDomOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomOutpEncoder : IEncoder<testEnumGnrcPrntEnumDomOutp>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumDomOutp input)
    => input.EncodeEnum("EnumGnrcPrntEnumDomOutp");

  internal static testEnumGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomOutpEncoder : IEncoder<ItestDomGnrcPrntEnumDomOutp>
{
  public IGqlpValue Encode(ItestDomGnrcPrntEnumDomOutp input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomOutp")!;

  internal static testDomGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntDualObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>> _itestFieldGnrcPrntEnumPrntDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumPrntDualObject input)
    => _itestFieldGnrcPrntEnumPrntDual.Encode(input);

  internal static testGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumPrntDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumPrntDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntDualEncoder : IEncoder<testEnumGnrcPrntEnumPrntDual>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumPrntDual input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntDual");

  internal static testEnumGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntDualEncoder : IEncoder<testParentGnrcPrntEnumPrntDual>
{
  public IGqlpValue Encode(testParentGnrcPrntEnumPrntDual input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntDual");

  internal static testParentGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntInpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>> _itestFieldGnrcPrntEnumPrntInp = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumPrntInpObject input)
    => _itestFieldGnrcPrntEnumPrntInp.Encode(input);

  internal static testGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumPrntInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumPrntInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntInpEncoder : IEncoder<testEnumGnrcPrntEnumPrntInp>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumPrntInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntInp");

  internal static testEnumGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpEncoder : IEncoder<testParentGnrcPrntEnumPrntInp>
{
  public IGqlpValue Encode(testParentGnrcPrntEnumPrntInp input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntInp");

  internal static testParentGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntOutpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>> _itestFieldGnrcPrntEnumPrntOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntEnumPrntOutpObject input)
    => _itestFieldGnrcPrntEnumPrntOutp.Encode(input);

  internal static testGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumPrntOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntEnumPrntOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntOutpEncoder : IEncoder<testEnumGnrcPrntEnumPrntOutp>
{
  public IGqlpValue Encode(testEnumGnrcPrntEnumPrntOutp input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntOutp");

  internal static testEnumGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpEncoder : IEncoder<testParentGnrcPrntEnumPrntOutp>
{
  public IGqlpValue Encode(testParentGnrcPrntEnumPrntOutp input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntOutp");

  internal static testParentGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamDualObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>> _itestRefGnrcPrntParamDual = encoders.EncoderFor<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>>();
  public IGqlpValue Encode(ItestGnrcPrntParamDualObject input)
    => _itestRefGnrcPrntParamDual.Encode(input);

  internal static testGnrcPrntParamDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamDualEncoder : IEncoder<ItestAltGnrcPrntParamDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamInpObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>> _itestRefGnrcPrntParamInp = encoders.EncoderFor<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>>();
  public IGqlpValue Encode(ItestGnrcPrntParamInpObject input)
    => _itestRefGnrcPrntParamInp.Encode(input);

  internal static testGnrcPrntParamInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamInpEncoder : IEncoder<ItestAltGnrcPrntParamInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamOutpObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>> _itestRefGnrcPrntParamOutp = encoders.EncoderFor<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntParamOutpObject input)
    => _itestRefGnrcPrntParamOutp.Encode(input);

  internal static testGnrcPrntParamOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamOutpEncoder : IEncoder<ItestAltGnrcPrntParamOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntDualObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>> _itestRefGnrcPrntParamPrntDual = encoders.EncoderFor<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>>();
  public IGqlpValue Encode(ItestGnrcPrntParamPrntDualObject input)
    => _itestRefGnrcPrntParamPrntDual.Encode(input);

  internal static testGnrcPrntParamPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntDualObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamPrntDualObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamPrntDualEncoder : IEncoder<ItestAltGnrcPrntParamPrntDualObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamPrntDualObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntInpObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>> _itestRefGnrcPrntParamPrntInp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>>();
  public IGqlpValue Encode(ItestGnrcPrntParamPrntInpObject input)
    => _itestRefGnrcPrntParamPrntInp.Encode(input);

  internal static testGnrcPrntParamPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntInpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamPrntInpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamPrntInpEncoder : IEncoder<ItestAltGnrcPrntParamPrntInpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamPrntInpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntOutpObject>
{
  private readonly Encoder<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>> _itestRefGnrcPrntParamPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntParamPrntOutpObject input)
    => _itestRefGnrcPrntParamPrntOutp.Encode(input);

  internal static testGnrcPrntParamPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntOutpObject<TRef>>
{
  public IGqlpValue Encode(ItestRefGnrcPrntParamPrntOutpObject<TRef> input)
    => new GqlpUnit();
}

internal class testAltGnrcPrntParamPrntOutpEncoder : IEncoder<ItestAltGnrcPrntParamPrntOutpObject>
{
  public IGqlpValue Encode(ItestAltGnrcPrntParamPrntOutpObject input)
    => new GqlpUnit()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumDualObject>
{
  private readonly Encoder<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>> _itestFieldGnrcPrntSmplEnumDual = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>>();
  public IGqlpValue Encode(ItestGnrcPrntSmplEnumDualObject input)
    => _itestFieldGnrcPrntSmplEnumDual.Encode(input);

  internal static testGnrcPrntSmplEnumDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntSmplEnumDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumDualEncoder : IEncoder<testEnumGnrcPrntSmplEnumDual>
{
  public IGqlpValue Encode(testEnumGnrcPrntSmplEnumDual input)
    => input.EncodeEnum("EnumGnrcPrntSmplEnumDual");

  internal static testEnumGnrcPrntSmplEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumInpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>> _itestFieldGnrcPrntSmplEnumInp = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>>();
  public IGqlpValue Encode(ItestGnrcPrntSmplEnumInpObject input)
    => _itestFieldGnrcPrntSmplEnumInp.Encode(input);

  internal static testGnrcPrntSmplEnumInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntSmplEnumInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumInpEncoder : IEncoder<testEnumGnrcPrntSmplEnumInp>
{
  public IGqlpValue Encode(testEnumGnrcPrntSmplEnumInp input)
    => input.EncodeEnum("EnumGnrcPrntSmplEnumInp");

  internal static testEnumGnrcPrntSmplEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumOutpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>> _itestFieldGnrcPrntSmplEnumOutp = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntSmplEnumOutpObject input)
    => _itestFieldGnrcPrntSmplEnumOutp.Encode(input);

  internal static testGnrcPrntSmplEnumOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntSmplEnumOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumOutpEncoder : IEncoder<testEnumGnrcPrntSmplEnumOutp>
{
  public IGqlpValue Encode(testEnumGnrcPrntSmplEnumOutp input)
    => input.EncodeEnum("EnumGnrcPrntSmplEnumOutp");

  internal static testEnumGnrcPrntSmplEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntStrDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomDualObject>
{
  private readonly Encoder<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>> _itestFieldGnrcPrntStrDomDual = encoders.EncoderFor<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>>();
  public IGqlpValue Encode(ItestGnrcPrntStrDomDualObject input)
    => _itestFieldGnrcPrntStrDomDual.Encode(input);

  internal static testGnrcPrntStrDomDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntStrDomDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomDualObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntStrDomDualObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomDualEncoder : IEncoder<ItestDomGnrcPrntStrDomDual>
{
  public IGqlpValue Encode(ItestDomGnrcPrntStrDomDual input)
    => input.Value!.Encode();

  internal static testDomGnrcPrntStrDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntStrDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomInpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>> _itestFieldGnrcPrntStrDomInp = encoders.EncoderFor<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>>();
  public IGqlpValue Encode(ItestGnrcPrntStrDomInpObject input)
    => _itestFieldGnrcPrntStrDomInp.Encode(input);

  internal static testGnrcPrntStrDomInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntStrDomInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomInpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntStrDomInpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomInpEncoder : IEncoder<ItestDomGnrcPrntStrDomInp>
{
  public IGqlpValue Encode(ItestDomGnrcPrntStrDomInp input)
    => input.Value!.Encode();

  internal static testDomGnrcPrntStrDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntStrDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomOutpObject>
{
  private readonly Encoder<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>> _itestFieldGnrcPrntStrDomOutp = encoders.EncoderFor<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>>();
  public IGqlpValue Encode(ItestGnrcPrntStrDomOutpObject input)
    => _itestFieldGnrcPrntStrDomOutp.Encode(input);

  internal static testGnrcPrntStrDomOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntStrDomOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomOutpObject<TRef>>
{
  private readonly Encoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public IGqlpValue Encode(ItestFieldGnrcPrntStrDomOutpObject<TRef> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomOutpEncoder : IEncoder<ItestDomGnrcPrntStrDomOutp>
{
  public IGqlpValue Encode(ItestDomGnrcPrntStrDomOutp input)
    => input.Value!.Encode();

  internal static testDomGnrcPrntStrDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcValueDualEncoder : IEncoder<ItestGnrcValueDualObject>
{
  public IGqlpValue Encode(ItestGnrcValueDualObject input)
    => new GqlpUnit();

  internal static testGnrcValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefGnrcValueDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueDualEncoder : IEncoder<testEnumGnrcValueDual>
{
  public IGqlpValue Encode(testEnumGnrcValueDual input)
    => input.EncodeEnum("EnumGnrcValueDual");

  internal static testEnumGnrcValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcValueInpEncoder : IEncoder<ItestGnrcValueInpObject>
{
  public IGqlpValue Encode(ItestGnrcValueInpObject input)
    => new GqlpUnit();

  internal static testGnrcValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefGnrcValueInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueInpEncoder : IEncoder<testEnumGnrcValueInp>
{
  public IGqlpValue Encode(testEnumGnrcValueInp input)
    => input.EncodeEnum("EnumGnrcValueInp");

  internal static testEnumGnrcValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcValueOutpEncoder : IEncoder<ItestGnrcValueOutpObject>
{
  public IGqlpValue Encode(ItestGnrcValueOutpObject input)
    => new GqlpUnit();

  internal static testGnrcValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefGnrcValueOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueOutpEncoder : IEncoder<testEnumGnrcValueOutp>
{
  public IGqlpValue Encode(testEnumGnrcValueOutp input)
    => input.EncodeEnum("EnumGnrcValueOutp");

  internal static testEnumGnrcValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldDescrNmbrEncoder : IEncoder<ItestInpFieldDescrNmbrObject>
{
  public IGqlpValue Encode(ItestInpFieldDescrNmbrObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testInpFieldDescrNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldEnumEncoder : IEncoder<ItestInpFieldEnumObject>
{
  public IGqlpValue Encode(ItestInpFieldEnumObject input)
    => new GqlpUnit()
      .AddEnum("field", input.Field);

  internal static testInpFieldEnumEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumInpFieldEnumEncoder : IEncoder<testEnumInpFieldEnum>
{
  public IGqlpValue Encode(testEnumInpFieldEnum input)
    => input.EncodeEnum("EnumInpFieldEnum");

  internal static testEnumInpFieldEnumEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldNullEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestInpFieldNullObject>
{
  private readonly Encoder<ItestFldInpFieldNull> _itestFldInpFieldNull = encoders.EncoderFor<ItestFldInpFieldNull>();
  public IGqlpValue Encode(ItestInpFieldNullObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldInpFieldNull);

  internal static testInpFieldNullEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldInpFieldNullEncoder : IEncoder<ItestFldInpFieldNullObject>
{
  public IGqlpValue Encode(ItestFldInpFieldNullObject input)
    => new GqlpUnit();

  internal static testFldInpFieldNullEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldNmbrEncoder : IEncoder<ItestInpFieldNmbrObject>
{
  public IGqlpValue Encode(ItestInpFieldNmbrObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testInpFieldNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldNmbrDescrEncoder : IEncoder<ItestInpFieldNmbrDescrObject>
{
  public IGqlpValue Encode(ItestInpFieldNmbrDescrObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testInpFieldNmbrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldStrEncoder : IEncoder<ItestInpFieldStrObject>
{
  public IGqlpValue Encode(ItestInpFieldStrObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testInpFieldStrEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpDescrParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpDescrParamObject>
{
  private readonly Encoder<ItestFldOutpDescrParam> _itestFldOutpDescrParam = encoders.EncoderFor<ItestFldOutpDescrParam>();
  public IGqlpValue Encode(ItestOutpDescrParamObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestFldOutpDescrParam);

  internal static testOutpDescrParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpDescrParamEncoder : IEncoder<ItestFldOutpDescrParamObject>
{
  public IGqlpValue Encode(ItestFldOutpDescrParamObject input)
    => new GqlpUnit();

  internal static testFldOutpDescrParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpDescrParamEncoder : IEncoder<ItestInOutpDescrParamObject>
{
  public IGqlpValue Encode(ItestInOutpDescrParamObject input)
    => new GqlpUnit()
      .Add("param", input.Param.Encode());

  internal static testInOutpDescrParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamObject>
{
  private readonly Encoder<ItestFldOutpParam> _itestFldOutpParam = encoders.EncoderFor<ItestFldOutpParam>();
  public IGqlpValue Encode(ItestOutpParamObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestFldOutpParam);

  internal static testOutpParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamEncoder : IEncoder<ItestFldOutpParamObject>
{
  public IGqlpValue Encode(ItestFldOutpParamObject input)
    => new GqlpUnit();

  internal static testFldOutpParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpParamEncoder : IEncoder<ItestInOutpParamObject>
{
  public IGqlpValue Encode(ItestInOutpParamObject input)
    => new GqlpUnit()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamDescrObject>
{
  private readonly Encoder<ItestFldOutpParamDescr> _itestFldOutpParamDescr = encoders.EncoderFor<ItestFldOutpParamDescr>();
  public IGqlpValue Encode(ItestOutpParamDescrObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestFldOutpParamDescr);

  internal static testOutpParamDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamDescrEncoder : IEncoder<ItestFldOutpParamDescrObject>
{
  public IGqlpValue Encode(ItestFldOutpParamDescrObject input)
    => new GqlpUnit();

  internal static testFldOutpParamDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpParamDescrEncoder : IEncoder<ItestInOutpParamDescrObject>
{
  public IGqlpValue Encode(ItestInOutpParamDescrObject input)
    => new GqlpUnit()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamModDmnEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModDmnObject>
{
  private readonly Encoder<ItestDomOutpParamModDmn> _itestDomOutpParamModDmn = encoders.EncoderFor<ItestDomOutpParamModDmn>();
  public IGqlpValue Encode(ItestOutpParamModDmnObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestDomOutpParamModDmn);

  internal static testOutpParamModDmnEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testInOutpParamModDmnEncoder : IEncoder<ItestInOutpParamModDmnObject>
{
  public IGqlpValue Encode(ItestInOutpParamModDmnObject input)
    => new GqlpUnit()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamModDmnEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomOutpParamModDmnEncoder : IEncoder<ItestDomOutpParamModDmn>
{
  public IGqlpValue Encode(ItestDomOutpParamModDmn input)
    => input.Value!.Encode();

  internal static testDomOutpParamModDmnEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamModParamEncoder<TMod>(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModParamObject<TMod>>
{
  private readonly Encoder<ItestDomOutpParamModParam> _itestDomOutpParamModParam = encoders.EncoderFor<ItestDomOutpParamModParam>();
  public IGqlpValue Encode(ItestOutpParamModParamObject<TMod> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestDomOutpParamModParam);
}

internal class testInOutpParamModParamEncoder : IEncoder<ItestInOutpParamModParamObject>
{
  public IGqlpValue Encode(ItestInOutpParamModParamObject input)
    => new GqlpUnit()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamModParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomOutpParamModParamEncoder : IEncoder<ItestDomOutpParamModParam>
{
  public IGqlpValue Encode(ItestDomOutpParamModParam input)
    => input.Value!.Encode();

  internal static testDomOutpParamModParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamTypeDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamTypeDescrObject>
{
  private readonly Encoder<ItestFldOutpParamTypeDescr> _itestFldOutpParamTypeDescr = encoders.EncoderFor<ItestFldOutpParamTypeDescr>();
  public IGqlpValue Encode(ItestOutpParamTypeDescrObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestFldOutpParamTypeDescr);

  internal static testOutpParamTypeDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public IGqlpValue Encode(ItestFldOutpParamTypeDescrObject input)
    => new GqlpUnit();

  internal static testFldOutpParamTypeDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpParamTypeDescrEncoder : IEncoder<ItestInOutpParamTypeDescrObject>
{
  public IGqlpValue Encode(ItestInOutpParamTypeDescrObject input)
    => new GqlpUnit()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamTypeDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpPrntGnrcEncoder : IEncoder<ItestOutpPrntGnrcObject>
{
  public IGqlpValue Encode(ItestOutpPrntGnrcObject input)
    => new GqlpUnit();

  internal static testOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefOutpPrntGnrcEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefOutpPrntGnrcObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestRefOutpPrntGnrcObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumOutpPrntGnrcEncoder : IEncoder<testEnumOutpPrntGnrc>
{
  public IGqlpValue Encode(testEnumOutpPrntGnrc input)
    => input.EncodeEnum("EnumOutpPrntGnrc");

  internal static testEnumOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcEncoder : IEncoder<testPrntOutpPrntGnrc>
{
  public IGqlpValue Encode(testPrntOutpPrntGnrc input)
    => input.EncodeEnum("PrntOutpPrntGnrc");

  internal static testPrntOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpPrntParamObject>
{
  private readonly Encoder<ItestPrntOutpPrntParamObject> _itestPrntOutpPrntParam = encoders.EncoderFor<ItestPrntOutpPrntParamObject>();
  private readonly Encoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public IGqlpValue Encode(ItestOutpPrntParamObject input)
    => _itestPrntOutpPrntParam.Encode(input)
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);

  internal static testOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpPrntParamObject>
{
  private readonly Encoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public IGqlpValue Encode(ItestPrntOutpPrntParamObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);

  internal static testPrntOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpPrntParamEncoder : IEncoder<ItestFldOutpPrntParamObject>
{
  public IGqlpValue Encode(ItestFldOutpPrntParamObject input)
    => new GqlpUnit();

  internal static testFldOutpPrntParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpPrntParamEncoder : IEncoder<ItestInOutpPrntParamObject>
{
  public IGqlpValue Encode(ItestInOutpPrntParamObject input)
    => new GqlpUnit()
      .Add("param", input.Param.Encode());

  internal static testInOutpPrntParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpPrntParamInEncoder : IEncoder<ItestPrntOutpPrntParamInObject>
{
  public IGqlpValue Encode(ItestPrntOutpPrntParamInObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testPrntOutpPrntParamInEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualObject>
{
  private readonly Encoder<ItestRefPrntDualObject> _itestRefPrntDual = encoders.EncoderFor<ItestRefPrntDualObject>();
  public IGqlpValue Encode(ItestPrntDualObject input)
    => _itestRefPrntDual.Encode(input);

  internal static testPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualEncoder : IEncoder<ItestRefPrntDualObject>
{
  public IGqlpValue Encode(ItestRefPrntDualObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntInpObject>
{
  private readonly Encoder<ItestRefPrntInpObject> _itestRefPrntInp = encoders.EncoderFor<ItestRefPrntInpObject>();
  public IGqlpValue Encode(ItestPrntInpObject input)
    => _itestRefPrntInp.Encode(input);

  internal static testPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntInpEncoder : IEncoder<ItestRefPrntInpObject>
{
  public IGqlpValue Encode(ItestRefPrntInpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpObject>
{
  private readonly Encoder<ItestRefPrntOutpObject> _itestRefPrntOutp = encoders.EncoderFor<ItestRefPrntOutpObject>();
  public IGqlpValue Encode(ItestPrntOutpObject input)
    => _itestRefPrntOutp.Encode(input);

  internal static testPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntOutpEncoder : IEncoder<ItestRefPrntOutpObject>
{
  public IGqlpValue Encode(ItestRefPrntOutpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntAltDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltDualObject>
{
  private readonly Encoder<ItestRefPrntAltDualObject> _itestRefPrntAltDual = encoders.EncoderFor<ItestRefPrntAltDualObject>();
  public IGqlpValue Encode(ItestPrntAltDualObject input)
    => _itestRefPrntAltDual.Encode(input);

  internal static testPrntAltDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltDualEncoder : IEncoder<ItestRefPrntAltDualObject>
{
  public IGqlpValue Encode(ItestRefPrntAltDualObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntAltInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltInpObject>
{
  private readonly Encoder<ItestRefPrntAltInpObject> _itestRefPrntAltInp = encoders.EncoderFor<ItestRefPrntAltInpObject>();
  public IGqlpValue Encode(ItestPrntAltInpObject input)
    => _itestRefPrntAltInp.Encode(input);

  internal static testPrntAltInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltInpEncoder : IEncoder<ItestRefPrntAltInpObject>
{
  public IGqlpValue Encode(ItestRefPrntAltInpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntAltOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltOutpObject>
{
  private readonly Encoder<ItestRefPrntAltOutpObject> _itestRefPrntAltOutp = encoders.EncoderFor<ItestRefPrntAltOutpObject>();
  public IGqlpValue Encode(ItestPrntAltOutpObject input)
    => _itestRefPrntAltOutp.Encode(input);

  internal static testPrntAltOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltOutpEncoder : IEncoder<ItestRefPrntAltOutpObject>
{
  public IGqlpValue Encode(ItestRefPrntAltOutpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDescrDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrDualObject>
{
  private readonly Encoder<ItestRefPrntDescrDualObject> _itestRefPrntDescrDual = encoders.EncoderFor<ItestRefPrntDescrDualObject>();
  public IGqlpValue Encode(ItestPrntDescrDualObject input)
    => _itestRefPrntDescrDual.Encode(input);

  internal static testPrntDescrDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDescrDualEncoder : IEncoder<ItestRefPrntDescrDualObject>
{
  public IGqlpValue Encode(ItestRefPrntDescrDualObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDescrInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrInpObject>
{
  private readonly Encoder<ItestRefPrntDescrInpObject> _itestRefPrntDescrInp = encoders.EncoderFor<ItestRefPrntDescrInpObject>();
  public IGqlpValue Encode(ItestPrntDescrInpObject input)
    => _itestRefPrntDescrInp.Encode(input);

  internal static testPrntDescrInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDescrInpEncoder : IEncoder<ItestRefPrntDescrInpObject>
{
  public IGqlpValue Encode(ItestRefPrntDescrInpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDescrOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrOutpObject>
{
  private readonly Encoder<ItestRefPrntDescrOutpObject> _itestRefPrntDescrOutp = encoders.EncoderFor<ItestRefPrntDescrOutpObject>();
  public IGqlpValue Encode(ItestPrntDescrOutpObject input)
    => _itestRefPrntDescrOutp.Encode(input);

  internal static testPrntDescrOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDescrOutpEncoder : IEncoder<ItestRefPrntDescrOutpObject>
{
  public IGqlpValue Encode(ItestRefPrntDescrOutpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualDualObject>
{
  private readonly Encoder<ItestRefPrntDualDualObject> _itestRefPrntDualDual = encoders.EncoderFor<ItestRefPrntDualDualObject>();
  public IGqlpValue Encode(ItestPrntDualDualObject input)
    => _itestRefPrntDualDual.Encode(input);

  internal static testPrntDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualDualEncoder : IEncoder<ItestRefPrntDualDualObject>
{
  public IGqlpValue Encode(ItestRefPrntDualDualObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualInpObject>
{
  private readonly Encoder<ItestRefPrntDualInpObject> _itestRefPrntDualInp = encoders.EncoderFor<ItestRefPrntDualInpObject>();
  public IGqlpValue Encode(ItestPrntDualInpObject input)
    => _itestRefPrntDualInp.Encode(input);

  internal static testPrntDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualInpEncoder : IEncoder<ItestRefPrntDualInpObject>
{
  public IGqlpValue Encode(ItestRefPrntDualInpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualOutpObject>
{
  private readonly Encoder<ItestRefPrntDualOutpObject> _itestRefPrntDualOutp = encoders.EncoderFor<ItestRefPrntDualOutpObject>();
  public IGqlpValue Encode(ItestPrntDualOutpObject input)
    => _itestRefPrntDualOutp.Encode(input);

  internal static testPrntDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualOutpEncoder : IEncoder<ItestRefPrntDualOutpObject>
{
  public IGqlpValue Encode(ItestRefPrntDualOutpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldDualObject>
{
  private readonly Encoder<ItestRefPrntFieldDualObject> _itestRefPrntFieldDual = encoders.EncoderFor<ItestRefPrntFieldDualObject>();
  public IGqlpValue Encode(ItestPrntFieldDualObject input)
    => _itestRefPrntFieldDual.Encode(input)
      .Add("field", input.Field.Encode());

  internal static testPrntFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldDualEncoder : IEncoder<ItestRefPrntFieldDualObject>
{
  public IGqlpValue Encode(ItestRefPrntFieldDualObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldInpObject>
{
  private readonly Encoder<ItestRefPrntFieldInpObject> _itestRefPrntFieldInp = encoders.EncoderFor<ItestRefPrntFieldInpObject>();
  public IGqlpValue Encode(ItestPrntFieldInpObject input)
    => _itestRefPrntFieldInp.Encode(input)
      .Add("field", input.Field.Encode());

  internal static testPrntFieldInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldInpEncoder : IEncoder<ItestRefPrntFieldInpObject>
{
  public IGqlpValue Encode(ItestRefPrntFieldInpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldOutpObject>
{
  private readonly Encoder<ItestRefPrntFieldOutpObject> _itestRefPrntFieldOutp = encoders.EncoderFor<ItestRefPrntFieldOutpObject>();
  public IGqlpValue Encode(ItestPrntFieldOutpObject input)
    => _itestRefPrntFieldOutp.Encode(input)
      .Add("field", input.Field.Encode());

  internal static testPrntFieldOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldOutpEncoder : IEncoder<ItestRefPrntFieldOutpObject>
{
  public IGqlpValue Encode(ItestRefPrntFieldOutpObject input)
    => new GqlpUnit()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntParamDiffDualEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffDualObject<TA>>
{
  private readonly Encoder<ItestRefPrntParamDiffDualObject<TA>> _itestRefPrntParamDiffDual = encoders.EncoderFor<ItestRefPrntParamDiffDualObject<TA>>();
  private readonly Encoder<TA> _a = encoders.EncoderFor<TA>();
  public IGqlpValue Encode(ItestPrntParamDiffDualObject<TA> input)
    => _itestRefPrntParamDiffDual.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffDualEncoder<TB> : IEncoder<ItestRefPrntParamDiffDualObject<TB>>
{
  public IGqlpValue Encode(ItestRefPrntParamDiffDualObject<TB> input)
    => new GqlpUnit();
}

internal class testPrntParamDiffInpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffInpObject<TA>>
{
  private readonly Encoder<ItestRefPrntParamDiffInpObject<TA>> _itestRefPrntParamDiffInp = encoders.EncoderFor<ItestRefPrntParamDiffInpObject<TA>>();
  private readonly Encoder<TA> _a = encoders.EncoderFor<TA>();
  public IGqlpValue Encode(ItestPrntParamDiffInpObject<TA> input)
    => _itestRefPrntParamDiffInp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffInpEncoder<TB> : IEncoder<ItestRefPrntParamDiffInpObject<TB>>
{
  public IGqlpValue Encode(ItestRefPrntParamDiffInpObject<TB> input)
    => new GqlpUnit();
}

internal class testPrntParamDiffOutpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffOutpObject<TA>>
{
  private readonly Encoder<ItestRefPrntParamDiffOutpObject<TA>> _itestRefPrntParamDiffOutp = encoders.EncoderFor<ItestRefPrntParamDiffOutpObject<TA>>();
  private readonly Encoder<TA> _a = encoders.EncoderFor<TA>();
  public IGqlpValue Encode(ItestPrntParamDiffOutpObject<TA> input)
    => _itestRefPrntParamDiffOutp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffOutpEncoder<TB> : IEncoder<ItestRefPrntParamDiffOutpObject<TB>>
{
  public IGqlpValue Encode(ItestRefPrntParamDiffOutpObject<TB> input)
    => new GqlpUnit();
}

internal class testPrntParamSameDualEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameDualObject<TA>>
{
  private readonly Encoder<ItestRefPrntParamSameDualObject<TA>> _itestRefPrntParamSameDual = encoders.EncoderFor<ItestRefPrntParamSameDualObject<TA>>();
  private readonly Encoder<TA> _a = encoders.EncoderFor<TA>();
  public IGqlpValue Encode(ItestPrntParamSameDualObject<TA> input)
    => _itestRefPrntParamSameDual.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameDualEncoder<TA> : IEncoder<ItestRefPrntParamSameDualObject<TA>>
{
  public IGqlpValue Encode(ItestRefPrntParamSameDualObject<TA> input)
    => new GqlpUnit();
}

internal class testPrntParamSameInpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameInpObject<TA>>
{
  private readonly Encoder<ItestRefPrntParamSameInpObject<TA>> _itestRefPrntParamSameInp = encoders.EncoderFor<ItestRefPrntParamSameInpObject<TA>>();
  private readonly Encoder<TA> _a = encoders.EncoderFor<TA>();
  public IGqlpValue Encode(ItestPrntParamSameInpObject<TA> input)
    => _itestRefPrntParamSameInp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameInpEncoder<TA> : IEncoder<ItestRefPrntParamSameInpObject<TA>>
{
  public IGqlpValue Encode(ItestRefPrntParamSameInpObject<TA> input)
    => new GqlpUnit();
}

internal class testPrntParamSameOutpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameOutpObject<TA>>
{
  private readonly Encoder<ItestRefPrntParamSameOutpObject<TA>> _itestRefPrntParamSameOutp = encoders.EncoderFor<ItestRefPrntParamSameOutpObject<TA>>();
  private readonly Encoder<TA> _a = encoders.EncoderFor<TA>();
  public IGqlpValue Encode(ItestPrntParamSameOutpObject<TA> input)
    => _itestRefPrntParamSameOutp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameOutpEncoder<TA> : IEncoder<ItestRefPrntParamSameOutpObject<TA>>
{
  public IGqlpValue Encode(ItestRefPrntParamSameOutpObject<TA> input)
    => new GqlpUnit();
}

internal class testCtgrEncoder : IEncoder<ItestCtgrObject>
{
  public IGqlpValue Encode(ItestCtgrObject input)
    => new GqlpUnit();

  internal static testCtgrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrAliasEncoder : IEncoder<ItestCtgrAliasObject>
{
  public IGqlpValue Encode(ItestCtgrAliasObject input)
    => new GqlpUnit();

  internal static testCtgrAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrDescrEncoder : IEncoder<ItestCtgrDescrObject>
{
  public IGqlpValue Encode(ItestCtgrDescrObject input)
    => new GqlpUnit();

  internal static testCtgrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrModEncoder : IEncoder<ItestCtgrModObject>
{
  public IGqlpValue Encode(ItestCtgrModObject input)
    => new GqlpUnit();

  internal static testCtgrModEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamEncoder : IEncoder<ItestInDrctParamObject>
{
  public IGqlpValue Encode(ItestInDrctParamObject input)
    => new GqlpUnit();

  internal static testInDrctParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public IGqlpValue Encode(ItestDmnAlias input)
    => input.Value!.Encode();

  internal static testDmnAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public IGqlpValue Encode(ItestDmnBool input)
    => input.Value!.Encode();

  internal static testDmnBoolEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolDiffEncoder : IEncoder<ItestDmnBoolDiff>
{
  public IGqlpValue Encode(ItestDmnBoolDiff input)
    => input.Value!.Encode();

  internal static testDmnBoolDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolSameEncoder : IEncoder<ItestDmnBoolSame>
{
  public IGqlpValue Encode(ItestDmnBoolSame input)
    => input.Value!.Encode();

  internal static testDmnBoolSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public IGqlpValue Encode(ItestDmnEnumDiff input)
    => input.Value?.EncodeEnum("bool")!;

  internal static testDmnEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumSameEncoder : IEncoder<ItestDmnEnumSame>
{
  public IGqlpValue Encode(ItestDmnEnumSame input)
    => input.Value?.EncodeEnum("bool")!;

  internal static testDmnEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrEncoder : IEncoder<ItestDmnNmbr>
{
  public IGqlpValue Encode(ItestDmnNmbr input)
    => input.Value!.Encode();

  internal static testDmnNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrDiffEncoder : IEncoder<ItestDmnNmbrDiff>
{
  public IGqlpValue Encode(ItestDmnNmbrDiff input)
    => input.Value!.Encode();

  internal static testDmnNmbrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrSameEncoder : IEncoder<ItestDmnNmbrSame>
{
  public IGqlpValue Encode(ItestDmnNmbrSame input)
    => input.Value!.Encode();

  internal static testDmnNmbrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrEncoder : IEncoder<ItestDmnStr>
{
  public IGqlpValue Encode(ItestDmnStr input)
    => input.Value!.Encode();

  internal static testDmnStrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrDiffEncoder : IEncoder<ItestDmnStrDiff>
{
  public IGqlpValue Encode(ItestDmnStrDiff input)
    => input.Value!.Encode();

  internal static testDmnStrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrSameEncoder : IEncoder<ItestDmnStrSame>
{
  public IGqlpValue Encode(ItestDmnStrSame input)
    => input.Value!.Encode();

  internal static testDmnStrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public IGqlpValue Encode(testEnumAlias input)
    => input.EncodeEnum("EnumAlias");

  internal static testEnumAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDiffEncoder : IEncoder<testEnumDiff>
{
  public IGqlpValue Encode(testEnumDiff input)
    => input.EncodeEnum("EnumDiff");

  internal static testEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSameEncoder : IEncoder<testEnumSame>
{
  public IGqlpValue Encode(testEnumSame input)
    => input.EncodeEnum("EnumSame");

  internal static testEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSamePrntEncoder : IEncoder<testEnumSamePrnt>
{
  public IGqlpValue Encode(testEnumSamePrnt input)
    => input.EncodeEnum("EnumSamePrnt");

  internal static testEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumSamePrntEncoder : IEncoder<testPrntEnumSamePrnt>
{
  public IGqlpValue Encode(testPrntEnumSamePrnt input)
    => input.EncodeEnum("PrntEnumSamePrnt");

  internal static testPrntEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumValueAliasEncoder : IEncoder<testEnumValueAlias>
{
  public IGqlpValue Encode(testEnumValueAlias input)
    => input.EncodeEnum("EnumValueAlias");

  internal static testEnumValueAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualEncoder : IEncoder<ItestObjDualObject>
{
  public IGqlpValue Encode(ItestObjDualObject input)
    => new GqlpUnit();

  internal static testObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjInpEncoder : IEncoder<ItestObjInpObject>
{
  public IGqlpValue Encode(ItestObjInpObject input)
    => new GqlpUnit();

  internal static testObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjOutpEncoder : IEncoder<ItestObjOutpObject>
{
  public IGqlpValue Encode(ItestObjOutpObject input)
    => new GqlpUnit();

  internal static testObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasDualEncoder : IEncoder<ItestObjAliasDualObject>
{
  public IGqlpValue Encode(ItestObjAliasDualObject input)
    => new GqlpUnit();

  internal static testObjAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasInpEncoder : IEncoder<ItestObjAliasInpObject>
{
  public IGqlpValue Encode(ItestObjAliasInpObject input)
    => new GqlpUnit();

  internal static testObjAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasOutpEncoder : IEncoder<ItestObjAliasOutpObject>
{
  public IGqlpValue Encode(ItestObjAliasOutpObject input)
    => new GqlpUnit();

  internal static testObjAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltDualEncoder : IEncoder<ItestObjAltDualObject>
{
  public IGqlpValue Encode(ItestObjAltDualObject input)
    => new GqlpUnit();

  internal static testObjAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltDualTypeEncoder : IEncoder<ItestObjAltDualTypeObject>
{
  public IGqlpValue Encode(ItestObjAltDualTypeObject input)
    => new GqlpUnit();

  internal static testObjAltDualTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltInpEncoder : IEncoder<ItestObjAltInpObject>
{
  public IGqlpValue Encode(ItestObjAltInpObject input)
    => new GqlpUnit();

  internal static testObjAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltInpTypeEncoder : IEncoder<ItestObjAltInpTypeObject>
{
  public IGqlpValue Encode(ItestObjAltInpTypeObject input)
    => new GqlpUnit();

  internal static testObjAltInpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltOutpEncoder : IEncoder<ItestObjAltOutpObject>
{
  public IGqlpValue Encode(ItestObjAltOutpObject input)
    => new GqlpUnit();

  internal static testObjAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltOutpTypeEncoder : IEncoder<ItestObjAltOutpTypeObject>
{
  public IGqlpValue Encode(ItestObjAltOutpTypeObject input)
    => new GqlpUnit();

  internal static testObjAltOutpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumDualEncoder : IEncoder<ItestObjAltEnumDualObject>
{
  public IGqlpValue Encode(ItestObjAltEnumDualObject input)
    => new GqlpUnit();

  internal static testObjAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumInpEncoder : IEncoder<ItestObjAltEnumInpObject>
{
  public IGqlpValue Encode(ItestObjAltEnumInpObject input)
    => new GqlpUnit();

  internal static testObjAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumOutpEncoder : IEncoder<ItestObjAltEnumOutpObject>
{
  public IGqlpValue Encode(ItestObjAltEnumOutpObject input)
    => new GqlpUnit();

  internal static testObjAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjCnstDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstDualObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestObjCnstDualObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjCnstInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstInpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestObjCnstInpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjCnstOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstOutpObject<TType>>
{
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestObjCnstOutpObject<TType> input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldDualObject>
{
  private readonly Encoder<ItestFldObjFieldDual> _itestFldObjFieldDual = encoders.EncoderFor<ItestFldObjFieldDual>();
  public IGqlpValue Encode(ItestObjFieldDualObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldObjFieldDual);

  internal static testObjFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldDualEncoder : IEncoder<ItestFldObjFieldDualObject>
{
  public IGqlpValue Encode(ItestFldObjFieldDualObject input)
    => new GqlpUnit();

  internal static testFldObjFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldInpObject>
{
  private readonly Encoder<ItestFldObjFieldInp> _itestFldObjFieldInp = encoders.EncoderFor<ItestFldObjFieldInp>();
  public IGqlpValue Encode(ItestObjFieldInpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldObjFieldInp);

  internal static testObjFieldInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldInpEncoder : IEncoder<ItestFldObjFieldInpObject>
{
  public IGqlpValue Encode(ItestFldObjFieldInpObject input)
    => new GqlpUnit();

  internal static testFldObjFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldOutpObject>
{
  private readonly Encoder<ItestFldObjFieldOutp> _itestFldObjFieldOutp = encoders.EncoderFor<ItestFldObjFieldOutp>();
  public IGqlpValue Encode(ItestObjFieldOutpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldObjFieldOutp);

  internal static testObjFieldOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldOutpEncoder : IEncoder<ItestFldObjFieldOutpObject>
{
  public IGqlpValue Encode(ItestFldObjFieldOutpObject input)
    => new GqlpUnit();

  internal static testFldObjFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasDualObject>
{
  private readonly Encoder<ItestFldObjFieldAliasDual> _itestFldObjFieldAliasDual = encoders.EncoderFor<ItestFldObjFieldAliasDual>();
  public IGqlpValue Encode(ItestObjFieldAliasDualObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasDual);

  internal static testObjFieldAliasDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasDualEncoder : IEncoder<ItestFldObjFieldAliasDualObject>
{
  public IGqlpValue Encode(ItestFldObjFieldAliasDualObject input)
    => new GqlpUnit();

  internal static testFldObjFieldAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasInpObject>
{
  private readonly Encoder<ItestFldObjFieldAliasInp> _itestFldObjFieldAliasInp = encoders.EncoderFor<ItestFldObjFieldAliasInp>();
  public IGqlpValue Encode(ItestObjFieldAliasInpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasInp);

  internal static testObjFieldAliasInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasInpEncoder : IEncoder<ItestFldObjFieldAliasInpObject>
{
  public IGqlpValue Encode(ItestFldObjFieldAliasInpObject input)
    => new GqlpUnit();

  internal static testFldObjFieldAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasOutpObject>
{
  private readonly Encoder<ItestFldObjFieldAliasOutp> _itestFldObjFieldAliasOutp = encoders.EncoderFor<ItestFldObjFieldAliasOutp>();
  public IGqlpValue Encode(ItestObjFieldAliasOutpObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasOutp);

  internal static testObjFieldAliasOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasOutpEncoder : IEncoder<ItestFldObjFieldAliasOutpObject>
{
  public IGqlpValue Encode(ItestFldObjFieldAliasOutpObject input)
    => new GqlpUnit();

  internal static testFldObjFieldAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualEncoder : IEncoder<ItestObjFieldEnumAliasDualObject>
{
  public IGqlpValue Encode(ItestObjFieldEnumAliasDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpEncoder : IEncoder<ItestObjFieldEnumAliasInpObject>
{
  public IGqlpValue Encode(ItestObjFieldEnumAliasInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasOutpEncoder : IEncoder<ItestObjFieldEnumAliasOutpObject>
{
  public IGqlpValue Encode(ItestObjFieldEnumAliasOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueDualEncoder : IEncoder<ItestObjFieldEnumValueDualObject>
{
  public IGqlpValue Encode(ItestObjFieldEnumValueDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueInpEncoder : IEncoder<ItestObjFieldEnumValueInpObject>
{
  public IGqlpValue Encode(ItestObjFieldEnumValueInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueOutpEncoder : IEncoder<ItestObjFieldEnumValueOutpObject>
{
  public IGqlpValue Encode(ItestObjFieldEnumValueOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualEncoder : IEncoder<ItestObjFieldTypeAliasDualObject>
{
  public IGqlpValue Encode(ItestObjFieldTypeAliasDualObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpEncoder : IEncoder<ItestObjFieldTypeAliasInpObject>
{
  public IGqlpValue Encode(ItestObjFieldTypeAliasInpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public IGqlpValue Encode(ItestObjFieldTypeAliasOutpObject input)
    => new GqlpUnit()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjParamDualEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDualObject<TTest,TType>>
{
  private readonly Encoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestObjParamDualObject<TTest,TType> input)
    => new GqlpUnit()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamInpEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamInpObject<TTest,TType>>
{
  private readonly Encoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestObjParamInpObject<TTest,TType> input)
    => new GqlpUnit()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamOutpEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamOutpObject<TTest,TType>>
{
  private readonly Encoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly Encoder<TType> _type = encoders.EncoderFor<TType>();
  public IGqlpValue Encode(ItestObjParamOutpObject<TTest,TType> input)
    => new GqlpUnit()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamDupDualEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupDualObject<TTest>>
{
  private readonly Encoder<TTest> _test = encoders.EncoderFor<TTest>();
  public IGqlpValue Encode(ItestObjParamDupDualObject<TTest> input)
    => new GqlpUnit()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjParamDupInpEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupInpObject<TTest>>
{
  private readonly Encoder<TTest> _test = encoders.EncoderFor<TTest>();
  public IGqlpValue Encode(ItestObjParamDupInpObject<TTest> input)
    => new GqlpUnit()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjParamDupOutpEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupOutpObject<TTest>>
{
  private readonly Encoder<TTest> _test = encoders.EncoderFor<TTest>();
  public IGqlpValue Encode(ItestObjParamDupOutpObject<TTest> input)
    => new GqlpUnit()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntDualObject>
{
  private readonly Encoder<ItestRefObjPrntDualObject> _itestRefObjPrntDual = encoders.EncoderFor<ItestRefObjPrntDualObject>();
  public IGqlpValue Encode(ItestObjPrntDualObject input)
    => _itestRefObjPrntDual.Encode(input);

  internal static testObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntDualEncoder : IEncoder<ItestRefObjPrntDualObject>
{
  public IGqlpValue Encode(ItestRefObjPrntDualObject input)
    => new GqlpUnit();

  internal static testRefObjPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntInpObject>
{
  private readonly Encoder<ItestRefObjPrntInpObject> _itestRefObjPrntInp = encoders.EncoderFor<ItestRefObjPrntInpObject>();
  public IGqlpValue Encode(ItestObjPrntInpObject input)
    => _itestRefObjPrntInp.Encode(input);

  internal static testObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntInpEncoder : IEncoder<ItestRefObjPrntInpObject>
{
  public IGqlpValue Encode(ItestRefObjPrntInpObject input)
    => new GqlpUnit();

  internal static testRefObjPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntOutpObject>
{
  private readonly Encoder<ItestRefObjPrntOutpObject> _itestRefObjPrntOutp = encoders.EncoderFor<ItestRefObjPrntOutpObject>();
  public IGqlpValue Encode(ItestObjPrntOutpObject input)
    => _itestRefObjPrntOutp.Encode(input);

  internal static testObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntOutpEncoder : IEncoder<ItestRefObjPrntOutpObject>
{
  public IGqlpValue Encode(ItestRefObjPrntOutpObject input)
    => new GqlpUnit();

  internal static testRefObjPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testOpEncoder : IEncoder<ItestOpObject>
{
  public IGqlpValue Encode(ItestOpObject input)
    => new GqlpUnit();

  internal static testOpEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpFieldParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpFieldParamObject>
{
  private readonly Encoder<ItestFldOutpFieldParam> _itestFldOutpFieldParam = encoders.EncoderFor<ItestFldOutpFieldParam>();
  public IGqlpValue Encode(ItestOutpFieldParamObject input)
    => new GqlpUnit()
      .AddEncoded("field", input.Field(), _itestFldOutpFieldParam);

  internal static testOutpFieldParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testOutpFieldParam1Encoder : IEncoder<ItestOutpFieldParam1Object>
{
  public IGqlpValue Encode(ItestOutpFieldParam1Object input)
    => new GqlpUnit();

  internal static testOutpFieldParam1Encoder Factory(IEncoderRepository _) => new();
}

internal class testOutpFieldParam2Encoder : IEncoder<ItestOutpFieldParam2Object>
{
  public IGqlpValue Encode(ItestOutpFieldParam2Object input)
    => new GqlpUnit();

  internal static testOutpFieldParam2Encoder Factory(IEncoderRepository _) => new();
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public IGqlpValue Encode(ItestFldOutpFieldParamObject input)
    => new GqlpUnit();

  internal static testFldOutpFieldParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testUnionAliasEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionAlias>
{
  private readonly Encoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestUnionAlias input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testUnionAliasEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionDiffEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDiff>
{
  private readonly Encoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestUnionDiff input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testUnionDiffEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionSameEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSame>
{
  private readonly Encoder<bool> _boolean = encoders.EncoderFor<bool>();
  public IGqlpValue Encode(ItestUnionSame input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : new GqlpUnit();

  internal static testUnionSameEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSamePrnt>
{
  private readonly Encoder<bool> _boolean = encoders.EncoderFor<bool>();
  public IGqlpValue Encode(ItestUnionSamePrnt input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : new GqlpUnit();

  internal static testUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionSamePrnt>
{
  private readonly Encoder<string> _string = encoders.EncoderFor<string>();
  public IGqlpValue Encode(ItestPrntUnionSamePrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : new GqlpUnit();

  internal static testPrntUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testDmnBoolDescrEncoder : IEncoder<ItestDmnBoolDescr>
{
  public IGqlpValue Encode(ItestDmnBoolDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolPrntEncoder : IEncoder<ItestDmnBoolPrnt>
{
  public IGqlpValue Encode(ItestDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntEncoder : IEncoder<ItestPrntDmnBoolPrnt>
{
  public IGqlpValue Encode(ItestPrntDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolPrntDescrEncoder : IEncoder<ItestDmnBoolPrntDescr>
{
  public IGqlpValue Encode(ItestDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrEncoder : IEncoder<ItestPrntDmnBoolPrntDescr>
{
  public IGqlpValue Encode(ItestPrntDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllEncoder : IEncoder<ItestDmnEnumAll>
{
  public IGqlpValue Encode(ItestDmnEnumAll input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAll")!;

  internal static testDmnEnumAllEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllEncoder : IEncoder<testEnumDmnEnumAll>
{
  public IGqlpValue Encode(testEnumDmnEnumAll input)
    => input.EncodeEnum("EnumDmnEnumAll");

  internal static testEnumDmnEnumAllEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllDescrEncoder : IEncoder<ItestDmnEnumAllDescr>
{
  public IGqlpValue Encode(ItestDmnEnumAllDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAllDescr")!;

  internal static testDmnEnumAllDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrEncoder : IEncoder<testEnumDmnEnumAllDescr>
{
  public IGqlpValue Encode(testEnumDmnEnumAllDescr input)
    => input.EncodeEnum("EnumDmnEnumAllDescr");

  internal static testEnumDmnEnumAllDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllPrntEncoder : IEncoder<ItestDmnEnumAllPrnt>
{
  public IGqlpValue Encode(ItestDmnEnumAllPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAllPrnt")!;

  internal static testDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntEncoder : IEncoder<testEnumDmnEnumAllPrnt>
{
  public IGqlpValue Encode(testEnumDmnEnumAllPrnt input)
    => input.EncodeEnum("EnumDmnEnumAllPrnt");

  internal static testEnumDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntEncoder : IEncoder<testPrntDmnEnumAllPrnt>
{
  public IGqlpValue Encode(testPrntDmnEnumAllPrnt input)
    => input.EncodeEnum("PrntDmnEnumAllPrnt");

  internal static testPrntDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumDescrEncoder : IEncoder<ItestDmnEnumDescr>
{
  public IGqlpValue Encode(ItestDmnEnumDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumDescr")!;

  internal static testDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumDescrEncoder : IEncoder<testEnumDmnEnumDescr>
{
  public IGqlpValue Encode(testEnumDmnEnumDescr input)
    => input.EncodeEnum("EnumDmnEnumDescr");

  internal static testEnumDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumExclEncoder : IEncoder<ItestDmnEnumExcl>
{
  public IGqlpValue Encode(ItestDmnEnumExcl input)
    => input.Value?.EncodeEnum("testEnumDmnEnumExcl")!;

  internal static testDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumExclEncoder : IEncoder<testEnumDmnEnumExcl>
{
  public IGqlpValue Encode(testEnumDmnEnumExcl input)
    => input.EncodeEnum("EnumDmnEnumExcl");

  internal static testEnumDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumExclPrntEncoder : IEncoder<ItestDmnEnumExclPrnt>
{
  public IGqlpValue Encode(ItestDmnEnumExclPrnt input)
    => input.Value?.EncodeEnum("DmnEnumExclPrnt")!;

  internal static testDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntEncoder : IEncoder<testEnumDmnEnumExclPrnt>
{
  public IGqlpValue Encode(testEnumDmnEnumExclPrnt input)
    => input.EncodeEnum("EnumDmnEnumExclPrnt");

  internal static testEnumDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntEncoder : IEncoder<testPrntDmnEnumExclPrnt>
{
  public IGqlpValue Encode(testPrntDmnEnumExclPrnt input)
    => input.EncodeEnum("PrntDmnEnumExclPrnt");

  internal static testPrntDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumLabelEncoder : IEncoder<ItestDmnEnumLabel>
{
  public IGqlpValue Encode(ItestDmnEnumLabel input)
    => input.Value?.EncodeEnum("testEnumDmnEnumLabel")!;

  internal static testDmnEnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumLabelEncoder : IEncoder<testEnumDmnEnumLabel>
{
  public IGqlpValue Encode(testEnumDmnEnumLabel input)
    => input.EncodeEnum("EnumDmnEnumLabel");

  internal static testEnumDmnEnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumPrntEncoder : IEncoder<ItestDmnEnumPrnt>
{
  public IGqlpValue Encode(ItestDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt")!;

  internal static testDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntEncoder : IEncoder<ItestPrntDmnEnumPrnt>
{
  public IGqlpValue Encode(ItestPrntDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt")!;

  internal static testPrntDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntEncoder : IEncoder<testEnumDmnEnumPrnt>
{
  public IGqlpValue Encode(testEnumDmnEnumPrnt input)
    => input.EncodeEnum("EnumDmnEnumPrnt");

  internal static testEnumDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumPrntDescrEncoder : IEncoder<ItestDmnEnumPrntDescr>
{
  public IGqlpValue Encode(ItestDmnEnumPrntDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrntDescr")!;

  internal static testDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrEncoder : IEncoder<ItestPrntDmnEnumPrntDescr>
{
  public IGqlpValue Encode(ItestPrntDmnEnumPrntDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrntDescr")!;

  internal static testPrntDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrEncoder : IEncoder<testEnumDmnEnumPrntDescr>
{
  public IGqlpValue Encode(testEnumDmnEnumPrntDescr input)
    => input.EncodeEnum("EnumDmnEnumPrntDescr");

  internal static testEnumDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumUnqEncoder : IEncoder<ItestDmnEnumUnq>
{
  public IGqlpValue Encode(ItestDmnEnumUnq input)
    => input.Value?.EncodeEnum("DmnEnumUnq")!;

  internal static testDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqEncoder : IEncoder<testEnumDmnEnumUnq>
{
  public IGqlpValue Encode(testEnumDmnEnumUnq input)
    => input.EncodeEnum("EnumDmnEnumUnq");

  internal static testEnumDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqEncoder : IEncoder<testDupDmnEnumUnq>
{
  public IGqlpValue Encode(testDupDmnEnumUnq input)
    => input.EncodeEnum("DupDmnEnumUnq");

  internal static testDupDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumUnqPrntEncoder : IEncoder<ItestDmnEnumUnqPrnt>
{
  public IGqlpValue Encode(ItestDmnEnumUnqPrnt input)
    => input.Value?.EncodeEnum("DmnEnumUnqPrnt")!;

  internal static testDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public IGqlpValue Encode(testEnumDmnEnumUnqPrnt input)
    => input.EncodeEnum("EnumDmnEnumUnqPrnt");

  internal static testEnumDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public IGqlpValue Encode(testPrntDmnEnumUnqPrnt input)
    => input.EncodeEnum("PrntDmnEnumUnqPrnt");

  internal static testPrntDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public IGqlpValue Encode(testDupDmnEnumUnqPrnt input)
    => input.EncodeEnum("DupDmnEnumUnqPrnt");

  internal static testDupDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumValueEncoder : IEncoder<ItestDmnEnumValue>
{
  public IGqlpValue Encode(ItestDmnEnumValue input)
    => input.Value?.EncodeEnum("testEnumDmnEnumValue")!;

  internal static testDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValueEncoder : IEncoder<testEnumDmnEnumValue>
{
  public IGqlpValue Encode(testEnumDmnEnumValue input)
    => input.EncodeEnum("EnumDmnEnumValue");

  internal static testEnumDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumValuePrntEncoder : IEncoder<ItestDmnEnumValuePrnt>
{
  public IGqlpValue Encode(ItestDmnEnumValuePrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumValuePrnt")!;

  internal static testDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntEncoder : IEncoder<testEnumDmnEnumValuePrnt>
{
  public IGqlpValue Encode(testEnumDmnEnumValuePrnt input)
    => input.EncodeEnum("EnumDmnEnumValuePrnt");

  internal static testEnumDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntEncoder : IEncoder<testPrntDmnEnumValuePrnt>
{
  public IGqlpValue Encode(testPrntDmnEnumValuePrnt input)
    => input.EncodeEnum("PrntDmnEnumValuePrnt");

  internal static testPrntDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrDescrEncoder : IEncoder<ItestDmnNmbrDescr>
{
  public IGqlpValue Encode(ItestDmnNmbrDescr input)
    => input.Value!.Encode();

  internal static testDmnNmbrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPrntEncoder : IEncoder<ItestDmnNmbrPrnt>
{
  public IGqlpValue Encode(ItestDmnNmbrPrnt input)
    => input.Value!.Encode();

  internal static testDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntEncoder : IEncoder<ItestPrntDmnNmbrPrnt>
{
  public IGqlpValue Encode(ItestPrntDmnNmbrPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testRegexDmnNmbrPrntEncoder : IEncoder<ItestRegexDmnNmbrPrnt>
{
  public IGqlpValue Encode(ItestRegexDmnNmbrPrnt input)
    => input.Value!.Encode();

  internal static testRegexDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPrntDescrEncoder : IEncoder<ItestDmnNmbrPrntDescr>
{
  public IGqlpValue Encode(ItestDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrEncoder : IEncoder<ItestPrntDmnNmbrPrntDescr>
{
  public IGqlpValue Encode(ItestPrntDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPstvEncoder : IEncoder<ItestDmnNmbrPstv>
{
  public IGqlpValue Encode(ItestDmnNmbrPstv input)
    => input.Value!.Encode();

  internal static testDmnNmbrPstvEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrRangeEncoder : IEncoder<ItestDmnNmbrRange>
{
  public IGqlpValue Encode(ItestDmnNmbrRange input)
    => input.Value!.Encode();

  internal static testDmnNmbrRangeEncoder Factory(IEncoderRepository _) => new();
}

internal class testRegexDmnNmbrRangeEncoder : IEncoder<ItestRegexDmnNmbrRange>
{
  public IGqlpValue Encode(ItestRegexDmnNmbrRange input)
    => input.Value!.Encode();

  internal static testRegexDmnNmbrRangeEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrDescrEncoder : IEncoder<ItestDmnStrDescr>
{
  public IGqlpValue Encode(ItestDmnStrDescr input)
    => input.Value!.Encode();

  internal static testDmnStrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrNonEmptyEncoder : IEncoder<ItestDmnStrNonEmpty>
{
  public IGqlpValue Encode(ItestDmnStrNonEmpty input)
    => input.Value!.Encode();

  internal static testDmnStrNonEmptyEncoder Factory(IEncoderRepository _) => new();
}

internal class testRegexDmnStrNonEmptyEncoder : IEncoder<ItestRegexDmnStrNonEmpty>
{
  public IGqlpValue Encode(ItestRegexDmnStrNonEmpty input)
    => input.Value!.Encode();

  internal static testRegexDmnStrNonEmptyEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrPrntEncoder : IEncoder<ItestDmnStrPrnt>
{
  public IGqlpValue Encode(ItestDmnStrPrnt input)
    => input.Value!.Encode();

  internal static testDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntEncoder : IEncoder<ItestPrntDmnStrPrnt>
{
  public IGqlpValue Encode(ItestPrntDmnStrPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testRegexDmnStrPrntEncoder : IEncoder<ItestRegexDmnStrPrnt>
{
  public IGqlpValue Encode(ItestRegexDmnStrPrnt input)
    => input.Value!.Encode();

  internal static testRegexDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrPrntDescrEncoder : IEncoder<ItestDmnStrPrntDescr>
{
  public IGqlpValue Encode(ItestDmnStrPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrEncoder : IEncoder<ItestPrntDmnStrPrntDescr>
{
  public IGqlpValue Encode(ItestPrntDmnStrPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDescrEncoder : IEncoder<testEnumDescr>
{
  public IGqlpValue Encode(testEnumDescr input)
    => input.EncodeEnum("EnumDescr");

  internal static testEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntEncoder : IEncoder<testEnumPrnt>
{
  public IGqlpValue Encode(testEnumPrnt input)
    => input.EncodeEnum("EnumPrnt");

  internal static testEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntEncoder : IEncoder<testPrntEnumPrnt>
{
  public IGqlpValue Encode(testPrntEnumPrnt input)
    => input.EncodeEnum("PrntEnumPrnt");

  internal static testPrntEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntAliasEncoder : IEncoder<testEnumPrntAlias>
{
  public IGqlpValue Encode(testEnumPrntAlias input)
    => input.EncodeEnum("EnumPrntAlias");

  internal static testEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntAliasEncoder : IEncoder<testPrntEnumPrntAlias>
{
  public IGqlpValue Encode(testPrntEnumPrntAlias input)
    => input.EncodeEnum("PrntEnumPrntAlias");

  internal static testPrntEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntDescrEncoder : IEncoder<testEnumPrntDescr>
{
  public IGqlpValue Encode(testEnumPrntDescr input)
    => input.EncodeEnum("EnumPrntDescr");

  internal static testEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntDescrEncoder : IEncoder<testPrntEnumPrntDescr>
{
  public IGqlpValue Encode(testPrntEnumPrntDescr input)
    => input.EncodeEnum("PrntEnumPrntDescr");

  internal static testPrntEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntDupEncoder : IEncoder<testEnumPrntDup>
{
  public IGqlpValue Encode(testEnumPrntDup input)
    => input.EncodeEnum("EnumPrntDup");

  internal static testEnumPrntDupEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntDupEncoder : IEncoder<testPrntEnumPrntDup>
{
  public IGqlpValue Encode(testPrntEnumPrntDup input)
    => input.EncodeEnum("PrntEnumPrntDup");

  internal static testPrntEnumPrntDupEncoder Factory(IEncoderRepository _) => new();
}

internal class testUnionDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDescr>
{
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestUnionDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testUnionDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrnt>
{
  private readonly Encoder<string> _string = encoders.EncoderFor<string>();
  public IGqlpValue Encode(ItestUnionPrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : new GqlpUnit();

  internal static testUnionPrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrnt>
{
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestPrntUnionPrnt input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testPrntUnionPrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDescr>
{
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDescr>
{
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestPrntUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testPrntUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDup>
{
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testUnionPrntDupEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDup>
{
  private readonly Encoder<decimal> _number = encoders.EncoderFor<decimal>();
  public IGqlpValue Encode(ItestPrntUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : new GqlpUnit();

  internal static testPrntUnionPrntDupEncoder Factory(IEncoderRepository r) => new(r);
}

internal static class test__ALLEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__ALLEncoders(this IEncoderRepositoryBuilder builder)
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
      .AddEncoder<ItestAddrOprSlctSprdObject>(testAddrOprSlctSprdEncoder.Factory)
      .AddEncoder<ItestAltDualObject>(testAltDualEncoder.Factory)
      .AddEncoder<ItestAltAltDualObject>(testAltAltDualEncoder.Factory)
      .AddEncoder<ItestAltInpObject>(testAltInpEncoder.Factory)
      .AddEncoder<ItestAltAltInpObject>(testAltAltInpEncoder.Factory)
      .AddEncoder<ItestAltOutpObject>(testAltOutpEncoder.Factory)
      .AddEncoder<ItestAltAltOutpObject>(testAltAltOutpEncoder.Factory)
      .AddEncoder<ItestAltDescrDualObject>(testAltDescrDualEncoder.Factory)
      .AddEncoder<ItestAltDescrInpObject>(testAltDescrInpEncoder.Factory)
      .AddEncoder<ItestAltDescrOutpObject>(testAltDescrOutpEncoder.Factory)
      .AddEncoder<ItestAltDualDualObject>(testAltDualDualEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualDualObject>(testObjDualAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltDualInpObject>(testAltDualInpEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualInpObject>(testObjDualAltDualInpEncoder.Factory)
      .AddEncoder<ItestAltDualOutpObject>(testAltDualOutpEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualOutpObject>(testObjDualAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltEnumDualObject>(testAltEnumDualEncoder.Factory)
      .AddEncoder<testEnumAltEnumDual>(testEnumAltEnumDualEncoder.Factory)
      .AddEncoder<ItestAltEnumInpObject>(testAltEnumInpEncoder.Factory)
      .AddEncoder<testEnumAltEnumInp>(testEnumAltEnumInpEncoder.Factory)
      .AddEncoder<ItestAltEnumOutpObject>(testAltEnumOutpEncoder.Factory)
      .AddEncoder<testEnumAltEnumOutp>(testEnumAltEnumOutpEncoder.Factory)
      .AddEncoder<ItestAltModBoolDualObject>(testAltModBoolDualEncoder.Factory)
      .AddEncoder<ItestAltAltModBoolDualObject>(testAltAltModBoolDualEncoder.Factory)
      .AddEncoder<ItestAltModBoolInpObject>(testAltModBoolInpEncoder.Factory)
      .AddEncoder<ItestAltAltModBoolInpObject>(testAltAltModBoolInpEncoder.Factory)
      .AddEncoder<ItestAltModBoolOutpObject>(testAltModBoolOutpEncoder.Factory)
      .AddEncoder<ItestAltAltModBoolOutpObject>(testAltAltModBoolOutpEncoder.Factory)
      .AddEncoder<ItestAltAltModParamDualObject>(testAltAltModParamDualEncoder.Factory)
      .AddEncoder<ItestAltAltModParamInpObject>(testAltAltModParamInpEncoder.Factory)
      .AddEncoder<ItestAltAltModParamOutpObject>(testAltAltModParamOutpEncoder.Factory)
      .AddEncoder<ItestAltSmplDualObject>(testAltSmplDualEncoder.Factory)
      .AddEncoder<ItestAltSmplInpObject>(testAltSmplInpEncoder.Factory)
      .AddEncoder<ItestAltSmplOutpObject>(testAltSmplOutpEncoder.Factory)
      .AddEncoder<ItestCnstAltDmnDualObject>(testCnstAltDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnDual>(testDomCnstAltDmnDualEncoder.Factory)
      .AddEncoder<ItestCnstAltDmnInpObject>(testCnstAltDmnInpEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnInp>(testDomCnstAltDmnInpEncoder.Factory)
      .AddEncoder<ItestCnstAltDmnOutpObject>(testCnstAltDmnOutpEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnOutp>(testDomCnstAltDmnOutpEncoder.Factory)
      .AddEncoder<ItestCnstAltDualDualObject>(testCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualDualObject>(testPrntCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualDualObject>(testAltCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestCnstAltDualInpObject>(testCnstAltDualInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualInpObject>(testPrntCnstAltDualInpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualInpObject>(testAltCnstAltDualInpEncoder.Factory)
      .AddEncoder<ItestCnstAltDualOutpObject>(testCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualOutpObject>(testPrntCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualOutpObject>(testAltCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestCnstAltObjDualObject>(testCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltObjDualObject>(testPrntCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestAltCnstAltObjDualObject>(testAltCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestCnstAltObjInpObject>(testCnstAltObjInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltObjInpObject>(testPrntCnstAltObjInpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltObjInpObject>(testAltCnstAltObjInpEncoder.Factory)
      .AddEncoder<ItestCnstAltObjOutpObject>(testCnstAltObjOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltObjOutpObject>(testPrntCnstAltObjOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltObjOutpObject>(testAltCnstAltObjOutpEncoder.Factory)
      .AddEncoder<ItestCnstDomEnumDualObject>(testCnstDomEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumDual>(testEnumCnstDomEnumDualEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumDual>(testJustCnstDomEnumDualEncoder.Factory)
      .AddEncoder<ItestCnstDomEnumInpObject>(testCnstDomEnumInpEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumInp>(testEnumCnstDomEnumInpEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumInp>(testJustCnstDomEnumInpEncoder.Factory)
      .AddEncoder<ItestCnstDomEnumOutpObject>(testCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumOutp>(testEnumCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumOutp>(testJustCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<ItestCnstEnumDualObject>(testCnstEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstEnumDual>(testEnumCnstEnumDualEncoder.Factory)
      .AddEncoder<ItestCnstEnumInpObject>(testCnstEnumInpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumInp>(testEnumCnstEnumInpEncoder.Factory)
      .AddEncoder<ItestCnstEnumOutpObject>(testCnstEnumOutpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumOutp>(testEnumCnstEnumOutpEncoder.Factory)
      .AddEncoder<ItestCnstEnumPrntDualObject>(testCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntDual>(testEnumCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntDual>(testParentCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<ItestCnstEnumPrntInpObject>(testCnstEnumPrntInpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntInp>(testEnumCnstEnumPrntInpEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntInp>(testParentCnstEnumPrntInpEncoder.Factory)
      .AddEncoder<ItestCnstEnumPrntOutpObject>(testCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntOutp>(testEnumCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntOutp>(testParentCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDmnDualObject>(testCnstFieldDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnDual>(testDomCnstFieldDmnDualEncoder.Factory)
      .AddEncoder<ItestCnstFieldDmnInpObject>(testCnstFieldDmnInpEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnInp>(testDomCnstFieldDmnInpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDmnOutpObject>(testCnstFieldDmnOutpEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnOutp>(testDomCnstFieldDmnOutpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDualDualObject>(testCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualDualObject>(testPrntCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualDualObject>(testAltCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestCnstFieldDualInpObject>(testCnstFieldDualInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualInpObject>(testPrntCnstFieldDualInpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualInpObject>(testAltCnstFieldDualInpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDualOutpObject>(testCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualOutpObject>(testPrntCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualOutpObject>(testAltCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestCnstFieldObjDualObject>(testCnstFieldObjDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldObjDualObject>(testPrntCnstFieldObjDualEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldObjDualObject>(testAltCnstFieldObjDualEncoder.Factory)
      .AddEncoder<ItestCnstFieldObjInpObject>(testCnstFieldObjInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldObjInpObject>(testPrntCnstFieldObjInpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldObjInpObject>(testAltCnstFieldObjInpEncoder.Factory)
      .AddEncoder<ItestCnstFieldObjOutpObject>(testCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldObjOutpObject>(testPrntCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldObjOutpObject>(testAltCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualGrndDualObject>(testCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndDualObject>(testGrndCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndDualObject>(testPrntCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndDualObject>(testAltCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualGrndInpObject>(testCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndInpObject>(testGrndCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndInpObject>(testPrntCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndInpObject>(testAltCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualGrndOutpObject>(testCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndOutpObject>(testGrndCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndOutpObject>(testPrntCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndOutpObject>(testAltCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualPrntDualObject>(testCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntDualObject>(testPrntCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntDualObject>(testAltCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualPrntInpObject>(testCnstPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntInpObject>(testPrntCnstPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntInpObject>(testAltCnstPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualPrntOutpObject>(testCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntOutpObject>(testPrntCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntOutpObject>(testAltCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntEnumDualObject>(testCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumDual>(testEnumCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumDual>(testParentCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<ItestCnstPrntEnumInpObject>(testCnstPrntEnumInpEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumInp>(testEnumCnstPrntEnumInpEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumInp>(testParentCnstPrntEnumInpEncoder.Factory)
      .AddEncoder<ItestCnstPrntEnumOutpObject>(testCnstPrntEnumOutpEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumOutp>(testEnumCnstPrntEnumOutpEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumOutp>(testParentCnstPrntEnumOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntObjPrntDualObject>(testCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntDualObject>(testPrntCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntDualObject>(testAltCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestCnstPrntObjPrntInpObject>(testCnstPrntObjPrntInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntInpObject>(testPrntCnstPrntObjPrntInpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntInpObject>(testAltCnstPrntObjPrntInpEncoder.Factory)
      .AddEncoder<ItestCnstPrntObjPrntOutpObject>(testCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntOutpObject>(testPrntCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntOutpObject>(testAltCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestFieldDualObject>(testFieldDualEncoder.Factory)
      .AddEncoder<ItestFieldInpObject>(testFieldInpEncoder.Factory)
      .AddEncoder<ItestFieldOutpObject>(testFieldOutpEncoder.Factory)
      .AddEncoder<ItestFieldDescrDualObject>(testFieldDescrDualEncoder.Factory)
      .AddEncoder<ItestFieldDescrInpObject>(testFieldDescrInpEncoder.Factory)
      .AddEncoder<ItestFieldDescrOutpObject>(testFieldDescrOutpEncoder.Factory)
      .AddEncoder<ItestFieldDualDualObject>(testFieldDualDualEncoder.Factory)
      .AddEncoder<ItestFldFieldDualDualObject>(testFldFieldDualDualEncoder.Factory)
      .AddEncoder<ItestFieldDualInpObject>(testFieldDualInpEncoder.Factory)
      .AddEncoder<ItestFldFieldDualInpObject>(testFldFieldDualInpEncoder.Factory)
      .AddEncoder<ItestFieldDualOutpObject>(testFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestFldFieldDualOutpObject>(testFldFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestFieldEnumDualObject>(testFieldEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumDual>(testEnumFieldEnumDualEncoder.Factory)
      .AddEncoder<ItestFieldEnumInpObject>(testFieldEnumInpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumInp>(testEnumFieldEnumInpEncoder.Factory)
      .AddEncoder<ItestFieldEnumOutpObject>(testFieldEnumOutpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumOutp>(testEnumFieldEnumOutpEncoder.Factory)
      .AddEncoder<ItestFieldEnumPrntDualObject>(testFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntDual>(testEnumFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntDual>(testPrntFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<ItestFieldEnumPrntInpObject>(testFieldEnumPrntInpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntInp>(testEnumFieldEnumPrntInpEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntInp>(testPrntFieldEnumPrntInpEncoder.Factory)
      .AddEncoder<ItestFieldEnumPrntOutpObject>(testFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntOutp>(testEnumFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntOutp>(testPrntFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<ItestFieldModEnumDualObject>(testFieldModEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumDual>(testEnumFieldModEnumDualEncoder.Factory)
      .AddEncoder<ItestFieldModEnumInpObject>(testFieldModEnumInpEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumInp>(testEnumFieldModEnumInpEncoder.Factory)
      .AddEncoder<ItestFieldModEnumOutpObject>(testFieldModEnumOutpEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumOutp>(testEnumFieldModEnumOutpEncoder.Factory)
      .AddEncoder<ItestFldFieldModParamDualObject>(testFldFieldModParamDualEncoder.Factory)
      .AddEncoder<ItestFldFieldModParamInpObject>(testFldFieldModParamInpEncoder.Factory)
      .AddEncoder<ItestFldFieldModParamOutpObject>(testFldFieldModParamOutpEncoder.Factory)
      .AddEncoder<ItestFieldObjDualObject>(testFieldObjDualEncoder.Factory)
      .AddEncoder<ItestFldFieldObjDualObject>(testFldFieldObjDualEncoder.Factory)
      .AddEncoder<ItestFieldObjInpObject>(testFieldObjInpEncoder.Factory)
      .AddEncoder<ItestFldFieldObjInpObject>(testFldFieldObjInpEncoder.Factory)
      .AddEncoder<ItestFieldObjOutpObject>(testFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestFldFieldObjOutpObject>(testFldFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestFieldSmplDualObject>(testFieldSmplDualEncoder.Factory)
      .AddEncoder<ItestFieldSmplInpObject>(testFieldSmplInpEncoder.Factory)
      .AddEncoder<ItestFieldSmplOutpObject>(testFieldSmplOutpEncoder.Factory)
      .AddEncoder<ItestFieldTypeDescrDualObject>(testFieldTypeDescrDualEncoder.Factory)
      .AddEncoder<ItestFieldTypeDescrInpObject>(testFieldTypeDescrInpEncoder.Factory)
      .AddEncoder<ItestFieldTypeDescrOutpObject>(testFieldTypeDescrOutpEncoder.Factory)
      .AddEncoder<ItestFieldValueDualObject>(testFieldValueDualEncoder.Factory)
      .AddEncoder<testEnumFieldValueDual>(testEnumFieldValueDualEncoder.Factory)
      .AddEncoder<ItestFieldValueInpObject>(testFieldValueInpEncoder.Factory)
      .AddEncoder<testEnumFieldValueInp>(testEnumFieldValueInpEncoder.Factory)
      .AddEncoder<ItestFieldValueOutpObject>(testFieldValueOutpEncoder.Factory)
      .AddEncoder<testEnumFieldValueOutp>(testEnumFieldValueOutpEncoder.Factory)
      .AddEncoder<ItestFieldValueDescrDualObject>(testFieldValueDescrDualEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrDual>(testEnumFieldValueDescrDualEncoder.Factory)
      .AddEncoder<ItestFieldValueDescrInpObject>(testFieldValueDescrInpEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrInp>(testEnumFieldValueDescrInpEncoder.Factory)
      .AddEncoder<ItestFieldValueDescrOutpObject>(testFieldValueDescrOutpEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrOutp>(testEnumFieldValueDescrOutpEncoder.Factory)
      .AddEncoder<ItestGnrcAltDualDualObject>(testGnrcAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualDualObject>(testAltGnrcAltDualDualEncoder.Factory)
      .AddEncoder<ItestGnrcAltDualInpObject>(testGnrcAltDualInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualInpObject>(testAltGnrcAltDualInpEncoder.Factory)
      .AddEncoder<ItestGnrcAltDualOutpObject>(testGnrcAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualOutpObject>(testAltGnrcAltDualOutpEncoder.Factory)
      .AddEncoder<ItestGnrcAltParamDualObject>(testGnrcAltParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamDualObject>(testAltGnrcAltParamDualEncoder.Factory)
      .AddEncoder<ItestGnrcAltParamInpObject>(testGnrcAltParamInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamInpObject>(testAltGnrcAltParamInpEncoder.Factory)
      .AddEncoder<ItestGnrcAltParamOutpObject>(testGnrcAltParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamOutpObject>(testAltGnrcAltParamOutpEncoder.Factory)
      .AddEncoder<ItestGnrcAltSmplDualObject>(testGnrcAltSmplDualEncoder.Factory)
      .AddEncoder<ItestGnrcAltSmplInpObject>(testGnrcAltSmplInpEncoder.Factory)
      .AddEncoder<ItestGnrcAltSmplOutpObject>(testGnrcAltSmplOutpEncoder.Factory)
      .AddEncoder<ItestGnrcEnumDualObject>(testGnrcEnumDualEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumDual>(testEnumGnrcEnumDualEncoder.Factory)
      .AddEncoder<ItestGnrcEnumInpObject>(testGnrcEnumInpEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumInp>(testEnumGnrcEnumInpEncoder.Factory)
      .AddEncoder<ItestGnrcEnumOutpObject>(testGnrcEnumOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumOutp>(testEnumGnrcEnumOutpEncoder.Factory)
      .AddEncoder<ItestGnrcFieldDualDualObject>(testGnrcFieldDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualDualObject>(testAltGnrcFieldDualDualEncoder.Factory)
      .AddEncoder<ItestGnrcFieldDualInpObject>(testGnrcFieldDualInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualInpObject>(testAltGnrcFieldDualInpEncoder.Factory)
      .AddEncoder<ItestGnrcFieldDualOutpObject>(testGnrcFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualOutpObject>(testAltGnrcFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestGnrcFieldParamDualObject>(testGnrcFieldParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamDualObject>(testAltGnrcFieldParamDualEncoder.Factory)
      .AddEncoder<ItestGnrcFieldParamInpObject>(testGnrcFieldParamInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamInpObject>(testAltGnrcFieldParamInpEncoder.Factory)
      .AddEncoder<ItestGnrcFieldParamOutpObject>(testGnrcFieldParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamOutpObject>(testAltGnrcFieldParamOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualDualObject>(testGnrcPrntDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualDualObject>(testAltGnrcPrntDualDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualInpObject>(testGnrcPrntDualInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualInpObject>(testAltGnrcPrntDualInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualOutpObject>(testGnrcPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualOutpObject>(testAltGnrcPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualPrntDualObject>(testGnrcPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntDualObject>(testAltGnrcPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualPrntInpObject>(testGnrcPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntInpObject>(testAltGnrcPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualPrntOutpObject>(testGnrcPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntOutpObject>(testAltGnrcPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumChildDualObject>(testGnrcPrntEnumChildDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumChildDual>(testEnumGnrcPrntEnumChildDualEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildDual>(testParentGnrcPrntEnumChildDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumChildInpObject>(testGnrcPrntEnumChildInpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumChildInp>(testEnumGnrcPrntEnumChildInpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildInp>(testParentGnrcPrntEnumChildInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumChildOutpObject>(testGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumChildOutp>(testEnumGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildOutp>(testParentGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumDomDualObject>(testGnrcPrntEnumDomDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomDual>(testEnumGnrcPrntEnumDomDualEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomDual>(testDomGnrcPrntEnumDomDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumDomInpObject>(testGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomInp>(testEnumGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomInp>(testDomGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumDomOutpObject>(testGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomOutp>(testEnumGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomOutp>(testDomGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumPrntDualObject>(testGnrcPrntEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumPrntDual>(testEnumGnrcPrntEnumPrntDualEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntDual>(testParentGnrcPrntEnumPrntDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumPrntInpObject>(testGnrcPrntEnumPrntInpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumPrntInp>(testEnumGnrcPrntEnumPrntInpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntInp>(testParentGnrcPrntEnumPrntInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumPrntOutpObject>(testGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumPrntOutp>(testEnumGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntOutp>(testParentGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamDualObject>(testGnrcPrntParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamDualObject>(testAltGnrcPrntParamDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamInpObject>(testGnrcPrntParamInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamInpObject>(testAltGnrcPrntParamInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamOutpObject>(testGnrcPrntParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamOutpObject>(testAltGnrcPrntParamOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamPrntDualObject>(testGnrcPrntParamPrntDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamPrntDualObject>(testAltGnrcPrntParamPrntDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamPrntInpObject>(testGnrcPrntParamPrntInpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamPrntInpObject>(testAltGnrcPrntParamPrntInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamPrntOutpObject>(testGnrcPrntParamPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamPrntOutpObject>(testAltGnrcPrntParamPrntOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntSmplEnumDualObject>(testGnrcPrntSmplEnumDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumDual>(testEnumGnrcPrntSmplEnumDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntSmplEnumInpObject>(testGnrcPrntSmplEnumInpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumInp>(testEnumGnrcPrntSmplEnumInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntSmplEnumOutpObject>(testGnrcPrntSmplEnumOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumOutp>(testEnumGnrcPrntSmplEnumOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntStrDomDualObject>(testGnrcPrntStrDomDualEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntStrDomDual>(testDomGnrcPrntStrDomDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntStrDomInpObject>(testGnrcPrntStrDomInpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntStrDomInp>(testDomGnrcPrntStrDomInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntStrDomOutpObject>(testGnrcPrntStrDomOutpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntStrDomOutp>(testDomGnrcPrntStrDomOutpEncoder.Factory)
      .AddEncoder<ItestGnrcValueDualObject>(testGnrcValueDualEncoder.Factory)
      .AddEncoder<testEnumGnrcValueDual>(testEnumGnrcValueDualEncoder.Factory)
      .AddEncoder<ItestGnrcValueInpObject>(testGnrcValueInpEncoder.Factory)
      .AddEncoder<testEnumGnrcValueInp>(testEnumGnrcValueInpEncoder.Factory)
      .AddEncoder<ItestGnrcValueOutpObject>(testGnrcValueOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcValueOutp>(testEnumGnrcValueOutpEncoder.Factory)
      .AddEncoder<ItestInpFieldDescrNmbrObject>(testInpFieldDescrNmbrEncoder.Factory)
      .AddEncoder<ItestInpFieldEnumObject>(testInpFieldEnumEncoder.Factory)
      .AddEncoder<testEnumInpFieldEnum>(testEnumInpFieldEnumEncoder.Factory)
      .AddEncoder<ItestInpFieldNullObject>(testInpFieldNullEncoder.Factory)
      .AddEncoder<ItestFldInpFieldNullObject>(testFldInpFieldNullEncoder.Factory)
      .AddEncoder<ItestInpFieldNmbrObject>(testInpFieldNmbrEncoder.Factory)
      .AddEncoder<ItestInpFieldNmbrDescrObject>(testInpFieldNmbrDescrEncoder.Factory)
      .AddEncoder<ItestInpFieldStrObject>(testInpFieldStrEncoder.Factory)
      .AddEncoder<ItestOutpDescrParamObject>(testOutpDescrParamEncoder.Factory)
      .AddEncoder<ItestFldOutpDescrParamObject>(testFldOutpDescrParamEncoder.Factory)
      .AddEncoder<ItestInOutpDescrParamObject>(testInOutpDescrParamEncoder.Factory)
      .AddEncoder<ItestOutpParamObject>(testOutpParamEncoder.Factory)
      .AddEncoder<ItestFldOutpParamObject>(testFldOutpParamEncoder.Factory)
      .AddEncoder<ItestInOutpParamObject>(testInOutpParamEncoder.Factory)
      .AddEncoder<ItestOutpParamDescrObject>(testOutpParamDescrEncoder.Factory)
      .AddEncoder<ItestFldOutpParamDescrObject>(testFldOutpParamDescrEncoder.Factory)
      .AddEncoder<ItestInOutpParamDescrObject>(testInOutpParamDescrEncoder.Factory)
      .AddEncoder<ItestOutpParamModDmnObject>(testOutpParamModDmnEncoder.Factory)
      .AddEncoder<ItestInOutpParamModDmnObject>(testInOutpParamModDmnEncoder.Factory)
      .AddEncoder<ItestDomOutpParamModDmn>(testDomOutpParamModDmnEncoder.Factory)
      .AddEncoder<ItestInOutpParamModParamObject>(testInOutpParamModParamEncoder.Factory)
      .AddEncoder<ItestDomOutpParamModParam>(testDomOutpParamModParamEncoder.Factory)
      .AddEncoder<ItestOutpParamTypeDescrObject>(testOutpParamTypeDescrEncoder.Factory)
      .AddEncoder<ItestFldOutpParamTypeDescrObject>(testFldOutpParamTypeDescrEncoder.Factory)
      .AddEncoder<ItestInOutpParamTypeDescrObject>(testInOutpParamTypeDescrEncoder.Factory)
      .AddEncoder<ItestOutpPrntGnrcObject>(testOutpPrntGnrcEncoder.Factory)
      .AddEncoder<testEnumOutpPrntGnrc>(testEnumOutpPrntGnrcEncoder.Factory)
      .AddEncoder<testPrntOutpPrntGnrc>(testPrntOutpPrntGnrcEncoder.Factory)
      .AddEncoder<ItestOutpPrntParamObject>(testOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestPrntOutpPrntParamObject>(testPrntOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestFldOutpPrntParamObject>(testFldOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestInOutpPrntParamObject>(testInOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestPrntOutpPrntParamInObject>(testPrntOutpPrntParamInEncoder.Factory)
      .AddEncoder<ItestPrntDualObject>(testPrntDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDualObject>(testRefPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntInpObject>(testPrntInpEncoder.Factory)
      .AddEncoder<ItestRefPrntInpObject>(testRefPrntInpEncoder.Factory)
      .AddEncoder<ItestPrntOutpObject>(testPrntOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntOutpObject>(testRefPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntAltDualObject>(testPrntAltDualEncoder.Factory)
      .AddEncoder<ItestRefPrntAltDualObject>(testRefPrntAltDualEncoder.Factory)
      .AddEncoder<ItestPrntAltInpObject>(testPrntAltInpEncoder.Factory)
      .AddEncoder<ItestRefPrntAltInpObject>(testRefPrntAltInpEncoder.Factory)
      .AddEncoder<ItestPrntAltOutpObject>(testPrntAltOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntAltOutpObject>(testRefPrntAltOutpEncoder.Factory)
      .AddEncoder<ItestPrntDescrDualObject>(testPrntDescrDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDescrDualObject>(testRefPrntDescrDualEncoder.Factory)
      .AddEncoder<ItestPrntDescrInpObject>(testPrntDescrInpEncoder.Factory)
      .AddEncoder<ItestRefPrntDescrInpObject>(testRefPrntDescrInpEncoder.Factory)
      .AddEncoder<ItestPrntDescrOutpObject>(testPrntDescrOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntDescrOutpObject>(testRefPrntDescrOutpEncoder.Factory)
      .AddEncoder<ItestPrntDualDualObject>(testPrntDualDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDualDualObject>(testRefPrntDualDualEncoder.Factory)
      .AddEncoder<ItestPrntDualInpObject>(testPrntDualInpEncoder.Factory)
      .AddEncoder<ItestRefPrntDualInpObject>(testRefPrntDualInpEncoder.Factory)
      .AddEncoder<ItestPrntDualOutpObject>(testPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntDualOutpObject>(testRefPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntFieldDualObject>(testPrntFieldDualEncoder.Factory)
      .AddEncoder<ItestRefPrntFieldDualObject>(testRefPrntFieldDualEncoder.Factory)
      .AddEncoder<ItestPrntFieldInpObject>(testPrntFieldInpEncoder.Factory)
      .AddEncoder<ItestRefPrntFieldInpObject>(testRefPrntFieldInpEncoder.Factory)
      .AddEncoder<ItestPrntFieldOutpObject>(testPrntFieldOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntFieldOutpObject>(testRefPrntFieldOutpEncoder.Factory)
      .AddEncoder<ItestCtgrObject>(testCtgrEncoder.Factory)
      .AddEncoder<ItestCtgrAliasObject>(testCtgrAliasEncoder.Factory)
      .AddEncoder<ItestCtgrDescrObject>(testCtgrDescrEncoder.Factory)
      .AddEncoder<ItestCtgrModObject>(testCtgrModEncoder.Factory)
      .AddEncoder<ItestInDrctParamObject>(testInDrctParamEncoder.Factory)
      .AddEncoder<ItestDmnAlias>(testDmnAliasEncoder.Factory)
      .AddEncoder<ItestDmnBool>(testDmnBoolEncoder.Factory)
      .AddEncoder<ItestDmnBoolDiff>(testDmnBoolDiffEncoder.Factory)
      .AddEncoder<ItestDmnBoolSame>(testDmnBoolSameEncoder.Factory)
      .AddEncoder<ItestDmnEnumDiff>(testDmnEnumDiffEncoder.Factory)
      .AddEncoder<ItestDmnEnumSame>(testDmnEnumSameEncoder.Factory)
      .AddEncoder<ItestDmnNmbr>(testDmnNmbrEncoder.Factory)
      .AddEncoder<ItestDmnNmbrDiff>(testDmnNmbrDiffEncoder.Factory)
      .AddEncoder<ItestDmnNmbrSame>(testDmnNmbrSameEncoder.Factory)
      .AddEncoder<ItestDmnStr>(testDmnStrEncoder.Factory)
      .AddEncoder<ItestDmnStrDiff>(testDmnStrDiffEncoder.Factory)
      .AddEncoder<ItestDmnStrSame>(testDmnStrSameEncoder.Factory)
      .AddEncoder<testEnumAlias>(testEnumAliasEncoder.Factory)
      .AddEncoder<testEnumDiff>(testEnumDiffEncoder.Factory)
      .AddEncoder<testEnumSame>(testEnumSameEncoder.Factory)
      .AddEncoder<testEnumSamePrnt>(testEnumSamePrntEncoder.Factory)
      .AddEncoder<testPrntEnumSamePrnt>(testPrntEnumSamePrntEncoder.Factory)
      .AddEncoder<testEnumValueAlias>(testEnumValueAliasEncoder.Factory)
      .AddEncoder<ItestObjDualObject>(testObjDualEncoder.Factory)
      .AddEncoder<ItestObjInpObject>(testObjInpEncoder.Factory)
      .AddEncoder<ItestObjOutpObject>(testObjOutpEncoder.Factory)
      .AddEncoder<ItestObjAliasDualObject>(testObjAliasDualEncoder.Factory)
      .AddEncoder<ItestObjAliasInpObject>(testObjAliasInpEncoder.Factory)
      .AddEncoder<ItestObjAliasOutpObject>(testObjAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjAltDualObject>(testObjAltDualEncoder.Factory)
      .AddEncoder<ItestObjAltDualTypeObject>(testObjAltDualTypeEncoder.Factory)
      .AddEncoder<ItestObjAltInpObject>(testObjAltInpEncoder.Factory)
      .AddEncoder<ItestObjAltInpTypeObject>(testObjAltInpTypeEncoder.Factory)
      .AddEncoder<ItestObjAltOutpObject>(testObjAltOutpEncoder.Factory)
      .AddEncoder<ItestObjAltOutpTypeObject>(testObjAltOutpTypeEncoder.Factory)
      .AddEncoder<ItestObjAltEnumDualObject>(testObjAltEnumDualEncoder.Factory)
      .AddEncoder<ItestObjAltEnumInpObject>(testObjAltEnumInpEncoder.Factory)
      .AddEncoder<ItestObjAltEnumOutpObject>(testObjAltEnumOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldDualObject>(testObjFieldDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldDualObject>(testFldObjFieldDualEncoder.Factory)
      .AddEncoder<ItestObjFieldInpObject>(testObjFieldInpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldInpObject>(testFldObjFieldInpEncoder.Factory)
      .AddEncoder<ItestObjFieldOutpObject>(testObjFieldOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldOutpObject>(testFldObjFieldOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasDualObject>(testObjFieldAliasDualEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasDualObject>(testFldObjFieldAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasInpObject>(testObjFieldAliasInpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasInpObject>(testFldObjFieldAliasInpEncoder.Factory)
      .AddEncoder<ItestObjFieldAliasOutpObject>(testObjFieldAliasOutpEncoder.Factory)
      .AddEncoder<ItestFldObjFieldAliasOutpObject>(testFldObjFieldAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasInpObject>(testObjFieldEnumAliasInpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumAliasOutpObject>(testObjFieldEnumAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueDualObject>(testObjFieldEnumValueDualEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueInpObject>(testObjFieldEnumValueInpEncoder.Factory)
      .AddEncoder<ItestObjFieldEnumValueOutpObject>(testObjFieldEnumValueOutpEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasInpObject>(testObjFieldTypeAliasInpEncoder.Factory)
      .AddEncoder<ItestObjFieldTypeAliasOutpObject>(testObjFieldTypeAliasOutpEncoder.Factory)
      .AddEncoder<ItestObjPrntDualObject>(testObjPrntDualEncoder.Factory)
      .AddEncoder<ItestRefObjPrntDualObject>(testRefObjPrntDualEncoder.Factory)
      .AddEncoder<ItestObjPrntInpObject>(testObjPrntInpEncoder.Factory)
      .AddEncoder<ItestRefObjPrntInpObject>(testRefObjPrntInpEncoder.Factory)
      .AddEncoder<ItestObjPrntOutpObject>(testObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestRefObjPrntOutpObject>(testRefObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestOpObject>(testOpEncoder.Factory)
      .AddEncoder<ItestOutpFieldParamObject>(testOutpFieldParamEncoder.Factory)
      .AddEncoder<ItestOutpFieldParam1Object>(testOutpFieldParam1Encoder.Factory)
      .AddEncoder<ItestOutpFieldParam2Object>(testOutpFieldParam2Encoder.Factory)
      .AddEncoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamEncoder.Factory)
      .AddEncoder<ItestUnionAlias>(testUnionAliasEncoder.Factory)
      .AddEncoder<ItestUnionDiff>(testUnionDiffEncoder.Factory)
      .AddEncoder<ItestUnionSame>(testUnionSameEncoder.Factory)
      .AddEncoder<ItestUnionSamePrnt>(testUnionSamePrntEncoder.Factory)
      .AddEncoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntEncoder.Factory)
      .AddEncoder<ItestDmnBoolDescr>(testDmnBoolDescrEncoder.Factory)
      .AddEncoder<ItestDmnBoolPrnt>(testDmnBoolPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnBoolPrnt>(testPrntDmnBoolPrntEncoder.Factory)
      .AddEncoder<ItestDmnBoolPrntDescr>(testDmnBoolPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnBoolPrntDescr>(testPrntDmnBoolPrntDescrEncoder.Factory)
      .AddEncoder<ItestDmnEnumAll>(testDmnEnumAllEncoder.Factory)
      .AddEncoder<testEnumDmnEnumAll>(testEnumDmnEnumAllEncoder.Factory)
      .AddEncoder<ItestDmnEnumAllDescr>(testDmnEnumAllDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumAllDescr>(testEnumDmnEnumAllDescrEncoder.Factory)
      .AddEncoder<ItestDmnEnumAllPrnt>(testDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumAllPrnt>(testEnumDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumAllPrnt>(testPrntDmnEnumAllPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumDescr>(testDmnEnumDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumDescr>(testEnumDmnEnumDescrEncoder.Factory)
      .AddEncoder<ItestDmnEnumExcl>(testDmnEnumExclEncoder.Factory)
      .AddEncoder<testEnumDmnEnumExcl>(testEnumDmnEnumExclEncoder.Factory)
      .AddEncoder<ItestDmnEnumExclPrnt>(testDmnEnumExclPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumExclPrnt>(testEnumDmnEnumExclPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumExclPrnt>(testPrntDmnEnumExclPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumLabel>(testDmnEnumLabelEncoder.Factory)
      .AddEncoder<testEnumDmnEnumLabel>(testEnumDmnEnumLabelEncoder.Factory)
      .AddEncoder<ItestDmnEnumPrnt>(testDmnEnumPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumPrnt>(testEnumDmnEnumPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<testEnumDmnEnumPrntDescr>(testEnumDmnEnumPrntDescrEncoder.Factory)
      .AddEncoder<ItestDmnEnumUnq>(testDmnEnumUnqEncoder.Factory)
      .AddEncoder<testEnumDmnEnumUnq>(testEnumDmnEnumUnqEncoder.Factory)
      .AddEncoder<testDupDmnEnumUnq>(testDupDmnEnumUnqEncoder.Factory)
      .AddEncoder<ItestDmnEnumUnqPrnt>(testDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumUnqPrnt>(testEnumDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumUnqPrnt>(testPrntDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<testDupDmnEnumUnqPrnt>(testDupDmnEnumUnqPrntEncoder.Factory)
      .AddEncoder<ItestDmnEnumValue>(testDmnEnumValueEncoder.Factory)
      .AddEncoder<testEnumDmnEnumValue>(testEnumDmnEnumValueEncoder.Factory)
      .AddEncoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<testEnumDmnEnumValuePrnt>(testEnumDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<testPrntDmnEnumValuePrnt>(testPrntDmnEnumValuePrntEncoder.Factory)
      .AddEncoder<ItestDmnNmbrDescr>(testDmnNmbrDescrEncoder.Factory)
      .AddEncoder<ItestDmnNmbrPrnt>(testDmnNmbrPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnNmbrPrnt>(testPrntDmnNmbrPrntEncoder.Factory)
      .AddEncoder<ItestRegexDmnNmbrPrnt>(testRegexDmnNmbrPrntEncoder.Factory)
      .AddEncoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrEncoder.Factory)
      .AddEncoder<ItestDmnNmbrPstv>(testDmnNmbrPstvEncoder.Factory)
      .AddEncoder<ItestDmnNmbrRange>(testDmnNmbrRangeEncoder.Factory)
      .AddEncoder<ItestRegexDmnNmbrRange>(testRegexDmnNmbrRangeEncoder.Factory)
      .AddEncoder<ItestDmnStrDescr>(testDmnStrDescrEncoder.Factory)
      .AddEncoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyEncoder.Factory)
      .AddEncoder<ItestRegexDmnStrNonEmpty>(testRegexDmnStrNonEmptyEncoder.Factory)
      .AddEncoder<ItestDmnStrPrnt>(testDmnStrPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntEncoder.Factory)
      .AddEncoder<ItestRegexDmnStrPrnt>(testRegexDmnStrPrntEncoder.Factory)
      .AddEncoder<ItestDmnStrPrntDescr>(testDmnStrPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnStrPrntDescr>(testPrntDmnStrPrntDescrEncoder.Factory)
      .AddEncoder<testEnumDescr>(testEnumDescrEncoder.Factory)
      .AddEncoder<testEnumPrnt>(testEnumPrntEncoder.Factory)
      .AddEncoder<testPrntEnumPrnt>(testPrntEnumPrntEncoder.Factory)
      .AddEncoder<testEnumPrntAlias>(testEnumPrntAliasEncoder.Factory)
      .AddEncoder<testPrntEnumPrntAlias>(testPrntEnumPrntAliasEncoder.Factory)
      .AddEncoder<testEnumPrntDescr>(testEnumPrntDescrEncoder.Factory)
      .AddEncoder<testPrntEnumPrntDescr>(testPrntEnumPrntDescrEncoder.Factory)
      .AddEncoder<testEnumPrntDup>(testEnumPrntDupEncoder.Factory)
      .AddEncoder<testPrntEnumPrntDup>(testPrntEnumPrntDupEncoder.Factory)
      .AddEncoder<ItestUnionDescr>(testUnionDescrEncoder.Factory)
      .AddEncoder<ItestUnionPrnt>(testUnionPrntEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrnt>(testPrntUnionPrntEncoder.Factory)
      .AddEncoder<ItestUnionPrntDescr>(testUnionPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrntDescr>(testPrntUnionPrntDescrEncoder.Factory)
      .AddEncoder<ItestUnionPrntDup>(testUnionPrntDupEncoder.Factory)
      .AddEncoder<ItestPrntUnionPrntDup>(testPrntUnionPrntDupEncoder.Factory);
}
