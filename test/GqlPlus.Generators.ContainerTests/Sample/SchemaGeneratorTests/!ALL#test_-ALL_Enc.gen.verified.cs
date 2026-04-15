//HintName: test_-ALL_Enc.gen.cs
// Generated from {CurrentDirectory}-ALL.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__ALL;

internal class testCtgrDscrsEncoder : IEncoder<ItestCtgrDscrsObject>
{
  public Structured Encode(ItestCtgrDscrsObject input)
    => Structured.Empty();
}

internal class testCtgrOutpEncoder : IEncoder<ItestCtgrOutpObject>
{
  public Structured Encode(ItestCtgrOutpObject input)
    => Structured.Empty();
}

internal class testCtgrOutpDescrEncoder : IEncoder<ItestCtgrOutpDescrObject>
{
  public Structured Encode(ItestCtgrOutpDescrObject input)
    => Structured.Empty();
}

internal class testCtgrOutpDictEncoder : IEncoder<ItestCtgrOutpDictObject>
{
  public Structured Encode(ItestCtgrOutpDictObject input)
    => Structured.Empty();
}

internal class testCtgrOutpListEncoder : IEncoder<ItestCtgrOutpListObject>
{
  public Structured Encode(ItestCtgrOutpListObject input)
    => Structured.Empty();
}

internal class testCtgrOutpOptlEncoder : IEncoder<ItestCtgrOutpOptlObject>
{
  public Structured Encode(ItestCtgrOutpOptlObject input)
    => Structured.Empty();
}

internal class testDescrEncoder : IEncoder<ItestDescrObject>
{
  public Structured Encode(ItestDescrObject input)
    => Structured.Empty();
}

internal class testDescrBcksEncoder : IEncoder<ItestDescrBcksObject>
{
  public Structured Encode(ItestDescrBcksObject input)
    => Structured.Empty();
}

internal class testDescrBtwnEncoder : IEncoder<ItestDescrBtwnObject>
{
  public Structured Encode(ItestDescrBtwnObject input)
    => Structured.Empty();
}

internal class testDescrCmplEncoder : IEncoder<ItestDescrCmplObject>
{
  public Structured Encode(ItestDescrCmplObject input)
    => Structured.Empty();
}

internal class testDescrDblEncoder : IEncoder<ItestDescrDblObject>
{
  public Structured Encode(ItestDescrDblObject input)
    => Structured.Empty();
}

internal class testDescrSnglEncoder : IEncoder<ItestDescrSnglObject>
{
  public Structured Encode(ItestDescrSnglObject input)
    => Structured.Empty();
}

internal class testDscrsEncoder : IEncoder<ItestDscrsObject>
{
  public Structured Encode(ItestDscrsObject input)
    => Structured.Empty();
}

internal class testAltDualEncoder : IEncoder<ItestAltDualObject>
{
  public Structured Encode(ItestAltDualObject input)
    => Structured.Empty();
}

internal class testAltAltDualEncoder : IEncoder<ItestAltAltDualObject>
{
  public Structured Encode(ItestAltAltDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testAltOutpEncoder : IEncoder<ItestAltOutpObject>
{
  public Structured Encode(ItestAltOutpObject input)
    => Structured.Empty();
}

internal class testAltAltOutpEncoder : IEncoder<ItestAltAltOutpObject>
{
  public Structured Encode(ItestAltAltOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testAltDescrDualEncoder : IEncoder<ItestAltDescrDualObject>
{
  public Structured Encode(ItestAltDescrDualObject input)
    => Structured.Empty();
}

internal class testAltDescrOutpEncoder : IEncoder<ItestAltDescrOutpObject>
{
  public Structured Encode(ItestAltDescrOutpObject input)
    => Structured.Empty();
}

internal class testAltDualDualEncoder : IEncoder<ItestAltDualDualObject>
{
  public Structured Encode(ItestAltDualDualObject input)
    => Structured.Empty();
}

internal class testObjDualAltDualDualEncoder : IEncoder<ItestObjDualAltDualDualObject>
{
  public Structured Encode(ItestObjDualAltDualDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testObjDualAltDualInpEncoder : IEncoder<ItestObjDualAltDualInpObject>
{
  public Structured Encode(ItestObjDualAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testAltDualOutpEncoder : IEncoder<ItestAltDualOutpObject>
{
  public Structured Encode(ItestAltDualOutpObject input)
    => Structured.Empty();
}

internal class testObjDualAltDualOutpEncoder : IEncoder<ItestObjDualAltDualOutpObject>
{
  public Structured Encode(ItestObjDualAltDualOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testAltEnumDualEncoder : IEncoder<ItestAltEnumDualObject>
{
  public Structured Encode(ItestAltEnumDualObject input)
    => Structured.Empty();
}

internal class testEnumAltEnumDualEncoder : IEncoder<testEnumAltEnumDual>
{
  public Structured Encode(testEnumAltEnumDual input)
    => new(input.ToString(), "_EnumAltEnumDual");
}

internal class testEnumAltEnumInpEncoder : IEncoder<testEnumAltEnumInp>
{
  public Structured Encode(testEnumAltEnumInp input)
    => new(input.ToString(), "_EnumAltEnumInp");
}

internal class testAltEnumOutpEncoder : IEncoder<ItestAltEnumOutpObject>
{
  public Structured Encode(ItestAltEnumOutpObject input)
    => Structured.Empty();
}

internal class testEnumAltEnumOutpEncoder : IEncoder<testEnumAltEnumOutp>
{
  public Structured Encode(testEnumAltEnumOutp input)
    => new(input.ToString(), "_EnumAltEnumOutp");
}

internal class testAltModBoolDualEncoder : IEncoder<ItestAltModBoolDualObject>
{
  public Structured Encode(ItestAltModBoolDualObject input)
    => Structured.Empty();
}

internal class testAltAltModBoolDualEncoder : IEncoder<ItestAltAltModBoolDualObject>
{
  public Structured Encode(ItestAltAltModBoolDualObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testAltModBoolOutpEncoder : IEncoder<ItestAltModBoolOutpObject>
{
  public Structured Encode(ItestAltModBoolOutpObject input)
    => Structured.Empty();
}

internal class testAltAltModBoolOutpEncoder : IEncoder<ItestAltAltModBoolOutpObject>
{
  public Structured Encode(ItestAltAltModBoolOutpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
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
      .Add("alt", input.Alt);
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
      .Add("alt", input.Alt);
}

internal class testAltSmplDualEncoder : IEncoder<ItestAltSmplDualObject>
{
  public Structured Encode(ItestAltSmplDualObject input)
    => Structured.Empty();
}

internal class testAltSmplOutpEncoder : IEncoder<ItestAltSmplOutpObject>
{
  public Structured Encode(ItestAltSmplOutpObject input)
    => Structured.Empty();
}

internal class testCnstAltDualEncoder<TType> : IEncoder<ItestCnstAltDualObject<TType>>
{
  public Structured Encode(ItestCnstAltDualObject<TType> input)
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
}

internal class testRefCnstAltDmnDualEncoder<TRef> : IEncoder<ItestRefCnstAltDmnDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnDualObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnDualEncoder : IEncoder<ItestDomCnstAltDmnDual>
{
  public Structured Encode(ItestDomCnstAltDmnDual input)
    => new(input.Value);
}

internal class testDomCnstAltDmnInpEncoder : IEncoder<ItestDomCnstAltDmnInp>
{
  public Structured Encode(ItestDomCnstAltDmnInp input)
    => new(input.Value);
}

internal class testCnstAltDmnOutpEncoder : IEncoder<ItestCnstAltDmnOutpObject>
{
  public Structured Encode(ItestCnstAltDmnOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDmnOutpEncoder<TRef> : IEncoder<ItestRefCnstAltDmnOutpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnOutpEncoder : IEncoder<ItestDomCnstAltDmnOutp>
{
  public Structured Encode(ItestDomCnstAltDmnOutp input)
    => new(input.Value);
}

internal class testCnstAltDualDualEncoder : IEncoder<ItestCnstAltDualDualObject>
{
  public Structured Encode(ItestCnstAltDualDualObject input)
    => Structured.Empty();
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
}

internal class testAltCnstAltDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualDualObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualDualObject> _itestPrntCnstAltDualDual = encoders.EncoderFor<ItestPrntCnstAltDualDualObject>();
  public Structured Encode(ItestAltCnstAltDualDualObject input)
    => _itestPrntCnstAltDualDual.Encode(input)
      .Add("alt", input.Alt);
}

internal class testPrntCnstAltDualInpEncoder : IEncoder<ItestPrntCnstAltDualInpObject>
{
  public Structured Encode(ItestPrntCnstAltDualInpObject input)
    => Structured.Empty();
}

internal class testCnstAltDualOutpEncoder : IEncoder<ItestCnstAltDualOutpObject>
{
  public Structured Encode(ItestCnstAltDualOutpObject input)
    => Structured.Empty();
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
}

internal class testAltCnstAltDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualOutpObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualOutpObject> _itestPrntCnstAltDualOutp = encoders.EncoderFor<ItestPrntCnstAltDualOutpObject>();
  public Structured Encode(ItestAltCnstAltDualOutpObject input)
    => _itestPrntCnstAltDualOutp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstAltObjDualEncoder : IEncoder<ItestCnstAltObjDualObject>
{
  public Structured Encode(ItestCnstAltObjDualObject input)
    => Structured.Empty();
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
}

internal class testAltCnstAltObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjDualObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjDualObject> _itestPrntCnstAltObjDual = encoders.EncoderFor<ItestPrntCnstAltObjDualObject>();
  public Structured Encode(ItestAltCnstAltObjDualObject input)
    => _itestPrntCnstAltObjDual.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstAltObjOutpEncoder : IEncoder<ItestCnstAltObjOutpObject>
{
  public Structured Encode(ItestCnstAltObjOutpObject input)
    => Structured.Empty();
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
}

internal class testAltCnstAltObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjOutpObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjOutpObject> _itestPrntCnstAltObjOutp = encoders.EncoderFor<ItestPrntCnstAltObjOutpObject>();
  public Structured Encode(ItestAltCnstAltObjOutpObject input)
    => _itestPrntCnstAltObjOutp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstDomEnumDualEncoder : IEncoder<ItestCnstDomEnumDualObject>
{
  public Structured Encode(ItestCnstDomEnumDualObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstDomEnumDual");
}

internal class testJustCnstDomEnumDualEncoder : IEncoder<ItestJustCnstDomEnumDual>
{
  public Structured Encode(ItestJustCnstDomEnumDual input)
    => new((decimal?)input.Value);
}

internal class testEnumCnstDomEnumInpEncoder : IEncoder<testEnumCnstDomEnumInp>
{
  public Structured Encode(testEnumCnstDomEnumInp input)
    => new(input.ToString(), "_EnumCnstDomEnumInp");
}

internal class testJustCnstDomEnumInpEncoder : IEncoder<ItestJustCnstDomEnumInp>
{
  public Structured Encode(ItestJustCnstDomEnumInp input)
    => new((decimal?)input.Value);
}

internal class testCnstDomEnumOutpEncoder : IEncoder<ItestCnstDomEnumOutpObject>
{
  public Structured Encode(ItestCnstDomEnumOutpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstDomEnumOutp");
}

internal class testJustCnstDomEnumOutpEncoder : IEncoder<ItestJustCnstDomEnumOutp>
{
  public Structured Encode(ItestJustCnstDomEnumOutp input)
    => new((decimal?)input.Value);
}

internal class testCnstEnumDualEncoder : IEncoder<ItestCnstEnumDualObject>
{
  public Structured Encode(ItestCnstEnumDualObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstEnumDual");
}

internal class testEnumCnstEnumInpEncoder : IEncoder<testEnumCnstEnumInp>
{
  public Structured Encode(testEnumCnstEnumInp input)
    => new(input.ToString(), "_EnumCnstEnumInp");
}

internal class testCnstEnumOutpEncoder : IEncoder<ItestCnstEnumOutpObject>
{
  public Structured Encode(ItestCnstEnumOutpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstEnumOutp");
}

internal class testCnstEnumPrntDualEncoder : IEncoder<ItestCnstEnumPrntDualObject>
{
  public Structured Encode(ItestCnstEnumPrntDualObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstEnumPrntDual");
}

internal class testParentCnstEnumPrntDualEncoder : IEncoder<testParentCnstEnumPrntDual>
{
  public Structured Encode(testParentCnstEnumPrntDual input)
    => new(input.ToString(), "_ParentCnstEnumPrntDual");
}

internal class testEnumCnstEnumPrntInpEncoder : IEncoder<testEnumCnstEnumPrntInp>
{
  public Structured Encode(testEnumCnstEnumPrntInp input)
    => new(input.ToString(), "_EnumCnstEnumPrntInp");
}

internal class testParentCnstEnumPrntInpEncoder : IEncoder<testParentCnstEnumPrntInp>
{
  public Structured Encode(testParentCnstEnumPrntInp input)
    => new(input.ToString(), "_ParentCnstEnumPrntInp");
}

internal class testCnstEnumPrntOutpEncoder : IEncoder<ItestCnstEnumPrntOutpObject>
{
  public Structured Encode(ItestCnstEnumPrntOutpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstEnumPrntOutp");
}

internal class testParentCnstEnumPrntOutpEncoder : IEncoder<testParentCnstEnumPrntOutp>
{
  public Structured Encode(testParentCnstEnumPrntOutp input)
    => new(input.ToString(), "_ParentCnstEnumPrntOutp");
}

internal class testCnstFieldDmnDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>> _itestRefCnstFieldDmnDual = encoders.EncoderFor<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>>();
  public Structured Encode(ItestCnstFieldDmnDualObject input)
    => _itestRefCnstFieldDmnDual.Encode(input);
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
    => new(input.Value);
}

internal class testDomCnstFieldDmnInpEncoder : IEncoder<ItestDomCnstFieldDmnInp>
{
  public Structured Encode(ItestDomCnstFieldDmnInp input)
    => new(input.Value);
}

internal class testCnstFieldDmnOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>> _itestRefCnstFieldDmnOutp = encoders.EncoderFor<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>>();
  public Structured Encode(ItestCnstFieldDmnOutpObject input)
    => _itestRefCnstFieldDmnOutp.Encode(input);
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
    => new(input.Value);
}

internal class testCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>> _itestRefCnstFieldDualDual = encoders.EncoderFor<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>>();
  public Structured Encode(ItestCnstFieldDualDualObject input)
    => _itestRefCnstFieldDualDual.Encode(input);
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
}

internal class testAltCnstFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualDualObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualDualObject> _itestPrntCnstFieldDualDual = encoders.EncoderFor<ItestPrntCnstFieldDualDualObject>();
  public Structured Encode(ItestAltCnstFieldDualDualObject input)
    => _itestPrntCnstFieldDualDual.Encode(input)
      .Add("alt", input.Alt);
}

internal class testPrntCnstFieldDualInpEncoder : IEncoder<ItestPrntCnstFieldDualInpObject>
{
  public Structured Encode(ItestPrntCnstFieldDualInpObject input)
    => Structured.Empty();
}

internal class testCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>> _itestRefCnstFieldDualOutp = encoders.EncoderFor<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>>();
  public Structured Encode(ItestCnstFieldDualOutpObject input)
    => _itestRefCnstFieldDualOutp.Encode(input);
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
}

internal class testAltCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualOutpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualOutpObject> _itestPrntCnstFieldDualOutp = encoders.EncoderFor<ItestPrntCnstFieldDualOutpObject>();
  public Structured Encode(ItestAltCnstFieldDualOutpObject input)
    => _itestPrntCnstFieldDualOutp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjDualObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>> _itestRefCnstFieldObjDual = encoders.EncoderFor<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>>();
  public Structured Encode(ItestCnstFieldObjDualObject input)
    => _itestRefCnstFieldObjDual.Encode(input);
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
}

internal class testAltCnstFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjDualObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjDualObject> _itestPrntCnstFieldObjDual = encoders.EncoderFor<ItestPrntCnstFieldObjDualObject>();
  public Structured Encode(ItestAltCnstFieldObjDualObject input)
    => _itestPrntCnstFieldObjDual.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>> _itestRefCnstFieldObjOutp = encoders.EncoderFor<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>>();
  public Structured Encode(ItestCnstFieldObjOutpObject input)
    => _itestRefCnstFieldObjOutp.Encode(input);
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
}

internal class testAltCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjOutpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjOutpObject> _itestPrntCnstFieldObjOutp = encoders.EncoderFor<ItestPrntCnstFieldObjOutpObject>();
  public Structured Encode(ItestAltCnstFieldObjOutpObject input)
    => _itestPrntCnstFieldObjOutp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>> _itestRefCnstPrntDualGrndDual = encoders.EncoderFor<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>>();
  public Structured Encode(ItestCnstPrntDualGrndDualObject input)
    => _itestRefCnstPrntDualGrndDual.Encode(input);
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
}

internal class testPrntCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndDualObject> _itestGrndCnstPrntDualGrndDual = encoders.EncoderFor<ItestGrndCnstPrntDualGrndDualObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndDualObject input)
    => _itestGrndCnstPrntDualGrndDual.Encode(input);
}

internal class testAltCnstPrntDualGrndDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndDualObject> _itestPrntCnstPrntDualGrndDual = encoders.EncoderFor<ItestPrntCnstPrntDualGrndDualObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndDualObject input)
    => _itestPrntCnstPrntDualGrndDual.Encode(input)
      .Add("alt", input.Alt);
}

internal class testGrndCnstPrntDualGrndInpEncoder : IEncoder<ItestGrndCnstPrntDualGrndInpObject>
{
  public Structured Encode(ItestGrndCnstPrntDualGrndInpObject input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndInpObject> _itestGrndCnstPrntDualGrndInp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndInpObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndInpObject input)
    => _itestGrndCnstPrntDualGrndInp.Encode(input);
}

internal class testCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>> _itestRefCnstPrntDualGrndOutp = encoders.EncoderFor<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>>();
  public Structured Encode(ItestCnstPrntDualGrndOutpObject input)
    => _itestRefCnstPrntDualGrndOutp.Encode(input);
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
}

internal class testPrntCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestGrndCnstPrntDualGrndOutpObject> _itestGrndCnstPrntDualGrndOutp = encoders.EncoderFor<ItestGrndCnstPrntDualGrndOutpObject>();
  public Structured Encode(ItestPrntCnstPrntDualGrndOutpObject input)
    => _itestGrndCnstPrntDualGrndOutp.Encode(input);
}

internal class testAltCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndOutpObject> _itestPrntCnstPrntDualGrndOutp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndOutpObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndOutpObject input)
    => _itestPrntCnstPrntDualGrndOutp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>> _itestRefCnstPrntDualPrntDual = encoders.EncoderFor<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>>();
  public Structured Encode(ItestCnstPrntDualPrntDualObject input)
    => _itestRefCnstPrntDualPrntDual.Encode(input);
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
}

internal class testAltCnstPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntDualObject> _itestPrntCnstPrntDualPrntDual = encoders.EncoderFor<ItestPrntCnstPrntDualPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntDualObject input)
    => _itestPrntCnstPrntDualPrntDual.Encode(input)
      .Add("alt", input.Alt);
}

internal class testPrntCnstPrntDualPrntInpEncoder : IEncoder<ItestPrntCnstPrntDualPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntInpObject input)
    => Structured.Empty();
}

internal class testCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>> _itestRefCnstPrntDualPrntOutp = encoders.EncoderFor<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>>();
  public Structured Encode(ItestCnstPrntDualPrntOutpObject input)
    => _itestRefCnstPrntDualPrntOutp.Encode(input);
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
}

internal class testAltCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntOutpObject> _itestPrntCnstPrntDualPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntOutpObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntOutpObject input)
    => _itestPrntCnstPrntDualPrntOutp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstPrntEnumDualEncoder : IEncoder<ItestCnstPrntEnumDualObject>
{
  public Structured Encode(ItestCnstPrntEnumDualObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstPrntEnumDual");
}

internal class testParentCnstPrntEnumDualEncoder : IEncoder<testParentCnstPrntEnumDual>
{
  public Structured Encode(testParentCnstPrntEnumDual input)
    => new(input.ToString(), "_ParentCnstPrntEnumDual");
}

internal class testEnumCnstPrntEnumInpEncoder : IEncoder<testEnumCnstPrntEnumInp>
{
  public Structured Encode(testEnumCnstPrntEnumInp input)
    => new(input.ToString(), "_EnumCnstPrntEnumInp");
}

internal class testParentCnstPrntEnumInpEncoder : IEncoder<testParentCnstPrntEnumInp>
{
  public Structured Encode(testParentCnstPrntEnumInp input)
    => new(input.ToString(), "_ParentCnstPrntEnumInp");
}

internal class testCnstPrntEnumOutpEncoder : IEncoder<ItestCnstPrntEnumOutpObject>
{
  public Structured Encode(ItestCnstPrntEnumOutpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumCnstPrntEnumOutp");
}

internal class testParentCnstPrntEnumOutpEncoder : IEncoder<testParentCnstPrntEnumOutp>
{
  public Structured Encode(testParentCnstPrntEnumOutp input)
    => new(input.ToString(), "_ParentCnstPrntEnumOutp");
}

internal class testCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>> _itestRefCnstPrntObjPrntDual = encoders.EncoderFor<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>>();
  public Structured Encode(ItestCnstPrntObjPrntDualObject input)
    => _itestRefCnstPrntObjPrntDual.Encode(input);
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
}

internal class testAltCnstPrntObjPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntDualObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntDualObject> _itestPrntCnstPrntObjPrntDual = encoders.EncoderFor<ItestPrntCnstPrntObjPrntDualObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntDualObject input)
    => _itestPrntCnstPrntObjPrntDual.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>> _itestRefCnstPrntObjPrntOutp = encoders.EncoderFor<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>>();
  public Structured Encode(ItestCnstPrntObjPrntOutpObject input)
    => _itestRefCnstPrntObjPrntOutp.Encode(input);
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
}

internal class testAltCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntOutpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntOutpObject> _itestPrntCnstPrntObjPrntOutp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntOutpObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntOutpObject input)
    => _itestPrntCnstPrntObjPrntOutp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testFieldDualEncoder : IEncoder<ItestFieldDualObject>
{
  public Structured Encode(ItestFieldDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldOutpEncoder : IEncoder<ItestFieldOutpObject>
{
  public Structured Encode(ItestFieldOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldDescrDualEncoder : IEncoder<ItestFieldDescrDualObject>
{
  public Structured Encode(ItestFieldDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldDescrOutpEncoder : IEncoder<ItestFieldDescrOutpObject>
{
  public Structured Encode(ItestFieldDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualDualObject>
{
  private readonly IEncoder<ItestFldFieldDualDual> _itestFldFieldDualDual = encoders.EncoderFor<ItestFldFieldDualDual>();
  public Structured Encode(ItestFieldDualDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualDual);
}

internal class testFldFieldDualDualEncoder : IEncoder<ItestFldFieldDualDualObject>
{
  public Structured Encode(ItestFldFieldDualDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFldFieldDualInpEncoder : IEncoder<ItestFldFieldDualInpObject>
{
  public Structured Encode(ItestFldFieldDualInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualOutpObject>
{
  private readonly IEncoder<ItestFldFieldDualOutp> _itestFldFieldDualOutp = encoders.EncoderFor<ItestFldFieldDualOutp>();
  public Structured Encode(ItestFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualOutp);
}

internal class testFldFieldDualOutpEncoder : IEncoder<ItestFldFieldDualOutpObject>
{
  public Structured Encode(ItestFldFieldDualOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldEnumDualEncoder : IEncoder<ItestFieldEnumDualObject>
{
  public Structured Encode(ItestFieldEnumDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumDualEncoder : IEncoder<testEnumFieldEnumDual>
{
  public Structured Encode(testEnumFieldEnumDual input)
    => new(input.ToString(), "_EnumFieldEnumDual");
}

internal class testEnumFieldEnumInpEncoder : IEncoder<testEnumFieldEnumInp>
{
  public Structured Encode(testEnumFieldEnumInp input)
    => new(input.ToString(), "_EnumFieldEnumInp");
}

internal class testFieldEnumOutpEncoder : IEncoder<ItestFieldEnumOutpObject>
{
  public Structured Encode(ItestFieldEnumOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumOutpEncoder : IEncoder<testEnumFieldEnumOutp>
{
  public Structured Encode(testEnumFieldEnumOutp input)
    => new(input.ToString(), "_EnumFieldEnumOutp");
}

internal class testFieldEnumPrntDualEncoder : IEncoder<ItestFieldEnumPrntDualObject>
{
  public Structured Encode(ItestFieldEnumPrntDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumPrntDualEncoder : IEncoder<testEnumFieldEnumPrntDual>
{
  public Structured Encode(testEnumFieldEnumPrntDual input)
    => new(input.ToString(), "_EnumFieldEnumPrntDual");
}

internal class testPrntFieldEnumPrntDualEncoder : IEncoder<testPrntFieldEnumPrntDual>
{
  public Structured Encode(testPrntFieldEnumPrntDual input)
    => new(input.ToString(), "_PrntFieldEnumPrntDual");
}

internal class testEnumFieldEnumPrntInpEncoder : IEncoder<testEnumFieldEnumPrntInp>
{
  public Structured Encode(testEnumFieldEnumPrntInp input)
    => new(input.ToString(), "_EnumFieldEnumPrntInp");
}

internal class testPrntFieldEnumPrntInpEncoder : IEncoder<testPrntFieldEnumPrntInp>
{
  public Structured Encode(testPrntFieldEnumPrntInp input)
    => new(input.ToString(), "_PrntFieldEnumPrntInp");
}

internal class testFieldEnumPrntOutpEncoder : IEncoder<ItestFieldEnumPrntOutpObject>
{
  public Structured Encode(ItestFieldEnumPrntOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldEnumPrntOutpEncoder : IEncoder<testEnumFieldEnumPrntOutp>
{
  public Structured Encode(testEnumFieldEnumPrntOutp input)
    => new(input.ToString(), "_EnumFieldEnumPrntOutp");
}

internal class testPrntFieldEnumPrntOutpEncoder : IEncoder<testPrntFieldEnumPrntOutp>
{
  public Structured Encode(testPrntFieldEnumPrntOutp input)
    => new(input.ToString(), "_PrntFieldEnumPrntOutp");
}

internal class testFieldModEnumDualEncoder : IEncoder<ItestFieldModEnumDualObject>
{
  public Structured Encode(ItestFieldModEnumDualObject input)
    => Structured.Empty();
}

internal class testEnumFieldModEnumDualEncoder : IEncoder<testEnumFieldModEnumDual>
{
  public Structured Encode(testEnumFieldModEnumDual input)
    => new(input.ToString(), "_EnumFieldModEnumDual");
}

internal class testEnumFieldModEnumInpEncoder : IEncoder<testEnumFieldModEnumInp>
{
  public Structured Encode(testEnumFieldModEnumInp input)
    => new(input.ToString(), "_EnumFieldModEnumInp");
}

internal class testFieldModEnumOutpEncoder : IEncoder<ItestFieldModEnumOutpObject>
{
  public Structured Encode(ItestFieldModEnumOutpObject input)
    => Structured.Empty();
}

internal class testEnumFieldModEnumOutpEncoder : IEncoder<testEnumFieldModEnumOutp>
{
  public Structured Encode(testEnumFieldModEnumOutp input)
    => new(input.ToString(), "_EnumFieldModEnumOutp");
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
      .Add("field", input.Field);
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
      .Add("field", input.Field);
}

internal class testFieldObjDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjDualObject>
{
  private readonly IEncoder<ItestFldFieldObjDual> _itestFldFieldObjDual = encoders.EncoderFor<ItestFldFieldObjDual>();
  public Structured Encode(ItestFieldObjDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjDual);
}

internal class testFldFieldObjDualEncoder : IEncoder<ItestFldFieldObjDualObject>
{
  public Structured Encode(ItestFldFieldObjDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjOutpObject>
{
  private readonly IEncoder<ItestFldFieldObjOutp> _itestFldFieldObjOutp = encoders.EncoderFor<ItestFldFieldObjOutp>();
  public Structured Encode(ItestFieldObjOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjOutp);
}

internal class testFldFieldObjOutpEncoder : IEncoder<ItestFldFieldObjOutpObject>
{
  public Structured Encode(ItestFldFieldObjOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldSmplDualEncoder : IEncoder<ItestFieldSmplDualObject>
{
  public Structured Encode(ItestFieldSmplDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldSmplOutpEncoder : IEncoder<ItestFieldSmplOutpObject>
{
  public Structured Encode(ItestFieldSmplOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldTypeDescrDualEncoder : IEncoder<ItestFieldTypeDescrDualObject>
{
  public Structured Encode(ItestFieldTypeDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldTypeDescrOutpEncoder : IEncoder<ItestFieldTypeDescrOutpObject>
{
  public Structured Encode(ItestFieldTypeDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldValueDualEncoder : IEncoder<ItestFieldValueDualObject>
{
  public Structured Encode(ItestFieldValueDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldValueDualEncoder : IEncoder<testEnumFieldValueDual>
{
  public Structured Encode(testEnumFieldValueDual input)
    => new(input.ToString(), "_EnumFieldValueDual");
}

internal class testEnumFieldValueInpEncoder : IEncoder<testEnumFieldValueInp>
{
  public Structured Encode(testEnumFieldValueInp input)
    => new(input.ToString(), "_EnumFieldValueInp");
}

internal class testFieldValueOutpEncoder : IEncoder<ItestFieldValueOutpObject>
{
  public Structured Encode(ItestFieldValueOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldValueOutpEncoder : IEncoder<testEnumFieldValueOutp>
{
  public Structured Encode(testEnumFieldValueOutp input)
    => new(input.ToString(), "_EnumFieldValueOutp");
}

internal class testFieldValueDescrDualEncoder : IEncoder<ItestFieldValueDescrDualObject>
{
  public Structured Encode(ItestFieldValueDescrDualObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldValueDescrDualEncoder : IEncoder<testEnumFieldValueDescrDual>
{
  public Structured Encode(testEnumFieldValueDescrDual input)
    => new(input.ToString(), "_EnumFieldValueDescrDual");
}

internal class testEnumFieldValueDescrInpEncoder : IEncoder<testEnumFieldValueDescrInp>
{
  public Structured Encode(testEnumFieldValueDescrInp input)
    => new(input.ToString(), "_EnumFieldValueDescrInp");
}

internal class testFieldValueDescrOutpEncoder : IEncoder<ItestFieldValueDescrOutpObject>
{
  public Structured Encode(ItestFieldValueDescrOutpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumFieldValueDescrOutpEncoder : IEncoder<testEnumFieldValueDescrOutp>
{
  public Structured Encode(testEnumFieldValueDescrOutp input)
    => new(input.ToString(), "_EnumFieldValueDescrOutp");
}

internal class testGnrcAltDualEncoder<TType> : IEncoder<ItestGnrcAltDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltDualObject<TType> input)
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
      .Add("alt", input.Alt);
}

internal class testAltGnrcAltDualInpEncoder : IEncoder<ItestAltGnrcAltDualInpObject>
{
  public Structured Encode(ItestAltGnrcAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcAltDualOutpEncoder : IEncoder<ItestGnrcAltDualOutpObject>
{
  public Structured Encode(ItestGnrcAltDualOutpObject input)
    => Structured.Empty();
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
      .Add("alt", input.Alt);
}

internal class testRefGnrcAltModParamDualEncoder<TRef,TMod> : IEncoder<ItestRefGnrcAltModParamDualObject<TRef,TMod>>
{
  public Structured Encode(ItestRefGnrcAltModParamDualObject<TRef,TMod> input)
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

internal class testRefGnrcAltModStrOutpEncoder<TRef> : IEncoder<ItestRefGnrcAltModStrOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltModStrOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltParamDualEncoder : IEncoder<ItestGnrcAltParamDualObject>
{
  public Structured Encode(ItestGnrcAltParamDualObject input)
    => Structured.Empty();
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
      .Add("alt", input.Alt);
}

internal class testGnrcAltParamOutpEncoder : IEncoder<ItestGnrcAltParamOutpObject>
{
  public Structured Encode(ItestGnrcAltParamOutpObject input)
    => Structured.Empty();
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
      .Add("alt", input.Alt);
}

internal class testGnrcAltSmplDualEncoder : IEncoder<ItestGnrcAltSmplDualObject>
{
  public Structured Encode(ItestGnrcAltSmplDualObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltSmplDualEncoder<TRef> : IEncoder<ItestRefGnrcAltSmplDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltSmplOutpEncoder : IEncoder<ItestGnrcAltSmplOutpObject>
{
  public Structured Encode(ItestGnrcAltSmplOutpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumGnrcEnumDual");
}

internal class testEnumGnrcEnumInpEncoder : IEncoder<testEnumGnrcEnumInp>
{
  public Structured Encode(testEnumGnrcEnumInp input)
    => new(input.ToString(), "_EnumGnrcEnumInp");
}

internal class testGnrcEnumOutpEncoder : IEncoder<ItestGnrcEnumOutpObject>
{
  public Structured Encode(ItestGnrcEnumOutpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumGnrcEnumOutp");
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
      .Add("alt", input.Alt);
}

internal class testAltGnrcFieldDualInpEncoder : IEncoder<ItestAltGnrcFieldDualInpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>> _itestRefGnrcFieldDualOutp = encoders.EncoderFor<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>>();
  public Structured Encode(ItestGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualOutp);
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
      .Add("alt", input.Alt);
}

internal class testGnrcFieldParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamDualObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>> _itestRefGnrcFieldParamDual = encoders.EncoderFor<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>>();
  public Structured Encode(ItestGnrcFieldParamDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamDual);
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
      .Add("alt", input.Alt);
}

internal class testGnrcFieldParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>> _itestRefGnrcFieldParamOutp = encoders.EncoderFor<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>>();
  public Structured Encode(ItestGnrcFieldParamOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamOutp);
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
      .Add("alt", input.Alt);
}

internal class testGnrcPrntDualEncoder<TType> : IEncoder<ItestGnrcPrntDualObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDualObject<TType> input)
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
      .Add("alt", input.Alt);
}

internal class testAltGnrcPrntDualInpEncoder : IEncoder<ItestAltGnrcPrntDualInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>> _itestRefGnrcPrntDualOutp = encoders.EncoderFor<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>>();
  public Structured Encode(ItestGnrcPrntDualOutpObject input)
    => _itestRefGnrcPrntDualOutp.Encode(input);
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
      .Add("alt", input.Alt);
}

internal class testGnrcPrntDualPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>> _itestRefGnrcPrntDualPrntDual = encoders.EncoderFor<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>>();
  public Structured Encode(ItestGnrcPrntDualPrntDualObject input)
    => _itestRefGnrcPrntDualPrntDual.Encode(input);
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
      .Add("alt", input.Alt);
}

internal class testAltGnrcPrntDualPrntInpEncoder : IEncoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>> _itestRefGnrcPrntDualPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>>();
  public Structured Encode(ItestGnrcPrntDualPrntOutpObject input)
    => _itestRefGnrcPrntDualPrntOutp.Encode(input);
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
      .Add("alt", input.Alt);
}

internal class testGnrcPrntEnumChildDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>> _itestFieldGnrcPrntEnumChildDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>>();
  public Structured Encode(ItestGnrcPrntEnumChildDualObject input)
    => _itestFieldGnrcPrntEnumChildDual.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntEnumChildDual");
}

internal class testParentGnrcPrntEnumChildDualEncoder : IEncoder<testParentGnrcPrntEnumChildDual>
{
  public Structured Encode(testParentGnrcPrntEnumChildDual input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildDual");
}

internal class testEnumGnrcPrntEnumChildInpEncoder : IEncoder<testEnumGnrcPrntEnumChildInp>
{
  public Structured Encode(testEnumGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumChildInp");
}

internal class testParentGnrcPrntEnumChildInpEncoder : IEncoder<testParentGnrcPrntEnumChildInp>
{
  public Structured Encode(testParentGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildInp");
}

internal class testGnrcPrntEnumChildOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>> _itestFieldGnrcPrntEnumChildOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>>();
  public Structured Encode(ItestGnrcPrntEnumChildOutpObject input)
    => _itestFieldGnrcPrntEnumChildOutp.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntEnumChildOutp");
}

internal class testParentGnrcPrntEnumChildOutpEncoder : IEncoder<testParentGnrcPrntEnumChildOutp>
{
  public Structured Encode(testParentGnrcPrntEnumChildOutp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildOutp");
}

internal class testGnrcPrntEnumDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>> _itestFieldGnrcPrntEnumDomDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>>();
  public Structured Encode(ItestGnrcPrntEnumDomDualObject input)
    => _itestFieldGnrcPrntEnumDomDual.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntEnumDomDual");
}

internal class testDomGnrcPrntEnumDomDualEncoder : IEncoder<ItestDomGnrcPrntEnumDomDual>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomDual input)
    => new((decimal?)input.Value);
}

internal class testEnumGnrcPrntEnumDomInpEncoder : IEncoder<testEnumGnrcPrntEnumDomInp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumDomInp");
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomInp input)
    => new((decimal?)input.Value);
}

internal class testGnrcPrntEnumDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>> _itestFieldGnrcPrntEnumDomOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>>();
  public Structured Encode(ItestGnrcPrntEnumDomOutpObject input)
    => _itestFieldGnrcPrntEnumDomOutp.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntEnumDomOutp");
}

internal class testDomGnrcPrntEnumDomOutpEncoder : IEncoder<ItestDomGnrcPrntEnumDomOutp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomOutp input)
    => new((decimal?)input.Value);
}

internal class testGnrcPrntEnumPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>> _itestFieldGnrcPrntEnumPrntDual = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>>();
  public Structured Encode(ItestGnrcPrntEnumPrntDualObject input)
    => _itestFieldGnrcPrntEnumPrntDual.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntDual");
}

internal class testParentGnrcPrntEnumPrntDualEncoder : IEncoder<testParentGnrcPrntEnumPrntDual>
{
  public Structured Encode(testParentGnrcPrntEnumPrntDual input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntDual");
}

internal class testEnumGnrcPrntEnumPrntInpEncoder : IEncoder<testEnumGnrcPrntEnumPrntInp>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntInp");
}

internal class testParentGnrcPrntEnumPrntInpEncoder : IEncoder<testParentGnrcPrntEnumPrntInp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntInp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntInp");
}

internal class testGnrcPrntEnumPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>> _itestFieldGnrcPrntEnumPrntOutp = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>>();
  public Structured Encode(ItestGnrcPrntEnumPrntOutpObject input)
    => _itestFieldGnrcPrntEnumPrntOutp.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntOutp");
}

internal class testParentGnrcPrntEnumPrntOutpEncoder : IEncoder<testParentGnrcPrntEnumPrntOutp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntOutp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntOutp");
}

internal class testGnrcPrntParamDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>> _itestRefGnrcPrntParamDual = encoders.EncoderFor<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>>();
  public Structured Encode(ItestGnrcPrntParamDualObject input)
    => _itestRefGnrcPrntParamDual.Encode(input);
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
      .Add("alt", input.Alt);
}

internal class testGnrcPrntParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>> _itestRefGnrcPrntParamOutp = encoders.EncoderFor<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>>();
  public Structured Encode(ItestGnrcPrntParamOutpObject input)
    => _itestRefGnrcPrntParamOutp.Encode(input);
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
      .Add("alt", input.Alt);
}

internal class testGnrcPrntParamPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>> _itestRefGnrcPrntParamPrntDual = encoders.EncoderFor<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>>();
  public Structured Encode(ItestGnrcPrntParamPrntDualObject input)
    => _itestRefGnrcPrntParamPrntDual.Encode(input);
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
      .Add("alt", input.Alt);
}

internal class testGnrcPrntParamPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>> _itestRefGnrcPrntParamPrntOutp = encoders.EncoderFor<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>>();
  public Structured Encode(ItestGnrcPrntParamPrntOutpObject input)
    => _itestRefGnrcPrntParamPrntOutp.Encode(input);
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
      .Add("alt", input.Alt);
}

internal class testGnrcPrntSmplEnumDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>> _itestFieldGnrcPrntSmplEnumDual = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>>();
  public Structured Encode(ItestGnrcPrntSmplEnumDualObject input)
    => _itestFieldGnrcPrntSmplEnumDual.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumDual");
}

internal class testEnumGnrcPrntSmplEnumInpEncoder : IEncoder<testEnumGnrcPrntSmplEnumInp>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumInp input)
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumInp");
}

internal class testGnrcPrntSmplEnumOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>> _itestFieldGnrcPrntSmplEnumOutp = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>>();
  public Structured Encode(ItestGnrcPrntSmplEnumOutpObject input)
    => _itestFieldGnrcPrntSmplEnumOutp.Encode(input);
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
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumOutp");
}

internal class testGnrcPrntStrDomDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomDualObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>> _itestFieldGnrcPrntStrDomDual = encoders.EncoderFor<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>>();
  public Structured Encode(ItestGnrcPrntStrDomDualObject input)
    => _itestFieldGnrcPrntStrDomDual.Encode(input);
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
    => new(input.Value);
}

internal class testDomGnrcPrntStrDomInpEncoder : IEncoder<ItestDomGnrcPrntStrDomInp>
{
  public Structured Encode(ItestDomGnrcPrntStrDomInp input)
    => new(input.Value);
}

internal class testGnrcPrntStrDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>> _itestFieldGnrcPrntStrDomOutp = encoders.EncoderFor<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>>();
  public Structured Encode(ItestGnrcPrntStrDomOutpObject input)
    => _itestFieldGnrcPrntStrDomOutp.Encode(input);
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
    => new(input.Value);
}

internal class testGnrcValueDualEncoder : IEncoder<ItestGnrcValueDualObject>
{
  public Structured Encode(ItestGnrcValueDualObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumGnrcValueDual");
}

internal class testEnumGnrcValueInpEncoder : IEncoder<testEnumGnrcValueInp>
{
  public Structured Encode(testEnumGnrcValueInp input)
    => new(input.ToString(), "_EnumGnrcValueInp");
}

internal class testGnrcValueOutpEncoder : IEncoder<ItestGnrcValueOutpObject>
{
  public Structured Encode(ItestGnrcValueOutpObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumGnrcValueOutp");
}

internal class testEnumInpFieldEnumEncoder : IEncoder<testEnumInpFieldEnum>
{
  public Structured Encode(testEnumInpFieldEnum input)
    => new(input.ToString(), "_EnumInpFieldEnum");
}

internal class testFldInpFieldNullEncoder : IEncoder<ItestFldInpFieldNullObject>
{
  public Structured Encode(ItestFldInpFieldNullObject input)
    => Structured.Empty();
}

internal class testOutpDescrParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpDescrParamObject>
{
  private readonly IEncoder<ItestFldOutpDescrParam> _itestFldOutpDescrParam = encoders.EncoderFor<ItestFldOutpDescrParam>();
  public Structured Encode(ItestOutpDescrParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpDescrParam);
}

internal class testFldOutpDescrParamEncoder : IEncoder<ItestFldOutpDescrParamObject>
{
  public Structured Encode(ItestFldOutpDescrParamObject input)
    => Structured.Empty();
}

internal class testOutpParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamObject>
{
  private readonly IEncoder<ItestFldOutpParam> _itestFldOutpParam = encoders.EncoderFor<ItestFldOutpParam>();
  public Structured Encode(ItestOutpParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParam);
}

internal class testFldOutpParamEncoder : IEncoder<ItestFldOutpParamObject>
{
  public Structured Encode(ItestFldOutpParamObject input)
    => Structured.Empty();
}

internal class testOutpParamDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamDescr> _itestFldOutpParamDescr = encoders.EncoderFor<ItestFldOutpParamDescr>();
  public Structured Encode(ItestOutpParamDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParamDescr);
}

internal class testFldOutpParamDescrEncoder : IEncoder<ItestFldOutpParamDescrObject>
{
  public Structured Encode(ItestFldOutpParamDescrObject input)
    => Structured.Empty();
}

internal class testOutpParamModDmnEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModDmnObject>
{
  private readonly IEncoder<ItestDomOutpParamModDmn> _itestDomOutpParamModDmn = encoders.EncoderFor<ItestDomOutpParamModDmn>();
  public Structured Encode(ItestOutpParamModDmnObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestDomOutpParamModDmn);
}

internal class testDomOutpParamModDmnEncoder : IEncoder<ItestDomOutpParamModDmn>
{
  public Structured Encode(ItestDomOutpParamModDmn input)
    => new(input.Value);
}

internal class testOutpParamModParamEncoder<TMod>(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModParamObject<TMod>>
{
  private readonly IEncoder<ItestDomOutpParamModParam> _itestDomOutpParamModParam = encoders.EncoderFor<ItestDomOutpParamModParam>();
  public Structured Encode(ItestOutpParamModParamObject<TMod> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestDomOutpParamModParam);
}

internal class testDomOutpParamModParamEncoder : IEncoder<ItestDomOutpParamModParam>
{
  public Structured Encode(ItestDomOutpParamModParam input)
    => new(input.Value);
}

internal class testOutpParamTypeDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamTypeDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamTypeDescr> _itestFldOutpParamTypeDescr = encoders.EncoderFor<ItestFldOutpParamTypeDescr>();
  public Structured Encode(ItestOutpParamTypeDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParamTypeDescr);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public Structured Encode(ItestFldOutpParamTypeDescrObject input)
    => Structured.Empty();
}

internal class testOutpPrntGnrcEncoder : IEncoder<ItestOutpPrntGnrcObject>
{
  public Structured Encode(ItestOutpPrntGnrcObject input)
    => Structured.Empty();
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
    => new(input.ToString(), "_EnumOutpPrntGnrc");
}

internal class testPrntOutpPrntGnrcEncoder : IEncoder<testPrntOutpPrntGnrc>
{
  public Structured Encode(testPrntOutpPrntGnrc input)
    => new(input.ToString(), "_PrntOutpPrntGnrc");
}

internal class testOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpPrntParamObject>
{
  private readonly IEncoder<ItestPrntOutpPrntParamObject> _itestPrntOutpPrntParam = encoders.EncoderFor<ItestPrntOutpPrntParamObject>();
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestOutpPrntParamObject input)
    => _itestPrntOutpPrntParam.Encode(input)
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);
}

internal class testPrntOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpPrntParamObject>
{
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestPrntOutpPrntParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);
}

internal class testFldOutpPrntParamEncoder : IEncoder<ItestFldOutpPrntParamObject>
{
  public Structured Encode(ItestFldOutpPrntParamObject input)
    => Structured.Empty();
}

internal class testPrntDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualObject>
{
  private readonly IEncoder<ItestRefPrntDualObject> _itestRefPrntDual = encoders.EncoderFor<ItestRefPrntDualObject>();
  public Structured Encode(ItestPrntDualObject input)
    => _itestRefPrntDual.Encode(input);
}

internal class testRefPrntDualEncoder : IEncoder<ItestRefPrntDualObject>
{
  public Structured Encode(ItestRefPrntDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpObject>
{
  private readonly IEncoder<ItestRefPrntOutpObject> _itestRefPrntOutp = encoders.EncoderFor<ItestRefPrntOutpObject>();
  public Structured Encode(ItestPrntOutpObject input)
    => _itestRefPrntOutp.Encode(input);
}

internal class testRefPrntOutpEncoder : IEncoder<ItestRefPrntOutpObject>
{
  public Structured Encode(ItestRefPrntOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntAltDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltDualObject>
{
  private readonly IEncoder<ItestRefPrntAltDualObject> _itestRefPrntAltDual = encoders.EncoderFor<ItestRefPrntAltDualObject>();
  public Structured Encode(ItestPrntAltDualObject input)
    => _itestRefPrntAltDual.Encode(input);
}

internal class testRefPrntAltDualEncoder : IEncoder<ItestRefPrntAltDualObject>
{
  public Structured Encode(ItestRefPrntAltDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntAltOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltOutpObject>
{
  private readonly IEncoder<ItestRefPrntAltOutpObject> _itestRefPrntAltOutp = encoders.EncoderFor<ItestRefPrntAltOutpObject>();
  public Structured Encode(ItestPrntAltOutpObject input)
    => _itestRefPrntAltOutp.Encode(input);
}

internal class testRefPrntAltOutpEncoder : IEncoder<ItestRefPrntAltOutpObject>
{
  public Structured Encode(ItestRefPrntAltOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntDescrDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrDualObject>
{
  private readonly IEncoder<ItestRefPrntDescrDualObject> _itestRefPrntDescrDual = encoders.EncoderFor<ItestRefPrntDescrDualObject>();
  public Structured Encode(ItestPrntDescrDualObject input)
    => _itestRefPrntDescrDual.Encode(input);
}

internal class testRefPrntDescrDualEncoder : IEncoder<ItestRefPrntDescrDualObject>
{
  public Structured Encode(ItestRefPrntDescrDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntDescrOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrOutpObject>
{
  private readonly IEncoder<ItestRefPrntDescrOutpObject> _itestRefPrntDescrOutp = encoders.EncoderFor<ItestRefPrntDescrOutpObject>();
  public Structured Encode(ItestPrntDescrOutpObject input)
    => _itestRefPrntDescrOutp.Encode(input);
}

internal class testRefPrntDescrOutpEncoder : IEncoder<ItestRefPrntDescrOutpObject>
{
  public Structured Encode(ItestRefPrntDescrOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualDualObject>
{
  private readonly IEncoder<ItestRefPrntDualDualObject> _itestRefPrntDualDual = encoders.EncoderFor<ItestRefPrntDualDualObject>();
  public Structured Encode(ItestPrntDualDualObject input)
    => _itestRefPrntDualDual.Encode(input);
}

internal class testRefPrntDualDualEncoder : IEncoder<ItestRefPrntDualDualObject>
{
  public Structured Encode(ItestRefPrntDualDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testRefPrntDualInpEncoder : IEncoder<ItestRefPrntDualInpObject>
{
  public Structured Encode(ItestRefPrntDualInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualOutpObject>
{
  private readonly IEncoder<ItestRefPrntDualOutpObject> _itestRefPrntDualOutp = encoders.EncoderFor<ItestRefPrntDualOutpObject>();
  public Structured Encode(ItestPrntDualOutpObject input)
    => _itestRefPrntDualOutp.Encode(input);
}

internal class testRefPrntDualOutpEncoder : IEncoder<ItestRefPrntDualOutpObject>
{
  public Structured Encode(ItestRefPrntDualOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldDualObject>
{
  private readonly IEncoder<ItestRefPrntFieldDualObject> _itestRefPrntFieldDual = encoders.EncoderFor<ItestRefPrntFieldDualObject>();
  public Structured Encode(ItestPrntFieldDualObject input)
    => _itestRefPrntFieldDual.Encode(input)
      .Add("field", input.Field);
}

internal class testRefPrntFieldDualEncoder : IEncoder<ItestRefPrntFieldDualObject>
{
  public Structured Encode(ItestRefPrntFieldDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
}

internal class testPrntFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldOutpObject>
{
  private readonly IEncoder<ItestRefPrntFieldOutpObject> _itestRefPrntFieldOutp = encoders.EncoderFor<ItestRefPrntFieldOutpObject>();
  public Structured Encode(ItestPrntFieldOutpObject input)
    => _itestRefPrntFieldOutp.Encode(input)
      .Add("field", input.Field);
}

internal class testRefPrntFieldOutpEncoder : IEncoder<ItestRefPrntFieldOutpObject>
{
  public Structured Encode(ItestRefPrntFieldOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
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
}

internal class testCtgrAliasEncoder : IEncoder<ItestCtgrAliasObject>
{
  public Structured Encode(ItestCtgrAliasObject input)
    => Structured.Empty();
}

internal class testCtgrDescrEncoder : IEncoder<ItestCtgrDescrObject>
{
  public Structured Encode(ItestCtgrDescrObject input)
    => Structured.Empty();
}

internal class testCtgrModEncoder : IEncoder<ItestCtgrModObject>
{
  public Structured Encode(ItestCtgrModObject input)
    => Structured.Empty();
}

internal class testDmnAliasEncoder : IEncoder<ItestDmnAlias>
{
  public Structured Encode(ItestDmnAlias input)
    => new(input.Value);
}

internal class testDmnBoolEncoder : IEncoder<ItestDmnBool>
{
  public Structured Encode(ItestDmnBool input)
    => new(input.Value);
}

internal class testDmnBoolDiffEncoder : IEncoder<ItestDmnBoolDiff>
{
  public Structured Encode(ItestDmnBoolDiff input)
    => new(input.Value);
}

internal class testDmnBoolSameEncoder : IEncoder<ItestDmnBoolSame>
{
  public Structured Encode(ItestDmnBoolSame input)
    => new(input.Value);
}

internal class testDmnEnumDiffEncoder : IEncoder<ItestDmnEnumDiff>
{
  public Structured Encode(ItestDmnEnumDiff input)
    => new((decimal?)input.Value);
}

internal class testDmnEnumSameEncoder : IEncoder<ItestDmnEnumSame>
{
  public Structured Encode(ItestDmnEnumSame input)
    => new((decimal?)input.Value);
}

internal class testDmnNmbrEncoder : IEncoder<ItestDmnNmbr>
{
  public Structured Encode(ItestDmnNmbr input)
    => new(input.Value);
}

internal class testDmnNmbrDiffEncoder : IEncoder<ItestDmnNmbrDiff>
{
  public Structured Encode(ItestDmnNmbrDiff input)
    => new(input.Value);
}

internal class testDmnNmbrSameEncoder : IEncoder<ItestDmnNmbrSame>
{
  public Structured Encode(ItestDmnNmbrSame input)
    => new(input.Value);
}

internal class testDmnStrEncoder : IEncoder<ItestDmnStr>
{
  public Structured Encode(ItestDmnStr input)
    => new(input.Value);
}

internal class testDmnStrDiffEncoder : IEncoder<ItestDmnStrDiff>
{
  public Structured Encode(ItestDmnStrDiff input)
    => new(input.Value);
}

internal class testDmnStrSameEncoder : IEncoder<ItestDmnStrSame>
{
  public Structured Encode(ItestDmnStrSame input)
    => new(input.Value);
}

internal class testEnumAliasEncoder : IEncoder<testEnumAlias>
{
  public Structured Encode(testEnumAlias input)
    => new(input.ToString(), "_EnumAlias");
}

internal class testEnumDiffEncoder : IEncoder<testEnumDiff>
{
  public Structured Encode(testEnumDiff input)
    => new(input.ToString(), "_EnumDiff");
}

internal class testEnumSameEncoder : IEncoder<testEnumSame>
{
  public Structured Encode(testEnumSame input)
    => new(input.ToString(), "_EnumSame");
}

internal class testEnumSamePrntEncoder : IEncoder<testEnumSamePrnt>
{
  public Structured Encode(testEnumSamePrnt input)
    => new(input.ToString(), "_EnumSamePrnt");
}

internal class testPrntEnumSamePrntEncoder : IEncoder<testPrntEnumSamePrnt>
{
  public Structured Encode(testPrntEnumSamePrnt input)
    => new(input.ToString(), "_PrntEnumSamePrnt");
}

internal class testEnumValueAliasEncoder : IEncoder<testEnumValueAlias>
{
  public Structured Encode(testEnumValueAlias input)
    => new(input.ToString(), "_EnumValueAlias");
}

internal class testObjDualEncoder : IEncoder<ItestObjDualObject>
{
  public Structured Encode(ItestObjDualObject input)
    => Structured.Empty();
}

internal class testObjOutpEncoder : IEncoder<ItestObjOutpObject>
{
  public Structured Encode(ItestObjOutpObject input)
    => Structured.Empty();
}

internal class testObjAliasDualEncoder : IEncoder<ItestObjAliasDualObject>
{
  public Structured Encode(ItestObjAliasDualObject input)
    => Structured.Empty();
}

internal class testObjAliasOutpEncoder : IEncoder<ItestObjAliasOutpObject>
{
  public Structured Encode(ItestObjAliasOutpObject input)
    => Structured.Empty();
}

internal class testObjAltDualEncoder : IEncoder<ItestObjAltDualObject>
{
  public Structured Encode(ItestObjAltDualObject input)
    => Structured.Empty();
}

internal class testObjAltDualTypeEncoder : IEncoder<ItestObjAltDualTypeObject>
{
  public Structured Encode(ItestObjAltDualTypeObject input)
    => Structured.Empty();
}

internal class testObjAltOutpEncoder : IEncoder<ItestObjAltOutpObject>
{
  public Structured Encode(ItestObjAltOutpObject input)
    => Structured.Empty();
}

internal class testObjAltOutpTypeEncoder : IEncoder<ItestObjAltOutpTypeObject>
{
  public Structured Encode(ItestObjAltOutpTypeObject input)
    => Structured.Empty();
}

internal class testObjAltEnumDualEncoder : IEncoder<ItestObjAltEnumDualObject>
{
  public Structured Encode(ItestObjAltEnumDualObject input)
    => Structured.Empty();
}

internal class testObjAltEnumOutpEncoder : IEncoder<ItestObjAltEnumOutpObject>
{
  public Structured Encode(ItestObjAltEnumOutpObject input)
    => Structured.Empty();
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
}

internal class testFldObjFieldDualEncoder : IEncoder<ItestFldObjFieldDualObject>
{
  public Structured Encode(ItestFldObjFieldDualObject input)
    => Structured.Empty();
}

internal class testObjFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldOutp> _itestFldObjFieldOutp = encoders.EncoderFor<ItestFldObjFieldOutp>();
  public Structured Encode(ItestObjFieldOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldOutp);
}

internal class testFldObjFieldOutpEncoder : IEncoder<ItestFldObjFieldOutpObject>
{
  public Structured Encode(ItestFldObjFieldOutpObject input)
    => Structured.Empty();
}

internal class testObjFieldAliasDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasDualObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasDual> _itestFldObjFieldAliasDual = encoders.EncoderFor<ItestFldObjFieldAliasDual>();
  public Structured Encode(ItestObjFieldAliasDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasDual);
}

internal class testFldObjFieldAliasDualEncoder : IEncoder<ItestFldObjFieldAliasDualObject>
{
  public Structured Encode(ItestFldObjFieldAliasDualObject input)
    => Structured.Empty();
}

internal class testObjFieldAliasOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjFieldAliasOutpObject>
{
  private readonly IEncoder<ItestFldObjFieldAliasOutp> _itestFldObjFieldAliasOutp = encoders.EncoderFor<ItestFldObjFieldAliasOutp>();
  public Structured Encode(ItestObjFieldAliasOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldObjFieldAliasOutp);
}

internal class testFldObjFieldAliasOutpEncoder : IEncoder<ItestFldObjFieldAliasOutpObject>
{
  public Structured Encode(ItestFldObjFieldAliasOutpObject input)
    => Structured.Empty();
}

internal class testObjFieldEnumAliasDualEncoder : IEncoder<ItestObjFieldEnumAliasDualObject>
{
  public Structured Encode(ItestObjFieldEnumAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldEnumAliasOutpEncoder : IEncoder<ItestObjFieldEnumAliasOutpObject>
{
  public Structured Encode(ItestObjFieldEnumAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldEnumValueDualEncoder : IEncoder<ItestObjFieldEnumValueDualObject>
{
  public Structured Encode(ItestObjFieldEnumValueDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldEnumValueOutpEncoder : IEncoder<ItestObjFieldEnumValueOutpObject>
{
  public Structured Encode(ItestObjFieldEnumValueOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldTypeAliasDualEncoder : IEncoder<ItestObjFieldTypeAliasDualObject>
{
  public Structured Encode(ItestObjFieldTypeAliasDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testObjFieldTypeAliasOutpEncoder : IEncoder<ItestObjFieldTypeAliasOutpObject>
{
  public Structured Encode(ItestObjFieldTypeAliasOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
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
}

internal class testRefObjPrntDualEncoder : IEncoder<ItestRefObjPrntDualObject>
{
  public Structured Encode(ItestRefObjPrntDualObject input)
    => Structured.Empty();
}

internal class testObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefObjPrntOutpObject> _itestRefObjPrntOutp = encoders.EncoderFor<ItestRefObjPrntOutpObject>();
  public Structured Encode(ItestObjPrntOutpObject input)
    => _itestRefObjPrntOutp.Encode(input);
}

internal class testRefObjPrntOutpEncoder : IEncoder<ItestRefObjPrntOutpObject>
{
  public Structured Encode(ItestRefObjPrntOutpObject input)
    => Structured.Empty();
}

internal class testOutpFieldParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpFieldParamObject>
{
  private readonly IEncoder<ItestFldOutpFieldParam> _itestFldOutpFieldParam = encoders.EncoderFor<ItestFldOutpFieldParam>();
  public Structured Encode(ItestOutpFieldParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpFieldParam);
}

internal class testFldOutpFieldParamEncoder : IEncoder<ItestFldOutpFieldParamObject>
{
  public Structured Encode(ItestFldOutpFieldParamObject input)
    => Structured.Empty();
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
}

internal class testUnionSameEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSame>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSame input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();
}

internal class testUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionSamePrnt>
{
  private readonly IEncoder<bool> _boolean = encoders.EncoderFor<bool>();
  public Structured Encode(ItestUnionSamePrnt input)
    => input.HasA<bool>() ? _boolean.Encode(input.AsA<bool>())
     : Structured.Empty();
}

internal class testPrntUnionSamePrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionSamePrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestPrntUnionSamePrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();
}

internal class testDmnBoolDescrEncoder : IEncoder<ItestDmnBoolDescr>
{
  public Structured Encode(ItestDmnBoolDescr input)
    => new(input.Value);
}

internal class testDmnBoolPrntEncoder : IEncoder<ItestDmnBoolPrnt>
{
  public Structured Encode(ItestDmnBoolPrnt input)
    => new(input.Value);
}

internal class testPrntDmnBoolPrntEncoder : IEncoder<ItestPrntDmnBoolPrnt>
{
  public Structured Encode(ItestPrntDmnBoolPrnt input)
    => new(input.Value);
}

internal class testDmnBoolPrntDescrEncoder : IEncoder<ItestDmnBoolPrntDescr>
{
  public Structured Encode(ItestDmnBoolPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnBoolPrntDescrEncoder : IEncoder<ItestPrntDmnBoolPrntDescr>
{
  public Structured Encode(ItestPrntDmnBoolPrntDescr input)
    => new(input.Value);
}

internal class testDmnEnumAllEncoder : IEncoder<ItestDmnEnumAll>
{
  public Structured Encode(ItestDmnEnumAll input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllEncoder : IEncoder<testEnumDmnEnumAll>
{
  public Structured Encode(testEnumDmnEnumAll input)
    => new(input.ToString(), "_EnumDmnEnumAll");
}

internal class testDmnEnumAllDescrEncoder : IEncoder<ItestDmnEnumAllDescr>
{
  public Structured Encode(ItestDmnEnumAllDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllDescrEncoder : IEncoder<testEnumDmnEnumAllDescr>
{
  public Structured Encode(testEnumDmnEnumAllDescr input)
    => new(input.ToString(), "_EnumDmnEnumAllDescr");
}

internal class testDmnEnumAllPrntEncoder : IEncoder<ItestDmnEnumAllPrnt>
{
  public Structured Encode(ItestDmnEnumAllPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumAllPrntEncoder : IEncoder<testEnumDmnEnumAllPrnt>
{
  public Structured Encode(testEnumDmnEnumAllPrnt input)
    => new(input.ToString(), "_EnumDmnEnumAllPrnt");
}

internal class testPrntDmnEnumAllPrntEncoder : IEncoder<testPrntDmnEnumAllPrnt>
{
  public Structured Encode(testPrntDmnEnumAllPrnt input)
    => new(input.ToString(), "_PrntDmnEnumAllPrnt");
}

internal class testDmnEnumDescrEncoder : IEncoder<ItestDmnEnumDescr>
{
  public Structured Encode(ItestDmnEnumDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumDescrEncoder : IEncoder<testEnumDmnEnumDescr>
{
  public Structured Encode(testEnumDmnEnumDescr input)
    => new(input.ToString(), "_EnumDmnEnumDescr");
}

internal class testDmnEnumExclEncoder : IEncoder<ItestDmnEnumExcl>
{
  public Structured Encode(ItestDmnEnumExcl input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumExclEncoder : IEncoder<testEnumDmnEnumExcl>
{
  public Structured Encode(testEnumDmnEnumExcl input)
    => new(input.ToString(), "_EnumDmnEnumExcl");
}

internal class testDmnEnumExclPrntEncoder : IEncoder<ItestDmnEnumExclPrnt>
{
  public Structured Encode(ItestDmnEnumExclPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumExclPrntEncoder : IEncoder<testEnumDmnEnumExclPrnt>
{
  public Structured Encode(testEnumDmnEnumExclPrnt input)
    => new(input.ToString(), "_EnumDmnEnumExclPrnt");
}

internal class testPrntDmnEnumExclPrntEncoder : IEncoder<testPrntDmnEnumExclPrnt>
{
  public Structured Encode(testPrntDmnEnumExclPrnt input)
    => new(input.ToString(), "_PrntDmnEnumExclPrnt");
}

internal class testDmnEnumLabelEncoder : IEncoder<ItestDmnEnumLabel>
{
  public Structured Encode(ItestDmnEnumLabel input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumLabelEncoder : IEncoder<testEnumDmnEnumLabel>
{
  public Structured Encode(testEnumDmnEnumLabel input)
    => new(input.ToString(), "_EnumDmnEnumLabel");
}

internal class testDmnEnumPrntEncoder : IEncoder<ItestDmnEnumPrnt>
{
  public Structured Encode(ItestDmnEnumPrnt input)
    => new((decimal?)input.Value);
}

internal class testPrntDmnEnumPrntEncoder : IEncoder<ItestPrntDmnEnumPrnt>
{
  public Structured Encode(ItestPrntDmnEnumPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumPrntEncoder : IEncoder<testEnumDmnEnumPrnt>
{
  public Structured Encode(testEnumDmnEnumPrnt input)
    => new(input.ToString(), "_EnumDmnEnumPrnt");
}

internal class testDmnEnumPrntDescrEncoder : IEncoder<ItestDmnEnumPrntDescr>
{
  public Structured Encode(ItestDmnEnumPrntDescr input)
    => new((decimal?)input.Value);
}

internal class testPrntDmnEnumPrntDescrEncoder : IEncoder<ItestPrntDmnEnumPrntDescr>
{
  public Structured Encode(ItestPrntDmnEnumPrntDescr input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumPrntDescrEncoder : IEncoder<testEnumDmnEnumPrntDescr>
{
  public Structured Encode(testEnumDmnEnumPrntDescr input)
    => new(input.ToString(), "_EnumDmnEnumPrntDescr");
}

internal class testDmnEnumUnqEncoder : IEncoder<ItestDmnEnumUnq>
{
  public Structured Encode(ItestDmnEnumUnq input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumUnqEncoder : IEncoder<testEnumDmnEnumUnq>
{
  public Structured Encode(testEnumDmnEnumUnq input)
    => new(input.ToString(), "_EnumDmnEnumUnq");
}

internal class testDupDmnEnumUnqEncoder : IEncoder<testDupDmnEnumUnq>
{
  public Structured Encode(testDupDmnEnumUnq input)
    => new(input.ToString(), "_DupDmnEnumUnq");
}

internal class testDmnEnumUnqPrntEncoder : IEncoder<ItestDmnEnumUnqPrnt>
{
  public Structured Encode(ItestDmnEnumUnqPrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumUnqPrntEncoder : IEncoder<testEnumDmnEnumUnqPrnt>
{
  public Structured Encode(testEnumDmnEnumUnqPrnt input)
    => new(input.ToString(), "_EnumDmnEnumUnqPrnt");
}

internal class testPrntDmnEnumUnqPrntEncoder : IEncoder<testPrntDmnEnumUnqPrnt>
{
  public Structured Encode(testPrntDmnEnumUnqPrnt input)
    => new(input.ToString(), "_PrntDmnEnumUnqPrnt");
}

internal class testDupDmnEnumUnqPrntEncoder : IEncoder<testDupDmnEnumUnqPrnt>
{
  public Structured Encode(testDupDmnEnumUnqPrnt input)
    => new(input.ToString(), "_DupDmnEnumUnqPrnt");
}

internal class testDmnEnumValueEncoder : IEncoder<ItestDmnEnumValue>
{
  public Structured Encode(ItestDmnEnumValue input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumValueEncoder : IEncoder<testEnumDmnEnumValue>
{
  public Structured Encode(testEnumDmnEnumValue input)
    => new(input.ToString(), "_EnumDmnEnumValue");
}

internal class testDmnEnumValuePrntEncoder : IEncoder<ItestDmnEnumValuePrnt>
{
  public Structured Encode(ItestDmnEnumValuePrnt input)
    => new((decimal?)input.Value);
}

internal class testEnumDmnEnumValuePrntEncoder : IEncoder<testEnumDmnEnumValuePrnt>
{
  public Structured Encode(testEnumDmnEnumValuePrnt input)
    => new(input.ToString(), "_EnumDmnEnumValuePrnt");
}

internal class testPrntDmnEnumValuePrntEncoder : IEncoder<testPrntDmnEnumValuePrnt>
{
  public Structured Encode(testPrntDmnEnumValuePrnt input)
    => new(input.ToString(), "_PrntDmnEnumValuePrnt");
}

internal class testDmnNmbrDescrEncoder : IEncoder<ItestDmnNmbrDescr>
{
  public Structured Encode(ItestDmnNmbrDescr input)
    => new(input.Value);
}

internal class testDmnNmbrPrntEncoder : IEncoder<ItestDmnNmbrPrnt>
{
  public Structured Encode(ItestDmnNmbrPrnt input)
    => new(input.Value);
}

internal class testPrntDmnNmbrPrntEncoder : IEncoder<ItestPrntDmnNmbrPrnt>
{
  public Structured Encode(ItestPrntDmnNmbrPrnt input)
    => new(input.Value);
}

internal class testDmnNmbrPrntDescrEncoder : IEncoder<ItestDmnNmbrPrntDescr>
{
  public Structured Encode(ItestDmnNmbrPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnNmbrPrntDescrEncoder : IEncoder<ItestPrntDmnNmbrPrntDescr>
{
  public Structured Encode(ItestPrntDmnNmbrPrntDescr input)
    => new(input.Value);
}

internal class testDmnNmbrPstvEncoder : IEncoder<ItestDmnNmbrPstv>
{
  public Structured Encode(ItestDmnNmbrPstv input)
    => new(input.Value);
}

internal class testDmnNmbrRangeEncoder : IEncoder<ItestDmnNmbrRange>
{
  public Structured Encode(ItestDmnNmbrRange input)
    => new(input.Value);
}

internal class testDmnStrDescrEncoder : IEncoder<ItestDmnStrDescr>
{
  public Structured Encode(ItestDmnStrDescr input)
    => new(input.Value);
}

internal class testDmnStrNonEmptyEncoder : IEncoder<ItestDmnStrNonEmpty>
{
  public Structured Encode(ItestDmnStrNonEmpty input)
    => new(input.Value);
}

internal class testDmnStrPrntEncoder : IEncoder<ItestDmnStrPrnt>
{
  public Structured Encode(ItestDmnStrPrnt input)
    => new(input.Value);
}

internal class testPrntDmnStrPrntEncoder : IEncoder<ItestPrntDmnStrPrnt>
{
  public Structured Encode(ItestPrntDmnStrPrnt input)
    => new(input.Value);
}

internal class testDmnStrPrntDescrEncoder : IEncoder<ItestDmnStrPrntDescr>
{
  public Structured Encode(ItestDmnStrPrntDescr input)
    => new(input.Value);
}

internal class testPrntDmnStrPrntDescrEncoder : IEncoder<ItestPrntDmnStrPrntDescr>
{
  public Structured Encode(ItestPrntDmnStrPrntDescr input)
    => new(input.Value);
}

internal class testEnumDescrEncoder : IEncoder<testEnumDescr>
{
  public Structured Encode(testEnumDescr input)
    => new(input.ToString(), "_EnumDescr");
}

internal class testEnumPrntEncoder : IEncoder<testEnumPrnt>
{
  public Structured Encode(testEnumPrnt input)
    => new(input.ToString(), "_EnumPrnt");
}

internal class testPrntEnumPrntEncoder : IEncoder<testPrntEnumPrnt>
{
  public Structured Encode(testPrntEnumPrnt input)
    => new(input.ToString(), "_PrntEnumPrnt");
}

internal class testEnumPrntAliasEncoder : IEncoder<testEnumPrntAlias>
{
  public Structured Encode(testEnumPrntAlias input)
    => new(input.ToString(), "_EnumPrntAlias");
}

internal class testPrntEnumPrntAliasEncoder : IEncoder<testPrntEnumPrntAlias>
{
  public Structured Encode(testPrntEnumPrntAlias input)
    => new(input.ToString(), "_PrntEnumPrntAlias");
}

internal class testEnumPrntDescrEncoder : IEncoder<testEnumPrntDescr>
{
  public Structured Encode(testEnumPrntDescr input)
    => new(input.ToString(), "_EnumPrntDescr");
}

internal class testPrntEnumPrntDescrEncoder : IEncoder<testPrntEnumPrntDescr>
{
  public Structured Encode(testPrntEnumPrntDescr input)
    => new(input.ToString(), "_PrntEnumPrntDescr");
}

internal class testEnumPrntDupEncoder : IEncoder<testEnumPrntDup>
{
  public Structured Encode(testEnumPrntDup input)
    => new(input.ToString(), "_EnumPrntDup");
}

internal class testPrntEnumPrntDupEncoder : IEncoder<testPrntEnumPrntDup>
{
  public Structured Encode(testPrntEnumPrntDup input)
    => new(input.ToString(), "_PrntEnumPrntDup");
}

internal class testUnionDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrnt>
{
  private readonly IEncoder<string> _string = encoders.EncoderFor<string>();
  public Structured Encode(ItestUnionPrnt input)
    => input.HasA<string>() ? _string.Encode(input.AsA<string>())
     : Structured.Empty();
}

internal class testPrntUnionPrntEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrnt>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrnt input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testPrntUnionPrntDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDescr>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDescr input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal class testPrntUnionPrntDupEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntUnionPrntDup>
{
  private readonly IEncoder<decimal> _number = encoders.EncoderFor<decimal>();
  public Structured Encode(ItestPrntUnionPrntDup input)
    => input.HasA<decimal>() ? _number.Encode(input.AsA<decimal>())
     : Structured.Empty();
}

internal static class test__ALLEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__ALLEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestCtgrDscrsObject>(_ => new testCtgrDscrsEncoder())
      .AddEncoder<ItestCtgrOutpObject>(_ => new testCtgrOutpEncoder())
      .AddEncoder<ItestCtgrOutpDescrObject>(_ => new testCtgrOutpDescrEncoder())
      .AddEncoder<ItestCtgrOutpDictObject>(_ => new testCtgrOutpDictEncoder())
      .AddEncoder<ItestCtgrOutpListObject>(_ => new testCtgrOutpListEncoder())
      .AddEncoder<ItestCtgrOutpOptlObject>(_ => new testCtgrOutpOptlEncoder())
      .AddEncoder<ItestDescrObject>(_ => new testDescrEncoder())
      .AddEncoder<ItestDescrBcksObject>(_ => new testDescrBcksEncoder())
      .AddEncoder<ItestDescrBtwnObject>(_ => new testDescrBtwnEncoder())
      .AddEncoder<ItestDescrCmplObject>(_ => new testDescrCmplEncoder())
      .AddEncoder<ItestDescrDblObject>(_ => new testDescrDblEncoder())
      .AddEncoder<ItestDescrSnglObject>(_ => new testDescrSnglEncoder())
      .AddEncoder<ItestDscrsObject>(_ => new testDscrsEncoder())
      .AddEncoder<ItestAltDualObject>(_ => new testAltDualEncoder())
      .AddEncoder<ItestAltAltDualObject>(_ => new testAltAltDualEncoder())
      .AddEncoder<ItestAltOutpObject>(_ => new testAltOutpEncoder())
      .AddEncoder<ItestAltAltOutpObject>(_ => new testAltAltOutpEncoder())
      .AddEncoder<ItestAltDescrDualObject>(_ => new testAltDescrDualEncoder())
      .AddEncoder<ItestAltDescrOutpObject>(_ => new testAltDescrOutpEncoder())
      .AddEncoder<ItestAltDualDualObject>(_ => new testAltDualDualEncoder())
      .AddEncoder<ItestObjDualAltDualDualObject>(_ => new testObjDualAltDualDualEncoder())
      .AddEncoder<ItestObjDualAltDualInpObject>(_ => new testObjDualAltDualInpEncoder())
      .AddEncoder<ItestAltDualOutpObject>(_ => new testAltDualOutpEncoder())
      .AddEncoder<ItestObjDualAltDualOutpObject>(_ => new testObjDualAltDualOutpEncoder())
      .AddEncoder<ItestAltEnumDualObject>(_ => new testAltEnumDualEncoder())
      .AddEncoder<testEnumAltEnumDual>(_ => new testEnumAltEnumDualEncoder())
      .AddEncoder<testEnumAltEnumInp>(_ => new testEnumAltEnumInpEncoder())
      .AddEncoder<ItestAltEnumOutpObject>(_ => new testAltEnumOutpEncoder())
      .AddEncoder<testEnumAltEnumOutp>(_ => new testEnumAltEnumOutpEncoder())
      .AddEncoder<ItestAltModBoolDualObject>(_ => new testAltModBoolDualEncoder())
      .AddEncoder<ItestAltAltModBoolDualObject>(_ => new testAltAltModBoolDualEncoder())
      .AddEncoder<ItestAltModBoolOutpObject>(_ => new testAltModBoolOutpEncoder())
      .AddEncoder<ItestAltAltModBoolOutpObject>(_ => new testAltAltModBoolOutpEncoder())
      .AddEncoder<ItestAltAltModParamDualObject>(_ => new testAltAltModParamDualEncoder())
      .AddEncoder<ItestAltAltModParamOutpObject>(_ => new testAltAltModParamOutpEncoder())
      .AddEncoder<ItestAltSmplDualObject>(_ => new testAltSmplDualEncoder())
      .AddEncoder<ItestAltSmplOutpObject>(_ => new testAltSmplOutpEncoder())
      .AddEncoder<ItestCnstAltDmnDualObject>(_ => new testCnstAltDmnDualEncoder())
      .AddEncoder<ItestDomCnstAltDmnDual>(_ => new testDomCnstAltDmnDualEncoder())
      .AddEncoder<ItestDomCnstAltDmnInp>(_ => new testDomCnstAltDmnInpEncoder())
      .AddEncoder<ItestCnstAltDmnOutpObject>(_ => new testCnstAltDmnOutpEncoder())
      .AddEncoder<ItestDomCnstAltDmnOutp>(_ => new testDomCnstAltDmnOutpEncoder())
      .AddEncoder<ItestCnstAltDualDualObject>(_ => new testCnstAltDualDualEncoder())
      .AddEncoder<ItestPrntCnstAltDualDualObject>(_ => new testPrntCnstAltDualDualEncoder())
      .AddEncoder<ItestAltCnstAltDualDualObject>(r => new testAltCnstAltDualDualEncoder(r))
      .AddEncoder<ItestPrntCnstAltDualInpObject>(_ => new testPrntCnstAltDualInpEncoder())
      .AddEncoder<ItestCnstAltDualOutpObject>(_ => new testCnstAltDualOutpEncoder())
      .AddEncoder<ItestPrntCnstAltDualOutpObject>(_ => new testPrntCnstAltDualOutpEncoder())
      .AddEncoder<ItestAltCnstAltDualOutpObject>(r => new testAltCnstAltDualOutpEncoder(r))
      .AddEncoder<ItestCnstAltObjDualObject>(_ => new testCnstAltObjDualEncoder())
      .AddEncoder<ItestPrntCnstAltObjDualObject>(_ => new testPrntCnstAltObjDualEncoder())
      .AddEncoder<ItestAltCnstAltObjDualObject>(r => new testAltCnstAltObjDualEncoder(r))
      .AddEncoder<ItestCnstAltObjOutpObject>(_ => new testCnstAltObjOutpEncoder())
      .AddEncoder<ItestPrntCnstAltObjOutpObject>(_ => new testPrntCnstAltObjOutpEncoder())
      .AddEncoder<ItestAltCnstAltObjOutpObject>(r => new testAltCnstAltObjOutpEncoder(r))
      .AddEncoder<ItestCnstDomEnumDualObject>(_ => new testCnstDomEnumDualEncoder())
      .AddEncoder<testEnumCnstDomEnumDual>(_ => new testEnumCnstDomEnumDualEncoder())
      .AddEncoder<ItestJustCnstDomEnumDual>(_ => new testJustCnstDomEnumDualEncoder())
      .AddEncoder<testEnumCnstDomEnumInp>(_ => new testEnumCnstDomEnumInpEncoder())
      .AddEncoder<ItestJustCnstDomEnumInp>(_ => new testJustCnstDomEnumInpEncoder())
      .AddEncoder<ItestCnstDomEnumOutpObject>(_ => new testCnstDomEnumOutpEncoder())
      .AddEncoder<testEnumCnstDomEnumOutp>(_ => new testEnumCnstDomEnumOutpEncoder())
      .AddEncoder<ItestJustCnstDomEnumOutp>(_ => new testJustCnstDomEnumOutpEncoder())
      .AddEncoder<ItestCnstEnumDualObject>(_ => new testCnstEnumDualEncoder())
      .AddEncoder<testEnumCnstEnumDual>(_ => new testEnumCnstEnumDualEncoder())
      .AddEncoder<testEnumCnstEnumInp>(_ => new testEnumCnstEnumInpEncoder())
      .AddEncoder<ItestCnstEnumOutpObject>(_ => new testCnstEnumOutpEncoder())
      .AddEncoder<testEnumCnstEnumOutp>(_ => new testEnumCnstEnumOutpEncoder())
      .AddEncoder<ItestCnstEnumPrntDualObject>(_ => new testCnstEnumPrntDualEncoder())
      .AddEncoder<testEnumCnstEnumPrntDual>(_ => new testEnumCnstEnumPrntDualEncoder())
      .AddEncoder<testParentCnstEnumPrntDual>(_ => new testParentCnstEnumPrntDualEncoder())
      .AddEncoder<testEnumCnstEnumPrntInp>(_ => new testEnumCnstEnumPrntInpEncoder())
      .AddEncoder<testParentCnstEnumPrntInp>(_ => new testParentCnstEnumPrntInpEncoder())
      .AddEncoder<ItestCnstEnumPrntOutpObject>(_ => new testCnstEnumPrntOutpEncoder())
      .AddEncoder<testEnumCnstEnumPrntOutp>(_ => new testEnumCnstEnumPrntOutpEncoder())
      .AddEncoder<testParentCnstEnumPrntOutp>(_ => new testParentCnstEnumPrntOutpEncoder())
      .AddEncoder<ItestCnstFieldDmnDualObject>(r => new testCnstFieldDmnDualEncoder(r))
      .AddEncoder<ItestDomCnstFieldDmnDual>(_ => new testDomCnstFieldDmnDualEncoder())
      .AddEncoder<ItestDomCnstFieldDmnInp>(_ => new testDomCnstFieldDmnInpEncoder())
      .AddEncoder<ItestCnstFieldDmnOutpObject>(r => new testCnstFieldDmnOutpEncoder(r))
      .AddEncoder<ItestDomCnstFieldDmnOutp>(_ => new testDomCnstFieldDmnOutpEncoder())
      .AddEncoder<ItestCnstFieldDualDualObject>(r => new testCnstFieldDualDualEncoder(r))
      .AddEncoder<ItestPrntCnstFieldDualDualObject>(_ => new testPrntCnstFieldDualDualEncoder())
      .AddEncoder<ItestAltCnstFieldDualDualObject>(r => new testAltCnstFieldDualDualEncoder(r))
      .AddEncoder<ItestPrntCnstFieldDualInpObject>(_ => new testPrntCnstFieldDualInpEncoder())
      .AddEncoder<ItestCnstFieldDualOutpObject>(r => new testCnstFieldDualOutpEncoder(r))
      .AddEncoder<ItestPrntCnstFieldDualOutpObject>(_ => new testPrntCnstFieldDualOutpEncoder())
      .AddEncoder<ItestAltCnstFieldDualOutpObject>(r => new testAltCnstFieldDualOutpEncoder(r))
      .AddEncoder<ItestCnstFieldObjDualObject>(r => new testCnstFieldObjDualEncoder(r))
      .AddEncoder<ItestPrntCnstFieldObjDualObject>(_ => new testPrntCnstFieldObjDualEncoder())
      .AddEncoder<ItestAltCnstFieldObjDualObject>(r => new testAltCnstFieldObjDualEncoder(r))
      .AddEncoder<ItestCnstFieldObjOutpObject>(r => new testCnstFieldObjOutpEncoder(r))
      .AddEncoder<ItestPrntCnstFieldObjOutpObject>(_ => new testPrntCnstFieldObjOutpEncoder())
      .AddEncoder<ItestAltCnstFieldObjOutpObject>(r => new testAltCnstFieldObjOutpEncoder(r))
      .AddEncoder<ItestCnstPrntDualGrndDualObject>(r => new testCnstPrntDualGrndDualEncoder(r))
      .AddEncoder<ItestGrndCnstPrntDualGrndDualObject>(_ => new testGrndCnstPrntDualGrndDualEncoder())
      .AddEncoder<ItestPrntCnstPrntDualGrndDualObject>(r => new testPrntCnstPrntDualGrndDualEncoder(r))
      .AddEncoder<ItestAltCnstPrntDualGrndDualObject>(r => new testAltCnstPrntDualGrndDualEncoder(r))
      .AddEncoder<ItestGrndCnstPrntDualGrndInpObject>(_ => new testGrndCnstPrntDualGrndInpEncoder())
      .AddEncoder<ItestPrntCnstPrntDualGrndInpObject>(r => new testPrntCnstPrntDualGrndInpEncoder(r))
      .AddEncoder<ItestCnstPrntDualGrndOutpObject>(r => new testCnstPrntDualGrndOutpEncoder(r))
      .AddEncoder<ItestGrndCnstPrntDualGrndOutpObject>(_ => new testGrndCnstPrntDualGrndOutpEncoder())
      .AddEncoder<ItestPrntCnstPrntDualGrndOutpObject>(r => new testPrntCnstPrntDualGrndOutpEncoder(r))
      .AddEncoder<ItestAltCnstPrntDualGrndOutpObject>(r => new testAltCnstPrntDualGrndOutpEncoder(r))
      .AddEncoder<ItestCnstPrntDualPrntDualObject>(r => new testCnstPrntDualPrntDualEncoder(r))
      .AddEncoder<ItestPrntCnstPrntDualPrntDualObject>(_ => new testPrntCnstPrntDualPrntDualEncoder())
      .AddEncoder<ItestAltCnstPrntDualPrntDualObject>(r => new testAltCnstPrntDualPrntDualEncoder(r))
      .AddEncoder<ItestPrntCnstPrntDualPrntInpObject>(_ => new testPrntCnstPrntDualPrntInpEncoder())
      .AddEncoder<ItestCnstPrntDualPrntOutpObject>(r => new testCnstPrntDualPrntOutpEncoder(r))
      .AddEncoder<ItestPrntCnstPrntDualPrntOutpObject>(_ => new testPrntCnstPrntDualPrntOutpEncoder())
      .AddEncoder<ItestAltCnstPrntDualPrntOutpObject>(r => new testAltCnstPrntDualPrntOutpEncoder(r))
      .AddEncoder<ItestCnstPrntEnumDualObject>(_ => new testCnstPrntEnumDualEncoder())
      .AddEncoder<testEnumCnstPrntEnumDual>(_ => new testEnumCnstPrntEnumDualEncoder())
      .AddEncoder<testParentCnstPrntEnumDual>(_ => new testParentCnstPrntEnumDualEncoder())
      .AddEncoder<testEnumCnstPrntEnumInp>(_ => new testEnumCnstPrntEnumInpEncoder())
      .AddEncoder<testParentCnstPrntEnumInp>(_ => new testParentCnstPrntEnumInpEncoder())
      .AddEncoder<ItestCnstPrntEnumOutpObject>(_ => new testCnstPrntEnumOutpEncoder())
      .AddEncoder<testEnumCnstPrntEnumOutp>(_ => new testEnumCnstPrntEnumOutpEncoder())
      .AddEncoder<testParentCnstPrntEnumOutp>(_ => new testParentCnstPrntEnumOutpEncoder())
      .AddEncoder<ItestCnstPrntObjPrntDualObject>(r => new testCnstPrntObjPrntDualEncoder(r))
      .AddEncoder<ItestPrntCnstPrntObjPrntDualObject>(_ => new testPrntCnstPrntObjPrntDualEncoder())
      .AddEncoder<ItestAltCnstPrntObjPrntDualObject>(r => new testAltCnstPrntObjPrntDualEncoder(r))
      .AddEncoder<ItestCnstPrntObjPrntOutpObject>(r => new testCnstPrntObjPrntOutpEncoder(r))
      .AddEncoder<ItestPrntCnstPrntObjPrntOutpObject>(_ => new testPrntCnstPrntObjPrntOutpEncoder())
      .AddEncoder<ItestAltCnstPrntObjPrntOutpObject>(r => new testAltCnstPrntObjPrntOutpEncoder(r))
      .AddEncoder<ItestFieldDualObject>(_ => new testFieldDualEncoder())
      .AddEncoder<ItestFieldOutpObject>(_ => new testFieldOutpEncoder())
      .AddEncoder<ItestFieldDescrDualObject>(_ => new testFieldDescrDualEncoder())
      .AddEncoder<ItestFieldDescrOutpObject>(_ => new testFieldDescrOutpEncoder())
      .AddEncoder<ItestFieldDualDualObject>(r => new testFieldDualDualEncoder(r))
      .AddEncoder<ItestFldFieldDualDualObject>(_ => new testFldFieldDualDualEncoder())
      .AddEncoder<ItestFldFieldDualInpObject>(_ => new testFldFieldDualInpEncoder())
      .AddEncoder<ItestFieldDualOutpObject>(r => new testFieldDualOutpEncoder(r))
      .AddEncoder<ItestFldFieldDualOutpObject>(_ => new testFldFieldDualOutpEncoder())
      .AddEncoder<ItestFieldEnumDualObject>(_ => new testFieldEnumDualEncoder())
      .AddEncoder<testEnumFieldEnumDual>(_ => new testEnumFieldEnumDualEncoder())
      .AddEncoder<testEnumFieldEnumInp>(_ => new testEnumFieldEnumInpEncoder())
      .AddEncoder<ItestFieldEnumOutpObject>(_ => new testFieldEnumOutpEncoder())
      .AddEncoder<testEnumFieldEnumOutp>(_ => new testEnumFieldEnumOutpEncoder())
      .AddEncoder<ItestFieldEnumPrntDualObject>(_ => new testFieldEnumPrntDualEncoder())
      .AddEncoder<testEnumFieldEnumPrntDual>(_ => new testEnumFieldEnumPrntDualEncoder())
      .AddEncoder<testPrntFieldEnumPrntDual>(_ => new testPrntFieldEnumPrntDualEncoder())
      .AddEncoder<testEnumFieldEnumPrntInp>(_ => new testEnumFieldEnumPrntInpEncoder())
      .AddEncoder<testPrntFieldEnumPrntInp>(_ => new testPrntFieldEnumPrntInpEncoder())
      .AddEncoder<ItestFieldEnumPrntOutpObject>(_ => new testFieldEnumPrntOutpEncoder())
      .AddEncoder<testEnumFieldEnumPrntOutp>(_ => new testEnumFieldEnumPrntOutpEncoder())
      .AddEncoder<testPrntFieldEnumPrntOutp>(_ => new testPrntFieldEnumPrntOutpEncoder())
      .AddEncoder<ItestFieldModEnumDualObject>(_ => new testFieldModEnumDualEncoder())
      .AddEncoder<testEnumFieldModEnumDual>(_ => new testEnumFieldModEnumDualEncoder())
      .AddEncoder<testEnumFieldModEnumInp>(_ => new testEnumFieldModEnumInpEncoder())
      .AddEncoder<ItestFieldModEnumOutpObject>(_ => new testFieldModEnumOutpEncoder())
      .AddEncoder<testEnumFieldModEnumOutp>(_ => new testEnumFieldModEnumOutpEncoder())
      .AddEncoder<ItestFldFieldModParamDualObject>(_ => new testFldFieldModParamDualEncoder())
      .AddEncoder<ItestFldFieldModParamOutpObject>(_ => new testFldFieldModParamOutpEncoder())
      .AddEncoder<ItestFieldObjDualObject>(r => new testFieldObjDualEncoder(r))
      .AddEncoder<ItestFldFieldObjDualObject>(_ => new testFldFieldObjDualEncoder())
      .AddEncoder<ItestFieldObjOutpObject>(r => new testFieldObjOutpEncoder(r))
      .AddEncoder<ItestFldFieldObjOutpObject>(_ => new testFldFieldObjOutpEncoder())
      .AddEncoder<ItestFieldSmplDualObject>(_ => new testFieldSmplDualEncoder())
      .AddEncoder<ItestFieldSmplOutpObject>(_ => new testFieldSmplOutpEncoder())
      .AddEncoder<ItestFieldTypeDescrDualObject>(_ => new testFieldTypeDescrDualEncoder())
      .AddEncoder<ItestFieldTypeDescrOutpObject>(_ => new testFieldTypeDescrOutpEncoder())
      .AddEncoder<ItestFieldValueDualObject>(_ => new testFieldValueDualEncoder())
      .AddEncoder<testEnumFieldValueDual>(_ => new testEnumFieldValueDualEncoder())
      .AddEncoder<testEnumFieldValueInp>(_ => new testEnumFieldValueInpEncoder())
      .AddEncoder<ItestFieldValueOutpObject>(_ => new testFieldValueOutpEncoder())
      .AddEncoder<testEnumFieldValueOutp>(_ => new testEnumFieldValueOutpEncoder())
      .AddEncoder<ItestFieldValueDescrDualObject>(_ => new testFieldValueDescrDualEncoder())
      .AddEncoder<testEnumFieldValueDescrDual>(_ => new testEnumFieldValueDescrDualEncoder())
      .AddEncoder<testEnumFieldValueDescrInp>(_ => new testEnumFieldValueDescrInpEncoder())
      .AddEncoder<ItestFieldValueDescrOutpObject>(_ => new testFieldValueDescrOutpEncoder())
      .AddEncoder<testEnumFieldValueDescrOutp>(_ => new testEnumFieldValueDescrOutpEncoder())
      .AddEncoder<ItestGnrcAltDualDualObject>(_ => new testGnrcAltDualDualEncoder())
      .AddEncoder<ItestAltGnrcAltDualDualObject>(_ => new testAltGnrcAltDualDualEncoder())
      .AddEncoder<ItestAltGnrcAltDualInpObject>(_ => new testAltGnrcAltDualInpEncoder())
      .AddEncoder<ItestGnrcAltDualOutpObject>(_ => new testGnrcAltDualOutpEncoder())
      .AddEncoder<ItestAltGnrcAltDualOutpObject>(_ => new testAltGnrcAltDualOutpEncoder())
      .AddEncoder<ItestGnrcAltParamDualObject>(_ => new testGnrcAltParamDualEncoder())
      .AddEncoder<ItestAltGnrcAltParamDualObject>(_ => new testAltGnrcAltParamDualEncoder())
      .AddEncoder<ItestGnrcAltParamOutpObject>(_ => new testGnrcAltParamOutpEncoder())
      .AddEncoder<ItestAltGnrcAltParamOutpObject>(_ => new testAltGnrcAltParamOutpEncoder())
      .AddEncoder<ItestGnrcAltSmplDualObject>(_ => new testGnrcAltSmplDualEncoder())
      .AddEncoder<ItestGnrcAltSmplOutpObject>(_ => new testGnrcAltSmplOutpEncoder())
      .AddEncoder<ItestGnrcEnumDualObject>(_ => new testGnrcEnumDualEncoder())
      .AddEncoder<testEnumGnrcEnumDual>(_ => new testEnumGnrcEnumDualEncoder())
      .AddEncoder<testEnumGnrcEnumInp>(_ => new testEnumGnrcEnumInpEncoder())
      .AddEncoder<ItestGnrcEnumOutpObject>(_ => new testGnrcEnumOutpEncoder())
      .AddEncoder<testEnumGnrcEnumOutp>(_ => new testEnumGnrcEnumOutpEncoder())
      .AddEncoder<ItestGnrcFieldDualDualObject>(r => new testGnrcFieldDualDualEncoder(r))
      .AddEncoder<ItestAltGnrcFieldDualDualObject>(_ => new testAltGnrcFieldDualDualEncoder())
      .AddEncoder<ItestAltGnrcFieldDualInpObject>(_ => new testAltGnrcFieldDualInpEncoder())
      .AddEncoder<ItestGnrcFieldDualOutpObject>(r => new testGnrcFieldDualOutpEncoder(r))
      .AddEncoder<ItestAltGnrcFieldDualOutpObject>(_ => new testAltGnrcFieldDualOutpEncoder())
      .AddEncoder<ItestGnrcFieldParamDualObject>(r => new testGnrcFieldParamDualEncoder(r))
      .AddEncoder<ItestAltGnrcFieldParamDualObject>(_ => new testAltGnrcFieldParamDualEncoder())
      .AddEncoder<ItestGnrcFieldParamOutpObject>(r => new testGnrcFieldParamOutpEncoder(r))
      .AddEncoder<ItestAltGnrcFieldParamOutpObject>(_ => new testAltGnrcFieldParamOutpEncoder())
      .AddEncoder<ItestGnrcPrntDualDualObject>(r => new testGnrcPrntDualDualEncoder(r))
      .AddEncoder<ItestAltGnrcPrntDualDualObject>(_ => new testAltGnrcPrntDualDualEncoder())
      .AddEncoder<ItestAltGnrcPrntDualInpObject>(_ => new testAltGnrcPrntDualInpEncoder())
      .AddEncoder<ItestGnrcPrntDualOutpObject>(r => new testGnrcPrntDualOutpEncoder(r))
      .AddEncoder<ItestAltGnrcPrntDualOutpObject>(_ => new testAltGnrcPrntDualOutpEncoder())
      .AddEncoder<ItestGnrcPrntDualPrntDualObject>(r => new testGnrcPrntDualPrntDualEncoder(r))
      .AddEncoder<ItestAltGnrcPrntDualPrntDualObject>(_ => new testAltGnrcPrntDualPrntDualEncoder())
      .AddEncoder<ItestAltGnrcPrntDualPrntInpObject>(_ => new testAltGnrcPrntDualPrntInpEncoder())
      .AddEncoder<ItestGnrcPrntDualPrntOutpObject>(r => new testGnrcPrntDualPrntOutpEncoder(r))
      .AddEncoder<ItestAltGnrcPrntDualPrntOutpObject>(_ => new testAltGnrcPrntDualPrntOutpEncoder())
      .AddEncoder<ItestGnrcPrntEnumChildDualObject>(r => new testGnrcPrntEnumChildDualEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumChildDual>(_ => new testEnumGnrcPrntEnumChildDualEncoder())
      .AddEncoder<testParentGnrcPrntEnumChildDual>(_ => new testParentGnrcPrntEnumChildDualEncoder())
      .AddEncoder<testEnumGnrcPrntEnumChildInp>(_ => new testEnumGnrcPrntEnumChildInpEncoder())
      .AddEncoder<testParentGnrcPrntEnumChildInp>(_ => new testParentGnrcPrntEnumChildInpEncoder())
      .AddEncoder<ItestGnrcPrntEnumChildOutpObject>(r => new testGnrcPrntEnumChildOutpEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumChildOutp>(_ => new testEnumGnrcPrntEnumChildOutpEncoder())
      .AddEncoder<testParentGnrcPrntEnumChildOutp>(_ => new testParentGnrcPrntEnumChildOutpEncoder())
      .AddEncoder<ItestGnrcPrntEnumDomDualObject>(r => new testGnrcPrntEnumDomDualEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumDomDual>(_ => new testEnumGnrcPrntEnumDomDualEncoder())
      .AddEncoder<ItestDomGnrcPrntEnumDomDual>(_ => new testDomGnrcPrntEnumDomDualEncoder())
      .AddEncoder<testEnumGnrcPrntEnumDomInp>(_ => new testEnumGnrcPrntEnumDomInpEncoder())
      .AddEncoder<ItestDomGnrcPrntEnumDomInp>(_ => new testDomGnrcPrntEnumDomInpEncoder())
      .AddEncoder<ItestGnrcPrntEnumDomOutpObject>(r => new testGnrcPrntEnumDomOutpEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumDomOutp>(_ => new testEnumGnrcPrntEnumDomOutpEncoder())
      .AddEncoder<ItestDomGnrcPrntEnumDomOutp>(_ => new testDomGnrcPrntEnumDomOutpEncoder())
      .AddEncoder<ItestGnrcPrntEnumPrntDualObject>(r => new testGnrcPrntEnumPrntDualEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumPrntDual>(_ => new testEnumGnrcPrntEnumPrntDualEncoder())
      .AddEncoder<testParentGnrcPrntEnumPrntDual>(_ => new testParentGnrcPrntEnumPrntDualEncoder())
      .AddEncoder<testEnumGnrcPrntEnumPrntInp>(_ => new testEnumGnrcPrntEnumPrntInpEncoder())
      .AddEncoder<testParentGnrcPrntEnumPrntInp>(_ => new testParentGnrcPrntEnumPrntInpEncoder())
      .AddEncoder<ItestGnrcPrntEnumPrntOutpObject>(r => new testGnrcPrntEnumPrntOutpEncoder(r))
      .AddEncoder<testEnumGnrcPrntEnumPrntOutp>(_ => new testEnumGnrcPrntEnumPrntOutpEncoder())
      .AddEncoder<testParentGnrcPrntEnumPrntOutp>(_ => new testParentGnrcPrntEnumPrntOutpEncoder())
      .AddEncoder<ItestGnrcPrntParamDualObject>(r => new testGnrcPrntParamDualEncoder(r))
      .AddEncoder<ItestAltGnrcPrntParamDualObject>(_ => new testAltGnrcPrntParamDualEncoder())
      .AddEncoder<ItestGnrcPrntParamOutpObject>(r => new testGnrcPrntParamOutpEncoder(r))
      .AddEncoder<ItestAltGnrcPrntParamOutpObject>(_ => new testAltGnrcPrntParamOutpEncoder())
      .AddEncoder<ItestGnrcPrntParamPrntDualObject>(r => new testGnrcPrntParamPrntDualEncoder(r))
      .AddEncoder<ItestAltGnrcPrntParamPrntDualObject>(_ => new testAltGnrcPrntParamPrntDualEncoder())
      .AddEncoder<ItestGnrcPrntParamPrntOutpObject>(r => new testGnrcPrntParamPrntOutpEncoder(r))
      .AddEncoder<ItestAltGnrcPrntParamPrntOutpObject>(_ => new testAltGnrcPrntParamPrntOutpEncoder())
      .AddEncoder<ItestGnrcPrntSmplEnumDualObject>(r => new testGnrcPrntSmplEnumDualEncoder(r))
      .AddEncoder<testEnumGnrcPrntSmplEnumDual>(_ => new testEnumGnrcPrntSmplEnumDualEncoder())
      .AddEncoder<testEnumGnrcPrntSmplEnumInp>(_ => new testEnumGnrcPrntSmplEnumInpEncoder())
      .AddEncoder<ItestGnrcPrntSmplEnumOutpObject>(r => new testGnrcPrntSmplEnumOutpEncoder(r))
      .AddEncoder<testEnumGnrcPrntSmplEnumOutp>(_ => new testEnumGnrcPrntSmplEnumOutpEncoder())
      .AddEncoder<ItestGnrcPrntStrDomDualObject>(r => new testGnrcPrntStrDomDualEncoder(r))
      .AddEncoder<ItestDomGnrcPrntStrDomDual>(_ => new testDomGnrcPrntStrDomDualEncoder())
      .AddEncoder<ItestDomGnrcPrntStrDomInp>(_ => new testDomGnrcPrntStrDomInpEncoder())
      .AddEncoder<ItestGnrcPrntStrDomOutpObject>(r => new testGnrcPrntStrDomOutpEncoder(r))
      .AddEncoder<ItestDomGnrcPrntStrDomOutp>(_ => new testDomGnrcPrntStrDomOutpEncoder())
      .AddEncoder<ItestGnrcValueDualObject>(_ => new testGnrcValueDualEncoder())
      .AddEncoder<testEnumGnrcValueDual>(_ => new testEnumGnrcValueDualEncoder())
      .AddEncoder<testEnumGnrcValueInp>(_ => new testEnumGnrcValueInpEncoder())
      .AddEncoder<ItestGnrcValueOutpObject>(_ => new testGnrcValueOutpEncoder())
      .AddEncoder<testEnumGnrcValueOutp>(_ => new testEnumGnrcValueOutpEncoder())
      .AddEncoder<testEnumInpFieldEnum>(_ => new testEnumInpFieldEnumEncoder())
      .AddEncoder<ItestFldInpFieldNullObject>(_ => new testFldInpFieldNullEncoder())
      .AddEncoder<ItestOutpDescrParamObject>(r => new testOutpDescrParamEncoder(r))
      .AddEncoder<ItestFldOutpDescrParamObject>(_ => new testFldOutpDescrParamEncoder())
      .AddEncoder<ItestOutpParamObject>(r => new testOutpParamEncoder(r))
      .AddEncoder<ItestFldOutpParamObject>(_ => new testFldOutpParamEncoder())
      .AddEncoder<ItestOutpParamDescrObject>(r => new testOutpParamDescrEncoder(r))
      .AddEncoder<ItestFldOutpParamDescrObject>(_ => new testFldOutpParamDescrEncoder())
      .AddEncoder<ItestOutpParamModDmnObject>(r => new testOutpParamModDmnEncoder(r))
      .AddEncoder<ItestDomOutpParamModDmn>(_ => new testDomOutpParamModDmnEncoder())
      .AddEncoder<ItestDomOutpParamModParam>(_ => new testDomOutpParamModParamEncoder())
      .AddEncoder<ItestOutpParamTypeDescrObject>(r => new testOutpParamTypeDescrEncoder(r))
      .AddEncoder<ItestFldOutpParamTypeDescrObject>(_ => new testFldOutpParamTypeDescrEncoder())
      .AddEncoder<ItestOutpPrntGnrcObject>(_ => new testOutpPrntGnrcEncoder())
      .AddEncoder<testEnumOutpPrntGnrc>(_ => new testEnumOutpPrntGnrcEncoder())
      .AddEncoder<testPrntOutpPrntGnrc>(_ => new testPrntOutpPrntGnrcEncoder())
      .AddEncoder<ItestOutpPrntParamObject>(r => new testOutpPrntParamEncoder(r))
      .AddEncoder<ItestPrntOutpPrntParamObject>(r => new testPrntOutpPrntParamEncoder(r))
      .AddEncoder<ItestFldOutpPrntParamObject>(_ => new testFldOutpPrntParamEncoder())
      .AddEncoder<ItestPrntDualObject>(r => new testPrntDualEncoder(r))
      .AddEncoder<ItestRefPrntDualObject>(_ => new testRefPrntDualEncoder())
      .AddEncoder<ItestPrntOutpObject>(r => new testPrntOutpEncoder(r))
      .AddEncoder<ItestRefPrntOutpObject>(_ => new testRefPrntOutpEncoder())
      .AddEncoder<ItestPrntAltDualObject>(r => new testPrntAltDualEncoder(r))
      .AddEncoder<ItestRefPrntAltDualObject>(_ => new testRefPrntAltDualEncoder())
      .AddEncoder<ItestPrntAltOutpObject>(r => new testPrntAltOutpEncoder(r))
      .AddEncoder<ItestRefPrntAltOutpObject>(_ => new testRefPrntAltOutpEncoder())
      .AddEncoder<ItestPrntDescrDualObject>(r => new testPrntDescrDualEncoder(r))
      .AddEncoder<ItestRefPrntDescrDualObject>(_ => new testRefPrntDescrDualEncoder())
      .AddEncoder<ItestPrntDescrOutpObject>(r => new testPrntDescrOutpEncoder(r))
      .AddEncoder<ItestRefPrntDescrOutpObject>(_ => new testRefPrntDescrOutpEncoder())
      .AddEncoder<ItestPrntDualDualObject>(r => new testPrntDualDualEncoder(r))
      .AddEncoder<ItestRefPrntDualDualObject>(_ => new testRefPrntDualDualEncoder())
      .AddEncoder<ItestRefPrntDualInpObject>(_ => new testRefPrntDualInpEncoder())
      .AddEncoder<ItestPrntDualOutpObject>(r => new testPrntDualOutpEncoder(r))
      .AddEncoder<ItestRefPrntDualOutpObject>(_ => new testRefPrntDualOutpEncoder())
      .AddEncoder<ItestPrntFieldDualObject>(r => new testPrntFieldDualEncoder(r))
      .AddEncoder<ItestRefPrntFieldDualObject>(_ => new testRefPrntFieldDualEncoder())
      .AddEncoder<ItestPrntFieldOutpObject>(r => new testPrntFieldOutpEncoder(r))
      .AddEncoder<ItestRefPrntFieldOutpObject>(_ => new testRefPrntFieldOutpEncoder())
      .AddEncoder<ItestCtgrObject>(_ => new testCtgrEncoder())
      .AddEncoder<ItestCtgrAliasObject>(_ => new testCtgrAliasEncoder())
      .AddEncoder<ItestCtgrDescrObject>(_ => new testCtgrDescrEncoder())
      .AddEncoder<ItestCtgrModObject>(_ => new testCtgrModEncoder())
      .AddEncoder<ItestDmnAlias>(_ => new testDmnAliasEncoder())
      .AddEncoder<ItestDmnBool>(_ => new testDmnBoolEncoder())
      .AddEncoder<ItestDmnBoolDiff>(_ => new testDmnBoolDiffEncoder())
      .AddEncoder<ItestDmnBoolSame>(_ => new testDmnBoolSameEncoder())
      .AddEncoder<ItestDmnEnumDiff>(_ => new testDmnEnumDiffEncoder())
      .AddEncoder<ItestDmnEnumSame>(_ => new testDmnEnumSameEncoder())
      .AddEncoder<ItestDmnNmbr>(_ => new testDmnNmbrEncoder())
      .AddEncoder<ItestDmnNmbrDiff>(_ => new testDmnNmbrDiffEncoder())
      .AddEncoder<ItestDmnNmbrSame>(_ => new testDmnNmbrSameEncoder())
      .AddEncoder<ItestDmnStr>(_ => new testDmnStrEncoder())
      .AddEncoder<ItestDmnStrDiff>(_ => new testDmnStrDiffEncoder())
      .AddEncoder<ItestDmnStrSame>(_ => new testDmnStrSameEncoder())
      .AddEncoder<testEnumAlias>(_ => new testEnumAliasEncoder())
      .AddEncoder<testEnumDiff>(_ => new testEnumDiffEncoder())
      .AddEncoder<testEnumSame>(_ => new testEnumSameEncoder())
      .AddEncoder<testEnumSamePrnt>(_ => new testEnumSamePrntEncoder())
      .AddEncoder<testPrntEnumSamePrnt>(_ => new testPrntEnumSamePrntEncoder())
      .AddEncoder<testEnumValueAlias>(_ => new testEnumValueAliasEncoder())
      .AddEncoder<ItestObjDualObject>(_ => new testObjDualEncoder())
      .AddEncoder<ItestObjOutpObject>(_ => new testObjOutpEncoder())
      .AddEncoder<ItestObjAliasDualObject>(_ => new testObjAliasDualEncoder())
      .AddEncoder<ItestObjAliasOutpObject>(_ => new testObjAliasOutpEncoder())
      .AddEncoder<ItestObjAltDualObject>(_ => new testObjAltDualEncoder())
      .AddEncoder<ItestObjAltDualTypeObject>(_ => new testObjAltDualTypeEncoder())
      .AddEncoder<ItestObjAltOutpObject>(_ => new testObjAltOutpEncoder())
      .AddEncoder<ItestObjAltOutpTypeObject>(_ => new testObjAltOutpTypeEncoder())
      .AddEncoder<ItestObjAltEnumDualObject>(_ => new testObjAltEnumDualEncoder())
      .AddEncoder<ItestObjAltEnumOutpObject>(_ => new testObjAltEnumOutpEncoder())
      .AddEncoder<ItestObjFieldDualObject>(r => new testObjFieldDualEncoder(r))
      .AddEncoder<ItestFldObjFieldDualObject>(_ => new testFldObjFieldDualEncoder())
      .AddEncoder<ItestObjFieldOutpObject>(r => new testObjFieldOutpEncoder(r))
      .AddEncoder<ItestFldObjFieldOutpObject>(_ => new testFldObjFieldOutpEncoder())
      .AddEncoder<ItestObjFieldAliasDualObject>(r => new testObjFieldAliasDualEncoder(r))
      .AddEncoder<ItestFldObjFieldAliasDualObject>(_ => new testFldObjFieldAliasDualEncoder())
      .AddEncoder<ItestObjFieldAliasOutpObject>(r => new testObjFieldAliasOutpEncoder(r))
      .AddEncoder<ItestFldObjFieldAliasOutpObject>(_ => new testFldObjFieldAliasOutpEncoder())
      .AddEncoder<ItestObjFieldEnumAliasDualObject>(_ => new testObjFieldEnumAliasDualEncoder())
      .AddEncoder<ItestObjFieldEnumAliasOutpObject>(_ => new testObjFieldEnumAliasOutpEncoder())
      .AddEncoder<ItestObjFieldEnumValueDualObject>(_ => new testObjFieldEnumValueDualEncoder())
      .AddEncoder<ItestObjFieldEnumValueOutpObject>(_ => new testObjFieldEnumValueOutpEncoder())
      .AddEncoder<ItestObjFieldTypeAliasDualObject>(_ => new testObjFieldTypeAliasDualEncoder())
      .AddEncoder<ItestObjFieldTypeAliasOutpObject>(_ => new testObjFieldTypeAliasOutpEncoder())
      .AddEncoder<ItestObjPrntDualObject>(r => new testObjPrntDualEncoder(r))
      .AddEncoder<ItestRefObjPrntDualObject>(_ => new testRefObjPrntDualEncoder())
      .AddEncoder<ItestObjPrntOutpObject>(r => new testObjPrntOutpEncoder(r))
      .AddEncoder<ItestRefObjPrntOutpObject>(_ => new testRefObjPrntOutpEncoder())
      .AddEncoder<ItestOutpFieldParamObject>(r => new testOutpFieldParamEncoder(r))
      .AddEncoder<ItestFldOutpFieldParamObject>(_ => new testFldOutpFieldParamEncoder())
      .AddEncoder<ItestUnionAlias>(r => new testUnionAliasEncoder(r))
      .AddEncoder<ItestUnionDiff>(r => new testUnionDiffEncoder(r))
      .AddEncoder<ItestUnionSame>(r => new testUnionSameEncoder(r))
      .AddEncoder<ItestUnionSamePrnt>(r => new testUnionSamePrntEncoder(r))
      .AddEncoder<ItestPrntUnionSamePrnt>(r => new testPrntUnionSamePrntEncoder(r))
      .AddEncoder<ItestDmnBoolDescr>(_ => new testDmnBoolDescrEncoder())
      .AddEncoder<ItestDmnBoolPrnt>(_ => new testDmnBoolPrntEncoder())
      .AddEncoder<ItestPrntDmnBoolPrnt>(_ => new testPrntDmnBoolPrntEncoder())
      .AddEncoder<ItestDmnBoolPrntDescr>(_ => new testDmnBoolPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnBoolPrntDescr>(_ => new testPrntDmnBoolPrntDescrEncoder())
      .AddEncoder<ItestDmnEnumAll>(_ => new testDmnEnumAllEncoder())
      .AddEncoder<testEnumDmnEnumAll>(_ => new testEnumDmnEnumAllEncoder())
      .AddEncoder<ItestDmnEnumAllDescr>(_ => new testDmnEnumAllDescrEncoder())
      .AddEncoder<testEnumDmnEnumAllDescr>(_ => new testEnumDmnEnumAllDescrEncoder())
      .AddEncoder<ItestDmnEnumAllPrnt>(_ => new testDmnEnumAllPrntEncoder())
      .AddEncoder<testEnumDmnEnumAllPrnt>(_ => new testEnumDmnEnumAllPrntEncoder())
      .AddEncoder<testPrntDmnEnumAllPrnt>(_ => new testPrntDmnEnumAllPrntEncoder())
      .AddEncoder<ItestDmnEnumDescr>(_ => new testDmnEnumDescrEncoder())
      .AddEncoder<testEnumDmnEnumDescr>(_ => new testEnumDmnEnumDescrEncoder())
      .AddEncoder<ItestDmnEnumExcl>(_ => new testDmnEnumExclEncoder())
      .AddEncoder<testEnumDmnEnumExcl>(_ => new testEnumDmnEnumExclEncoder())
      .AddEncoder<ItestDmnEnumExclPrnt>(_ => new testDmnEnumExclPrntEncoder())
      .AddEncoder<testEnumDmnEnumExclPrnt>(_ => new testEnumDmnEnumExclPrntEncoder())
      .AddEncoder<testPrntDmnEnumExclPrnt>(_ => new testPrntDmnEnumExclPrntEncoder())
      .AddEncoder<ItestDmnEnumLabel>(_ => new testDmnEnumLabelEncoder())
      .AddEncoder<testEnumDmnEnumLabel>(_ => new testEnumDmnEnumLabelEncoder())
      .AddEncoder<ItestDmnEnumPrnt>(_ => new testDmnEnumPrntEncoder())
      .AddEncoder<ItestPrntDmnEnumPrnt>(_ => new testPrntDmnEnumPrntEncoder())
      .AddEncoder<testEnumDmnEnumPrnt>(_ => new testEnumDmnEnumPrntEncoder())
      .AddEncoder<ItestDmnEnumPrntDescr>(_ => new testDmnEnumPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnEnumPrntDescr>(_ => new testPrntDmnEnumPrntDescrEncoder())
      .AddEncoder<testEnumDmnEnumPrntDescr>(_ => new testEnumDmnEnumPrntDescrEncoder())
      .AddEncoder<ItestDmnEnumUnq>(_ => new testDmnEnumUnqEncoder())
      .AddEncoder<testEnumDmnEnumUnq>(_ => new testEnumDmnEnumUnqEncoder())
      .AddEncoder<testDupDmnEnumUnq>(_ => new testDupDmnEnumUnqEncoder())
      .AddEncoder<ItestDmnEnumUnqPrnt>(_ => new testDmnEnumUnqPrntEncoder())
      .AddEncoder<testEnumDmnEnumUnqPrnt>(_ => new testEnumDmnEnumUnqPrntEncoder())
      .AddEncoder<testPrntDmnEnumUnqPrnt>(_ => new testPrntDmnEnumUnqPrntEncoder())
      .AddEncoder<testDupDmnEnumUnqPrnt>(_ => new testDupDmnEnumUnqPrntEncoder())
      .AddEncoder<ItestDmnEnumValue>(_ => new testDmnEnumValueEncoder())
      .AddEncoder<testEnumDmnEnumValue>(_ => new testEnumDmnEnumValueEncoder())
      .AddEncoder<ItestDmnEnumValuePrnt>(_ => new testDmnEnumValuePrntEncoder())
      .AddEncoder<testEnumDmnEnumValuePrnt>(_ => new testEnumDmnEnumValuePrntEncoder())
      .AddEncoder<testPrntDmnEnumValuePrnt>(_ => new testPrntDmnEnumValuePrntEncoder())
      .AddEncoder<ItestDmnNmbrDescr>(_ => new testDmnNmbrDescrEncoder())
      .AddEncoder<ItestDmnNmbrPrnt>(_ => new testDmnNmbrPrntEncoder())
      .AddEncoder<ItestPrntDmnNmbrPrnt>(_ => new testPrntDmnNmbrPrntEncoder())
      .AddEncoder<ItestDmnNmbrPrntDescr>(_ => new testDmnNmbrPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnNmbrPrntDescr>(_ => new testPrntDmnNmbrPrntDescrEncoder())
      .AddEncoder<ItestDmnNmbrPstv>(_ => new testDmnNmbrPstvEncoder())
      .AddEncoder<ItestDmnNmbrRange>(_ => new testDmnNmbrRangeEncoder())
      .AddEncoder<ItestDmnStrDescr>(_ => new testDmnStrDescrEncoder())
      .AddEncoder<ItestDmnStrNonEmpty>(_ => new testDmnStrNonEmptyEncoder())
      .AddEncoder<ItestDmnStrPrnt>(_ => new testDmnStrPrntEncoder())
      .AddEncoder<ItestPrntDmnStrPrnt>(_ => new testPrntDmnStrPrntEncoder())
      .AddEncoder<ItestDmnStrPrntDescr>(_ => new testDmnStrPrntDescrEncoder())
      .AddEncoder<ItestPrntDmnStrPrntDescr>(_ => new testPrntDmnStrPrntDescrEncoder())
      .AddEncoder<testEnumDescr>(_ => new testEnumDescrEncoder())
      .AddEncoder<testEnumPrnt>(_ => new testEnumPrntEncoder())
      .AddEncoder<testPrntEnumPrnt>(_ => new testPrntEnumPrntEncoder())
      .AddEncoder<testEnumPrntAlias>(_ => new testEnumPrntAliasEncoder())
      .AddEncoder<testPrntEnumPrntAlias>(_ => new testPrntEnumPrntAliasEncoder())
      .AddEncoder<testEnumPrntDescr>(_ => new testEnumPrntDescrEncoder())
      .AddEncoder<testPrntEnumPrntDescr>(_ => new testPrntEnumPrntDescrEncoder())
      .AddEncoder<testEnumPrntDup>(_ => new testEnumPrntDupEncoder())
      .AddEncoder<testPrntEnumPrntDup>(_ => new testPrntEnumPrntDupEncoder())
      .AddEncoder<ItestUnionDescr>(r => new testUnionDescrEncoder(r))
      .AddEncoder<ItestUnionPrnt>(r => new testUnionPrntEncoder(r))
      .AddEncoder<ItestPrntUnionPrnt>(r => new testPrntUnionPrntEncoder(r))
      .AddEncoder<ItestUnionPrntDescr>(r => new testUnionPrntDescrEncoder(r))
      .AddEncoder<ItestPrntUnionPrntDescr>(r => new testPrntUnionPrntDescrEncoder(r))
      .AddEncoder<ItestUnionPrntDup>(r => new testUnionPrntDupEncoder(r))
      .AddEncoder<ItestPrntUnionPrntDup>(r => new testPrntUnionPrntDupEncoder(r));
}
