//HintName: test_+Objects_Enc.gen.cs
// Generated from {CurrentDirectory}+Objects.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Objects;

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

internal class testAltInpEncoder : IEncoder<ItestAltInpObject>
{
  public Structured Encode(ItestAltInpObject input)
    => Structured.Empty();
}

internal class testAltAltInpEncoder : IEncoder<ItestAltAltInpObject>
{
  public Structured Encode(ItestAltAltInpObject input)
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

internal class testAltDescrInpEncoder : IEncoder<ItestAltDescrInpObject>
{
  public Structured Encode(ItestAltDescrInpObject input)
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

internal class testAltDualInpEncoder : IEncoder<ItestAltDualInpObject>
{
  public Structured Encode(ItestAltDualInpObject input)
    => Structured.Empty();
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

internal class testAltEnumInpEncoder : IEncoder<ItestAltEnumInpObject>
{
  public Structured Encode(ItestAltEnumInpObject input)
    => Structured.Empty();
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

internal class testAltModBoolInpEncoder : IEncoder<ItestAltModBoolInpObject>
{
  public Structured Encode(ItestAltModBoolInpObject input)
    => Structured.Empty();
}

internal class testAltAltModBoolInpEncoder : IEncoder<ItestAltAltModBoolInpObject>
{
  public Structured Encode(ItestAltAltModBoolInpObject input)
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

internal class testAltModParamDualEncoder : IEncoder<ItestAltModParamDualObject<TMod>>
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

internal class testAltModParamInpEncoder : IEncoder<ItestAltModParamInpObject<TMod>>
{
  public Structured Encode(ItestAltModParamInpObject<TMod> input)
    => Structured.Empty();
}

internal class testAltAltModParamInpEncoder : IEncoder<ItestAltAltModParamInpObject>
{
  public Structured Encode(ItestAltAltModParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testAltModParamOutpEncoder : IEncoder<ItestAltModParamOutpObject<TMod>>
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

internal class testAltSmplInpEncoder : IEncoder<ItestAltSmplInpObject>
{
  public Structured Encode(ItestAltSmplInpObject input)
    => Structured.Empty();
}

internal class testAltSmplOutpEncoder : IEncoder<ItestAltSmplOutpObject>
{
  public Structured Encode(ItestAltSmplOutpObject input)
    => Structured.Empty();
}

internal class testCnstAltDualEncoder : IEncoder<ItestCnstAltDualObject<TType>>
{
  public Structured Encode(ItestCnstAltDualObject<TType> input)
    => Structured.Empty();
}

internal class testCnstAltInpEncoder : IEncoder<ItestCnstAltInpObject<TType>>
{
  public Structured Encode(ItestCnstAltInpObject<TType> input)
    => Structured.Empty();
}

internal class testCnstAltOutpEncoder : IEncoder<ItestCnstAltOutpObject<TType>>
{
  public Structured Encode(ItestCnstAltOutpObject<TType> input)
    => Structured.Empty();
}

internal class testCnstAltDmnDualEncoder : IEncoder<ItestCnstAltDmnDualObject>
{
  public Structured Encode(ItestCnstAltDmnDualObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDmnDualEncoder : IEncoder<ItestRefCnstAltDmnDualObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnDualObject<TRef> input)
    => Structured.Empty();
}

internal class testDomCnstAltDmnDualEncoder : IEncoder<ItestDomCnstAltDmnDual>
{
  public Structured Encode(ItestDomCnstAltDmnDual input)
    => new(input.Value);
}

internal class testCnstAltDmnInpEncoder : IEncoder<ItestCnstAltDmnInpObject>
{
  public Structured Encode(ItestCnstAltDmnInpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDmnInpEncoder : IEncoder<ItestRefCnstAltDmnInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDmnInpObject<TRef> input)
    => Structured.Empty();
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

internal class testRefCnstAltDmnOutpEncoder : IEncoder<ItestRefCnstAltDmnOutpObject<TRef>>
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

internal class testRefCnstAltDualDualEncoder : IEncoder<ItestRefCnstAltDualDualObject<TRef>>
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

internal class testCnstAltDualInpEncoder : IEncoder<ItestCnstAltDualInpObject>
{
  public Structured Encode(ItestCnstAltDualInpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDualInpEncoder : IEncoder<ItestRefCnstAltDualInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltDualInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltDualInpEncoder : IEncoder<ItestPrntCnstAltDualInpObject>
{
  public Structured Encode(ItestPrntCnstAltDualInpObject input)
    => Structured.Empty();
}

internal class testAltCnstAltDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltDualInpObject>
{
  private readonly IEncoder<ItestPrntCnstAltDualInpObject> _itestPrntCnstAltDualInp = encoders.EncoderFor<ItestPrntCnstAltDualInpObject>();
  public Structured Encode(ItestAltCnstAltDualInpObject input)
    => _itestPrntCnstAltDualInp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstAltDualOutpEncoder : IEncoder<ItestCnstAltDualOutpObject>
{
  public Structured Encode(ItestCnstAltDualOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltDualOutpEncoder : IEncoder<ItestRefCnstAltDualOutpObject<TRef>>
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

internal class testRefCnstAltObjDualEncoder : IEncoder<ItestRefCnstAltObjDualObject<TRef>>
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

internal class testCnstAltObjInpEncoder : IEncoder<ItestCnstAltObjInpObject>
{
  public Structured Encode(ItestCnstAltObjInpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltObjInpEncoder : IEncoder<ItestRefCnstAltObjInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstAltObjInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstAltObjInpEncoder : IEncoder<ItestPrntCnstAltObjInpObject>
{
  public Structured Encode(ItestPrntCnstAltObjInpObject input)
    => Structured.Empty();
}

internal class testAltCnstAltObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstAltObjInpObject>
{
  private readonly IEncoder<ItestPrntCnstAltObjInpObject> _itestPrntCnstAltObjInp = encoders.EncoderFor<ItestPrntCnstAltObjInpObject>();
  public Structured Encode(ItestAltCnstAltObjInpObject input)
    => _itestPrntCnstAltObjInp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstAltObjOutpEncoder : IEncoder<ItestCnstAltObjOutpObject>
{
  public Structured Encode(ItestCnstAltObjOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstAltObjOutpEncoder : IEncoder<ItestRefCnstAltObjOutpObject<TRef>>
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

internal class testRefCnstDomEnumDualEncoder(
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

internal class testCnstDomEnumInpEncoder : IEncoder<ItestCnstDomEnumInpObject>
{
  public Structured Encode(ItestCnstDomEnumInpObject input)
    => Structured.Empty();
}

internal class testRefCnstDomEnumInpEncoder(
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

internal class testRefCnstDomEnumOutpEncoder(
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

internal class testRefCnstEnumDualEncoder(
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

internal class testCnstEnumInpEncoder : IEncoder<ItestCnstEnumInpObject>
{
  public Structured Encode(ItestCnstEnumInpObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumInpEncoder(
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
    => new(input.ToString(), "_EnumCnstEnumInp");
}

internal class testCnstEnumOutpEncoder : IEncoder<ItestCnstEnumOutpObject>
{
  public Structured Encode(ItestCnstEnumOutpObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumOutpEncoder(
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

internal class testRefCnstEnumPrntDualEncoder(
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

internal class testCnstEnumPrntInpEncoder : IEncoder<ItestCnstEnumPrntInpObject>
{
  public Structured Encode(ItestCnstEnumPrntInpObject input)
    => Structured.Empty();
}

internal class testRefCnstEnumPrntInpEncoder(
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

internal class testRefCnstEnumPrntOutpEncoder(
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
  private readonly IEncoder<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>> _itestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual> = encoders.EncoderFor<ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>>();
  public Structured Encode(ItestCnstFieldDmnDualObject input)
    => _itestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>.Encode(input);
}

internal class testRefCnstFieldDmnDualEncoder(
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

internal class testCnstFieldDmnInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>> _itestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp> = encoders.EncoderFor<ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>>();
  public Structured Encode(ItestCnstFieldDmnInpObject input)
    => _itestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>.Encode(input);
}

internal class testRefCnstFieldDmnInpEncoder(
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
    => new(input.Value);
}

internal class testCnstFieldDmnOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDmnOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>> _itestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp> = encoders.EncoderFor<ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>>();
  public Structured Encode(ItestCnstFieldDmnOutpObject input)
    => _itestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>.Encode(input);
}

internal class testRefCnstFieldDmnOutpEncoder(
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
  private readonly IEncoder<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>> _itestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual> = encoders.EncoderFor<ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>>();
  public Structured Encode(ItestCnstFieldDualDualObject input)
    => _itestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>.Encode(input);
}

internal class testRefCnstFieldDualDualEncoder(
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

internal class testCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>> _itestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp> = encoders.EncoderFor<ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>>();
  public Structured Encode(ItestCnstFieldDualInpObject input)
    => _itestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>.Encode(input);
}

internal class testRefCnstFieldDualInpEncoder(
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
}

internal class testAltCnstFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldDualInpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldDualInpObject> _itestPrntCnstFieldDualInp = encoders.EncoderFor<ItestPrntCnstFieldDualInpObject>();
  public Structured Encode(ItestAltCnstFieldDualInpObject input)
    => _itestPrntCnstFieldDualInp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstFieldDualOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldDualOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>> _itestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp> = encoders.EncoderFor<ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>>();
  public Structured Encode(ItestCnstFieldDualOutpObject input)
    => _itestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>.Encode(input);
}

internal class testRefCnstFieldDualOutpEncoder(
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
  private readonly IEncoder<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>> _itestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual> = encoders.EncoderFor<ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>>();
  public Structured Encode(ItestCnstFieldObjDualObject input)
    => _itestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>.Encode(input);
}

internal class testRefCnstFieldObjDualEncoder(
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

internal class testCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjInpObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>> _itestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp> = encoders.EncoderFor<ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>>();
  public Structured Encode(ItestCnstFieldObjInpObject input)
    => _itestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>.Encode(input);
}

internal class testRefCnstFieldObjInpEncoder(
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
}

internal class testAltCnstFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstFieldObjInpObject>
{
  private readonly IEncoder<ItestPrntCnstFieldObjInpObject> _itestPrntCnstFieldObjInp = encoders.EncoderFor<ItestPrntCnstFieldObjInpObject>();
  public Structured Encode(ItestAltCnstFieldObjInpObject input)
    => _itestPrntCnstFieldObjInp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstFieldObjOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstFieldObjOutpObject>
{
  private readonly IEncoder<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>> _itestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp> = encoders.EncoderFor<ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>>();
  public Structured Encode(ItestCnstFieldObjOutpObject input)
    => _itestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>.Encode(input);
}

internal class testRefCnstFieldObjOutpEncoder(
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
  private readonly IEncoder<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>> _itestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual> = encoders.EncoderFor<ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>>();
  public Structured Encode(ItestCnstPrntDualGrndDualObject input)
    => _itestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>.Encode(input);
}

internal class testRefCnstPrntDualGrndDualEncoder : IEncoder<ItestRefCnstPrntDualGrndDualObject<TRef>>
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

internal class testCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>> _itestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp> = encoders.EncoderFor<ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>>();
  public Structured Encode(ItestCnstPrntDualGrndInpObject input)
    => _itestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>.Encode(input);
}

internal class testRefCnstPrntDualGrndInpEncoder : IEncoder<ItestRefCnstPrntDualGrndInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualGrndInpObject<TRef> input)
    => Structured.Empty();
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

internal class testAltCnstPrntDualGrndInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualGrndInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualGrndInpObject> _itestPrntCnstPrntDualGrndInp = encoders.EncoderFor<ItestPrntCnstPrntDualGrndInpObject>();
  public Structured Encode(ItestAltCnstPrntDualGrndInpObject input)
    => _itestPrntCnstPrntDualGrndInp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstPrntDualGrndOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualGrndOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>> _itestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp> = encoders.EncoderFor<ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>>();
  public Structured Encode(ItestCnstPrntDualGrndOutpObject input)
    => _itestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>.Encode(input);
}

internal class testRefCnstPrntDualGrndOutpEncoder : IEncoder<ItestRefCnstPrntDualGrndOutpObject<TRef>>
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
  private readonly IEncoder<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>> _itestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual> = encoders.EncoderFor<ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>>();
  public Structured Encode(ItestCnstPrntDualPrntDualObject input)
    => _itestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>.Encode(input);
}

internal class testRefCnstPrntDualPrntDualEncoder : IEncoder<ItestRefCnstPrntDualPrntDualObject<TRef>>
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

internal class testCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>> _itestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp> = encoders.EncoderFor<ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>>();
  public Structured Encode(ItestCnstPrntDualPrntInpObject input)
    => _itestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>.Encode(input);
}

internal class testRefCnstPrntDualPrntInpEncoder : IEncoder<ItestRefCnstPrntDualPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntDualPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntDualPrntInpEncoder : IEncoder<ItestPrntCnstPrntDualPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntInpObject input)
    => Structured.Empty();
}

internal class testAltCnstPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntDualPrntInpObject> _itestPrntCnstPrntDualPrntInp = encoders.EncoderFor<ItestPrntCnstPrntDualPrntInpObject>();
  public Structured Encode(ItestAltCnstPrntDualPrntInpObject input)
    => _itestPrntCnstPrntDualPrntInp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstPrntDualPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntDualPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>> _itestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp> = encoders.EncoderFor<ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>>();
  public Structured Encode(ItestCnstPrntDualPrntOutpObject input)
    => _itestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>.Encode(input);
}

internal class testRefCnstPrntDualPrntOutpEncoder : IEncoder<ItestRefCnstPrntDualPrntOutpObject<TRef>>
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

internal class testRefCnstPrntEnumDualEncoder(
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

internal class testCnstPrntEnumInpEncoder : IEncoder<ItestCnstPrntEnumInpObject>
{
  public Structured Encode(ItestCnstPrntEnumInpObject input)
    => Structured.Empty();
}

internal class testRefCnstPrntEnumInpEncoder(
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

internal class testRefCnstPrntEnumOutpEncoder(
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
  private readonly IEncoder<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>> _itestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual> = encoders.EncoderFor<ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>>();
  public Structured Encode(ItestCnstPrntObjPrntDualObject input)
    => _itestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>.Encode(input);
}

internal class testRefCnstPrntObjPrntDualEncoder : IEncoder<ItestRefCnstPrntObjPrntDualObject<TRef>>
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

internal class testCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>> _itestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp> = encoders.EncoderFor<ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>>();
  public Structured Encode(ItestCnstPrntObjPrntInpObject input)
    => _itestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>.Encode(input);
}

internal class testRefCnstPrntObjPrntInpEncoder : IEncoder<ItestRefCnstPrntObjPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefCnstPrntObjPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testPrntCnstPrntObjPrntInpEncoder : IEncoder<ItestPrntCnstPrntObjPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntObjPrntInpObject input)
    => Structured.Empty();
}

internal class testAltCnstPrntObjPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestAltCnstPrntObjPrntInpObject>
{
  private readonly IEncoder<ItestPrntCnstPrntObjPrntInpObject> _itestPrntCnstPrntObjPrntInp = encoders.EncoderFor<ItestPrntCnstPrntObjPrntInpObject>();
  public Structured Encode(ItestAltCnstPrntObjPrntInpObject input)
    => _itestPrntCnstPrntObjPrntInp.Encode(input)
      .Add("alt", input.Alt);
}

internal class testCnstPrntObjPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestCnstPrntObjPrntOutpObject>
{
  private readonly IEncoder<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>> _itestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp> = encoders.EncoderFor<ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>>();
  public Structured Encode(ItestCnstPrntObjPrntOutpObject input)
    => _itestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>.Encode(input);
}

internal class testRefCnstPrntObjPrntOutpEncoder : IEncoder<ItestRefCnstPrntObjPrntOutpObject<TRef>>
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

internal class testFieldInpEncoder : IEncoder<ItestFieldInpObject>
{
  public Structured Encode(ItestFieldInpObject input)
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

internal class testFieldDescrInpEncoder : IEncoder<ItestFieldDescrInpObject>
{
  public Structured Encode(ItestFieldDescrInpObject input)
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

internal class testFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldDualInpObject>
{
  private readonly IEncoder<ItestFldFieldDualInp> _itestFldFieldDualInp = encoders.EncoderFor<ItestFldFieldDualInp>();
  public Structured Encode(ItestFieldDualInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldDualInp);
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

internal class testFieldEnumInpEncoder : IEncoder<ItestFieldEnumInpObject>
{
  public Structured Encode(ItestFieldEnumInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
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

internal class testFieldEnumPrntInpEncoder : IEncoder<ItestFieldEnumPrntInpObject>
{
  public Structured Encode(ItestFieldEnumPrntInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
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

internal class testFieldModEnumInpEncoder : IEncoder<ItestFieldModEnumInpObject>
{
  public Structured Encode(ItestFieldModEnumInpObject input)
    => Structured.Empty();
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

internal class testFieldModParamDualEncoder : IEncoder<ItestFieldModParamDualObject<TMod>>
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

internal class testFieldModParamInpEncoder : IEncoder<ItestFieldModParamInpObject<TMod>>
{
  public Structured Encode(ItestFieldModParamInpObject<TMod> input)
    => Structured.Empty();
}

internal class testFldFieldModParamInpEncoder : IEncoder<ItestFldFieldModParamInpObject>
{
  public Structured Encode(ItestFldFieldModParamInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testFieldModParamOutpEncoder : IEncoder<ItestFieldModParamOutpObject<TMod>>
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

internal class testFieldObjInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestFieldObjInpObject>
{
  private readonly IEncoder<ItestFldFieldObjInp> _itestFldFieldObjInp = encoders.EncoderFor<ItestFldFieldObjInp>();
  public Structured Encode(ItestFieldObjInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldFieldObjInp);
}

internal class testFldFieldObjInpEncoder : IEncoder<ItestFldFieldObjInpObject>
{
  public Structured Encode(ItestFldFieldObjInpObject input)
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

internal class testFieldSmplInpEncoder : IEncoder<ItestFieldSmplInpObject>
{
  public Structured Encode(ItestFieldSmplInpObject input)
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

internal class testFieldTypeDescrInpEncoder : IEncoder<ItestFieldTypeDescrInpObject>
{
  public Structured Encode(ItestFieldTypeDescrInpObject input)
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

internal class testFieldValueInpEncoder : IEncoder<ItestFieldValueInpObject>
{
  public Structured Encode(ItestFieldValueInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
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

internal class testFieldValueDescrInpEncoder : IEncoder<ItestFieldValueDescrInpObject>
{
  public Structured Encode(ItestFieldValueDescrInpObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
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

internal class testGnrcAltDualEncoder : IEncoder<ItestGnrcAltDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltDualObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcAltInpEncoder : IEncoder<ItestGnrcAltInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltInpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcAltOutpEncoder : IEncoder<ItestGnrcAltOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltOutpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDualEncoder : IEncoder<ItestGnrcAltArgDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDualObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDualEncoder : IEncoder<ItestRefGnrcAltArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgInpEncoder : IEncoder<ItestGnrcAltArgInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgInpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgInpEncoder : IEncoder<ItestRefGnrcAltArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgOutpEncoder : IEncoder<ItestGnrcAltArgOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgOutpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgOutpEncoder : IEncoder<ItestRefGnrcAltArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDescrDualEncoder : IEncoder<ItestGnrcAltArgDescrDualObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrDualObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrDualEncoder : IEncoder<ItestRefGnrcAltArgDescrDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDescrInpEncoder : IEncoder<ItestGnrcAltArgDescrInpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrInpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrInpEncoder : IEncoder<ItestRefGnrcAltArgDescrInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltArgDescrOutpEncoder : IEncoder<ItestGnrcAltArgDescrOutpObject<TType>>
{
  public Structured Encode(ItestGnrcAltArgDescrOutpObject<TType> input)
    => Structured.Empty();
}

internal class testRefGnrcAltArgDescrOutpEncoder : IEncoder<ItestRefGnrcAltArgDescrOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltArgDescrOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltDualDualEncoder : IEncoder<ItestGnrcAltDualDualObject>
{
  public Structured Encode(ItestGnrcAltDualDualObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltDualDualEncoder : IEncoder<ItestRefGnrcAltDualDualObject<TRef>>
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

internal class testGnrcAltDualInpEncoder : IEncoder<ItestGnrcAltDualInpObject>
{
  public Structured Encode(ItestGnrcAltDualInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltDualInpEncoder : IEncoder<ItestRefGnrcAltDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltDualInpObject<TRef> input)
    => Structured.Empty();
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

internal class testRefGnrcAltDualOutpEncoder : IEncoder<ItestRefGnrcAltDualOutpObject<TRef>>
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

internal class testRefGnrcAltModParamDualEncoder : IEncoder<ItestRefGnrcAltModParamDualObject<TRef,TMod>>
{
  public Structured Encode(ItestRefGnrcAltModParamDualObject<TRef,TMod> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModParamInpEncoder : IEncoder<ItestRefGnrcAltModParamInpObject<TRef,TMod>>
{
  public Structured Encode(ItestRefGnrcAltModParamInpObject<TRef,TMod> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModParamOutpEncoder : IEncoder<ItestRefGnrcAltModParamOutpObject<TRef,TMod>>
{
  public Structured Encode(ItestRefGnrcAltModParamOutpObject<TRef,TMod> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModStrDualEncoder : IEncoder<ItestRefGnrcAltModStrDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltModStrDualObject<TRef> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModStrInpEncoder : IEncoder<ItestRefGnrcAltModStrInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltModStrInpObject<TRef> input)
    => Structured.Empty();
}

internal class testRefGnrcAltModStrOutpEncoder : IEncoder<ItestRefGnrcAltModStrOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltModStrOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltParamDualEncoder : IEncoder<ItestGnrcAltParamDualObject>
{
  public Structured Encode(ItestGnrcAltParamDualObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltParamDualEncoder : IEncoder<ItestRefGnrcAltParamDualObject<TRef>>
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

internal class testGnrcAltParamInpEncoder : IEncoder<ItestGnrcAltParamInpObject>
{
  public Structured Encode(ItestGnrcAltParamInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltParamInpEncoder : IEncoder<ItestRefGnrcAltParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcAltParamInpEncoder : IEncoder<ItestAltGnrcAltParamInpObject>
{
  public Structured Encode(ItestAltGnrcAltParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcAltParamOutpEncoder : IEncoder<ItestGnrcAltParamOutpObject>
{
  public Structured Encode(ItestGnrcAltParamOutpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltParamOutpEncoder : IEncoder<ItestRefGnrcAltParamOutpObject<TRef>>
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

internal class testRefGnrcAltSmplDualEncoder : IEncoder<ItestRefGnrcAltSmplDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltSmplInpEncoder : IEncoder<ItestGnrcAltSmplInpObject>
{
  public Structured Encode(ItestGnrcAltSmplInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltSmplInpEncoder : IEncoder<ItestRefGnrcAltSmplInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcAltSmplOutpEncoder : IEncoder<ItestGnrcAltSmplOutpObject>
{
  public Structured Encode(ItestGnrcAltSmplOutpObject input)
    => Structured.Empty();
}

internal class testRefGnrcAltSmplOutpEncoder : IEncoder<ItestRefGnrcAltSmplOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcAltSmplOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcDescrDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcDescrInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcDescrInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcDescrInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcDescrOutpEncoder(
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

internal class testRefGnrcEnumDualEncoder(
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

internal class testGnrcEnumInpEncoder : IEncoder<ItestGnrcEnumInpObject>
{
  public Structured Encode(ItestGnrcEnumInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcEnumInpEncoder(
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
    => new(input.ToString(), "_EnumGnrcEnumInp");
}

internal class testGnrcEnumOutpEncoder : IEncoder<ItestGnrcEnumOutpObject>
{
  public Structured Encode(ItestGnrcEnumOutpObject input)
    => Structured.Empty();
}

internal class testRefGnrcEnumOutpEncoder(
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

internal class testGnrcFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldInpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldOutpObject<TType>>
{
  private readonly IEncoder<TType> _type = encoders.EncoderFor<TType>();
  public Structured Encode(ItestGnrcFieldOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _type);
}

internal class testGnrcFieldArgDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgDualObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgDual<TType>> _itestRefGnrcFieldArgDual<TType> = encoders.EncoderFor<ItestRefGnrcFieldArgDual<TType>>();
  public Structured Encode(ItestGnrcFieldArgDualObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgDual<TType>);
}

internal class testRefGnrcFieldArgDualEncoder : IEncoder<ItestRefGnrcFieldArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcFieldArgInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgInpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgInp<TType>> _itestRefGnrcFieldArgInp<TType> = encoders.EncoderFor<ItestRefGnrcFieldArgInp<TType>>();
  public Structured Encode(ItestGnrcFieldArgInpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgInp<TType>);
}

internal class testRefGnrcFieldArgInpEncoder : IEncoder<ItestRefGnrcFieldArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcFieldArgOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldArgOutpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcFieldArgOutp<TType>> _itestRefGnrcFieldArgOutp<TType> = encoders.EncoderFor<ItestRefGnrcFieldArgOutp<TType>>();
  public Structured Encode(ItestGnrcFieldArgOutpObject<TType> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldArgOutp<TType>);
}

internal class testRefGnrcFieldArgOutpEncoder : IEncoder<ItestRefGnrcFieldArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldArgOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcFieldDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualDualObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>> _itestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> = encoders.EncoderFor<ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>>();
  public Structured Encode(ItestGnrcFieldDualDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>);
}

internal class testRefGnrcFieldDualDualEncoder : IEncoder<ItestRefGnrcFieldDualDualObject<TRef>>
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

internal class testGnrcFieldDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldDualInpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>> _itestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> = encoders.EncoderFor<ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>>();
  public Structured Encode(ItestGnrcFieldDualInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>);
}

internal class testRefGnrcFieldDualInpEncoder : IEncoder<ItestRefGnrcFieldDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldDualInpObject<TRef> input)
    => Structured.Empty();
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
  private readonly IEncoder<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>> _itestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> = encoders.EncoderFor<ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>>();
  public Structured Encode(ItestGnrcFieldDualOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp>);
}

internal class testRefGnrcFieldDualOutpEncoder : IEncoder<ItestRefGnrcFieldDualOutpObject<TRef>>
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
  private readonly IEncoder<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>> _itestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> = encoders.EncoderFor<ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>>();
  public Structured Encode(ItestGnrcFieldParamDualObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>);
}

internal class testRefGnrcFieldParamDualEncoder : IEncoder<ItestRefGnrcFieldParamDualObject<TRef>>
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

internal class testGnrcFieldParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamInpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>> _itestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> = encoders.EncoderFor<ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>>();
  public Structured Encode(ItestGnrcFieldParamInpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>);
}

internal class testRefGnrcFieldParamInpEncoder : IEncoder<ItestRefGnrcFieldParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcFieldParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcFieldParamInpEncoder : IEncoder<ItestAltGnrcFieldParamInpObject>
{
  public Structured Encode(ItestAltGnrcFieldParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcFieldParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcFieldParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>> _itestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> = encoders.EncoderFor<ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>>();
  public Structured Encode(ItestGnrcFieldParamOutpObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp>);
}

internal class testRefGnrcFieldParamOutpEncoder : IEncoder<ItestRefGnrcFieldParamOutpObject<TRef>>
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

internal class testGnrcPrntDualEncoder : IEncoder<ItestGnrcPrntDualObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDualObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntInpEncoder : IEncoder<ItestGnrcPrntInpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntInpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntOutpEncoder : IEncoder<ItestGnrcPrntOutpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntOutpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntArgDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgDualObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgDualObject<TType>> _itestRefGnrcPrntArgDualObject<TType> = encoders.EncoderFor<ItestRefGnrcPrntArgDualObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgDualObject<TType> input)
    => _itestRefGnrcPrntArgDualObject<TType>.Encode(input);
}

internal class testRefGnrcPrntArgDualEncoder : IEncoder<ItestRefGnrcPrntArgDualObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgDualObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcPrntArgInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgInpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgInpObject<TType>> _itestRefGnrcPrntArgInpObject<TType> = encoders.EncoderFor<ItestRefGnrcPrntArgInpObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgInpObject<TType> input)
    => _itestRefGnrcPrntArgInpObject<TType>.Encode(input);
}

internal class testRefGnrcPrntArgInpEncoder : IEncoder<ItestRefGnrcPrntArgInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgInpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcPrntArgOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntArgOutpObject<TType>>
{
  private readonly IEncoder<ItestRefGnrcPrntArgOutpObject<TType>> _itestRefGnrcPrntArgOutpObject<TType> = encoders.EncoderFor<ItestRefGnrcPrntArgOutpObject<TType>>();
  public Structured Encode(ItestGnrcPrntArgOutpObject<TType> input)
    => _itestRefGnrcPrntArgOutpObject<TType>.Encode(input);
}

internal class testRefGnrcPrntArgOutpEncoder : IEncoder<ItestRefGnrcPrntArgOutpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntArgOutpObject<TRef> input)
    => Structured.Empty();
}

internal class testGnrcPrntDescrDualEncoder : IEncoder<ItestGnrcPrntDescrDualObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDescrDualObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntDescrInpEncoder : IEncoder<ItestGnrcPrntDescrInpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDescrInpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntDescrOutpEncoder : IEncoder<ItestGnrcPrntDescrOutpObject<TType>>
{
  public Structured Encode(ItestGnrcPrntDescrOutpObject<TType> input)
    => Structured.Empty();
}

internal class testGnrcPrntDualDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualDualObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>> _itestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual> = encoders.EncoderFor<ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>>();
  public Structured Encode(ItestGnrcPrntDualDualObject input)
    => _itestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>.Encode(input);
}

internal class testRefGnrcPrntDualDualEncoder : IEncoder<ItestRefGnrcPrntDualDualObject<TRef>>
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

internal class testGnrcPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>> _itestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp> = encoders.EncoderFor<ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>>();
  public Structured Encode(ItestGnrcPrntDualInpObject input)
    => _itestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>.Encode(input);
}

internal class testRefGnrcPrntDualInpEncoder : IEncoder<ItestRefGnrcPrntDualInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualInpObject<TRef> input)
    => Structured.Empty();
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
  private readonly IEncoder<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>> _itestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp> = encoders.EncoderFor<ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>>();
  public Structured Encode(ItestGnrcPrntDualOutpObject input)
    => _itestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>.Encode(input);
}

internal class testRefGnrcPrntDualOutpEncoder : IEncoder<ItestRefGnrcPrntDualOutpObject<TRef>>
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
  private readonly IEncoder<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>> _itestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual> = encoders.EncoderFor<ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>>();
  public Structured Encode(ItestGnrcPrntDualPrntDualObject input)
    => _itestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>.Encode(input);
}

internal class testRefGnrcPrntDualPrntDualEncoder : IEncoder<ItestRefGnrcPrntDualPrntDualObject<TRef>>
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

internal class testGnrcPrntDualPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntDualPrntInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>> _itestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp> = encoders.EncoderFor<ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>>();
  public Structured Encode(ItestGnrcPrntDualPrntInpObject input)
    => _itestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>.Encode(input);
}

internal class testRefGnrcPrntDualPrntInpEncoder : IEncoder<ItestRefGnrcPrntDualPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntDualPrntInpObject<TRef> input)
    => Structured.Empty();
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
  private readonly IEncoder<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>> _itestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp> = encoders.EncoderFor<ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>>();
  public Structured Encode(ItestGnrcPrntDualPrntOutpObject input)
    => _itestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>.Encode(input);
}

internal class testRefGnrcPrntDualPrntOutpEncoder : IEncoder<ItestRefGnrcPrntDualPrntOutpObject<TRef>>
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
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>> _itestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual> = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>>();
  public Structured Encode(ItestGnrcPrntEnumChildDualObject input)
    => _itestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>.Encode(input);
}

internal class testFieldGnrcPrntEnumChildDualEncoder(
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

internal class testGnrcPrntEnumChildInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumChildInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>> _itestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>>();
  public Structured Encode(ItestGnrcPrntEnumChildInpObject input)
    => _itestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>.Encode(input);
}

internal class testFieldGnrcPrntEnumChildInpEncoder(
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
  private readonly IEncoder<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>> _itestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>>();
  public Structured Encode(ItestGnrcPrntEnumChildOutpObject input)
    => _itestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>.Encode(input);
}

internal class testFieldGnrcPrntEnumChildOutpEncoder(
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
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>> _itestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual> = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>>();
  public Structured Encode(ItestGnrcPrntEnumDomDualObject input)
    => _itestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>.Encode(input);
}

internal class testFieldGnrcPrntEnumDomDualEncoder(
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

internal class testGnrcPrntEnumDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumDomInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>> _itestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>>();
  public Structured Encode(ItestGnrcPrntEnumDomInpObject input)
    => _itestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>.Encode(input);
}

internal class testFieldGnrcPrntEnumDomInpEncoder(
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
  private readonly IEncoder<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>> _itestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>>();
  public Structured Encode(ItestGnrcPrntEnumDomOutpObject input)
    => _itestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>.Encode(input);
}

internal class testFieldGnrcPrntEnumDomOutpEncoder(
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
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>> _itestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual> = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>>();
  public Structured Encode(ItestGnrcPrntEnumPrntDualObject input)
    => _itestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>.Encode(input);
}

internal class testFieldGnrcPrntEnumPrntDualEncoder(
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

internal class testGnrcPrntEnumPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntEnumPrntInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>> _itestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>>();
  public Structured Encode(ItestGnrcPrntEnumPrntInpObject input)
    => _itestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>.Encode(input);
}

internal class testFieldGnrcPrntEnumPrntInpEncoder(
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
  private readonly IEncoder<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>> _itestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp> = encoders.EncoderFor<ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>>();
  public Structured Encode(ItestGnrcPrntEnumPrntOutpObject input)
    => _itestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>.Encode(input);
}

internal class testFieldGnrcPrntEnumPrntOutpEncoder(
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
  private readonly IEncoder<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>> _itestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual> = encoders.EncoderFor<ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>>();
  public Structured Encode(ItestGnrcPrntParamDualObject input)
    => _itestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>.Encode(input);
}

internal class testRefGnrcPrntParamDualEncoder : IEncoder<ItestRefGnrcPrntParamDualObject<TRef>>
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

internal class testGnrcPrntParamInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>> _itestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp> = encoders.EncoderFor<ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>>();
  public Structured Encode(ItestGnrcPrntParamInpObject input)
    => _itestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>.Encode(input);
}

internal class testRefGnrcPrntParamInpEncoder : IEncoder<ItestRefGnrcPrntParamInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamInpEncoder : IEncoder<ItestAltGnrcPrntParamInpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcPrntParamOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>> _itestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp> = encoders.EncoderFor<ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>>();
  public Structured Encode(ItestGnrcPrntParamOutpObject input)
    => _itestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>.Encode(input);
}

internal class testRefGnrcPrntParamOutpEncoder : IEncoder<ItestRefGnrcPrntParamOutpObject<TRef>>
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
  private readonly IEncoder<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>> _itestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual> = encoders.EncoderFor<ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>>();
  public Structured Encode(ItestGnrcPrntParamPrntDualObject input)
    => _itestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>.Encode(input);
}

internal class testRefGnrcPrntParamPrntDualEncoder : IEncoder<ItestRefGnrcPrntParamPrntDualObject<TRef>>
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

internal class testGnrcPrntParamPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntInpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>> _itestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp> = encoders.EncoderFor<ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>>();
  public Structured Encode(ItestGnrcPrntParamPrntInpObject input)
    => _itestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>.Encode(input);
}

internal class testRefGnrcPrntParamPrntInpEncoder : IEncoder<ItestRefGnrcPrntParamPrntInpObject<TRef>>
{
  public Structured Encode(ItestRefGnrcPrntParamPrntInpObject<TRef> input)
    => Structured.Empty();
}

internal class testAltGnrcPrntParamPrntInpEncoder : IEncoder<ItestAltGnrcPrntParamPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntParamPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);
}

internal class testGnrcPrntParamPrntOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntParamPrntOutpObject>
{
  private readonly IEncoder<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>> _itestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp> = encoders.EncoderFor<ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>>();
  public Structured Encode(ItestGnrcPrntParamPrntOutpObject input)
    => _itestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>.Encode(input);
}

internal class testRefGnrcPrntParamPrntOutpEncoder : IEncoder<ItestRefGnrcPrntParamPrntOutpObject<TRef>>
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
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>> _itestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual> = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>>();
  public Structured Encode(ItestGnrcPrntSmplEnumDualObject input)
    => _itestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>.Encode(input);
}

internal class testFieldGnrcPrntSmplEnumDualEncoder(
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

internal class testGnrcPrntSmplEnumInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>> _itestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp> = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>>();
  public Structured Encode(ItestGnrcPrntSmplEnumInpObject input)
    => _itestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>.Encode(input);
}

internal class testFieldGnrcPrntSmplEnumInpEncoder(
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
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumInp");
}

internal class testGnrcPrntSmplEnumOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntSmplEnumOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>> _itestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp> = encoders.EncoderFor<ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>>();
  public Structured Encode(ItestGnrcPrntSmplEnumOutpObject input)
    => _itestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>.Encode(input);
}

internal class testFieldGnrcPrntSmplEnumOutpEncoder(
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
  private readonly IEncoder<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>> _itestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual> = encoders.EncoderFor<ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>>();
  public Structured Encode(ItestGnrcPrntStrDomDualObject input)
    => _itestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>.Encode(input);
}

internal class testFieldGnrcPrntStrDomDualEncoder(
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

internal class testGnrcPrntStrDomInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomInpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>> _itestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp> = encoders.EncoderFor<ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>>();
  public Structured Encode(ItestGnrcPrntStrDomInpObject input)
    => _itestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>.Encode(input);
}

internal class testFieldGnrcPrntStrDomInpEncoder(
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
    => new(input.Value);
}

internal class testGnrcPrntStrDomOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestGnrcPrntStrDomOutpObject>
{
  private readonly IEncoder<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>> _itestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp> = encoders.EncoderFor<ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>>();
  public Structured Encode(ItestGnrcPrntStrDomOutpObject input)
    => _itestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>.Encode(input);
}

internal class testFieldGnrcPrntStrDomOutpEncoder(
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

internal class testRefGnrcValueDualEncoder(
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

internal class testGnrcValueInpEncoder : IEncoder<ItestGnrcValueInpObject>
{
  public Structured Encode(ItestGnrcValueInpObject input)
    => Structured.Empty();
}

internal class testRefGnrcValueInpEncoder(
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
    => new(input.ToString(), "_EnumGnrcValueInp");
}

internal class testGnrcValueOutpEncoder : IEncoder<ItestGnrcValueOutpObject>
{
  public Structured Encode(ItestGnrcValueOutpObject input)
    => Structured.Empty();
}

internal class testRefGnrcValueOutpEncoder(
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

internal class testInpFieldDescrNmbrEncoder : IEncoder<ItestInpFieldDescrNmbrObject>
{
  public Structured Encode(ItestInpFieldDescrNmbrObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testInpFieldEnumEncoder : IEncoder<ItestInpFieldEnumObject>
{
  public Structured Encode(ItestInpFieldEnumObject input)
    => Structured.Empty()
      .AddEnum("field", input.Field);
}

internal class testEnumInpFieldEnumEncoder : IEncoder<testEnumInpFieldEnum>
{
  public Structured Encode(testEnumInpFieldEnum input)
    => new(input.ToString(), "_EnumInpFieldEnum");
}

internal class testInpFieldNullEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestInpFieldNullObject>
{
  private readonly IEncoder<ItestFldInpFieldNull> _itestFldInpFieldNull = encoders.EncoderFor<ItestFldInpFieldNull>();
  public Structured Encode(ItestInpFieldNullObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field, _itestFldInpFieldNull);
}

internal class testFldInpFieldNullEncoder : IEncoder<ItestFldInpFieldNullObject>
{
  public Structured Encode(ItestFldInpFieldNullObject input)
    => Structured.Empty();
}

internal class testInpFieldNmbrEncoder : IEncoder<ItestInpFieldNmbrObject>
{
  public Structured Encode(ItestInpFieldNmbrObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testInpFieldNmbrDescrEncoder : IEncoder<ItestInpFieldNmbrDescrObject>
{
  public Structured Encode(ItestInpFieldNmbrDescrObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testInpFieldStrEncoder : IEncoder<ItestInpFieldStrObject>
{
  public Structured Encode(ItestInpFieldStrObject input)
    => Structured.Empty()
      .Add("field", input.Field);
}

internal class testOutpDescrParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpDescrParamObject>
{
  private readonly IEncoder<ItestFldOutpDescrParam> _itestFldOutpDescrParam = encoders.EncoderFor<ItestFldOutpDescrParam>();
  public Structured Encode(ItestOutpDescrParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestFldOutpDescrParam);
}

internal class testFldOutpDescrParamEncoder : IEncoder<ItestFldOutpDescrParamObject>
{
  public Structured Encode(ItestFldOutpDescrParamObject input)
    => Structured.Empty();
}

internal class testInOutpDescrParamEncoder : IEncoder<ItestInOutpDescrParamObject>
{
  public Structured Encode(ItestInOutpDescrParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testOutpParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamObject>
{
  private readonly IEncoder<ItestFldOutpParam> _itestFldOutpParam = encoders.EncoderFor<ItestFldOutpParam>();
  public Structured Encode(ItestOutpParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestFldOutpParam);
}

internal class testFldOutpParamEncoder : IEncoder<ItestFldOutpParamObject>
{
  public Structured Encode(ItestFldOutpParamObject input)
    => Structured.Empty();
}

internal class testInOutpParamEncoder : IEncoder<ItestInOutpParamObject>
{
  public Structured Encode(ItestInOutpParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testOutpParamDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamDescr> _itestFldOutpParamDescr = encoders.EncoderFor<ItestFldOutpParamDescr>();
  public Structured Encode(ItestOutpParamDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestFldOutpParamDescr);
}

internal class testFldOutpParamDescrEncoder : IEncoder<ItestFldOutpParamDescrObject>
{
  public Structured Encode(ItestFldOutpParamDescrObject input)
    => Structured.Empty();
}

internal class testInOutpParamDescrEncoder : IEncoder<ItestInOutpParamDescrObject>
{
  public Structured Encode(ItestInOutpParamDescrObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testOutpParamModDmnEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModDmnObject>
{
  private readonly IEncoder<ItestDomOutpParamModDmn> _itestDomOutpParamModDmn = encoders.EncoderFor<ItestDomOutpParamModDmn>();
  public Structured Encode(ItestOutpParamModDmnObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestDomOutpParamModDmn);
}

internal class testInOutpParamModDmnEncoder : IEncoder<ItestInOutpParamModDmnObject>
{
  public Structured Encode(ItestInOutpParamModDmnObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testDomOutpParamModDmnEncoder : IEncoder<ItestDomOutpParamModDmn>
{
  public Structured Encode(ItestDomOutpParamModDmn input)
    => new(input.Value);
}

internal class testOutpParamModParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModParamObject<TMod>>
{
  private readonly IEncoder<ItestDomOutpParamModParam> _itestDomOutpParamModParam = encoders.EncoderFor<ItestDomOutpParamModParam>();
  public Structured Encode(ItestOutpParamModParamObject<TMod> input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestDomOutpParamModParam);
}

internal class testInOutpParamModParamEncoder : IEncoder<ItestInOutpParamModParamObject>
{
  public Structured Encode(ItestInOutpParamModParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
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
      .AddEncoded("field", input.Field(null), _itestFldOutpParamTypeDescr);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public Structured Encode(ItestFldOutpParamTypeDescrObject input)
    => Structured.Empty();
}

internal class testInOutpParamTypeDescrEncoder : IEncoder<ItestInOutpParamTypeDescrObject>
{
  public Structured Encode(ItestInOutpParamTypeDescrObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testOutpPrntGnrcEncoder : IEncoder<ItestOutpPrntGnrcObject>
{
  public Structured Encode(ItestOutpPrntGnrcObject input)
    => Structured.Empty();
}

internal class testRefOutpPrntGnrcEncoder(
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
      .AddEncoded("field", input.Field(null), _itestFldOutpPrntParam);
}

internal class testPrntOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpPrntParamObject>
{
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestPrntOutpPrntParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(null), _itestFldOutpPrntParam);
}

internal class testFldOutpPrntParamEncoder : IEncoder<ItestFldOutpPrntParamObject>
{
  public Structured Encode(ItestFldOutpPrntParamObject input)
    => Structured.Empty();
}

internal class testInOutpPrntParamEncoder : IEncoder<ItestInOutpPrntParamObject>
{
  public Structured Encode(ItestInOutpPrntParamObject input)
    => Structured.Empty()
      .Add("param", input.Param);
}

internal class testPrntOutpPrntParamInEncoder : IEncoder<ItestPrntOutpPrntParamInObject>
{
  public Structured Encode(ItestPrntOutpPrntParamInObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);
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

internal class testPrntInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntInpObject>
{
  private readonly IEncoder<ItestRefPrntInpObject> _itestRefPrntInp = encoders.EncoderFor<ItestRefPrntInpObject>();
  public Structured Encode(ItestPrntInpObject input)
    => _itestRefPrntInp.Encode(input);
}

internal class testRefPrntInpEncoder : IEncoder<ItestRefPrntInpObject>
{
  public Structured Encode(ItestRefPrntInpObject input)
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

internal class testPrntAltInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntAltInpObject>
{
  private readonly IEncoder<ItestRefPrntAltInpObject> _itestRefPrntAltInp = encoders.EncoderFor<ItestRefPrntAltInpObject>();
  public Structured Encode(ItestPrntAltInpObject input)
    => _itestRefPrntAltInp.Encode(input);
}

internal class testRefPrntAltInpEncoder : IEncoder<ItestRefPrntAltInpObject>
{
  public Structured Encode(ItestRefPrntAltInpObject input)
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

internal class testPrntDescrInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDescrInpObject>
{
  private readonly IEncoder<ItestRefPrntDescrInpObject> _itestRefPrntDescrInp = encoders.EncoderFor<ItestRefPrntDescrInpObject>();
  public Structured Encode(ItestPrntDescrInpObject input)
    => _itestRefPrntDescrInp.Encode(input);
}

internal class testRefPrntDescrInpEncoder : IEncoder<ItestRefPrntDescrInpObject>
{
  public Structured Encode(ItestRefPrntDescrInpObject input)
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

internal class testPrntDualInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntDualInpObject>
{
  private readonly IEncoder<ItestRefPrntDualInpObject> _itestRefPrntDualInp = encoders.EncoderFor<ItestRefPrntDualInpObject>();
  public Structured Encode(ItestPrntDualInpObject input)
    => _itestRefPrntDualInp.Encode(input);
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

internal class testPrntFieldInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldInpObject>
{
  private readonly IEncoder<ItestRefPrntFieldInpObject> _itestRefPrntFieldInp = encoders.EncoderFor<ItestRefPrntFieldInpObject>();
  public Structured Encode(ItestPrntFieldInpObject input)
    => _itestRefPrntFieldInp.Encode(input)
      .Add("field", input.Field);
}

internal class testRefPrntFieldInpEncoder : IEncoder<ItestRefPrntFieldInpObject>
{
  public Structured Encode(ItestRefPrntFieldInpObject input)
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

internal class testPrntParamDiffDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffDualObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffDualObject<TA>> _itestRefPrntParamDiffDualObject<TA> = encoders.EncoderFor<ItestRefPrntParamDiffDualObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffDualObject<TA> input)
    => _itestRefPrntParamDiffDualObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffDualEncoder : IEncoder<ItestRefPrntParamDiffDualObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffDualObject<TB> input)
    => Structured.Empty();
}

internal class testPrntParamDiffInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffInpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffInpObject<TA>> _itestRefPrntParamDiffInpObject<TA> = encoders.EncoderFor<ItestRefPrntParamDiffInpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffInpObject<TA> input)
    => _itestRefPrntParamDiffInpObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffInpEncoder : IEncoder<ItestRefPrntParamDiffInpObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffInpObject<TB> input)
    => Structured.Empty();
}

internal class testPrntParamDiffOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamDiffOutpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamDiffOutpObject<TA>> _itestRefPrntParamDiffOutpObject<TA> = encoders.EncoderFor<ItestRefPrntParamDiffOutpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamDiffOutpObject<TA> input)
    => _itestRefPrntParamDiffOutpObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamDiffOutpEncoder : IEncoder<ItestRefPrntParamDiffOutpObject<TB>>
{
  public Structured Encode(ItestRefPrntParamDiffOutpObject<TB> input)
    => Structured.Empty();
}

internal class testPrntParamSameDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameDualObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameDualObject<TA>> _itestRefPrntParamSameDualObject<TA> = encoders.EncoderFor<ItestRefPrntParamSameDualObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameDualObject<TA> input)
    => _itestRefPrntParamSameDualObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameDualEncoder : IEncoder<ItestRefPrntParamSameDualObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameDualObject<TA> input)
    => Structured.Empty();
}

internal class testPrntParamSameInpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameInpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameInpObject<TA>> _itestRefPrntParamSameInpObject<TA> = encoders.EncoderFor<ItestRefPrntParamSameInpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameInpObject<TA> input)
    => _itestRefPrntParamSameInpObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameInpEncoder : IEncoder<ItestRefPrntParamSameInpObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameInpObject<TA> input)
    => Structured.Empty();
}

internal class testPrntParamSameOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntParamSameOutpObject<TA>>
{
  private readonly IEncoder<ItestRefPrntParamSameOutpObject<TA>> _itestRefPrntParamSameOutpObject<TA> = encoders.EncoderFor<ItestRefPrntParamSameOutpObject<TA>>();
  private readonly IEncoder<TA> _a = encoders.EncoderFor<TA>();
  public Structured Encode(ItestPrntParamSameOutpObject<TA> input)
    => _itestRefPrntParamSameOutpObject<TA>.Encode(input)
      .AddEncoded("field", input.Field, _a);
}

internal class testRefPrntParamSameOutpEncoder : IEncoder<ItestRefPrntParamSameOutpObject<TA>>
{
  public Structured Encode(ItestRefPrntParamSameOutpObject<TA> input)
    => Structured.Empty();
}
