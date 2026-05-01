//HintName: test_-ALL_Enc.gen.cs
// Generated from {CurrentDirectory}-ALL.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__ALL;

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

internal class testInDrctParamDictEncoder : IEncoder<ItestInDrctParamDictObject>
{
  public Structured Encode(ItestInDrctParamDictObject input)
    => Structured.Empty();

  internal static testInDrctParamDictEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamInEncoder : IEncoder<ItestInDrctParamInObject>
{
  public Structured Encode(ItestInDrctParamInObject input)
    => Structured.Empty();

  internal static testInDrctParamInEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamListEncoder : IEncoder<ItestInDrctParamListObject>
{
  public Structured Encode(ItestInDrctParamListObject input)
    => Structured.Empty();

  internal static testInDrctParamListEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamOptEncoder : IEncoder<ItestInDrctParamOptObject>
{
  public Structured Encode(ItestInDrctParamOptObject input)
    => Structured.Empty();

  internal static testInDrctParamOptEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDualEncoder : IEncoder<ItestAltDualObject>
{
  public Structured Encode(ItestAltDualObject input)
    => Structured.Empty();

  internal static testAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltDualEncoder : IEncoder<ItestAltAltDualObject>
{
  public Structured Encode(ItestAltAltDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltInpEncoder : IEncoder<ItestAltInpObject>
{
  public Structured Encode(ItestAltInpObject input)
    => Structured.Empty();

  internal static testAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltInpEncoder : IEncoder<ItestAltAltInpObject>
{
  public Structured Encode(ItestAltAltInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltOutpEncoder : IEncoder<ItestAltOutpObject>
{
  public Structured Encode(ItestAltOutpObject input)
    => Structured.Empty();

  internal static testAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltOutpEncoder : IEncoder<ItestAltAltOutpObject>
{
  public Structured Encode(ItestAltAltOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDescrDualEncoder : IEncoder<ItestAltDescrDualObject>
{
  public Structured Encode(ItestAltDescrDualObject input)
    => Structured.Empty();

  internal static testAltDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDescrInpEncoder : IEncoder<ItestAltDescrInpObject>
{
  public Structured Encode(ItestAltDescrInpObject input)
    => Structured.Empty();

  internal static testAltDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDescrOutpEncoder : IEncoder<ItestAltDescrOutpObject>
{
  public Structured Encode(ItestAltDescrOutpObject input)
    => Structured.Empty();

  internal static testAltDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDualDualEncoder : IEncoder<ItestAltDualDualObject>
{
  public Structured Encode(ItestAltDualDualObject input)
    => Structured.Empty();

  internal static testAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualDualEncoder : IEncoder<ItestObjDualAltDualDualObject>
{
  public Structured Encode(ItestObjDualAltDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDualInpEncoder : IEncoder<ItestAltDualInpObject>
{
  public Structured Encode(ItestAltDualInpObject input)
    => Structured.Empty();

  internal static testAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualInpEncoder : IEncoder<ItestObjDualAltDualInpObject>
{
  public Structured Encode(ItestObjDualAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDualOutpEncoder : IEncoder<ItestAltDualOutpObject>
{
  public Structured Encode(ItestAltDualOutpObject input)
    => Structured.Empty();

  internal static testAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualOutpEncoder : IEncoder<ItestObjDualAltDualOutpObject>
{
  public Structured Encode(ItestObjDualAltDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testObjDualAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltEnumDualEncoder : IEncoder<ItestAltEnumDualObject>
{
  public Structured Encode(ItestAltEnumDualObject input)
    => Structured.Empty();

  internal static testAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumDualEncoder : IEncoder<testEnumAltEnumDual>
{
  public Structured Encode(testEnumAltEnumDual input)
    => input.EncodeEnum("EnumAltEnumDual");

  internal static testEnumAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltEnumInpEncoder : IEncoder<ItestAltEnumInpObject>
{
  public Structured Encode(ItestAltEnumInpObject input)
    => Structured.Empty();

  internal static testAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumInpEncoder : IEncoder<testEnumAltEnumInp>
{
  public Structured Encode(testEnumAltEnumInp input)
    => input.EncodeEnum("EnumAltEnumInp");

  internal static testEnumAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltEnumOutpEncoder : IEncoder<ItestAltEnumOutpObject>
{
  public Structured Encode(ItestAltEnumOutpObject input)
    => Structured.Empty();

  internal static testAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumOutpEncoder : IEncoder<testEnumAltEnumOutp>
{
  public Structured Encode(testEnumAltEnumOutp input)
    => input.EncodeEnum("EnumAltEnumOutp");

  internal static testEnumAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModBoolDualEncoder : IEncoder<ItestAltModBoolDualObject>
{
  public Structured Encode(ItestAltModBoolDualObject input)
    => Structured.Empty();

  internal static testAltModBoolDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolDualEncoder : IEncoder<ItestAltAltModBoolDualObject>
{
  public Structured Encode(ItestAltAltModBoolDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModBoolInpEncoder : IEncoder<ItestAltModBoolInpObject>
{
  public Structured Encode(ItestAltModBoolInpObject input)
    => Structured.Empty();

  internal static testAltModBoolInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolInpEncoder : IEncoder<ItestAltAltModBoolInpObject>
{
  public Structured Encode(ItestAltAltModBoolInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModBoolOutpEncoder : IEncoder<ItestAltModBoolOutpObject>
{
  public Structured Encode(ItestAltModBoolOutpObject input)
    => Structured.Empty();

  internal static testAltModBoolOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltAltModBoolOutpEncoder : IEncoder<ItestAltAltModBoolOutpObject>
{
  public Structured Encode(ItestAltAltModBoolOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModBoolOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModParamDualEncoder<TMod> : IEncoder<ItestAltModParamDualObject<TMod>>
{
  public Structured Encode(ItestAltModParamDualObject<TMod> input)
    => Structured.Empty();
}

internal class testAltAltModParamDualEncoder : IEncoder<ItestAltAltModParamDualObject>
{
  public Structured Encode(ItestAltAltModParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModParamInpEncoder<TMod> : IEncoder<ItestAltModParamInpObject<TMod>>
{
  public Structured Encode(ItestAltModParamInpObject<TMod> input)
    => Structured.Empty();
}

internal class testAltAltModParamInpEncoder : IEncoder<ItestAltAltModParamInpObject>
{
  public Structured Encode(ItestAltAltModParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltModParamOutpEncoder<TMod> : IEncoder<ItestAltModParamOutpObject<TMod>>
{
  public Structured Encode(ItestAltModParamOutpObject<TMod> input)
    => Structured.Empty();
}

internal class testAltAltModParamOutpEncoder : IEncoder<ItestAltAltModParamOutpObject>
{
  public Structured Encode(ItestAltAltModParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltAltModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltSmplDualEncoder : IEncoder<ItestAltSmplDualObject>
{
  public Structured Encode(ItestAltSmplDualObject input)
    => Structured.Empty();

  internal static testAltSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltSmplInpEncoder : IEncoder<ItestAltSmplInpObject>
{
  public Structured Encode(ItestAltSmplInpObject input)
    => Structured.Empty();

  internal static testAltSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltSmplOutpEncoder : IEncoder<ItestAltSmplOutpObject>
{
  public Structured Encode(ItestAltSmplOutpObject input)
    => Structured.Empty();

  internal static testAltSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDualEncoder<TType> : IEncoder<ItestCnstAltDualObject<TType>>
{
  public Structured Encode(ItestCnstAltDualObject<TType> input)
    => Structured.Empty();
}

internal class testCnstAltInpEncoder<TType> : IEncoder<ItestCnstAltInpObject<TType>>
{
  public Structured Encode(ItestCnstAltInpObject<TType> input)
    => Structured.Empty();
}

internal class testCnstAltOutpEncoder<TType> : IEncoder<ItestCnstAltOutpObject<TType>>
{
  public Structured Encode(ItestCnstAltOutpObject<TType> input)
    => Structured.Empty();
}

internal class testCnstAltDmnDualEncoder : IEncoder<ItestCnstAltDmnDualObject>
{
  public Structured Encode(ItestCnstAltDmnDualObject input)
    => Structured.Empty();

  internal static testCnstAltDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnDualEncoder<TRef> : IEncoder<ItestRefCnstAltDmnDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnDualObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnDualEncoder : IEncoder<ItestDomCnstAltDmnDual>
{
  public Structured Encode(ItestDomCnstAltDmnDual input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDmnInpEncoder : IEncoder<ItestCnstAltDmnInpObject>
{
  public Structured Encode(ItestCnstAltDmnInpObject input)
    => Structured.Empty();

  internal static testCnstAltDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnInpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnInpObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnInpEncoder : IEncoder<ItestDomCnstAltDmnInp>
{
  public Structured Encode(ItestDomCnstAltDmnInp input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDmnOutpEncoder : IEncoder<ItestCnstAltDmnOutpObject>
{
  public Structured Encode(ItestCnstAltDmnOutpObject input)
    => Structured.Empty();

  internal static testCnstAltDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDmnOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnOutpEncoder : IEncoder<ItestDomCnstAltDmnOutp>
{
  public Structured Encode(ItestDomCnstAltDmnOutp input)
    => input.Value!.Encode();

  internal static testDomCnstAltDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstAltDualDualEncoder : IEncoder<ItestCnstAltDualDualObject>
{
  public Structured Encode(ItestCnstAltDualDualObject input)
    => Structured.Empty();

  internal static testCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualDualEncoder<TRef> : IEncoder<ItestRefCnstAltDualDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltDualDualEncoder : IEncoder<ItestPrntCnstAltDualDualObject>
{
  public Structured Encode(ItestPrntCnstAltDualDualObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualDualObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualDualObject> _itestPrntCnstAltDualDual = encoders.EncoderFor<ItestPrntCnstAltDualDualObject>();
  public Structured Encode(ItestAltCnstAltDualDualObject input)
    => _itestPrntCnstAltDualDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltDualInpEncoder : IEncoder<ItestCnstAltDualInpObject>
{
  public Structured Encode(ItestCnstAltDualInpObject input)
    => Structured.Empty();

  internal static testCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualInpEncoder<TRef> : IEncoder<ItestRefCnstAltDualInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltDualInpEncoder : IEncoder<ItestPrntCnstAltDualInpObject>
{
  public Structured Encode(ItestPrntCnstAltDualInpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualInpObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualInpObject> _itestPrntCnstAltDualInp = encoders.EncoderFor<ItestPrntCnstAltDualInpObject>();
  public Structured Encode(ItestAltCnstAltDualInpObject input)
    => _itestPrntCnstAltDualInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltDualOutpEncoder : IEncoder<ItestCnstAltDualOutpObject>
{
  public Structured Encode(ItestCnstAltDualOutpObject input)
    => Structured.Empty();

  internal static testCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltDualOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltDualOutpEncoder : IEncoder<ItestPrntCnstAltDualOutpObject>
{
  public Structured Encode(ItestPrntCnstAltDualOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualOutpObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualOutpObject> _itestPrntCnstAltDualOutp = encoders.EncoderFor<ItestPrntCnstAltDualOutpObject>();
  public Structured Encode(ItestAltCnstAltDualOutpObject input)
    => _itestPrntCnstAltDualOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltObjDualEncoder : IEncoder<ItestCnstAltObjDualObject>
{
  public Structured Encode(ItestCnstAltObjDualObject input)
    => Structured.Empty();

  internal static testCnstAltObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjDualEncoder<TRef> : IEncoder<ItestRefCnstAltObjDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltObjDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltObjDualEncoder : IEncoder<ItestPrntCnstAltObjDualObject>
{
  public Structured Encode(ItestPrntCnstAltObjDualObject input)
    => Structured.Empty();

  internal static testPrntCnstAltObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjDualObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjDualObject> _itestPrntCnstAltObjDual = encoders.EncoderFor<ItestPrntCnstAltObjDualObject>();
  public Structured Encode(ItestAltCnstAltObjDualObject input)
    => _itestPrntCnstAltObjDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltObjInpEncoder : IEncoder<ItestCnstAltObjInpObject>
{
  public Structured Encode(ItestCnstAltObjInpObject input)
    => Structured.Empty();

  internal static testCnstAltObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjInpEncoder<TRef> : IEncoder<ItestRefCnstAltObjInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltObjInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltObjInpEncoder : IEncoder<ItestPrntCnstAltObjInpObject>
{
  public Structured Encode(ItestPrntCnstAltObjInpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjInpObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjInpObject> _itestPrntCnstAltObjInp = encoders.EncoderFor<ItestPrntCnstAltObjInpObject>();
  public Structured Encode(ItestAltCnstAltObjInpObject input)
    => _itestPrntCnstAltObjInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstAltObjOutpEncoder : IEncoder<ItestCnstAltObjOutpObject>
{
  public Structured Encode(ItestCnstAltObjOutpObject input)
    => Structured.Empty();

  internal static testCnstAltObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstAltObjOutpEncoder<TRef> : IEncoder<ItestRefCnstAltObjOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltObjOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltObjOutpEncoder : IEncoder<ItestPrntCnstAltObjOutpObject>
{
  public Structured Encode(ItestPrntCnstAltObjOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstAltObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjOutpObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjOutpObject> _itestPrntCnstAltObjOutp = encoders.EncoderFor<ItestPrntCnstAltObjOutpObject>();
  public Structured Encode(ItestAltCnstAltObjOutpObject input)
    => _itestPrntCnstAltObjOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstAltObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstDomEnumDualEncoder : IEncoder<ItestCnstDomEnumDualObject>
{
  public Structured Encode(ItestCnstDomEnumDualObject input)
    => Structured.Empty();

  internal static testCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumDualEncoder : IEncoder<testEnumCnstDomEnumDual>
{
  public Structured Encode(testEnumCnstDomEnumDual input)
    => input.EncodeEnum("EnumCnstDomEnumDual");

  internal static testEnumCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumDualEncoder : IEncoder<ItestJustCnstDomEnumDual>
{
  public Structured Encode(ItestJustCnstDomEnumDual input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumDual")!;

  internal static testJustCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstDomEnumInpEncoder : IEncoder<ItestCnstDomEnumInpObject>
{
  public Structured Encode(ItestCnstDomEnumInpObject input)
    => Structured.Empty();

  internal static testCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumInpEncoder : IEncoder<testEnumCnstDomEnumInp>
{
  public Structured Encode(testEnumCnstDomEnumInp input)
    => input.EncodeEnum("EnumCnstDomEnumInp");

  internal static testEnumCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumInpEncoder : IEncoder<ItestJustCnstDomEnumInp>
{
  public Structured Encode(ItestJustCnstDomEnumInp input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumInp")!;

  internal static testJustCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstDomEnumOutpEncoder : IEncoder<ItestCnstDomEnumOutpObject>
{
  public Structured Encode(ItestCnstDomEnumOutpObject input)
    => Structured.Empty();

  internal static testCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstDomEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstDomEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstDomEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstDomEnumOutpEncoder : IEncoder<testEnumCnstDomEnumOutp>
{
  public Structured Encode(testEnumCnstDomEnumOutp input)
    => input.EncodeEnum("EnumCnstDomEnumOutp");

  internal static testEnumCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpEncoder : IEncoder<ItestJustCnstDomEnumOutp>
{
  public Structured Encode(ItestJustCnstDomEnumOutp input)
    => input.Value?.EncodeEnum("testEnumCnstDomEnumOutp")!;

  internal static testJustCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumDualEncoder : IEncoder<ItestCnstEnumDualObject>
{
  public Structured Encode(ItestCnstEnumDualObject input)
    => Structured.Empty();

  internal static testCnstEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumDualEncoder : IEncoder<testEnumCnstEnumDual>
{
  public Structured Encode(testEnumCnstEnumDual input)
    => input.EncodeEnum("EnumCnstEnumDual");

  internal static testEnumCnstEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumInpEncoder : IEncoder<ItestCnstEnumInpObject>
{
  public Structured Encode(ItestCnstEnumInpObject input)
    => Structured.Empty();

  internal static testCnstEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumInpEncoder : IEncoder<testEnumCnstEnumInp>
{
  public Structured Encode(testEnumCnstEnumInp input)
    => input.EncodeEnum("EnumCnstEnumInp");

  internal static testEnumCnstEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumOutpEncoder : IEncoder<ItestCnstEnumOutpObject>
{
  public Structured Encode(ItestCnstEnumOutpObject input)
    => Structured.Empty();

  internal static testCnstEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumOutpEncoder : IEncoder<testEnumCnstEnumOutp>
{
  public Structured Encode(testEnumCnstEnumOutp input)
    => input.EncodeEnum("EnumCnstEnumOutp");

  internal static testEnumCnstEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumPrntDualEncoder : IEncoder<ItestCnstEnumPrntDualObject>
{
  public Structured Encode(ItestCnstEnumPrntDualObject input)
    => Structured.Empty();

  internal static testCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumPrntDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntDualEncoder : IEncoder<testEnumCnstEnumPrntDual>
{
  public Structured Encode(testEnumCnstEnumPrntDual input)
    => input.EncodeEnum("EnumCnstEnumPrntDual");

  internal static testEnumCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntDualEncoder : IEncoder<testParentCnstEnumPrntDual>
{
  public Structured Encode(testParentCnstEnumPrntDual input)
    => input.EncodeEnum("ParentCnstEnumPrntDual");

  internal static testParentCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumPrntInpEncoder : IEncoder<ItestCnstEnumPrntInpObject>
{
  public Structured Encode(ItestCnstEnumPrntInpObject input)
    => Structured.Empty();

  internal static testCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumPrntInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntInpEncoder : IEncoder<testEnumCnstEnumPrntInp>
{
  public Structured Encode(testEnumCnstEnumPrntInp input)
    => input.EncodeEnum("EnumCnstEnumPrntInp");

  internal static testEnumCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpEncoder : IEncoder<testParentCnstEnumPrntInp>
{
  public Structured Encode(testParentCnstEnumPrntInp input)
    => input.EncodeEnum("ParentCnstEnumPrntInp");

  internal static testParentCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstEnumPrntOutpEncoder : IEncoder<ItestCnstEnumPrntOutpObject>
{
  public Structured Encode(ItestCnstEnumPrntOutpObject input)
    => Structured.Empty();

  internal static testCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstEnumPrntOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstEnumPrntOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstEnumPrntOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstEnumPrntOutpEncoder : IEncoder<testEnumCnstEnumPrntOutp>
{
  public Structured Encode(testEnumCnstEnumPrntOutp input)
    => input.EncodeEnum("EnumCnstEnumPrntOutp");

  internal static testEnumCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpEncoder : IEncoder<testParentCnstEnumPrntOutp>
{
  public Structured Encode(testParentCnstEnumPrntOutp input)
    => input.EncodeEnum("ParentCnstEnumPrntOutp");

  internal static testParentCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDmnDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>> _itestRefCnstFieldDmnDual = encoders.EncoderFor<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>>();
  public Structured Encode(ItestCnstFieldDmnDualObject input)
    => _itestRefCnstFieldDmnDual.Encode(input);

  internal static testCnstFieldDmnDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDmnDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnDualEncoder : IEncoder<ItestDomCnstFieldDmnDual>
{
  public Structured Encode(ItestDomCnstFieldDmnDual input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDmnInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>> _itestRefCnstFieldDmnInp = encoders.EncoderFor<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>>();
  public Structured Encode(ItestCnstFieldDmnInpObject input)
    => _itestRefCnstFieldDmnInp.Encode(input);

  internal static testCnstFieldDmnInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDmnInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnInpEncoder : IEncoder<ItestDomCnstFieldDmnInp>
{
  public Structured Encode(ItestDomCnstFieldDmnInp input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDmnOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>> _itestRefCnstFieldDmnOutp = encoders.EncoderFor<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>>();
  public Structured Encode(ItestCnstFieldDmnOutpObject input)
    => _itestRefCnstFieldDmnOutp.Encode(input);

  internal static testCnstFieldDmnOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDmnOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDmnOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDmnOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomCnstFieldDmnOutpEncoder : IEncoder<ItestDomCnstFieldDmnOutp>
{
  public Structured Encode(ItestDomCnstFieldDmnOutp input)
    => input.Value!.Encode();

  internal static testDomCnstFieldDmnOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>> _itestRefCnstFieldDualDual = encoders.EncoderFor<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>>();
  public Structured Encode(ItestCnstFieldDualDualObject input)
    => _itestRefCnstFieldDualDual.Encode(input);

  internal static testCnstFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDualDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualDualEncoder : IEncoder<ItestPrntCnstFieldDualDualObject>
{
  public Structured Encode(ItestPrntCnstFieldDualDualObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualDualObject> _itestPrntCnstFieldDualDual = encoders.EncoderFor<ItestPrntCnstFieldDualDualObject>();
  public Structured Encode(ItestAltCnstFieldDualDualObject input)
    => _itestPrntCnstFieldDualDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>> _itestRefCnstFieldDualInp = encoders.EncoderFor<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>>();
  public Structured Encode(ItestCnstFieldDualInpObject input)
    => _itestRefCnstFieldDualInp.Encode(input);

  internal static testCnstFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDualInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualInpEncoder : IEncoder<ItestPrntCnstFieldDualInpObject>
{
  public Structured Encode(ItestPrntCnstFieldDualInpObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualInpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualInpObject> _itestPrntCnstFieldDualInp = encoders.EncoderFor<ItestPrntCnstFieldDualInpObject>();
  public Structured Encode(ItestAltCnstFieldDualInpObject input)
    => _itestPrntCnstFieldDualInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>> _itestRefCnstFieldDualOutp = encoders.EncoderFor<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>>();
  public Structured Encode(ItestCnstFieldDualOutpObject input)
    => _itestRefCnstFieldDualOutp.Encode(input);

  internal static testCnstFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldDualOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldDualOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldDualOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldDualOutpEncoder : IEncoder<ItestPrntCnstFieldDualOutpObject>
{
  public Structured Encode(ItestPrntCnstFieldDualOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualOutpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualOutpObject> _itestPrntCnstFieldDualOutp = encoders.EncoderFor<ItestPrntCnstFieldDualOutpObject>();
  public Structured Encode(ItestAltCnstFieldDualOutpObject input)
    => _itestPrntCnstFieldDualOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>> _itestRefCnstFieldObjDual = encoders.EncoderFor<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>>();
  public Structured Encode(ItestCnstFieldObjDualObject input)
    => _itestRefCnstFieldObjDual.Encode(input);

  internal static testCnstFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldObjDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjDualEncoder : IEncoder<ItestPrntCnstFieldObjDualObject>
{
  public Structured Encode(ItestPrntCnstFieldObjDualObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjDualObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjDualObject> _itestPrntCnstFieldObjDual = encoders.EncoderFor<ItestPrntCnstFieldObjDualObject>();
  public Structured Encode(ItestAltCnstFieldObjDualObject input)
    => _itestPrntCnstFieldObjDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>> _itestRefCnstFieldObjInp = encoders.EncoderFor<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>>();
  public Structured Encode(ItestCnstFieldObjInpObject input)
    => _itestRefCnstFieldObjInp.Encode(input);

  internal static testCnstFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldObjInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjInpEncoder : IEncoder<ItestPrntCnstFieldObjInpObject>
{
  public Structured Encode(ItestPrntCnstFieldObjInpObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjInpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjInpObject> _itestPrntCnstFieldObjInp = encoders.EncoderFor<ItestPrntCnstFieldObjInpObject>();
  public Structured Encode(ItestAltCnstFieldObjInpObject input)
    => _itestPrntCnstFieldObjInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>> _itestRefCnstFieldObjOutp = encoders.EncoderFor<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>>();
  public Structured Encode(ItestCnstFieldObjOutpObject input)
    => _itestRefCnstFieldObjOutp.Encode(input);

  internal static testCnstFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstFieldObjOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstFieldObjOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestRefCnstFieldObjOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testPrntCnstFieldObjOutpEncoder : IEncoder<ItestPrntCnstFieldObjOutpObject>
{
  public Structured Encode(ItestPrntCnstFieldObjOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjOutpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjOutpObject> _itestPrntCnstFieldObjOutp = encoders.EncoderFor<ItestPrntCnstFieldObjOutpObject>();
  public Structured Encode(ItestAltCnstFieldObjOutpObject input)
    => _itestPrntCnstFieldObjOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>> _itestRefCnstPrntDualGrndDual = encoders.EncoderFor<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>>();
  public Structured Encode(ItestCnstPrntDualGrndDualObject input)
    => _itestRefCnstPrntDualGrndDual.Encode(input);

  internal static testCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndDualEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualGrndDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGrndCnstPrntDualGrndDualEncoder : IEncoder<ItestGrndCnstPrntDualGrndDualObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndDualObject input)
    => Structured.Empty();

  internal static testGrndCnstPrntDualGrndDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndDualObject> _itestGrndCnstPrntDualGrndDual = encoders.EncoderFor<ItestGrndCnstPrntDualGrndDualObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndDualObject input)
    => _itestGrndCnstPrntDualGrndDual.Encode(input);

  internal static testPrntCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndDualObject> _itestPrntCnstPrntDualGrndDual = encoders.EncoderFor<ItestPrntCnstPrntDualGrndDualObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndDualObject input)
    => _itestPrntCnstPrntDualGrndDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>> _itestRefCnstPrntDualGrndInp = encoders.EncoderFor<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>>();
  public Structured Encode(ItestCnstPrntDualGrndInpObject input)
    => _itestRefCnstPrntDualGrndInp.Encode(input);

  internal static testCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndInpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualGrndInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGrndCnstPrntDualGrndInpEncoder : IEncoder<ItestGrndCnstPrntDualGrndInpObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndInpObject input)
    => Structured.Empty();

  internal static testGrndCnstPrntDualGrndInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndInpObject> _itestGrndCnstPrntDualGrndInp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndInpObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndInpObject input)
    => _itestGrndCnstPrntDualGrndInp.Encode(input);

  internal static testPrntCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndInpObject> _itestPrntCnstPrntDualGrndInp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndInpObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndInpObject input)
    => _itestPrntCnstPrntDualGrndInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>> _itestRefCnstPrntDualGrndOutp = encoders.EncoderFor<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>>();
  public Structured Encode(ItestCnstPrntDualGrndOutpObject input)
    => _itestRefCnstPrntDualGrndOutp.Encode(input);

  internal static testCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualGrndOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualGrndOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualGrndOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGrndCnstPrntDualGrndOutpEncoder : IEncoder<ItestGrndCnstPrntDualGrndOutpObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndOutpObject input)
    => Structured.Empty();

  internal static testGrndCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndOutpObject> _itestGrndCnstPrntDualGrndOutp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndOutpObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndOutpObject input)
    => _itestGrndCnstPrntDualGrndOutp.Encode(input);

  internal static testPrntCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testAltCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndOutpObject> _itestPrntCnstPrntDualGrndOutp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndOutpObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndOutpObject input)
    => _itestPrntCnstPrntDualGrndOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualGrndOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>> _itestRefCnstPrntDualPrntDual = encoders.EncoderFor<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>>();
  public Structured Encode(ItestCnstPrntDualPrntDualObject input)
    => _itestRefCnstPrntDualPrntDual.Encode(input);

  internal static testCnstPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntDualEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntDualEncoder : IEncoder<ItestPrntCnstPrntDualPrntDualObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntDualObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntDualObject> _itestPrntCnstPrntDualPrntDual = encoders.EncoderFor<ItestPrntCnstPrntDualPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntDualObject input)
    => _itestPrntCnstPrntDualPrntDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>> _itestRefCnstPrntDualPrntInp = encoders.EncoderFor<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>>();
  public Structured Encode(ItestCnstPrntDualPrntInpObject input)
    => _itestRefCnstPrntDualPrntInp.Encode(input);

  internal static testCnstPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntInpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntInpEncoder : IEncoder<ItestPrntCnstPrntDualPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntInpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntInpObject> _itestPrntCnstPrntDualPrntInp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntInpObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntInpObject input)
    => _itestPrntCnstPrntDualPrntInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>> _itestRefCnstPrntDualPrntOutp = encoders.EncoderFor<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>>();
  public Structured Encode(ItestCnstPrntDualPrntOutpObject input)
    => _itestRefCnstPrntDualPrntOutp.Encode(input);

  internal static testCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntDualPrntOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntDualPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntOutpEncoder : IEncoder<ItestPrntCnstPrntDualPrntOutpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntOutpObject> _itestPrntCnstPrntDualPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntOutpObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntOutpObject input)
    => _itestPrntCnstPrntDualPrntOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntEnumDualEncoder : IEncoder<ItestCnstPrntEnumDualObject>
{
  public Structured Encode(ItestCnstPrntEnumDualObject input)
    => Structured.Empty();

  internal static testCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstPrntEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumDualEncoder : IEncoder<testEnumCnstPrntEnumDual>
{
  public Structured Encode(testEnumCnstPrntEnumDual input)
    => input.EncodeEnum("EnumCnstPrntEnumDual");

  internal static testEnumCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumDualEncoder : IEncoder<testParentCnstPrntEnumDual>
{
  public Structured Encode(testParentCnstPrntEnumDual input)
    => input.EncodeEnum("ParentCnstPrntEnumDual");

  internal static testParentCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstPrntEnumInpEncoder : IEncoder<ItestCnstPrntEnumInpObject>
{
  public Structured Encode(ItestCnstPrntEnumInpObject input)
    => Structured.Empty();

  internal static testCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstPrntEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumInpEncoder : IEncoder<testEnumCnstPrntEnumInp>
{
  public Structured Encode(testEnumCnstPrntEnumInp input)
    => input.EncodeEnum("EnumCnstPrntEnumInp");

  internal static testEnumCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpEncoder : IEncoder<testParentCnstPrntEnumInp>
{
  public Structured Encode(testParentCnstPrntEnumInp input)
    => input.EncodeEnum("ParentCnstPrntEnumInp");

  internal static testParentCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstPrntEnumOutpEncoder : IEncoder<ItestCnstPrntEnumOutpObject>
{
  public Structured Encode(ItestCnstPrntEnumOutpObject input)
    => Structured.Empty();

  internal static testCnstPrntEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefCnstPrntEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefCnstPrntEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefCnstPrntEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumCnstPrntEnumOutpEncoder : IEncoder<testEnumCnstPrntEnumOutp>
{
  public Structured Encode(testEnumCnstPrntEnumOutp input)
    => input.EncodeEnum("EnumCnstPrntEnumOutp");

  internal static testEnumCnstPrntEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumOutpEncoder : IEncoder<testParentCnstPrntEnumOutp>
{
  public Structured Encode(testParentCnstPrntEnumOutp input)
    => input.EncodeEnum("ParentCnstPrntEnumOutp");

  internal static testParentCnstPrntEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>> _itestRefCnstPrntObjPrntDual = encoders.EncoderFor<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>>();
  public Structured Encode(ItestCnstPrntObjPrntDualObject input)
    => _itestRefCnstPrntObjPrntDual.Encode(input);

  internal static testCnstPrntObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntDualEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntDualEncoder : IEncoder<ItestPrntCnstPrntObjPrntDualObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntDualObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntObjPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntDualObject> _itestPrntCnstPrntObjPrntDual = encoders.EncoderFor<ItestPrntCnstPrntObjPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntDualObject input)
    => _itestPrntCnstPrntObjPrntDual.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>> _itestRefCnstPrntObjPrntInp = encoders.EncoderFor<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>>();
  public Structured Encode(ItestCnstPrntObjPrntInpObject input)
    => _itestRefCnstPrntObjPrntInp.Encode(input);

  internal static testCnstPrntObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntInpEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntInpEncoder : IEncoder<ItestPrntCnstPrntObjPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntInpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntObjPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntInpObject> _itestPrntCnstPrntObjPrntInp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntInpObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntInpObject input)
    => _itestPrntCnstPrntObjPrntInp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>> _itestRefCnstPrntObjPrntOutp = encoders.EncoderFor<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>>();
  public Structured Encode(ItestCnstPrntObjPrntOutpObject input)
    => _itestRefCnstPrntObjPrntOutp.Encode(input);

  internal static testCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefCnstPrntObjPrntOutpEncoder<TRef> : IEncoder<ItestRefCnstPrntObjPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntOutpEncoder : IEncoder<ItestPrntCnstPrntObjPrntOutpObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntOutpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntOutpObject> _itestPrntCnstPrntObjPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntOutpObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntOutpObject input)
    => _itestPrntCnstPrntObjPrntOutp.Encode(input)
      .Add("alt", input.Alt.Encode());

  internal static testAltCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldDualEncoder : IEncoder<ItestFieldDualObject>
{
  public Structured Encode(ItestFieldDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldInpEncoder : IEncoder<ItestFieldInpObject>
{
  public Structured Encode(ItestFieldInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldOutpEncoder : IEncoder<ItestFieldOutpObject>
{
  public Structured Encode(ItestFieldOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrDualEncoder : IEncoder<ItestFieldDescrDualObject>
{
  public Structured Encode(ItestFieldDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrInpEncoder : IEncoder<ItestFieldDescrInpObject>
{
  public Structured Encode(ItestFieldDescrInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrOutpEncoder : IEncoder<ItestFieldDescrOutpObject>
{
  public Structured Encode(ItestFieldDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualDualObject>
{
  private readonly IEncoder<ItestFldFieldDualDual> _itestFldFieldDualDual = encoders.EncoderFor<ItestFldFieldDualDual>();
  public Structured Encode(ItestFieldDualDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualDual);

  internal static testFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldDualDualEncoder : IEncoder<ItestFldFieldDualDualObject>
{
  public Structured Encode(ItestFldFieldDualDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualInpObject>
{
  private readonly IEncoder<ItestFldFieldDualInp> _itestFldFieldDualInp = encoders.EncoderFor<ItestFldFieldDualInp>();
  public Structured Encode(ItestFieldDualInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualInp);

  internal static testFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldDualInpEncoder : IEncoder<ItestFldFieldDualInpObject>
{
  public Structured Encode(ItestFldFieldDualInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualOutpObject>
{
  private readonly IEncoder<ItestFldFieldDualOutp> _itestFldFieldDualOutp = encoders.EncoderFor<ItestFldFieldDualOutp>();
  public Structured Encode(ItestFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualOutp);

  internal static testFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldDualOutpEncoder : IEncoder<ItestFldFieldDualOutpObject>
{
  public Structured Encode(ItestFldFieldDualOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumDualEncoder : IEncoder<ItestFieldEnumDualObject>
{
  public Structured Encode(ItestFieldEnumDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumDualEncoder : IEncoder<testEnumFieldEnumDual>
{
  public Structured Encode(testEnumFieldEnumDual input)
    => input.EncodeEnum("EnumFieldEnumDual");

  internal static testEnumFieldEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumInpEncoder : IEncoder<ItestFieldEnumInpObject>
{
  public Structured Encode(ItestFieldEnumInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumInpEncoder : IEncoder<testEnumFieldEnumInp>
{
  public Structured Encode(testEnumFieldEnumInp input)
    => input.EncodeEnum("EnumFieldEnumInp");

  internal static testEnumFieldEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumOutpEncoder : IEncoder<ItestFieldEnumOutpObject>
{
  public Structured Encode(ItestFieldEnumOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumOutpEncoder : IEncoder<testEnumFieldEnumOutp>
{
  public Structured Encode(testEnumFieldEnumOutp input)
    => input.EncodeEnum("EnumFieldEnumOutp");

  internal static testEnumFieldEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumPrntDualEncoder : IEncoder<ItestFieldEnumPrntDualObject>
{
  public Structured Encode(ItestFieldEnumPrntDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualEncoder : IEncoder<testEnumFieldEnumPrntDual>
{
  public Structured Encode(testEnumFieldEnumPrntDual input)
    => input.EncodeEnum("EnumFieldEnumPrntDual");

  internal static testEnumFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualEncoder : IEncoder<testPrntFieldEnumPrntDual>
{
  public Structured Encode(testPrntFieldEnumPrntDual input)
    => input.EncodeEnum("PrntFieldEnumPrntDual");

  internal static testPrntFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumPrntInpEncoder : IEncoder<ItestFieldEnumPrntInpObject>
{
  public Structured Encode(ItestFieldEnumPrntInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntInpEncoder : IEncoder<testEnumFieldEnumPrntInp>
{
  public Structured Encode(testEnumFieldEnumPrntInp input)
    => input.EncodeEnum("EnumFieldEnumPrntInp");

  internal static testEnumFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpEncoder : IEncoder<testPrntFieldEnumPrntInp>
{
  public Structured Encode(testPrntFieldEnumPrntInp input)
    => input.EncodeEnum("PrntFieldEnumPrntInp");

  internal static testPrntFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldEnumPrntOutpEncoder : IEncoder<ItestFieldEnumPrntOutpObject>
{
  public Structured Encode(ItestFieldEnumPrntOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntOutpEncoder : IEncoder<testEnumFieldEnumPrntOutp>
{
  public Structured Encode(testEnumFieldEnumPrntOutp input)
    => input.EncodeEnum("EnumFieldEnumPrntOutp");

  internal static testEnumFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpEncoder : IEncoder<testPrntFieldEnumPrntOutp>
{
  public Structured Encode(testPrntFieldEnumPrntOutp input)
    => input.EncodeEnum("PrntFieldEnumPrntOutp");

  internal static testPrntFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModEnumDualEncoder : IEncoder<ItestFieldModEnumDualObject>
{
  public Structured Encode(ItestFieldModEnumDualObject input)
    => Structured.Empty();

  internal static testFieldModEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumDualEncoder : IEncoder<testEnumFieldModEnumDual>
{
  public Structured Encode(testEnumFieldModEnumDual input)
    => input.EncodeEnum("EnumFieldModEnumDual");

  internal static testEnumFieldModEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModEnumInpEncoder : IEncoder<ItestFieldModEnumInpObject>
{
  public Structured Encode(ItestFieldModEnumInpObject input)
    => Structured.Empty();

  internal static testFieldModEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumInpEncoder : IEncoder<testEnumFieldModEnumInp>
{
  public Structured Encode(testEnumFieldModEnumInp input)
    => input.EncodeEnum("EnumFieldModEnumInp");

  internal static testEnumFieldModEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModEnumOutpEncoder : IEncoder<ItestFieldModEnumOutpObject>
{
  public Structured Encode(ItestFieldModEnumOutpObject input)
    => Structured.Empty();

  internal static testFieldModEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumOutpEncoder : IEncoder<testEnumFieldModEnumOutp>
{
  public Structured Encode(testEnumFieldModEnumOutp input)
    => input.EncodeEnum("EnumFieldModEnumOutp");

  internal static testEnumFieldModEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModParamDualEncoder<TMod> : IEncoder<ItestFieldModParamDualObject<TMod>>
{
  public Structured Encode(ItestFieldModParamDualObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamDualEncoder : IEncoder<ItestFldFieldModParamDualObject>
{
  public Structured Encode(ItestFldFieldModParamDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModParamInpEncoder<TMod> : IEncoder<ItestFieldModParamInpObject<TMod>>
{
  public Structured Encode(ItestFieldModParamInpObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamInpEncoder : IEncoder<ItestFldFieldModParamInpObject>
{
  public Structured Encode(ItestFldFieldModParamInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldModParamOutpEncoder<TMod> : IEncoder<ItestFieldModParamOutpObject<TMod>>
{
  public Structured Encode(ItestFieldModParamOutpObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamOutpEncoder : IEncoder<ItestFldFieldModParamOutpObject>
{
  public Structured Encode(ItestFldFieldModParamOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjDualObject>
{
  private readonly IEncoder<ItestFldFieldObjDual> _itestFldFieldObjDual = encoders.EncoderFor<ItestFldFieldObjDual>();
  public Structured Encode(ItestFieldObjDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjDual);

  internal static testFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjDualEncoder : IEncoder<ItestFldFieldObjDualObject>
{
  public Structured Encode(ItestFldFieldObjDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjInpObject>
{
  private readonly IEncoder<ItestFldFieldObjInp> _itestFldFieldObjInp = encoders.EncoderFor<ItestFldFieldObjInp>();
  public Structured Encode(ItestFieldObjInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjInp);

  internal static testFieldObjInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjInpEncoder : IEncoder<ItestFldFieldObjInpObject>
{
  public Structured Encode(ItestFldFieldObjInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjOutpObject>
{
  private readonly IEncoder<ItestFldFieldObjOutp> _itestFldFieldObjOutp = encoders.EncoderFor<ItestFldFieldObjOutp>();
  public Structured Encode(ItestFieldObjOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjOutp);

  internal static testFieldObjOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldFieldObjOutpEncoder : IEncoder<ItestFldFieldObjOutpObject>
{
  public Structured Encode(ItestFldFieldObjOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFldFieldObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplDualEncoder : IEncoder<ItestFieldSmplDualObject>
{
  public Structured Encode(ItestFieldSmplDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplInpEncoder : IEncoder<ItestFieldSmplInpObject>
{
  public Structured Encode(ItestFieldSmplInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplOutpEncoder : IEncoder<ItestFieldSmplOutpObject>
{
  public Structured Encode(ItestFieldSmplOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrDualEncoder : IEncoder<ItestFieldTypeDescrDualObject>
{
  public Structured Encode(ItestFieldTypeDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldTypeDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrInpEncoder : IEncoder<ItestFieldTypeDescrInpObject>
{
  public Structured Encode(ItestFieldTypeDescrInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldTypeDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrOutpEncoder : IEncoder<ItestFieldTypeDescrOutpObject>
{
  public Structured Encode(ItestFieldTypeDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testFieldTypeDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDualEncoder : IEncoder<ItestFieldValueDualObject>
{
  public Structured Encode(ItestFieldValueDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDualEncoder : IEncoder<testEnumFieldValueDual>
{
  public Structured Encode(testEnumFieldValueDual input)
    => input.EncodeEnum("EnumFieldValueDual");

  internal static testEnumFieldValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueInpEncoder : IEncoder<ItestFieldValueInpObject>
{
  public Structured Encode(ItestFieldValueInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueInpEncoder : IEncoder<testEnumFieldValueInp>
{
  public Structured Encode(testEnumFieldValueInp input)
    => input.EncodeEnum("EnumFieldValueInp");

  internal static testEnumFieldValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueOutpEncoder : IEncoder<ItestFieldValueOutpObject>
{
  public Structured Encode(ItestFieldValueOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueOutpEncoder : IEncoder<testEnumFieldValueOutp>
{
  public Structured Encode(testEnumFieldValueOutp input)
    => input.EncodeEnum("EnumFieldValueOutp");

  internal static testEnumFieldValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDescrDualEncoder : IEncoder<ItestFieldValueDescrDualObject>
{
  public Structured Encode(ItestFieldValueDescrDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrDualEncoder : IEncoder<testEnumFieldValueDescrDual>
{
  public Structured Encode(testEnumFieldValueDescrDual input)
    => input.EncodeEnum("EnumFieldValueDescrDual");

  internal static testEnumFieldValueDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDescrInpEncoder : IEncoder<ItestFieldValueDescrInpObject>
{
  public Structured Encode(ItestFieldValueDescrInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrInpEncoder : IEncoder<testEnumFieldValueDescrInp>
{
  public Structured Encode(testEnumFieldValueDescrInp input)
    => input.EncodeEnum("EnumFieldValueDescrInp");

  internal static testEnumFieldValueDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldValueDescrOutpEncoder : IEncoder<ItestFieldValueDescrOutpObject>
{
  public Structured Encode(ItestFieldValueDescrOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testFieldValueDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrOutpEncoder : IEncoder<testEnumFieldValueDescrOutp>
{
  public Structured Encode(testEnumFieldValueDescrOutp input)
    => input.EncodeEnum("EnumFieldValueDescrOutp");

  internal static testEnumFieldValueDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltDualEncoder<TType> : IEncoder<ItestGnrcAltDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltDualObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcAltInpEncoder<TType> : IEncoder<ItestGnrcAltInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltInpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcAltOutpEncoder<TType> : IEncoder<ItestGnrcAltOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltOutpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDualEncoder<TType> : IEncoder<ItestGnrcAltArgDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDualObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDualEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgInpEncoder<TType> : IEncoder<ItestGnrcAltArgInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgInpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgInpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgOutpEncoder<TType> : IEncoder<ItestGnrcAltArgOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgOutpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDescrDualEncoder<TType> : IEncoder<ItestGnrcAltArgDescrDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrDualObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrDualEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDescrInpEncoder<TType> : IEncoder<ItestGnrcAltArgDescrInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrInpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrInpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDescrOutpEncoder<TType> : IEncoder<ItestGnrcAltArgDescrOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrOutpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltArgDescrOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltDualDualEncoder : IEncoder<ItestGnrcAltDualDualObject>
{
  public Structured Encode(ItestGnrcAltDualDualObject input)
    => Structured.Empty();

  internal static testGnrcAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualDualEncoder<TRef> : IEncoder<ItestRefGnrcAltDualDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltDualDualEncoder : IEncoder<ItestAltGnrcAltDualDualObject>
{
  public Structured Encode(ItestAltGnrcAltDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltDualInpEncoder : IEncoder<ItestGnrcAltDualInpObject>
{
  public Structured Encode(ItestGnrcAltDualInpObject input)
    => Structured.Empty();

  internal static testGnrcAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualInpEncoder<TRef> : IEncoder<ItestRefGnrcAltDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltDualInpEncoder : IEncoder<ItestAltGnrcAltDualInpObject>
{
  public Structured Encode(ItestAltGnrcAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltDualOutpEncoder : IEncoder<ItestGnrcAltDualOutpObject>
{
  public Structured Encode(ItestGnrcAltDualOutpObject input)
    => Structured.Empty();

  internal static testGnrcAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltDualOutpEncoder : IEncoder<ItestAltGnrcAltDualOutpObject>
{
  public Structured Encode(ItestAltGnrcAltDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltModParamDualEncoder<TRef,TMod> : IEncoder<ItestRefGnrcAltModParamDualObject<TRef,TMod>>
{
  public Structured Encode(ItestRefGnrcAltModParamDualObject<TRef,TMod> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModParamInpEncoder<TRef,TMod> : IEncoder<ItestRefGnrcAltModParamInpObject<TRef,TMod>>
{
  public Structured Encode(ItestRefGnrcAltModParamInpObject<TRef,TMod> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModParamOutpEncoder<TRef,TMod> : IEncoder<ItestRefGnrcAltModParamOutpObject<TRef,TMod>>
{
  public Structured Encode(ItestRefGnrcAltModParamOutpObject<TRef,TMod> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModStrDualEncoder<TRef> : IEncoder<ItestRefGnrcAltModStrDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltModStrDualObject<TRef> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModStrInpEncoder<TRef> : IEncoder<ItestRefGnrcAltModStrInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltModStrInpObject<TRef> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModStrOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltModStrOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltModStrOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltParamDualEncoder : IEncoder<ItestGnrcAltParamDualObject>
{
  public Structured Encode(ItestGnrcAltParamDualObject input)
    => Structured.Empty();

  internal static testGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamDualEncoder<TRef> : IEncoder<ItestRefGnrcAltParamDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamDualEncoder : IEncoder<ItestAltGnrcAltParamDualObject>
{
  public Structured Encode(ItestAltGnrcAltParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltParamInpEncoder : IEncoder<ItestGnrcAltParamInpObject>
{
  public Structured Encode(ItestGnrcAltParamInpObject input)
    => Structured.Empty();

  internal static testGnrcAltParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamInpEncoder<TRef> : IEncoder<ItestRefGnrcAltParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamInpEncoder : IEncoder<ItestAltGnrcAltParamInpObject>
{
  public Structured Encode(ItestAltGnrcAltParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltParamOutpEncoder : IEncoder<ItestGnrcAltParamOutpObject>
{
  public Structured Encode(ItestGnrcAltParamOutpObject input)
    => Structured.Empty();

  internal static testGnrcAltParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltParamOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamOutpEncoder : IEncoder<ItestAltGnrcAltParamOutpObject>
{
  public Structured Encode(ItestAltGnrcAltParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcAltParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcAltSmplDualEncoder : IEncoder<ItestGnrcAltSmplDualObject>
{
  public Structured Encode(ItestGnrcAltSmplDualObject input)
    => Structured.Empty();

  internal static testGnrcAltSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplDualEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltSmplInpEncoder : IEncoder<ItestGnrcAltSmplInpObject>
{
  public Structured Encode(ItestGnrcAltSmplInpObject input)
    => Structured.Empty();

  internal static testGnrcAltSmplInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplInpEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltSmplOutpEncoder : IEncoder<ItestGnrcAltSmplOutpObject>
{
  public Structured Encode(ItestGnrcAltSmplOutpObject input)
    => Structured.Empty();

  internal static testGnrcAltSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcAltSmplOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcDescrDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcDescrInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcDescrOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcEnumDualEncoder : IEncoder<ItestGnrcEnumDualObject>
{
  public Structured Encode(ItestGnrcEnumDualObject input)
    => Structured.Empty();

  internal static testGnrcEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcEnumDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumDualEncoder : IEncoder<testEnumGnrcEnumDual>
{
  public Structured Encode(testEnumGnrcEnumDual input)
    => input.EncodeEnum("EnumGnrcEnumDual");

  internal static testEnumGnrcEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcEnumInpEncoder : IEncoder<ItestGnrcEnumInpObject>
{
  public Structured Encode(ItestGnrcEnumInpObject input)
    => Structured.Empty();

  internal static testGnrcEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcEnumInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumInpEncoder : IEncoder<testEnumGnrcEnumInp>
{
  public Structured Encode(testEnumGnrcEnumInp input)
    => input.EncodeEnum("EnumGnrcEnumInp");

  internal static testEnumGnrcEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcEnumOutpEncoder : IEncoder<ItestGnrcEnumOutpObject>
{
  public Structured Encode(ItestGnrcEnumOutpObject input)
    => Structured.Empty();

  internal static testGnrcEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcEnumOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcEnumOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcEnumOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcEnumOutpEncoder : IEncoder<testEnumGnrcEnumOutp>
{
  public Structured Encode(testEnumGnrcEnumOutp input)
    => input.EncodeEnum("EnumGnrcEnumOutp");

  internal static testEnumGnrcEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldArgDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgDualObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgDual<TType>> _itestRefGnrcFieldArgDual = encoders.EncoderFor<ItestRefGnrcFieldArgDual<TType>>();
  public Structured Encode(ItestGnrcFieldArgDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgDual);
}

internal class testRefGnrcFieldArgDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcFieldArgInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgInpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgInp<TType>> _itestRefGnrcFieldArgInp = encoders.EncoderFor<ItestRefGnrcFieldArgInp<TType>>();
  public Structured Encode(ItestGnrcFieldArgInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgInp);
}

internal class testRefGnrcFieldArgInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcFieldArgOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgOutpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgOutp<TType>> _itestRefGnrcFieldArgOutp = encoders.EncoderFor<ItestRefGnrcFieldArgOutp<TType>>();
  public Structured Encode(ItestGnrcFieldArgOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgOutp);
}

internal class testRefGnrcFieldArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualDualObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>> _itestRefGnrcFieldDualDual = encoders.EncoderFor<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>>();
  public Structured Encode(ItestGnrcFieldDualDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualDual);

  internal static testGnrcFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldDualDualEncoder : IEncoder<ItestAltGnrcFieldDualDualObject>
{
  public Structured Encode(ItestAltGnrcFieldDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualInpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>> _itestRefGnrcFieldDualInp = encoders.EncoderFor<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>>();
  public Structured Encode(ItestGnrcFieldDualInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualInp);

  internal static testGnrcFieldDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldDualInpEncoder : IEncoder<ItestAltGnrcFieldDualInpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>> _itestRefGnrcFieldDualOutp = encoders.EncoderFor<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>>();
  public Structured Encode(ItestGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualOutp);

  internal static testGnrcFieldDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldDualOutpEncoder : IEncoder<ItestAltGnrcFieldDualOutpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamDualObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>> _itestRefGnrcFieldParamDual = encoders.EncoderFor<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>>();
  public Structured Encode(ItestGnrcFieldParamDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamDual);

  internal static testGnrcFieldParamDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamDualEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamDualEncoder : IEncoder<ItestAltGnrcFieldParamDualObject>
{
  public Structured Encode(ItestAltGnrcFieldParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamInpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>> _itestRefGnrcFieldParamInp = encoders.EncoderFor<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>>();
  public Structured Encode(ItestGnrcFieldParamInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamInp);

  internal static testGnrcFieldParamInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamInpEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamInpEncoder : IEncoder<ItestAltGnrcFieldParamInpObject>
{
  public Structured Encode(ItestAltGnrcFieldParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcFieldParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>> _itestRefGnrcFieldParamOutp = encoders.EncoderFor<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>>();
  public Structured Encode(ItestGnrcFieldParamOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamOutp);

  internal static testGnrcFieldParamOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcFieldParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcFieldParamOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamOutpEncoder : IEncoder<ItestAltGnrcFieldParamOutpObject>
{
  public Structured Encode(ItestAltGnrcFieldParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcFieldParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualEncoder<TType> : IEncoder<ItestGnrcPrntDualObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDualObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntInpEncoder<TType> : IEncoder<ItestGnrcPrntInpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntInpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntOutpEncoder<TType> : IEncoder<ItestGnrcPrntOutpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntOutpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntArgDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgDualObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgDualObject<TType>> _itestRefGnrcPrntArgDual = encoders.EncoderFor<ItestRefGnrcPrntArgDualObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgDualObject<TType> input)
    => _itestRefGnrcPrntArgDual.Encode(input);
}

internal class testRefGnrcPrntArgDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcPrntArgInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgInpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgInpObject<TType>> _itestRefGnrcPrntArgInp = encoders.EncoderFor<ItestRefGnrcPrntArgInpObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgInpObject<TType> input)
    => _itestRefGnrcPrntArgInp.Encode(input);
}

internal class testRefGnrcPrntArgInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcPrntArgOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgOutpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgOutpObject<TType>> _itestRefGnrcPrntArgOutp = encoders.EncoderFor<ItestRefGnrcPrntArgOutpObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgOutpObject<TType> input)
    => _itestRefGnrcPrntArgOutp.Encode(input);
}

internal class testRefGnrcPrntArgOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcPrntDescrDualEncoder<TType> : IEncoder<ItestGnrcPrntDescrDualObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDescrDualObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntDescrInpEncoder<TType> : IEncoder<ItestGnrcPrntDescrInpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDescrInpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntDescrOutpEncoder<TType> : IEncoder<ItestGnrcPrntDescrOutpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDescrOutpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>> _itestRefGnrcPrntDualDual = encoders.EncoderFor<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>>();
  public Structured Encode(ItestGnrcPrntDualDualObject input)
    => _itestRefGnrcPrntDualDual.Encode(input);

  internal static testGnrcPrntDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualDualEncoder : IEncoder<ItestAltGnrcPrntDualDualObject>
{
  public Structured Encode(ItestAltGnrcPrntDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>> _itestRefGnrcPrntDualInp = encoders.EncoderFor<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>>();
  public Structured Encode(ItestGnrcPrntDualInpObject input)
    => _itestRefGnrcPrntDualInp.Encode(input);

  internal static testGnrcPrntDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualInpEncoder : IEncoder<ItestAltGnrcPrntDualInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>> _itestRefGnrcPrntDualOutp = encoders.EncoderFor<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>>();
  public Structured Encode(ItestGnrcPrntDualOutpObject input)
    => _itestRefGnrcPrntDualOutp.Encode(input);

  internal static testGnrcPrntDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualOutpEncoder : IEncoder<ItestAltGnrcPrntDualOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>> _itestRefGnrcPrntDualPrntDual = encoders.EncoderFor<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>>();
  public Structured Encode(ItestGnrcPrntDualPrntDualObject input)
    => _itestRefGnrcPrntDualPrntDual.Encode(input);

  internal static testGnrcPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualPrntDualEncoder : IEncoder<ItestAltGnrcPrntDualPrntDualObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>> _itestRefGnrcPrntDualPrntInp = encoders.EncoderFor<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>>();
  public Structured Encode(ItestGnrcPrntDualPrntInpObject input)
    => _itestRefGnrcPrntDualPrntInp.Encode(input);

  internal static testGnrcPrntDualPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualPrntInpEncoder : IEncoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>> _itestRefGnrcPrntDualPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>>();
  public Structured Encode(ItestGnrcPrntDualPrntOutpObject input)
    => _itestRefGnrcPrntDualPrntOutp.Encode(input);

  internal static testGnrcPrntDualPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntDualPrntOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntDualPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntDualPrntOutpEncoder : IEncoder<ItestAltGnrcPrntDualPrntOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntDualPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumChildDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>> _itestFieldGnrcPrntEnumChildDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>>();
  public Structured Encode(ItestGnrcPrntEnumChildDualObject input)
    => _itestFieldGnrcPrntEnumChildDual.Encode(input);

  internal static testGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumChildDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumChildDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildDualEncoder : IEncoder<testEnumGnrcPrntEnumChildDual>
{
  public Structured Encode(testEnumGnrcPrntEnumChildDual input)
    => input.EncodeEnum("EnumGnrcPrntEnumChildDual");

  internal static testEnumGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildDualEncoder : IEncoder<testParentGnrcPrntEnumChildDual>
{
  public Structured Encode(testParentGnrcPrntEnumChildDual input)
    => input.EncodeEnum("ParentGnrcPrntEnumChildDual");

  internal static testParentGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumChildInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>> _itestFieldGnrcPrntEnumChildInp = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>>();
  public Structured Encode(ItestGnrcPrntEnumChildInpObject input)
    => _itestFieldGnrcPrntEnumChildInp.Encode(input);

  internal static testGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumChildInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumChildInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildInpEncoder : IEncoder<testEnumGnrcPrntEnumChildInp>
{
  public Structured Encode(testEnumGnrcPrntEnumChildInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumChildInp");

  internal static testEnumGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpEncoder : IEncoder<testParentGnrcPrntEnumChildInp>
{
  public Structured Encode(testParentGnrcPrntEnumChildInp input)
    => input.EncodeEnum("ParentGnrcPrntEnumChildInp");

  internal static testParentGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumChildOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>> _itestFieldGnrcPrntEnumChildOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>>();
  public Structured Encode(ItestGnrcPrntEnumChildOutpObject input)
    => _itestFieldGnrcPrntEnumChildOutp.Encode(input);

  internal static testGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumChildOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumChildOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumChildOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumChildOutpEncoder : IEncoder<testEnumGnrcPrntEnumChildOutp>
{
  public Structured Encode(testEnumGnrcPrntEnumChildOutp input)
    => input.EncodeEnum("EnumGnrcPrntEnumChildOutp");

  internal static testEnumGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpEncoder : IEncoder<testParentGnrcPrntEnumChildOutp>
{
  public Structured Encode(testParentGnrcPrntEnumChildOutp input)
    => input.EncodeEnum("ParentGnrcPrntEnumChildOutp");

  internal static testParentGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>> _itestFieldGnrcPrntEnumDomDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>>();
  public Structured Encode(ItestGnrcPrntEnumDomDualObject input)
    => _itestFieldGnrcPrntEnumDomDual.Encode(input);

  internal static testGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumDomDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumDomDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomDualEncoder : IEncoder<testEnumGnrcPrntEnumDomDual>
{
  public Structured Encode(testEnumGnrcPrntEnumDomDual input)
    => input.EncodeEnum("EnumGnrcPrntEnumDomDual");

  internal static testEnumGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomDualEncoder : IEncoder<ItestDomGnrcPrntEnumDomDual>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomDual input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomDual")!;

  internal static testDomGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>> _itestFieldGnrcPrntEnumDomInp = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>>();
  public Structured Encode(ItestGnrcPrntEnumDomInpObject input)
    => _itestFieldGnrcPrntEnumDomInp.Encode(input);

  internal static testGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumDomInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumDomInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomInpEncoder : IEncoder<testEnumGnrcPrntEnumDomInp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumDomInp");

  internal static testEnumGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomInp input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomInp")!;

  internal static testDomGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>> _itestFieldGnrcPrntEnumDomOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>>();
  public Structured Encode(ItestGnrcPrntEnumDomOutpObject input)
    => _itestFieldGnrcPrntEnumDomOutp.Encode(input);

  internal static testGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumDomOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumDomOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumDomOutpEncoder : IEncoder<testEnumGnrcPrntEnumDomOutp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomOutp input)
    => input.EncodeEnum("EnumGnrcPrntEnumDomOutp");

  internal static testEnumGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomOutpEncoder : IEncoder<ItestDomGnrcPrntEnumDomOutp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomOutp input)
    => input.Value?.EncodeEnum("testEnumGnrcPrntEnumDomOutp")!;

  internal static testDomGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>> _itestFieldGnrcPrntEnumPrntDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>>();
  public Structured Encode(ItestGnrcPrntEnumPrntDualObject input)
    => _itestFieldGnrcPrntEnumPrntDual.Encode(input);

  internal static testGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumPrntDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumPrntDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntDualEncoder : IEncoder<testEnumGnrcPrntEnumPrntDual>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntDual input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntDual");

  internal static testEnumGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntDualEncoder : IEncoder<testParentGnrcPrntEnumPrntDual>
{
  public Structured Encode(testParentGnrcPrntEnumPrntDual input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntDual");

  internal static testParentGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>> _itestFieldGnrcPrntEnumPrntInp = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>>();
  public Structured Encode(ItestGnrcPrntEnumPrntInpObject input)
    => _itestFieldGnrcPrntEnumPrntInp.Encode(input);

  internal static testGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumPrntInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumPrntInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntInpEncoder : IEncoder<testEnumGnrcPrntEnumPrntInp>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntInp input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntInp");

  internal static testEnumGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpEncoder : IEncoder<testParentGnrcPrntEnumPrntInp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntInp input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntInp");

  internal static testParentGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>> _itestFieldGnrcPrntEnumPrntOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>>();
  public Structured Encode(ItestGnrcPrntEnumPrntOutpObject input)
    => _itestFieldGnrcPrntEnumPrntOutp.Encode(input);

  internal static testGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntEnumPrntOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntEnumPrntOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntEnumPrntOutpEncoder : IEncoder<testEnumGnrcPrntEnumPrntOutp>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntOutp input)
    => input.EncodeEnum("EnumGnrcPrntEnumPrntOutp");

  internal static testEnumGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpEncoder : IEncoder<testParentGnrcPrntEnumPrntOutp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntOutp input)
    => input.EncodeEnum("ParentGnrcPrntEnumPrntOutp");

  internal static testParentGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>> _itestRefGnrcPrntParamDual = encoders.EncoderFor<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>>();
  public Structured Encode(ItestGnrcPrntParamDualObject input)
    => _itestRefGnrcPrntParamDual.Encode(input);

  internal static testGnrcPrntParamDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamDualEncoder : IEncoder<ItestAltGnrcPrntParamDualObject>
{
  public Structured Encode(ItestAltGnrcPrntParamDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>> _itestRefGnrcPrntParamInp = encoders.EncoderFor<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>>();
  public Structured Encode(ItestGnrcPrntParamInpObject input)
    => _itestRefGnrcPrntParamInp.Encode(input);

  internal static testGnrcPrntParamInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamInpEncoder : IEncoder<ItestAltGnrcPrntParamInpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>> _itestRefGnrcPrntParamOutp = encoders.EncoderFor<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>>();
  public Structured Encode(ItestGnrcPrntParamOutpObject input)
    => _itestRefGnrcPrntParamOutp.Encode(input);

  internal static testGnrcPrntParamOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamOutpEncoder : IEncoder<ItestAltGnrcPrntParamOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>> _itestRefGnrcPrntParamPrntDual = encoders.EncoderFor<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>>();
  public Structured Encode(ItestGnrcPrntParamPrntDualObject input)
    => _itestRefGnrcPrntParamPrntDual.Encode(input);

  internal static testGnrcPrntParamPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntDualEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamPrntDualObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamPrntDualEncoder : IEncoder<ItestAltGnrcPrntParamPrntDualObject>
{
  public Structured Encode(ItestAltGnrcPrntParamPrntDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>> _itestRefGnrcPrntParamPrntInp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>>();
  public Structured Encode(ItestGnrcPrntParamPrntInpObject input)
    => _itestRefGnrcPrntParamPrntInp.Encode(input);

  internal static testGnrcPrntParamPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntInpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamPrntInpEncoder : IEncoder<ItestAltGnrcPrntParamPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntParamPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>> _itestRefGnrcPrntParamPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>>();
  public Structured Encode(ItestGnrcPrntParamPrntOutpObject input)
    => _itestRefGnrcPrntParamPrntOutp.Encode(input);

  internal static testGnrcPrntParamPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefGnrcPrntParamPrntOutpEncoder<TRef> : IEncoder<ItestRefGnrcPrntParamPrntOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamPrntOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamPrntOutpEncoder : IEncoder<ItestAltGnrcPrntParamPrntOutpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamPrntOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt.Encode());

  internal static testAltGnrcPrntParamPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>> _itestFieldGnrcPrntSmplEnumDual = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>>();
  public Structured Encode(ItestGnrcPrntSmplEnumDualObject input)
    => _itestFieldGnrcPrntSmplEnumDual.Encode(input);

  internal static testGnrcPrntSmplEnumDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntSmplEnumDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumDualEncoder : IEncoder<testEnumGnrcPrntSmplEnumDual>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumDual input)
    => input.EncodeEnum("EnumGnrcPrntSmplEnumDual");

  internal static testEnumGnrcPrntSmplEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>> _itestFieldGnrcPrntSmplEnumInp = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>>();
  public Structured Encode(ItestGnrcPrntSmplEnumInpObject input)
    => _itestFieldGnrcPrntSmplEnumInp.Encode(input);

  internal static testGnrcPrntSmplEnumInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntSmplEnumInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumInpEncoder : IEncoder<testEnumGnrcPrntSmplEnumInp>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumInp input)
    => input.EncodeEnum("EnumGnrcPrntSmplEnumInp");

  internal static testEnumGnrcPrntSmplEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>> _itestFieldGnrcPrntSmplEnumOutp = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>>();
  public Structured Encode(ItestGnrcPrntSmplEnumOutpObject input)
    => _itestFieldGnrcPrntSmplEnumOutp.Encode(input);

  internal static testGnrcPrntSmplEnumOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntSmplEnumOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntSmplEnumOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntSmplEnumOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testEnumGnrcPrntSmplEnumOutpEncoder : IEncoder<testEnumGnrcPrntSmplEnumOutp>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumOutp input)
    => input.EncodeEnum("EnumGnrcPrntSmplEnumOutp");

  internal static testEnumGnrcPrntSmplEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntStrDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>> _itestFieldGnrcPrntStrDomDual = encoders.EncoderFor<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>>();
  public Structured Encode(ItestGnrcPrntStrDomDualObject input)
    => _itestFieldGnrcPrntStrDomDual.Encode(input);

  internal static testGnrcPrntStrDomDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntStrDomDualEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomDualObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntStrDomDualObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomDualEncoder : IEncoder<ItestDomGnrcPrntStrDomDual>
{
  public Structured Encode(ItestDomGnrcPrntStrDomDual input)
    => input.Value!.Encode();

  internal static testDomGnrcPrntStrDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntStrDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>> _itestFieldGnrcPrntStrDomInp = encoders.EncoderFor<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>>();
  public Structured Encode(ItestGnrcPrntStrDomInpObject input)
    => _itestFieldGnrcPrntStrDomInp.Encode(input);

  internal static testGnrcPrntStrDomInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntStrDomInpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomInpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntStrDomInpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomInpEncoder : IEncoder<ItestDomGnrcPrntStrDomInp>
{
  public Structured Encode(ItestDomGnrcPrntStrDomInp input)
    => input.Value!.Encode();

  internal static testDomGnrcPrntStrDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcPrntStrDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>> _itestFieldGnrcPrntStrDomOutp = encoders.EncoderFor<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>>();
  public Structured Encode(ItestGnrcPrntStrDomOutpObject input)
    => _itestFieldGnrcPrntStrDomOutp.Encode(input);

  internal static testGnrcPrntStrDomOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldGnrcPrntStrDomOutpEncoder<TRef>(
  IEncoderRepository encoders
) : IEncoder<ItestFieldGnrcPrntStrDomOutpObject<TRef>>
{
  private readonly IEncoder<TRef> _ref = encoders.EncoderFor<TRef>();
  public Structured Encode(ItestFieldGnrcPrntStrDomOutpObject<TRef> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _ref);
}

internal class testDomGnrcPrntStrDomOutpEncoder : IEncoder<ItestDomGnrcPrntStrDomOutp>
{
  public Structured Encode(ItestDomGnrcPrntStrDomOutp input)
    => input.Value!.Encode();

  internal static testDomGnrcPrntStrDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcValueDualEncoder : IEncoder<ItestGnrcValueDualObject>
{
  public Structured Encode(ItestGnrcValueDualObject input)
    => Structured.Empty();

  internal static testGnrcValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcValueDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueDualEncoder : IEncoder<testEnumGnrcValueDual>
{
  public Structured Encode(testEnumGnrcValueDual input)
    => input.EncodeEnum("EnumGnrcValueDual");

  internal static testEnumGnrcValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcValueInpEncoder : IEncoder<ItestGnrcValueInpObject>
{
  public Structured Encode(ItestGnrcValueInpObject input)
    => Structured.Empty();

  internal static testGnrcValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcValueInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueInpEncoder : IEncoder<testEnumGnrcValueInp>
{
  public Structured Encode(testEnumGnrcValueInp input)
    => input.EncodeEnum("EnumGnrcValueInp");

  internal static testEnumGnrcValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testGnrcValueOutpEncoder : IEncoder<ItestGnrcValueOutpObject>
{
  public Structured Encode(ItestGnrcValueOutpObject input)
    => Structured.Empty();

  internal static testGnrcValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefGnrcValueOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefGnrcValueOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefGnrcValueOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumGnrcValueOutpEncoder : IEncoder<testEnumGnrcValueOutp>
{
  public Structured Encode(testEnumGnrcValueOutp input)
    => input.EncodeEnum("EnumGnrcValueOutp");

  internal static testEnumGnrcValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldDescrNmbrEncoder : IEncoder<ItestInpFieldDescrNmbrObject>
{
  public Structured Encode(ItestInpFieldDescrNmbrObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testInpFieldDescrNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldEnumEncoder : IEncoder<ItestInpFieldEnumObject>
{
  public Structured Encode(ItestInpFieldEnumObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);

  internal static testInpFieldEnumEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumInpFieldEnumEncoder : IEncoder<testEnumInpFieldEnum>
{
  public Structured Encode(testEnumInpFieldEnum input)
    => input.EncodeEnum("EnumInpFieldEnum");

  internal static testEnumInpFieldEnumEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldNullEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestInpFieldNullObject>
{
  private readonly IEncoder<ItestFldInpFieldNull> _itestFldInpFieldNull = encoders.EncoderFor<ItestFldInpFieldNull>();
  public Structured Encode(ItestInpFieldNullObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldInpFieldNull);

  internal static testInpFieldNullEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldInpFieldNullEncoder : IEncoder<ItestFldInpFieldNullObject>
{
  public Structured Encode(ItestFldInpFieldNullObject input)
    => Structured.Empty();

  internal static testFldInpFieldNullEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldNmbrEncoder : IEncoder<ItestInpFieldNmbrObject>
{
  public Structured Encode(ItestInpFieldNmbrObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testInpFieldNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldNmbrDescrEncoder : IEncoder<ItestInpFieldNmbrDescrObject>
{
  public Structured Encode(ItestInpFieldNmbrDescrObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testInpFieldNmbrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInpFieldStrEncoder : IEncoder<ItestInpFieldStrObject>
{
  public Structured Encode(ItestInpFieldStrObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testInpFieldStrEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpDescrParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpDescrParamObject>
{
  private readonly IEncoder<ItestFldOutpDescrParam> _itestFldOutpDescrParam = encoders.EncoderFor<ItestFldOutpDescrParam>();
  public Structured Encode(ItestOutpDescrParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldOutpDescrParam);

  internal static testOutpDescrParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpDescrParamEncoder : IEncoder<ItestFldOutpDescrParamObject>
{
  public Structured Encode(ItestFldOutpDescrParamObject input)
    => Structured.Empty();

  internal static testFldOutpDescrParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpDescrParamEncoder : IEncoder<ItestInOutpDescrParamObject>
{
  public Structured Encode(ItestInOutpDescrParamObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpDescrParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamObject>
{
  private readonly IEncoder<ItestFldOutpParam> _itestFldOutpParam = encoders.EncoderFor<ItestFldOutpParam>();
  public Structured Encode(ItestOutpParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldOutpParam);

  internal static testOutpParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamEncoder : IEncoder<ItestFldOutpParamObject>
{
  public Structured Encode(ItestFldOutpParamObject input)
    => Structured.Empty();

  internal static testFldOutpParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpParamEncoder : IEncoder<ItestInOutpParamObject>
{
  public Structured Encode(ItestInOutpParamObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamDescr> _itestFldOutpParamDescr = encoders.EncoderFor<ItestFldOutpParamDescr>();
  public Structured Encode(ItestOutpParamDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldOutpParamDescr);

  internal static testOutpParamDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamDescrEncoder : IEncoder<ItestFldOutpParamDescrObject>
{
  public Structured Encode(ItestFldOutpParamDescrObject input)
    => Structured.Empty();

  internal static testFldOutpParamDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpParamDescrEncoder : IEncoder<ItestInOutpParamDescrObject>
{
  public Structured Encode(ItestInOutpParamDescrObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamModDmnEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModDmnObject>
{
  private readonly IEncoder<ItestDomOutpParamModDmn> _itestDomOutpParamModDmn = encoders.EncoderFor<ItestDomOutpParamModDmn>();
  public Structured Encode(ItestOutpParamModDmnObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestDomOutpParamModDmn);

  internal static testOutpParamModDmnEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testInOutpParamModDmnEncoder : IEncoder<ItestInOutpParamModDmnObject>
{
  public Structured Encode(ItestInOutpParamModDmnObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamModDmnEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomOutpParamModDmnEncoder : IEncoder<ItestDomOutpParamModDmn>
{
  public Structured Encode(ItestDomOutpParamModDmn input)
    => input.Value!.Encode();

  internal static testDomOutpParamModDmnEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamModParamEncoder<TMod>(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModParamObject<TMod>>
{
  private readonly IEncoder<ItestDomOutpParamModParam> _itestDomOutpParamModParam = encoders.EncoderFor<ItestDomOutpParamModParam>();
  public Structured Encode(ItestOutpParamModParamObject<TMod> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestDomOutpParamModParam);
}

internal class testInOutpParamModParamEncoder : IEncoder<ItestInOutpParamModParamObject>
{
  public Structured Encode(ItestInOutpParamModParamObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamModParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomOutpParamModParamEncoder : IEncoder<ItestDomOutpParamModParam>
{
  public Structured Encode(ItestDomOutpParamModParam input)
    => input.Value!.Encode();

  internal static testDomOutpParamModParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamTypeDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamTypeDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamTypeDescr> _itestFldOutpParamTypeDescr = encoders.EncoderFor<ItestFldOutpParamTypeDescr>();
  public Structured Encode(ItestOutpParamTypeDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldOutpParamTypeDescr);

  internal static testOutpParamTypeDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public Structured Encode(ItestFldOutpParamTypeDescrObject input)
    => Structured.Empty();

  internal static testFldOutpParamTypeDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpParamTypeDescrEncoder : IEncoder<ItestInOutpParamTypeDescrObject>
{
  public Structured Encode(ItestInOutpParamTypeDescrObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpParamTypeDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpPrntGnrcEncoder : IEncoder<ItestOutpPrntGnrcObject>
{
  public Structured Encode(ItestOutpPrntGnrcObject input)
    => Structured.Empty();

  internal static testOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefOutpPrntGnrcEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestRefOutpPrntGnrcObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestRefOutpPrntGnrcObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testEnumOutpPrntGnrcEncoder : IEncoder<testEnumOutpPrntGnrc>
{
  public Structured Encode(testEnumOutpPrntGnrc input)
    => input.EncodeEnum("EnumOutpPrntGnrc");

  internal static testEnumOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcEncoder : IEncoder<testPrntOutpPrntGnrc>
{
  public Structured Encode(testPrntOutpPrntGnrc input)
    => input.EncodeEnum("PrntOutpPrntGnrc");

  internal static testPrntOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpPrntParamObject>
{
  private readonly IEncoder<ItestPrntOutpPrntParamObject> _itestPrntOutpPrntParam = encoders.EncoderFor<ItestPrntOutpPrntParamObject>();
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestOutpPrntParamObject input)
    => _itestPrntOutpPrntParam.Encode(input)
      .AddEncoded("field", input.Field, _itestFldOutpPrntParam);

  internal static testOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpPrntParamObject>
{
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestPrntOutpPrntParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldOutpPrntParam);

  internal static testPrntOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpPrntParamEncoder : IEncoder<ItestFldOutpPrntParamObject>
{
  public Structured Encode(ItestFldOutpPrntParamObject input)
    => Structured.Empty();

  internal static testFldOutpPrntParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testInOutpPrntParamEncoder : IEncoder<ItestInOutpPrntParamObject>
{
  public Structured Encode(ItestInOutpPrntParamObject input)
    => Structured.Empty()
      .Add("param", input.Param.Encode());

  internal static testInOutpPrntParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpPrntParamInEncoder : IEncoder<ItestPrntOutpPrntParamInObject>
{
  public Structured Encode(ItestPrntOutpPrntParamInObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testPrntOutpPrntParamInEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualObject>
{
  private readonly IEncoder<ItestRefPrntDualObject> _itestRefPrntDual = encoders.EncoderFor<ItestRefPrntDualObject>();
  public Structured Encode(ItestPrntDualObject input)
    => _itestRefPrntDual.Encode(input);

  internal static testPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualEncoder : IEncoder<ItestRefPrntDualObject>
{
  public Structured Encode(ItestRefPrntDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntInpObject>
{
  private readonly IEncoder<ItestRefPrntInpObject> _itestRefPrntInp = encoders.EncoderFor<ItestRefPrntInpObject>();
  public Structured Encode(ItestPrntInpObject input)
    => _itestRefPrntInp.Encode(input);

  internal static testPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntInpEncoder : IEncoder<ItestRefPrntInpObject>
{
  public Structured Encode(ItestRefPrntInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpObject>
{
  private readonly IEncoder<ItestRefPrntOutpObject> _itestRefPrntOutp = encoders.EncoderFor<ItestRefPrntOutpObject>();
  public Structured Encode(ItestPrntOutpObject input)
    => _itestRefPrntOutp.Encode(input);

  internal static testPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntOutpEncoder : IEncoder<ItestRefPrntOutpObject>
{
  public Structured Encode(ItestRefPrntOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntAltDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltDualObject>
{
  private readonly IEncoder<ItestRefPrntAltDualObject> _itestRefPrntAltDual = encoders.EncoderFor<ItestRefPrntAltDualObject>();
  public Structured Encode(ItestPrntAltDualObject input)
    => _itestRefPrntAltDual.Encode(input);

  internal static testPrntAltDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltDualEncoder : IEncoder<ItestRefPrntAltDualObject>
{
  public Structured Encode(ItestRefPrntAltDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntAltInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltInpObject>
{
  private readonly IEncoder<ItestRefPrntAltInpObject> _itestRefPrntAltInp = encoders.EncoderFor<ItestRefPrntAltInpObject>();
  public Structured Encode(ItestPrntAltInpObject input)
    => _itestRefPrntAltInp.Encode(input);

  internal static testPrntAltInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltInpEncoder : IEncoder<ItestRefPrntAltInpObject>
{
  public Structured Encode(ItestRefPrntAltInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntAltOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltOutpObject>
{
  private readonly IEncoder<ItestRefPrntAltOutpObject> _itestRefPrntAltOutp = encoders.EncoderFor<ItestRefPrntAltOutpObject>();
  public Structured Encode(ItestPrntAltOutpObject input)
    => _itestRefPrntAltOutp.Encode(input);

  internal static testPrntAltOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntAltOutpEncoder : IEncoder<ItestRefPrntAltOutpObject>
{
  public Structured Encode(ItestRefPrntAltOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntAltOutpEncoder Factory(IEncoderRepository _) => new();
}

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
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDescrInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrInpObject>
{
  private readonly IEncoder<ItestRefPrntDescrInpObject> _itestRefPrntDescrInp = encoders.EncoderFor<ItestRefPrntDescrInpObject>();
  public Structured Encode(ItestPrntDescrInpObject input)
    => _itestRefPrntDescrInp.Encode(input);

  internal static testPrntDescrInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDescrInpEncoder : IEncoder<ItestRefPrntDescrInpObject>
{
  public Structured Encode(ItestRefPrntDescrInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDescrInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDescrOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrOutpObject>
{
  private readonly IEncoder<ItestRefPrntDescrOutpObject> _itestRefPrntDescrOutp = encoders.EncoderFor<ItestRefPrntDescrOutpObject>();
  public Structured Encode(ItestPrntDescrOutpObject input)
    => _itestRefPrntDescrOutp.Encode(input);

  internal static testPrntDescrOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDescrOutpEncoder : IEncoder<ItestRefPrntDescrOutpObject>
{
  public Structured Encode(ItestRefPrntDescrOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDescrOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualDualObject>
{
  private readonly IEncoder<ItestRefPrntDualDualObject> _itestRefPrntDualDual = encoders.EncoderFor<ItestRefPrntDualDualObject>();
  public Structured Encode(ItestPrntDualDualObject input)
    => _itestRefPrntDualDual.Encode(input);

  internal static testPrntDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualDualEncoder : IEncoder<ItestRefPrntDualDualObject>
{
  public Structured Encode(ItestRefPrntDualDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualInpObject>
{
  private readonly IEncoder<ItestRefPrntDualInpObject> _itestRefPrntDualInp = encoders.EncoderFor<ItestRefPrntDualInpObject>();
  public Structured Encode(ItestPrntDualInpObject input)
    => _itestRefPrntDualInp.Encode(input);

  internal static testPrntDualInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualInpEncoder : IEncoder<ItestRefPrntDualInpObject>
{
  public Structured Encode(ItestRefPrntDualInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualOutpObject>
{
  private readonly IEncoder<ItestRefPrntDualOutpObject> _itestRefPrntDualOutp = encoders.EncoderFor<ItestRefPrntDualOutpObject>();
  public Structured Encode(ItestPrntDualOutpObject input)
    => _itestRefPrntDualOutp.Encode(input);

  internal static testPrntDualOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntDualOutpEncoder : IEncoder<ItestRefPrntDualOutpObject>
{
  public Structured Encode(ItestRefPrntDualOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldDualObject>
{
  private readonly IEncoder<ItestRefPrntFieldDualObject> _itestRefPrntFieldDual = encoders.EncoderFor<ItestRefPrntFieldDualObject>();
  public Structured Encode(ItestPrntFieldDualObject input)
    => _itestRefPrntFieldDual.Encode(input)
      .Add("field", input.Field.Encode());

  internal static testPrntFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldDualEncoder : IEncoder<ItestRefPrntFieldDualObject>
{
  public Structured Encode(ItestRefPrntFieldDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldInpObject>
{
  private readonly IEncoder<ItestRefPrntFieldInpObject> _itestRefPrntFieldInp = encoders.EncoderFor<ItestRefPrntFieldInpObject>();
  public Structured Encode(ItestPrntFieldInpObject input)
    => _itestRefPrntFieldInp.Encode(input)
      .Add("field", input.Field.Encode());

  internal static testPrntFieldInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldInpEncoder : IEncoder<ItestRefPrntFieldInpObject>
{
  public Structured Encode(ItestRefPrntFieldInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldOutpObject>
{
  private readonly IEncoder<ItestRefPrntFieldOutpObject> _itestRefPrntFieldOutp = encoders.EncoderFor<ItestRefPrntFieldOutpObject>();
  public Structured Encode(ItestPrntFieldOutpObject input)
    => _itestRefPrntFieldOutp.Encode(input)
      .Add("field", input.Field.Encode());

  internal static testPrntFieldOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldOutpEncoder : IEncoder<ItestRefPrntFieldOutpObject>
{
  public Structured Encode(ItestRefPrntFieldOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent.Encode());

  internal static testRefPrntFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntParamDiffDualEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffDualObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffDualObject<TA>> _itestRefPrntParamDiffDual = encoders.EncoderFor<ItestRefPrntParamDiffDualObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffDualObject<TA> input)
    => _itestRefPrntParamDiffDual.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffDualEncoder<TB> : IEncoder<ItestRefPrntParamDiffDualObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffDualObject<TB> input)
    => Structured.Empty();
}

internal class testPrntParamDiffInpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffInpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffInpObject<TA>> _itestRefPrntParamDiffInp = encoders.EncoderFor<ItestRefPrntParamDiffInpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffInpObject<TA> input)
    => _itestRefPrntParamDiffInp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffInpEncoder<TB> : IEncoder<ItestRefPrntParamDiffInpObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffInpObject<TB> input)
    => Structured.Empty();
}

internal class testPrntParamDiffOutpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffOutpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffOutpObject<TA>> _itestRefPrntParamDiffOutp = encoders.EncoderFor<ItestRefPrntParamDiffOutpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffOutpObject<TA> input)
    => _itestRefPrntParamDiffOutp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffOutpEncoder<TB> : IEncoder<ItestRefPrntParamDiffOutpObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffOutpObject<TB> input)
    => Structured.Empty();
}

internal class testPrntParamSameDualEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameDualObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameDualObject<TA>> _itestRefPrntParamSameDual = encoders.EncoderFor<ItestRefPrntParamSameDualObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameDualObject<TA> input)
    => _itestRefPrntParamSameDual.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameDualEncoder<TA> : IEncoder<ItestRefPrntParamSameDualObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameDualObject<TA> input)
    => Structured.Empty();
}

internal class testPrntParamSameInpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameInpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameInpObject<TA>> _itestRefPrntParamSameInp = encoders.EncoderFor<ItestRefPrntParamSameInpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameInpObject<TA> input)
    => _itestRefPrntParamSameInp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameInpEncoder<TA> : IEncoder<ItestRefPrntParamSameInpObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameInpObject<TA> input)
    => Structured.Empty();
}

internal class testPrntParamSameOutpEncoder<TA>(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameOutpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameOutpObject<TA>> _itestRefPrntParamSameOutp = encoders.EncoderFor<ItestRefPrntParamSameOutpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameOutpObject<TA> input)
    => _itestRefPrntParamSameOutp.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameOutpEncoder<TA> : IEncoder<ItestRefPrntParamSameOutpObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameOutpObject<TA> input)
    => Structured.Empty();
}

internal class testCtgrEncoder : IEncoder<ItestCtgrObject>
{
  public Structured Encode(ItestCtgrObject input)
    => Structured.Empty();

  internal static testCtgrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrAliasEncoder : IEncoder<ItestCtgrAliasObject>
{
  public Structured Encode(ItestCtgrAliasObject input)
    => Structured.Empty();

  internal static testCtgrAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrDescrEncoder : IEncoder<ItestCtgrDescrObject>
{
  public Structured Encode(ItestCtgrDescrObject input)
    => Structured.Empty();

  internal static testCtgrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testCtgrModEncoder : IEncoder<ItestCtgrModObject>
{
  public Structured Encode(ItestCtgrModObject input)
    => Structured.Empty();

  internal static testCtgrModEncoder Factory(IEncoderRepository _) => new();
}

internal class testInDrctParamEncoder : IEncoder<ItestInDrctParamObject>
{
  public Structured Encode(ItestInDrctParamObject input)
    => Structured.Empty();

  internal static testInDrctParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public Structured Encode(ItestDmnAlias input)
    => input.Value!.Encode();

  internal static testDmnAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public Structured Encode(ItestDmnBool input)
    => input.Value!.Encode();

  internal static testDmnBoolEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolDiffEncoder : IEncoder<ItestDmnBoolDiff>
{
  public Structured Encode(ItestDmnBoolDiff input)
    => input.Value!.Encode();

  internal static testDmnBoolDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolSameEncoder : IEncoder<ItestDmnBoolSame>
{
  public Structured Encode(ItestDmnBoolSame input)
    => input.Value!.Encode();

  internal static testDmnBoolSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public Structured Encode(ItestDmnEnumDiff input)
    => input.Value?.EncodeEnum("bool")!;

  internal static testDmnEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumSameEncoder : IEncoder<ItestDmnEnumSame>
{
  public Structured Encode(ItestDmnEnumSame input)
    => input.Value?.EncodeEnum("bool")!;

  internal static testDmnEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrEncoder : IEncoder<ItestDmnNmbr>
{
  public Structured Encode(ItestDmnNmbr input)
    => input.Value!.Encode();

  internal static testDmnNmbrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrDiffEncoder : IEncoder<ItestDmnNmbrDiff>
{
  public Structured Encode(ItestDmnNmbrDiff input)
    => input.Value!.Encode();

  internal static testDmnNmbrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrSameEncoder : IEncoder<ItestDmnNmbrSame>
{
  public Structured Encode(ItestDmnNmbrSame input)
    => input.Value!.Encode();

  internal static testDmnNmbrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrEncoder : IEncoder<ItestDmnStr>
{
  public Structured Encode(ItestDmnStr input)
    => input.Value!.Encode();

  internal static testDmnStrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrDiffEncoder : IEncoder<ItestDmnStrDiff>
{
  public Structured Encode(ItestDmnStrDiff input)
    => input.Value!.Encode();

  internal static testDmnStrDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrSameEncoder : IEncoder<ItestDmnStrSame>
{
  public Structured Encode(ItestDmnStrSame input)
    => input.Value!.Encode();

  internal static testDmnStrSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public Structured Encode(testEnumAlias input)
    => input.EncodeEnum("EnumAlias");

  internal static testEnumAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDiffEncoder : IEncoder<testEnumDiff>
{
  public Structured Encode(testEnumDiff input)
    => input.EncodeEnum("EnumDiff");

  internal static testEnumDiffEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSameEncoder : IEncoder<testEnumSame>
{
  public Structured Encode(testEnumSame input)
    => input.EncodeEnum("EnumSame");

  internal static testEnumSameEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumSamePrntEncoder : IEncoder<testEnumSamePrnt>
{
  public Structured Encode(testEnumSamePrnt input)
    => input.EncodeEnum("EnumSamePrnt");

  internal static testEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumSamePrntEncoder : IEncoder<testPrntEnumSamePrnt>
{
  public Structured Encode(testPrntEnumSamePrnt input)
    => input.EncodeEnum("PrntEnumSamePrnt");

  internal static testPrntEnumSamePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumValueAliasEncoder : IEncoder<testEnumValueAlias>
{
  public Structured Encode(testEnumValueAlias input)
    => input.EncodeEnum("EnumValueAlias");

  internal static testEnumValueAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualEncoder : IEncoder<ItestObjDualObject>
{
  public Structured Encode(ItestObjDualObject input)
    => Structured.Empty();

  internal static testObjDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjInpEncoder : IEncoder<ItestObjInpObject>
{
  public Structured Encode(ItestObjInpObject input)
    => Structured.Empty();

  internal static testObjInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjOutpEncoder : IEncoder<ItestObjOutpObject>
{
  public Structured Encode(ItestObjOutpObject input)
    => Structured.Empty();

  internal static testObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasDualEncoder : IEncoder<ItestObjAliasDualObject>
{
  public Structured Encode(ItestObjAliasDualObject input)
    => Structured.Empty();

  internal static testObjAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasInpEncoder : IEncoder<ItestObjAliasInpObject>
{
  public Structured Encode(ItestObjAliasInpObject input)
    => Structured.Empty();

  internal static testObjAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAliasOutpEncoder : IEncoder<ItestObjAliasOutpObject>
{
  public Structured Encode(ItestObjAliasOutpObject input)
    => Structured.Empty();

  internal static testObjAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltDualEncoder : IEncoder<ItestObjAltDualObject>
{
  public Structured Encode(ItestObjAltDualObject input)
    => Structured.Empty();

  internal static testObjAltDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltDualTypeEncoder : IEncoder<ItestObjAltDualTypeObject>
{
  public Structured Encode(ItestObjAltDualTypeObject input)
    => Structured.Empty();

  internal static testObjAltDualTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltInpEncoder : IEncoder<ItestObjAltInpObject>
{
  public Structured Encode(ItestObjAltInpObject input)
    => Structured.Empty();

  internal static testObjAltInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltInpTypeEncoder : IEncoder<ItestObjAltInpTypeObject>
{
  public Structured Encode(ItestObjAltInpTypeObject input)
    => Structured.Empty();

  internal static testObjAltInpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltOutpEncoder : IEncoder<ItestObjAltOutpObject>
{
  public Structured Encode(ItestObjAltOutpObject input)
    => Structured.Empty();

  internal static testObjAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltOutpTypeEncoder : IEncoder<ItestObjAltOutpTypeObject>
{
  public Structured Encode(ItestObjAltOutpTypeObject input)
    => Structured.Empty();

  internal static testObjAltOutpTypeEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumDualEncoder : IEncoder<ItestObjAltEnumDualObject>
{
  public Structured Encode(ItestObjAltEnumDualObject input)
    => Structured.Empty();

  internal static testObjAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumInpEncoder : IEncoder<ItestObjAltEnumInpObject>
{
  public Structured Encode(ItestObjAltEnumInpObject input)
    => Structured.Empty();

  internal static testObjAltEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjAltEnumOutpEncoder : IEncoder<ItestObjAltEnumOutpObject>
{
  public Structured Encode(ItestObjAltEnumOutpObject input)
    => Structured.Empty();

  internal static testObjAltEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjCnstDualEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjCnstDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjCnstInpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjCnstInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjCnstOutpEncoder<TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjCnstOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjCnstOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type)
      .AddEncoded("str", input.Str, _type);
}

internal class testObjFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldDualObject>
{
  private readonly IEncoder<ItestFldObjFieldDual> _itestFldObjFieldDual = encoders.EncoderFor<ItestFldObjFieldDual>();
  public Structured Encode(ItestObjFieldDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldDual);

  internal static testObjFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldDualEncoder : IEncoder<ItestFldObjFieldDualObject>
{
  public Structured Encode(ItestFldObjFieldDualObject input)
    => Structured.Empty();

  internal static testFldObjFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldInpObject>
{
  private readonly IEncoder<ItestFldObjFieldInp> _itestFldObjFieldInp = encoders.EncoderFor<ItestFldObjFieldInp>();
  public Structured Encode(ItestObjFieldInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldInp);

  internal static testObjFieldInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldInpEncoder : IEncoder<ItestFldObjFieldInpObject>
{
  public Structured Encode(ItestFldObjFieldInpObject input)
    => Structured.Empty();

  internal static testFldObjFieldInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldOutp> _itestFldObjFieldOutp = encoders.EncoderFor<ItestFldObjFieldOutp>();
  public Structured Encode(ItestObjFieldOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldOutp);

  internal static testObjFieldOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldOutpEncoder : IEncoder<ItestFldObjFieldOutpObject>
{
  public Structured Encode(ItestFldObjFieldOutpObject input)
    => Structured.Empty();

  internal static testFldObjFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasDualObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasDual> _itestFldObjFieldAliasDual = encoders.EncoderFor<ItestFldObjFieldAliasDual>();
  public Structured Encode(ItestObjFieldAliasDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasDual);

  internal static testObjFieldAliasDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasDualEncoder : IEncoder<ItestFldObjFieldAliasDualObject>
{
  public Structured Encode(ItestFldObjFieldAliasDualObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasInpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasInp> _itestFldObjFieldAliasInp = encoders.EncoderFor<ItestFldObjFieldAliasInp>();
  public Structured Encode(ItestObjFieldAliasInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasInp);

  internal static testObjFieldAliasInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasInpEncoder : IEncoder<ItestFldObjFieldAliasInpObject>
{
  public Structured Encode(ItestFldObjFieldAliasInpObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldAliasOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasOutp> _itestFldObjFieldAliasOutp = encoders.EncoderFor<ItestFldObjFieldAliasOutp>();
  public Structured Encode(ItestObjFieldAliasOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasOutp);

  internal static testObjFieldAliasOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldObjFieldAliasOutpEncoder : IEncoder<ItestFldObjFieldAliasOutpObject>
{
  public Structured Encode(ItestFldObjFieldAliasOutpObject input)
    => Structured.Empty();

  internal static testFldObjFieldAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualEncoder : IEncoder<ItestObjFieldEnumAliasDualObject>
{
  public Structured Encode(ItestObjFieldEnumAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpEncoder : IEncoder<ItestObjFieldEnumAliasInpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumAliasOutpEncoder : IEncoder<ItestObjFieldEnumAliasOutpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueDualEncoder : IEncoder<ItestObjFieldEnumValueDualObject>
{
  public Structured Encode(ItestObjFieldEnumValueDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueInpEncoder : IEncoder<ItestObjFieldEnumValueInpObject>
{
  public Structured Encode(ItestObjFieldEnumValueInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldEnumValueOutpEncoder : IEncoder<ItestObjFieldEnumValueOutpObject>
{
  public Structured Encode(ItestObjFieldEnumValueOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldEnumValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualEncoder : IEncoder<ItestObjFieldTypeAliasDualObject>
{
  public Structured Encode(ItestObjFieldTypeAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpEncoder : IEncoder<ItestObjFieldTypeAliasInpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasInpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field.Encode());

  internal static testObjFieldTypeAliasOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjParamDualEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDualObject<TTest,TType>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamDualObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamInpEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamInpObject<TTest,TType>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamInpObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamOutpEncoder<TTest,TType>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamOutpObject<TTest,TType>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestObjParamOutpObject<TTest,TType> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _type);
}

internal class testObjParamDupDualEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupDualObject<TTest>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  public Structured Encode(ItestObjParamDupDualObject<TTest> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjParamDupInpEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupInpObject<TTest>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  public Structured Encode(ItestObjParamDupInpObject<TTest> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjParamDupOutpEncoder<TTest>(
  IEncoderRepository encoders
) : IEncoder<ItestObjParamDupOutpObject<TTest>>
{
  private readonly IEncoder<TTest> _test = encoders.EncoderFor<TTest>();
  public Structured Encode(ItestObjParamDupOutpObject<TTest> input)
    => Structured.Empty()
      .AddEncoded("test", input.Test, _test)
      .AddEncoded("type", input.Type, _test);
}

internal class testObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntDualObject>
{
  private readonly IEncoder<ItestRefObjPrntDualObject> _itestRefObjPrntDual = encoders.EncoderFor<ItestRefObjPrntDualObject>();
  public Structured Encode(ItestObjPrntDualObject input)
    => _itestRefObjPrntDual.Encode(input);

  internal static testObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntDualEncoder : IEncoder<ItestRefObjPrntDualObject>
{
  public Structured Encode(ItestRefObjPrntDualObject input)
    => Structured.Empty();

  internal static testRefObjPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntInpObject>
{
  private readonly IEncoder<ItestRefObjPrntInpObject> _itestRefObjPrntInp = encoders.EncoderFor<ItestRefObjPrntInpObject>();
  public Structured Encode(ItestObjPrntInpObject input)
    => _itestRefObjPrntInp.Encode(input);

  internal static testObjPrntInpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntInpEncoder : IEncoder<ItestRefObjPrntInpObject>
{
  public Structured Encode(ItestRefObjPrntInpObject input)
    => Structured.Empty();

  internal static testRefObjPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefObjPrntOutpObject> _itestRefObjPrntOutp = encoders.EncoderFor<ItestRefObjPrntOutpObject>();
  public Structured Encode(ItestObjPrntOutpObject input)
    => _itestRefObjPrntOutp.Encode(input);

  internal static testObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefObjPrntOutpEncoder : IEncoder<ItestRefObjPrntOutpObject>
{
  public Structured Encode(ItestRefObjPrntOutpObject input)
    => Structured.Empty();

  internal static testRefObjPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpFieldParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpFieldParamObject>
{
  private readonly IEncoder<ItestFldOutpFieldParam> _itestFldOutpFieldParam = encoders.EncoderFor<ItestFldOutpFieldParam>();
  public Structured Encode(ItestOutpFieldParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldOutpFieldParam);

  internal static testOutpFieldParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testOutpFieldParam1Encoder : IEncoder<ItestOutpFieldParam1Object>
{
  public Structured Encode(ItestOutpFieldParam1Object input)
    => Structured.Empty();

  internal static testOutpFieldParam1Encoder Factory(IEncoderRepository _) => new();
}

internal class testOutpFieldParam2Encoder : IEncoder<ItestOutpFieldParam2Object>
{
  public Structured Encode(ItestOutpFieldParam2Object input)
    => Structured.Empty();

  internal static testOutpFieldParam2Encoder Factory(IEncoderRepository _) => new();
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public Structured Encode(ItestFldOutpFieldParamObject input)
    => Structured.Empty();

  internal static testFldOutpFieldParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testUnionAliasEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionAlias>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionAlias input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionAliasEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionDiffEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDiff>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDiff input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionDiffEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionSameEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSame>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSame input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();

  internal static testUnionSameEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionSamePrntEncoder(
  IEncoderRepository encoders
: testPrntUnionSamePrntEncoder, IEncoder<ItestUnionSamePrnt>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSamePrnt input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : base.Encode(input);

  internal static testUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionSamePrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestPrntUnionSamePrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();

  internal static testPrntUnionSamePrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testDmnBoolDescrEncoder : IEncoder<ItestDmnBoolDescr>
{
  public Structured Encode(ItestDmnBoolDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolPrntEncoder : IEncoder<ItestDmnBoolPrnt>
{
  public Structured Encode(ItestDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntEncoder : IEncoder<ItestPrntDmnBoolPrnt>
{
  public Structured Encode(ItestPrntDmnBoolPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnBoolPrntDescrEncoder : IEncoder<ItestDmnBoolPrntDescr>
{
  public Structured Encode(ItestDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrEncoder : IEncoder<ItestPrntDmnBoolPrntDescr>
{
  public Structured Encode(ItestPrntDmnBoolPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnBoolPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllEncoder : IEncoder<ItestDmnEnumAll>
{
  public Structured Encode(ItestDmnEnumAll input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAll")!;

  internal static testDmnEnumAllEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllEncoder : IEncoder<testEnumDmnEnumAll>
{
  public Structured Encode(testEnumDmnEnumAll input)
    => input.EncodeEnum("EnumDmnEnumAll");

  internal static testEnumDmnEnumAllEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllDescrEncoder : IEncoder<ItestDmnEnumAllDescr>
{
  public Structured Encode(ItestDmnEnumAllDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAllDescr")!;

  internal static testDmnEnumAllDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrEncoder : IEncoder<testEnumDmnEnumAllDescr>
{
  public Structured Encode(testEnumDmnEnumAllDescr input)
    => input.EncodeEnum("EnumDmnEnumAllDescr");

  internal static testEnumDmnEnumAllDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumAllPrntEncoder : IEncoder<ItestDmnEnumAllPrnt>
{
  public Structured Encode(ItestDmnEnumAllPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumAllPrnt")!;

  internal static testDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntEncoder : IEncoder<testEnumDmnEnumAllPrnt>
{
  public Structured Encode(testEnumDmnEnumAllPrnt input)
    => input.EncodeEnum("EnumDmnEnumAllPrnt");

  internal static testEnumDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntEncoder : IEncoder<testPrntDmnEnumAllPrnt>
{
  public Structured Encode(testPrntDmnEnumAllPrnt input)
    => input.EncodeEnum("PrntDmnEnumAllPrnt");

  internal static testPrntDmnEnumAllPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumDescrEncoder : IEncoder<ItestDmnEnumDescr>
{
  public Structured Encode(ItestDmnEnumDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumDescr")!;

  internal static testDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumDescrEncoder : IEncoder<testEnumDmnEnumDescr>
{
  public Structured Encode(testEnumDmnEnumDescr input)
    => input.EncodeEnum("EnumDmnEnumDescr");

  internal static testEnumDmnEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumExclEncoder : IEncoder<ItestDmnEnumExcl>
{
  public Structured Encode(ItestDmnEnumExcl input)
    => input.Value?.EncodeEnum("testEnumDmnEnumExcl")!;

  internal static testDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumExclEncoder : IEncoder<testEnumDmnEnumExcl>
{
  public Structured Encode(testEnumDmnEnumExcl input)
    => input.EncodeEnum("EnumDmnEnumExcl");

  internal static testEnumDmnEnumExclEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumExclPrntEncoder : IEncoder<ItestDmnEnumExclPrnt>
{
  public Structured Encode(ItestDmnEnumExclPrnt input)
    => input.Value?.EncodeEnum("DmnEnumExclPrnt")!;

  internal static testDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntEncoder : IEncoder<testEnumDmnEnumExclPrnt>
{
  public Structured Encode(testEnumDmnEnumExclPrnt input)
    => input.EncodeEnum("EnumDmnEnumExclPrnt");

  internal static testEnumDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntEncoder : IEncoder<testPrntDmnEnumExclPrnt>
{
  public Structured Encode(testPrntDmnEnumExclPrnt input)
    => input.EncodeEnum("PrntDmnEnumExclPrnt");

  internal static testPrntDmnEnumExclPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumLabelEncoder : IEncoder<ItestDmnEnumLabel>
{
  public Structured Encode(ItestDmnEnumLabel input)
    => input.Value?.EncodeEnum("testEnumDmnEnumLabel")!;

  internal static testDmnEnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumLabelEncoder : IEncoder<testEnumDmnEnumLabel>
{
  public Structured Encode(testEnumDmnEnumLabel input)
    => input.EncodeEnum("EnumDmnEnumLabel");

  internal static testEnumDmnEnumLabelEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumPrntEncoder : IEncoder<ItestDmnEnumPrnt>
{
  public Structured Encode(ItestDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt")!;

  internal static testDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntEncoder : IEncoder<ItestPrntDmnEnumPrnt>
{
  public Structured Encode(ItestPrntDmnEnumPrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrnt")!;

  internal static testPrntDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntEncoder : IEncoder<testEnumDmnEnumPrnt>
{
  public Structured Encode(testEnumDmnEnumPrnt input)
    => input.EncodeEnum("EnumDmnEnumPrnt");

  internal static testEnumDmnEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumPrntDescrEncoder : IEncoder<ItestDmnEnumPrntDescr>
{
  public Structured Encode(ItestDmnEnumPrntDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrntDescr")!;

  internal static testDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrEncoder : IEncoder<ItestPrntDmnEnumPrntDescr>
{
  public Structured Encode(ItestPrntDmnEnumPrntDescr input)
    => input.Value?.EncodeEnum("testEnumDmnEnumPrntDescr")!;

  internal static testPrntDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrEncoder : IEncoder<testEnumDmnEnumPrntDescr>
{
  public Structured Encode(testEnumDmnEnumPrntDescr input)
    => input.EncodeEnum("EnumDmnEnumPrntDescr");

  internal static testEnumDmnEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumUnqEncoder : IEncoder<ItestDmnEnumUnq>
{
  public Structured Encode(ItestDmnEnumUnq input)
    => input.Value?.EncodeEnum("DmnEnumUnq")!;

  internal static testDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqEncoder : IEncoder<testEnumDmnEnumUnq>
{
  public Structured Encode(testEnumDmnEnumUnq input)
    => input.EncodeEnum("EnumDmnEnumUnq");

  internal static testEnumDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqEncoder : IEncoder<testDupDmnEnumUnq>
{
  public Structured Encode(testDupDmnEnumUnq input)
    => input.EncodeEnum("DupDmnEnumUnq");

  internal static testDupDmnEnumUnqEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumUnqPrntEncoder : IEncoder<ItestDmnEnumUnqPrnt>
{
  public Structured Encode(ItestDmnEnumUnqPrnt input)
    => input.Value?.EncodeEnum("DmnEnumUnqPrnt")!;

  internal static testDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public Structured Encode(testEnumDmnEnumUnqPrnt input)
    => input.EncodeEnum("EnumDmnEnumUnqPrnt");

  internal static testEnumDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public Structured Encode(testPrntDmnEnumUnqPrnt input)
    => input.EncodeEnum("PrntDmnEnumUnqPrnt");

  internal static testPrntDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public Structured Encode(testDupDmnEnumUnqPrnt input)
    => input.EncodeEnum("DupDmnEnumUnqPrnt");

  internal static testDupDmnEnumUnqPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumValueEncoder : IEncoder<ItestDmnEnumValue>
{
  public Structured Encode(ItestDmnEnumValue input)
    => input.Value?.EncodeEnum("testEnumDmnEnumValue")!;

  internal static testDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValueEncoder : IEncoder<testEnumDmnEnumValue>
{
  public Structured Encode(testEnumDmnEnumValue input)
    => input.EncodeEnum("EnumDmnEnumValue");

  internal static testEnumDmnEnumValueEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnEnumValuePrntEncoder : IEncoder<ItestDmnEnumValuePrnt>
{
  public Structured Encode(ItestDmnEnumValuePrnt input)
    => input.Value?.EncodeEnum("testEnumDmnEnumValuePrnt")!;

  internal static testDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntEncoder : IEncoder<testEnumDmnEnumValuePrnt>
{
  public Structured Encode(testEnumDmnEnumValuePrnt input)
    => input.EncodeEnum("EnumDmnEnumValuePrnt");

  internal static testEnumDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntEncoder : IEncoder<testPrntDmnEnumValuePrnt>
{
  public Structured Encode(testPrntDmnEnumValuePrnt input)
    => input.EncodeEnum("PrntDmnEnumValuePrnt");

  internal static testPrntDmnEnumValuePrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrDescrEncoder : IEncoder<ItestDmnNmbrDescr>
{
  public Structured Encode(ItestDmnNmbrDescr input)
    => input.Value!.Encode();

  internal static testDmnNmbrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPrntEncoder : IEncoder<ItestDmnNmbrPrnt>
{
  public Structured Encode(ItestDmnNmbrPrnt input)
    => input.Value!.Encode();

  internal static testDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntEncoder : IEncoder<ItestPrntDmnNmbrPrnt>
{
  public Structured Encode(ItestPrntDmnNmbrPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnNmbrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPrntDescrEncoder : IEncoder<ItestDmnNmbrPrntDescr>
{
  public Structured Encode(ItestDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrEncoder : IEncoder<ItestPrntDmnNmbrPrntDescr>
{
  public Structured Encode(ItestPrntDmnNmbrPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnNmbrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrPstvEncoder : IEncoder<ItestDmnNmbrPstv>
{
  public Structured Encode(ItestDmnNmbrPstv input)
    => input.Value!.Encode();

  internal static testDmnNmbrPstvEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnNmbrRangeEncoder : IEncoder<ItestDmnNmbrRange>
{
  public Structured Encode(ItestDmnNmbrRange input)
    => input.Value!.Encode();

  internal static testDmnNmbrRangeEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrDescrEncoder : IEncoder<ItestDmnStrDescr>
{
  public Structured Encode(ItestDmnStrDescr input)
    => input.Value!.Encode();

  internal static testDmnStrDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrNonEmptyEncoder : IEncoder<ItestDmnStrNonEmpty>
{
  public Structured Encode(ItestDmnStrNonEmpty input)
    => input.Value!.Encode();

  internal static testDmnStrNonEmptyEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrPrntEncoder : IEncoder<ItestDmnStrPrnt>
{
  public Structured Encode(ItestDmnStrPrnt input)
    => input.Value!.Encode();

  internal static testDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntEncoder : IEncoder<ItestPrntDmnStrPrnt>
{
  public Structured Encode(ItestPrntDmnStrPrnt input)
    => input.Value!.Encode();

  internal static testPrntDmnStrPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testDmnStrPrntDescrEncoder : IEncoder<ItestDmnStrPrntDescr>
{
  public Structured Encode(ItestDmnStrPrntDescr input)
    => input.Value!.Encode();

  internal static testDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrEncoder : IEncoder<ItestPrntDmnStrPrntDescr>
{
  public Structured Encode(ItestPrntDmnStrPrntDescr input)
    => input.Value!.Encode();

  internal static testPrntDmnStrPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumDescrEncoder : IEncoder<testEnumDescr>
{
  public Structured Encode(testEnumDescr input)
    => input.EncodeEnum("EnumDescr");

  internal static testEnumDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntEncoder : IEncoder<testEnumPrnt>
{
  public Structured Encode(testEnumPrnt input)
    => input.EncodeEnum("EnumPrnt");

  internal static testEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntEncoder : IEncoder<testPrntEnumPrnt>
{
  public Structured Encode(testPrntEnumPrnt input)
    => input.EncodeEnum("PrntEnumPrnt");

  internal static testPrntEnumPrntEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntAliasEncoder : IEncoder<testEnumPrntAlias>
{
  public Structured Encode(testEnumPrntAlias input)
    => input.EncodeEnum("EnumPrntAlias");

  internal static testEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntAliasEncoder : IEncoder<testPrntEnumPrntAlias>
{
  public Structured Encode(testPrntEnumPrntAlias input)
    => input.EncodeEnum("PrntEnumPrntAlias");

  internal static testPrntEnumPrntAliasEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntDescrEncoder : IEncoder<testEnumPrntDescr>
{
  public Structured Encode(testEnumPrntDescr input)
    => input.EncodeEnum("EnumPrntDescr");

  internal static testEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntDescrEncoder : IEncoder<testPrntEnumPrntDescr>
{
  public Structured Encode(testPrntEnumPrntDescr input)
    => input.EncodeEnum("PrntEnumPrntDescr");

  internal static testPrntEnumPrntDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumPrntDupEncoder : IEncoder<testEnumPrntDup>
{
  public Structured Encode(testEnumPrntDup input)
    => input.EncodeEnum("EnumPrntDup");

  internal static testEnumPrntDupEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntEnumPrntDupEncoder : IEncoder<testPrntEnumPrntDup>
{
  public Structured Encode(testPrntEnumPrntDup input)
    => input.EncodeEnum("PrntEnumPrntDup");

  internal static testPrntEnumPrntDupEncoder Factory(IEncoderRepository _) => new();
}

internal class testUnionDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testUnionDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntEncoder(
  IEncoderRepository encoders
: testPrntUnionPrntEncoder, IEncoder<ItestUnionPrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestUnionPrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : base.Encode(input);

  internal static testUnionPrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrnt>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrnt input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testPrntUnionPrntEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntDescrEncoder(
  IEncoderRepository encoders
: testPrntUnionPrntDescrEncoder, IEncoder<ItestUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : base.Encode(input);

  internal static testUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

  internal static testPrntUnionPrntDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testUnionPrntDupEncoder(
  IEncoderRepository encoders
: testPrntUnionPrntDupEncoder, IEncoder<ItestUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : base.Encode(input);

  internal static testUnionPrntDupEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();

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
      .AddEncoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrEncoder.Factory)
      .AddEncoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrEncoder.Factory)
      .AddEncoder<ItestDmnNmbrPstv>(testDmnNmbrPstvEncoder.Factory)
      .AddEncoder<ItestDmnNmbrRange>(testDmnNmbrRangeEncoder.Factory)
      .AddEncoder<ItestDmnStrDescr>(testDmnStrDescrEncoder.Factory)
      .AddEncoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyEncoder.Factory)
      .AddEncoder<ItestDmnStrPrnt>(testDmnStrPrntEncoder.Factory)
      .AddEncoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntEncoder.Factory)
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
