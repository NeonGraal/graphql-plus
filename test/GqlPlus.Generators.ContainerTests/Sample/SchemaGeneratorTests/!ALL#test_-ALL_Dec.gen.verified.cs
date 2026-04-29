//HintName: test_-ALL_Dec.gen.cs
// Generated from {CurrentDirectory}-ALL.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__ALL;

internal class testInDrctParamDictDecoder
{

  internal static testInDrctParamDictDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamInDecoder
{

  internal static testInDrctParamInDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamListDecoder
{

  internal static testInDrctParamListDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamOptDecoder
{

  internal static testInDrctParamOptDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDualDecoder
{

  internal static testAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltInpDecoder
{

  internal static testAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDescrDualDecoder
{

  internal static testAltDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDescrInpDecoder
{

  internal static testAltDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDualDualDecoder
{

  internal static testAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testObjDualAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDualInpDecoder
{

  internal static testAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testObjDualAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualOutpDecoder
{
  public decimal Alt { get; set; }

  internal static testObjDualAltDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltEnumDualDecoder
{

  internal static testAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumDualDecoder : IDecoder<testEnumAltEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumAltEnumDual? output)
    => input.DecodeEnum("EnumAltEnumDual", out output);

  internal static testEnumAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltEnumInpDecoder
{

  internal static testAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumInpDecoder : IDecoder<testEnumAltEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumAltEnumInp? output)
    => input.DecodeEnum("EnumAltEnumInp", out output);

  internal static testEnumAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumOutpDecoder : IDecoder<testEnumAltEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumAltEnumOutp? output)
    => input.DecodeEnum("EnumAltEnumOutp", out output);

  internal static testEnumAltEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModBoolDualDecoder
{

  internal static testAltModBoolDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltModBoolDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltModBoolDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModBoolInpDecoder
{

  internal static testAltModBoolInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltModBoolInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltModBoolInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModParamDualDecoder<TMod>
{
}

internal class testAltAltModParamDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltModParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModParamInpDecoder<TMod>
{
}

internal class testAltAltModParamInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltAltModParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltSmplDualDecoder
{

  internal static testAltSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltSmplInpDecoder
{

  internal static testAltSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDualDecoder<TType>
{
}

internal class testCnstAltInpDecoder<TType>
{
}

internal class testCnstAltDmnDualDecoder
{

  internal static testCnstAltDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDmnDualDecoder<TRef>
{
}

internal class testDomCnstAltDmnDualDecoder
{

  internal static testDomCnstAltDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDmnInpDecoder
{

  internal static testCnstAltDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDmnInpDecoder<TRef>
{
}

internal class testDomCnstAltDmnInpDecoder
{

  internal static testDomCnstAltDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomCnstAltDmnOutpDecoder
{

  internal static testDomCnstAltDmnOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDualDualDecoder
{

  internal static testCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDualDualDecoder<TRef>
{
}

internal class testPrntCnstAltDualDualDecoder
{

  internal static testPrntCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDualInpDecoder
{

  internal static testCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDualInpDecoder<TRef>
{
}

internal class testPrntCnstAltDualInpDecoder
{

  internal static testPrntCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstAltDualOutpDecoder
{

  internal static testPrntCnstAltDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltObjDualDecoder
{

  internal static testCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltObjDualDecoder<TRef>
{
}

internal class testPrntCnstAltObjDualDecoder
{

  internal static testPrntCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltObjDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltObjInpDecoder
{

  internal static testCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltObjInpDecoder<TRef>
{
}

internal class testPrntCnstAltObjInpDecoder
{

  internal static testPrntCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltObjInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstDomEnumDualDecoder
{

  internal static testCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstDomEnumDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstDomEnumDualDecoder : IDecoder<testEnumCnstDomEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumCnstDomEnumDual? output)
    => input.DecodeEnum("EnumCnstDomEnumDual", out output);

  internal static testEnumCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumDualDecoder
{

  internal static testJustCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstDomEnumInpDecoder
{

  internal static testCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstDomEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstDomEnumInpDecoder : IDecoder<testEnumCnstDomEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstDomEnumInp? output)
    => input.DecodeEnum("EnumCnstDomEnumInp", out output);

  internal static testEnumCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumInpDecoder
{

  internal static testJustCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstDomEnumOutpDecoder : IDecoder<testEnumCnstDomEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstDomEnumOutp? output)
    => input.DecodeEnum("EnumCnstDomEnumOutp", out output);

  internal static testEnumCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpDecoder
{

  internal static testJustCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumDualDecoder
{

  internal static testCnstEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumDualDecoder : IDecoder<testEnumCnstEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumDual? output)
    => input.DecodeEnum("EnumCnstEnumDual", out output);

  internal static testEnumCnstEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumInpDecoder
{

  internal static testCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumInpDecoder : IDecoder<testEnumCnstEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumInp? output)
    => input.DecodeEnum("EnumCnstEnumInp", out output);

  internal static testEnumCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstEnumOutpDecoder : IDecoder<testEnumCnstEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumOutp? output)
    => input.DecodeEnum("EnumCnstEnumOutp", out output);

  internal static testEnumCnstEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumPrntDualDecoder
{

  internal static testCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumPrntDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumPrntDualDecoder : IDecoder<testEnumCnstEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumPrntDual? output)
    => input.DecodeEnum("EnumCnstEnumPrntDual", out output);

  internal static testEnumCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntDualDecoder : IDecoder<testParentCnstEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testParentCnstEnumPrntDual? output)
    => input.DecodeEnum("ParentCnstEnumPrntDual", out output);

  internal static testParentCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumPrntInpDecoder
{

  internal static testCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumPrntInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstEnumPrntInpDecoder : IDecoder<testEnumCnstEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumPrntInp? output)
    => input.DecodeEnum("EnumCnstEnumPrntInp", out output);

  internal static testEnumCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpDecoder : IDecoder<testParentCnstEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testParentCnstEnumPrntInp? output)
    => input.DecodeEnum("ParentCnstEnumPrntInp", out output);

  internal static testParentCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstEnumPrntOutpDecoder : IDecoder<testEnumCnstEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstEnumPrntOutp? output)
    => input.DecodeEnum("EnumCnstEnumPrntOutp", out output);

  internal static testEnumCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpDecoder : IDecoder<testParentCnstEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testParentCnstEnumPrntOutp? output)
    => input.DecodeEnum("ParentCnstEnumPrntOutp", out output);

  internal static testParentCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDmnDualDecoder
{

  internal static testCnstFieldDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDmnDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testDomCnstFieldDmnDualDecoder
{

  internal static testDomCnstFieldDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDmnInpDecoder
{

  internal static testCnstFieldDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDmnInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testDomCnstFieldDmnInpDecoder
{

  internal static testDomCnstFieldDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomCnstFieldDmnOutpDecoder
{

  internal static testDomCnstFieldDmnOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDualDualDecoder
{

  internal static testCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDualDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldDualDualDecoder
{

  internal static testPrntCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDualInpDecoder
{

  internal static testCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDualInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldDualInpDecoder
{

  internal static testPrntCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstFieldDualOutpDecoder
{

  internal static testPrntCnstFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldObjDualDecoder
{

  internal static testCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldObjDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldObjDualDecoder
{

  internal static testPrntCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldObjDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldObjInpDecoder
{

  internal static testCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldObjInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testPrntCnstFieldObjInpDecoder
{

  internal static testPrntCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldObjInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualGrndDualDecoder
{

  internal static testCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualGrndDualDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndDualDecoder
{

  internal static testGrndCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndDualDecoder
{

  internal static testPrntCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualGrndDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualGrndInpDecoder
{

  internal static testCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualGrndInpDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndInpDecoder
{

  internal static testGrndCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndInpDecoder
{

  internal static testPrntCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualGrndInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGrndCnstPrntDualGrndOutpDecoder
{

  internal static testGrndCnstPrntDualGrndOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndOutpDecoder
{

  internal static testPrntCnstPrntDualGrndOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualPrntDualDecoder
{

  internal static testCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntDualDecoder
{

  internal static testPrntCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualPrntInpDecoder
{

  internal static testCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntInpDecoder
{

  internal static testPrntCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualPrntOutpDecoder
{

  internal static testPrntCnstPrntDualPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntEnumDualDecoder
{

  internal static testCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntEnumDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstPrntEnumDualDecoder : IDecoder<testEnumCnstPrntEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumCnstPrntEnumDual? output)
    => input.DecodeEnum("EnumCnstPrntEnumDual", out output);

  internal static testEnumCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumDualDecoder : IDecoder<testParentCnstPrntEnumDual?>
{
  public IMessages Decoder(IValue input, out testParentCnstPrntEnumDual? output)
    => input.DecodeEnum("ParentCnstPrntEnumDual", out output);

  internal static testParentCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntEnumInpDecoder
{

  internal static testCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumCnstPrntEnumInpDecoder : IDecoder<testEnumCnstPrntEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstPrntEnumInp? output)
    => input.DecodeEnum("EnumCnstPrntEnumInp", out output);

  internal static testEnumCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpDecoder : IDecoder<testParentCnstPrntEnumInp?>
{
  public IMessages Decoder(IValue input, out testParentCnstPrntEnumInp? output)
    => input.DecodeEnum("ParentCnstPrntEnumInp", out output);

  internal static testParentCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstPrntEnumOutpDecoder : IDecoder<testEnumCnstPrntEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumCnstPrntEnumOutp? output)
    => input.DecodeEnum("EnumCnstPrntEnumOutp", out output);

  internal static testEnumCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumOutpDecoder : IDecoder<testParentCnstPrntEnumOutp?>
{
  public IMessages Decoder(IValue input, out testParentCnstPrntEnumOutp? output)
    => input.DecodeEnum("ParentCnstPrntEnumOutp", out output);

  internal static testParentCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntObjPrntDualDecoder
{

  internal static testCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntObjPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntDualDecoder
{

  internal static testPrntCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntObjPrntInpDecoder
{

  internal static testCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntObjPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntInpDecoder
{

  internal static testPrntCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDualDecoder
{
  public string Field { get; set; }

  internal static testFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldInpDecoder
{
  public string Field { get; set; }

  internal static testFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDescrDualDecoder
{
  public string Field { get; set; }

  internal static testFieldDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDescrInpDecoder
{
  public string Field { get; set; }

  internal static testFieldDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDualDualDecoder
{
  public ItestFldFieldDualDual Field { get; set; }

  internal static testFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldDualDualDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDualInpDecoder
{
  public ItestFldFieldDualInp Field { get; set; }

  internal static testFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldDualInpDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldDualOutpDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumDualDecoder
{
  public testEnumFieldEnumDual Field { get; set; }

  internal static testFieldEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumDualDecoder : IDecoder<testEnumFieldEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumDual? output)
    => input.DecodeEnum("EnumFieldEnumDual", out output);

  internal static testEnumFieldEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumInpDecoder
{
  public testEnumFieldEnumInp Field { get; set; }

  internal static testFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumInpDecoder : IDecoder<testEnumFieldEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumInp? output)
    => input.DecodeEnum("EnumFieldEnumInp", out output);

  internal static testEnumFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumOutpDecoder : IDecoder<testEnumFieldEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumOutp? output)
    => input.DecodeEnum("EnumFieldEnumOutp", out output);

  internal static testEnumFieldEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumPrntDualDecoder
{
  public testEnumFieldEnumPrntDual Field { get; set; }

  internal static testFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualDecoder : IDecoder<testEnumFieldEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumPrntDual? output)
    => input.DecodeEnum("EnumFieldEnumPrntDual", out output);

  internal static testEnumFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualDecoder : IDecoder<testPrntFieldEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testPrntFieldEnumPrntDual? output)
    => input.DecodeEnum("PrntFieldEnumPrntDual", out output);

  internal static testPrntFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumPrntInpDecoder
{
  public testEnumFieldEnumPrntInp Field { get; set; }

  internal static testFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntInpDecoder : IDecoder<testEnumFieldEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumPrntInp? output)
    => input.DecodeEnum("EnumFieldEnumPrntInp", out output);

  internal static testEnumFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpDecoder : IDecoder<testPrntFieldEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testPrntFieldEnumPrntInp? output)
    => input.DecodeEnum("PrntFieldEnumPrntInp", out output);

  internal static testPrntFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntOutpDecoder : IDecoder<testEnumFieldEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldEnumPrntOutp? output)
    => input.DecodeEnum("EnumFieldEnumPrntOutp", out output);

  internal static testEnumFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpDecoder : IDecoder<testPrntFieldEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testPrntFieldEnumPrntOutp? output)
    => input.DecodeEnum("PrntFieldEnumPrntOutp", out output);

  internal static testPrntFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModEnumDualDecoder
{
  public IDictionary<testEnumFieldModEnumDual, string> Field { get; set; }

  internal static testFieldModEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumDualDecoder : IDecoder<testEnumFieldModEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumFieldModEnumDual? output)
    => input.DecodeEnum("EnumFieldModEnumDual", out output);

  internal static testEnumFieldModEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModEnumInpDecoder
{
  public IDictionary<testEnumFieldModEnumInp, string> Field { get; set; }

  internal static testFieldModEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumInpDecoder : IDecoder<testEnumFieldModEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldModEnumInp? output)
    => input.DecodeEnum("EnumFieldModEnumInp", out output);

  internal static testEnumFieldModEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumOutpDecoder : IDecoder<testEnumFieldModEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldModEnumOutp? output)
    => input.DecodeEnum("EnumFieldModEnumOutp", out output);

  internal static testEnumFieldModEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModParamDualDecoder<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamDual> Field { get; set; }
}

internal class testFldFieldModParamDualDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldModParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModParamInpDecoder<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp> Field { get; set; }
}

internal class testFldFieldModParamInpDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldModParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldObjDualDecoder
{
  public ItestFldFieldObjDual Field { get; set; }

  internal static testFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldObjDualDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldObjInpDecoder
{
  public ItestFldFieldObjInp Field { get; set; }

  internal static testFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldObjInpDecoder
{
  public decimal Field { get; set; }

  internal static testFldFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldSmplDualDecoder
{
  public decimal Field { get; set; }

  internal static testFieldSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldSmplInpDecoder
{
  public decimal Field { get; set; }

  internal static testFieldSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldTypeDescrDualDecoder
{
  public decimal Field { get; set; }

  internal static testFieldTypeDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldTypeDescrInpDecoder
{
  public decimal Field { get; set; }

  internal static testFieldTypeDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueDualDecoder
{
  public testEnumFieldValueDual Field { get; set; }

  internal static testFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDualDecoder : IDecoder<testEnumFieldValueDual?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueDual? output)
    => input.DecodeEnum("EnumFieldValueDual", out output);

  internal static testEnumFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueInpDecoder
{
  public testEnumFieldValueInp Field { get; set; }

  internal static testFieldValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueInpDecoder : IDecoder<testEnumFieldValueInp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueInp? output)
    => input.DecodeEnum("EnumFieldValueInp", out output);

  internal static testEnumFieldValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueOutpDecoder : IDecoder<testEnumFieldValueOutp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueOutp? output)
    => input.DecodeEnum("EnumFieldValueOutp", out output);

  internal static testEnumFieldValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueDescrDualDecoder
{
  public testEnumFieldValueDescrDual Field { get; set; }

  internal static testFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrDualDecoder : IDecoder<testEnumFieldValueDescrDual?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueDescrDual? output)
    => input.DecodeEnum("EnumFieldValueDescrDual", out output);

  internal static testEnumFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueDescrInpDecoder
{
  public testEnumFieldValueDescrInp Field { get; set; }

  internal static testFieldValueDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrInpDecoder : IDecoder<testEnumFieldValueDescrInp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueDescrInp? output)
    => input.DecodeEnum("EnumFieldValueDescrInp", out output);

  internal static testEnumFieldValueDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrOutpDecoder : IDecoder<testEnumFieldValueDescrOutp?>
{
  public IMessages Decoder(IValue input, out testEnumFieldValueDescrOutp? output)
    => input.DecodeEnum("EnumFieldValueDescrOutp", out output);

  internal static testEnumFieldValueDescrOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcAltDualDecoder<TType>
{
}

internal class testGnrcAltInpDecoder<TType>
{
}

internal class testGnrcAltArgDualDecoder<TType>
{
}

internal class testRefGnrcAltArgDualDecoder<TRef>
{
}

internal class testGnrcAltArgInpDecoder<TType>
{
}

internal class testRefGnrcAltArgInpDecoder<TRef>
{
}

internal class testGnrcAltArgDescrDualDecoder<TType>
{
}

internal class testRefGnrcAltArgDescrDualDecoder<TRef>
{
}

internal class testGnrcAltArgDescrInpDecoder<TType>
{
}

internal class testRefGnrcAltArgDescrInpDecoder<TRef>
{
}

internal class testGnrcAltDualDualDecoder
{

  internal static testGnrcAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltDualDualDecoder<TRef>
{
}

internal class testAltGnrcAltDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcAltDualInpDecoder
{

  internal static testGnrcAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltDualInpDecoder<TRef>
{
}

internal class testAltGnrcAltDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcAltDualOutpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltModParamDualDecoder<TRef,TMod>
{
}

internal class testRefGnrcAltModParamInpDecoder<TRef,TMod>
{
}

internal class testRefGnrcAltModStrDualDecoder<TRef>
{
}

internal class testRefGnrcAltModStrInpDecoder<TRef>
{
}

internal class testGnrcAltParamDualDecoder
{

  internal static testGnrcAltParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltParamDualDecoder<TRef>
{
}

internal class testAltGnrcAltParamDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcAltParamInpDecoder
{

  internal static testGnrcAltParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltParamInpDecoder<TRef>
{
}

internal class testAltGnrcAltParamInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcAltParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcAltSmplDualDecoder
{

  internal static testGnrcAltSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltSmplDualDecoder<TRef>
{
}

internal class testGnrcAltSmplInpDecoder
{

  internal static testGnrcAltSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltSmplInpDecoder<TRef>
{
}

internal class testGnrcDescrDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testGnrcDescrInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testGnrcEnumDualDecoder
{

  internal static testGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcEnumDualDecoder : IDecoder<testEnumGnrcEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcEnumDual? output)
    => input.DecodeEnum("EnumGnrcEnumDual", out output);

  internal static testEnumGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcEnumInpDecoder
{

  internal static testGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcEnumInpDecoder : IDecoder<testEnumGnrcEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcEnumInp? output)
    => input.DecodeEnum("EnumGnrcEnumInp", out output);

  internal static testEnumGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcEnumOutpDecoder : IDecoder<testEnumGnrcEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcEnumOutp? output)
    => input.DecodeEnum("EnumGnrcEnumOutp", out output);

  internal static testEnumGnrcEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testGnrcFieldInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testGnrcFieldArgDualDecoder<TType>
{
  public ItestRefGnrcFieldArgDual<TType> Field { get; set; }
}

internal class testRefGnrcFieldArgDualDecoder<TRef>
{
}

internal class testGnrcFieldArgInpDecoder<TType>
{
  public ItestRefGnrcFieldArgInp<TType> Field { get; set; }
}

internal class testRefGnrcFieldArgInpDecoder<TRef>
{
}

internal class testGnrcFieldDualDualDecoder
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }

  internal static testGnrcFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldDualDualDecoder<TRef>
{
}

internal class testAltGnrcFieldDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldDualInpDecoder
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }

  internal static testGnrcFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldDualInpDecoder<TRef>
{
}

internal class testAltGnrcFieldDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcFieldDualOutpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldParamDualDecoder
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }

  internal static testGnrcFieldParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldParamDualDecoder<TRef>
{
}

internal class testAltGnrcFieldParamDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldParamInpDecoder
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }

  internal static testGnrcFieldParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldParamInpDecoder<TRef>
{
}

internal class testAltGnrcFieldParamInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcFieldParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntDualDecoder<TType>
{
}

internal class testGnrcPrntInpDecoder<TType>
{
}

internal class testGnrcPrntArgDualDecoder<TType>
{
}

internal class testRefGnrcPrntArgDualDecoder<TRef>
{
}

internal class testGnrcPrntArgInpDecoder<TType>
{
}

internal class testRefGnrcPrntArgInpDecoder<TRef>
{
}

internal class testGnrcPrntDescrDualDecoder<TType>
{
}

internal class testGnrcPrntDescrInpDecoder<TType>
{
}

internal class testGnrcPrntDualDualDecoder
{

  internal static testGnrcPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualDualDecoder<TRef>
{
}

internal class testAltGnrcPrntDualDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntDualInpDecoder
{

  internal static testGnrcPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualInpDecoder<TRef>
{
}

internal class testAltGnrcPrntDualInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcPrntDualOutpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntDualPrntDualDecoder
{

  internal static testGnrcPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualPrntDualDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntDualPrntInpDecoder
{

  internal static testGnrcPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualPrntInpDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcPrntDualPrntOutpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntDualPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumChildDualDecoder
{

  internal static testGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumChildDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumChildDualDecoder : IDecoder<testEnumGnrcPrntEnumChildDual?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumChildDual? output)
    => input.DecodeEnum("EnumGnrcPrntEnumChildDual", out output);

  internal static testEnumGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildDualDecoder : IDecoder<testParentGnrcPrntEnumChildDual?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumChildDual? output)
    => input.DecodeEnum("ParentGnrcPrntEnumChildDual", out output);

  internal static testParentGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumChildInpDecoder
{

  internal static testGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumChildInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumChildInpDecoder : IDecoder<testEnumGnrcPrntEnumChildInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumChildInp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumChildInp", out output);

  internal static testEnumGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpDecoder : IDecoder<testParentGnrcPrntEnumChildInp?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumChildInp? output)
    => input.DecodeEnum("ParentGnrcPrntEnumChildInp", out output);

  internal static testParentGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumChildOutpDecoder : IDecoder<testEnumGnrcPrntEnumChildOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumChildOutp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumChildOutp", out output);

  internal static testEnumGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpDecoder : IDecoder<testParentGnrcPrntEnumChildOutp?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumChildOutp? output)
    => input.DecodeEnum("ParentGnrcPrntEnumChildOutp", out output);

  internal static testParentGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumDomDualDecoder
{

  internal static testGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomDualDecoder : IDecoder<testEnumGnrcPrntEnumDomDual?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumDomDual? output)
    => input.DecodeEnum("EnumGnrcPrntEnumDomDual", out output);

  internal static testEnumGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomDualDecoder
{

  internal static testDomGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumDomInpDecoder
{

  internal static testGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomInpDecoder : IDecoder<testEnumGnrcPrntEnumDomInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumDomInp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumDomInp", out output);

  internal static testEnumGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpDecoder
{

  internal static testDomGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumDomOutpDecoder : IDecoder<testEnumGnrcPrntEnumDomOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumDomOutp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumDomOutp", out output);

  internal static testEnumGnrcPrntEnumDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomOutpDecoder
{

  internal static testDomGnrcPrntEnumDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntDualDecoder
{

  internal static testGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumPrntDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumPrntDualDecoder : IDecoder<testEnumGnrcPrntEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumPrntDual? output)
    => input.DecodeEnum("EnumGnrcPrntEnumPrntDual", out output);

  internal static testEnumGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntDualDecoder : IDecoder<testParentGnrcPrntEnumPrntDual?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumPrntDual? output)
    => input.DecodeEnum("ParentGnrcPrntEnumPrntDual", out output);

  internal static testParentGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntInpDecoder
{

  internal static testGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumPrntInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntEnumPrntInpDecoder : IDecoder<testEnumGnrcPrntEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumPrntInp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumPrntInp", out output);

  internal static testEnumGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpDecoder : IDecoder<testParentGnrcPrntEnumPrntInp?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumPrntInp? output)
    => input.DecodeEnum("ParentGnrcPrntEnumPrntInp", out output);

  internal static testParentGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumPrntOutpDecoder : IDecoder<testEnumGnrcPrntEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntEnumPrntOutp? output)
    => input.DecodeEnum("EnumGnrcPrntEnumPrntOutp", out output);

  internal static testEnumGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpDecoder : IDecoder<testParentGnrcPrntEnumPrntOutp?>
{
  public IMessages Decoder(IValue input, out testParentGnrcPrntEnumPrntOutp? output)
    => input.DecodeEnum("ParentGnrcPrntEnumPrntOutp", out output);

  internal static testParentGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamDualDecoder
{

  internal static testGnrcPrntParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamDualDecoder<TRef>
{
}

internal class testAltGnrcPrntParamDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamInpDecoder
{

  internal static testGnrcPrntParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamInpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamPrntDualDecoder
{

  internal static testGnrcPrntParamPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamPrntDualDecoder<TRef>
{
}

internal class testAltGnrcPrntParamPrntDualDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntParamPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamPrntInpDecoder
{

  internal static testGnrcPrntParamPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamPrntInpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamPrntInpDecoder
{
  public decimal Alt { get; set; }

  internal static testAltGnrcPrntParamPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumDualDecoder
{

  internal static testGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntSmplEnumDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntSmplEnumDualDecoder : IDecoder<testEnumGnrcPrntSmplEnumDual?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntSmplEnumDual? output)
    => input.DecodeEnum("EnumGnrcPrntSmplEnumDual", out output);

  internal static testEnumGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumInpDecoder
{

  internal static testGnrcPrntSmplEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntSmplEnumInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testEnumGnrcPrntSmplEnumInpDecoder : IDecoder<testEnumGnrcPrntSmplEnumInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntSmplEnumInp? output)
    => input.DecodeEnum("EnumGnrcPrntSmplEnumInp", out output);

  internal static testEnumGnrcPrntSmplEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntSmplEnumOutpDecoder : IDecoder<testEnumGnrcPrntSmplEnumOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcPrntSmplEnumOutp? output)
    => input.DecodeEnum("EnumGnrcPrntSmplEnumOutp", out output);

  internal static testEnumGnrcPrntSmplEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntStrDomDualDecoder
{

  internal static testGnrcPrntStrDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntStrDomDualDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testDomGnrcPrntStrDomDualDecoder
{

  internal static testDomGnrcPrntStrDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntStrDomInpDecoder
{

  internal static testGnrcPrntStrDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntStrDomInpDecoder<TRef>
{
  public TRef Field { get; set; }
}

internal class testDomGnrcPrntStrDomInpDecoder
{

  internal static testDomGnrcPrntStrDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntStrDomOutpDecoder
{

  internal static testDomGnrcPrntStrDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcValueDualDecoder
{

  internal static testGnrcValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcValueDualDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcValueDualDecoder : IDecoder<testEnumGnrcValueDual?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcValueDual? output)
    => input.DecodeEnum("EnumGnrcValueDual", out output);

  internal static testEnumGnrcValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcValueInpDecoder
{

  internal static testGnrcValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcValueInpDecoder<TType>
{
  public TType Field { get; set; }
}

internal class testEnumGnrcValueInpDecoder : IDecoder<testEnumGnrcValueInp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcValueInp? output)
    => input.DecodeEnum("EnumGnrcValueInp", out output);

  internal static testEnumGnrcValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcValueOutpDecoder : IDecoder<testEnumGnrcValueOutp?>
{
  public IMessages Decoder(IValue input, out testEnumGnrcValueOutp? output)
    => input.DecodeEnum("EnumGnrcValueOutp", out output);

  internal static testEnumGnrcValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldDescrNmbrDecoder
{
  public decimal Field { get; set; }

  internal static testInpFieldDescrNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldEnumDecoder
{
  public testEnumInpFieldEnum Field { get; set; }

  internal static testInpFieldEnumDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumInpFieldEnumDecoder : IDecoder<testEnumInpFieldEnum?>
{
  public IMessages Decoder(IValue input, out testEnumInpFieldEnum? output)
    => input.DecodeEnum("EnumInpFieldEnum", out output);

  internal static testEnumInpFieldEnumDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldNullDecoder
{
  public ItestFldInpFieldNull? Field { get; set; }

  internal static testInpFieldNullDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldInpFieldNullDecoder
{

  internal static testFldInpFieldNullDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldNmbrDecoder
{
  public decimal Field { get; set; }

  internal static testInpFieldNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldNmbrDescrDecoder
{
  public decimal Field { get; set; }

  internal static testInpFieldNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldStrDecoder
{
  public string Field { get; set; }

  internal static testInpFieldStrDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpDescrParamDecoder
{

  internal static testFldOutpDescrParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpDescrParamDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpDescrParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpParamDecoder
{

  internal static testFldOutpParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpParamDescrDecoder
{

  internal static testFldOutpParamDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamDescrDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamModDmnDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomOutpParamModDmnDecoder
{

  internal static testDomOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamModParamDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamModParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomOutpParamModParamDecoder
{

  internal static testDomOutpParamModParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpParamTypeDescrDecoder
{

  internal static testFldOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamTypeDescrDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumOutpPrntGnrcDecoder : IDecoder<testEnumOutpPrntGnrc?>
{
  public IMessages Decoder(IValue input, out testEnumOutpPrntGnrc? output)
    => input.DecodeEnum("EnumOutpPrntGnrc", out output);

  internal static testEnumOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcDecoder : IDecoder<testPrntOutpPrntGnrc?>
{
  public IMessages Decoder(IValue input, out testPrntOutpPrntGnrc? output)
    => input.DecodeEnum("PrntOutpPrntGnrc", out output);

  internal static testPrntOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpPrntParamDecoder
{

  internal static testFldOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpPrntParamDecoder
{
  public decimal Param { get; set; }

  internal static testInOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntParamInDecoder
{
  public decimal Parent { get; set; }

  internal static testPrntOutpPrntParamInDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDualDecoder
{

  internal static testPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntInpDecoder
{

  internal static testPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntInpDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntAltDualDecoder
{

  internal static testPrntAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntAltDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntAltInpDecoder
{

  internal static testPrntAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntAltInpDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDescrDualDecoder
{

  internal static testPrntDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDescrDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDescrInpDecoder
{

  internal static testPrntDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDescrInpDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDualDualDecoder
{

  internal static testPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDualInpDecoder
{

  internal static testPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualInpDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualOutpDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldDualDecoder
{
  public decimal Field { get; set; }

  internal static testPrntFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntFieldDualDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldInpDecoder
{
  public decimal Field { get; set; }

  internal static testPrntFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntFieldInpDecoder
{
  public decimal Parent { get; set; }

  internal static testRefPrntFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntParamDiffDualDecoder<TA>
{
  public TA Field { get; set; }
}

internal class testRefPrntParamDiffDualDecoder<TB>
{
}

internal class testPrntParamDiffInpDecoder<TA>
{
  public TA Field { get; set; }
}

internal class testRefPrntParamDiffInpDecoder<TB>
{
}

internal class testPrntParamSameDualDecoder<TA>
{
  public TA Field { get; set; }
}

internal class testRefPrntParamSameDualDecoder<TA>
{
}

internal class testPrntParamSameInpDecoder<TA>
{
  public TA Field { get; set; }
}

internal class testRefPrntParamSameInpDecoder<TA>
{
}

internal class testInDrctParamDecoder
{

  internal static testInDrctParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnAliasDecoder
{

  internal static testDmnAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDecoder
{

  internal static testDmnBoolDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDiffDecoder
{

  internal static testDmnBoolDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolSameDecoder
{

  internal static testDmnBoolSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDiffDecoder
{

  internal static testDmnEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumSameDecoder
{

  internal static testDmnEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDecoder
{

  internal static testDmnNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDiffDecoder
{

  internal static testDmnNmbrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrSameDecoder
{

  internal static testDmnNmbrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDecoder
{

  internal static testDmnStrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDiffDecoder
{

  internal static testDmnStrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrSameDecoder
{

  internal static testDmnStrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAliasDecoder : IDecoder<testEnumAlias?>
{
  public IMessages Decoder(IValue input, out testEnumAlias? output)
    => input.DecodeEnum("EnumAlias", out output);

  internal static testEnumAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDiffDecoder : IDecoder<testEnumDiff?>
{
  public IMessages Decoder(IValue input, out testEnumDiff? output)
    => input.DecodeEnum("EnumDiff", out output);

  internal static testEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSameDecoder : IDecoder<testEnumSame?>
{
  public IMessages Decoder(IValue input, out testEnumSame? output)
    => input.DecodeEnum("EnumSame", out output);

  internal static testEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSamePrntDecoder : IDecoder<testEnumSamePrnt?>
{
  public IMessages Decoder(IValue input, out testEnumSamePrnt? output)
    => input.DecodeEnum("EnumSamePrnt", out output);

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder : IDecoder<testPrntEnumSamePrnt?>
{
  public IMessages Decoder(IValue input, out testPrntEnumSamePrnt? output)
    => input.DecodeEnum("PrntEnumSamePrnt", out output);

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumValueAliasDecoder : IDecoder<testEnumValueAlias?>
{
  public IMessages Decoder(IValue input, out testEnumValueAlias? output)
    => input.DecodeEnum("EnumValueAlias", out output);

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualDecoder
{

  internal static testObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjInpDecoder
{

  internal static testObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasDualDecoder
{

  internal static testObjAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasInpDecoder
{

  internal static testObjAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualDecoder
{

  internal static testObjAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualTypeDecoder
{

  internal static testObjAltDualTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpDecoder
{

  internal static testObjAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpTypeDecoder
{

  internal static testObjAltInpTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumDualDecoder
{

  internal static testObjAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumInpDecoder
{

  internal static testObjAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjCnstDualDecoder<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
}

internal class testObjCnstInpDecoder<TType>
{
  public TType Field { get; set; }
  public TType Str { get; set; }
}

internal class testObjFieldDualDecoder
{
  public ItestFldObjFieldDual Field { get; set; }

  internal static testObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldDualDecoder
{

  internal static testFldObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldInpDecoder
{
  public ItestFldObjFieldInp Field { get; set; }

  internal static testObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldInpDecoder
{

  internal static testFldObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasDualDecoder
{
  public ItestFldObjFieldAliasDual Field { get; set; }

  internal static testObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasDualDecoder
{

  internal static testFldObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasInpDecoder
{
  public ItestFldObjFieldAliasInp Field { get; set; }

  internal static testObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasInpDecoder
{

  internal static testFldObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueDualDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueInpDecoder
{
  public bool Field { get; set; }

  internal static testObjFieldEnumValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualDecoder
{
  public string Field { get; set; }

  internal static testObjFieldTypeAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpDecoder
{
  public string Field { get; set; }

  internal static testObjFieldTypeAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjParamDualDecoder<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}

internal class testObjParamInpDecoder<TTest,TType>
{
  public TTest Test { get; set; }
  public TType Type { get; set; }
}

internal class testObjParamDupDualDecoder<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
}

internal class testObjParamDupInpDecoder<TTest>
{
  public TTest Test { get; set; }
  public TTest Type { get; set; }
}

internal class testObjPrntDualDecoder
{

  internal static testObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntDualDecoder
{

  internal static testRefObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjPrntInpDecoder
{

  internal static testObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntInpDecoder
{

  internal static testRefObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam1Decoder
{

  internal static testOutpFieldParam1Decoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam2Decoder
{

  internal static testOutpFieldParam2Decoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpFieldParamDecoder
{

  internal static testFldOutpFieldParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionAliasDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }

  internal static testUnionAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDiffDecoder
{
  public Boolean AsBoolean { get; set; }
  public Number AsNumber { get; set; }

  internal static testUnionDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSameDecoder
{
  public Boolean AsBoolean { get; set; }

  internal static testUnionSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSamePrntDecoder
{
  public Boolean AsBoolean { get; set; }

  internal static testUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionSamePrntDecoder
{
  public String AsString { get; set; }

  internal static testPrntUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDescrDecoder
{

  internal static testDmnBoolDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDecoder
{

  internal static testDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDecoder
{

  internal static testPrntDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDescrDecoder
{

  internal static testDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrDecoder
{

  internal static testPrntDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDecoder
{

  internal static testDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDecoder : IDecoder<testEnumDmnEnumAll?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumAll? output)
    => input.DecodeEnum("EnumDmnEnumAll", out output);

  internal static testEnumDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDescrDecoder
{

  internal static testDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrDecoder : IDecoder<testEnumDmnEnumAllDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumAllDescr? output)
    => input.DecodeEnum("EnumDmnEnumAllDescr", out output);

  internal static testEnumDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllPrntDecoder
{

  internal static testDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntDecoder : IDecoder<testEnumDmnEnumAllPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumAllPrnt? output)
    => input.DecodeEnum("EnumDmnEnumAllPrnt", out output);

  internal static testEnumDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntDecoder : IDecoder<testPrntDmnEnumAllPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumAllPrnt? output)
    => input.DecodeEnum("PrntDmnEnumAllPrnt", out output);

  internal static testPrntDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDescrDecoder
{

  internal static testDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumDescrDecoder : IDecoder<testEnumDmnEnumDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumDescr? output)
    => input.DecodeEnum("EnumDmnEnumDescr", out output);

  internal static testEnumDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclDecoder
{

  internal static testDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclDecoder : IDecoder<testEnumDmnEnumExcl?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumExcl? output)
    => input.DecodeEnum("EnumDmnEnumExcl", out output);

  internal static testEnumDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclPrntDecoder
{

  internal static testDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntDecoder : IDecoder<testEnumDmnEnumExclPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumExclPrnt? output)
    => input.DecodeEnum("EnumDmnEnumExclPrnt", out output);

  internal static testEnumDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntDecoder : IDecoder<testPrntDmnEnumExclPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumExclPrnt? output)
    => input.DecodeEnum("PrntDmnEnumExclPrnt", out output);

  internal static testPrntDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumLabelDecoder
{

  internal static testDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumLabelDecoder : IDecoder<testEnumDmnEnumLabel?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumLabel? output)
    => input.DecodeEnum("EnumDmnEnumLabel", out output);

  internal static testEnumDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDecoder
{

  internal static testDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDecoder
{

  internal static testPrntDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDecoder : IDecoder<testEnumDmnEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumPrnt? output)
    => input.DecodeEnum("EnumDmnEnumPrnt", out output);

  internal static testEnumDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDescrDecoder
{

  internal static testDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrDecoder
{

  internal static testPrntDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrDecoder : IDecoder<testEnumDmnEnumPrntDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumPrntDescr? output)
    => input.DecodeEnum("EnumDmnEnumPrntDescr", out output);

  internal static testEnumDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqDecoder
{

  internal static testDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqDecoder : IDecoder<testEnumDmnEnumUnq?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumUnq? output)
    => input.DecodeEnum("EnumDmnEnumUnq", out output);

  internal static testEnumDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqDecoder : IDecoder<testDupDmnEnumUnq?>
{
  public IMessages Decoder(IValue input, out testDupDmnEnumUnq? output)
    => input.DecodeEnum("DupDmnEnumUnq", out output);

  internal static testDupDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqPrntDecoder
{

  internal static testDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntDecoder : IDecoder<testEnumDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumUnqPrnt? output)
    => input.DecodeEnum("EnumDmnEnumUnqPrnt", out output);

  internal static testEnumDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntDecoder : IDecoder<testPrntDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumUnqPrnt? output)
    => input.DecodeEnum("PrntDmnEnumUnqPrnt", out output);

  internal static testPrntDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntDecoder : IDecoder<testDupDmnEnumUnqPrnt?>
{
  public IMessages Decoder(IValue input, out testDupDmnEnumUnqPrnt? output)
    => input.DecodeEnum("DupDmnEnumUnqPrnt", out output);

  internal static testDupDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValueDecoder
{

  internal static testDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValueDecoder : IDecoder<testEnumDmnEnumValue?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumValue? output)
    => input.DecodeEnum("EnumDmnEnumValue", out output);

  internal static testEnumDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValuePrntDecoder
{

  internal static testDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntDecoder : IDecoder<testEnumDmnEnumValuePrnt?>
{
  public IMessages Decoder(IValue input, out testEnumDmnEnumValuePrnt? output)
    => input.DecodeEnum("EnumDmnEnumValuePrnt", out output);

  internal static testEnumDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntDecoder : IDecoder<testPrntDmnEnumValuePrnt?>
{
  public IMessages Decoder(IValue input, out testPrntDmnEnumValuePrnt? output)
    => input.DecodeEnum("PrntDmnEnumValuePrnt", out output);

  internal static testPrntDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDescrDecoder
{

  internal static testDmnNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDecoder
{

  internal static testDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDecoder
{

  internal static testPrntDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDescrDecoder
{

  internal static testDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrDecoder
{

  internal static testPrntDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPstvDecoder
{

  internal static testDmnNmbrPstvDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrRangeDecoder
{

  internal static testDmnNmbrRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDescrDecoder
{

  internal static testDmnStrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrNonEmptyDecoder
{

  internal static testDmnStrNonEmptyDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDecoder
{

  internal static testDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDecoder
{

  internal static testPrntDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDescrDecoder
{

  internal static testDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrDecoder
{

  internal static testPrntDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDescrDecoder : IDecoder<testEnumDescr?>
{
  public IMessages Decoder(IValue input, out testEnumDescr? output)
    => input.DecodeEnum("EnumDescr", out output);

  internal static testEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDecoder : IDecoder<testEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testEnumPrnt? output)
    => input.DecodeEnum("EnumPrnt", out output);

  internal static testEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDecoder : IDecoder<testPrntEnumPrnt?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrnt? output)
    => input.DecodeEnum("PrntEnumPrnt", out output);

  internal static testPrntEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntAliasDecoder : IDecoder<testEnumPrntAlias?>
{
  public IMessages Decoder(IValue input, out testEnumPrntAlias? output)
    => input.DecodeEnum("EnumPrntAlias", out output);

  internal static testEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntAliasDecoder : IDecoder<testPrntEnumPrntAlias?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrntAlias? output)
    => input.DecodeEnum("PrntEnumPrntAlias", out output);

  internal static testPrntEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDescrDecoder : IDecoder<testEnumPrntDescr?>
{
  public IMessages Decoder(IValue input, out testEnumPrntDescr? output)
    => input.DecodeEnum("EnumPrntDescr", out output);

  internal static testEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDescrDecoder : IDecoder<testPrntEnumPrntDescr?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrntDescr? output)
    => input.DecodeEnum("PrntEnumPrntDescr", out output);

  internal static testPrntEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDupDecoder : IDecoder<testEnumPrntDup?>
{
  public IMessages Decoder(IValue input, out testEnumPrntDup? output)
    => input.DecodeEnum("EnumPrntDup", out output);

  internal static testEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDupDecoder : IDecoder<testPrntEnumPrntDup?>
{
  public IMessages Decoder(IValue input, out testPrntEnumPrntDup? output)
    => input.DecodeEnum("PrntEnumPrntDup", out output);

  internal static testPrntEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDescrDecoder
{
  public Number AsNumber { get; set; }

  internal static testUnionDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDecoder
{
  public String AsString { get; set; }

  internal static testUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDescrDecoder
{
  public Number AsNumber { get; set; }

  internal static testUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDescrDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDupDecoder
{
  public Number AsNumber { get; set; }

  internal static testUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDupDecoder
{
  public Number AsNumber { get; set; }

  internal static testPrntUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal static class test__ALLDecoders
{
  internal static IDecoderRepositoryBuilder Addtest__ALLDecoders(this IDecoderRepositoryBuilder builder)
    => builder
      .AddDecoder<ItestInDrctParamDictObject>(testInDrctParamDictDecoder.Factory)
      .AddDecoder<ItestInDrctParamInObject>(testInDrctParamInDecoder.Factory)
      .AddDecoder<ItestInDrctParamListObject>(testInDrctParamListDecoder.Factory)
      .AddDecoder<ItestInDrctParamOptObject>(testInDrctParamOptDecoder.Factory)
      .AddDecoder<ItestAltDualObject>(testAltDualDecoder.Factory)
      .AddDecoder<ItestAltAltDualObject>(testAltAltDualDecoder.Factory)
      .AddDecoder<ItestAltInpObject>(testAltInpDecoder.Factory)
      .AddDecoder<ItestAltAltInpObject>(testAltAltInpDecoder.Factory)
      .AddDecoder<ItestAltDescrDualObject>(testAltDescrDualDecoder.Factory)
      .AddDecoder<ItestAltDescrInpObject>(testAltDescrInpDecoder.Factory)
      .AddDecoder<ItestAltDualDualObject>(testAltDualDualDecoder.Factory)
      .AddDecoder<ItestObjDualAltDualDualObject>(testObjDualAltDualDualDecoder.Factory)
      .AddDecoder<ItestAltDualInpObject>(testAltDualInpDecoder.Factory)
      .AddDecoder<ItestObjDualAltDualInpObject>(testObjDualAltDualInpDecoder.Factory)
      .AddDecoder<ItestObjDualAltDualOutpObject>(testObjDualAltDualOutpDecoder.Factory)
      .AddDecoder<ItestAltEnumDualObject>(testAltEnumDualDecoder.Factory)
      .AddDecoder<testEnumAltEnumDual?>(testEnumAltEnumDualDecoder.Factory)
      .AddDecoder<ItestAltEnumInpObject>(testAltEnumInpDecoder.Factory)
      .AddDecoder<testEnumAltEnumInp?>(testEnumAltEnumInpDecoder.Factory)
      .AddDecoder<testEnumAltEnumOutp?>(testEnumAltEnumOutpDecoder.Factory)
      .AddDecoder<ItestAltModBoolDualObject>(testAltModBoolDualDecoder.Factory)
      .AddDecoder<ItestAltAltModBoolDualObject>(testAltAltModBoolDualDecoder.Factory)
      .AddDecoder<ItestAltModBoolInpObject>(testAltModBoolInpDecoder.Factory)
      .AddDecoder<ItestAltAltModBoolInpObject>(testAltAltModBoolInpDecoder.Factory)
      .AddDecoder<ItestAltAltModParamDualObject>(testAltAltModParamDualDecoder.Factory)
      .AddDecoder<ItestAltAltModParamInpObject>(testAltAltModParamInpDecoder.Factory)
      .AddDecoder<ItestAltSmplDualObject>(testAltSmplDualDecoder.Factory)
      .AddDecoder<ItestAltSmplInpObject>(testAltSmplInpDecoder.Factory)
      .AddDecoder<ItestCnstAltDmnDualObject>(testCnstAltDmnDualDecoder.Factory)
      .AddDecoder<ItestDomCnstAltDmnDual>(testDomCnstAltDmnDualDecoder.Factory)
      .AddDecoder<ItestCnstAltDmnInpObject>(testCnstAltDmnInpDecoder.Factory)
      .AddDecoder<ItestDomCnstAltDmnInp>(testDomCnstAltDmnInpDecoder.Factory)
      .AddDecoder<ItestDomCnstAltDmnOutp>(testDomCnstAltDmnOutpDecoder.Factory)
      .AddDecoder<ItestCnstAltDualDualObject>(testCnstAltDualDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltDualDualObject>(testPrntCnstAltDualDualDecoder.Factory)
      .AddDecoder<ItestAltCnstAltDualDualObject>(testAltCnstAltDualDualDecoder.Factory)
      .AddDecoder<ItestCnstAltDualInpObject>(testCnstAltDualInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltDualInpObject>(testPrntCnstAltDualInpDecoder.Factory)
      .AddDecoder<ItestAltCnstAltDualInpObject>(testAltCnstAltDualInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltDualOutpObject>(testPrntCnstAltDualOutpDecoder.Factory)
      .AddDecoder<ItestCnstAltObjDualObject>(testCnstAltObjDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltObjDualObject>(testPrntCnstAltObjDualDecoder.Factory)
      .AddDecoder<ItestAltCnstAltObjDualObject>(testAltCnstAltObjDualDecoder.Factory)
      .AddDecoder<ItestCnstAltObjInpObject>(testCnstAltObjInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstAltObjInpObject>(testPrntCnstAltObjInpDecoder.Factory)
      .AddDecoder<ItestAltCnstAltObjInpObject>(testAltCnstAltObjInpDecoder.Factory)
      .AddDecoder<ItestCnstDomEnumDualObject>(testCnstDomEnumDualDecoder.Factory)
      .AddDecoder<testEnumCnstDomEnumDual?>(testEnumCnstDomEnumDualDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumDual>(testJustCnstDomEnumDualDecoder.Factory)
      .AddDecoder<ItestCnstDomEnumInpObject>(testCnstDomEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstDomEnumInp?>(testEnumCnstDomEnumInpDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumInp>(testJustCnstDomEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstDomEnumOutp?>(testEnumCnstDomEnumOutpDecoder.Factory)
      .AddDecoder<ItestJustCnstDomEnumOutp>(testJustCnstDomEnumOutpDecoder.Factory)
      .AddDecoder<ItestCnstEnumDualObject>(testCnstEnumDualDecoder.Factory)
      .AddDecoder<testEnumCnstEnumDual?>(testEnumCnstEnumDualDecoder.Factory)
      .AddDecoder<ItestCnstEnumInpObject>(testCnstEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumInp?>(testEnumCnstEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumOutp?>(testEnumCnstEnumOutpDecoder.Factory)
      .AddDecoder<ItestCnstEnumPrntDualObject>(testCnstEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumCnstEnumPrntDual?>(testEnumCnstEnumPrntDualDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntDual?>(testParentCnstEnumPrntDualDecoder.Factory)
      .AddDecoder<ItestCnstEnumPrntInpObject>(testCnstEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumPrntInp?>(testEnumCnstEnumPrntInpDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntInp?>(testParentCnstEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumCnstEnumPrntOutp?>(testEnumCnstEnumPrntOutpDecoder.Factory)
      .AddDecoder<testParentCnstEnumPrntOutp?>(testParentCnstEnumPrntOutpDecoder.Factory)
      .AddDecoder<ItestCnstFieldDmnDualObject>(testCnstFieldDmnDualDecoder.Factory)
      .AddDecoder<ItestDomCnstFieldDmnDual>(testDomCnstFieldDmnDualDecoder.Factory)
      .AddDecoder<ItestCnstFieldDmnInpObject>(testCnstFieldDmnInpDecoder.Factory)
      .AddDecoder<ItestDomCnstFieldDmnInp>(testDomCnstFieldDmnInpDecoder.Factory)
      .AddDecoder<ItestDomCnstFieldDmnOutp>(testDomCnstFieldDmnOutpDecoder.Factory)
      .AddDecoder<ItestCnstFieldDualDualObject>(testCnstFieldDualDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldDualDualObject>(testPrntCnstFieldDualDualDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldDualDualObject>(testAltCnstFieldDualDualDecoder.Factory)
      .AddDecoder<ItestCnstFieldDualInpObject>(testCnstFieldDualInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldDualInpObject>(testPrntCnstFieldDualInpDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldDualInpObject>(testAltCnstFieldDualInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldDualOutpObject>(testPrntCnstFieldDualOutpDecoder.Factory)
      .AddDecoder<ItestCnstFieldObjDualObject>(testCnstFieldObjDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldObjDualObject>(testPrntCnstFieldObjDualDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldObjDualObject>(testAltCnstFieldObjDualDecoder.Factory)
      .AddDecoder<ItestCnstFieldObjInpObject>(testCnstFieldObjInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstFieldObjInpObject>(testPrntCnstFieldObjInpDecoder.Factory)
      .AddDecoder<ItestAltCnstFieldObjInpObject>(testAltCnstFieldObjInpDecoder.Factory)
      .AddDecoder<ItestCnstPrntDualGrndDualObject>(testCnstPrntDualGrndDualDecoder.Factory)
      .AddDecoder<ItestGrndCnstPrntDualGrndDualObject>(testGrndCnstPrntDualGrndDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualGrndDualObject>(testPrntCnstPrntDualGrndDualDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualGrndDualObject>(testAltCnstPrntDualGrndDualDecoder.Factory)
      .AddDecoder<ItestCnstPrntDualGrndInpObject>(testCnstPrntDualGrndInpDecoder.Factory)
      .AddDecoder<ItestGrndCnstPrntDualGrndInpObject>(testGrndCnstPrntDualGrndInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualGrndInpObject>(testPrntCnstPrntDualGrndInpDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualGrndInpObject>(testAltCnstPrntDualGrndInpDecoder.Factory)
      .AddDecoder<ItestGrndCnstPrntDualGrndOutpObject>(testGrndCnstPrntDualGrndOutpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualGrndOutpObject>(testPrntCnstPrntDualGrndOutpDecoder.Factory)
      .AddDecoder<ItestCnstPrntDualPrntDualObject>(testCnstPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualPrntDualObject>(testPrntCnstPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualPrntDualObject>(testAltCnstPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestCnstPrntDualPrntInpObject>(testCnstPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualPrntInpObject>(testPrntCnstPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntDualPrntInpObject>(testAltCnstPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntDualPrntOutpObject>(testPrntCnstPrntDualPrntOutpDecoder.Factory)
      .AddDecoder<ItestCnstPrntEnumDualObject>(testCnstPrntEnumDualDecoder.Factory)
      .AddDecoder<testEnumCnstPrntEnumDual?>(testEnumCnstPrntEnumDualDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumDual?>(testParentCnstPrntEnumDualDecoder.Factory)
      .AddDecoder<ItestCnstPrntEnumInpObject>(testCnstPrntEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstPrntEnumInp?>(testEnumCnstPrntEnumInpDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumInp?>(testParentCnstPrntEnumInpDecoder.Factory)
      .AddDecoder<testEnumCnstPrntEnumOutp?>(testEnumCnstPrntEnumOutpDecoder.Factory)
      .AddDecoder<testParentCnstPrntEnumOutp?>(testParentCnstPrntEnumOutpDecoder.Factory)
      .AddDecoder<ItestCnstPrntObjPrntDualObject>(testCnstPrntObjPrntDualDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntObjPrntDualObject>(testPrntCnstPrntObjPrntDualDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntObjPrntDualObject>(testAltCnstPrntObjPrntDualDecoder.Factory)
      .AddDecoder<ItestCnstPrntObjPrntInpObject>(testCnstPrntObjPrntInpDecoder.Factory)
      .AddDecoder<ItestPrntCnstPrntObjPrntInpObject>(testPrntCnstPrntObjPrntInpDecoder.Factory)
      .AddDecoder<ItestAltCnstPrntObjPrntInpObject>(testAltCnstPrntObjPrntInpDecoder.Factory)
      .AddDecoder<ItestFieldDualObject>(testFieldDualDecoder.Factory)
      .AddDecoder<ItestFieldInpObject>(testFieldInpDecoder.Factory)
      .AddDecoder<ItestFieldDescrDualObject>(testFieldDescrDualDecoder.Factory)
      .AddDecoder<ItestFieldDescrInpObject>(testFieldDescrInpDecoder.Factory)
      .AddDecoder<ItestFieldDualDualObject>(testFieldDualDualDecoder.Factory)
      .AddDecoder<ItestFldFieldDualDualObject>(testFldFieldDualDualDecoder.Factory)
      .AddDecoder<ItestFieldDualInpObject>(testFieldDualInpDecoder.Factory)
      .AddDecoder<ItestFldFieldDualInpObject>(testFldFieldDualInpDecoder.Factory)
      .AddDecoder<ItestFldFieldDualOutpObject>(testFldFieldDualOutpDecoder.Factory)
      .AddDecoder<ItestFieldEnumDualObject>(testFieldEnumDualDecoder.Factory)
      .AddDecoder<testEnumFieldEnumDual?>(testEnumFieldEnumDualDecoder.Factory)
      .AddDecoder<ItestFieldEnumInpObject>(testFieldEnumInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumInp?>(testEnumFieldEnumInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumOutp?>(testEnumFieldEnumOutpDecoder.Factory)
      .AddDecoder<ItestFieldEnumPrntDualObject>(testFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntDual?>(testEnumFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntDual?>(testPrntFieldEnumPrntDualDecoder.Factory)
      .AddDecoder<ItestFieldEnumPrntInpObject>(testFieldEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntInp?>(testEnumFieldEnumPrntInpDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntInp?>(testPrntFieldEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumFieldEnumPrntOutp?>(testEnumFieldEnumPrntOutpDecoder.Factory)
      .AddDecoder<testPrntFieldEnumPrntOutp?>(testPrntFieldEnumPrntOutpDecoder.Factory)
      .AddDecoder<ItestFieldModEnumDualObject>(testFieldModEnumDualDecoder.Factory)
      .AddDecoder<testEnumFieldModEnumDual?>(testEnumFieldModEnumDualDecoder.Factory)
      .AddDecoder<ItestFieldModEnumInpObject>(testFieldModEnumInpDecoder.Factory)
      .AddDecoder<testEnumFieldModEnumInp?>(testEnumFieldModEnumInpDecoder.Factory)
      .AddDecoder<testEnumFieldModEnumOutp?>(testEnumFieldModEnumOutpDecoder.Factory)
      .AddDecoder<ItestFldFieldModParamDualObject>(testFldFieldModParamDualDecoder.Factory)
      .AddDecoder<ItestFldFieldModParamInpObject>(testFldFieldModParamInpDecoder.Factory)
      .AddDecoder<ItestFieldObjDualObject>(testFieldObjDualDecoder.Factory)
      .AddDecoder<ItestFldFieldObjDualObject>(testFldFieldObjDualDecoder.Factory)
      .AddDecoder<ItestFieldObjInpObject>(testFieldObjInpDecoder.Factory)
      .AddDecoder<ItestFldFieldObjInpObject>(testFldFieldObjInpDecoder.Factory)
      .AddDecoder<ItestFieldSmplDualObject>(testFieldSmplDualDecoder.Factory)
      .AddDecoder<ItestFieldSmplInpObject>(testFieldSmplInpDecoder.Factory)
      .AddDecoder<ItestFieldTypeDescrDualObject>(testFieldTypeDescrDualDecoder.Factory)
      .AddDecoder<ItestFieldTypeDescrInpObject>(testFieldTypeDescrInpDecoder.Factory)
      .AddDecoder<ItestFieldValueDualObject>(testFieldValueDualDecoder.Factory)
      .AddDecoder<testEnumFieldValueDual?>(testEnumFieldValueDualDecoder.Factory)
      .AddDecoder<ItestFieldValueInpObject>(testFieldValueInpDecoder.Factory)
      .AddDecoder<testEnumFieldValueInp?>(testEnumFieldValueInpDecoder.Factory)
      .AddDecoder<testEnumFieldValueOutp?>(testEnumFieldValueOutpDecoder.Factory)
      .AddDecoder<ItestFieldValueDescrDualObject>(testFieldValueDescrDualDecoder.Factory)
      .AddDecoder<testEnumFieldValueDescrDual?>(testEnumFieldValueDescrDualDecoder.Factory)
      .AddDecoder<ItestFieldValueDescrInpObject>(testFieldValueDescrInpDecoder.Factory)
      .AddDecoder<testEnumFieldValueDescrInp?>(testEnumFieldValueDescrInpDecoder.Factory)
      .AddDecoder<testEnumFieldValueDescrOutp?>(testEnumFieldValueDescrOutpDecoder.Factory)
      .AddDecoder<ItestGnrcAltDualDualObject>(testGnrcAltDualDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltDualDualObject>(testAltGnrcAltDualDualDecoder.Factory)
      .AddDecoder<ItestGnrcAltDualInpObject>(testGnrcAltDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltDualInpObject>(testAltGnrcAltDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltDualOutpObject>(testAltGnrcAltDualOutpDecoder.Factory)
      .AddDecoder<ItestGnrcAltParamDualObject>(testGnrcAltParamDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltParamDualObject>(testAltGnrcAltParamDualDecoder.Factory)
      .AddDecoder<ItestGnrcAltParamInpObject>(testGnrcAltParamInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcAltParamInpObject>(testAltGnrcAltParamInpDecoder.Factory)
      .AddDecoder<ItestGnrcAltSmplDualObject>(testGnrcAltSmplDualDecoder.Factory)
      .AddDecoder<ItestGnrcAltSmplInpObject>(testGnrcAltSmplInpDecoder.Factory)
      .AddDecoder<ItestGnrcEnumDualObject>(testGnrcEnumDualDecoder.Factory)
      .AddDecoder<testEnumGnrcEnumDual?>(testEnumGnrcEnumDualDecoder.Factory)
      .AddDecoder<ItestGnrcEnumInpObject>(testGnrcEnumInpDecoder.Factory)
      .AddDecoder<testEnumGnrcEnumInp?>(testEnumGnrcEnumInpDecoder.Factory)
      .AddDecoder<testEnumGnrcEnumOutp?>(testEnumGnrcEnumOutpDecoder.Factory)
      .AddDecoder<ItestGnrcFieldDualDualObject>(testGnrcFieldDualDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldDualDualObject>(testAltGnrcFieldDualDualDecoder.Factory)
      .AddDecoder<ItestGnrcFieldDualInpObject>(testGnrcFieldDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldDualInpObject>(testAltGnrcFieldDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldDualOutpObject>(testAltGnrcFieldDualOutpDecoder.Factory)
      .AddDecoder<ItestGnrcFieldParamDualObject>(testGnrcFieldParamDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldParamDualObject>(testAltGnrcFieldParamDualDecoder.Factory)
      .AddDecoder<ItestGnrcFieldParamInpObject>(testGnrcFieldParamInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcFieldParamInpObject>(testAltGnrcFieldParamInpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntDualDualObject>(testGnrcPrntDualDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualDualObject>(testAltGnrcPrntDualDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntDualInpObject>(testGnrcPrntDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualInpObject>(testAltGnrcPrntDualInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualOutpObject>(testAltGnrcPrntDualOutpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntDualPrntDualObject>(testGnrcPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualPrntDualObject>(testAltGnrcPrntDualPrntDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntDualPrntInpObject>(testGnrcPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualPrntInpObject>(testAltGnrcPrntDualPrntInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntDualPrntOutpObject>(testAltGnrcPrntDualPrntOutpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntEnumChildDualObject>(testGnrcPrntEnumChildDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumChildDual?>(testEnumGnrcPrntEnumChildDualDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildDual?>(testParentGnrcPrntEnumChildDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntEnumChildInpObject>(testGnrcPrntEnumChildInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumChildInp?>(testEnumGnrcPrntEnumChildInpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildInp?>(testParentGnrcPrntEnumChildInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumChildOutp?>(testEnumGnrcPrntEnumChildOutpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumChildOutp?>(testParentGnrcPrntEnumChildOutpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntEnumDomDualObject>(testGnrcPrntEnumDomDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumDomDual?>(testEnumGnrcPrntEnumDomDualDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomDual>(testDomGnrcPrntEnumDomDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntEnumDomInpObject>(testGnrcPrntEnumDomInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumDomInp?>(testEnumGnrcPrntEnumDomInpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomInp>(testDomGnrcPrntEnumDomInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumDomOutp?>(testEnumGnrcPrntEnumDomOutpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntEnumDomOutp>(testDomGnrcPrntEnumDomOutpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntEnumPrntDualObject>(testGnrcPrntEnumPrntDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumPrntDual?>(testEnumGnrcPrntEnumPrntDualDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntDual?>(testParentGnrcPrntEnumPrntDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntEnumPrntInpObject>(testGnrcPrntEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumPrntInp?>(testEnumGnrcPrntEnumPrntInpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntInp?>(testParentGnrcPrntEnumPrntInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntEnumPrntOutp?>(testEnumGnrcPrntEnumPrntOutpDecoder.Factory)
      .AddDecoder<testParentGnrcPrntEnumPrntOutp?>(testParentGnrcPrntEnumPrntOutpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntParamDualObject>(testGnrcPrntParamDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamDualObject>(testAltGnrcPrntParamDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntParamInpObject>(testGnrcPrntParamInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamInpObject>(testAltGnrcPrntParamInpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntParamPrntDualObject>(testGnrcPrntParamPrntDualDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamPrntDualObject>(testAltGnrcPrntParamPrntDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntParamPrntInpObject>(testGnrcPrntParamPrntInpDecoder.Factory)
      .AddDecoder<ItestAltGnrcPrntParamPrntInpObject>(testAltGnrcPrntParamPrntInpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntSmplEnumDualObject>(testGnrcPrntSmplEnumDualDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntSmplEnumDual?>(testEnumGnrcPrntSmplEnumDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntSmplEnumInpObject>(testGnrcPrntSmplEnumInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntSmplEnumInp?>(testEnumGnrcPrntSmplEnumInpDecoder.Factory)
      .AddDecoder<testEnumGnrcPrntSmplEnumOutp?>(testEnumGnrcPrntSmplEnumOutpDecoder.Factory)
      .AddDecoder<ItestGnrcPrntStrDomDualObject>(testGnrcPrntStrDomDualDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntStrDomDual>(testDomGnrcPrntStrDomDualDecoder.Factory)
      .AddDecoder<ItestGnrcPrntStrDomInpObject>(testGnrcPrntStrDomInpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntStrDomInp>(testDomGnrcPrntStrDomInpDecoder.Factory)
      .AddDecoder<ItestDomGnrcPrntStrDomOutp>(testDomGnrcPrntStrDomOutpDecoder.Factory)
      .AddDecoder<ItestGnrcValueDualObject>(testGnrcValueDualDecoder.Factory)
      .AddDecoder<testEnumGnrcValueDual?>(testEnumGnrcValueDualDecoder.Factory)
      .AddDecoder<ItestGnrcValueInpObject>(testGnrcValueInpDecoder.Factory)
      .AddDecoder<testEnumGnrcValueInp?>(testEnumGnrcValueInpDecoder.Factory)
      .AddDecoder<testEnumGnrcValueOutp?>(testEnumGnrcValueOutpDecoder.Factory)
      .AddDecoder<ItestInpFieldDescrNmbrObject>(testInpFieldDescrNmbrDecoder.Factory)
      .AddDecoder<ItestInpFieldEnumObject>(testInpFieldEnumDecoder.Factory)
      .AddDecoder<testEnumInpFieldEnum?>(testEnumInpFieldEnumDecoder.Factory)
      .AddDecoder<ItestInpFieldNullObject>(testInpFieldNullDecoder.Factory)
      .AddDecoder<ItestFldInpFieldNullObject>(testFldInpFieldNullDecoder.Factory)
      .AddDecoder<ItestInpFieldNmbrObject>(testInpFieldNmbrDecoder.Factory)
      .AddDecoder<ItestInpFieldNmbrDescrObject>(testInpFieldNmbrDescrDecoder.Factory)
      .AddDecoder<ItestInpFieldStrObject>(testInpFieldStrDecoder.Factory)
      .AddDecoder<ItestFldOutpDescrParamObject>(testFldOutpDescrParamDecoder.Factory)
      .AddDecoder<ItestInOutpDescrParamObject>(testInOutpDescrParamDecoder.Factory)
      .AddDecoder<ItestFldOutpParamObject>(testFldOutpParamDecoder.Factory)
      .AddDecoder<ItestInOutpParamObject>(testInOutpParamDecoder.Factory)
      .AddDecoder<ItestFldOutpParamDescrObject>(testFldOutpParamDescrDecoder.Factory)
      .AddDecoder<ItestInOutpParamDescrObject>(testInOutpParamDescrDecoder.Factory)
      .AddDecoder<ItestInOutpParamModDmnObject>(testInOutpParamModDmnDecoder.Factory)
      .AddDecoder<ItestDomOutpParamModDmn>(testDomOutpParamModDmnDecoder.Factory)
      .AddDecoder<ItestInOutpParamModParamObject>(testInOutpParamModParamDecoder.Factory)
      .AddDecoder<ItestDomOutpParamModParam>(testDomOutpParamModParamDecoder.Factory)
      .AddDecoder<ItestFldOutpParamTypeDescrObject>(testFldOutpParamTypeDescrDecoder.Factory)
      .AddDecoder<ItestInOutpParamTypeDescrObject>(testInOutpParamTypeDescrDecoder.Factory)
      .AddDecoder<testEnumOutpPrntGnrc?>(testEnumOutpPrntGnrcDecoder.Factory)
      .AddDecoder<testPrntOutpPrntGnrc?>(testPrntOutpPrntGnrcDecoder.Factory)
      .AddDecoder<ItestFldOutpPrntParamObject>(testFldOutpPrntParamDecoder.Factory)
      .AddDecoder<ItestInOutpPrntParamObject>(testInOutpPrntParamDecoder.Factory)
      .AddDecoder<ItestPrntOutpPrntParamInObject>(testPrntOutpPrntParamInDecoder.Factory)
      .AddDecoder<ItestPrntDualObject>(testPrntDualDecoder.Factory)
      .AddDecoder<ItestRefPrntDualObject>(testRefPrntDualDecoder.Factory)
      .AddDecoder<ItestPrntInpObject>(testPrntInpDecoder.Factory)
      .AddDecoder<ItestRefPrntInpObject>(testRefPrntInpDecoder.Factory)
      .AddDecoder<ItestPrntAltDualObject>(testPrntAltDualDecoder.Factory)
      .AddDecoder<ItestRefPrntAltDualObject>(testRefPrntAltDualDecoder.Factory)
      .AddDecoder<ItestPrntAltInpObject>(testPrntAltInpDecoder.Factory)
      .AddDecoder<ItestRefPrntAltInpObject>(testRefPrntAltInpDecoder.Factory)
      .AddDecoder<ItestPrntDescrDualObject>(testPrntDescrDualDecoder.Factory)
      .AddDecoder<ItestRefPrntDescrDualObject>(testRefPrntDescrDualDecoder.Factory)
      .AddDecoder<ItestPrntDescrInpObject>(testPrntDescrInpDecoder.Factory)
      .AddDecoder<ItestRefPrntDescrInpObject>(testRefPrntDescrInpDecoder.Factory)
      .AddDecoder<ItestPrntDualDualObject>(testPrntDualDualDecoder.Factory)
      .AddDecoder<ItestRefPrntDualDualObject>(testRefPrntDualDualDecoder.Factory)
      .AddDecoder<ItestPrntDualInpObject>(testPrntDualInpDecoder.Factory)
      .AddDecoder<ItestRefPrntDualInpObject>(testRefPrntDualInpDecoder.Factory)
      .AddDecoder<ItestRefPrntDualOutpObject>(testRefPrntDualOutpDecoder.Factory)
      .AddDecoder<ItestPrntFieldDualObject>(testPrntFieldDualDecoder.Factory)
      .AddDecoder<ItestRefPrntFieldDualObject>(testRefPrntFieldDualDecoder.Factory)
      .AddDecoder<ItestPrntFieldInpObject>(testPrntFieldInpDecoder.Factory)
      .AddDecoder<ItestRefPrntFieldInpObject>(testRefPrntFieldInpDecoder.Factory)
      .AddDecoder<ItestInDrctParamObject>(testInDrctParamDecoder.Factory)
      .AddDecoder<ItestDmnAlias>(testDmnAliasDecoder.Factory)
      .AddDecoder<ItestDmnBool>(testDmnBoolDecoder.Factory)
      .AddDecoder<ItestDmnBoolDiff>(testDmnBoolDiffDecoder.Factory)
      .AddDecoder<ItestDmnBoolSame>(testDmnBoolSameDecoder.Factory)
      .AddDecoder<ItestDmnEnumDiff>(testDmnEnumDiffDecoder.Factory)
      .AddDecoder<ItestDmnEnumSame>(testDmnEnumSameDecoder.Factory)
      .AddDecoder<ItestDmnNmbr>(testDmnNmbrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrDiff>(testDmnNmbrDiffDecoder.Factory)
      .AddDecoder<ItestDmnNmbrSame>(testDmnNmbrSameDecoder.Factory)
      .AddDecoder<ItestDmnStr>(testDmnStrDecoder.Factory)
      .AddDecoder<ItestDmnStrDiff>(testDmnStrDiffDecoder.Factory)
      .AddDecoder<ItestDmnStrSame>(testDmnStrSameDecoder.Factory)
      .AddDecoder<testEnumAlias?>(testEnumAliasDecoder.Factory)
      .AddDecoder<testEnumDiff?>(testEnumDiffDecoder.Factory)
      .AddDecoder<testEnumSame?>(testEnumSameDecoder.Factory)
      .AddDecoder<testEnumSamePrnt?>(testEnumSamePrntDecoder.Factory)
      .AddDecoder<testPrntEnumSamePrnt?>(testPrntEnumSamePrntDecoder.Factory)
      .AddDecoder<testEnumValueAlias?>(testEnumValueAliasDecoder.Factory)
      .AddDecoder<ItestObjDualObject>(testObjDualDecoder.Factory)
      .AddDecoder<ItestObjInpObject>(testObjInpDecoder.Factory)
      .AddDecoder<ItestObjAliasDualObject>(testObjAliasDualDecoder.Factory)
      .AddDecoder<ItestObjAliasInpObject>(testObjAliasInpDecoder.Factory)
      .AddDecoder<ItestObjAltDualObject>(testObjAltDualDecoder.Factory)
      .AddDecoder<ItestObjAltDualTypeObject>(testObjAltDualTypeDecoder.Factory)
      .AddDecoder<ItestObjAltInpObject>(testObjAltInpDecoder.Factory)
      .AddDecoder<ItestObjAltInpTypeObject>(testObjAltInpTypeDecoder.Factory)
      .AddDecoder<ItestObjAltEnumDualObject>(testObjAltEnumDualDecoder.Factory)
      .AddDecoder<ItestObjAltEnumInpObject>(testObjAltEnumInpDecoder.Factory)
      .AddDecoder<ItestObjFieldDualObject>(testObjFieldDualDecoder.Factory)
      .AddDecoder<ItestFldObjFieldDualObject>(testFldObjFieldDualDecoder.Factory)
      .AddDecoder<ItestObjFieldInpObject>(testObjFieldInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldInpObject>(testFldObjFieldInpDecoder.Factory)
      .AddDecoder<ItestObjFieldAliasDualObject>(testObjFieldAliasDualDecoder.Factory)
      .AddDecoder<ItestFldObjFieldAliasDualObject>(testFldObjFieldAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldAliasInpObject>(testObjFieldAliasInpDecoder.Factory)
      .AddDecoder<ItestFldObjFieldAliasInpObject>(testFldObjFieldAliasInpDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumAliasDualObject>(testObjFieldEnumAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumAliasInpObject>(testObjFieldEnumAliasInpDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumValueDualObject>(testObjFieldEnumValueDualDecoder.Factory)
      .AddDecoder<ItestObjFieldEnumValueInpObject>(testObjFieldEnumValueInpDecoder.Factory)
      .AddDecoder<ItestObjFieldTypeAliasDualObject>(testObjFieldTypeAliasDualDecoder.Factory)
      .AddDecoder<ItestObjFieldTypeAliasInpObject>(testObjFieldTypeAliasInpDecoder.Factory)
      .AddDecoder<ItestObjPrntDualObject>(testObjPrntDualDecoder.Factory)
      .AddDecoder<ItestRefObjPrntDualObject>(testRefObjPrntDualDecoder.Factory)
      .AddDecoder<ItestObjPrntInpObject>(testObjPrntInpDecoder.Factory)
      .AddDecoder<ItestRefObjPrntInpObject>(testRefObjPrntInpDecoder.Factory)
      .AddDecoder<ItestOutpFieldParam1Object>(testOutpFieldParam1Decoder.Factory)
      .AddDecoder<ItestOutpFieldParam2Object>(testOutpFieldParam2Decoder.Factory)
      .AddDecoder<ItestFldOutpFieldParamObject>(testFldOutpFieldParamDecoder.Factory)
      .AddDecoder<ItestUnionAlias>(testUnionAliasDecoder.Factory)
      .AddDecoder<ItestUnionDiff>(testUnionDiffDecoder.Factory)
      .AddDecoder<ItestUnionSame>(testUnionSameDecoder.Factory)
      .AddDecoder<ItestUnionSamePrnt>(testUnionSamePrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionSamePrnt>(testPrntUnionSamePrntDecoder.Factory)
      .AddDecoder<ItestDmnBoolDescr>(testDmnBoolDescrDecoder.Factory)
      .AddDecoder<ItestDmnBoolPrnt>(testDmnBoolPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrnt>(testPrntDmnBoolPrntDecoder.Factory)
      .AddDecoder<ItestDmnBoolPrntDescr>(testDmnBoolPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnBoolPrntDescr>(testPrntDmnBoolPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumAll>(testDmnEnumAllDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAll?>(testEnumDmnEnumAllDecoder.Factory)
      .AddDecoder<ItestDmnEnumAllDescr>(testDmnEnumAllDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllDescr?>(testEnumDmnEnumAllDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumAllPrnt>(testDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumAllPrnt?>(testEnumDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumAllPrnt?>(testPrntDmnEnumAllPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumDescr>(testDmnEnumDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumDescr?>(testEnumDmnEnumDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumExcl>(testDmnEnumExclDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExcl?>(testEnumDmnEnumExclDecoder.Factory)
      .AddDecoder<ItestDmnEnumExclPrnt>(testDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumExclPrnt?>(testEnumDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumExclPrnt?>(testPrntDmnEnumExclPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumLabel>(testDmnEnumLabelDecoder.Factory)
      .AddDecoder<testEnumDmnEnumLabel?>(testEnumDmnEnumLabelDecoder.Factory)
      .AddDecoder<ItestDmnEnumPrnt>(testDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrnt>(testPrntDmnEnumPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrnt?>(testEnumDmnEnumPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumPrntDescr>(testDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnEnumPrntDescr>(testPrntDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDmnEnumPrntDescr?>(testEnumDmnEnumPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnEnumUnq>(testDmnEnumUnqDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnq?>(testEnumDmnEnumUnqDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnq?>(testDupDmnEnumUnqDecoder.Factory)
      .AddDecoder<ItestDmnEnumUnqPrnt>(testDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumUnqPrnt?>(testEnumDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumUnqPrnt?>(testPrntDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<testDupDmnEnumUnqPrnt?>(testDupDmnEnumUnqPrntDecoder.Factory)
      .AddDecoder<ItestDmnEnumValue>(testDmnEnumValueDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValue?>(testEnumDmnEnumValueDecoder.Factory)
      .AddDecoder<ItestDmnEnumValuePrnt>(testDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testEnumDmnEnumValuePrnt?>(testEnumDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<testPrntDmnEnumValuePrnt?>(testPrntDmnEnumValuePrntDecoder.Factory)
      .AddDecoder<ItestDmnNmbrDescr>(testDmnNmbrDescrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPrnt>(testDmnNmbrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrnt>(testPrntDmnNmbrPrntDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPrntDescr>(testDmnNmbrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnNmbrPrntDescr>(testPrntDmnNmbrPrntDescrDecoder.Factory)
      .AddDecoder<ItestDmnNmbrPstv>(testDmnNmbrPstvDecoder.Factory)
      .AddDecoder<ItestDmnNmbrRange>(testDmnNmbrRangeDecoder.Factory)
      .AddDecoder<ItestDmnStrDescr>(testDmnStrDescrDecoder.Factory)
      .AddDecoder<ItestDmnStrNonEmpty>(testDmnStrNonEmptyDecoder.Factory)
      .AddDecoder<ItestDmnStrPrnt>(testDmnStrPrntDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrnt>(testPrntDmnStrPrntDecoder.Factory)
      .AddDecoder<ItestDmnStrPrntDescr>(testDmnStrPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntDmnStrPrntDescr>(testPrntDmnStrPrntDescrDecoder.Factory)
      .AddDecoder<testEnumDescr?>(testEnumDescrDecoder.Factory)
      .AddDecoder<testEnumPrnt?>(testEnumPrntDecoder.Factory)
      .AddDecoder<testPrntEnumPrnt?>(testPrntEnumPrntDecoder.Factory)
      .AddDecoder<testEnumPrntAlias?>(testEnumPrntAliasDecoder.Factory)
      .AddDecoder<testPrntEnumPrntAlias?>(testPrntEnumPrntAliasDecoder.Factory)
      .AddDecoder<testEnumPrntDescr?>(testEnumPrntDescrDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDescr?>(testPrntEnumPrntDescrDecoder.Factory)
      .AddDecoder<testEnumPrntDup?>(testEnumPrntDupDecoder.Factory)
      .AddDecoder<testPrntEnumPrntDup?>(testPrntEnumPrntDupDecoder.Factory)
      .AddDecoder<ItestUnionDescr>(testUnionDescrDecoder.Factory)
      .AddDecoder<ItestUnionPrnt>(testUnionPrntDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrnt>(testPrntUnionPrntDecoder.Factory)
      .AddDecoder<ItestUnionPrntDescr>(testUnionPrntDescrDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDescr>(testPrntUnionPrntDescrDecoder.Factory)
      .AddDecoder<ItestUnionPrntDup>(testUnionPrntDupDecoder.Factory)
      .AddDecoder<ItestPrntUnionPrntDup>(testPrntUnionPrntDupDecoder.Factory);
}
