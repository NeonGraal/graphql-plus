//HintName: test_+Objects_Impl.gen.cs
// Generated from +Objects.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Objects;

public class testAltDual
  : ItestAltDual
{
  public ItestAltAltDual AsAltAltDual { get; set; }
  public ItestAltDualObject AsAltDual { get; set; }
}

public class testAltAltDual
  : ItestAltAltDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltDualObject AsAltAltDual { get; set; }
}

public class testAltInp
  : ItestAltInp
{
  public ItestAltAltInp AsAltAltInp { get; set; }
  public ItestAltInpObject AsAltInp { get; set; }
}

public class testAltAltInp
  : ItestAltAltInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltInpObject AsAltAltInp { get; set; }
}

public class testAltOutp
  : ItestAltOutp
{
  public ItestAltAltOutp AsAltAltOutp { get; set; }
  public ItestAltOutpObject AsAltOutp { get; set; }
}

public class testAltAltOutp
  : ItestAltAltOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltOutpObject AsAltAltOutp { get; set; }
}

public class testAltDescrDual
  : ItestAltDescrDual
{
  public string AsString { get; set; }
  public ItestAltDescrDualObject AsAltDescrDual { get; set; }
}

public class testAltDescrInp
  : ItestAltDescrInp
{
  public string AsString { get; set; }
  public ItestAltDescrInpObject AsAltDescrInp { get; set; }
}

public class testAltDescrOutp
  : ItestAltDescrOutp
{
  public string AsString { get; set; }
  public ItestAltDescrOutpObject AsAltDescrOutp { get; set; }
}

public class testAltDualDual
  : ItestAltDualDual
{
  public ItestObjDualAltDualDual AsObjDualAltDualDual { get; set; }
  public ItestAltDualDualObject AsAltDualDual { get; set; }
}

public class testObjDualAltDualDual
  : ItestObjDualAltDualDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestObjDualAltDualDualObject AsObjDualAltDualDual { get; set; }
}

public class testAltDualInp
  : ItestAltDualInp
{
  public ItestObjDualAltDualInp AsObjDualAltDualInp { get; set; }
  public ItestAltDualInpObject AsAltDualInp { get; set; }
}

public class testObjDualAltDualInp
  : ItestObjDualAltDualInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestObjDualAltDualInpObject AsObjDualAltDualInp { get; set; }
}

public class testAltDualOutp
  : ItestAltDualOutp
{
  public ItestObjDualAltDualOutp AsObjDualAltDualOutp { get; set; }
  public ItestAltDualOutpObject AsAltDualOutp { get; set; }
}

public class testObjDualAltDualOutp
  : ItestObjDualAltDualOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestObjDualAltDualOutpObject AsObjDualAltDualOutp { get; set; }
}

public class testAltEnumDual
  : ItestAltEnumDual
{
  public testEnumAltEnumDual AsEnumAltEnumDualaltEnumDual { get; set; }
  public ItestAltEnumDualObject AsAltEnumDual { get; set; }
}

public class testAltEnumInp
  : ItestAltEnumInp
{
  public testEnumAltEnumInp AsEnumAltEnumInpaltEnumInp { get; set; }
  public ItestAltEnumInpObject AsAltEnumInp { get; set; }
}

public class testAltEnumOutp
  : ItestAltEnumOutp
{
  public testEnumAltEnumOutp AsEnumAltEnumOutpaltEnumOutp { get; set; }
  public ItestAltEnumOutpObject AsAltEnumOutp { get; set; }
}

public class testAltModBoolDual
  : ItestAltModBoolDual
{
  public IDictionary<testBoolean, ItestAltAltModBoolDual> AsAltAltModBoolDual { get; set; }
  public ItestAltModBoolDualObject AsAltModBoolDual { get; set; }
}

public class testAltAltModBoolDual
  : ItestAltAltModBoolDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModBoolDualObject AsAltAltModBoolDual { get; set; }
}

public class testAltModBoolInp
  : ItestAltModBoolInp
{
  public IDictionary<testBoolean, ItestAltAltModBoolInp> AsAltAltModBoolInp { get; set; }
  public ItestAltModBoolInpObject AsAltModBoolInp { get; set; }
}

public class testAltAltModBoolInp
  : ItestAltAltModBoolInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModBoolInpObject AsAltAltModBoolInp { get; set; }
}

public class testAltModBoolOutp
  : ItestAltModBoolOutp
{
  public IDictionary<testBoolean, ItestAltAltModBoolOutp> AsAltAltModBoolOutp { get; set; }
  public ItestAltModBoolOutpObject AsAltModBoolOutp { get; set; }
}

public class testAltAltModBoolOutp
  : ItestAltAltModBoolOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModBoolOutpObject AsAltAltModBoolOutp { get; set; }
}

public class testAltModParamDual<TMod>
  : ItestAltModParamDual<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamDual> AsAltAltModParamDual { get; set; }
  public ItestAltModParamDualObject AsAltModParamDual { get; set; }
}

public class testAltAltModParamDual
  : ItestAltAltModParamDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModParamDualObject AsAltAltModParamDual { get; set; }
}

public class testAltModParamInp<TMod>
  : ItestAltModParamInp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamInp> AsAltAltModParamInp { get; set; }
  public ItestAltModParamInpObject AsAltModParamInp { get; set; }
}

public class testAltAltModParamInp
  : ItestAltAltModParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModParamInpObject AsAltAltModParamInp { get; set; }
}

public class testAltModParamOutp<TMod>
  : ItestAltModParamOutp<TMod>
{
  public IDictionary<TMod, ItestAltAltModParamOutp> AsAltAltModParamOutp { get; set; }
  public ItestAltModParamOutpObject AsAltModParamOutp { get; set; }
}

public class testAltAltModParamOutp
  : ItestAltAltModParamOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltAltModParamOutpObject AsAltAltModParamOutp { get; set; }
}

public class testAltSmplDual
  : ItestAltSmplDual
{
  public string AsString { get; set; }
  public ItestAltSmplDualObject AsAltSmplDual { get; set; }
}

public class testAltSmplInp
  : ItestAltSmplInp
{
  public string AsString { get; set; }
  public ItestAltSmplInpObject AsAltSmplInp { get; set; }
}

public class testAltSmplOutp
  : ItestAltSmplOutp
{
  public string AsString { get; set; }
  public ItestAltSmplOutpObject AsAltSmplOutp { get; set; }
}

public class testCnstAltDual<TType>
  : ItestCnstAltDual<TType>
{
  public TType Astype { get; set; }
  public ItestCnstAltDualObject AsCnstAltDual { get; set; }
}

public class testCnstAltInp<TType>
  : ItestCnstAltInp<TType>
{
  public TType Astype { get; set; }
  public ItestCnstAltInpObject AsCnstAltInp { get; set; }
}

public class testCnstAltOutp<TType>
  : ItestCnstAltOutp<TType>
{
  public TType Astype { get; set; }
  public ItestCnstAltOutpObject AsCnstAltOutp { get; set; }
}

public class testCnstAltDmnDual
  : ItestCnstAltDmnDual
{
  public ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual> AsRefCnstAltDmnDual { get; set; }
  public ItestCnstAltDmnDualObject AsCnstAltDmnDual { get; set; }
}

public class testRefCnstAltDmnDual<TRef>
  : ItestRefCnstAltDmnDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDmnDualObject AsRefCnstAltDmnDual { get; set; }
}

public class testDomCnstAltDmnDual
  : DomainString
  , ItestDomCnstAltDmnDual
{
}

public class testCnstAltDmnInp
  : ItestCnstAltDmnInp
{
  public ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp> AsRefCnstAltDmnInp { get; set; }
  public ItestCnstAltDmnInpObject AsCnstAltDmnInp { get; set; }
}

public class testRefCnstAltDmnInp<TRef>
  : ItestRefCnstAltDmnInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDmnInpObject AsRefCnstAltDmnInp { get; set; }
}

public class testDomCnstAltDmnInp
  : DomainString
  , ItestDomCnstAltDmnInp
{
}

public class testCnstAltDmnOutp
  : ItestCnstAltDmnOutp
{
  public ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp> AsRefCnstAltDmnOutp { get; set; }
  public ItestCnstAltDmnOutpObject AsCnstAltDmnOutp { get; set; }
}

public class testRefCnstAltDmnOutp<TRef>
  : ItestRefCnstAltDmnOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDmnOutpObject AsRefCnstAltDmnOutp { get; set; }
}

public class testDomCnstAltDmnOutp
  : DomainString
  , ItestDomCnstAltDmnOutp
{
}

public class testCnstAltDualDual
  : ItestCnstAltDualDual
{
  public ItestRefCnstAltDualDual<ItestAltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
  public ItestCnstAltDualDualObject AsCnstAltDualDual { get; set; }
}

public class testRefCnstAltDualDual<TRef>
  : ItestRefCnstAltDualDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDualDualObject AsRefCnstAltDualDual { get; set; }
}

public class testPrntCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  public string AsString { get; set; }
  public ItestPrntCnstAltDualDualObject AsPrntCnstAltDualDual { get; set; }
}

public class testAltCnstAltDualDual
  : testPrntCnstAltDualDual
  , ItestAltCnstAltDualDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltDualDualObject AsAltCnstAltDualDual { get; set; }
}

public class testCnstAltDualInp
  : ItestCnstAltDualInp
{
  public ItestRefCnstAltDualInp<ItestAltCnstAltDualInp> AsRefCnstAltDualInp { get; set; }
  public ItestCnstAltDualInpObject AsCnstAltDualInp { get; set; }
}

public class testRefCnstAltDualInp<TRef>
  : ItestRefCnstAltDualInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDualInpObject AsRefCnstAltDualInp { get; set; }
}

public class testPrntCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltDualInpObject AsPrntCnstAltDualInp { get; set; }
}

public class testAltCnstAltDualInp
  : testPrntCnstAltDualInp
  , ItestAltCnstAltDualInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltDualInpObject AsAltCnstAltDualInp { get; set; }
}

public class testCnstAltDualOutp
  : ItestCnstAltDualOutp
{
  public ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; set; }
  public ItestCnstAltDualOutpObject AsCnstAltDualOutp { get; set; }
}

public class testRefCnstAltDualOutp<TRef>
  : ItestRefCnstAltDualOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltDualOutpObject AsRefCnstAltDualOutp { get; set; }
}

public class testPrntCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltDualOutpObject AsPrntCnstAltDualOutp { get; set; }
}

public class testAltCnstAltDualOutp
  : testPrntCnstAltDualOutp
  , ItestAltCnstAltDualOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltDualOutpObject AsAltCnstAltDualOutp { get; set; }
}

public class testCnstAltObjDual
  : ItestCnstAltObjDual
{
  public ItestRefCnstAltObjDual<ItestAltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
  public ItestCnstAltObjDualObject AsCnstAltObjDual { get; set; }
}

public class testRefCnstAltObjDual<TRef>
  : ItestRefCnstAltObjDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltObjDualObject AsRefCnstAltObjDual { get; set; }
}

public class testPrntCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  public string AsString { get; set; }
  public ItestPrntCnstAltObjDualObject AsPrntCnstAltObjDual { get; set; }
}

public class testAltCnstAltObjDual
  : testPrntCnstAltObjDual
  , ItestAltCnstAltObjDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltObjDualObject AsAltCnstAltObjDual { get; set; }
}

public class testCnstAltObjInp
  : ItestCnstAltObjInp
{
  public ItestRefCnstAltObjInp<ItestAltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
  public ItestCnstAltObjInpObject AsCnstAltObjInp { get; set; }
}

public class testRefCnstAltObjInp<TRef>
  : ItestRefCnstAltObjInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltObjInpObject AsRefCnstAltObjInp { get; set; }
}

public class testPrntCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltObjInpObject AsPrntCnstAltObjInp { get; set; }
}

public class testAltCnstAltObjInp
  : testPrntCnstAltObjInp
  , ItestAltCnstAltObjInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltObjInpObject AsAltCnstAltObjInp { get; set; }
}

public class testCnstAltObjOutp
  : ItestCnstAltObjOutp
{
  public ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
  public ItestCnstAltObjOutpObject AsCnstAltObjOutp { get; set; }
}

public class testRefCnstAltObjOutp<TRef>
  : ItestRefCnstAltObjOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltObjOutpObject AsRefCnstAltObjOutp { get; set; }
}

public class testPrntCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltObjOutpObject AsPrntCnstAltObjOutp { get; set; }
}

public class testAltCnstAltObjOutp
  : testPrntCnstAltObjOutp
  , ItestAltCnstAltObjOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltObjOutpObject AsAltCnstAltObjOutp { get; set; }
}

public class testCnstDomEnumDual
  : ItestCnstDomEnumDual
{
  public ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual> AsEnumCnstDomEnumDualcnstDomEnumDual { get; set; }
  public ItestCnstDomEnumDualObject AsCnstDomEnumDual { get; set; }
}

public class testRefCnstDomEnumDual<TType>
  : ItestRefCnstDomEnumDual<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstDomEnumDualObject AsRefCnstDomEnumDual { get; set; }
}

public class testJustCnstDomEnumDual
  : DomainEnum
  , ItestJustCnstDomEnumDual
{
}

public class testCnstDomEnumInp
  : ItestCnstDomEnumInp
{
  public ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp> AsEnumCnstDomEnumInpcnstDomEnumInp { get; set; }
  public ItestCnstDomEnumInpObject AsCnstDomEnumInp { get; set; }
}

public class testRefCnstDomEnumInp<TType>
  : ItestRefCnstDomEnumInp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstDomEnumInpObject AsRefCnstDomEnumInp { get; set; }
}

public class testJustCnstDomEnumInp
  : DomainEnum
  , ItestJustCnstDomEnumInp
{
}

public class testCnstDomEnumOutp
  : ItestCnstDomEnumOutp
{
  public ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp> AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; set; }
  public ItestCnstDomEnumOutpObject AsCnstDomEnumOutp { get; set; }
}

public class testRefCnstDomEnumOutp<TType>
  : ItestRefCnstDomEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstDomEnumOutpObject AsRefCnstDomEnumOutp { get; set; }
}

public class testJustCnstDomEnumOutp
  : DomainEnum
  , ItestJustCnstDomEnumOutp
{
}

public class testCnstEnumDual
  : ItestCnstEnumDual
{
  public ItestRefCnstEnumDual<testEnumCnstEnumDual> AsEnumCnstEnumDualcnstEnumDual { get; set; }
  public ItestCnstEnumDualObject AsCnstEnumDual { get; set; }
}

public class testRefCnstEnumDual<TType>
  : ItestRefCnstEnumDual<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumDualObject AsRefCnstEnumDual { get; set; }
}

public class testCnstEnumInp
  : ItestCnstEnumInp
{
  public ItestRefCnstEnumInp<testEnumCnstEnumInp> AsEnumCnstEnumInpcnstEnumInp { get; set; }
  public ItestCnstEnumInpObject AsCnstEnumInp { get; set; }
}

public class testRefCnstEnumInp<TType>
  : ItestRefCnstEnumInp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumInpObject AsRefCnstEnumInp { get; set; }
}

public class testCnstEnumOutp
  : ItestCnstEnumOutp
{
  public ItestRefCnstEnumOutp<testEnumCnstEnumOutp> AsEnumCnstEnumOutpcnstEnumOutp { get; set; }
  public ItestCnstEnumOutpObject AsCnstEnumOutp { get; set; }
}

public class testRefCnstEnumOutp<TType>
  : ItestRefCnstEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumOutpObject AsRefCnstEnumOutp { get; set; }
}

public class testCnstEnumPrntDual
  : ItestCnstEnumPrntDual
{
  public ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual> AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; set; }
  public ItestCnstEnumPrntDualObject AsCnstEnumPrntDual { get; set; }
}

public class testRefCnstEnumPrntDual<TType>
  : ItestRefCnstEnumPrntDual<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumPrntDualObject AsRefCnstEnumPrntDual { get; set; }
}

public class testCnstEnumPrntInp
  : ItestCnstEnumPrntInp
{
  public ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp> AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; set; }
  public ItestCnstEnumPrntInpObject AsCnstEnumPrntInp { get; set; }
}

public class testRefCnstEnumPrntInp<TType>
  : ItestRefCnstEnumPrntInp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumPrntInpObject AsRefCnstEnumPrntInp { get; set; }
}

public class testCnstEnumPrntOutp
  : ItestCnstEnumPrntOutp
{
  public ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp> AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; set; }
  public ItestCnstEnumPrntOutpObject AsCnstEnumPrntOutp { get; set; }
}

public class testRefCnstEnumPrntOutp<TType>
  : ItestRefCnstEnumPrntOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstEnumPrntOutpObject AsRefCnstEnumPrntOutp { get; set; }
}

public class testCnstFieldDmnDual
  : testRefCnstFieldDmnDual<ItestDomCnstFieldDmnDual>
  , ItestCnstFieldDmnDual
{
  public ItestCnstFieldDmnDualObject AsCnstFieldDmnDual { get; set; }
}

public class testRefCnstFieldDmnDual<TRef>
  : ItestRefCnstFieldDmnDual<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDmnDualObject AsRefCnstFieldDmnDual { get; set; }
}

public class testDomCnstFieldDmnDual
  : DomainString
  , ItestDomCnstFieldDmnDual
{
}

public class testCnstFieldDmnInp
  : testRefCnstFieldDmnInp<ItestDomCnstFieldDmnInp>
  , ItestCnstFieldDmnInp
{
  public ItestCnstFieldDmnInpObject AsCnstFieldDmnInp { get; set; }
}

public class testRefCnstFieldDmnInp<TRef>
  : ItestRefCnstFieldDmnInp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDmnInpObject AsRefCnstFieldDmnInp { get; set; }
}

public class testDomCnstFieldDmnInp
  : DomainString
  , ItestDomCnstFieldDmnInp
{
}

public class testCnstFieldDmnOutp
  : testRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
  , ItestCnstFieldDmnOutp
{
  public ItestCnstFieldDmnOutpObject AsCnstFieldDmnOutp { get; set; }
}

public class testRefCnstFieldDmnOutp<TRef>
  : ItestRefCnstFieldDmnOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDmnOutpObject AsRefCnstFieldDmnOutp { get; set; }
}

public class testDomCnstFieldDmnOutp
  : DomainString
  , ItestDomCnstFieldDmnOutp
{
}

public class testCnstFieldDualDual
  : testRefCnstFieldDualDual<ItestAltCnstFieldDualDual>
  , ItestCnstFieldDualDual
{
  public ItestCnstFieldDualDualObject AsCnstFieldDualDual { get; set; }
}

public class testRefCnstFieldDualDual<TRef>
  : ItestRefCnstFieldDualDual<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDualDualObject AsRefCnstFieldDualDual { get; set; }
}

public class testPrntCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldDualDualObject AsPrntCnstFieldDualDual { get; set; }
}

public class testAltCnstFieldDualDual
  : testPrntCnstFieldDualDual
  , ItestAltCnstFieldDualDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldDualDualObject AsAltCnstFieldDualDual { get; set; }
}

public class testCnstFieldDualInp
  : testRefCnstFieldDualInp<ItestAltCnstFieldDualInp>
  , ItestCnstFieldDualInp
{
  public ItestCnstFieldDualInpObject AsCnstFieldDualInp { get; set; }
}

public class testRefCnstFieldDualInp<TRef>
  : ItestRefCnstFieldDualInp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDualInpObject AsRefCnstFieldDualInp { get; set; }
}

public class testPrntCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldDualInpObject AsPrntCnstFieldDualInp { get; set; }
}

public class testAltCnstFieldDualInp
  : testPrntCnstFieldDualInp
  , ItestAltCnstFieldDualInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldDualInpObject AsAltCnstFieldDualInp { get; set; }
}

public class testCnstFieldDualOutp
  : testRefCnstFieldDualOutp<ItestAltCnstFieldDualOutp>
  , ItestCnstFieldDualOutp
{
  public ItestCnstFieldDualOutpObject AsCnstFieldDualOutp { get; set; }
}

public class testRefCnstFieldDualOutp<TRef>
  : ItestRefCnstFieldDualOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldDualOutpObject AsRefCnstFieldDualOutp { get; set; }
}

public class testPrntCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldDualOutpObject AsPrntCnstFieldDualOutp { get; set; }
}

public class testAltCnstFieldDualOutp
  : testPrntCnstFieldDualOutp
  , ItestAltCnstFieldDualOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldDualOutpObject AsAltCnstFieldDualOutp { get; set; }
}

public class testCnstFieldObjDual
  : testRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
  , ItestCnstFieldObjDual
{
  public ItestCnstFieldObjDualObject AsCnstFieldObjDual { get; set; }
}

public class testRefCnstFieldObjDual<TRef>
  : ItestRefCnstFieldObjDual<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldObjDualObject AsRefCnstFieldObjDual { get; set; }
}

public class testPrntCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjDualObject AsPrntCnstFieldObjDual { get; set; }
}

public class testAltCnstFieldObjDual
  : testPrntCnstFieldObjDual
  , ItestAltCnstFieldObjDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldObjDualObject AsAltCnstFieldObjDual { get; set; }
}

public class testCnstFieldObjInp
  : testRefCnstFieldObjInp<ItestAltCnstFieldObjInp>
  , ItestCnstFieldObjInp
{
  public ItestCnstFieldObjInpObject AsCnstFieldObjInp { get; set; }
}

public class testRefCnstFieldObjInp<TRef>
  : ItestRefCnstFieldObjInp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldObjInpObject AsRefCnstFieldObjInp { get; set; }
}

public class testPrntCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjInpObject AsPrntCnstFieldObjInp { get; set; }
}

public class testAltCnstFieldObjInp
  : testPrntCnstFieldObjInp
  , ItestAltCnstFieldObjInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldObjInpObject AsAltCnstFieldObjInp { get; set; }
}

public class testCnstFieldObjOutp
  : testRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
  , ItestCnstFieldObjOutp
{
  public ItestCnstFieldObjOutpObject AsCnstFieldObjOutp { get; set; }
}

public class testRefCnstFieldObjOutp<TRef>
  : ItestRefCnstFieldObjOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldObjOutpObject AsRefCnstFieldObjOutp { get; set; }
}

public class testPrntCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjOutpObject AsPrntCnstFieldObjOutp { get; set; }
}

public class testAltCnstFieldObjOutp
  : testPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldObjOutpObject AsAltCnstFieldObjOutp { get; set; }
}

public class testCnstPrntDualGrndDual
  : testRefCnstPrntDualGrndDual<ItestAltCnstPrntDualGrndDual>
  , ItestCnstPrntDualGrndDual
{
  public ItestCnstPrntDualGrndDualObject AsCnstPrntDualGrndDual { get; set; }
}

public class testRefCnstPrntDualGrndDual<TRef>
  : testref
  , ItestRefCnstPrntDualGrndDual<TRef>
{
  public ItestRefCnstPrntDualGrndDualObject AsRefCnstPrntDualGrndDual { get; set; }
}

public class testGrndCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  public string AsString { get; set; }
  public ItestGrndCnstPrntDualGrndDualObject AsGrndCnstPrntDualGrndDual { get; set; }
}

public class testPrntCnstPrntDualGrndDual
  : testGrndCnstPrntDualGrndDual
  , ItestPrntCnstPrntDualGrndDual
{
  public ItestPrntCnstPrntDualGrndDualObject AsPrntCnstPrntDualGrndDual { get; set; }
}

public class testAltCnstPrntDualGrndDual
  : testPrntCnstPrntDualGrndDual
  , ItestAltCnstPrntDualGrndDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualGrndDualObject AsAltCnstPrntDualGrndDual { get; set; }
}

public class testCnstPrntDualGrndInp
  : testRefCnstPrntDualGrndInp<ItestAltCnstPrntDualGrndInp>
  , ItestCnstPrntDualGrndInp
{
  public ItestCnstPrntDualGrndInpObject AsCnstPrntDualGrndInp { get; set; }
}

public class testRefCnstPrntDualGrndInp<TRef>
  : testref
  , ItestRefCnstPrntDualGrndInp<TRef>
{
  public ItestRefCnstPrntDualGrndInpObject AsRefCnstPrntDualGrndInp { get; set; }
}

public class testGrndCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  public string AsString { get; set; }
  public ItestGrndCnstPrntDualGrndInpObject AsGrndCnstPrntDualGrndInp { get; set; }
}

public class testPrntCnstPrntDualGrndInp
  : testGrndCnstPrntDualGrndInp
  , ItestPrntCnstPrntDualGrndInp
{
  public ItestPrntCnstPrntDualGrndInpObject AsPrntCnstPrntDualGrndInp { get; set; }
}

public class testAltCnstPrntDualGrndInp
  : testPrntCnstPrntDualGrndInp
  , ItestAltCnstPrntDualGrndInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualGrndInpObject AsAltCnstPrntDualGrndInp { get; set; }
}

public class testCnstPrntDualGrndOutp
  : testRefCnstPrntDualGrndOutp<ItestAltCnstPrntDualGrndOutp>
  , ItestCnstPrntDualGrndOutp
{
  public ItestCnstPrntDualGrndOutpObject AsCnstPrntDualGrndOutp { get; set; }
}

public class testRefCnstPrntDualGrndOutp<TRef>
  : testref
  , ItestRefCnstPrntDualGrndOutp<TRef>
{
  public ItestRefCnstPrntDualGrndOutpObject AsRefCnstPrntDualGrndOutp { get; set; }
}

public class testGrndCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  public string AsString { get; set; }
  public ItestGrndCnstPrntDualGrndOutpObject AsGrndCnstPrntDualGrndOutp { get; set; }
}

public class testPrntCnstPrntDualGrndOutp
  : testGrndCnstPrntDualGrndOutp
  , ItestPrntCnstPrntDualGrndOutp
{
  public ItestPrntCnstPrntDualGrndOutpObject AsPrntCnstPrntDualGrndOutp { get; set; }
}

public class testAltCnstPrntDualGrndOutp
  : testPrntCnstPrntDualGrndOutp
  , ItestAltCnstPrntDualGrndOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualGrndOutpObject AsAltCnstPrntDualGrndOutp { get; set; }
}

public class testCnstPrntDualPrntDual
  : testRefCnstPrntDualPrntDual<ItestAltCnstPrntDualPrntDual>
  , ItestCnstPrntDualPrntDual
{
  public ItestCnstPrntDualPrntDualObject AsCnstPrntDualPrntDual { get; set; }
}

public class testRefCnstPrntDualPrntDual<TRef>
  : testref
  , ItestRefCnstPrntDualPrntDual<TRef>
{
  public ItestRefCnstPrntDualPrntDualObject AsRefCnstPrntDualPrntDual { get; set; }
}

public class testPrntCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntDualPrntDualObject AsPrntCnstPrntDualPrntDual { get; set; }
}

public class testAltCnstPrntDualPrntDual
  : testPrntCnstPrntDualPrntDual
  , ItestAltCnstPrntDualPrntDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualPrntDualObject AsAltCnstPrntDualPrntDual { get; set; }
}

public class testCnstPrntDualPrntInp
  : testRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
  , ItestCnstPrntDualPrntInp
{
  public ItestCnstPrntDualPrntInpObject AsCnstPrntDualPrntInp { get; set; }
}

public class testRefCnstPrntDualPrntInp<TRef>
  : testref
  , ItestRefCnstPrntDualPrntInp<TRef>
{
  public ItestRefCnstPrntDualPrntInpObject AsRefCnstPrntDualPrntInp { get; set; }
}

public class testPrntCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntDualPrntInpObject AsPrntCnstPrntDualPrntInp { get; set; }
}

public class testAltCnstPrntDualPrntInp
  : testPrntCnstPrntDualPrntInp
  , ItestAltCnstPrntDualPrntInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualPrntInpObject AsAltCnstPrntDualPrntInp { get; set; }
}

public class testCnstPrntDualPrntOutp
  : testRefCnstPrntDualPrntOutp<ItestAltCnstPrntDualPrntOutp>
  , ItestCnstPrntDualPrntOutp
{
  public ItestCnstPrntDualPrntOutpObject AsCnstPrntDualPrntOutp { get; set; }
}

public class testRefCnstPrntDualPrntOutp<TRef>
  : testref
  , ItestRefCnstPrntDualPrntOutp<TRef>
{
  public ItestRefCnstPrntDualPrntOutpObject AsRefCnstPrntDualPrntOutp { get; set; }
}

public class testPrntCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntDualPrntOutpObject AsPrntCnstPrntDualPrntOutp { get; set; }
}

public class testAltCnstPrntDualPrntOutp
  : testPrntCnstPrntDualPrntOutp
  , ItestAltCnstPrntDualPrntOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntDualPrntOutpObject AsAltCnstPrntDualPrntOutp { get; set; }
}

public class testCnstPrntEnumDual
  : ItestCnstPrntEnumDual
{
  public ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual> AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; set; }
  public ItestCnstPrntEnumDualObject AsCnstPrntEnumDual { get; set; }
}

public class testRefCnstPrntEnumDual<TType>
  : ItestRefCnstPrntEnumDual<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstPrntEnumDualObject AsRefCnstPrntEnumDual { get; set; }
}

public class testCnstPrntEnumInp
  : ItestCnstPrntEnumInp
{
  public ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp> AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; set; }
  public ItestCnstPrntEnumInpObject AsCnstPrntEnumInp { get; set; }
}

public class testRefCnstPrntEnumInp<TType>
  : ItestRefCnstPrntEnumInp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstPrntEnumInpObject AsRefCnstPrntEnumInp { get; set; }
}

public class testCnstPrntEnumOutp
  : ItestCnstPrntEnumOutp
{
  public ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp> AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; set; }
  public ItestCnstPrntEnumOutpObject AsCnstPrntEnumOutp { get; set; }
}

public class testRefCnstPrntEnumOutp<TType>
  : ItestRefCnstPrntEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefCnstPrntEnumOutpObject AsRefCnstPrntEnumOutp { get; set; }
}

public class testCnstPrntObjPrntDual
  : testRefCnstPrntObjPrntDual<ItestAltCnstPrntObjPrntDual>
  , ItestCnstPrntObjPrntDual
{
  public ItestCnstPrntObjPrntDualObject AsCnstPrntObjPrntDual { get; set; }
}

public class testRefCnstPrntObjPrntDual<TRef>
  : testref
  , ItestRefCnstPrntObjPrntDual<TRef>
{
  public ItestRefCnstPrntObjPrntDualObject AsRefCnstPrntObjPrntDual { get; set; }
}

public class testPrntCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntObjPrntDualObject AsPrntCnstPrntObjPrntDual { get; set; }
}

public class testAltCnstPrntObjPrntDual
  : testPrntCnstPrntObjPrntDual
  , ItestAltCnstPrntObjPrntDual
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntObjPrntDualObject AsAltCnstPrntObjPrntDual { get; set; }
}

public class testCnstPrntObjPrntInp
  : testRefCnstPrntObjPrntInp<ItestAltCnstPrntObjPrntInp>
  , ItestCnstPrntObjPrntInp
{
  public ItestCnstPrntObjPrntInpObject AsCnstPrntObjPrntInp { get; set; }
}

public class testRefCnstPrntObjPrntInp<TRef>
  : testref
  , ItestRefCnstPrntObjPrntInp<TRef>
{
  public ItestRefCnstPrntObjPrntInpObject AsRefCnstPrntObjPrntInp { get; set; }
}

public class testPrntCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntObjPrntInpObject AsPrntCnstPrntObjPrntInp { get; set; }
}

public class testAltCnstPrntObjPrntInp
  : testPrntCnstPrntObjPrntInp
  , ItestAltCnstPrntObjPrntInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntObjPrntInpObject AsAltCnstPrntObjPrntInp { get; set; }
}

public class testCnstPrntObjPrntOutp
  : testRefCnstPrntObjPrntOutp<ItestAltCnstPrntObjPrntOutp>
  , ItestCnstPrntObjPrntOutp
{
  public ItestCnstPrntObjPrntOutpObject AsCnstPrntObjPrntOutp { get; set; }
}

public class testRefCnstPrntObjPrntOutp<TRef>
  : testref
  , ItestRefCnstPrntObjPrntOutp<TRef>
{
  public ItestRefCnstPrntObjPrntOutpObject AsRefCnstPrntObjPrntOutp { get; set; }
}

public class testPrntCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstPrntObjPrntOutpObject AsPrntCnstPrntObjPrntOutp { get; set; }
}

public class testAltCnstPrntObjPrntOutp
  : testPrntCnstPrntObjPrntOutp
  , ItestAltCnstPrntObjPrntOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstPrntObjPrntOutpObject AsAltCnstPrntObjPrntOutp { get; set; }
}

public class testFieldDual
  : ItestFieldDual
{
  public string Field { get; set; }
  public ItestFieldDualObject AsFieldDual { get; set; }
}

public class testFieldInp
  : ItestFieldInp
{
  public string Field { get; set; }
  public ItestFieldInpObject AsFieldInp { get; set; }
}

public class testFieldOutp
  : ItestFieldOutp
{
  public string Field { get; set; }
  public ItestFieldOutpObject AsFieldOutp { get; set; }
}

public class testFieldDescrDual
  : ItestFieldDescrDual
{
  public string Field { get; set; }
  public ItestFieldDescrDualObject AsFieldDescrDual { get; set; }
}

public class testFieldDescrInp
  : ItestFieldDescrInp
{
  public string Field { get; set; }
  public ItestFieldDescrInpObject AsFieldDescrInp { get; set; }
}

public class testFieldDescrOutp
  : ItestFieldDescrOutp
{
  public string Field { get; set; }
  public ItestFieldDescrOutpObject AsFieldDescrOutp { get; set; }
}

public class testFieldDualDual
  : ItestFieldDualDual
{
  public ItestFldFieldDualDual Field { get; set; }
  public ItestFieldDualDualObject AsFieldDualDual { get; set; }
}

public class testFldFieldDualDual
  : ItestFldFieldDualDual
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldDualDualObject AsFldFieldDualDual { get; set; }
}

public class testFieldDualInp
  : ItestFieldDualInp
{
  public ItestFldFieldDualInp Field { get; set; }
  public ItestFieldDualInpObject AsFieldDualInp { get; set; }
}

public class testFldFieldDualInp
  : ItestFldFieldDualInp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldDualInpObject AsFldFieldDualInp { get; set; }
}

public class testFieldDualOutp
  : ItestFieldDualOutp
{
  public ItestFldFieldDualOutp Field { get; set; }
  public ItestFieldDualOutpObject AsFieldDualOutp { get; set; }
}

public class testFldFieldDualOutp
  : ItestFldFieldDualOutp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldDualOutpObject AsFldFieldDualOutp { get; set; }
}

public class testFieldEnumDual
  : ItestFieldEnumDual
{
  public testEnumFieldEnumDual Field { get; set; }
  public ItestFieldEnumDualObject AsFieldEnumDual { get; set; }
}

public class testFieldEnumInp
  : ItestFieldEnumInp
{
  public testEnumFieldEnumInp Field { get; set; }
  public ItestFieldEnumInpObject AsFieldEnumInp { get; set; }
}

public class testFieldEnumOutp
  : ItestFieldEnumOutp
{
  public testEnumFieldEnumOutp Field { get; set; }
  public ItestFieldEnumOutpObject AsFieldEnumOutp { get; set; }
}

public class testFieldEnumPrntDual
  : ItestFieldEnumPrntDual
{
  public testEnumFieldEnumPrntDual Field { get; set; }
  public ItestFieldEnumPrntDualObject AsFieldEnumPrntDual { get; set; }
}

public class testFieldEnumPrntInp
  : ItestFieldEnumPrntInp
{
  public testEnumFieldEnumPrntInp Field { get; set; }
  public ItestFieldEnumPrntInpObject AsFieldEnumPrntInp { get; set; }
}

public class testFieldEnumPrntOutp
  : ItestFieldEnumPrntOutp
{
  public testEnumFieldEnumPrntOutp Field { get; set; }
  public ItestFieldEnumPrntOutpObject AsFieldEnumPrntOutp { get; set; }
}

public class testFieldModEnumDual
  : ItestFieldModEnumDual
{
  public IDictionary<testEnumFieldModEnumDual, string> Field { get; set; }
  public ItestFieldModEnumDualObject AsFieldModEnumDual { get; set; }
}

public class testFieldModEnumInp
  : ItestFieldModEnumInp
{
  public IDictionary<testEnumFieldModEnumInp, string> Field { get; set; }
  public ItestFieldModEnumInpObject AsFieldModEnumInp { get; set; }
}

public class testFieldModEnumOutp
  : ItestFieldModEnumOutp
{
  public IDictionary<testEnumFieldModEnumOutp, string> Field { get; set; }
  public ItestFieldModEnumOutpObject AsFieldModEnumOutp { get; set; }
}

public class testFieldModParamDual<TMod>
  : ItestFieldModParamDual<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamDual> Field { get; set; }
  public ItestFieldModParamDualObject AsFieldModParamDual { get; set; }
}

public class testFldFieldModParamDual
  : ItestFldFieldModParamDual
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldModParamDualObject AsFldFieldModParamDual { get; set; }
}

public class testFieldModParamInp<TMod>
  : ItestFieldModParamInp<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamInp> Field { get; set; }
  public ItestFieldModParamInpObject AsFieldModParamInp { get; set; }
}

public class testFldFieldModParamInp
  : ItestFldFieldModParamInp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldModParamInpObject AsFldFieldModParamInp { get; set; }
}

public class testFieldModParamOutp<TMod>
  : ItestFieldModParamOutp<TMod>
{
  public IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; set; }
  public ItestFieldModParamOutpObject AsFieldModParamOutp { get; set; }
}

public class testFldFieldModParamOutp
  : ItestFldFieldModParamOutp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldModParamOutpObject AsFldFieldModParamOutp { get; set; }
}

public class testFieldObjDual
  : ItestFieldObjDual
{
  public ItestFldFieldObjDual Field { get; set; }
  public ItestFieldObjDualObject AsFieldObjDual { get; set; }
}

public class testFldFieldObjDual
  : ItestFldFieldObjDual
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldObjDualObject AsFldFieldObjDual { get; set; }
}

public class testFieldObjInp
  : ItestFieldObjInp
{
  public ItestFldFieldObjInp Field { get; set; }
  public ItestFieldObjInpObject AsFieldObjInp { get; set; }
}

public class testFldFieldObjInp
  : ItestFldFieldObjInp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldObjInpObject AsFldFieldObjInp { get; set; }
}

public class testFieldObjOutp
  : ItestFieldObjOutp
{
  public ItestFldFieldObjOutp Field { get; set; }
  public ItestFieldObjOutpObject AsFieldObjOutp { get; set; }
}

public class testFldFieldObjOutp
  : ItestFldFieldObjOutp
{
  public decimal Field { get; set; }
  public string AsString { get; set; }
  public ItestFldFieldObjOutpObject AsFldFieldObjOutp { get; set; }
}

public class testFieldSmplDual
  : ItestFieldSmplDual
{
  public decimal Field { get; set; }
  public ItestFieldSmplDualObject AsFieldSmplDual { get; set; }
}

public class testFieldSmplInp
  : ItestFieldSmplInp
{
  public decimal Field { get; set; }
  public ItestFieldSmplInpObject AsFieldSmplInp { get; set; }
}

public class testFieldSmplOutp
  : ItestFieldSmplOutp
{
  public decimal Field { get; set; }
  public ItestFieldSmplOutpObject AsFieldSmplOutp { get; set; }
}

public class testFieldTypeDescrDual
  : ItestFieldTypeDescrDual
{
  public decimal Field { get; set; }
  public ItestFieldTypeDescrDualObject AsFieldTypeDescrDual { get; set; }
}

public class testFieldTypeDescrInp
  : ItestFieldTypeDescrInp
{
  public decimal Field { get; set; }
  public ItestFieldTypeDescrInpObject AsFieldTypeDescrInp { get; set; }
}

public class testFieldTypeDescrOutp
  : ItestFieldTypeDescrOutp
{
  public decimal Field { get; set; }
  public ItestFieldTypeDescrOutpObject AsFieldTypeDescrOutp { get; set; }
}

public class testFieldValueDual
  : ItestFieldValueDual
{
  public testEnumFieldValueDual Field { get; set; }
  public ItestFieldValueDualObject AsFieldValueDual { get; set; }
}

public class testFieldValueInp
  : ItestFieldValueInp
{
  public testEnumFieldValueInp Field { get; set; }
  public ItestFieldValueInpObject AsFieldValueInp { get; set; }
}

public class testFieldValueOutp
  : ItestFieldValueOutp
{
  public testEnumFieldValueOutp Field { get; set; }
  public ItestFieldValueOutpObject AsFieldValueOutp { get; set; }
}

public class testFieldValueDescrDual
  : ItestFieldValueDescrDual
{
  public testEnumFieldValueDescrDual Field { get; set; }
  public ItestFieldValueDescrDualObject AsFieldValueDescrDual { get; set; }
}

public class testFieldValueDescrInp
  : ItestFieldValueDescrInp
{
  public testEnumFieldValueDescrInp Field { get; set; }
  public ItestFieldValueDescrInpObject AsFieldValueDescrInp { get; set; }
}

public class testFieldValueDescrOutp
  : ItestFieldValueDescrOutp
{
  public testEnumFieldValueDescrOutp Field { get; set; }
  public ItestFieldValueDescrOutpObject AsFieldValueDescrOutp { get; set; }
}

public class testGnrcAltDual<TType>
  : ItestGnrcAltDual<TType>
{
  public TType Astype { get; set; }
  public ItestGnrcAltDualObject AsGnrcAltDual { get; set; }
}

public class testGnrcAltInp<TType>
  : ItestGnrcAltInp<TType>
{
  public TType Astype { get; set; }
  public ItestGnrcAltInpObject AsGnrcAltInp { get; set; }
}

public class testGnrcAltOutp<TType>
  : ItestGnrcAltOutp<TType>
{
  public TType Astype { get; set; }
  public ItestGnrcAltOutpObject AsGnrcAltOutp { get; set; }
}

public class testGnrcAltArgDual<TType>
  : ItestGnrcAltArgDual<TType>
{
  public ItestRefGnrcAltArgDual<TType> AsRefGnrcAltArgDual { get; set; }
  public ItestGnrcAltArgDualObject AsGnrcAltArgDual { get; set; }
}

public class testRefGnrcAltArgDual<TRef>
  : ItestRefGnrcAltArgDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgDualObject AsRefGnrcAltArgDual { get; set; }
}

public class testGnrcAltArgInp<TType>
  : ItestGnrcAltArgInp<TType>
{
  public ItestRefGnrcAltArgInp<TType> AsRefGnrcAltArgInp { get; set; }
  public ItestGnrcAltArgInpObject AsGnrcAltArgInp { get; set; }
}

public class testRefGnrcAltArgInp<TRef>
  : ItestRefGnrcAltArgInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgInpObject AsRefGnrcAltArgInp { get; set; }
}

public class testGnrcAltArgOutp<TType>
  : ItestGnrcAltArgOutp<TType>
{
  public ItestRefGnrcAltArgOutp<TType> AsRefGnrcAltArgOutp { get; set; }
  public ItestGnrcAltArgOutpObject AsGnrcAltArgOutp { get; set; }
}

public class testRefGnrcAltArgOutp<TRef>
  : ItestRefGnrcAltArgOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgOutpObject AsRefGnrcAltArgOutp { get; set; }
}

public class testGnrcAltArgDescrDual<TType>
  : ItestGnrcAltArgDescrDual<TType>
{
  public ItestRefGnrcAltArgDescrDual<TType> AsRefGnrcAltArgDescrDual { get; set; }
  public ItestGnrcAltArgDescrDualObject AsGnrcAltArgDescrDual { get; set; }
}

public class testRefGnrcAltArgDescrDual<TRef>
  : ItestRefGnrcAltArgDescrDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgDescrDualObject AsRefGnrcAltArgDescrDual { get; set; }
}

public class testGnrcAltArgDescrInp<TType>
  : ItestGnrcAltArgDescrInp<TType>
{
  public ItestRefGnrcAltArgDescrInp<TType> AsRefGnrcAltArgDescrInp { get; set; }
  public ItestGnrcAltArgDescrInpObject AsGnrcAltArgDescrInp { get; set; }
}

public class testRefGnrcAltArgDescrInp<TRef>
  : ItestRefGnrcAltArgDescrInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgDescrInpObject AsRefGnrcAltArgDescrInp { get; set; }
}

public class testGnrcAltArgDescrOutp<TType>
  : ItestGnrcAltArgDescrOutp<TType>
{
  public ItestRefGnrcAltArgDescrOutp<TType> AsRefGnrcAltArgDescrOutp { get; set; }
  public ItestGnrcAltArgDescrOutpObject AsGnrcAltArgDescrOutp { get; set; }
}

public class testRefGnrcAltArgDescrOutp<TRef>
  : ItestRefGnrcAltArgDescrOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltArgDescrOutpObject AsRefGnrcAltArgDescrOutp { get; set; }
}

public class testGnrcAltDualDual
  : ItestGnrcAltDualDual
{
  public ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual> AsRefGnrcAltDualDual { get; set; }
  public ItestGnrcAltDualDualObject AsGnrcAltDualDual { get; set; }
}

public class testRefGnrcAltDualDual<TRef>
  : ItestRefGnrcAltDualDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltDualDualObject AsRefGnrcAltDualDual { get; set; }
}

public class testAltGnrcAltDualDual
  : ItestAltGnrcAltDualDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltDualDualObject AsAltGnrcAltDualDual { get; set; }
}

public class testGnrcAltDualInp
  : ItestGnrcAltDualInp
{
  public ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp> AsRefGnrcAltDualInp { get; set; }
  public ItestGnrcAltDualInpObject AsGnrcAltDualInp { get; set; }
}

public class testRefGnrcAltDualInp<TRef>
  : ItestRefGnrcAltDualInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltDualInpObject AsRefGnrcAltDualInp { get; set; }
}

public class testAltGnrcAltDualInp
  : ItestAltGnrcAltDualInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltDualInpObject AsAltGnrcAltDualInp { get; set; }
}

public class testGnrcAltDualOutp
  : ItestGnrcAltDualOutp
{
  public ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp> AsRefGnrcAltDualOutp { get; set; }
  public ItestGnrcAltDualOutpObject AsGnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltDualOutp<TRef>
  : ItestRefGnrcAltDualOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltDualOutpObject AsRefGnrcAltDualOutp { get; set; }
}

public class testAltGnrcAltDualOutp
  : ItestAltGnrcAltDualOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltDualOutpObject AsAltGnrcAltDualOutp { get; set; }
}

public class testRefGnrcAltModParamDual<TRef,TMod>
  : ItestRefGnrcAltModParamDual<TRef,TMod>
{
  public IDictionary<TMod, TRef> Asref { get; set; }
  public ItestRefGnrcAltModParamDualObject AsRefGnrcAltModParamDual { get; set; }
}

public class testRefGnrcAltModParamInp<TRef,TMod>
  : ItestRefGnrcAltModParamInp<TRef,TMod>
{
  public IDictionary<TMod, TRef> Asref { get; set; }
  public ItestRefGnrcAltModParamInpObject AsRefGnrcAltModParamInp { get; set; }
}

public class testRefGnrcAltModParamOutp<TRef,TMod>
  : ItestRefGnrcAltModParamOutp<TRef,TMod>
{
  public IDictionary<TMod, TRef> Asref { get; set; }
  public ItestRefGnrcAltModParamOutpObject AsRefGnrcAltModParamOutp { get; set; }
}

public class testRefGnrcAltModStrDual<TRef>
  : ItestRefGnrcAltModStrDual<TRef>
{
  public IDictionary<testString, TRef> Asref { get; set; }
  public ItestRefGnrcAltModStrDualObject AsRefGnrcAltModStrDual { get; set; }
}

public class testRefGnrcAltModStrInp<TRef>
  : ItestRefGnrcAltModStrInp<TRef>
{
  public IDictionary<testString, TRef> Asref { get; set; }
  public ItestRefGnrcAltModStrInpObject AsRefGnrcAltModStrInp { get; set; }
}

public class testRefGnrcAltModStrOutp<TRef>
  : ItestRefGnrcAltModStrOutp<TRef>
{
  public IDictionary<testString, TRef> Asref { get; set; }
  public ItestRefGnrcAltModStrOutpObject AsRefGnrcAltModStrOutp { get; set; }
}

public class testGnrcAltParamDual
  : ItestGnrcAltParamDual
{
  public ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual> AsRefGnrcAltParamDual { get; set; }
  public ItestGnrcAltParamDualObject AsGnrcAltParamDual { get; set; }
}

public class testRefGnrcAltParamDual<TRef>
  : ItestRefGnrcAltParamDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltParamDualObject AsRefGnrcAltParamDual { get; set; }
}

public class testAltGnrcAltParamDual
  : ItestAltGnrcAltParamDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltParamDualObject AsAltGnrcAltParamDual { get; set; }
}

public class testGnrcAltParamInp
  : ItestGnrcAltParamInp
{
  public ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp> AsRefGnrcAltParamInp { get; set; }
  public ItestGnrcAltParamInpObject AsGnrcAltParamInp { get; set; }
}

public class testRefGnrcAltParamInp<TRef>
  : ItestRefGnrcAltParamInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltParamInpObject AsRefGnrcAltParamInp { get; set; }
}

public class testAltGnrcAltParamInp
  : ItestAltGnrcAltParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltParamInpObject AsAltGnrcAltParamInp { get; set; }
}

public class testGnrcAltParamOutp
  : ItestGnrcAltParamOutp
{
  public ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp> AsRefGnrcAltParamOutp { get; set; }
  public ItestGnrcAltParamOutpObject AsGnrcAltParamOutp { get; set; }
}

public class testRefGnrcAltParamOutp<TRef>
  : ItestRefGnrcAltParamOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltParamOutpObject AsRefGnrcAltParamOutp { get; set; }
}

public class testAltGnrcAltParamOutp
  : ItestAltGnrcAltParamOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcAltParamOutpObject AsAltGnrcAltParamOutp { get; set; }
}

public class testGnrcAltSmplDual
  : ItestGnrcAltSmplDual
{
  public ItestRefGnrcAltSmplDual<string> AsRefGnrcAltSmplDual { get; set; }
  public ItestGnrcAltSmplDualObject AsGnrcAltSmplDual { get; set; }
}

public class testRefGnrcAltSmplDual<TRef>
  : ItestRefGnrcAltSmplDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltSmplDualObject AsRefGnrcAltSmplDual { get; set; }
}

public class testGnrcAltSmplInp
  : ItestGnrcAltSmplInp
{
  public ItestRefGnrcAltSmplInp<string> AsRefGnrcAltSmplInp { get; set; }
  public ItestGnrcAltSmplInpObject AsGnrcAltSmplInp { get; set; }
}

public class testRefGnrcAltSmplInp<TRef>
  : ItestRefGnrcAltSmplInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltSmplInpObject AsRefGnrcAltSmplInp { get; set; }
}

public class testGnrcAltSmplOutp
  : ItestGnrcAltSmplOutp
{
  public ItestRefGnrcAltSmplOutp<string> AsRefGnrcAltSmplOutp { get; set; }
  public ItestGnrcAltSmplOutpObject AsGnrcAltSmplOutp { get; set; }
}

public class testRefGnrcAltSmplOutp<TRef>
  : ItestRefGnrcAltSmplOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcAltSmplOutpObject AsRefGnrcAltSmplOutp { get; set; }
}

public class testGnrcDescrDual<TType>
  : ItestGnrcDescrDual<TType>
{
  public TType Field { get; set; }
  public ItestGnrcDescrDualObject AsGnrcDescrDual { get; set; }
}

public class testGnrcDescrInp<TType>
  : ItestGnrcDescrInp<TType>
{
  public TType Field { get; set; }
  public ItestGnrcDescrInpObject AsGnrcDescrInp { get; set; }
}

public class testGnrcDescrOutp<TType>
  : ItestGnrcDescrOutp<TType>
{
  public TType Field { get; set; }
  public ItestGnrcDescrOutpObject AsGnrcDescrOutp { get; set; }
}

public class testGnrcEnumDual
  : ItestGnrcEnumDual
{
  public ItestRefGnrcEnumDual<testEnumGnrcEnumDual> AsEnumGnrcEnumDualgnrcEnumDual { get; set; }
  public ItestGnrcEnumDualObject AsGnrcEnumDual { get; set; }
}

public class testRefGnrcEnumDual<TType>
  : ItestRefGnrcEnumDual<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcEnumDualObject AsRefGnrcEnumDual { get; set; }
}

public class testGnrcEnumInp
  : ItestGnrcEnumInp
{
  public ItestRefGnrcEnumInp<testEnumGnrcEnumInp> AsEnumGnrcEnumInpgnrcEnumInp { get; set; }
  public ItestGnrcEnumInpObject AsGnrcEnumInp { get; set; }
}

public class testRefGnrcEnumInp<TType>
  : ItestRefGnrcEnumInp<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcEnumInpObject AsRefGnrcEnumInp { get; set; }
}

public class testGnrcEnumOutp
  : ItestGnrcEnumOutp
{
  public ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp> AsEnumGnrcEnumOutpgnrcEnumOutp { get; set; }
  public ItestGnrcEnumOutpObject AsGnrcEnumOutp { get; set; }
}

public class testRefGnrcEnumOutp<TType>
  : ItestRefGnrcEnumOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcEnumOutpObject AsRefGnrcEnumOutp { get; set; }
}

public class testGnrcFieldDual<TType>
  : ItestGnrcFieldDual<TType>
{
  public TType Field { get; set; }
  public ItestGnrcFieldDualObject AsGnrcFieldDual { get; set; }
}

public class testGnrcFieldInp<TType>
  : ItestGnrcFieldInp<TType>
{
  public TType Field { get; set; }
  public ItestGnrcFieldInpObject AsGnrcFieldInp { get; set; }
}

public class testGnrcFieldOutp<TType>
  : ItestGnrcFieldOutp<TType>
{
  public TType Field { get; set; }
  public ItestGnrcFieldOutpObject AsGnrcFieldOutp { get; set; }
}

public class testGnrcFieldArgDual<TType>
  : ItestGnrcFieldArgDual<TType>
{
  public ItestRefGnrcFieldArgDual<TType> Field { get; set; }
  public ItestGnrcFieldArgDualObject AsGnrcFieldArgDual { get; set; }
}

public class testRefGnrcFieldArgDual<TRef>
  : ItestRefGnrcFieldArgDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldArgDualObject AsRefGnrcFieldArgDual { get; set; }
}

public class testGnrcFieldArgInp<TType>
  : ItestGnrcFieldArgInp<TType>
{
  public ItestRefGnrcFieldArgInp<TType> Field { get; set; }
  public ItestGnrcFieldArgInpObject AsGnrcFieldArgInp { get; set; }
}

public class testRefGnrcFieldArgInp<TRef>
  : ItestRefGnrcFieldArgInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldArgInpObject AsRefGnrcFieldArgInp { get; set; }
}

public class testGnrcFieldArgOutp<TType>
  : ItestGnrcFieldArgOutp<TType>
{
  public ItestRefGnrcFieldArgOutp<TType> Field { get; set; }
  public ItestGnrcFieldArgOutpObject AsGnrcFieldArgOutp { get; set; }
}

public class testRefGnrcFieldArgOutp<TRef>
  : ItestRefGnrcFieldArgOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldArgOutpObject AsRefGnrcFieldArgOutp { get; set; }
}

public class testGnrcFieldDualDual
  : ItestGnrcFieldDualDual
{
  public ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; set; }
  public ItestGnrcFieldDualDualObject AsGnrcFieldDualDual { get; set; }
}

public class testRefGnrcFieldDualDual<TRef>
  : ItestRefGnrcFieldDualDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldDualDualObject AsRefGnrcFieldDualDual { get; set; }
}

public class testAltGnrcFieldDualDual
  : ItestAltGnrcFieldDualDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldDualDualObject AsAltGnrcFieldDualDual { get; set; }
}

public class testGnrcFieldDualInp
  : ItestGnrcFieldDualInp
{
  public ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; set; }
  public ItestGnrcFieldDualInpObject AsGnrcFieldDualInp { get; set; }
}

public class testRefGnrcFieldDualInp<TRef>
  : ItestRefGnrcFieldDualInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldDualInpObject AsRefGnrcFieldDualInp { get; set; }
}

public class testAltGnrcFieldDualInp
  : ItestAltGnrcFieldDualInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldDualInpObject AsAltGnrcFieldDualInp { get; set; }
}

public class testGnrcFieldDualOutp
  : ItestGnrcFieldDualOutp
{
  public ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; set; }
  public ItestGnrcFieldDualOutpObject AsGnrcFieldDualOutp { get; set; }
}

public class testRefGnrcFieldDualOutp<TRef>
  : ItestRefGnrcFieldDualOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldDualOutpObject AsRefGnrcFieldDualOutp { get; set; }
}

public class testAltGnrcFieldDualOutp
  : ItestAltGnrcFieldDualOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldDualOutpObject AsAltGnrcFieldDualOutp { get; set; }
}

public class testGnrcFieldParamDual
  : ItestGnrcFieldParamDual
{
  public ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; set; }
  public ItestGnrcFieldParamDualObject AsGnrcFieldParamDual { get; set; }
}

public class testRefGnrcFieldParamDual<TRef>
  : ItestRefGnrcFieldParamDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldParamDualObject AsRefGnrcFieldParamDual { get; set; }
}

public class testAltGnrcFieldParamDual
  : ItestAltGnrcFieldParamDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldParamDualObject AsAltGnrcFieldParamDual { get; set; }
}

public class testGnrcFieldParamInp
  : ItestGnrcFieldParamInp
{
  public ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; set; }
  public ItestGnrcFieldParamInpObject AsGnrcFieldParamInp { get; set; }
}

public class testRefGnrcFieldParamInp<TRef>
  : ItestRefGnrcFieldParamInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldParamInpObject AsRefGnrcFieldParamInp { get; set; }
}

public class testAltGnrcFieldParamInp
  : ItestAltGnrcFieldParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldParamInpObject AsAltGnrcFieldParamInp { get; set; }
}

public class testGnrcFieldParamOutp
  : ItestGnrcFieldParamOutp
{
  public ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; set; }
  public ItestGnrcFieldParamOutpObject AsGnrcFieldParamOutp { get; set; }
}

public class testRefGnrcFieldParamOutp<TRef>
  : ItestRefGnrcFieldParamOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcFieldParamOutpObject AsRefGnrcFieldParamOutp { get; set; }
}

public class testAltGnrcFieldParamOutp
  : ItestAltGnrcFieldParamOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcFieldParamOutpObject AsAltGnrcFieldParamOutp { get; set; }
}

public class testGnrcPrntDual<TType>
  : testtype
  , ItestGnrcPrntDual<TType>
{
  public ItestGnrcPrntDualObject AsGnrcPrntDual { get; set; }
}

public class testGnrcPrntInp<TType>
  : testtype
  , ItestGnrcPrntInp<TType>
{
  public ItestGnrcPrntInpObject AsGnrcPrntInp { get; set; }
}

public class testGnrcPrntOutp<TType>
  : testtype
  , ItestGnrcPrntOutp<TType>
{
  public ItestGnrcPrntOutpObject AsGnrcPrntOutp { get; set; }
}

public class testGnrcPrntArgDual<TType>
  : testRefGnrcPrntArgDual<TType>
  , ItestGnrcPrntArgDual<TType>
{
  public ItestGnrcPrntArgDualObject AsGnrcPrntArgDual { get; set; }
}

public class testRefGnrcPrntArgDual<TRef>
  : ItestRefGnrcPrntArgDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntArgDualObject AsRefGnrcPrntArgDual { get; set; }
}

public class testGnrcPrntArgInp<TType>
  : testRefGnrcPrntArgInp<TType>
  , ItestGnrcPrntArgInp<TType>
{
  public ItestGnrcPrntArgInpObject AsGnrcPrntArgInp { get; set; }
}

public class testRefGnrcPrntArgInp<TRef>
  : ItestRefGnrcPrntArgInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntArgInpObject AsRefGnrcPrntArgInp { get; set; }
}

public class testGnrcPrntArgOutp<TType>
  : testRefGnrcPrntArgOutp<TType>
  , ItestGnrcPrntArgOutp<TType>
{
  public ItestGnrcPrntArgOutpObject AsGnrcPrntArgOutp { get; set; }
}

public class testRefGnrcPrntArgOutp<TRef>
  : ItestRefGnrcPrntArgOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntArgOutpObject AsRefGnrcPrntArgOutp { get; set; }
}

public class testGnrcPrntDescrDual<TType>
  : testtype
  , ItestGnrcPrntDescrDual<TType>
{
  public ItestGnrcPrntDescrDualObject AsGnrcPrntDescrDual { get; set; }
}

public class testGnrcPrntDescrInp<TType>
  : testtype
  , ItestGnrcPrntDescrInp<TType>
{
  public ItestGnrcPrntDescrInpObject AsGnrcPrntDescrInp { get; set; }
}

public class testGnrcPrntDescrOutp<TType>
  : testtype
  , ItestGnrcPrntDescrOutp<TType>
{
  public ItestGnrcPrntDescrOutpObject AsGnrcPrntDescrOutp { get; set; }
}

public class testGnrcPrntDualDual
  : testRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
  , ItestGnrcPrntDualDual
{
  public ItestGnrcPrntDualDualObject AsGnrcPrntDualDual { get; set; }
}

public class testRefGnrcPrntDualDual<TRef>
  : ItestRefGnrcPrntDualDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntDualDualObject AsRefGnrcPrntDualDual { get; set; }
}

public class testAltGnrcPrntDualDual
  : ItestAltGnrcPrntDualDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualDualObject AsAltGnrcPrntDualDual { get; set; }
}

public class testGnrcPrntDualInp
  : testRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
  , ItestGnrcPrntDualInp
{
  public ItestGnrcPrntDualInpObject AsGnrcPrntDualInp { get; set; }
}

public class testRefGnrcPrntDualInp<TRef>
  : ItestRefGnrcPrntDualInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntDualInpObject AsRefGnrcPrntDualInp { get; set; }
}

public class testAltGnrcPrntDualInp
  : ItestAltGnrcPrntDualInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualInpObject AsAltGnrcPrntDualInp { get; set; }
}

public class testGnrcPrntDualOutp
  : testRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
  , ItestGnrcPrntDualOutp
{
  public ItestGnrcPrntDualOutpObject AsGnrcPrntDualOutp { get; set; }
}

public class testRefGnrcPrntDualOutp<TRef>
  : ItestRefGnrcPrntDualOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntDualOutpObject AsRefGnrcPrntDualOutp { get; set; }
}

public class testAltGnrcPrntDualOutp
  : ItestAltGnrcPrntDualOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualOutpObject AsAltGnrcPrntDualOutp { get; set; }
}

public class testGnrcPrntDualPrntDual
  : testRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
  , ItestGnrcPrntDualPrntDual
{
  public ItestGnrcPrntDualPrntDualObject AsGnrcPrntDualPrntDual { get; set; }
}

public class testRefGnrcPrntDualPrntDual<TRef>
  : testref
  , ItestRefGnrcPrntDualPrntDual<TRef>
{
  public ItestRefGnrcPrntDualPrntDualObject AsRefGnrcPrntDualPrntDual { get; set; }
}

public class testAltGnrcPrntDualPrntDual
  : ItestAltGnrcPrntDualPrntDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualPrntDualObject AsAltGnrcPrntDualPrntDual { get; set; }
}

public class testGnrcPrntDualPrntInp
  : testRefGnrcPrntDualPrntInp<ItestAltGnrcPrntDualPrntInp>
  , ItestGnrcPrntDualPrntInp
{
  public ItestGnrcPrntDualPrntInpObject AsGnrcPrntDualPrntInp { get; set; }
}

public class testRefGnrcPrntDualPrntInp<TRef>
  : testref
  , ItestRefGnrcPrntDualPrntInp<TRef>
{
  public ItestRefGnrcPrntDualPrntInpObject AsRefGnrcPrntDualPrntInp { get; set; }
}

public class testAltGnrcPrntDualPrntInp
  : ItestAltGnrcPrntDualPrntInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualPrntInpObject AsAltGnrcPrntDualPrntInp { get; set; }
}

public class testGnrcPrntDualPrntOutp
  : testRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
  , ItestGnrcPrntDualPrntOutp
{
  public ItestGnrcPrntDualPrntOutpObject AsGnrcPrntDualPrntOutp { get; set; }
}

public class testRefGnrcPrntDualPrntOutp<TRef>
  : testref
  , ItestRefGnrcPrntDualPrntOutp<TRef>
{
  public ItestRefGnrcPrntDualPrntOutpObject AsRefGnrcPrntDualPrntOutp { get; set; }
}

public class testAltGnrcPrntDualPrntOutp
  : ItestAltGnrcPrntDualPrntOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntDualPrntOutpObject AsAltGnrcPrntDualPrntOutp { get; set; }
}

public class testGnrcPrntEnumChildDual
  : testFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
  , ItestGnrcPrntEnumChildDual
{
  public ItestGnrcPrntEnumChildDualObject AsGnrcPrntEnumChildDual { get; set; }
}

public class testFieldGnrcPrntEnumChildDual<TRef>
  : ItestFieldGnrcPrntEnumChildDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumChildDualObject AsFieldGnrcPrntEnumChildDual { get; set; }
}

public class testGnrcPrntEnumChildInp
  : testFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
  , ItestGnrcPrntEnumChildInp
{
  public ItestGnrcPrntEnumChildInpObject AsGnrcPrntEnumChildInp { get; set; }
}

public class testFieldGnrcPrntEnumChildInp<TRef>
  : ItestFieldGnrcPrntEnumChildInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumChildInpObject AsFieldGnrcPrntEnumChildInp { get; set; }
}

public class testGnrcPrntEnumChildOutp
  : testFieldGnrcPrntEnumChildOutp<testParentGnrcPrntEnumChildOutp>
  , ItestGnrcPrntEnumChildOutp
{
  public ItestGnrcPrntEnumChildOutpObject AsGnrcPrntEnumChildOutp { get; set; }
}

public class testFieldGnrcPrntEnumChildOutp<TRef>
  : ItestFieldGnrcPrntEnumChildOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumChildOutpObject AsFieldGnrcPrntEnumChildOutp { get; set; }
}

public class testGnrcPrntEnumDomDual
  : testFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
  , ItestGnrcPrntEnumDomDual
{
  public ItestGnrcPrntEnumDomDualObject AsGnrcPrntEnumDomDual { get; set; }
}

public class testFieldGnrcPrntEnumDomDual<TRef>
  : ItestFieldGnrcPrntEnumDomDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumDomDualObject AsFieldGnrcPrntEnumDomDual { get; set; }
}

public class testDomGnrcPrntEnumDomDual
  : DomainEnum
  , ItestDomGnrcPrntEnumDomDual
{
}

public class testGnrcPrntEnumDomInp
  : testFieldGnrcPrntEnumDomInp<ItestDomGnrcPrntEnumDomInp>
  , ItestGnrcPrntEnumDomInp
{
  public ItestGnrcPrntEnumDomInpObject AsGnrcPrntEnumDomInp { get; set; }
}

public class testFieldGnrcPrntEnumDomInp<TRef>
  : ItestFieldGnrcPrntEnumDomInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumDomInpObject AsFieldGnrcPrntEnumDomInp { get; set; }
}

public class testDomGnrcPrntEnumDomInp
  : DomainEnum
  , ItestDomGnrcPrntEnumDomInp
{
}

public class testGnrcPrntEnumDomOutp
  : testFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
  , ItestGnrcPrntEnumDomOutp
{
  public ItestGnrcPrntEnumDomOutpObject AsGnrcPrntEnumDomOutp { get; set; }
}

public class testFieldGnrcPrntEnumDomOutp<TRef>
  : ItestFieldGnrcPrntEnumDomOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumDomOutpObject AsFieldGnrcPrntEnumDomOutp { get; set; }
}

public class testDomGnrcPrntEnumDomOutp
  : DomainEnum
  , ItestDomGnrcPrntEnumDomOutp
{
}

public class testGnrcPrntEnumPrntDual
  : testFieldGnrcPrntEnumPrntDual<testEnumGnrcPrntEnumPrntDual>
  , ItestGnrcPrntEnumPrntDual
{
  public ItestGnrcPrntEnumPrntDualObject AsGnrcPrntEnumPrntDual { get; set; }
}

public class testFieldGnrcPrntEnumPrntDual<TRef>
  : ItestFieldGnrcPrntEnumPrntDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumPrntDualObject AsFieldGnrcPrntEnumPrntDual { get; set; }
}

public class testGnrcPrntEnumPrntInp
  : testFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
  , ItestGnrcPrntEnumPrntInp
{
  public ItestGnrcPrntEnumPrntInpObject AsGnrcPrntEnumPrntInp { get; set; }
}

public class testFieldGnrcPrntEnumPrntInp<TRef>
  : ItestFieldGnrcPrntEnumPrntInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumPrntInpObject AsFieldGnrcPrntEnumPrntInp { get; set; }
}

public class testGnrcPrntEnumPrntOutp
  : testFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
  , ItestGnrcPrntEnumPrntOutp
{
  public ItestGnrcPrntEnumPrntOutpObject AsGnrcPrntEnumPrntOutp { get; set; }
}

public class testFieldGnrcPrntEnumPrntOutp<TRef>
  : ItestFieldGnrcPrntEnumPrntOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumPrntOutpObject AsFieldGnrcPrntEnumPrntOutp { get; set; }
}

public class testGnrcPrntParamDual
  : testRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
  , ItestGnrcPrntParamDual
{
  public ItestGnrcPrntParamDualObject AsGnrcPrntParamDual { get; set; }
}

public class testRefGnrcPrntParamDual<TRef>
  : ItestRefGnrcPrntParamDual<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntParamDualObject AsRefGnrcPrntParamDual { get; set; }
}

public class testAltGnrcPrntParamDual
  : ItestAltGnrcPrntParamDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamDualObject AsAltGnrcPrntParamDual { get; set; }
}

public class testGnrcPrntParamInp
  : testRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
  , ItestGnrcPrntParamInp
{
  public ItestGnrcPrntParamInpObject AsGnrcPrntParamInp { get; set; }
}

public class testRefGnrcPrntParamInp<TRef>
  : ItestRefGnrcPrntParamInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntParamInpObject AsRefGnrcPrntParamInp { get; set; }
}

public class testAltGnrcPrntParamInp
  : ItestAltGnrcPrntParamInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamInpObject AsAltGnrcPrntParamInp { get; set; }
}

public class testGnrcPrntParamOutp
  : testRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
  , ItestGnrcPrntParamOutp
{
  public ItestGnrcPrntParamOutpObject AsGnrcPrntParamOutp { get; set; }
}

public class testRefGnrcPrntParamOutp<TRef>
  : ItestRefGnrcPrntParamOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefGnrcPrntParamOutpObject AsRefGnrcPrntParamOutp { get; set; }
}

public class testAltGnrcPrntParamOutp
  : ItestAltGnrcPrntParamOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamOutpObject AsAltGnrcPrntParamOutp { get; set; }
}

public class testGnrcPrntParamPrntDual
  : testRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
  , ItestGnrcPrntParamPrntDual
{
  public ItestGnrcPrntParamPrntDualObject AsGnrcPrntParamPrntDual { get; set; }
}

public class testRefGnrcPrntParamPrntDual<TRef>
  : testref
  , ItestRefGnrcPrntParamPrntDual<TRef>
{
  public ItestRefGnrcPrntParamPrntDualObject AsRefGnrcPrntParamPrntDual { get; set; }
}

public class testAltGnrcPrntParamPrntDual
  : ItestAltGnrcPrntParamPrntDual
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntDualObject AsAltGnrcPrntParamPrntDual { get; set; }
}

public class testGnrcPrntParamPrntInp
  : testRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
  , ItestGnrcPrntParamPrntInp
{
  public ItestGnrcPrntParamPrntInpObject AsGnrcPrntParamPrntInp { get; set; }
}

public class testRefGnrcPrntParamPrntInp<TRef>
  : testref
  , ItestRefGnrcPrntParamPrntInp<TRef>
{
  public ItestRefGnrcPrntParamPrntInpObject AsRefGnrcPrntParamPrntInp { get; set; }
}

public class testAltGnrcPrntParamPrntInp
  : ItestAltGnrcPrntParamPrntInp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntInpObject AsAltGnrcPrntParamPrntInp { get; set; }
}

public class testGnrcPrntParamPrntOutp
  : testRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
  , ItestGnrcPrntParamPrntOutp
{
  public ItestGnrcPrntParamPrntOutpObject AsGnrcPrntParamPrntOutp { get; set; }
}

public class testRefGnrcPrntParamPrntOutp<TRef>
  : testref
  , ItestRefGnrcPrntParamPrntOutp<TRef>
{
  public ItestRefGnrcPrntParamPrntOutpObject AsRefGnrcPrntParamPrntOutp { get; set; }
}

public class testAltGnrcPrntParamPrntOutp
  : ItestAltGnrcPrntParamPrntOutp
{
  public decimal Alt { get; set; }
  public string AsString { get; set; }
  public ItestAltGnrcPrntParamPrntOutpObject AsAltGnrcPrntParamPrntOutp { get; set; }
}

public class testGnrcPrntSmplEnumDual
  : testFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
  , ItestGnrcPrntSmplEnumDual
{
  public ItestGnrcPrntSmplEnumDualObject AsGnrcPrntSmplEnumDual { get; set; }
}

public class testFieldGnrcPrntSmplEnumDual<TRef>
  : ItestFieldGnrcPrntSmplEnumDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntSmplEnumDualObject AsFieldGnrcPrntSmplEnumDual { get; set; }
}

public class testGnrcPrntSmplEnumInp
  : testFieldGnrcPrntSmplEnumInp<testEnumGnrcPrntSmplEnumInp>
  , ItestGnrcPrntSmplEnumInp
{
  public ItestGnrcPrntSmplEnumInpObject AsGnrcPrntSmplEnumInp { get; set; }
}

public class testFieldGnrcPrntSmplEnumInp<TRef>
  : ItestFieldGnrcPrntSmplEnumInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntSmplEnumInpObject AsFieldGnrcPrntSmplEnumInp { get; set; }
}

public class testGnrcPrntSmplEnumOutp
  : testFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
  , ItestGnrcPrntSmplEnumOutp
{
  public ItestGnrcPrntSmplEnumOutpObject AsGnrcPrntSmplEnumOutp { get; set; }
}

public class testFieldGnrcPrntSmplEnumOutp<TRef>
  : ItestFieldGnrcPrntSmplEnumOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntSmplEnumOutpObject AsFieldGnrcPrntSmplEnumOutp { get; set; }
}

public class testGnrcPrntStrDomDual
  : testFieldGnrcPrntStrDomDual<ItestDomGnrcPrntStrDomDual>
  , ItestGnrcPrntStrDomDual
{
  public ItestGnrcPrntStrDomDualObject AsGnrcPrntStrDomDual { get; set; }
}

public class testFieldGnrcPrntStrDomDual<TRef>
  : ItestFieldGnrcPrntStrDomDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntStrDomDualObject AsFieldGnrcPrntStrDomDual { get; set; }
}

public class testDomGnrcPrntStrDomDual
  : DomainString
  , ItestDomGnrcPrntStrDomDual
{
}

public class testGnrcPrntStrDomInp
  : testFieldGnrcPrntStrDomInp<ItestDomGnrcPrntStrDomInp>
  , ItestGnrcPrntStrDomInp
{
  public ItestGnrcPrntStrDomInpObject AsGnrcPrntStrDomInp { get; set; }
}

public class testFieldGnrcPrntStrDomInp<TRef>
  : ItestFieldGnrcPrntStrDomInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntStrDomInpObject AsFieldGnrcPrntStrDomInp { get; set; }
}

public class testDomGnrcPrntStrDomInp
  : DomainString
  , ItestDomGnrcPrntStrDomInp
{
}

public class testGnrcPrntStrDomOutp
  : testFieldGnrcPrntStrDomOutp<ItestDomGnrcPrntStrDomOutp>
  , ItestGnrcPrntStrDomOutp
{
  public ItestGnrcPrntStrDomOutpObject AsGnrcPrntStrDomOutp { get; set; }
}

public class testFieldGnrcPrntStrDomOutp<TRef>
  : ItestFieldGnrcPrntStrDomOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntStrDomOutpObject AsFieldGnrcPrntStrDomOutp { get; set; }
}

public class testDomGnrcPrntStrDomOutp
  : DomainString
  , ItestDomGnrcPrntStrDomOutp
{
}

public class testGnrcValueDual
  : ItestGnrcValueDual
{
  public ItestRefGnrcValueDual<testEnumGnrcValueDual> AsEnumGnrcValueDualgnrcValueDual { get; set; }
  public ItestGnrcValueDualObject AsGnrcValueDual { get; set; }
}

public class testRefGnrcValueDual<TType>
  : ItestRefGnrcValueDual<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcValueDualObject AsRefGnrcValueDual { get; set; }
}

public class testGnrcValueInp
  : ItestGnrcValueInp
{
  public ItestRefGnrcValueInp<testEnumGnrcValueInp> AsEnumGnrcValueInpgnrcValueInp { get; set; }
  public ItestGnrcValueInpObject AsGnrcValueInp { get; set; }
}

public class testRefGnrcValueInp<TType>
  : ItestRefGnrcValueInp<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcValueInpObject AsRefGnrcValueInp { get; set; }
}

public class testGnrcValueOutp
  : ItestGnrcValueOutp
{
  public ItestRefGnrcValueOutp<testEnumGnrcValueOutp> AsEnumGnrcValueOutpgnrcValueOutp { get; set; }
  public ItestGnrcValueOutpObject AsGnrcValueOutp { get; set; }
}

public class testRefGnrcValueOutp<TType>
  : ItestRefGnrcValueOutp<TType>
{
  public TType Field { get; set; }
  public ItestRefGnrcValueOutpObject AsRefGnrcValueOutp { get; set; }
}

public class testInpFieldDescrNmbr
  : ItestInpFieldDescrNmbr
{
  public decimal Field { get; set; }
  public ItestInpFieldDescrNmbrObject AsInpFieldDescrNmbr { get; set; }
}

public class testInpFieldEnum
  : ItestInpFieldEnum
{
  public testEnumInpFieldEnum Field { get; set; }
  public ItestInpFieldEnumObject AsInpFieldEnum { get; set; }
}

public class testInpFieldNull
  : ItestInpFieldNull
{
  public ItestFldInpFieldNull? Field { get; set; }
  public ItestInpFieldNullObject AsInpFieldNull { get; set; }
}

public class testFldInpFieldNull
  : ItestFldInpFieldNull
{
  public ItestFldInpFieldNullObject AsFldInpFieldNull { get; set; }
}

public class testInpFieldNmbr
  : ItestInpFieldNmbr
{
  public decimal Field { get; set; }
  public ItestInpFieldNmbrObject AsInpFieldNmbr { get; set; }
}

public class testInpFieldNmbrDescr
  : ItestInpFieldNmbrDescr
{
  public decimal Field { get; set; }
  public ItestInpFieldNmbrDescrObject AsInpFieldNmbrDescr { get; set; }
}

public class testInpFieldStr
  : ItestInpFieldStr
{
  public string Field { get; set; }
  public ItestInpFieldStrObject AsInpFieldStr { get; set; }
}

public class testOutpDescrParam
  : ItestOutpDescrParam
{
  public ItestFldOutpDescrParam Field { get; set; }
  public ItestOutpDescrParamObject AsOutpDescrParam { get; set; }
}

public class testFldOutpDescrParam
  : ItestFldOutpDescrParam
{
  public ItestFldOutpDescrParamObject AsFldOutpDescrParam { get; set; }
}

public class testInOutpDescrParam
  : ItestInOutpDescrParam
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpDescrParamObject AsInOutpDescrParam { get; set; }
}

public class testOutpParam
  : ItestOutpParam
{
  public ItestFldOutpParam Field { get; set; }
  public ItestOutpParamObject AsOutpParam { get; set; }
}

public class testFldOutpParam
  : ItestFldOutpParam
{
  public ItestFldOutpParamObject AsFldOutpParam { get; set; }
}

public class testInOutpParam
  : ItestInOutpParam
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpParamObject AsInOutpParam { get; set; }
}

public class testOutpParamDescr
  : ItestOutpParamDescr
{
  public ItestFldOutpParamDescr Field { get; set; }
  public ItestOutpParamDescrObject AsOutpParamDescr { get; set; }
}

public class testFldOutpParamDescr
  : ItestFldOutpParamDescr
{
  public ItestFldOutpParamDescrObject AsFldOutpParamDescr { get; set; }
}

public class testInOutpParamDescr
  : ItestInOutpParamDescr
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpParamDescrObject AsInOutpParamDescr { get; set; }
}

public class testOutpParamModDmn
  : ItestOutpParamModDmn
{
  public ItestDomOutpParamModDmn Field { get; set; }
  public ItestOutpParamModDmnObject AsOutpParamModDmn { get; set; }
}

public class testInOutpParamModDmn
  : ItestInOutpParamModDmn
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpParamModDmnObject AsInOutpParamModDmn { get; set; }
}

public class testDomOutpParamModDmn
  : DomainNumber
  , ItestDomOutpParamModDmn
{
}

public class testOutpParamModParam<TMod>
  : ItestOutpParamModParam<TMod>
{
  public ItestDomOutpParamModParam Field { get; set; }
  public ItestOutpParamModParamObject AsOutpParamModParam { get; set; }
}

public class testInOutpParamModParam
  : ItestInOutpParamModParam
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpParamModParamObject AsInOutpParamModParam { get; set; }
}

public class testDomOutpParamModParam
  : DomainNumber
  , ItestDomOutpParamModParam
{
}

public class testOutpParamTypeDescr
  : ItestOutpParamTypeDescr
{
  public ItestFldOutpParamTypeDescr Field { get; set; }
  public ItestOutpParamTypeDescrObject AsOutpParamTypeDescr { get; set; }
}

public class testFldOutpParamTypeDescr
  : ItestFldOutpParamTypeDescr
{
  public ItestFldOutpParamTypeDescrObject AsFldOutpParamTypeDescr { get; set; }
}

public class testInOutpParamTypeDescr
  : ItestInOutpParamTypeDescr
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpParamTypeDescrObject AsInOutpParamTypeDescr { get; set; }
}

public class testOutpPrntGnrc
  : ItestOutpPrntGnrc
{
  public ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc> AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; set; }
  public ItestOutpPrntGnrcObject AsOutpPrntGnrc { get; set; }
}

public class testRefOutpPrntGnrc<TType>
  : ItestRefOutpPrntGnrc<TType>
{
  public TType Field { get; set; }
  public ItestRefOutpPrntGnrcObject AsRefOutpPrntGnrc { get; set; }
}

public class testOutpPrntParam
  : testPrntOutpPrntParam
  , ItestOutpPrntParam
{
  public ItestFldOutpPrntParam Field { get; set; }
  public ItestOutpPrntParamObject AsOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParam
  : ItestPrntOutpPrntParam
{
  public ItestFldOutpPrntParam Field { get; set; }
  public ItestPrntOutpPrntParamObject AsPrntOutpPrntParam { get; set; }
}

public class testFldOutpPrntParam
  : ItestFldOutpPrntParam
{
  public ItestFldOutpPrntParamObject AsFldOutpPrntParam { get; set; }
}

public class testInOutpPrntParam
  : ItestInOutpPrntParam
{
  public decimal Param { get; set; }
  public string AsString { get; set; }
  public ItestInOutpPrntParamObject AsInOutpPrntParam { get; set; }
}

public class testPrntOutpPrntParamIn
  : ItestPrntOutpPrntParamIn
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestPrntOutpPrntParamInObject AsPrntOutpPrntParamIn { get; set; }
}

public class testPrntDual
  : testRefPrntDual
  , ItestPrntDual
{
  public ItestPrntDualObject AsPrntDual { get; set; }
}

public class testRefPrntDual
  : ItestRefPrntDual
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDualObject AsRefPrntDual { get; set; }
}

public class testPrntInp
  : testRefPrntInp
  , ItestPrntInp
{
  public ItestPrntInpObject AsPrntInp { get; set; }
}

public class testRefPrntInp
  : ItestRefPrntInp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntInpObject AsRefPrntInp { get; set; }
}

public class testPrntOutp
  : testRefPrntOutp
  , ItestPrntOutp
{
  public ItestPrntOutpObject AsPrntOutp { get; set; }
}

public class testRefPrntOutp
  : ItestRefPrntOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntOutpObject AsRefPrntOutp { get; set; }
}

public class testPrntAltDual
  : testRefPrntAltDual
  , ItestPrntAltDual
{
  public decimal AsNumber { get; set; }
  public ItestPrntAltDualObject AsPrntAltDual { get; set; }
}

public class testRefPrntAltDual
  : ItestRefPrntAltDual
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntAltDualObject AsRefPrntAltDual { get; set; }
}

public class testPrntAltInp
  : testRefPrntAltInp
  , ItestPrntAltInp
{
  public decimal AsNumber { get; set; }
  public ItestPrntAltInpObject AsPrntAltInp { get; set; }
}

public class testRefPrntAltInp
  : ItestRefPrntAltInp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntAltInpObject AsRefPrntAltInp { get; set; }
}

public class testPrntAltOutp
  : testRefPrntAltOutp
  , ItestPrntAltOutp
{
  public decimal AsNumber { get; set; }
  public ItestPrntAltOutpObject AsPrntAltOutp { get; set; }
}

public class testRefPrntAltOutp
  : ItestRefPrntAltOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntAltOutpObject AsRefPrntAltOutp { get; set; }
}

public class testPrntDescrDual
  : testRefPrntDescrDual
  , ItestPrntDescrDual
{
  public ItestPrntDescrDualObject AsPrntDescrDual { get; set; }
}

public class testRefPrntDescrDual
  : ItestRefPrntDescrDual
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDescrDualObject AsRefPrntDescrDual { get; set; }
}

public class testPrntDescrInp
  : testRefPrntDescrInp
  , ItestPrntDescrInp
{
  public ItestPrntDescrInpObject AsPrntDescrInp { get; set; }
}

public class testRefPrntDescrInp
  : ItestRefPrntDescrInp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDescrInpObject AsRefPrntDescrInp { get; set; }
}

public class testPrntDescrOutp
  : testRefPrntDescrOutp
  , ItestPrntDescrOutp
{
  public ItestPrntDescrOutpObject AsPrntDescrOutp { get; set; }
}

public class testRefPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDescrOutpObject AsRefPrntDescrOutp { get; set; }
}

public class testPrntDualDual
  : testRefPrntDualDual
  , ItestPrntDualDual
{
  public ItestPrntDualDualObject AsPrntDualDual { get; set; }
}

public class testRefPrntDualDual
  : ItestRefPrntDualDual
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDualDualObject AsRefPrntDualDual { get; set; }
}

public class testPrntDualInp
  : testRefPrntDualInp
  , ItestPrntDualInp
{
  public ItestPrntDualInpObject AsPrntDualInp { get; set; }
}

public class testRefPrntDualInp
  : ItestRefPrntDualInp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDualInpObject AsRefPrntDualInp { get; set; }
}

public class testPrntDualOutp
  : testRefPrntDualOutp
  , ItestPrntDualOutp
{
  public ItestPrntDualOutpObject AsPrntDualOutp { get; set; }
}

public class testRefPrntDualOutp
  : ItestRefPrntDualOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntDualOutpObject AsRefPrntDualOutp { get; set; }
}

public class testPrntFieldDual
  : testRefPrntFieldDual
  , ItestPrntFieldDual
{
  public decimal Field { get; set; }
  public ItestPrntFieldDualObject AsPrntFieldDual { get; set; }
}

public class testRefPrntFieldDual
  : ItestRefPrntFieldDual
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntFieldDualObject AsRefPrntFieldDual { get; set; }
}

public class testPrntFieldInp
  : testRefPrntFieldInp
  , ItestPrntFieldInp
{
  public decimal Field { get; set; }
  public ItestPrntFieldInpObject AsPrntFieldInp { get; set; }
}

public class testRefPrntFieldInp
  : ItestRefPrntFieldInp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntFieldInpObject AsRefPrntFieldInp { get; set; }
}

public class testPrntFieldOutp
  : testRefPrntFieldOutp
  , ItestPrntFieldOutp
{
  public decimal Field { get; set; }
  public ItestPrntFieldOutpObject AsPrntFieldOutp { get; set; }
}

public class testRefPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  public decimal Parent { get; set; }
  public string AsString { get; set; }
  public ItestRefPrntFieldOutpObject AsRefPrntFieldOutp { get; set; }
}

public class testPrntParamDiffDual<TA>
  : testRefPrntParamDiffDual<TA>
  , ItestPrntParamDiffDual<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamDiffDualObject AsPrntParamDiffDual { get; set; }
}

public class testRefPrntParamDiffDual<TB>
  : ItestRefPrntParamDiffDual<TB>
{
  public TB Asb { get; set; }
  public ItestRefPrntParamDiffDualObject AsRefPrntParamDiffDual { get; set; }
}

public class testPrntParamDiffInp<TA>
  : testRefPrntParamDiffInp<TA>
  , ItestPrntParamDiffInp<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamDiffInpObject AsPrntParamDiffInp { get; set; }
}

public class testRefPrntParamDiffInp<TB>
  : ItestRefPrntParamDiffInp<TB>
{
  public TB Asb { get; set; }
  public ItestRefPrntParamDiffInpObject AsRefPrntParamDiffInp { get; set; }
}

public class testPrntParamDiffOutp<TA>
  : testRefPrntParamDiffOutp<TA>
  , ItestPrntParamDiffOutp<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamDiffOutpObject AsPrntParamDiffOutp { get; set; }
}

public class testRefPrntParamDiffOutp<TB>
  : ItestRefPrntParamDiffOutp<TB>
{
  public TB Asb { get; set; }
  public ItestRefPrntParamDiffOutpObject AsRefPrntParamDiffOutp { get; set; }
}

public class testPrntParamSameDual<TA>
  : testRefPrntParamSameDual<TA>
  , ItestPrntParamSameDual<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamSameDualObject AsPrntParamSameDual { get; set; }
}

public class testRefPrntParamSameDual<TA>
  : ItestRefPrntParamSameDual<TA>
{
  public TA Asa { get; set; }
  public ItestRefPrntParamSameDualObject AsRefPrntParamSameDual { get; set; }
}

public class testPrntParamSameInp<TA>
  : testRefPrntParamSameInp<TA>
  , ItestPrntParamSameInp<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamSameInpObject AsPrntParamSameInp { get; set; }
}

public class testRefPrntParamSameInp<TA>
  : ItestRefPrntParamSameInp<TA>
{
  public TA Asa { get; set; }
  public ItestRefPrntParamSameInpObject AsRefPrntParamSameInp { get; set; }
}

public class testPrntParamSameOutp<TA>
  : testRefPrntParamSameOutp<TA>
  , ItestPrntParamSameOutp<TA>
{
  public TA Field { get; set; }
  public ItestPrntParamSameOutpObject AsPrntParamSameOutp { get; set; }
}

public class testRefPrntParamSameOutp<TA>
  : ItestRefPrntParamSameOutp<TA>
{
  public TA Asa { get; set; }
  public ItestRefPrntParamSameOutpObject AsRefPrntParamSameOutp { get; set; }
}
