//HintName: test_+Objects_Enc.gen.cs
// Generated from {CurrentDirectory}+Objects.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpEncoderBase, GeneratorType: Enc
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Objects;

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
      .Add("alt", input.Alt);

  internal static testAltAltDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

  internal static testAltAltOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltDescrDualEncoder : IEncoder<ItestAltDescrDualObject>
{
  public Structured Encode(ItestAltDescrDualObject input)
    => Structured.Empty();

  internal static testAltDescrDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

  internal static testObjDualAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testObjDualAltDualInpEncoder : IEncoder<ItestObjDualAltDualInpObject>
{
  public Structured Encode(ItestObjDualAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

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
    => new(input.ToString(), "_EnumAltEnumDual");

  internal static testEnumAltEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumAltEnumInpEncoder : IEncoder<testEnumAltEnumInp>
{
  public Structured Encode(testEnumAltEnumInp input)
    => new(input.ToString(), "_EnumAltEnumInp");

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
    => new(input.ToString(), "_EnumAltEnumOutp");

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
      .Add("alt", input.Alt);

  internal static testAltAltModBoolDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltAltModParamDualEncoder Factory(IEncoderRepository _) => new();
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

  internal static testAltAltModParamOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltSmplDualEncoder : IEncoder<ItestAltSmplDualObject>
{
  public Structured Encode(ItestAltSmplDualObject input)
    => Structured.Empty();

  internal static testAltSmplDualEncoder Factory(IEncoderRepository _) => new();
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
    => new(input.Value);

  internal static testDomCnstAltDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomCnstAltDmnInpEncoder : IEncoder<ItestDomCnstAltDmnInp>
{
  public Structured Encode(ItestDomCnstAltDmnInp input)
    => new(input.Value);

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
    => new(input.Value);

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
      .Add("alt", input.Alt);

  internal static testAltCnstAltDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntCnstAltDualInpEncoder : IEncoder<ItestPrntCnstAltDualInpObject>
{
  public Structured Encode(ItestPrntCnstAltDualInpObject input)
    => Structured.Empty();

  internal static testPrntCnstAltDualInpEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltCnstAltObjDualEncoder Factory(IEncoderRepository r) => new(r);
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
      .Add("alt", input.Alt);

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
    => new(input.ToString(), "_EnumCnstDomEnumDual");

  internal static testEnumCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumDualEncoder : IEncoder<ItestJustCnstDomEnumDual>
{
  public Structured Encode(ItestJustCnstDomEnumDual input)
    => new((decimal?)input.Value);

  internal static testJustCnstDomEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumCnstDomEnumInpEncoder : IEncoder<testEnumCnstDomEnumInp>
{
  public Structured Encode(testEnumCnstDomEnumInp input)
    => new(input.ToString(), "_EnumCnstDomEnumInp");

  internal static testEnumCnstDomEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumInpEncoder : IEncoder<ItestJustCnstDomEnumInp>
{
  public Structured Encode(ItestJustCnstDomEnumInp input)
    => new((decimal?)input.Value);

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
    => new(input.ToString(), "_EnumCnstDomEnumOutp");

  internal static testEnumCnstDomEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpEncoder : IEncoder<ItestJustCnstDomEnumOutp>
{
  public Structured Encode(ItestJustCnstDomEnumOutp input)
    => new((decimal?)input.Value);

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
    => new(input.ToString(), "_EnumCnstEnumDual");

  internal static testEnumCnstEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumCnstEnumInpEncoder : IEncoder<testEnumCnstEnumInp>
{
  public Structured Encode(testEnumCnstEnumInp input)
    => new(input.ToString(), "_EnumCnstEnumInp");

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
    => new(input.ToString(), "_EnumCnstEnumOutp");

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
    => new(input.ToString(), "_EnumCnstEnumPrntDual");

  internal static testEnumCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntDualEncoder : IEncoder<testParentCnstEnumPrntDual>
{
  public Structured Encode(testParentCnstEnumPrntDual input)
    => new(input.ToString(), "_ParentCnstEnumPrntDual");

  internal static testParentCnstEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumCnstEnumPrntInpEncoder : IEncoder<testEnumCnstEnumPrntInp>
{
  public Structured Encode(testEnumCnstEnumPrntInp input)
    => new(input.ToString(), "_EnumCnstEnumPrntInp");

  internal static testEnumCnstEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpEncoder : IEncoder<testParentCnstEnumPrntInp>
{
  public Structured Encode(testParentCnstEnumPrntInp input)
    => new(input.ToString(), "_ParentCnstEnumPrntInp");

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
    => new(input.ToString(), "_EnumCnstEnumPrntOutp");

  internal static testEnumCnstEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpEncoder : IEncoder<testParentCnstEnumPrntOutp>
{
  public Structured Encode(testParentCnstEnumPrntOutp input)
    => new(input.ToString(), "_ParentCnstEnumPrntOutp");

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
    => new(input.Value);

  internal static testDomCnstFieldDmnDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomCnstFieldDmnInpEncoder : IEncoder<ItestDomCnstFieldDmnInp>
{
  public Structured Encode(ItestDomCnstFieldDmnInp input)
    => new(input.Value);

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
    => new(input.Value);

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
      .Add("alt", input.Alt);

  internal static testAltCnstFieldDualDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntCnstFieldDualInpEncoder : IEncoder<ItestPrntCnstFieldDualInpObject>
{
  public Structured Encode(ItestPrntCnstFieldDualInpObject input)
    => Structured.Empty();

  internal static testPrntCnstFieldDualInpEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltCnstFieldObjDualEncoder Factory(IEncoderRepository r) => new(r);
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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltCnstPrntDualGrndDualEncoder Factory(IEncoderRepository r) => new(r);
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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltCnstPrntDualPrntDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntCnstPrntDualPrntInpEncoder : IEncoder<ItestPrntCnstPrntDualPrntInpObject>
{
  public Structured Encode(ItestPrntCnstPrntDualPrntInpObject input)
    => Structured.Empty();

  internal static testPrntCnstPrntDualPrntInpEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

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
    => new(input.ToString(), "_EnumCnstPrntEnumDual");

  internal static testEnumCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumDualEncoder : IEncoder<testParentCnstPrntEnumDual>
{
  public Structured Encode(testParentCnstPrntEnumDual input)
    => new(input.ToString(), "_ParentCnstPrntEnumDual");

  internal static testParentCnstPrntEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumCnstPrntEnumInpEncoder : IEncoder<testEnumCnstPrntEnumInp>
{
  public Structured Encode(testEnumCnstPrntEnumInp input)
    => new(input.ToString(), "_EnumCnstPrntEnumInp");

  internal static testEnumCnstPrntEnumInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpEncoder : IEncoder<testParentCnstPrntEnumInp>
{
  public Structured Encode(testParentCnstPrntEnumInp input)
    => new(input.ToString(), "_ParentCnstPrntEnumInp");

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
    => new(input.ToString(), "_EnumCnstPrntEnumOutp");

  internal static testEnumCnstPrntEnumOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentCnstPrntEnumOutpEncoder : IEncoder<testParentCnstPrntEnumOutp>
{
  public Structured Encode(testParentCnstPrntEnumOutp input)
    => new(input.ToString(), "_ParentCnstPrntEnumOutp");

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
      .Add("alt", input.Alt);

  internal static testAltCnstPrntObjPrntDualEncoder Factory(IEncoderRepository r) => new(r);
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
      .Add("alt", input.Alt);

  internal static testAltCnstPrntObjPrntOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFieldDualEncoder : IEncoder<ItestFieldDualObject>
{
  public Structured Encode(ItestFieldDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldOutpEncoder : IEncoder<ItestFieldOutpObject>
{
  public Structured Encode(ItestFieldOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrDualEncoder : IEncoder<ItestFieldDescrDualObject>
{
  public Structured Encode(ItestFieldDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldDescrOutpEncoder : IEncoder<ItestFieldDescrOutpObject>
{
  public Structured Encode(ItestFieldDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

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
      .Add("field", input.Field);

  internal static testFldFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFldFieldDualInpEncoder : IEncoder<ItestFldFieldDualInpObject>
{
  public Structured Encode(ItestFldFieldDualInpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

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
      .Add("field", input.Field);

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
    => new(input.ToString(), "_EnumFieldEnumDual");

  internal static testEnumFieldEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumInpEncoder : IEncoder<testEnumFieldEnumInp>
{
  public Structured Encode(testEnumFieldEnumInp input)
    => new(input.ToString(), "_EnumFieldEnumInp");

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
    => new(input.ToString(), "_EnumFieldEnumOutp");

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
    => new(input.ToString(), "_EnumFieldEnumPrntDual");

  internal static testEnumFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualEncoder : IEncoder<testPrntFieldEnumPrntDual>
{
  public Structured Encode(testPrntFieldEnumPrntDual input)
    => new(input.ToString(), "_PrntFieldEnumPrntDual");

  internal static testPrntFieldEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldEnumPrntInpEncoder : IEncoder<testEnumFieldEnumPrntInp>
{
  public Structured Encode(testEnumFieldEnumPrntInp input)
    => new(input.ToString(), "_EnumFieldEnumPrntInp");

  internal static testEnumFieldEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpEncoder : IEncoder<testPrntFieldEnumPrntInp>
{
  public Structured Encode(testPrntFieldEnumPrntInp input)
    => new(input.ToString(), "_PrntFieldEnumPrntInp");

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
    => new(input.ToString(), "_EnumFieldEnumPrntOutp");

  internal static testEnumFieldEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpEncoder : IEncoder<testPrntFieldEnumPrntOutp>
{
  public Structured Encode(testPrntFieldEnumPrntOutp input)
    => new(input.ToString(), "_PrntFieldEnumPrntOutp");

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
    => new(input.ToString(), "_EnumFieldModEnumDual");

  internal static testEnumFieldModEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldModEnumInpEncoder : IEncoder<testEnumFieldModEnumInp>
{
  public Structured Encode(testEnumFieldModEnumInp input)
    => new(input.ToString(), "_EnumFieldModEnumInp");

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
    => new(input.ToString(), "_EnumFieldModEnumOutp");

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
      .Add("field", input.Field);

  internal static testFldFieldModParamDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("field", input.Field);

  internal static testFldFieldObjDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("field", input.Field);

  internal static testFldFieldObjOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplDualEncoder : IEncoder<ItestFieldSmplDualObject>
{
  public Structured Encode(ItestFieldSmplDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldSmplDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldSmplOutpEncoder : IEncoder<ItestFieldSmplOutpObject>
{
  public Structured Encode(ItestFieldSmplOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldSmplOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrDualEncoder : IEncoder<ItestFieldTypeDescrDualObject>
{
  public Structured Encode(ItestFieldTypeDescrDualObject input)
    => Structured.Empty()
      .Add("field", input.Field);

  internal static testFieldTypeDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testFieldTypeDescrOutpEncoder : IEncoder<ItestFieldTypeDescrOutpObject>
{
  public Structured Encode(ItestFieldTypeDescrOutpObject input)
    => Structured.Empty()
      .Add("field", input.Field);

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
    => new(input.ToString(), "_EnumFieldValueDual");

  internal static testEnumFieldValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueInpEncoder : IEncoder<testEnumFieldValueInp>
{
  public Structured Encode(testEnumFieldValueInp input)
    => new(input.ToString(), "_EnumFieldValueInp");

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
    => new(input.ToString(), "_EnumFieldValueOutp");

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
    => new(input.ToString(), "_EnumFieldValueDescrDual");

  internal static testEnumFieldValueDescrDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumFieldValueDescrInpEncoder : IEncoder<testEnumFieldValueDescrInp>
{
  public Structured Encode(testEnumFieldValueDescrInp input)
    => new(input.ToString(), "_EnumFieldValueDescrInp");

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
    => new(input.ToString(), "_EnumFieldValueDescrOutp");

  internal static testEnumFieldValueDescrOutpEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

  internal static testAltGnrcAltDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltGnrcAltDualInpEncoder : IEncoder<ItestAltGnrcAltDualInpObject>
{
  public Structured Encode(ItestAltGnrcAltDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltGnrcAltDualOutpEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

  internal static testAltGnrcAltParamDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

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
    => new(input.ToString(), "_EnumGnrcEnumDual");

  internal static testEnumGnrcEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumGnrcEnumInpEncoder : IEncoder<testEnumGnrcEnumInp>
{
  public Structured Encode(testEnumGnrcEnumInp input)
    => new(input.ToString(), "_EnumGnrcEnumInp");

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
    => new(input.ToString(), "_EnumGnrcEnumOutp");

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
      .Add("alt", input.Alt);

  internal static testAltGnrcFieldDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltGnrcFieldDualInpEncoder : IEncoder<ItestAltGnrcFieldDualInpObject>
{
  public Structured Encode(ItestAltGnrcFieldDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltGnrcFieldParamDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

  internal static testAltGnrcFieldParamOutpEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltGnrcPrntDualInpEncoder : IEncoder<ItestAltGnrcPrntDualInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntDualPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testAltGnrcPrntDualPrntInpEncoder : IEncoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public Structured Encode(ItestAltGnrcPrntDualPrntInpObject input)
    => Structured.Empty()
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

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
    => new(input.ToString(), "_EnumGnrcPrntEnumChildDual");

  internal static testEnumGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildDualEncoder : IEncoder<testParentGnrcPrntEnumChildDual>
{
  public Structured Encode(testParentGnrcPrntEnumChildDual input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildDual");

  internal static testParentGnrcPrntEnumChildDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumChildInpEncoder : IEncoder<testEnumGnrcPrntEnumChildInp>
{
  public Structured Encode(testEnumGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumChildInp");

  internal static testEnumGnrcPrntEnumChildInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpEncoder : IEncoder<testParentGnrcPrntEnumChildInp>
{
  public Structured Encode(testParentGnrcPrntEnumChildInp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildInp");

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
    => new(input.ToString(), "_EnumGnrcPrntEnumChildOutp");

  internal static testEnumGnrcPrntEnumChildOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpEncoder : IEncoder<testParentGnrcPrntEnumChildOutp>
{
  public Structured Encode(testParentGnrcPrntEnumChildOutp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumChildOutp");

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
    => new(input.ToString(), "_EnumGnrcPrntEnumDomDual");

  internal static testEnumGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomDualEncoder : IEncoder<ItestDomGnrcPrntEnumDomDual>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomDual input)
    => new((decimal?)input.Value);

  internal static testDomGnrcPrntEnumDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumDomInpEncoder : IEncoder<testEnumGnrcPrntEnumDomInp>
{
  public Structured Encode(testEnumGnrcPrntEnumDomInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumDomInp");

  internal static testEnumGnrcPrntEnumDomInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpEncoder : IEncoder<ItestDomGnrcPrntEnumDomInp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomInp input)
    => new((decimal?)input.Value);

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
    => new(input.ToString(), "_EnumGnrcPrntEnumDomOutp");

  internal static testEnumGnrcPrntEnumDomOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomOutpEncoder : IEncoder<ItestDomGnrcPrntEnumDomOutp>
{
  public Structured Encode(ItestDomGnrcPrntEnumDomOutp input)
    => new((decimal?)input.Value);

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
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntDual");

  internal static testEnumGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntDualEncoder : IEncoder<testParentGnrcPrntEnumPrntDual>
{
  public Structured Encode(testParentGnrcPrntEnumPrntDual input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntDual");

  internal static testParentGnrcPrntEnumPrntDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumPrntInpEncoder : IEncoder<testEnumGnrcPrntEnumPrntInp>
{
  public Structured Encode(testEnumGnrcPrntEnumPrntInp input)
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntInp");

  internal static testEnumGnrcPrntEnumPrntInpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpEncoder : IEncoder<testParentGnrcPrntEnumPrntInp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntInp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntInp");

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
    => new(input.ToString(), "_EnumGnrcPrntEnumPrntOutp");

  internal static testEnumGnrcPrntEnumPrntOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpEncoder : IEncoder<testParentGnrcPrntEnumPrntOutp>
{
  public Structured Encode(testParentGnrcPrntEnumPrntOutp input)
    => new(input.ToString(), "_ParentGnrcPrntEnumPrntOutp");

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
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntParamDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

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
      .Add("alt", input.Alt);

  internal static testAltGnrcPrntParamPrntDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("alt", input.Alt);

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
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumDual");

  internal static testEnumGnrcPrntSmplEnumDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumGnrcPrntSmplEnumInpEncoder : IEncoder<testEnumGnrcPrntSmplEnumInp>
{
  public Structured Encode(testEnumGnrcPrntSmplEnumInp input)
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumInp");

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
    => new(input.ToString(), "_EnumGnrcPrntSmplEnumOutp");

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
    => new(input.Value);

  internal static testDomGnrcPrntStrDomDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testDomGnrcPrntStrDomInpEncoder : IEncoder<ItestDomGnrcPrntStrDomInp>
{
  public Structured Encode(ItestDomGnrcPrntStrDomInp input)
    => new(input.Value);

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
    => new(input.Value);

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
    => new(input.ToString(), "_EnumGnrcValueDual");

  internal static testEnumGnrcValueDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumGnrcValueInpEncoder : IEncoder<testEnumGnrcValueInp>
{
  public Structured Encode(testEnumGnrcValueInp input)
    => new(input.ToString(), "_EnumGnrcValueInp");

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
    => new(input.ToString(), "_EnumGnrcValueOutp");

  internal static testEnumGnrcValueOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testEnumInpFieldEnumEncoder : IEncoder<testEnumInpFieldEnum>
{
  public Structured Encode(testEnumInpFieldEnum input)
    => new(input.ToString(), "_EnumInpFieldEnum");

  internal static testEnumInpFieldEnumEncoder Factory(IEncoderRepository _) => new();
}

internal class testFldInpFieldNullEncoder : IEncoder<ItestFldInpFieldNullObject>
{
  public Structured Encode(ItestFldInpFieldNullObject input)
    => Structured.Empty();

  internal static testFldInpFieldNullEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpDescrParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpDescrParamObject>
{
  private readonly IEncoder<ItestFldOutpDescrParam> _itestFldOutpDescrParam = encoders.EncoderFor<ItestFldOutpDescrParam>();
  public Structured Encode(ItestOutpDescrParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpDescrParam);

  internal static testOutpDescrParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpDescrParamEncoder : IEncoder<ItestFldOutpDescrParamObject>
{
  public Structured Encode(ItestFldOutpDescrParamObject input)
    => Structured.Empty();

  internal static testFldOutpDescrParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamObject>
{
  private readonly IEncoder<ItestFldOutpParam> _itestFldOutpParam = encoders.EncoderFor<ItestFldOutpParam>();
  public Structured Encode(ItestOutpParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParam);

  internal static testOutpParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamEncoder : IEncoder<ItestFldOutpParamObject>
{
  public Structured Encode(ItestFldOutpParamObject input)
    => Structured.Empty();

  internal static testFldOutpParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamDescr> _itestFldOutpParamDescr = encoders.EncoderFor<ItestFldOutpParamDescr>();
  public Structured Encode(ItestOutpParamDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParamDescr);

  internal static testOutpParamDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamDescrEncoder : IEncoder<ItestFldOutpParamDescrObject>
{
  public Structured Encode(ItestFldOutpParamDescrObject input)
    => Structured.Empty();

  internal static testFldOutpParamDescrEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamModDmnEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamModDmnObject>
{
  private readonly IEncoder<ItestDomOutpParamModDmn> _itestDomOutpParamModDmn = encoders.EncoderFor<ItestDomOutpParamModDmn>();
  public Structured Encode(ItestOutpParamModDmnObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestDomOutpParamModDmn);

  internal static testOutpParamModDmnEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testDomOutpParamModDmnEncoder : IEncoder<ItestDomOutpParamModDmn>
{
  public Structured Encode(ItestDomOutpParamModDmn input)
    => new(input.Value);

  internal static testDomOutpParamModDmnEncoder Factory(IEncoderRepository _) => new();
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

  internal static testDomOutpParamModParamEncoder Factory(IEncoderRepository _) => new();
}

internal class testOutpParamTypeDescrEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestOutpParamTypeDescrObject>
{
  private readonly IEncoder<ItestFldOutpParamTypeDescr> _itestFldOutpParamTypeDescr = encoders.EncoderFor<ItestFldOutpParamTypeDescr>();
  public Structured Encode(ItestOutpParamTypeDescrObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpParamTypeDescr);

  internal static testOutpParamTypeDescrEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpParamTypeDescrEncoder : IEncoder<ItestFldOutpParamTypeDescrObject>
{
  public Structured Encode(ItestFldOutpParamTypeDescrObject input)
    => Structured.Empty();

  internal static testFldOutpParamTypeDescrEncoder Factory(IEncoderRepository _) => new();
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
    => new(input.ToString(), "_EnumOutpPrntGnrc");

  internal static testEnumOutpPrntGnrcEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcEncoder : IEncoder<testPrntOutpPrntGnrc>
{
  public Structured Encode(testPrntOutpPrntGnrc input)
    => new(input.ToString(), "_PrntOutpPrntGnrc");

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
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);

  internal static testOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testPrntOutpPrntParamEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntOutpPrntParamObject>
{
  private readonly IEncoder<ItestFldOutpPrntParam> _itestFldOutpPrntParam = encoders.EncoderFor<ItestFldOutpPrntParam>();
  public Structured Encode(ItestPrntOutpPrntParamObject input)
    => Structured.Empty()
      .AddEncoded("field", input.Field(), _itestFldOutpPrntParam);

  internal static testPrntOutpPrntParamEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testFldOutpPrntParamEncoder : IEncoder<ItestFldOutpPrntParamObject>
{
  public Structured Encode(ItestFldOutpPrntParamObject input)
    => Structured.Empty();

  internal static testFldOutpPrntParamEncoder Factory(IEncoderRepository _) => new();
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
      .Add("parent", input.Parent);

  internal static testRefPrntDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("parent", input.Parent);

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
      .Add("parent", input.Parent);

  internal static testRefPrntAltDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("parent", input.Parent);

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
      .Add("parent", input.Parent);

  internal static testRefPrntDescrDualEncoder Factory(IEncoderRepository _) => new();
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
      .Add("parent", input.Parent);

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
      .Add("parent", input.Parent);

  internal static testRefPrntDualDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testRefPrntDualInpEncoder : IEncoder<ItestRefPrntDualInpObject>
{
  public Structured Encode(ItestRefPrntDualInpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

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
      .Add("parent", input.Parent);

  internal static testRefPrntDualOutpEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldDualEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldDualObject>
{
  private readonly IEncoder<ItestRefPrntFieldDualObject> _itestRefPrntFieldDual = encoders.EncoderFor<ItestRefPrntFieldDualObject>();
  public Structured Encode(ItestPrntFieldDualObject input)
    => _itestRefPrntFieldDual.Encode(input)
      .Add("field", input.Field);

  internal static testPrntFieldDualEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldDualEncoder : IEncoder<ItestRefPrntFieldDualObject>
{
  public Structured Encode(ItestRefPrntFieldDualObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

  internal static testRefPrntFieldDualEncoder Factory(IEncoderRepository _) => new();
}

internal class testPrntFieldOutpEncoder(
  IEncoderRepository encoders
) : IEncoder<ItestPrntFieldOutpObject>
{
  private readonly IEncoder<ItestRefPrntFieldOutpObject> _itestRefPrntFieldOutp = encoders.EncoderFor<ItestRefPrntFieldOutpObject>();
  public Structured Encode(ItestPrntFieldOutpObject input)
    => _itestRefPrntFieldOutp.Encode(input)
      .Add("field", input.Field);

  internal static testPrntFieldOutpEncoder Factory(IEncoderRepository r) => new(r);
}

internal class testRefPrntFieldOutpEncoder : IEncoder<ItestRefPrntFieldOutpObject>
{
  public Structured Encode(ItestRefPrntFieldOutpObject input)
    => Structured.Empty()
      .Add("parent", input.Parent);

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

internal static class test__ObjectsEncoders
{
  internal static IEncoderRepositoryBuilder Addtest__ObjectsEncoders(this IEncoderRepositoryBuilder builder)
    => builder
      .AddEncoder<ItestAltDualObject>(testAltDualEncoder.Factory)
      .AddEncoder<ItestAltAltDualObject>(testAltAltDualEncoder.Factory)
      .AddEncoder<ItestAltOutpObject>(testAltOutpEncoder.Factory)
      .AddEncoder<ItestAltAltOutpObject>(testAltAltOutpEncoder.Factory)
      .AddEncoder<ItestAltDescrDualObject>(testAltDescrDualEncoder.Factory)
      .AddEncoder<ItestAltDescrOutpObject>(testAltDescrOutpEncoder.Factory)
      .AddEncoder<ItestAltDualDualObject>(testAltDualDualEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualDualObject>(testObjDualAltDualDualEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualInpObject>(testObjDualAltDualInpEncoder.Factory)
      .AddEncoder<ItestAltDualOutpObject>(testAltDualOutpEncoder.Factory)
      .AddEncoder<ItestObjDualAltDualOutpObject>(testObjDualAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltEnumDualObject>(testAltEnumDualEncoder.Factory)
      .AddEncoder<testEnumAltEnumDual>(testEnumAltEnumDualEncoder.Factory)
      .AddEncoder<testEnumAltEnumInp>(testEnumAltEnumInpEncoder.Factory)
      .AddEncoder<ItestAltEnumOutpObject>(testAltEnumOutpEncoder.Factory)
      .AddEncoder<testEnumAltEnumOutp>(testEnumAltEnumOutpEncoder.Factory)
      .AddEncoder<ItestAltModBoolDualObject>(testAltModBoolDualEncoder.Factory)
      .AddEncoder<ItestAltAltModBoolDualObject>(testAltAltModBoolDualEncoder.Factory)
      .AddEncoder<ItestAltModBoolOutpObject>(testAltModBoolOutpEncoder.Factory)
      .AddEncoder<ItestAltAltModBoolOutpObject>(testAltAltModBoolOutpEncoder.Factory)
      .AddEncoder<ItestAltAltModParamDualObject>(testAltAltModParamDualEncoder.Factory)
      .AddEncoder<ItestAltAltModParamOutpObject>(testAltAltModParamOutpEncoder.Factory)
      .AddEncoder<ItestAltSmplDualObject>(testAltSmplDualEncoder.Factory)
      .AddEncoder<ItestAltSmplOutpObject>(testAltSmplOutpEncoder.Factory)
      .AddEncoder<ItestCnstAltDmnDualObject>(testCnstAltDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnDual>(testDomCnstAltDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnInp>(testDomCnstAltDmnInpEncoder.Factory)
      .AddEncoder<ItestCnstAltDmnOutpObject>(testCnstAltDmnOutpEncoder.Factory)
      .AddEncoder<ItestDomCnstAltDmnOutp>(testDomCnstAltDmnOutpEncoder.Factory)
      .AddEncoder<ItestCnstAltDualDualObject>(testCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualDualObject>(testPrntCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualDualObject>(testAltCnstAltDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualInpObject>(testPrntCnstAltDualInpEncoder.Factory)
      .AddEncoder<ItestCnstAltDualOutpObject>(testCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltDualOutpObject>(testPrntCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltDualOutpObject>(testAltCnstAltDualOutpEncoder.Factory)
      .AddEncoder<ItestCnstAltObjDualObject>(testCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltObjDualObject>(testPrntCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestAltCnstAltObjDualObject>(testAltCnstAltObjDualEncoder.Factory)
      .AddEncoder<ItestCnstAltObjOutpObject>(testCnstAltObjOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstAltObjOutpObject>(testPrntCnstAltObjOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstAltObjOutpObject>(testAltCnstAltObjOutpEncoder.Factory)
      .AddEncoder<ItestCnstDomEnumDualObject>(testCnstDomEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumDual>(testEnumCnstDomEnumDualEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumDual>(testJustCnstDomEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumInp>(testEnumCnstDomEnumInpEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumInp>(testJustCnstDomEnumInpEncoder.Factory)
      .AddEncoder<ItestCnstDomEnumOutpObject>(testCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<testEnumCnstDomEnumOutp>(testEnumCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<ItestJustCnstDomEnumOutp>(testJustCnstDomEnumOutpEncoder.Factory)
      .AddEncoder<ItestCnstEnumDualObject>(testCnstEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstEnumDual>(testEnumCnstEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstEnumInp>(testEnumCnstEnumInpEncoder.Factory)
      .AddEncoder<ItestCnstEnumOutpObject>(testCnstEnumOutpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumOutp>(testEnumCnstEnumOutpEncoder.Factory)
      .AddEncoder<ItestCnstEnumPrntDualObject>(testCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntDual>(testEnumCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntDual>(testParentCnstEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntInp>(testEnumCnstEnumPrntInpEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntInp>(testParentCnstEnumPrntInpEncoder.Factory)
      .AddEncoder<ItestCnstEnumPrntOutpObject>(testCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumCnstEnumPrntOutp>(testEnumCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<testParentCnstEnumPrntOutp>(testParentCnstEnumPrntOutpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDmnDualObject>(testCnstFieldDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnDual>(testDomCnstFieldDmnDualEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnInp>(testDomCnstFieldDmnInpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDmnOutpObject>(testCnstFieldDmnOutpEncoder.Factory)
      .AddEncoder<ItestDomCnstFieldDmnOutp>(testDomCnstFieldDmnOutpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDualDualObject>(testCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualDualObject>(testPrntCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualDualObject>(testAltCnstFieldDualDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualInpObject>(testPrntCnstFieldDualInpEncoder.Factory)
      .AddEncoder<ItestCnstFieldDualOutpObject>(testCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldDualOutpObject>(testPrntCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldDualOutpObject>(testAltCnstFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestCnstFieldObjDualObject>(testCnstFieldObjDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldObjDualObject>(testPrntCnstFieldObjDualEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldObjDualObject>(testAltCnstFieldObjDualEncoder.Factory)
      .AddEncoder<ItestCnstFieldObjOutpObject>(testCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstFieldObjOutpObject>(testPrntCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstFieldObjOutpObject>(testAltCnstFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualGrndDualObject>(testCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndDualObject>(testGrndCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndDualObject>(testPrntCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndDualObject>(testAltCnstPrntDualGrndDualEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndInpObject>(testGrndCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndInpObject>(testPrntCnstPrntDualGrndInpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualGrndOutpObject>(testCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestGrndCnstPrntDualGrndOutpObject>(testGrndCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualGrndOutpObject>(testPrntCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualGrndOutpObject>(testAltCnstPrntDualGrndOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualPrntDualObject>(testCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntDualObject>(testPrntCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntDualObject>(testAltCnstPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntInpObject>(testPrntCnstPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestCnstPrntDualPrntOutpObject>(testCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntDualPrntOutpObject>(testPrntCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntDualPrntOutpObject>(testAltCnstPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntEnumDualObject>(testCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumDual>(testEnumCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumDual>(testParentCnstPrntEnumDualEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumInp>(testEnumCnstPrntEnumInpEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumInp>(testParentCnstPrntEnumInpEncoder.Factory)
      .AddEncoder<ItestCnstPrntEnumOutpObject>(testCnstPrntEnumOutpEncoder.Factory)
      .AddEncoder<testEnumCnstPrntEnumOutp>(testEnumCnstPrntEnumOutpEncoder.Factory)
      .AddEncoder<testParentCnstPrntEnumOutp>(testParentCnstPrntEnumOutpEncoder.Factory)
      .AddEncoder<ItestCnstPrntObjPrntDualObject>(testCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntDualObject>(testPrntCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntDualObject>(testAltCnstPrntObjPrntDualEncoder.Factory)
      .AddEncoder<ItestCnstPrntObjPrntOutpObject>(testCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntCnstPrntObjPrntOutpObject>(testPrntCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltCnstPrntObjPrntOutpObject>(testAltCnstPrntObjPrntOutpEncoder.Factory)
      .AddEncoder<ItestFieldDualObject>(testFieldDualEncoder.Factory)
      .AddEncoder<ItestFieldOutpObject>(testFieldOutpEncoder.Factory)
      .AddEncoder<ItestFieldDescrDualObject>(testFieldDescrDualEncoder.Factory)
      .AddEncoder<ItestFieldDescrOutpObject>(testFieldDescrOutpEncoder.Factory)
      .AddEncoder<ItestFieldDualDualObject>(testFieldDualDualEncoder.Factory)
      .AddEncoder<ItestFldFieldDualDualObject>(testFldFieldDualDualEncoder.Factory)
      .AddEncoder<ItestFldFieldDualInpObject>(testFldFieldDualInpEncoder.Factory)
      .AddEncoder<ItestFieldDualOutpObject>(testFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestFldFieldDualOutpObject>(testFldFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestFieldEnumDualObject>(testFieldEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumDual>(testEnumFieldEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumInp>(testEnumFieldEnumInpEncoder.Factory)
      .AddEncoder<ItestFieldEnumOutpObject>(testFieldEnumOutpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumOutp>(testEnumFieldEnumOutpEncoder.Factory)
      .AddEncoder<ItestFieldEnumPrntDualObject>(testFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntDual>(testEnumFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntDual>(testPrntFieldEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntInp>(testEnumFieldEnumPrntInpEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntInp>(testPrntFieldEnumPrntInpEncoder.Factory)
      .AddEncoder<ItestFieldEnumPrntOutpObject>(testFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumFieldEnumPrntOutp>(testEnumFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<testPrntFieldEnumPrntOutp>(testPrntFieldEnumPrntOutpEncoder.Factory)
      .AddEncoder<ItestFieldModEnumDualObject>(testFieldModEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumDual>(testEnumFieldModEnumDualEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumInp>(testEnumFieldModEnumInpEncoder.Factory)
      .AddEncoder<ItestFieldModEnumOutpObject>(testFieldModEnumOutpEncoder.Factory)
      .AddEncoder<testEnumFieldModEnumOutp>(testEnumFieldModEnumOutpEncoder.Factory)
      .AddEncoder<ItestFldFieldModParamDualObject>(testFldFieldModParamDualEncoder.Factory)
      .AddEncoder<ItestFldFieldModParamOutpObject>(testFldFieldModParamOutpEncoder.Factory)
      .AddEncoder<ItestFieldObjDualObject>(testFieldObjDualEncoder.Factory)
      .AddEncoder<ItestFldFieldObjDualObject>(testFldFieldObjDualEncoder.Factory)
      .AddEncoder<ItestFieldObjOutpObject>(testFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestFldFieldObjOutpObject>(testFldFieldObjOutpEncoder.Factory)
      .AddEncoder<ItestFieldSmplDualObject>(testFieldSmplDualEncoder.Factory)
      .AddEncoder<ItestFieldSmplOutpObject>(testFieldSmplOutpEncoder.Factory)
      .AddEncoder<ItestFieldTypeDescrDualObject>(testFieldTypeDescrDualEncoder.Factory)
      .AddEncoder<ItestFieldTypeDescrOutpObject>(testFieldTypeDescrOutpEncoder.Factory)
      .AddEncoder<ItestFieldValueDualObject>(testFieldValueDualEncoder.Factory)
      .AddEncoder<testEnumFieldValueDual>(testEnumFieldValueDualEncoder.Factory)
      .AddEncoder<testEnumFieldValueInp>(testEnumFieldValueInpEncoder.Factory)
      .AddEncoder<ItestFieldValueOutpObject>(testFieldValueOutpEncoder.Factory)
      .AddEncoder<testEnumFieldValueOutp>(testEnumFieldValueOutpEncoder.Factory)
      .AddEncoder<ItestFieldValueDescrDualObject>(testFieldValueDescrDualEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrDual>(testEnumFieldValueDescrDualEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrInp>(testEnumFieldValueDescrInpEncoder.Factory)
      .AddEncoder<ItestFieldValueDescrOutpObject>(testFieldValueDescrOutpEncoder.Factory)
      .AddEncoder<testEnumFieldValueDescrOutp>(testEnumFieldValueDescrOutpEncoder.Factory)
      .AddEncoder<ItestGnrcAltDualDualObject>(testGnrcAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualDualObject>(testAltGnrcAltDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualInpObject>(testAltGnrcAltDualInpEncoder.Factory)
      .AddEncoder<ItestGnrcAltDualOutpObject>(testGnrcAltDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltDualOutpObject>(testAltGnrcAltDualOutpEncoder.Factory)
      .AddEncoder<ItestGnrcAltParamDualObject>(testGnrcAltParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamDualObject>(testAltGnrcAltParamDualEncoder.Factory)
      .AddEncoder<ItestGnrcAltParamOutpObject>(testGnrcAltParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcAltParamOutpObject>(testAltGnrcAltParamOutpEncoder.Factory)
      .AddEncoder<ItestGnrcAltSmplDualObject>(testGnrcAltSmplDualEncoder.Factory)
      .AddEncoder<ItestGnrcAltSmplOutpObject>(testGnrcAltSmplOutpEncoder.Factory)
      .AddEncoder<ItestGnrcEnumDualObject>(testGnrcEnumDualEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumDual>(testEnumGnrcEnumDualEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumInp>(testEnumGnrcEnumInpEncoder.Factory)
      .AddEncoder<ItestGnrcEnumOutpObject>(testGnrcEnumOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcEnumOutp>(testEnumGnrcEnumOutpEncoder.Factory)
      .AddEncoder<ItestGnrcFieldDualDualObject>(testGnrcFieldDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualDualObject>(testAltGnrcFieldDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualInpObject>(testAltGnrcFieldDualInpEncoder.Factory)
      .AddEncoder<ItestGnrcFieldDualOutpObject>(testGnrcFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldDualOutpObject>(testAltGnrcFieldDualOutpEncoder.Factory)
      .AddEncoder<ItestGnrcFieldParamDualObject>(testGnrcFieldParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamDualObject>(testAltGnrcFieldParamDualEncoder.Factory)
      .AddEncoder<ItestGnrcFieldParamOutpObject>(testGnrcFieldParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcFieldParamOutpObject>(testAltGnrcFieldParamOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualDualObject>(testGnrcPrntDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualDualObject>(testAltGnrcPrntDualDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualInpObject>(testAltGnrcPrntDualInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualOutpObject>(testGnrcPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualOutpObject>(testAltGnrcPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualPrntDualObject>(testGnrcPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntDualObject>(testAltGnrcPrntDualPrntDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntInpObject>(testAltGnrcPrntDualPrntInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntDualPrntOutpObject>(testGnrcPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntDualPrntOutpObject>(testAltGnrcPrntDualPrntOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumChildDualObject>(testGnrcPrntEnumChildDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumChildDual>(testEnumGnrcPrntEnumChildDualEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildDual>(testParentGnrcPrntEnumChildDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumChildInp>(testEnumGnrcPrntEnumChildInpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildInp>(testParentGnrcPrntEnumChildInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumChildOutpObject>(testGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumChildOutp>(testEnumGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumChildOutp>(testParentGnrcPrntEnumChildOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumDomDualObject>(testGnrcPrntEnumDomDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomDual>(testEnumGnrcPrntEnumDomDualEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomDual>(testDomGnrcPrntEnumDomDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomInp>(testEnumGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomInp>(testDomGnrcPrntEnumDomInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumDomOutpObject>(testGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumDomOutp>(testEnumGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntEnumDomOutp>(testDomGnrcPrntEnumDomOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumPrntDualObject>(testGnrcPrntEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumPrntDual>(testEnumGnrcPrntEnumPrntDualEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntDual>(testParentGnrcPrntEnumPrntDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumPrntInp>(testEnumGnrcPrntEnumPrntInpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntInp>(testParentGnrcPrntEnumPrntInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntEnumPrntOutpObject>(testGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntEnumPrntOutp>(testEnumGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<testParentGnrcPrntEnumPrntOutp>(testParentGnrcPrntEnumPrntOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamDualObject>(testGnrcPrntParamDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamDualObject>(testAltGnrcPrntParamDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamOutpObject>(testGnrcPrntParamOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamOutpObject>(testAltGnrcPrntParamOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamPrntDualObject>(testGnrcPrntParamPrntDualEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamPrntDualObject>(testAltGnrcPrntParamPrntDualEncoder.Factory)
      .AddEncoder<ItestGnrcPrntParamPrntOutpObject>(testGnrcPrntParamPrntOutpEncoder.Factory)
      .AddEncoder<ItestAltGnrcPrntParamPrntOutpObject>(testAltGnrcPrntParamPrntOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntSmplEnumDualObject>(testGnrcPrntSmplEnumDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumDual>(testEnumGnrcPrntSmplEnumDualEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumInp>(testEnumGnrcPrntSmplEnumInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntSmplEnumOutpObject>(testGnrcPrntSmplEnumOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcPrntSmplEnumOutp>(testEnumGnrcPrntSmplEnumOutpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntStrDomDualObject>(testGnrcPrntStrDomDualEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntStrDomDual>(testDomGnrcPrntStrDomDualEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntStrDomInp>(testDomGnrcPrntStrDomInpEncoder.Factory)
      .AddEncoder<ItestGnrcPrntStrDomOutpObject>(testGnrcPrntStrDomOutpEncoder.Factory)
      .AddEncoder<ItestDomGnrcPrntStrDomOutp>(testDomGnrcPrntStrDomOutpEncoder.Factory)
      .AddEncoder<ItestGnrcValueDualObject>(testGnrcValueDualEncoder.Factory)
      .AddEncoder<testEnumGnrcValueDual>(testEnumGnrcValueDualEncoder.Factory)
      .AddEncoder<testEnumGnrcValueInp>(testEnumGnrcValueInpEncoder.Factory)
      .AddEncoder<ItestGnrcValueOutpObject>(testGnrcValueOutpEncoder.Factory)
      .AddEncoder<testEnumGnrcValueOutp>(testEnumGnrcValueOutpEncoder.Factory)
      .AddEncoder<testEnumInpFieldEnum>(testEnumInpFieldEnumEncoder.Factory)
      .AddEncoder<ItestFldInpFieldNullObject>(testFldInpFieldNullEncoder.Factory)
      .AddEncoder<ItestOutpDescrParamObject>(testOutpDescrParamEncoder.Factory)
      .AddEncoder<ItestFldOutpDescrParamObject>(testFldOutpDescrParamEncoder.Factory)
      .AddEncoder<ItestOutpParamObject>(testOutpParamEncoder.Factory)
      .AddEncoder<ItestFldOutpParamObject>(testFldOutpParamEncoder.Factory)
      .AddEncoder<ItestOutpParamDescrObject>(testOutpParamDescrEncoder.Factory)
      .AddEncoder<ItestFldOutpParamDescrObject>(testFldOutpParamDescrEncoder.Factory)
      .AddEncoder<ItestOutpParamModDmnObject>(testOutpParamModDmnEncoder.Factory)
      .AddEncoder<ItestDomOutpParamModDmn>(testDomOutpParamModDmnEncoder.Factory)
      .AddEncoder<ItestDomOutpParamModParam>(testDomOutpParamModParamEncoder.Factory)
      .AddEncoder<ItestOutpParamTypeDescrObject>(testOutpParamTypeDescrEncoder.Factory)
      .AddEncoder<ItestFldOutpParamTypeDescrObject>(testFldOutpParamTypeDescrEncoder.Factory)
      .AddEncoder<ItestOutpPrntGnrcObject>(testOutpPrntGnrcEncoder.Factory)
      .AddEncoder<testEnumOutpPrntGnrc>(testEnumOutpPrntGnrcEncoder.Factory)
      .AddEncoder<testPrntOutpPrntGnrc>(testPrntOutpPrntGnrcEncoder.Factory)
      .AddEncoder<ItestOutpPrntParamObject>(testOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestPrntOutpPrntParamObject>(testPrntOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestFldOutpPrntParamObject>(testFldOutpPrntParamEncoder.Factory)
      .AddEncoder<ItestPrntDualObject>(testPrntDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDualObject>(testRefPrntDualEncoder.Factory)
      .AddEncoder<ItestPrntOutpObject>(testPrntOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntOutpObject>(testRefPrntOutpEncoder.Factory)
      .AddEncoder<ItestPrntAltDualObject>(testPrntAltDualEncoder.Factory)
      .AddEncoder<ItestRefPrntAltDualObject>(testRefPrntAltDualEncoder.Factory)
      .AddEncoder<ItestPrntAltOutpObject>(testPrntAltOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntAltOutpObject>(testRefPrntAltOutpEncoder.Factory)
      .AddEncoder<ItestPrntDescrDualObject>(testPrntDescrDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDescrDualObject>(testRefPrntDescrDualEncoder.Factory)
      .AddEncoder<ItestPrntDescrOutpObject>(testPrntDescrOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntDescrOutpObject>(testRefPrntDescrOutpEncoder.Factory)
      .AddEncoder<ItestPrntDualDualObject>(testPrntDualDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDualDualObject>(testRefPrntDualDualEncoder.Factory)
      .AddEncoder<ItestRefPrntDualInpObject>(testRefPrntDualInpEncoder.Factory)
      .AddEncoder<ItestPrntDualOutpObject>(testPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntDualOutpObject>(testRefPrntDualOutpEncoder.Factory)
      .AddEncoder<ItestPrntFieldDualObject>(testPrntFieldDualEncoder.Factory)
      .AddEncoder<ItestRefPrntFieldDualObject>(testRefPrntFieldDualEncoder.Factory)
      .AddEncoder<ItestPrntFieldOutpObject>(testPrntFieldOutpEncoder.Factory)
      .AddEncoder<ItestRefPrntFieldOutpObject>(testRefPrntFieldOutpEncoder.Factory);
}
