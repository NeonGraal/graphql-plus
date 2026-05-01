//HintName: test_-ALL_Dec.gen.cs
// Generated from {CurrentDirectory}-ALL.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__ALL;

internal class testInDrctParamDictDecoder : IDecoder<ItestInDrctParamDictObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamDictObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamDictDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamInDecoder : IDecoder<ItestInDrctParamInObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamInObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamInDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamListDecoder : IDecoder<ItestInDrctParamListObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamListObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamListDecoder Factory(IDecoderRepository _) => new();
}

internal class testInDrctParamOptDecoder : IDecoder<ItestInDrctParamOptObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamOptObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamOptDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDualDecoder : IDecoder<ItestAltDualObject>
{

  public IMessages Decode(IValue input, out ItestAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltDualDecoder : IDecoder<ItestAltAltDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltInpDecoder : IDecoder<ItestAltInpObject>
{

  public IMessages Decode(IValue input, out ItestAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltInpDecoder : IDecoder<ItestAltAltInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDescrDualDecoder : IDecoder<ItestAltDescrDualObject>
{

  public IMessages Decode(IValue input, out ItestAltDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDescrInpDecoder : IDecoder<ItestAltDescrInpObject>
{

  public IMessages Decode(IValue input, out ItestAltDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDualDualDecoder : IDecoder<ItestAltDualDualObject>
{

  public IMessages Decode(IValue input, out ItestAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualDualDecoder : IDecoder<ItestObjDualAltDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestObjDualAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjDualAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltDualInpDecoder : IDecoder<ItestAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualInpDecoder : IDecoder<ItestObjDualAltDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestObjDualAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjDualAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualAltDualOutpDecoder : IDecoder<ItestObjDualAltDualOutpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestObjDualAltDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjDualAltDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltEnumDualDecoder : IDecoder<ItestAltEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestAltEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumDualDecoder : IDecoder<testEnumAltEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumAltEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAltEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAltEnumDual".AnError();
  }

  internal static testEnumAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltEnumInpDecoder : IDecoder<ItestAltEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestAltEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumInpDecoder : IDecoder<testEnumAltEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumAltEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAltEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAltEnumInp".AnError();
  }

  internal static testEnumAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAltEnumOutpDecoder : IDecoder<testEnumAltEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumAltEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAltEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAltEnumOutp".AnError();
  }

  internal static testEnumAltEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModBoolDualDecoder : IDecoder<ItestAltModBoolDualObject>
{

  public IMessages Decode(IValue input, out ItestAltModBoolDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltModBoolDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltModBoolDualDecoder : IDecoder<ItestAltAltModBoolDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltModBoolDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltModBoolDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModBoolInpDecoder : IDecoder<ItestAltModBoolInpObject>
{

  public IMessages Decode(IValue input, out ItestAltModBoolInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltModBoolInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltAltModBoolInpDecoder : IDecoder<ItestAltAltModBoolInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltModBoolInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltModBoolInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModParamDualDecoder<TMod>
{
}

internal class testAltAltModParamDualDecoder : IDecoder<ItestAltAltModParamDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltModParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltModParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltModParamInpDecoder<TMod>
{
}

internal class testAltAltModParamInpDecoder : IDecoder<ItestAltAltModParamInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltAltModParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltAltModParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltSmplDualDecoder : IDecoder<ItestAltSmplDualObject>
{

  public IMessages Decode(IValue input, out ItestAltSmplDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltSmplInpDecoder : IDecoder<ItestAltSmplInpObject>
{

  public IMessages Decode(IValue input, out ItestAltSmplInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDualDecoder<TType>
{
}

internal class testCnstAltInpDecoder<TType>
{
}

internal class testCnstAltDmnDualDecoder : IDecoder<ItestCnstAltDmnDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltDmnDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDmnDualDecoder<TRef>
{
}

internal class testDomCnstAltDmnDualDecoder : IDecoder<ItestDomCnstAltDmnDual>
{

  public IMessages Decode(IValue input, out ItestDomCnstAltDmnDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstAltDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDmnInpDecoder : IDecoder<ItestCnstAltDmnInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltDmnInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDmnInpDecoder<TRef>
{
}

internal class testDomCnstAltDmnInpDecoder : IDecoder<ItestDomCnstAltDmnInp>
{

  public IMessages Decode(IValue input, out ItestDomCnstAltDmnInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstAltDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomCnstAltDmnOutpDecoder : IDecoder<ItestDomCnstAltDmnOutp>
{

  public IMessages Decode(IValue input, out ItestDomCnstAltDmnOutp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstAltDmnOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDualDualDecoder : IDecoder<ItestCnstAltDualDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDualDualDecoder<TRef>
{
}

internal class testPrntCnstAltDualDualDecoder : IDecoder<ItestPrntCnstAltDualDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltDualDualDecoder : IDecoder<ItestAltCnstAltDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltDualInpDecoder : IDecoder<ItestCnstAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltDualInpDecoder<TRef>
{
}

internal class testPrntCnstAltDualInpDecoder : IDecoder<ItestPrntCnstAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltDualInpDecoder : IDecoder<ItestAltCnstAltDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstAltDualOutpDecoder : IDecoder<ItestPrntCnstAltDualOutpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltObjDualDecoder : IDecoder<ItestCnstAltObjDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltObjDualDecoder<TRef>
{
}

internal class testPrntCnstAltObjDualDecoder : IDecoder<ItestPrntCnstAltObjDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltObjDualDecoder : IDecoder<ItestAltCnstAltObjDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstAltObjInpDecoder : IDecoder<ItestCnstAltObjInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstAltObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstAltObjInpDecoder<TRef>
{
}

internal class testPrntCnstAltObjInpDecoder : IDecoder<ItestPrntCnstAltObjInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstAltObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstAltObjInpDecoder : IDecoder<ItestAltCnstAltObjInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstAltObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstAltObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstDomEnumDualDecoder : IDecoder<ItestCnstDomEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstDomEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstDomEnumDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstDomEnumDualDecoder : IDecoder<testEnumCnstDomEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumCnstDomEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstDomEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstDomEnumDual".AnError();
  }

  internal static testEnumCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumDualDecoder : IDecoder<ItestJustCnstDomEnumDual>
{
  public testEnumCnstDomEnumDual? Value { get; set; }

  public IMessages Decode(IValue input, out ItestJustCnstDomEnumDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testJustCnstDomEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstDomEnumInpDecoder : IDecoder<ItestCnstDomEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstDomEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstDomEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstDomEnumInpDecoder : IDecoder<testEnumCnstDomEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstDomEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstDomEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstDomEnumInp".AnError();
  }

  internal static testEnumCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumInpDecoder : IDecoder<ItestJustCnstDomEnumInp>
{
  public testEnumCnstDomEnumInp? Value { get; set; }

  public IMessages Decode(IValue input, out ItestJustCnstDomEnumInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testJustCnstDomEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstDomEnumOutpDecoder : IDecoder<testEnumCnstDomEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstDomEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstDomEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstDomEnumOutp".AnError();
  }

  internal static testEnumCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testJustCnstDomEnumOutpDecoder : IDecoder<ItestJustCnstDomEnumOutp>
{
  public testEnumCnstDomEnumOutp? Value { get; set; }

  public IMessages Decode(IValue input, out ItestJustCnstDomEnumOutp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testJustCnstDomEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumDualDecoder : IDecoder<ItestCnstEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstEnumDualDecoder : IDecoder<testEnumCnstEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumDual".AnError();
  }

  internal static testEnumCnstEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumInpDecoder : IDecoder<ItestCnstEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstEnumInpDecoder : IDecoder<testEnumCnstEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumInp".AnError();
  }

  internal static testEnumCnstEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstEnumOutpDecoder : IDecoder<testEnumCnstEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumOutp".AnError();
  }

  internal static testEnumCnstEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumPrntDualDecoder : IDecoder<ItestCnstEnumPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstEnumPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumPrntDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstEnumPrntDualDecoder : IDecoder<testEnumCnstEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumPrntDual".AnError();
  }

  internal static testEnumCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntDualDecoder : IDecoder<testParentCnstEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testParentCnstEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstEnumPrntDual".AnError();
  }

  internal static testParentCnstEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstEnumPrntInpDecoder : IDecoder<ItestCnstEnumPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstEnumPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstEnumPrntInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstEnumPrntInpDecoder : IDecoder<testEnumCnstEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumPrntInp".AnError();
  }

  internal static testEnumCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntInpDecoder : IDecoder<testParentCnstEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testParentCnstEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstEnumPrntInp".AnError();
  }

  internal static testParentCnstEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstEnumPrntOutpDecoder : IDecoder<testEnumCnstEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstEnumPrntOutp".AnError();
  }

  internal static testEnumCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstEnumPrntOutpDecoder : IDecoder<testParentCnstEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testParentCnstEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstEnumPrntOutp".AnError();
  }

  internal static testParentCnstEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDmnDualDecoder : IDecoder<ItestCnstFieldDmnDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldDmnDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDmnDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testDomCnstFieldDmnDualDecoder : IDecoder<ItestDomCnstFieldDmnDual>
{

  public IMessages Decode(IValue input, out ItestDomCnstFieldDmnDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstFieldDmnDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDmnInpDecoder : IDecoder<ItestCnstFieldDmnInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldDmnInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDmnInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testDomCnstFieldDmnInpDecoder : IDecoder<ItestDomCnstFieldDmnInp>
{

  public IMessages Decode(IValue input, out ItestDomCnstFieldDmnInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstFieldDmnInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomCnstFieldDmnOutpDecoder : IDecoder<ItestDomCnstFieldDmnOutp>
{

  public IMessages Decode(IValue input, out ItestDomCnstFieldDmnOutp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomCnstFieldDmnOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDualDualDecoder : IDecoder<ItestCnstFieldDualDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDualDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testPrntCnstFieldDualDualDecoder : IDecoder<ItestPrntCnstFieldDualDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldDualDualDecoder : IDecoder<ItestAltCnstFieldDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldDualInpDecoder : IDecoder<ItestCnstFieldDualInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldDualInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testPrntCnstFieldDualInpDecoder : IDecoder<ItestPrntCnstFieldDualInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldDualInpDecoder : IDecoder<ItestAltCnstFieldDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstFieldDualOutpDecoder : IDecoder<ItestPrntCnstFieldDualOutpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldObjDualDecoder : IDecoder<ItestCnstFieldObjDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldObjDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testPrntCnstFieldObjDualDecoder : IDecoder<ItestPrntCnstFieldObjDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldObjDualDecoder : IDecoder<ItestAltCnstFieldObjDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstFieldObjInpDecoder : IDecoder<ItestCnstFieldObjInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstFieldObjInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testPrntCnstFieldObjInpDecoder : IDecoder<ItestPrntCnstFieldObjInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstFieldObjInpDecoder : IDecoder<ItestAltCnstFieldObjInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualGrndDualDecoder : IDecoder<ItestCnstPrntDualGrndDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualGrndDualDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndDualDecoder : IDecoder<ItestGrndCnstPrntDualGrndDualObject>
{

  public IMessages Decode(IValue input, out ItestGrndCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGrndCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndDualDecoder : IDecoder<ItestPrntCnstPrntDualGrndDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualGrndDualDecoder : IDecoder<ItestAltCnstPrntDualGrndDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntDualGrndDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntDualGrndDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualGrndInpDecoder : IDecoder<ItestCnstPrntDualGrndInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntDualGrndInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualGrndInpDecoder<TRef>
{
}

internal class testGrndCnstPrntDualGrndInpDecoder : IDecoder<ItestGrndCnstPrntDualGrndInpObject>
{

  public IMessages Decode(IValue input, out ItestGrndCnstPrntDualGrndInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGrndCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndInpDecoder : IDecoder<ItestPrntCnstPrntDualGrndInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualGrndInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualGrndInpDecoder : IDecoder<ItestAltCnstPrntDualGrndInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntDualGrndInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntDualGrndInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGrndCnstPrntDualGrndOutpDecoder : IDecoder<ItestGrndCnstPrntDualGrndOutpObject>
{

  public IMessages Decode(IValue input, out ItestGrndCnstPrntDualGrndOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGrndCnstPrntDualGrndOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualGrndOutpDecoder : IDecoder<ItestPrntCnstPrntDualGrndOutpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualGrndOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualGrndOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualPrntDualDecoder : IDecoder<ItestCnstPrntDualPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntDualPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntDualDecoder : IDecoder<ItestPrntCnstPrntDualPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntDualDecoder : IDecoder<ItestAltCnstPrntDualPrntDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntDualPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntDualPrntInpDecoder : IDecoder<ItestCnstPrntDualPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntDualPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntDualPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntDualPrntInpDecoder : IDecoder<ItestPrntCnstPrntDualPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntDualPrntInpDecoder : IDecoder<ItestAltCnstPrntDualPrntInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntDualPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntCnstPrntDualPrntOutpDecoder : IDecoder<ItestPrntCnstPrntDualPrntOutpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntDualPrntOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntDualPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntEnumDualDecoder : IDecoder<ItestCnstPrntEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntEnumDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstPrntEnumDualDecoder : IDecoder<testEnumCnstPrntEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumCnstPrntEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstPrntEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstPrntEnumDual".AnError();
  }

  internal static testEnumCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumDualDecoder : IDecoder<testParentCnstPrntEnumDual?>
{
  public IMessages Decode(IValue input, out testParentCnstPrntEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstPrntEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstPrntEnumDual".AnError();
  }

  internal static testParentCnstPrntEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntEnumInpDecoder : IDecoder<ItestCnstPrntEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumCnstPrntEnumInpDecoder : IDecoder<testEnumCnstPrntEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumCnstPrntEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstPrntEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstPrntEnumInp".AnError();
  }

  internal static testEnumCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumInpDecoder : IDecoder<testParentCnstPrntEnumInp?>
{
  public IMessages Decode(IValue input, out testParentCnstPrntEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstPrntEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstPrntEnumInp".AnError();
  }

  internal static testParentCnstPrntEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumCnstPrntEnumOutpDecoder : IDecoder<testEnumCnstPrntEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumCnstPrntEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumCnstPrntEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumCnstPrntEnumOutp".AnError();
  }

  internal static testEnumCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentCnstPrntEnumOutpDecoder : IDecoder<testParentCnstPrntEnumOutp?>
{
  public IMessages Decode(IValue input, out testParentCnstPrntEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentCnstPrntEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentCnstPrntEnumOutp".AnError();
  }

  internal static testParentCnstPrntEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntObjPrntDualDecoder : IDecoder<ItestCnstPrntObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntObjPrntDualDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntDualDecoder : IDecoder<ItestPrntCnstPrntObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntDualDecoder : IDecoder<ItestAltCnstPrntObjPrntDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testCnstPrntObjPrntInpDecoder : IDecoder<ItestCnstPrntObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestCnstPrntObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefCnstPrntObjPrntInpDecoder<TRef>
{
}

internal class testPrntCnstPrntObjPrntInpDecoder : IDecoder<ItestPrntCnstPrntObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntCnstPrntObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltCnstPrntObjPrntInpDecoder : IDecoder<ItestAltCnstPrntObjPrntInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltCnstPrntObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltCnstPrntObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDualDecoder : IDecoder<ItestFieldDualObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldInpDecoder : IDecoder<ItestFieldInpObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDescrDualDecoder : IDecoder<ItestFieldDescrDualObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDescrInpDecoder : IDecoder<ItestFieldDescrInpObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDualDualDecoder : IDecoder<ItestFieldDualDualObject>
{
  public ItestFldFieldDualDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldDualDualDecoder : IDecoder<ItestFldFieldDualDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldDualInpDecoder : IDecoder<ItestFieldDualInpObject>
{
  public ItestFldFieldDualInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldDualInpDecoder : IDecoder<ItestFldFieldDualInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldDualOutpDecoder : IDecoder<ItestFldFieldDualOutpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumDualDecoder : IDecoder<ItestFieldEnumDualObject>
{
  public testEnumFieldEnumDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumDualDecoder : IDecoder<testEnumFieldEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumDual".AnError();
  }

  internal static testEnumFieldEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumInpDecoder : IDecoder<ItestFieldEnumInpObject>
{
  public testEnumFieldEnumInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumInpDecoder : IDecoder<testEnumFieldEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumInp".AnError();
  }

  internal static testEnumFieldEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumOutpDecoder : IDecoder<testEnumFieldEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumOutp".AnError();
  }

  internal static testEnumFieldEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumPrntDualDecoder : IDecoder<ItestFieldEnumPrntDualObject>
{
  public testEnumFieldEnumPrntDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntDualDecoder : IDecoder<testEnumFieldEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumPrntDual".AnError();
  }

  internal static testEnumFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntDualDecoder : IDecoder<testPrntFieldEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testPrntFieldEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntFieldEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntFieldEnumPrntDual".AnError();
  }

  internal static testPrntFieldEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldEnumPrntInpDecoder : IDecoder<ItestFieldEnumPrntInpObject>
{
  public testEnumFieldEnumPrntInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldEnumPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntInpDecoder : IDecoder<testEnumFieldEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumPrntInp".AnError();
  }

  internal static testEnumFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntInpDecoder : IDecoder<testPrntFieldEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testPrntFieldEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntFieldEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntFieldEnumPrntInp".AnError();
  }

  internal static testPrntFieldEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldEnumPrntOutpDecoder : IDecoder<testEnumFieldEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldEnumPrntOutp".AnError();
  }

  internal static testEnumFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldEnumPrntOutpDecoder : IDecoder<testPrntFieldEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testPrntFieldEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntFieldEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntFieldEnumPrntOutp".AnError();
  }

  internal static testPrntFieldEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModEnumDualDecoder : IDecoder<ItestFieldModEnumDualObject>
{
  public IDictionary<testEnumFieldModEnumDual, string>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldModEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldModEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumDualDecoder : IDecoder<testEnumFieldModEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldModEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldModEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldModEnumDual".AnError();
  }

  internal static testEnumFieldModEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModEnumInpDecoder : IDecoder<ItestFieldModEnumInpObject>
{
  public IDictionary<testEnumFieldModEnumInp, string>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldModEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldModEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumInpDecoder : IDecoder<testEnumFieldModEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldModEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldModEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldModEnumInp".AnError();
  }

  internal static testEnumFieldModEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldModEnumOutpDecoder : IDecoder<testEnumFieldModEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldModEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldModEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldModEnumOutp".AnError();
  }

  internal static testEnumFieldModEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModParamDualDecoder<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamDual>? Field { get; set; }
}

internal class testFldFieldModParamDualDecoder : IDecoder<ItestFldFieldModParamDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldModParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldModParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldModParamInpDecoder<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp>? Field { get; set; }
}

internal class testFldFieldModParamInpDecoder : IDecoder<ItestFldFieldModParamInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldModParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldModParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldObjDualDecoder : IDecoder<ItestFieldObjDualObject>
{
  public ItestFldFieldObjDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldObjDualDecoder : IDecoder<ItestFldFieldObjDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldObjInpDecoder : IDecoder<ItestFieldObjInpObject>
{
  public ItestFldFieldObjInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldFieldObjInpDecoder : IDecoder<ItestFldFieldObjInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFldFieldObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldFieldObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldSmplDualDecoder : IDecoder<ItestFieldSmplDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldSmplDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldSmplInpDecoder : IDecoder<ItestFieldSmplInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldSmplInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldTypeDescrDualDecoder : IDecoder<ItestFieldTypeDescrDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldTypeDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldTypeDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldTypeDescrInpDecoder : IDecoder<ItestFieldTypeDescrInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldTypeDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldTypeDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueDualDecoder : IDecoder<ItestFieldValueDualObject>
{
  public testEnumFieldValueDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDualDecoder : IDecoder<testEnumFieldValueDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDual".AnError();
  }

  internal static testEnumFieldValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueInpDecoder : IDecoder<ItestFieldValueInpObject>
{
  public testEnumFieldValueInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueInpDecoder : IDecoder<testEnumFieldValueInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueInp".AnError();
  }

  internal static testEnumFieldValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueOutpDecoder : IDecoder<testEnumFieldValueOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueOutp".AnError();
  }

  internal static testEnumFieldValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueDescrDualDecoder : IDecoder<ItestFieldValueDescrDualObject>
{
  public testEnumFieldValueDescrDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrDualDecoder : IDecoder<testEnumFieldValueDescrDual?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDescrDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDescrDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDescrDual".AnError();
  }

  internal static testEnumFieldValueDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldValueDescrInpDecoder : IDecoder<ItestFieldValueDescrInpObject>
{
  public testEnumFieldValueDescrInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestFieldValueDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFieldValueDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrInpDecoder : IDecoder<testEnumFieldValueDescrInp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDescrInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDescrInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDescrInp".AnError();
  }

  internal static testEnumFieldValueDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumFieldValueDescrOutpDecoder : IDecoder<testEnumFieldValueDescrOutp?>
{
  public IMessages Decode(IValue input, out testEnumFieldValueDescrOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumFieldValueDescrOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumFieldValueDescrOutp".AnError();
  }

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

internal class testGnrcAltDualDualDecoder : IDecoder<ItestGnrcAltDualDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltDualDualDecoder<TRef>
{
}

internal class testAltGnrcAltDualDualDecoder : IDecoder<ItestAltGnrcAltDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcAltDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcAltDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcAltDualInpDecoder : IDecoder<ItestGnrcAltDualInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltDualInpDecoder<TRef>
{
}

internal class testAltGnrcAltDualInpDecoder : IDecoder<ItestAltGnrcAltDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcAltDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcAltDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcAltDualOutpDecoder : IDecoder<ItestAltGnrcAltDualOutpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcAltDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

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

internal class testGnrcAltParamDualDecoder : IDecoder<ItestGnrcAltParamDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcAltParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcAltParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltParamDualDecoder<TRef>
{
}

internal class testAltGnrcAltParamDualDecoder : IDecoder<ItestAltGnrcAltParamDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcAltParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcAltParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcAltParamInpDecoder : IDecoder<ItestGnrcAltParamInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcAltParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcAltParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltParamInpDecoder<TRef>
{
}

internal class testAltGnrcAltParamInpDecoder : IDecoder<ItestAltGnrcAltParamInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcAltParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcAltParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcAltSmplDualDecoder : IDecoder<ItestGnrcAltSmplDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcAltSmplDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcAltSmplDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltSmplDualDecoder<TRef>
{
}

internal class testGnrcAltSmplInpDecoder : IDecoder<ItestGnrcAltSmplInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcAltSmplInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcAltSmplInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcAltSmplInpDecoder<TRef>
{
}

internal class testGnrcDescrDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testGnrcDescrInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testGnrcEnumDualDecoder : IDecoder<ItestGnrcEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumGnrcEnumDualDecoder : IDecoder<testEnumGnrcEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcEnumDual".AnError();
  }

  internal static testEnumGnrcEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcEnumInpDecoder : IDecoder<ItestGnrcEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcEnumInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumGnrcEnumInpDecoder : IDecoder<testEnumGnrcEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcEnumInp".AnError();
  }

  internal static testEnumGnrcEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcEnumOutpDecoder : IDecoder<testEnumGnrcEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcEnumOutp".AnError();
  }

  internal static testEnumGnrcEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testGnrcFieldInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testGnrcFieldArgDualDecoder<TType>
{
  public ItestRefGnrcFieldArgDual<TType>? Field { get; set; }
}

internal class testRefGnrcFieldArgDualDecoder<TRef>
{
}

internal class testGnrcFieldArgInpDecoder<TType>
{
  public ItestRefGnrcFieldArgInp<TType>? Field { get; set; }
}

internal class testRefGnrcFieldArgInpDecoder<TRef>
{
}

internal class testGnrcFieldDualDualDecoder : IDecoder<ItestGnrcFieldDualDualObject>
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestGnrcFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldDualDualDecoder<TRef>
{
}

internal class testAltGnrcFieldDualDualDecoder : IDecoder<ItestAltGnrcFieldDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcFieldDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcFieldDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldDualInpDecoder : IDecoder<ItestGnrcFieldDualInpObject>
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestGnrcFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldDualInpDecoder<TRef>
{
}

internal class testAltGnrcFieldDualInpDecoder : IDecoder<ItestAltGnrcFieldDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcFieldDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcFieldDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcFieldDualOutpDecoder : IDecoder<ItestAltGnrcFieldDualOutpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcFieldDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcFieldDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldParamDualDecoder : IDecoder<ItestGnrcFieldParamDualObject>
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestGnrcFieldParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcFieldParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldParamDualDecoder<TRef>
{
}

internal class testAltGnrcFieldParamDualDecoder : IDecoder<ItestAltGnrcFieldParamDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcFieldParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcFieldParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcFieldParamInpDecoder : IDecoder<ItestGnrcFieldParamInpObject>
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp>? Field { get; set; }

  public IMessages Decode(IValue input, out ItestGnrcFieldParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcFieldParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcFieldParamInpDecoder<TRef>
{
}

internal class testAltGnrcFieldParamInpDecoder : IDecoder<ItestAltGnrcFieldParamInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcFieldParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

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

internal class testGnrcPrntDualDualDecoder : IDecoder<ItestGnrcPrntDualDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualDualDecoder<TRef>
{
}

internal class testAltGnrcPrntDualDualDecoder : IDecoder<ItestAltGnrcPrntDualDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntDualInpDecoder : IDecoder<ItestGnrcPrntDualInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualInpDecoder<TRef>
{
}

internal class testAltGnrcPrntDualInpDecoder : IDecoder<ItestAltGnrcPrntDualInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcPrntDualOutpDecoder : IDecoder<ItestAltGnrcPrntDualOutpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntDualPrntDualDecoder : IDecoder<ItestGnrcPrntDualPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntDualPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualPrntDualDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntDualDecoder : IDecoder<ItestAltGnrcPrntDualPrntDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntDualPrntInpDecoder : IDecoder<ItestGnrcPrntDualPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntDualPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntDualPrntInpDecoder<TRef>
{
}

internal class testAltGnrcPrntDualPrntInpDecoder : IDecoder<ItestAltGnrcPrntDualPrntInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testAltGnrcPrntDualPrntOutpDecoder : IDecoder<ItestAltGnrcPrntDualPrntOutpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntDualPrntOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntDualPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumChildDualDecoder : IDecoder<ItestGnrcPrntEnumChildDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumChildDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumChildDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumChildDualDecoder : IDecoder<testEnumGnrcPrntEnumChildDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumChildDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumChildDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumChildDual".AnError();
  }

  internal static testEnumGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildDualDecoder : IDecoder<testParentGnrcPrntEnumChildDual?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumChildDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumChildDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumChildDual".AnError();
  }

  internal static testParentGnrcPrntEnumChildDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumChildInpDecoder : IDecoder<ItestGnrcPrntEnumChildInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumChildInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumChildInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumChildInpDecoder : IDecoder<testEnumGnrcPrntEnumChildInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumChildInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumChildInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumChildInp".AnError();
  }

  internal static testEnumGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildInpDecoder : IDecoder<testParentGnrcPrntEnumChildInp?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumChildInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumChildInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumChildInp".AnError();
  }

  internal static testParentGnrcPrntEnumChildInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumChildOutpDecoder : IDecoder<testEnumGnrcPrntEnumChildOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumChildOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumChildOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumChildOutp".AnError();
  }

  internal static testEnumGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumChildOutpDecoder : IDecoder<testParentGnrcPrntEnumChildOutp?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumChildOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumChildOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumChildOutp".AnError();
  }

  internal static testParentGnrcPrntEnumChildOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumDomDualDecoder : IDecoder<ItestGnrcPrntEnumDomDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumDomDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomDualDecoder : IDecoder<testEnumGnrcPrntEnumDomDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumDomDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumDomDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumDomDual".AnError();
  }

  internal static testEnumGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomDualDecoder : IDecoder<ItestDomGnrcPrntEnumDomDual>
{
  public testEnumGnrcPrntEnumDomDual? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDomGnrcPrntEnumDomDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntEnumDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumDomInpDecoder : IDecoder<ItestGnrcPrntEnumDomInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumDomInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumDomInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumDomInpDecoder : IDecoder<testEnumGnrcPrntEnumDomInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumDomInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumDomInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumDomInp".AnError();
  }

  internal static testEnumGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomInpDecoder : IDecoder<ItestDomGnrcPrntEnumDomInp>
{
  public testEnumGnrcPrntEnumDomInp? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDomGnrcPrntEnumDomInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntEnumDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumDomOutpDecoder : IDecoder<testEnumGnrcPrntEnumDomOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumDomOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumDomOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumDomOutp".AnError();
  }

  internal static testEnumGnrcPrntEnumDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntEnumDomOutpDecoder : IDecoder<ItestDomGnrcPrntEnumDomOutp>
{
  public testEnumGnrcPrntEnumDomOutp? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDomGnrcPrntEnumDomOutp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntEnumDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntDualDecoder : IDecoder<ItestGnrcPrntEnumPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumPrntDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumPrntDualDecoder : IDecoder<testEnumGnrcPrntEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumPrntDual".AnError();
  }

  internal static testEnumGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntDualDecoder : IDecoder<testParentGnrcPrntEnumPrntDual?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumPrntDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumPrntDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumPrntDual".AnError();
  }

  internal static testParentGnrcPrntEnumPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntEnumPrntInpDecoder : IDecoder<ItestGnrcPrntEnumPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntEnumPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntEnumPrntInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntEnumPrntInpDecoder : IDecoder<testEnumGnrcPrntEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumPrntInp".AnError();
  }

  internal static testEnumGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntInpDecoder : IDecoder<testParentGnrcPrntEnumPrntInp?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumPrntInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumPrntInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumPrntInp".AnError();
  }

  internal static testParentGnrcPrntEnumPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntEnumPrntOutpDecoder : IDecoder<testEnumGnrcPrntEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntEnumPrntOutp".AnError();
  }

  internal static testEnumGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testParentGnrcPrntEnumPrntOutpDecoder : IDecoder<testParentGnrcPrntEnumPrntOutp?>
{
  public IMessages Decode(IValue input, out testParentGnrcPrntEnumPrntOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testParentGnrcPrntEnumPrntOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testParentGnrcPrntEnumPrntOutp".AnError();
  }

  internal static testParentGnrcPrntEnumPrntOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamDualDecoder : IDecoder<ItestGnrcPrntParamDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamDualDecoder<TRef>
{
}

internal class testAltGnrcPrntParamDualDecoder : IDecoder<ItestAltGnrcPrntParamDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntParamDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntParamDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamInpDecoder : IDecoder<ItestGnrcPrntParamInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamInpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamInpDecoder : IDecoder<ItestAltGnrcPrntParamInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntParamInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntParamInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamPrntDualDecoder : IDecoder<ItestGnrcPrntParamPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntParamPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntParamPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamPrntDualDecoder<TRef>
{
}

internal class testAltGnrcPrntParamPrntDualDecoder : IDecoder<ItestAltGnrcPrntParamPrntDualObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntParamPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntParamPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntParamPrntInpDecoder : IDecoder<ItestGnrcPrntParamPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntParamPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntParamPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcPrntParamPrntInpDecoder<TRef>
{
}

internal class testAltGnrcPrntParamPrntInpDecoder : IDecoder<ItestAltGnrcPrntParamPrntInpObject>
{
  public decimal? Alt { get; set; }

  public IMessages Decode(IValue input, out ItestAltGnrcPrntParamPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testAltGnrcPrntParamPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumDualDecoder : IDecoder<ItestGnrcPrntSmplEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntSmplEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntSmplEnumDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntSmplEnumDualDecoder : IDecoder<testEnumGnrcPrntSmplEnumDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntSmplEnumDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntSmplEnumDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntSmplEnumDual".AnError();
  }

  internal static testEnumGnrcPrntSmplEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntSmplEnumInpDecoder : IDecoder<ItestGnrcPrntSmplEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntSmplEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntSmplEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntSmplEnumInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testEnumGnrcPrntSmplEnumInpDecoder : IDecoder<testEnumGnrcPrntSmplEnumInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntSmplEnumInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntSmplEnumInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntSmplEnumInp".AnError();
  }

  internal static testEnumGnrcPrntSmplEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcPrntSmplEnumOutpDecoder : IDecoder<testEnumGnrcPrntSmplEnumOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcPrntSmplEnumOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcPrntSmplEnumOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcPrntSmplEnumOutp".AnError();
  }

  internal static testEnumGnrcPrntSmplEnumOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntStrDomDualDecoder : IDecoder<ItestGnrcPrntStrDomDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntStrDomDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntStrDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntStrDomDualDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testDomGnrcPrntStrDomDualDecoder : IDecoder<ItestDomGnrcPrntStrDomDual>
{

  public IMessages Decode(IValue input, out ItestDomGnrcPrntStrDomDual? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntStrDomDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcPrntStrDomInpDecoder : IDecoder<ItestGnrcPrntStrDomInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcPrntStrDomInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcPrntStrDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFieldGnrcPrntStrDomInpDecoder<TRef>
{
  public TRef? Field { get; set; }
}

internal class testDomGnrcPrntStrDomInpDecoder : IDecoder<ItestDomGnrcPrntStrDomInp>
{

  public IMessages Decode(IValue input, out ItestDomGnrcPrntStrDomInp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntStrDomInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomGnrcPrntStrDomOutpDecoder : IDecoder<ItestDomGnrcPrntStrDomOutp>
{

  public IMessages Decode(IValue input, out ItestDomGnrcPrntStrDomOutp? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomGnrcPrntStrDomOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcValueDualDecoder : IDecoder<ItestGnrcValueDualObject>
{

  public IMessages Decode(IValue input, out ItestGnrcValueDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcValueDualDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumGnrcValueDualDecoder : IDecoder<testEnumGnrcValueDual?>
{
  public IMessages Decode(IValue input, out testEnumGnrcValueDual? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcValueDual value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcValueDual".AnError();
  }

  internal static testEnumGnrcValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testGnrcValueInpDecoder : IDecoder<ItestGnrcValueInpObject>
{

  public IMessages Decode(IValue input, out ItestGnrcValueInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testGnrcValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefGnrcValueInpDecoder<TType>
{
  public TType? Field { get; set; }
}

internal class testEnumGnrcValueInpDecoder : IDecoder<testEnumGnrcValueInp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcValueInp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcValueInp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcValueInp".AnError();
  }

  internal static testEnumGnrcValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumGnrcValueOutpDecoder : IDecoder<testEnumGnrcValueOutp?>
{
  public IMessages Decode(IValue input, out testEnumGnrcValueOutp? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumGnrcValueOutp value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumGnrcValueOutp".AnError();
  }

  internal static testEnumGnrcValueOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldDescrNmbrDecoder : IDecoder<ItestInpFieldDescrNmbrObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldDescrNmbrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldDescrNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldEnumDecoder : IDecoder<ItestInpFieldEnumObject>
{
  public testEnumInpFieldEnum? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldEnumObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldEnumDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumInpFieldEnumDecoder : IDecoder<testEnumInpFieldEnum?>
{
  public IMessages Decode(IValue input, out testEnumInpFieldEnum? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumInpFieldEnum value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumInpFieldEnum".AnError();
  }

  internal static testEnumInpFieldEnumDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldNullDecoder : IDecoder<ItestInpFieldNullObject>
{
  public ItestFldInpFieldNull? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldNullObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldNullDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldInpFieldNullDecoder : IDecoder<ItestFldInpFieldNullObject>
{

  public IMessages Decode(IValue input, out ItestFldInpFieldNullObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldInpFieldNullDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldNmbrDecoder : IDecoder<ItestInpFieldNmbrObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldNmbrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldNmbrDescrDecoder : IDecoder<ItestInpFieldNmbrDescrObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldNmbrDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInpFieldStrDecoder : IDecoder<ItestInpFieldStrObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestInpFieldStrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInpFieldStrDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpDescrParamDecoder : IDecoder<ItestFldOutpDescrParamObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpDescrParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpDescrParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpDescrParamDecoder : IDecoder<ItestInOutpDescrParamObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpDescrParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpDescrParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpParamDecoder : IDecoder<ItestFldOutpParamObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamDecoder : IDecoder<ItestInOutpParamObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpParamDescrDecoder : IDecoder<ItestFldOutpParamDescrObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpParamDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpParamDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamDescrDecoder : IDecoder<ItestInOutpParamDescrObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamModDmnDecoder : IDecoder<ItestInOutpParamModDmnObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamModDmnObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomOutpParamModDmnDecoder : IDecoder<ItestDomOutpParamModDmn>
{

  public IMessages Decode(IValue input, out ItestDomOutpParamModDmn? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomOutpParamModDmnDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamModParamDecoder : IDecoder<ItestInOutpParamModParamObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamModParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamModParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDomOutpParamModParamDecoder : IDecoder<ItestDomOutpParamModParam>
{

  public IMessages Decode(IValue input, out ItestDomOutpParamModParam? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDomOutpParamModParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpParamTypeDescrDecoder : IDecoder<ItestFldOutpParamTypeDescrObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpParamTypeDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpParamTypeDescrDecoder : IDecoder<ItestInOutpParamTypeDescrObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpParamTypeDescrObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpParamTypeDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumOutpPrntGnrcDecoder : IDecoder<testEnumOutpPrntGnrc?>
{
  public IMessages Decode(IValue input, out testEnumOutpPrntGnrc? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumOutpPrntGnrc value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumOutpPrntGnrc".AnError();
  }

  internal static testEnumOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntGnrcDecoder : IDecoder<testPrntOutpPrntGnrc?>
{
  public IMessages Decode(IValue input, out testPrntOutpPrntGnrc? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntOutpPrntGnrc value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntOutpPrntGnrc".AnError();
  }

  internal static testPrntOutpPrntGnrcDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpPrntParamDecoder : IDecoder<ItestFldOutpPrntParamObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpPrntParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testInOutpPrntParamDecoder : IDecoder<ItestInOutpPrntParamObject>
{
  public decimal? Param { get; set; }

  public IMessages Decode(IValue input, out ItestInOutpPrntParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInOutpPrntParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntOutpPrntParamInDecoder : IDecoder<ItestPrntOutpPrntParamInObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestPrntOutpPrntParamInObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntOutpPrntParamInDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDualDecoder : IDecoder<ItestPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualDecoder : IDecoder<ItestRefPrntDualObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntInpDecoder : IDecoder<ItestPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntInpDecoder : IDecoder<ItestRefPrntInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntAltDualDecoder : IDecoder<ItestPrntAltDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntAltDualDecoder : IDecoder<ItestRefPrntAltDualObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntAltInpDecoder : IDecoder<ItestPrntAltInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntAltInpDecoder : IDecoder<ItestRefPrntAltInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDescrDualDecoder : IDecoder<ItestPrntDescrDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDescrDualDecoder : IDecoder<ItestRefPrntDescrDualObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDescrDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDescrDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDescrInpDecoder : IDecoder<ItestPrntDescrInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDescrInpDecoder : IDecoder<ItestRefPrntDescrInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDescrInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDescrInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDualDualDecoder : IDecoder<ItestPrntDualDualObject>
{

  public IMessages Decode(IValue input, out ItestPrntDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualDualDecoder : IDecoder<ItestRefPrntDualDualObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDualDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDualDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDualInpDecoder : IDecoder<ItestPrntDualInpObject>
{

  public IMessages Decode(IValue input, out ItestPrntDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualInpDecoder : IDecoder<ItestRefPrntDualInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDualInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDualInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntDualOutpDecoder : IDecoder<ItestRefPrntDualOutpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntDualOutpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntDualOutpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldDualDecoder : IDecoder<ItestPrntFieldDualObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestPrntFieldDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntFieldDualDecoder : IDecoder<ItestRefPrntFieldDualObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntFieldDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntFieldInpDecoder : IDecoder<ItestPrntFieldInpObject>
{
  public decimal? Field { get; set; }

  public IMessages Decode(IValue input, out ItestPrntFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefPrntFieldInpDecoder : IDecoder<ItestRefPrntFieldInpObject>
{
  public decimal? Parent { get; set; }

  public IMessages Decode(IValue input, out ItestRefPrntFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefPrntFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntParamDiffDualDecoder<TA>
{
  public TA? Field { get; set; }
}

internal class testRefPrntParamDiffDualDecoder<TB>
{
}

internal class testPrntParamDiffInpDecoder<TA>
{
  public TA? Field { get; set; }
}

internal class testRefPrntParamDiffInpDecoder<TB>
{
}

internal class testPrntParamSameDualDecoder<TA>
{
  public TA? Field { get; set; }
}

internal class testRefPrntParamSameDualDecoder<TA>
{
}

internal class testPrntParamSameInpDecoder<TA>
{
  public TA? Field { get; set; }
}

internal class testRefPrntParamSameInpDecoder<TA>
{
}

internal class testInDrctParamDecoder : IDecoder<ItestInDrctParamObject>
{

  public IMessages Decode(IValue input, out ItestInDrctParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testInDrctParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnAliasDecoder : IDecoder<ItestDmnAlias>
{

  public IMessages Decode(IValue input, out ItestDmnAlias? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDecoder : IDecoder<ItestDmnBool>
{

  public IMessages Decode(IValue input, out ItestDmnBool? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDiffDecoder : IDecoder<ItestDmnBoolDiff>
{

  public IMessages Decode(IValue input, out ItestDmnBoolDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolSameDecoder : IDecoder<ItestDmnBoolSame>
{

  public IMessages Decode(IValue input, out ItestDmnBoolSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDiffDecoder : IDecoder<ItestDmnEnumDiff>
{
  public bool? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumSameDecoder : IDecoder<ItestDmnEnumSame>
{
  public bool? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDecoder : IDecoder<ItestDmnNmbr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDiffDecoder : IDecoder<ItestDmnNmbrDiff>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrSameDecoder : IDecoder<ItestDmnNmbrSame>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDecoder : IDecoder<ItestDmnStr>
{

  public IMessages Decode(IValue input, out ItestDmnStr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDiffDecoder : IDecoder<ItestDmnStrDiff>
{

  public IMessages Decode(IValue input, out ItestDmnStrDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrSameDecoder : IDecoder<ItestDmnStrSame>
{

  public IMessages Decode(IValue input, out ItestDmnStrSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumAliasDecoder : IDecoder<testEnumAlias?>
{
  public IMessages Decode(IValue input, out testEnumAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumAlias".AnError();
  }

  internal static testEnumAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDiffDecoder : IDecoder<testEnumDiff?>
{
  public IMessages Decode(IValue input, out testEnumDiff? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDiff value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDiff".AnError();
  }

  internal static testEnumDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSameDecoder : IDecoder<testEnumSame?>
{
  public IMessages Decode(IValue input, out testEnumSame? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumSame value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumSame".AnError();
  }

  internal static testEnumSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumSamePrntDecoder : IDecoder<testEnumSamePrnt?>
{
  public IMessages Decode(IValue input, out testEnumSamePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumSamePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumSamePrnt".AnError();
  }

  internal static testEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumSamePrntDecoder : IDecoder<testPrntEnumSamePrnt?>
{
  public IMessages Decode(IValue input, out testPrntEnumSamePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumSamePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumSamePrnt".AnError();
  }

  internal static testPrntEnumSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumValueAliasDecoder : IDecoder<testEnumValueAlias?>
{
  public IMessages Decode(IValue input, out testEnumValueAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumValueAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumValueAlias".AnError();
  }

  internal static testEnumValueAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjDualDecoder : IDecoder<ItestObjDualObject>
{

  public IMessages Decode(IValue input, out ItestObjDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjInpDecoder : IDecoder<ItestObjInpObject>
{

  public IMessages Decode(IValue input, out ItestObjInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasDualDecoder : IDecoder<ItestObjAliasDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAliasInpDecoder : IDecoder<ItestObjAliasInpObject>
{

  public IMessages Decode(IValue input, out ItestObjAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualDecoder : IDecoder<ItestObjAltDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAltDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltDualTypeDecoder : IDecoder<ItestObjAltDualTypeObject>
{

  public IMessages Decode(IValue input, out ItestObjAltDualTypeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltDualTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpDecoder : IDecoder<ItestObjAltInpObject>
{

  public IMessages Decode(IValue input, out ItestObjAltInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltInpTypeDecoder : IDecoder<ItestObjAltInpTypeObject>
{

  public IMessages Decode(IValue input, out ItestObjAltInpTypeObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltInpTypeDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumDualDecoder : IDecoder<ItestObjAltEnumDualObject>
{

  public IMessages Decode(IValue input, out ItestObjAltEnumDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltEnumDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjAltEnumInpDecoder : IDecoder<ItestObjAltEnumInpObject>
{

  public IMessages Decode(IValue input, out ItestObjAltEnumInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjAltEnumInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjCnstDualDecoder<TType>
{
  public TType? Field { get; set; }
  public TType? Str { get; set; }
}

internal class testObjCnstInpDecoder<TType>
{
  public TType? Field { get; set; }
  public TType? Str { get; set; }
}

internal class testObjFieldDualDecoder : IDecoder<ItestObjFieldDualObject>
{
  public ItestFldObjFieldDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldDualDecoder : IDecoder<ItestFldObjFieldDualObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldInpDecoder : IDecoder<ItestObjFieldInpObject>
{
  public ItestFldObjFieldInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldInpDecoder : IDecoder<ItestFldObjFieldInpObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasDualDecoder : IDecoder<ItestObjFieldAliasDualObject>
{
  public ItestFldObjFieldAliasDual? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasDualDecoder : IDecoder<ItestFldObjFieldAliasDualObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldAliasInpDecoder : IDecoder<ItestObjFieldAliasInpObject>
{
  public ItestFldObjFieldAliasInp? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testFldObjFieldAliasInpDecoder : IDecoder<ItestFldObjFieldAliasInpObject>
{

  public IMessages Decode(IValue input, out ItestFldObjFieldAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldObjFieldAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasDualDecoder : IDecoder<ItestObjFieldEnumAliasDualObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumAliasInpDecoder : IDecoder<ItestObjFieldEnumAliasInpObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueDualDecoder : IDecoder<ItestObjFieldEnumValueDualObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumValueDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumValueDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldEnumValueInpDecoder : IDecoder<ItestObjFieldEnumValueInpObject>
{
  public bool? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldEnumValueInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldEnumValueInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasDualDecoder : IDecoder<ItestObjFieldTypeAliasDualObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldTypeAliasDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldTypeAliasDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjFieldTypeAliasInpDecoder : IDecoder<ItestObjFieldTypeAliasInpObject>
{
  public string? Field { get; set; }

  public IMessages Decode(IValue input, out ItestObjFieldTypeAliasInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjFieldTypeAliasInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjParamDualDecoder<TTest,TType>
{
  public TTest? Test { get; set; }
  public TType? Type { get; set; }
}

internal class testObjParamInpDecoder<TTest,TType>
{
  public TTest? Test { get; set; }
  public TType? Type { get; set; }
}

internal class testObjParamDupDualDecoder<TTest>
{
  public TTest? Test { get; set; }
  public TTest? Type { get; set; }
}

internal class testObjParamDupInpDecoder<TTest>
{
  public TTest? Test { get; set; }
  public TTest? Type { get; set; }
}

internal class testObjPrntDualDecoder : IDecoder<ItestObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntDualDecoder : IDecoder<ItestRefObjPrntDualObject>
{

  public IMessages Decode(IValue input, out ItestRefObjPrntDualObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefObjPrntDualDecoder Factory(IDecoderRepository _) => new();
}

internal class testObjPrntInpDecoder : IDecoder<ItestObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testRefObjPrntInpDecoder : IDecoder<ItestRefObjPrntInpObject>
{

  public IMessages Decode(IValue input, out ItestRefObjPrntInpObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testRefObjPrntInpDecoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam1Decoder : IDecoder<ItestOutpFieldParam1Object>
{

  public IMessages Decode(IValue input, out ItestOutpFieldParam1Object? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testOutpFieldParam1Decoder Factory(IDecoderRepository _) => new();
}

internal class testOutpFieldParam2Decoder : IDecoder<ItestOutpFieldParam2Object>
{

  public IMessages Decode(IValue input, out ItestOutpFieldParam2Object? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testOutpFieldParam2Decoder Factory(IDecoderRepository _) => new();
}

internal class testFldOutpFieldParamDecoder : IDecoder<ItestFldOutpFieldParamObject>
{

  public IMessages Decode(IValue input, out ItestFldOutpFieldParamObject? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testFldOutpFieldParamDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionAliasDecoder : IDecoder<ItestUnionAlias>
{
  public Boolean? AsBoolean { get; set; }
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionAlias? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDiffDecoder : IDecoder<ItestUnionDiff>
{
  public Boolean? AsBoolean { get; set; }
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionDiff? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionDiffDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSameDecoder : IDecoder<ItestUnionSame>
{
  public Boolean? AsBoolean { get; set; }

  public IMessages Decode(IValue input, out ItestUnionSame? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionSameDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionSamePrntDecoder : IDecoder<ItestUnionSamePrnt>
{
  public Boolean? AsBoolean { get; set; }

  public IMessages Decode(IValue input, out ItestUnionSamePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionSamePrntDecoder : IDecoder<ItestPrntUnionSamePrnt>
{
  public String? AsString { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionSamePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionSamePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolDescrDecoder : IDecoder<ItestDmnBoolDescr>
{

  public IMessages Decode(IValue input, out ItestDmnBoolDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDecoder : IDecoder<ItestDmnBoolPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnBoolPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDecoder : IDecoder<ItestPrntDmnBoolPrnt>
{

  public IMessages Decode(IValue input, out ItestPrntDmnBoolPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnBoolPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnBoolPrntDescrDecoder : IDecoder<ItestDmnBoolPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnBoolPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnBoolPrntDescrDecoder : IDecoder<ItestPrntDmnBoolPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnBoolPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnBoolPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDecoder : IDecoder<ItestDmnEnumAll>
{
  public testEnumDmnEnumAll? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAll? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDecoder : IDecoder<testEnumDmnEnumAll?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAll? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAll value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAll".AnError();
  }

  internal static testEnumDmnEnumAllDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllDescrDecoder : IDecoder<ItestDmnEnumAllDescr>
{
  public testEnumDmnEnumAllDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAllDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllDescrDecoder : IDecoder<testEnumDmnEnumAllDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAllDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAllDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAllDescr".AnError();
  }

  internal static testEnumDmnEnumAllDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumAllPrntDecoder : IDecoder<ItestDmnEnumAllPrnt>
{
  public testEnumDmnEnumAllPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumAllPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumAllPrntDecoder : IDecoder<testEnumDmnEnumAllPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumAllPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumAllPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumAllPrnt".AnError();
  }

  internal static testEnumDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumAllPrntDecoder : IDecoder<testPrntDmnEnumAllPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumAllPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumAllPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumAllPrnt".AnError();
  }

  internal static testPrntDmnEnumAllPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumDescrDecoder : IDecoder<ItestDmnEnumDescr>
{
  public testEnumDmnEnumDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumDescrDecoder : IDecoder<testEnumDmnEnumDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumDescr".AnError();
  }

  internal static testEnumDmnEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclDecoder : IDecoder<ItestDmnEnumExcl>
{
  public testEnumDmnEnumExcl? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumExcl? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclDecoder : IDecoder<testEnumDmnEnumExcl?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumExcl? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumExcl value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumExcl".AnError();
  }

  internal static testEnumDmnEnumExclDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumExclPrntDecoder : IDecoder<ItestDmnEnumExclPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnEnumExclPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumExclPrntDecoder : IDecoder<testEnumDmnEnumExclPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumExclPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumExclPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumExclPrnt".AnError();
  }

  internal static testEnumDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumExclPrntDecoder : IDecoder<testPrntDmnEnumExclPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumExclPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumExclPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumExclPrnt".AnError();
  }

  internal static testPrntDmnEnumExclPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumLabelDecoder : IDecoder<ItestDmnEnumLabel>
{
  public testEnumDmnEnumLabel? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumLabel? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumLabelDecoder : IDecoder<testEnumDmnEnumLabel?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumLabel? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumLabel value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumLabel".AnError();
  }

  internal static testEnumDmnEnumLabelDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDecoder : IDecoder<ItestDmnEnumPrnt>
{
  public testEnumDmnEnumPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDecoder : IDecoder<ItestPrntDmnEnumPrnt>
{
  public testEnumDmnEnumPrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestPrntDmnEnumPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDecoder : IDecoder<testEnumDmnEnumPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumPrnt".AnError();
  }

  internal static testEnumDmnEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumPrntDescrDecoder : IDecoder<ItestDmnEnumPrntDescr>
{
  public testEnumDmnEnumPrntDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumPrntDescrDecoder : IDecoder<ItestPrntDmnEnumPrntDescr>
{
  public testEnumDmnEnumPrntDescr? Value { get; set; }

  public IMessages Decode(IValue input, out ItestPrntDmnEnumPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumPrntDescrDecoder : IDecoder<testEnumDmnEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumPrntDescr".AnError();
  }

  internal static testEnumDmnEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqDecoder : IDecoder<ItestDmnEnumUnq>
{

  public IMessages Decode(IValue input, out ItestDmnEnumUnq? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqDecoder : IDecoder<testEnumDmnEnumUnq?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumUnq? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumUnq value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumUnq".AnError();
  }

  internal static testEnumDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqDecoder : IDecoder<testDupDmnEnumUnq?>
{
  public IMessages Decode(IValue input, out testDupDmnEnumUnq? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testDupDmnEnumUnq value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testDupDmnEnumUnq".AnError();
  }

  internal static testDupDmnEnumUnqDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumUnqPrntDecoder : IDecoder<ItestDmnEnumUnqPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnEnumUnqPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumUnqPrntDecoder : IDecoder<testEnumDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumUnqPrnt".AnError();
  }

  internal static testEnumDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumUnqPrntDecoder : IDecoder<testPrntDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumUnqPrnt".AnError();
  }

  internal static testPrntDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDupDmnEnumUnqPrntDecoder : IDecoder<testDupDmnEnumUnqPrnt?>
{
  public IMessages Decode(IValue input, out testDupDmnEnumUnqPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testDupDmnEnumUnqPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testDupDmnEnumUnqPrnt".AnError();
  }

  internal static testDupDmnEnumUnqPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValueDecoder : IDecoder<ItestDmnEnumValue>
{
  public testEnumDmnEnumValue? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumValue? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValueDecoder : IDecoder<testEnumDmnEnumValue?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumValue? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumValue value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumValue".AnError();
  }

  internal static testEnumDmnEnumValueDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnEnumValuePrntDecoder : IDecoder<ItestDmnEnumValuePrnt>
{
  public testEnumDmnEnumValuePrnt? Value { get; set; }

  public IMessages Decode(IValue input, out ItestDmnEnumValuePrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDmnEnumValuePrntDecoder : IDecoder<testEnumDmnEnumValuePrnt?>
{
  public IMessages Decode(IValue input, out testEnumDmnEnumValuePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDmnEnumValuePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDmnEnumValuePrnt".AnError();
  }

  internal static testEnumDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnEnumValuePrntDecoder : IDecoder<testPrntDmnEnumValuePrnt?>
{
  public IMessages Decode(IValue input, out testPrntDmnEnumValuePrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntDmnEnumValuePrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntDmnEnumValuePrnt".AnError();
  }

  internal static testPrntDmnEnumValuePrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrDescrDecoder : IDecoder<ItestDmnNmbrDescr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDecoder : IDecoder<ItestDmnNmbrPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDecoder : IDecoder<ItestPrntDmnNmbrPrnt>
{

  public IMessages Decode(IValue input, out ItestPrntDmnNmbrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnNmbrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPrntDescrDecoder : IDecoder<ItestDmnNmbrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnNmbrPrntDescrDecoder : IDecoder<ItestPrntDmnNmbrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnNmbrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnNmbrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrPstvDecoder : IDecoder<ItestDmnNmbrPstv>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrPstv? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrPstvDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnNmbrRangeDecoder : IDecoder<ItestDmnNmbrRange>
{

  public IMessages Decode(IValue input, out ItestDmnNmbrRange? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnNmbrRangeDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrDescrDecoder : IDecoder<ItestDmnStrDescr>
{

  public IMessages Decode(IValue input, out ItestDmnStrDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrNonEmptyDecoder : IDecoder<ItestDmnStrNonEmpty>
{

  public IMessages Decode(IValue input, out ItestDmnStrNonEmpty? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrNonEmptyDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDecoder : IDecoder<ItestDmnStrPrnt>
{

  public IMessages Decode(IValue input, out ItestDmnStrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDecoder : IDecoder<ItestPrntDmnStrPrnt>
{

  public IMessages Decode(IValue input, out ItestPrntDmnStrPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnStrPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testDmnStrPrntDescrDecoder : IDecoder<ItestDmnStrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestDmnStrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntDmnStrPrntDescrDecoder : IDecoder<ItestPrntDmnStrPrntDescr>
{

  public IMessages Decode(IValue input, out ItestPrntDmnStrPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntDmnStrPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumDescrDecoder : IDecoder<testEnumDescr?>
{
  public IMessages Decode(IValue input, out testEnumDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumDescr".AnError();
  }

  internal static testEnumDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDecoder : IDecoder<testEnumPrnt?>
{
  public IMessages Decode(IValue input, out testEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrnt".AnError();
  }

  internal static testEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDecoder : IDecoder<testPrntEnumPrnt?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrnt? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrnt value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrnt".AnError();
  }

  internal static testPrntEnumPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntAliasDecoder : IDecoder<testEnumPrntAlias?>
{
  public IMessages Decode(IValue input, out testEnumPrntAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntAlias".AnError();
  }

  internal static testEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntAliasDecoder : IDecoder<testPrntEnumPrntAlias?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntAlias? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntAlias value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntAlias".AnError();
  }

  internal static testPrntEnumPrntAliasDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDescrDecoder : IDecoder<testEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntDescr".AnError();
  }

  internal static testEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDescrDecoder : IDecoder<testPrntEnumPrntDescr?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntDescr? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntDescr value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntDescr".AnError();
  }

  internal static testPrntEnumPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testEnumPrntDupDecoder : IDecoder<testEnumPrntDup?>
{
  public IMessages Decode(IValue input, out testEnumPrntDup? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testEnumPrntDup value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testEnumPrntDup".AnError();
  }

  internal static testEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntEnumPrntDupDecoder : IDecoder<testPrntEnumPrntDup?>
{
  public IMessages Decode(IValue input, out testPrntEnumPrntDup? output)
  {
    if (input.TryGetText(out string? text) && Enum.TryParse(text, out testPrntEnumPrntDup value))
    {
      output = value;
      return Messages.New;
    }
    output = null;
    return "Unable to decode testPrntEnumPrntDup".AnError();
  }

  internal static testPrntEnumPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionDescrDecoder : IDecoder<ItestUnionDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDecoder : IDecoder<ItestUnionPrnt>
{
  public String? AsString { get; set; }

  public IMessages Decode(IValue input, out ItestUnionPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDecoder : IDecoder<ItestPrntUnionPrnt>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionPrnt? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionPrntDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDescrDecoder : IDecoder<ItestUnionPrntDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDescrDecoder : IDecoder<ItestPrntUnionPrntDescr>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionPrntDescr? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testPrntUnionPrntDescrDecoder Factory(IDecoderRepository _) => new();
}

internal class testUnionPrntDupDecoder : IDecoder<ItestUnionPrntDup>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestUnionPrntDup? output)
  {
    output = null;
    return Messages.New;
  }

  internal static testUnionPrntDupDecoder Factory(IDecoderRepository _) => new();
}

internal class testPrntUnionPrntDupDecoder : IDecoder<ItestPrntUnionPrntDup>
{
  public Number? AsNumber { get; set; }

  public IMessages Decode(IValue input, out ItestPrntUnionPrntDup? output)
  {
    output = null;
    return Messages.New;
  }

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
