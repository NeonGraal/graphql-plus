//HintName: test_+Objects_Intf.gen.cs
// Generated from {CurrentDirectory}+Objects.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Objects;

public interface ItestAltDual
  : IGqlpInterfaceBase
{
  ItestAltAltDual? AsAltAltDual { get; }
  ItestAltDualObject? As_AltDual { get; }
}

public interface ItestAltDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltDualObject? As_AltAltDual { get; }
}

public interface ItestAltAltDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltInp
  : IGqlpInterfaceBase
{
  ItestAltAltInp? AsAltAltInp { get; }
  ItestAltInpObject? As_AltInp { get; }
}

public interface ItestAltInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltInpObject? As_AltAltInp { get; }
}

public interface ItestAltAltInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltOutp
  : IGqlpInterfaceBase
{
  ItestAltAltOutp? AsAltAltOutp { get; }
  ItestAltOutpObject? As_AltOutp { get; }
}

public interface ItestAltOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltOutpObject? As_AltAltOutp { get; }
}

public interface ItestAltAltOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltDescrDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltDescrDualObject? As_AltDescrDual { get; }
}

public interface ItestAltDescrDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltDescrInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltDescrInpObject? As_AltDescrInp { get; }
}

public interface ItestAltDescrInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltDescrOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltDescrOutpObject? As_AltDescrOutp { get; }
}

public interface ItestAltDescrOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltDualDual
  : IGqlpInterfaceBase
{
  ItestObjDualAltDualDual? AsObjDualAltDualDual { get; }
  ItestAltDualDualObject? As_AltDualDual { get; }
}

public interface ItestAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjDualAltDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestObjDualAltDualDualObject? As_ObjDualAltDualDual { get; }
}

public interface ItestObjDualAltDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltDualInp
  : IGqlpInterfaceBase
{
  ItestObjDualAltDualInp? AsObjDualAltDualInp { get; }
  ItestAltDualInpObject? As_AltDualInp { get; }
}

public interface ItestAltDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjDualAltDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestObjDualAltDualInpObject? As_ObjDualAltDualInp { get; }
}

public interface ItestObjDualAltDualInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltDualOutp
  : IGqlpInterfaceBase
{
  ItestObjDualAltDualOutp? AsObjDualAltDualOutp { get; }
  ItestAltDualOutpObject? As_AltDualOutp { get; }
}

public interface ItestAltDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestObjDualAltDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestObjDualAltDualOutpObject? As_ObjDualAltDualOutp { get; }
}

public interface ItestObjDualAltDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltEnumDual
  : IGqlpInterfaceBase
{
  testEnumAltEnumDual? AsEnumAltEnumDualaltEnumDual { get; }
  ItestAltEnumDualObject? As_AltEnumDual { get; }
}

public interface ItestAltEnumDualObject
  : IGqlpInterfaceBase
{
}

public enum testEnumAltEnumDual
{
  altEnumDual,
}

public interface ItestAltEnumInp
  : IGqlpInterfaceBase
{
  testEnumAltEnumInp? AsEnumAltEnumInpaltEnumInp { get; }
  ItestAltEnumInpObject? As_AltEnumInp { get; }
}

public interface ItestAltEnumInpObject
  : IGqlpInterfaceBase
{
}

public enum testEnumAltEnumInp
{
  altEnumInp,
}

public interface ItestAltEnumOutp
  : IGqlpInterfaceBase
{
  testEnumAltEnumOutp? AsEnumAltEnumOutpaltEnumOutp { get; }
  ItestAltEnumOutpObject? As_AltEnumOutp { get; }
}

public interface ItestAltEnumOutpObject
  : IGqlpInterfaceBase
{
}

public enum testEnumAltEnumOutp
{
  altEnumOutp,
}

public interface ItestAltModBoolDual
  : IGqlpInterfaceBase
{
  IDictionary<bool, ItestAltAltModBoolDual>? AsAltAltModBoolDual { get; }
  ItestAltModBoolDualObject? As_AltModBoolDual { get; }
}

public interface ItestAltModBoolDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModBoolDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModBoolDualObject? As_AltAltModBoolDual { get; }
}

public interface ItestAltAltModBoolDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltModBoolInp
  : IGqlpInterfaceBase
{
  IDictionary<bool, ItestAltAltModBoolInp>? AsAltAltModBoolInp { get; }
  ItestAltModBoolInpObject? As_AltModBoolInp { get; }
}

public interface ItestAltModBoolInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModBoolInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModBoolInpObject? As_AltAltModBoolInp { get; }
}

public interface ItestAltAltModBoolInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltModBoolOutp
  : IGqlpInterfaceBase
{
  IDictionary<bool, ItestAltAltModBoolOutp>? AsAltAltModBoolOutp { get; }
  ItestAltModBoolOutpObject? As_AltModBoolOutp { get; }
}

public interface ItestAltModBoolOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModBoolOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModBoolOutpObject? As_AltAltModBoolOutp { get; }
}

public interface ItestAltAltModBoolOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltModParamDual<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestAltAltModParamDual>? AsAltAltModParamDual { get; }
  ItestAltModParamDualObject<TMod>? As_AltModParamDual { get; }
}

public interface ItestAltModParamDualObject<TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModParamDualObject? As_AltAltModParamDual { get; }
}

public interface ItestAltAltModParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltModParamInp<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestAltAltModParamInp>? AsAltAltModParamInp { get; }
  ItestAltModParamInpObject<TMod>? As_AltModParamInp { get; }
}

public interface ItestAltModParamInpObject<TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModParamInpObject? As_AltAltModParamInp { get; }
}

public interface ItestAltAltModParamInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltModParamOutp<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestAltAltModParamOutp>? AsAltAltModParamOutp { get; }
  ItestAltModParamOutpObject<TMod>? As_AltModParamOutp { get; }
}

public interface ItestAltModParamOutpObject<TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestAltAltModParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltAltModParamOutpObject? As_AltAltModParamOutp { get; }
}

public interface ItestAltAltModParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestAltSmplDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltSmplDualObject? As_AltSmplDual { get; }
}

public interface ItestAltSmplDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltSmplInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltSmplInpObject? As_AltSmplInp { get; }
}

public interface ItestAltSmplInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltSmplOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltSmplOutpObject? As_AltSmplOutp { get; }
}

public interface ItestAltSmplOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestCnstAltDual<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestCnstAltDualObject<TType>? As_CnstAltDual { get; }
}

public interface ItestCnstAltDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestCnstAltInp<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestCnstAltInpObject<TType>? As_CnstAltInp { get; }
}

public interface ItestCnstAltInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestCnstAltOutp<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestCnstAltOutpObject<TType>? As_CnstAltOutp { get; }
}

public interface ItestCnstAltOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestCnstAltDmnDual
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDmnDual<ItestDomCnstAltDmnDual>? AsRefCnstAltDmnDual { get; }
  ItestCnstAltDmnDualObject? As_CnstAltDmnDual { get; }
}

public interface ItestCnstAltDmnDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDmnDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnDualObject<TRef>? As_RefCnstAltDmnDual { get; }
}

public interface ItestRefCnstAltDmnDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestDomCnstAltDmnDual
  : IGqlpDomainString
{
}

public interface ItestCnstAltDmnInp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDmnInp<ItestDomCnstAltDmnInp>? AsRefCnstAltDmnInp { get; }
  ItestCnstAltDmnInpObject? As_CnstAltDmnInp { get; }
}

public interface ItestCnstAltDmnInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDmnInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnInpObject<TRef>? As_RefCnstAltDmnInp { get; }
}

public interface ItestRefCnstAltDmnInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestDomCnstAltDmnInp
  : IGqlpDomainString
{
}

public interface ItestCnstAltDmnOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDmnOutp<ItestDomCnstAltDmnOutp>? AsRefCnstAltDmnOutp { get; }
  ItestCnstAltDmnOutpObject? As_CnstAltDmnOutp { get; }
}

public interface ItestCnstAltDmnOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDmnOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDmnOutpObject<TRef>? As_RefCnstAltDmnOutp { get; }
}

public interface ItestRefCnstAltDmnOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestDomCnstAltDmnOutp
  : IGqlpDomainString
{
}

public interface ItestCnstAltDualDual
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDualDual<ItestAltCnstAltDualDual>? AsRefCnstAltDualDual { get; }
  ItestCnstAltDualDualObject? As_CnstAltDualDual { get; }
}

public interface ItestCnstAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualDualObject<TRef>? As_RefCnstAltDualDual { get; }
}

public interface ItestRefCnstAltDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualDualObject? As_PrntCnstAltDualDual { get; }
}

public interface ItestPrntCnstAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltDualDual
  : ItestPrntCnstAltDualDual
{
  ItestAltCnstAltDualDualObject? As_AltCnstAltDualDual { get; }
}

public interface ItestAltCnstAltDualDualObject
  : ItestPrntCnstAltDualDualObject
{
  decimal Alt { get; }
}

public interface ItestCnstAltDualInp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDualInp<ItestAltCnstAltDualInp>? AsRefCnstAltDualInp { get; }
  ItestCnstAltDualInpObject? As_CnstAltDualInp { get; }
}

public interface ItestCnstAltDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDualInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualInpObject<TRef>? As_RefCnstAltDualInp { get; }
}

public interface ItestRefCnstAltDualInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualInpObject? As_PrntCnstAltDualInp { get; }
}

public interface ItestPrntCnstAltDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  ItestAltCnstAltDualInpObject? As_AltCnstAltDualInp { get; }
}

public interface ItestAltCnstAltDualInpObject
  : ItestPrntCnstAltDualInpObject
{
  decimal Alt { get; }
}

public interface ItestCnstAltDualOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp>? AsRefCnstAltDualOutp { get; }
  ItestCnstAltDualOutpObject? As_CnstAltDualOutp { get; }
}

public interface ItestCnstAltDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualOutpObject<TRef>? As_RefCnstAltDualOutp { get; }
}

public interface ItestRefCnstAltDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualOutpObject? As_PrntCnstAltDualOutp { get; }
}

public interface ItestPrntCnstAltDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  ItestAltCnstAltDualOutpObject? As_AltCnstAltDualOutp { get; }
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  decimal Alt { get; }
}

public interface ItestCnstAltObjDual
  : IGqlpInterfaceBase
{
  ItestRefCnstAltObjDual<ItestAltCnstAltObjDual>? AsRefCnstAltObjDual { get; }
  ItestCnstAltObjDualObject? As_CnstAltObjDual { get; }
}

public interface ItestCnstAltObjDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltObjDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjDualObject<TRef>? As_RefCnstAltObjDual { get; }
}

public interface ItestRefCnstAltObjDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltObjDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjDualObject? As_PrntCnstAltObjDual { get; }
}

public interface ItestPrntCnstAltObjDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  ItestAltCnstAltObjDualObject? As_AltCnstAltObjDual { get; }
}

public interface ItestAltCnstAltObjDualObject
  : ItestPrntCnstAltObjDualObject
{
  decimal Alt { get; }
}

public interface ItestCnstAltObjInp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltObjInp<ItestAltCnstAltObjInp>? AsRefCnstAltObjInp { get; }
  ItestCnstAltObjInpObject? As_CnstAltObjInp { get; }
}

public interface ItestCnstAltObjInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltObjInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjInpObject<TRef>? As_RefCnstAltObjInp { get; }
}

public interface ItestRefCnstAltObjInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltObjInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjInpObject? As_PrntCnstAltObjInp { get; }
}

public interface ItestPrntCnstAltObjInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  ItestAltCnstAltObjInpObject? As_AltCnstAltObjInp { get; }
}

public interface ItestAltCnstAltObjInpObject
  : ItestPrntCnstAltObjInpObject
{
  decimal Alt { get; }
}

public interface ItestCnstAltObjOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp>? AsRefCnstAltObjOutp { get; }
  ItestCnstAltObjOutpObject? As_CnstAltObjOutp { get; }
}

public interface ItestCnstAltObjOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltObjOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjOutpObject<TRef>? As_RefCnstAltObjOutp { get; }
}

public interface ItestRefCnstAltObjOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltObjOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjOutpObject? As_PrntCnstAltObjOutp { get; }
}

public interface ItestPrntCnstAltObjOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  ItestAltCnstAltObjOutpObject? As_AltCnstAltObjOutp { get; }
}

public interface ItestAltCnstAltObjOutpObject
  : ItestPrntCnstAltObjOutpObject
{
  decimal Alt { get; }
}

public interface ItestCnstDomEnumDual
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumDual<testEnumCnstDomEnumDual>? AsEnumCnstDomEnumDualcnstDomEnumDual { get; }
  ItestCnstDomEnumDualObject? As_CnstDomEnumDual { get; }
}

public interface ItestCnstDomEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstDomEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumDualObject<TType>? As_RefCnstDomEnumDual { get; }
}

public interface ItestRefCnstDomEnumDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumDual
{
  cnstDomEnumDual,
  other,
}

public interface ItestJustCnstDomEnumDual
  : IGqlpDomainEnum
{
}

public interface ItestCnstDomEnumInp
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumInp<testEnumCnstDomEnumInp>? AsEnumCnstDomEnumInpcnstDomEnumInp { get; }
  ItestCnstDomEnumInpObject? As_CnstDomEnumInp { get; }
}

public interface ItestCnstDomEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstDomEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumInpObject<TType>? As_RefCnstDomEnumInp { get; }
}

public interface ItestRefCnstDomEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumInp
{
  cnstDomEnumInp,
  other,
}

public interface ItestJustCnstDomEnumInp
  : IGqlpDomainEnum
{
}

public interface ItestCnstDomEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumOutp<testEnumCnstDomEnumOutp>? AsEnumCnstDomEnumOutpcnstDomEnumOutp { get; }
  ItestCnstDomEnumOutpObject? As_CnstDomEnumOutp { get; }
}

public interface ItestCnstDomEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstDomEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstDomEnumOutpObject<TType>? As_RefCnstDomEnumOutp { get; }
}

public interface ItestRefCnstDomEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstDomEnumOutp
{
  cnstDomEnumOutp,
  other,
}

public interface ItestJustCnstDomEnumOutp
  : IGqlpDomainEnum
{
}

public interface ItestCnstEnumDual
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumDual<testEnumCnstEnumDual>? AsEnumCnstEnumDualcnstEnumDual { get; }
  ItestCnstEnumDualObject? As_CnstEnumDual { get; }
}

public interface ItestCnstEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumDualObject<TType>? As_RefCnstEnumDual { get; }
}

public interface ItestRefCnstEnumDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumDual
{
  cnstEnumDual,
}

public interface ItestCnstEnumInp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumInp<testEnumCnstEnumInp>? AsEnumCnstEnumInpcnstEnumInp { get; }
  ItestCnstEnumInpObject? As_CnstEnumInp { get; }
}

public interface ItestCnstEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumInpObject<TType>? As_RefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumInp
{
  cnstEnumInp,
}

public interface ItestCnstEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumOutp<testEnumCnstEnumOutp>? AsEnumCnstEnumOutpcnstEnumOutp { get; }
  ItestCnstEnumOutpObject? As_CnstEnumOutp { get; }
}

public interface ItestCnstEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumOutpObject<TType>? As_RefCnstEnumOutp { get; }
}

public interface ItestRefCnstEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumOutp
{
  cnstEnumOutp,
}

public interface ItestCnstEnumPrntDual
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntDual<testEnumCnstEnumPrntDual>? AsEnumCnstEnumPrntDualcnstEnumPrntDual { get; }
  ItestCnstEnumPrntDualObject? As_CnstEnumPrntDual { get; }
}

public interface ItestCnstEnumPrntDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumPrntDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntDualObject<TType>? As_RefCnstEnumPrntDual { get; }
}

public interface ItestRefCnstEnumPrntDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntDual
{
  parentCnstEnumPrntDual = testParentCnstEnumPrntDual.parentCnstEnumPrntDual,
  cnstEnumPrntDual,
}

public enum testParentCnstEnumPrntDual
{
  parentCnstEnumPrntDual,
}

public interface ItestCnstEnumPrntInp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntInp<testEnumCnstEnumPrntInp>? AsEnumCnstEnumPrntInpcnstEnumPrntInp { get; }
  ItestCnstEnumPrntInpObject? As_CnstEnumPrntInp { get; }
}

public interface ItestCnstEnumPrntInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumPrntInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntInpObject<TType>? As_RefCnstEnumPrntInp { get; }
}

public interface ItestRefCnstEnumPrntInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntInp
{
  parentCnstEnumPrntInp = testParentCnstEnumPrntInp.parentCnstEnumPrntInp,
  cnstEnumPrntInp,
}

public enum testParentCnstEnumPrntInp
{
  parentCnstEnumPrntInp,
}

public interface ItestCnstEnumPrntOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntOutp<testEnumCnstEnumPrntOutp>? AsEnumCnstEnumPrntOutpcnstEnumPrntOutp { get; }
  ItestCnstEnumPrntOutpObject? As_CnstEnumPrntOutp { get; }
}

public interface ItestCnstEnumPrntOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstEnumPrntOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstEnumPrntOutpObject<TType>? As_RefCnstEnumPrntOutp { get; }
}

public interface ItestRefCnstEnumPrntOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp = testParentCnstEnumPrntOutp.parentCnstEnumPrntOutp,
  cnstEnumPrntOutp,
}

public enum testParentCnstEnumPrntOutp
{
  parentCnstEnumPrntOutp,
}

public interface ItestCnstFieldDmnDual
  : ItestRefCnstFieldDmnDual<ItestDomCnstFieldDmnDual>
{
  ItestCnstFieldDmnDualObject? As_CnstFieldDmnDual { get; }
}

public interface ItestCnstFieldDmnDualObject
  : ItestRefCnstFieldDmnDualObject<ItestDomCnstFieldDmnDual>
{
}

public interface ItestRefCnstFieldDmnDual<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDmnDualObject<TRef>? As_RefCnstFieldDmnDual { get; }
}

public interface ItestRefCnstFieldDmnDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnDual
  : IGqlpDomainString
{
}

public interface ItestCnstFieldDmnInp
  : ItestRefCnstFieldDmnInp<ItestDomCnstFieldDmnInp>
{
  ItestCnstFieldDmnInpObject? As_CnstFieldDmnInp { get; }
}

public interface ItestCnstFieldDmnInpObject
  : ItestRefCnstFieldDmnInpObject<ItestDomCnstFieldDmnInp>
{
}

public interface ItestRefCnstFieldDmnInp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDmnInpObject<TRef>? As_RefCnstFieldDmnInp { get; }
}

public interface ItestRefCnstFieldDmnInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnInp
  : IGqlpDomainString
{
}

public interface ItestCnstFieldDmnOutp
  : ItestRefCnstFieldDmnOutp<ItestDomCnstFieldDmnOutp>
{
  ItestCnstFieldDmnOutpObject? As_CnstFieldDmnOutp { get; }
}

public interface ItestCnstFieldDmnOutpObject
  : ItestRefCnstFieldDmnOutpObject<ItestDomCnstFieldDmnOutp>
{
}

public interface ItestRefCnstFieldDmnOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDmnOutpObject<TRef>? As_RefCnstFieldDmnOutp { get; }
}

public interface ItestRefCnstFieldDmnOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomCnstFieldDmnOutp
  : IGqlpDomainString
{
}

public interface ItestCnstFieldDualDual
  : ItestRefCnstFieldDualDual<ItestAltCnstFieldDualDual>
{
  ItestCnstFieldDualDualObject? As_CnstFieldDualDual { get; }
}

public interface ItestCnstFieldDualDualObject
  : ItestRefCnstFieldDualDualObject<ItestAltCnstFieldDualDual>
{
}

public interface ItestRefCnstFieldDualDual<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDualDualObject<TRef>? As_RefCnstFieldDualDual { get; }
}

public interface ItestRefCnstFieldDualDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldDualDualObject? As_PrntCnstFieldDualDual { get; }
}

public interface ItestPrntCnstFieldDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstFieldDualDual
  : ItestPrntCnstFieldDualDual
{
  ItestAltCnstFieldDualDualObject? As_AltCnstFieldDualDual { get; }
}

public interface ItestAltCnstFieldDualDualObject
  : ItestPrntCnstFieldDualDualObject
{
  decimal Alt { get; }
}

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp<ItestAltCnstFieldDualInp>
{
  ItestCnstFieldDualInpObject? As_CnstFieldDualInp { get; }
}

public interface ItestCnstFieldDualInpObject
  : ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>
{
}

public interface ItestRefCnstFieldDualInp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDualInpObject<TRef>? As_RefCnstFieldDualInp { get; }
}

public interface ItestRefCnstFieldDualInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldDualInpObject? As_PrntCnstFieldDualInp { get; }
}

public interface ItestPrntCnstFieldDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  ItestAltCnstFieldDualInpObject? As_AltCnstFieldDualInp { get; }
}

public interface ItestAltCnstFieldDualInpObject
  : ItestPrntCnstFieldDualInpObject
{
  decimal Alt { get; }
}

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp<ItestAltCnstFieldDualOutp>
{
  ItestCnstFieldDualOutpObject? As_CnstFieldDualOutp { get; }
}

public interface ItestCnstFieldDualOutpObject
  : ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>
{
}

public interface ItestRefCnstFieldDualOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDualOutpObject<TRef>? As_RefCnstFieldDualOutp { get; }
}

public interface ItestRefCnstFieldDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldDualOutpObject? As_PrntCnstFieldDualOutp { get; }
}

public interface ItestPrntCnstFieldDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  ItestAltCnstFieldDualOutpObject? As_AltCnstFieldDualOutp { get; }
}

public interface ItestAltCnstFieldDualOutpObject
  : ItestPrntCnstFieldDualOutpObject
{
  decimal Alt { get; }
}

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
{
  ItestCnstFieldObjDualObject? As_CnstFieldObjDual { get; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>
{
}

public interface ItestRefCnstFieldObjDual<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldObjDualObject<TRef>? As_RefCnstFieldObjDual { get; }
}

public interface ItestRefCnstFieldObjDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldObjDualObject? As_PrntCnstFieldObjDual { get; }
}

public interface ItestPrntCnstFieldObjDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  ItestAltCnstFieldObjDualObject? As_AltCnstFieldObjDual { get; }
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  decimal Alt { get; }
}

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp<ItestAltCnstFieldObjInp>
{
  ItestCnstFieldObjInpObject? As_CnstFieldObjInp { get; }
}

public interface ItestCnstFieldObjInpObject
  : ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>
{
}

public interface ItestRefCnstFieldObjInp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldObjInpObject<TRef>? As_RefCnstFieldObjInp { get; }
}

public interface ItestRefCnstFieldObjInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldObjInpObject? As_PrntCnstFieldObjInp { get; }
}

public interface ItestPrntCnstFieldObjInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  ItestAltCnstFieldObjInpObject? As_AltCnstFieldObjInp { get; }
}

public interface ItestAltCnstFieldObjInpObject
  : ItestPrntCnstFieldObjInpObject
{
  decimal Alt { get; }
}

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
{
  ItestCnstFieldObjOutpObject? As_CnstFieldObjOutp { get; }
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject<ItestAltCnstFieldObjOutp>
{
}

public interface ItestRefCnstFieldObjOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldObjOutpObject<TRef>? As_RefCnstFieldObjOutp { get; }
}

public interface ItestRefCnstFieldObjOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldObjOutpObject? As_PrntCnstFieldObjOutp { get; }
}

public interface ItestPrntCnstFieldObjOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  ItestAltCnstFieldObjOutpObject? As_AltCnstFieldObjOutp { get; }
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntDualGrndDual
  : ItestRefCnstPrntDualGrndDual<ItestAltCnstPrntDualGrndDual>
{
  ItestCnstPrntDualGrndDualObject? As_CnstPrntDualGrndDual { get; }
}

public interface ItestCnstPrntDualGrndDualObject
  : ItestRefCnstPrntDualGrndDualObject<ItestAltCnstPrntDualGrndDual>
{
}

public interface ItestRefCnstPrntDualGrndDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualGrndDualObject<TRef>? As_RefCnstPrntDualGrndDual { get; }
}

public interface ItestRefCnstPrntDualGrndDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGrndCnstPrntDualGrndDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestGrndCnstPrntDualGrndDualObject? As_GrndCnstPrntDualGrndDual { get; }
}

public interface ItestGrndCnstPrntDualGrndDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualGrndDual
  : ItestGrndCnstPrntDualGrndDual
{
  ItestPrntCnstPrntDualGrndDualObject? As_PrntCnstPrntDualGrndDual { get; }
}

public interface ItestPrntCnstPrntDualGrndDualObject
  : ItestGrndCnstPrntDualGrndDualObject
{
}

public interface ItestAltCnstPrntDualGrndDual
  : ItestPrntCnstPrntDualGrndDual
{
  ItestAltCnstPrntDualGrndDualObject? As_AltCnstPrntDualGrndDual { get; }
}

public interface ItestAltCnstPrntDualGrndDualObject
  : ItestPrntCnstPrntDualGrndDualObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntDualGrndInp
  : ItestRefCnstPrntDualGrndInp<ItestAltCnstPrntDualGrndInp>
{
  ItestCnstPrntDualGrndInpObject? As_CnstPrntDualGrndInp { get; }
}

public interface ItestCnstPrntDualGrndInpObject
  : ItestRefCnstPrntDualGrndInpObject<ItestAltCnstPrntDualGrndInp>
{
}

public interface ItestRefCnstPrntDualGrndInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualGrndInpObject<TRef>? As_RefCnstPrntDualGrndInp { get; }
}

public interface ItestRefCnstPrntDualGrndInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGrndCnstPrntDualGrndInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestGrndCnstPrntDualGrndInpObject? As_GrndCnstPrntDualGrndInp { get; }
}

public interface ItestGrndCnstPrntDualGrndInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualGrndInp
  : ItestGrndCnstPrntDualGrndInp
{
  ItestPrntCnstPrntDualGrndInpObject? As_PrntCnstPrntDualGrndInp { get; }
}

public interface ItestPrntCnstPrntDualGrndInpObject
  : ItestGrndCnstPrntDualGrndInpObject
{
}

public interface ItestAltCnstPrntDualGrndInp
  : ItestPrntCnstPrntDualGrndInp
{
  ItestAltCnstPrntDualGrndInpObject? As_AltCnstPrntDualGrndInp { get; }
}

public interface ItestAltCnstPrntDualGrndInpObject
  : ItestPrntCnstPrntDualGrndInpObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntDualGrndOutp
  : ItestRefCnstPrntDualGrndOutp<ItestAltCnstPrntDualGrndOutp>
{
  ItestCnstPrntDualGrndOutpObject? As_CnstPrntDualGrndOutp { get; }
}

public interface ItestCnstPrntDualGrndOutpObject
  : ItestRefCnstPrntDualGrndOutpObject<ItestAltCnstPrntDualGrndOutp>
{
}

public interface ItestRefCnstPrntDualGrndOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualGrndOutpObject<TRef>? As_RefCnstPrntDualGrndOutp { get; }
}

public interface ItestRefCnstPrntDualGrndOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGrndCnstPrntDualGrndOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestGrndCnstPrntDualGrndOutpObject? As_GrndCnstPrntDualGrndOutp { get; }
}

public interface ItestGrndCnstPrntDualGrndOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualGrndOutp
  : ItestGrndCnstPrntDualGrndOutp
{
  ItestPrntCnstPrntDualGrndOutpObject? As_PrntCnstPrntDualGrndOutp { get; }
}

public interface ItestPrntCnstPrntDualGrndOutpObject
  : ItestGrndCnstPrntDualGrndOutpObject
{
}

public interface ItestAltCnstPrntDualGrndOutp
  : ItestPrntCnstPrntDualGrndOutp
{
  ItestAltCnstPrntDualGrndOutpObject? As_AltCnstPrntDualGrndOutp { get; }
}

public interface ItestAltCnstPrntDualGrndOutpObject
  : ItestPrntCnstPrntDualGrndOutpObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntDualPrntDual
  : ItestRefCnstPrntDualPrntDual<ItestAltCnstPrntDualPrntDual>
{
  ItestCnstPrntDualPrntDualObject? As_CnstPrntDualPrntDual { get; }
}

public interface ItestCnstPrntDualPrntDualObject
  : ItestRefCnstPrntDualPrntDualObject<ItestAltCnstPrntDualPrntDual>
{
}

public interface ItestRefCnstPrntDualPrntDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntDualObject<TRef>? As_RefCnstPrntDualPrntDual { get; }
}

public interface ItestRefCnstPrntDualPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualPrntDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntDualObject? As_PrntCnstPrntDualPrntDual { get; }
}

public interface ItestPrntCnstPrntDualPrntDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntDualPrntDual
  : ItestPrntCnstPrntDualPrntDual
{
  ItestAltCnstPrntDualPrntDualObject? As_AltCnstPrntDualPrntDual { get; }
}

public interface ItestAltCnstPrntDualPrntDualObject
  : ItestPrntCnstPrntDualPrntDualObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntDualPrntInp
  : ItestRefCnstPrntDualPrntInp<ItestAltCnstPrntDualPrntInp>
{
  ItestCnstPrntDualPrntInpObject? As_CnstPrntDualPrntInp { get; }
}

public interface ItestCnstPrntDualPrntInpObject
  : ItestRefCnstPrntDualPrntInpObject<ItestAltCnstPrntDualPrntInp>
{
}

public interface ItestRefCnstPrntDualPrntInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntInpObject<TRef>? As_RefCnstPrntDualPrntInp { get; }
}

public interface ItestRefCnstPrntDualPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualPrntInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntInpObject? As_PrntCnstPrntDualPrntInp { get; }
}

public interface ItestPrntCnstPrntDualPrntInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntDualPrntInp
  : ItestPrntCnstPrntDualPrntInp
{
  ItestAltCnstPrntDualPrntInpObject? As_AltCnstPrntDualPrntInp { get; }
}

public interface ItestAltCnstPrntDualPrntInpObject
  : ItestPrntCnstPrntDualPrntInpObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntDualPrntOutp
  : ItestRefCnstPrntDualPrntOutp<ItestAltCnstPrntDualPrntOutp>
{
  ItestCnstPrntDualPrntOutpObject? As_CnstPrntDualPrntOutp { get; }
}

public interface ItestCnstPrntDualPrntOutpObject
  : ItestRefCnstPrntDualPrntOutpObject<ItestAltCnstPrntDualPrntOutp>
{
}

public interface ItestRefCnstPrntDualPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntDualPrntOutpObject<TRef>? As_RefCnstPrntDualPrntOutp { get; }
}

public interface ItestRefCnstPrntDualPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntDualPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntDualPrntOutpObject? As_PrntCnstPrntDualPrntOutp { get; }
}

public interface ItestPrntCnstPrntDualPrntOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntDualPrntOutp
  : ItestPrntCnstPrntDualPrntOutp
{
  ItestAltCnstPrntDualPrntOutpObject? As_AltCnstPrntDualPrntOutp { get; }
}

public interface ItestAltCnstPrntDualPrntOutpObject
  : ItestPrntCnstPrntDualPrntOutpObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntEnumDual
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumDual<testParentCnstPrntEnumDual>? AsParentCnstPrntEnumDualparentCnstPrntEnumDual { get; }
  ItestCnstPrntEnumDualObject? As_CnstPrntEnumDual { get; }
}

public interface ItestCnstPrntEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstPrntEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumDualObject<TType>? As_RefCnstPrntEnumDual { get; }
}

public interface ItestRefCnstPrntEnumDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumDual
{
  parentCnstPrntEnumDual = testParentCnstPrntEnumDual.parentCnstPrntEnumDual,
  cnstPrntEnumDual,
}

public enum testParentCnstPrntEnumDual
{
  parentCnstPrntEnumDual,
}

public interface ItestCnstPrntEnumInp
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumInp<testParentCnstPrntEnumInp>? AsParentCnstPrntEnumInpparentCnstPrntEnumInp { get; }
  ItestCnstPrntEnumInpObject? As_CnstPrntEnumInp { get; }
}

public interface ItestCnstPrntEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstPrntEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumInpObject<TType>? As_RefCnstPrntEnumInp { get; }
}

public interface ItestRefCnstPrntEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumInp
{
  parentCnstPrntEnumInp = testParentCnstPrntEnumInp.parentCnstPrntEnumInp,
  cnstPrntEnumInp,
}

public enum testParentCnstPrntEnumInp
{
  parentCnstPrntEnumInp,
}

public interface ItestCnstPrntEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumOutp<testParentCnstPrntEnumOutp>? AsParentCnstPrntEnumOutpparentCnstPrntEnumOutp { get; }
  ItestCnstPrntEnumOutpObject? As_CnstPrntEnumOutp { get; }
}

public interface ItestCnstPrntEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstPrntEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefCnstPrntEnumOutpObject<TType>? As_RefCnstPrntEnumOutp { get; }
}

public interface ItestRefCnstPrntEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp = testParentCnstPrntEnumOutp.parentCnstPrntEnumOutp,
  cnstPrntEnumOutp,
}

public enum testParentCnstPrntEnumOutp
{
  parentCnstPrntEnumOutp,
}

public interface ItestCnstPrntObjPrntDual
  : ItestRefCnstPrntObjPrntDual<ItestAltCnstPrntObjPrntDual>
{
  ItestCnstPrntObjPrntDualObject? As_CnstPrntObjPrntDual { get; }
}

public interface ItestCnstPrntObjPrntDualObject
  : ItestRefCnstPrntObjPrntDualObject<ItestAltCnstPrntObjPrntDual>
{
}

public interface ItestRefCnstPrntObjPrntDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntDualObject<TRef>? As_RefCnstPrntObjPrntDual { get; }
}

public interface ItestRefCnstPrntObjPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntObjPrntDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntDualObject? As_PrntCnstPrntObjPrntDual { get; }
}

public interface ItestPrntCnstPrntObjPrntDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntObjPrntDual
  : ItestPrntCnstPrntObjPrntDual
{
  ItestAltCnstPrntObjPrntDualObject? As_AltCnstPrntObjPrntDual { get; }
}

public interface ItestAltCnstPrntObjPrntDualObject
  : ItestPrntCnstPrntObjPrntDualObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntObjPrntInp
  : ItestRefCnstPrntObjPrntInp<ItestAltCnstPrntObjPrntInp>
{
  ItestCnstPrntObjPrntInpObject? As_CnstPrntObjPrntInp { get; }
}

public interface ItestCnstPrntObjPrntInpObject
  : ItestRefCnstPrntObjPrntInpObject<ItestAltCnstPrntObjPrntInp>
{
}

public interface ItestRefCnstPrntObjPrntInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntInpObject<TRef>? As_RefCnstPrntObjPrntInp { get; }
}

public interface ItestRefCnstPrntObjPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntObjPrntInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntInpObject? As_PrntCnstPrntObjPrntInp { get; }
}

public interface ItestPrntCnstPrntObjPrntInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntObjPrntInp
  : ItestPrntCnstPrntObjPrntInp
{
  ItestAltCnstPrntObjPrntInpObject? As_AltCnstPrntObjPrntInp { get; }
}

public interface ItestAltCnstPrntObjPrntInpObject
  : ItestPrntCnstPrntObjPrntInpObject
{
  decimal Alt { get; }
}

public interface ItestCnstPrntObjPrntOutp
  : ItestRefCnstPrntObjPrntOutp<ItestAltCnstPrntObjPrntOutp>
{
  ItestCnstPrntObjPrntOutpObject? As_CnstPrntObjPrntOutp { get; }
}

public interface ItestCnstPrntObjPrntOutpObject
  : ItestRefCnstPrntObjPrntOutpObject<ItestAltCnstPrntObjPrntOutp>
{
}

public interface ItestRefCnstPrntObjPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefCnstPrntObjPrntOutpObject<TRef>? As_RefCnstPrntObjPrntOutp { get; }
}

public interface ItestRefCnstPrntObjPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstPrntObjPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstPrntObjPrntOutpObject? As_PrntCnstPrntObjPrntOutp { get; }
}

public interface ItestPrntCnstPrntObjPrntOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstPrntObjPrntOutp
  : ItestPrntCnstPrntObjPrntOutp
{
  ItestAltCnstPrntObjPrntOutpObject? As_AltCnstPrntObjPrntOutp { get; }
}

public interface ItestAltCnstPrntObjPrntOutpObject
  : ItestPrntCnstPrntObjPrntOutpObject
{
  decimal Alt { get; }
}

public interface ItestFieldDual
  : IGqlpInterfaceBase
{
  ItestFieldDualObject? As_FieldDual { get; }
}

public interface ItestFieldDualObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestFieldInp
  : IGqlpInterfaceBase
{
  ItestFieldInpObject? As_FieldInp { get; }
}

public interface ItestFieldInpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestFieldOutp
  : IGqlpInterfaceBase
{
  ItestFieldOutpObject? As_FieldOutp { get; }
}

public interface ItestFieldOutpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestFieldDescrDual
  : IGqlpInterfaceBase
{
  ItestFieldDescrDualObject? As_FieldDescrDual { get; }
}

public interface ItestFieldDescrDualObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestFieldDescrInp
  : IGqlpInterfaceBase
{
  ItestFieldDescrInpObject? As_FieldDescrInp { get; }
}

public interface ItestFieldDescrInpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestFieldDescrOutp
  : IGqlpInterfaceBase
{
  ItestFieldDescrOutpObject? As_FieldDescrOutp { get; }
}

public interface ItestFieldDescrOutpObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestFieldDualDual
  : IGqlpInterfaceBase
{
  ItestFieldDualDualObject? As_FieldDualDual { get; }
}

public interface ItestFieldDualDualObject
  : IGqlpInterfaceBase
{
  ItestFldFieldDualDual Field { get; }
}

public interface ItestFldFieldDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldDualDualObject? As_FldFieldDualDual { get; }
}

public interface ItestFldFieldDualDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldDualInp
  : IGqlpInterfaceBase
{
  ItestFieldDualInpObject? As_FieldDualInp { get; }
}

public interface ItestFieldDualInpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldDualInp Field { get; }
}

public interface ItestFldFieldDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldDualInpObject? As_FldFieldDualInp { get; }
}

public interface ItestFldFieldDualInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldDualOutp
  : IGqlpInterfaceBase
{
  ItestFieldDualOutpObject? As_FieldDualOutp { get; }
}

public interface ItestFieldDualOutpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldDualOutp Field { get; }
}

public interface ItestFldFieldDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldDualOutpObject? As_FldFieldDualOutp { get; }
}

public interface ItestFldFieldDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldEnumDual
  : IGqlpInterfaceBase
{
  ItestFieldEnumDualObject? As_FieldEnumDual { get; }
}

public interface ItestFieldEnumDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumDual Field { get; }
}

public enum testEnumFieldEnumDual
{
  fieldEnumDual,
}

public interface ItestFieldEnumInp
  : IGqlpInterfaceBase
{
  ItestFieldEnumInpObject? As_FieldEnumInp { get; }
}

public interface ItestFieldEnumInpObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumInp Field { get; }
}

public enum testEnumFieldEnumInp
{
  fieldEnumInp,
}

public interface ItestFieldEnumOutp
  : IGqlpInterfaceBase
{
  ItestFieldEnumOutpObject? As_FieldEnumOutp { get; }
}

public interface ItestFieldEnumOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumOutp Field { get; }
}

public enum testEnumFieldEnumOutp
{
  fieldEnumOutp,
}

public interface ItestFieldEnumPrntDual
  : IGqlpInterfaceBase
{
  ItestFieldEnumPrntDualObject? As_FieldEnumPrntDual { get; }
}

public interface ItestFieldEnumPrntDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumPrntDual Field { get; }
}

public enum testEnumFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual = testPrntFieldEnumPrntDual.prnt_fieldEnumPrntDual,
  fieldEnumPrntDual,
}

public enum testPrntFieldEnumPrntDual
{
  prnt_fieldEnumPrntDual,
}

public interface ItestFieldEnumPrntInp
  : IGqlpInterfaceBase
{
  ItestFieldEnumPrntInpObject? As_FieldEnumPrntInp { get; }
}

public interface ItestFieldEnumPrntInpObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumPrntInp Field { get; }
}

public enum testEnumFieldEnumPrntInp
{
  prnt_fieldEnumPrntInp = testPrntFieldEnumPrntInp.prnt_fieldEnumPrntInp,
  fieldEnumPrntInp,
}

public enum testPrntFieldEnumPrntInp
{
  prnt_fieldEnumPrntInp,
}

public interface ItestFieldEnumPrntOutp
  : IGqlpInterfaceBase
{
  ItestFieldEnumPrntOutpObject? As_FieldEnumPrntOutp { get; }
}

public interface ItestFieldEnumPrntOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldEnumPrntOutp Field { get; }
}

public enum testEnumFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp = testPrntFieldEnumPrntOutp.prnt_fieldEnumPrntOutp,
  fieldEnumPrntOutp,
}

public enum testPrntFieldEnumPrntOutp
{
  prnt_fieldEnumPrntOutp,
}

public interface ItestFieldModEnumDual
  : IGqlpInterfaceBase
{
  ItestFieldModEnumDualObject? As_FieldModEnumDual { get; }
}

public interface ItestFieldModEnumDualObject
  : IGqlpInterfaceBase
{
  IDictionary<testEnumFieldModEnumDual, string> Field { get; }
}

public enum testEnumFieldModEnumDual
{
  value,
}

public interface ItestFieldModEnumInp
  : IGqlpInterfaceBase
{
  ItestFieldModEnumInpObject? As_FieldModEnumInp { get; }
}

public interface ItestFieldModEnumInpObject
  : IGqlpInterfaceBase
{
  IDictionary<testEnumFieldModEnumInp, string> Field { get; }
}

public enum testEnumFieldModEnumInp
{
  value,
}

public interface ItestFieldModEnumOutp
  : IGqlpInterfaceBase
{
  ItestFieldModEnumOutpObject? As_FieldModEnumOutp { get; }
}

public interface ItestFieldModEnumOutpObject
  : IGqlpInterfaceBase
{
  IDictionary<testEnumFieldModEnumOutp, string> Field { get; }
}

public enum testEnumFieldModEnumOutp
{
  value,
}

public interface ItestFieldModParamDual<TMod>
  : IGqlpInterfaceBase
{
  ItestFieldModParamDualObject<TMod>? As_FieldModParamDual { get; }
}

public interface ItestFieldModParamDualObject<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestFldFieldModParamDual> Field { get; }
}

public interface ItestFldFieldModParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldModParamDualObject? As_FldFieldModParamDual { get; }
}

public interface ItestFldFieldModParamDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldModParamInp<TMod>
  : IGqlpInterfaceBase
{
  ItestFieldModParamInpObject<TMod>? As_FieldModParamInp { get; }
}

public interface ItestFieldModParamInpObject<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestFldFieldModParamInp> Field { get; }
}

public interface ItestFldFieldModParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldModParamInpObject? As_FldFieldModParamInp { get; }
}

public interface ItestFldFieldModParamInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldModParamOutp<TMod>
  : IGqlpInterfaceBase
{
  ItestFieldModParamOutpObject<TMod>? As_FieldModParamOutp { get; }
}

public interface ItestFieldModParamOutpObject<TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, ItestFldFieldModParamOutp> Field { get; }
}

public interface ItestFldFieldModParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldModParamOutpObject? As_FldFieldModParamOutp { get; }
}

public interface ItestFldFieldModParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldObjDual
  : IGqlpInterfaceBase
{
  ItestFieldObjDualObject? As_FieldObjDual { get; }
}

public interface ItestFieldObjDualObject
  : IGqlpInterfaceBase
{
  ItestFldFieldObjDual Field { get; }
}

public interface ItestFldFieldObjDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldObjDualObject? As_FldFieldObjDual { get; }
}

public interface ItestFldFieldObjDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldObjInp
  : IGqlpInterfaceBase
{
  ItestFieldObjInpObject? As_FieldObjInp { get; }
}

public interface ItestFieldObjInpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldObjInp Field { get; }
}

public interface ItestFldFieldObjInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldObjInpObject? As_FldFieldObjInp { get; }
}

public interface ItestFldFieldObjInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldObjOutp
  : IGqlpInterfaceBase
{
  ItestFieldObjOutpObject? As_FieldObjOutp { get; }
}

public interface ItestFieldObjOutpObject
  : IGqlpInterfaceBase
{
  ItestFldFieldObjOutp Field { get; }
}

public interface ItestFldFieldObjOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestFldFieldObjOutpObject? As_FldFieldObjOutp { get; }
}

public interface ItestFldFieldObjOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldSmplDual
  : IGqlpInterfaceBase
{
  ItestFieldSmplDualObject? As_FieldSmplDual { get; }
}

public interface ItestFieldSmplDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldSmplInp
  : IGqlpInterfaceBase
{
  ItestFieldSmplInpObject? As_FieldSmplInp { get; }
}

public interface ItestFieldSmplInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldSmplOutp
  : IGqlpInterfaceBase
{
  ItestFieldSmplOutpObject? As_FieldSmplOutp { get; }
}

public interface ItestFieldSmplOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldTypeDescrDual
  : IGqlpInterfaceBase
{
  ItestFieldTypeDescrDualObject? As_FieldTypeDescrDual { get; }
}

public interface ItestFieldTypeDescrDualObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldTypeDescrInp
  : IGqlpInterfaceBase
{
  ItestFieldTypeDescrInpObject? As_FieldTypeDescrInp { get; }
}

public interface ItestFieldTypeDescrInpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldTypeDescrOutp
  : IGqlpInterfaceBase
{
  ItestFieldTypeDescrOutpObject? As_FieldTypeDescrOutp { get; }
}

public interface ItestFieldTypeDescrOutpObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestFieldValueDual
  : IGqlpInterfaceBase
{
  ItestFieldValueDualObject? As_FieldValueDual { get; }
}

public interface ItestFieldValueDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDual Field { get; }
}

public enum testEnumFieldValueDual
{
  fieldValueDual,
}

public interface ItestFieldValueInp
  : IGqlpInterfaceBase
{
  ItestFieldValueInpObject? As_FieldValueInp { get; }
}

public interface ItestFieldValueInpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueInp Field { get; }
}

public enum testEnumFieldValueInp
{
  fieldValueInp,
}

public interface ItestFieldValueOutp
  : IGqlpInterfaceBase
{
  ItestFieldValueOutpObject? As_FieldValueOutp { get; }
}

public interface ItestFieldValueOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueOutp Field { get; }
}

public enum testEnumFieldValueOutp
{
  fieldValueOutp,
}

public interface ItestFieldValueDescrDual
  : IGqlpInterfaceBase
{
  ItestFieldValueDescrDualObject? As_FieldValueDescrDual { get; }
}

public interface ItestFieldValueDescrDualObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDescrDual Field { get; }
}

public enum testEnumFieldValueDescrDual
{
  fieldValueDescrDual,
}

public interface ItestFieldValueDescrInp
  : IGqlpInterfaceBase
{
  ItestFieldValueDescrInpObject? As_FieldValueDescrInp { get; }
}

public interface ItestFieldValueDescrInpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDescrInp Field { get; }
}

public enum testEnumFieldValueDescrInp
{
  fieldValueDescrInp,
}

public interface ItestFieldValueDescrOutp
  : IGqlpInterfaceBase
{
  ItestFieldValueDescrOutpObject? As_FieldValueDescrOutp { get; }
}

public interface ItestFieldValueDescrOutpObject
  : IGqlpInterfaceBase
{
  testEnumFieldValueDescrOutp Field { get; }
}

public enum testEnumFieldValueDescrOutp
{
  fieldValueDescrOutp,
}

public interface ItestGnrcAltDual<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestGnrcAltDualObject<TType>? As_GnrcAltDual { get; }
}

public interface ItestGnrcAltDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltInp<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestGnrcAltInpObject<TType>? As_GnrcAltInp { get; }
}

public interface ItestGnrcAltInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltOutp<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestGnrcAltOutpObject<TType>? As_GnrcAltOutp { get; }
}

public interface ItestGnrcAltOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltArgDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDual<TType>? AsRefGnrcAltArgDual { get; }
  ItestGnrcAltArgDualObject<TType>? As_GnrcAltArgDual { get; }
}

public interface ItestGnrcAltArgDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDualObject<TRef>? As_RefGnrcAltArgDual { get; }
}

public interface ItestRefGnrcAltArgDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltArgInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgInp<TType>? AsRefGnrcAltArgInp { get; }
  ItestGnrcAltArgInpObject<TType>? As_GnrcAltArgInp { get; }
}

public interface ItestGnrcAltArgInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgInpObject<TRef>? As_RefGnrcAltArgInp { get; }
}

public interface ItestRefGnrcAltArgInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltArgOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgOutp<TType>? AsRefGnrcAltArgOutp { get; }
  ItestGnrcAltArgOutpObject<TType>? As_GnrcAltArgOutp { get; }
}

public interface ItestGnrcAltArgOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgOutpObject<TRef>? As_RefGnrcAltArgOutp { get; }
}

public interface ItestRefGnrcAltArgOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltArgDescrDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDescrDual<TType>? AsRefGnrcAltArgDescrDual { get; }
  ItestGnrcAltArgDescrDualObject<TType>? As_GnrcAltArgDescrDual { get; }
}

public interface ItestGnrcAltArgDescrDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDescrDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrDualObject<TRef>? As_RefGnrcAltArgDescrDual { get; }
}

public interface ItestRefGnrcAltArgDescrDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltArgDescrInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDescrInp<TType>? AsRefGnrcAltArgDescrInp { get; }
  ItestGnrcAltArgDescrInpObject<TType>? As_GnrcAltArgDescrInp { get; }
}

public interface ItestGnrcAltArgDescrInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDescrInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrInpObject<TRef>? As_RefGnrcAltArgDescrInp { get; }
}

public interface ItestRefGnrcAltArgDescrInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltArgDescrOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltArgDescrOutp<TType>? AsRefGnrcAltArgDescrOutp { get; }
  ItestGnrcAltArgDescrOutpObject<TType>? As_GnrcAltArgDescrOutp { get; }
}

public interface ItestGnrcAltArgDescrOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltArgDescrOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltArgDescrOutpObject<TRef>? As_RefGnrcAltArgDescrOutp { get; }
}

public interface ItestRefGnrcAltArgDescrOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltDualDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltDualDual<ItestAltGnrcAltDualDual>? AsRefGnrcAltDualDual { get; }
  ItestGnrcAltDualDualObject? As_GnrcAltDualDual { get; }
}

public interface ItestGnrcAltDualDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualDualObject<TRef>? As_RefGnrcAltDualDual { get; }
}

public interface ItestRefGnrcAltDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualDualObject? As_AltGnrcAltDualDual { get; }
}

public interface ItestAltGnrcAltDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcAltDualInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltDualInp<ItestAltGnrcAltDualInp>? AsRefGnrcAltDualInp { get; }
  ItestGnrcAltDualInpObject? As_GnrcAltDualInp { get; }
}

public interface ItestGnrcAltDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltDualInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualInpObject<TRef>? As_RefGnrcAltDualInp { get; }
}

public interface ItestRefGnrcAltDualInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualInpObject? As_AltGnrcAltDualInp { get; }
}

public interface ItestAltGnrcAltDualInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcAltDualOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltDualOutp<ItestAltGnrcAltDualOutp>? AsRefGnrcAltDualOutp { get; }
  ItestGnrcAltDualOutpObject? As_GnrcAltDualOutp { get; }
}

public interface ItestGnrcAltDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltDualOutpObject<TRef>? As_RefGnrcAltDualOutp { get; }
}

public interface ItestRefGnrcAltDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltDualOutpObject? As_AltGnrcAltDualOutp { get; }
}

public interface ItestAltGnrcAltDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestRefGnrcAltModParamDual<TRef,TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamDualObject<TRef,TMod>? As_RefGnrcAltModParamDual { get; }
}

public interface ItestRefGnrcAltModParamDualObject<TRef,TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltModParamInp<TRef,TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamInpObject<TRef,TMod>? As_RefGnrcAltModParamInp { get; }
}

public interface ItestRefGnrcAltModParamInpObject<TRef,TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltModParamOutp<TRef,TMod>
  : IGqlpInterfaceBase
{
  IDictionary<TMod, TRef>? Asref { get; }
  ItestRefGnrcAltModParamOutpObject<TRef,TMod>? As_RefGnrcAltModParamOutp { get; }
}

public interface ItestRefGnrcAltModParamOutpObject<TRef,TMod>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltModStrDual<TRef>
  : IGqlpInterfaceBase
{
  IDictionary<string, TRef>? Asref { get; }
  ItestRefGnrcAltModStrDualObject<TRef>? As_RefGnrcAltModStrDual { get; }
}

public interface ItestRefGnrcAltModStrDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltModStrInp<TRef>
  : IGqlpInterfaceBase
{
  IDictionary<string, TRef>? Asref { get; }
  ItestRefGnrcAltModStrInpObject<TRef>? As_RefGnrcAltModStrInp { get; }
}

public interface ItestRefGnrcAltModStrInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltModStrOutp<TRef>
  : IGqlpInterfaceBase
{
  IDictionary<string, TRef>? Asref { get; }
  ItestRefGnrcAltModStrOutpObject<TRef>? As_RefGnrcAltModStrOutp { get; }
}

public interface ItestRefGnrcAltModStrOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltParamDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltParamDual<ItestAltGnrcAltParamDual>? AsRefGnrcAltParamDual { get; }
  ItestGnrcAltParamDualObject? As_GnrcAltParamDual { get; }
}

public interface ItestGnrcAltParamDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltParamDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamDualObject<TRef>? As_RefGnrcAltParamDual { get; }
}

public interface ItestRefGnrcAltParamDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamDualObject? As_AltGnrcAltParamDual { get; }
}

public interface ItestAltGnrcAltParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcAltParamInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltParamInp<ItestAltGnrcAltParamInp>? AsRefGnrcAltParamInp { get; }
  ItestGnrcAltParamInpObject? As_GnrcAltParamInp { get; }
}

public interface ItestGnrcAltParamInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltParamInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamInpObject<TRef>? As_RefGnrcAltParamInp { get; }
}

public interface ItestRefGnrcAltParamInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamInpObject? As_AltGnrcAltParamInp { get; }
}

public interface ItestAltGnrcAltParamInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcAltParamOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltParamOutp<ItestAltGnrcAltParamOutp>? AsRefGnrcAltParamOutp { get; }
  ItestGnrcAltParamOutpObject? As_GnrcAltParamOutp { get; }
}

public interface ItestGnrcAltParamOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltParamOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltParamOutpObject<TRef>? As_RefGnrcAltParamOutp { get; }
}

public interface ItestRefGnrcAltParamOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcAltParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcAltParamOutpObject? As_AltGnrcAltParamOutp { get; }
}

public interface ItestAltGnrcAltParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcAltSmplDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltSmplDual<string>? AsRefGnrcAltSmplDual { get; }
  ItestGnrcAltSmplDualObject? As_GnrcAltSmplDual { get; }
}

public interface ItestGnrcAltSmplDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltSmplDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplDualObject<TRef>? As_RefGnrcAltSmplDual { get; }
}

public interface ItestRefGnrcAltSmplDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltSmplInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltSmplInp<string>? AsRefGnrcAltSmplInp { get; }
  ItestGnrcAltSmplInpObject? As_GnrcAltSmplInp { get; }
}

public interface ItestGnrcAltSmplInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltSmplInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplInpObject<TRef>? As_RefGnrcAltSmplInp { get; }
}

public interface ItestRefGnrcAltSmplInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcAltSmplOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcAltSmplOutp<string>? AsRefGnrcAltSmplOutp { get; }
  ItestGnrcAltSmplOutpObject? As_GnrcAltSmplOutp { get; }
}

public interface ItestGnrcAltSmplOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcAltSmplOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcAltSmplOutpObject<TRef>? As_RefGnrcAltSmplOutp { get; }
}

public interface ItestRefGnrcAltSmplOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcDescrDual<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcDescrDualObject<TType>? As_GnrcDescrDual { get; }
}

public interface ItestGnrcDescrDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public interface ItestGnrcDescrInp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcDescrInpObject<TType>? As_GnrcDescrInp { get; }
}

public interface ItestGnrcDescrInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public interface ItestGnrcDescrOutp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcDescrOutpObject<TType>? As_GnrcDescrOutp { get; }
}

public interface ItestGnrcDescrOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public interface ItestGnrcEnumDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumDual<testEnumGnrcEnumDual>? AsEnumGnrcEnumDualgnrcEnumDual { get; }
  ItestGnrcEnumDualObject? As_GnrcEnumDual { get; }
}

public interface ItestGnrcEnumDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcEnumDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumDualObject<TType>? As_RefGnrcEnumDual { get; }
}

public interface ItestRefGnrcEnumDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcEnumDual
{
  gnrcEnumDual,
}

public interface ItestGnrcEnumInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumInp<testEnumGnrcEnumInp>? AsEnumGnrcEnumInpgnrcEnumInp { get; }
  ItestGnrcEnumInpObject? As_GnrcEnumInp { get; }
}

public interface ItestGnrcEnumInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcEnumInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumInpObject<TType>? As_RefGnrcEnumInp { get; }
}

public interface ItestRefGnrcEnumInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcEnumInp
{
  gnrcEnumInp,
}

public interface ItestGnrcEnumOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumOutp<testEnumGnrcEnumOutp>? AsEnumGnrcEnumOutpgnrcEnumOutp { get; }
  ItestGnrcEnumOutpObject? As_GnrcEnumOutp { get; }
}

public interface ItestGnrcEnumOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcEnumOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcEnumOutpObject<TType>? As_RefGnrcEnumOutp { get; }
}

public interface ItestRefGnrcEnumOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcEnumOutp
{
  gnrcEnumOutp,
}

public interface ItestGnrcFieldDual<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualObject<TType>? As_GnrcFieldDual { get; }
}

public interface ItestGnrcFieldDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public interface ItestGnrcFieldInp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldInpObject<TType>? As_GnrcFieldInp { get; }
}

public interface ItestGnrcFieldInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public interface ItestGnrcFieldOutp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldOutpObject<TType>? As_GnrcFieldOutp { get; }
}

public interface ItestGnrcFieldOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public interface ItestGnrcFieldArgDual<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldArgDualObject<TType>? As_GnrcFieldArgDual { get; }
}

public interface ItestGnrcFieldArgDualObject<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldArgDual<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgDualObject<TRef>? As_RefGnrcFieldArgDual { get; }
}

public interface ItestRefGnrcFieldArgDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcFieldArgInp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldArgInpObject<TType>? As_GnrcFieldArgInp { get; }
}

public interface ItestGnrcFieldArgInpObject<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldArgInp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgInpObject<TRef>? As_RefGnrcFieldArgInp { get; }
}

public interface ItestRefGnrcFieldArgInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcFieldArgOutp<TType>
  : IGqlpInterfaceBase
{
  ItestGnrcFieldArgOutpObject<TType>? As_GnrcFieldArgOutp { get; }
}

public interface ItestGnrcFieldArgOutpObject<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldArgOutp<TType> Field { get; }
}

public interface ItestRefGnrcFieldArgOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldArgOutpObject<TRef>? As_RefGnrcFieldArgOutp { get; }
}

public interface ItestRefGnrcFieldArgOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcFieldDualDual
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualDualObject? As_GnrcFieldDualDual { get; }
}

public interface ItestGnrcFieldDualDualObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldDualDual<ItestAltGnrcFieldDualDual> Field { get; }
}

public interface ItestRefGnrcFieldDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualDualObject<TRef>? As_RefGnrcFieldDualDual { get; }
}

public interface ItestRefGnrcFieldDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualDualObject? As_AltGnrcFieldDualDual { get; }
}

public interface ItestAltGnrcFieldDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcFieldDualInp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualInpObject? As_GnrcFieldDualInp { get; }
}

public interface ItestGnrcFieldDualInpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldDualInp<ItestAltGnrcFieldDualInp> Field { get; }
}

public interface ItestRefGnrcFieldDualInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualInpObject<TRef>? As_RefGnrcFieldDualInp { get; }
}

public interface ItestRefGnrcFieldDualInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualInpObject? As_AltGnrcFieldDualInp { get; }
}

public interface ItestAltGnrcFieldDualInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcFieldDualOutp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldDualOutpObject? As_GnrcFieldDualOutp { get; }
}

public interface ItestGnrcFieldDualOutpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldDualOutp<ItestAltGnrcFieldDualOutp> Field { get; }
}

public interface ItestRefGnrcFieldDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldDualOutpObject<TRef>? As_RefGnrcFieldDualOutp { get; }
}

public interface ItestRefGnrcFieldDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldDualOutpObject? As_AltGnrcFieldDualOutp { get; }
}

public interface ItestAltGnrcFieldDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcFieldParamDual
  : IGqlpInterfaceBase
{
  ItestGnrcFieldParamDualObject? As_GnrcFieldParamDual { get; }
}

public interface ItestGnrcFieldParamDualObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldParamDual<ItestAltGnrcFieldParamDual> Field { get; }
}

public interface ItestRefGnrcFieldParamDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamDualObject<TRef>? As_RefGnrcFieldParamDual { get; }
}

public interface ItestRefGnrcFieldParamDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamDualObject? As_AltGnrcFieldParamDual { get; }
}

public interface ItestAltGnrcFieldParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcFieldParamInp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldParamInpObject? As_GnrcFieldParamInp { get; }
}

public interface ItestGnrcFieldParamInpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldParamInp<ItestAltGnrcFieldParamInp> Field { get; }
}

public interface ItestRefGnrcFieldParamInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamInpObject<TRef>? As_RefGnrcFieldParamInp { get; }
}

public interface ItestRefGnrcFieldParamInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamInpObject? As_AltGnrcFieldParamInp { get; }
}

public interface ItestAltGnrcFieldParamInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcFieldParamOutp
  : IGqlpInterfaceBase
{
  ItestGnrcFieldParamOutpObject? As_GnrcFieldParamOutp { get; }
}

public interface ItestGnrcFieldParamOutpObject
  : IGqlpInterfaceBase
{
  ItestRefGnrcFieldParamOutp<ItestAltGnrcFieldParamOutp> Field { get; }
}

public interface ItestRefGnrcFieldParamOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcFieldParamOutpObject<TRef>? As_RefGnrcFieldParamOutp { get; }
}

public interface ItestRefGnrcFieldParamOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcFieldParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcFieldParamOutpObject? As_AltGnrcFieldParamOutp { get; }
}

public interface ItestAltGnrcFieldParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntDual<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDualObject<TType>? As_GnrcPrntDual { get; }
}

public interface ItestGnrcPrntDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntInp<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntInpObject<TType>? As_GnrcPrntInp { get; }
}

public interface ItestGnrcPrntInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntOutp<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntOutpObject<TType>? As_GnrcPrntOutp { get; }
}

public interface ItestGnrcPrntOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntArgDual<TType>
  : ItestRefGnrcPrntArgDual<TType>
{
  ItestGnrcPrntArgDualObject<TType>? As_GnrcPrntArgDual { get; }
}

public interface ItestGnrcPrntArgDualObject<TType>
  : ItestRefGnrcPrntArgDualObject<TType>
{
}

public interface ItestRefGnrcPrntArgDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntArgDualObject<TRef>? As_RefGnrcPrntArgDual { get; }
}

public interface ItestRefGnrcPrntArgDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntArgInp<TType>
  : ItestRefGnrcPrntArgInp<TType>
{
  ItestGnrcPrntArgInpObject<TType>? As_GnrcPrntArgInp { get; }
}

public interface ItestGnrcPrntArgInpObject<TType>
  : ItestRefGnrcPrntArgInpObject<TType>
{
}

public interface ItestRefGnrcPrntArgInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntArgInpObject<TRef>? As_RefGnrcPrntArgInp { get; }
}

public interface ItestRefGnrcPrntArgInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntArgOutp<TType>
  : ItestRefGnrcPrntArgOutp<TType>
{
  ItestGnrcPrntArgOutpObject<TType>? As_GnrcPrntArgOutp { get; }
}

public interface ItestGnrcPrntArgOutpObject<TType>
  : ItestRefGnrcPrntArgOutpObject<TType>
{
}

public interface ItestRefGnrcPrntArgOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntArgOutpObject<TRef>? As_RefGnrcPrntArgOutp { get; }
}

public interface ItestRefGnrcPrntArgOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntDescrDual<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrDualObject<TType>? As_GnrcPrntDescrDual { get; }
}

public interface ItestGnrcPrntDescrDualObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntDescrInp<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrInpObject<TType>? As_GnrcPrntDescrInp { get; }
}

public interface ItestGnrcPrntDescrInpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntDescrOutp<TType>
  : IGqlpInterfaceBase
{
  TType? As_Parent { get; }
  ItestGnrcPrntDescrOutpObject<TType>? As_GnrcPrntDescrOutp { get; }
}

public interface ItestGnrcPrntDescrOutpObject<TType>
  : IGqlpInterfaceBase
{
}

public interface ItestGnrcPrntDualDual
  : ItestRefGnrcPrntDualDual<ItestAltGnrcPrntDualDual>
{
  ItestGnrcPrntDualDualObject? As_GnrcPrntDualDual { get; }
}

public interface ItestGnrcPrntDualDualObject
  : ItestRefGnrcPrntDualDualObject<ItestAltGnrcPrntDualDual>
{
}

public interface ItestRefGnrcPrntDualDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualDualObject<TRef>? As_RefGnrcPrntDualDual { get; }
}

public interface ItestRefGnrcPrntDualDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualDualObject? As_AltGnrcPrntDualDual { get; }
}

public interface ItestAltGnrcPrntDualDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntDualInp
  : ItestRefGnrcPrntDualInp<ItestAltGnrcPrntDualInp>
{
  ItestGnrcPrntDualInpObject? As_GnrcPrntDualInp { get; }
}

public interface ItestGnrcPrntDualInpObject
  : ItestRefGnrcPrntDualInpObject<ItestAltGnrcPrntDualInp>
{
}

public interface ItestRefGnrcPrntDualInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualInpObject<TRef>? As_RefGnrcPrntDualInp { get; }
}

public interface ItestRefGnrcPrntDualInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualInpObject? As_AltGnrcPrntDualInp { get; }
}

public interface ItestAltGnrcPrntDualInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntDualOutp
  : ItestRefGnrcPrntDualOutp<ItestAltGnrcPrntDualOutp>
{
  ItestGnrcPrntDualOutpObject? As_GnrcPrntDualOutp { get; }
}

public interface ItestGnrcPrntDualOutpObject
  : ItestRefGnrcPrntDualOutpObject<ItestAltGnrcPrntDualOutp>
{
}

public interface ItestRefGnrcPrntDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntDualOutpObject<TRef>? As_RefGnrcPrntDualOutp { get; }
}

public interface ItestRefGnrcPrntDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualOutpObject? As_AltGnrcPrntDualOutp { get; }
}

public interface ItestAltGnrcPrntDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntDualPrntDual
  : ItestRefGnrcPrntDualPrntDual<ItestAltGnrcPrntDualPrntDual>
{
  ItestGnrcPrntDualPrntDualObject? As_GnrcPrntDualPrntDual { get; }
}

public interface ItestGnrcPrntDualPrntDualObject
  : ItestRefGnrcPrntDualPrntDualObject<ItestAltGnrcPrntDualPrntDual>
{
}

public interface ItestRefGnrcPrntDualPrntDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntDualObject<TRef>? As_RefGnrcPrntDualPrntDual { get; }
}

public interface ItestRefGnrcPrntDualPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualPrntDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntDualObject? As_AltGnrcPrntDualPrntDual { get; }
}

public interface ItestAltGnrcPrntDualPrntDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntDualPrntInp
  : ItestRefGnrcPrntDualPrntInp<ItestAltGnrcPrntDualPrntInp>
{
  ItestGnrcPrntDualPrntInpObject? As_GnrcPrntDualPrntInp { get; }
}

public interface ItestGnrcPrntDualPrntInpObject
  : ItestRefGnrcPrntDualPrntInpObject<ItestAltGnrcPrntDualPrntInp>
{
}

public interface ItestRefGnrcPrntDualPrntInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntInpObject<TRef>? As_RefGnrcPrntDualPrntInp { get; }
}

public interface ItestRefGnrcPrntDualPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualPrntInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntInpObject? As_AltGnrcPrntDualPrntInp { get; }
}

public interface ItestAltGnrcPrntDualPrntInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntDualPrntOutp
  : ItestRefGnrcPrntDualPrntOutp<ItestAltGnrcPrntDualPrntOutp>
{
  ItestGnrcPrntDualPrntOutpObject? As_GnrcPrntDualPrntOutp { get; }
}

public interface ItestGnrcPrntDualPrntOutpObject
  : ItestRefGnrcPrntDualPrntOutpObject<ItestAltGnrcPrntDualPrntOutp>
{
}

public interface ItestRefGnrcPrntDualPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntDualPrntOutpObject<TRef>? As_RefGnrcPrntDualPrntOutp { get; }
}

public interface ItestRefGnrcPrntDualPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntDualPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntDualPrntOutpObject? As_AltGnrcPrntDualPrntOutp { get; }
}

public interface ItestAltGnrcPrntDualPrntOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntEnumChildDual
  : ItestFieldGnrcPrntEnumChildDual<testParentGnrcPrntEnumChildDual>
{
  ItestGnrcPrntEnumChildDualObject? As_GnrcPrntEnumChildDual { get; }
}

public interface ItestGnrcPrntEnumChildDualObject
  : ItestFieldGnrcPrntEnumChildDualObject<testParentGnrcPrntEnumChildDual>
{
}

public interface ItestFieldGnrcPrntEnumChildDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumChildDualObject<TRef>? As_FieldGnrcPrntEnumChildDual { get; }
}

public interface ItestFieldGnrcPrntEnumChildDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent = testParentGnrcPrntEnumChildDual.gnrcPrntEnumChildDualParent,
  gnrcPrntEnumChildDualLabel,
}

public enum testParentGnrcPrntEnumChildDual
{
  gnrcPrntEnumChildDualParent,
}

public interface ItestGnrcPrntEnumChildInp
  : ItestFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
{
  ItestGnrcPrntEnumChildInpObject? As_GnrcPrntEnumChildInp { get; }
}

public interface ItestGnrcPrntEnumChildInpObject
  : ItestFieldGnrcPrntEnumChildInpObject<testParentGnrcPrntEnumChildInp>
{
}

public interface ItestFieldGnrcPrntEnumChildInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumChildInpObject<TRef>? As_FieldGnrcPrntEnumChildInp { get; }
}

public interface ItestFieldGnrcPrntEnumChildInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent = testParentGnrcPrntEnumChildInp.gnrcPrntEnumChildInpParent,
  gnrcPrntEnumChildInpLabel,
}

public enum testParentGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent,
}

public interface ItestGnrcPrntEnumChildOutp
  : ItestFieldGnrcPrntEnumChildOutp<testParentGnrcPrntEnumChildOutp>
{
  ItestGnrcPrntEnumChildOutpObject? As_GnrcPrntEnumChildOutp { get; }
}

public interface ItestGnrcPrntEnumChildOutpObject
  : ItestFieldGnrcPrntEnumChildOutpObject<testParentGnrcPrntEnumChildOutp>
{
}

public interface ItestFieldGnrcPrntEnumChildOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumChildOutpObject<TRef>? As_FieldGnrcPrntEnumChildOutp { get; }
}

public interface ItestFieldGnrcPrntEnumChildOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent = testParentGnrcPrntEnumChildOutp.gnrcPrntEnumChildOutpParent,
  gnrcPrntEnumChildOutpLabel,
}

public enum testParentGnrcPrntEnumChildOutp
{
  gnrcPrntEnumChildOutpParent,
}

public interface ItestGnrcPrntEnumDomDual
  : ItestFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
{
  ItestGnrcPrntEnumDomDualObject? As_GnrcPrntEnumDomDual { get; }
}

public interface ItestGnrcPrntEnumDomDualObject
  : ItestFieldGnrcPrntEnumDomDualObject<ItestDomGnrcPrntEnumDomDual>
{
}

public interface ItestFieldGnrcPrntEnumDomDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumDomDualObject<TRef>? As_FieldGnrcPrntEnumDomDual { get; }
}

public interface ItestFieldGnrcPrntEnumDomDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumDomDual
{
  gnrcPrntEnumDomDualLabel,
  gnrcPrntEnumDomDualOther,
}

public interface ItestDomGnrcPrntEnumDomDual
  : IGqlpDomainEnum
{
}

public interface ItestGnrcPrntEnumDomInp
  : ItestFieldGnrcPrntEnumDomInp<ItestDomGnrcPrntEnumDomInp>
{
  ItestGnrcPrntEnumDomInpObject? As_GnrcPrntEnumDomInp { get; }
}

public interface ItestGnrcPrntEnumDomInpObject
  : ItestFieldGnrcPrntEnumDomInpObject<ItestDomGnrcPrntEnumDomInp>
{
}

public interface ItestFieldGnrcPrntEnumDomInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumDomInpObject<TRef>? As_FieldGnrcPrntEnumDomInp { get; }
}

public interface ItestFieldGnrcPrntEnumDomInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumDomInp
{
  gnrcPrntEnumDomInpLabel,
  gnrcPrntEnumDomInpOther,
}

public interface ItestDomGnrcPrntEnumDomInp
  : IGqlpDomainEnum
{
}

public interface ItestGnrcPrntEnumDomOutp
  : ItestFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
{
  ItestGnrcPrntEnumDomOutpObject? As_GnrcPrntEnumDomOutp { get; }
}

public interface ItestGnrcPrntEnumDomOutpObject
  : ItestFieldGnrcPrntEnumDomOutpObject<ItestDomGnrcPrntEnumDomOutp>
{
}

public interface ItestFieldGnrcPrntEnumDomOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumDomOutpObject<TRef>? As_FieldGnrcPrntEnumDomOutp { get; }
}

public interface ItestFieldGnrcPrntEnumDomOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumDomOutp
{
  gnrcPrntEnumDomOutpLabel,
  gnrcPrntEnumDomOutpOther,
}

public interface ItestDomGnrcPrntEnumDomOutp
  : IGqlpDomainEnum
{
}

public interface ItestGnrcPrntEnumPrntDual
  : ItestFieldGnrcPrntEnumPrntDual<testEnumGnrcPrntEnumPrntDual>
{
  ItestGnrcPrntEnumPrntDualObject? As_GnrcPrntEnumPrntDual { get; }
}

public interface ItestGnrcPrntEnumPrntDualObject
  : ItestFieldGnrcPrntEnumPrntDualObject<testEnumGnrcPrntEnumPrntDual>
{
}

public interface ItestFieldGnrcPrntEnumPrntDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumPrntDualObject<TRef>? As_FieldGnrcPrntEnumPrntDual { get; }
}

public interface ItestFieldGnrcPrntEnumPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent = testParentGnrcPrntEnumPrntDual.gnrcPrntEnumPrntDualParent,
  gnrcPrntEnumPrntDualLabel,
}

public enum testParentGnrcPrntEnumPrntDual
{
  gnrcPrntEnumPrntDualParent,
}

public interface ItestGnrcPrntEnumPrntInp
  : ItestFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
{
  ItestGnrcPrntEnumPrntInpObject? As_GnrcPrntEnumPrntInp { get; }
}

public interface ItestGnrcPrntEnumPrntInpObject
  : ItestFieldGnrcPrntEnumPrntInpObject<testEnumGnrcPrntEnumPrntInp>
{
}

public interface ItestFieldGnrcPrntEnumPrntInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumPrntInpObject<TRef>? As_FieldGnrcPrntEnumPrntInp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent = testParentGnrcPrntEnumPrntInp.gnrcPrntEnumPrntInpParent,
  gnrcPrntEnumPrntInpLabel,
}

public enum testParentGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent,
}

public interface ItestGnrcPrntEnumPrntOutp
  : ItestFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
{
  ItestGnrcPrntEnumPrntOutpObject? As_GnrcPrntEnumPrntOutp { get; }
}

public interface ItestGnrcPrntEnumPrntOutpObject
  : ItestFieldGnrcPrntEnumPrntOutpObject<testEnumGnrcPrntEnumPrntOutp>
{
}

public interface ItestFieldGnrcPrntEnumPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntEnumPrntOutpObject<TRef>? As_FieldGnrcPrntEnumPrntOutp { get; }
}

public interface ItestFieldGnrcPrntEnumPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntEnumPrntOutp
{
  gnrcPrntEnumPrntOutpParent = testParentGnrcPrntEnumPrntOutp.gnrcPrntEnumPrntOutpParent,
  gnrcPrntEnumPrntOutpLabel,
}

public enum testParentGnrcPrntEnumPrntOutp
{
  gnrcPrntEnumPrntOutpParent,
}

public interface ItestGnrcPrntParamDual
  : ItestRefGnrcPrntParamDual<ItestAltGnrcPrntParamDual>
{
  ItestGnrcPrntParamDualObject? As_GnrcPrntParamDual { get; }
}

public interface ItestGnrcPrntParamDualObject
  : ItestRefGnrcPrntParamDualObject<ItestAltGnrcPrntParamDual>
{
}

public interface ItestRefGnrcPrntParamDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamDualObject<TRef>? As_RefGnrcPrntParamDual { get; }
}

public interface ItestRefGnrcPrntParamDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamDualObject? As_AltGnrcPrntParamDual { get; }
}

public interface ItestAltGnrcPrntParamDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntParamInp
  : ItestRefGnrcPrntParamInp<ItestAltGnrcPrntParamInp>
{
  ItestGnrcPrntParamInpObject? As_GnrcPrntParamInp { get; }
}

public interface ItestGnrcPrntParamInpObject
  : ItestRefGnrcPrntParamInpObject<ItestAltGnrcPrntParamInp>
{
}

public interface ItestRefGnrcPrntParamInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamInpObject<TRef>? As_RefGnrcPrntParamInp { get; }
}

public interface ItestRefGnrcPrntParamInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamInpObject? As_AltGnrcPrntParamInp { get; }
}

public interface ItestAltGnrcPrntParamInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntParamOutp
  : ItestRefGnrcPrntParamOutp<ItestAltGnrcPrntParamOutp>
{
  ItestGnrcPrntParamOutpObject? As_GnrcPrntParamOutp { get; }
}

public interface ItestGnrcPrntParamOutpObject
  : ItestRefGnrcPrntParamOutpObject<ItestAltGnrcPrntParamOutp>
{
}

public interface ItestRefGnrcPrntParamOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefGnrcPrntParamOutpObject<TRef>? As_RefGnrcPrntParamOutp { get; }
}

public interface ItestRefGnrcPrntParamOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamOutpObject? As_AltGnrcPrntParamOutp { get; }
}

public interface ItestAltGnrcPrntParamOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntParamPrntDual
  : ItestRefGnrcPrntParamPrntDual<ItestAltGnrcPrntParamPrntDual>
{
  ItestGnrcPrntParamPrntDualObject? As_GnrcPrntParamPrntDual { get; }
}

public interface ItestGnrcPrntParamPrntDualObject
  : ItestRefGnrcPrntParamPrntDualObject<ItestAltGnrcPrntParamPrntDual>
{
}

public interface ItestRefGnrcPrntParamPrntDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntDualObject<TRef>? As_RefGnrcPrntParamPrntDual { get; }
}

public interface ItestRefGnrcPrntParamPrntDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamPrntDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntDualObject? As_AltGnrcPrntParamPrntDual { get; }
}

public interface ItestAltGnrcPrntParamPrntDualObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntParamPrntInp
  : ItestRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
{
  ItestGnrcPrntParamPrntInpObject? As_GnrcPrntParamPrntInp { get; }
}

public interface ItestGnrcPrntParamPrntInpObject
  : ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>
{
}

public interface ItestRefGnrcPrntParamPrntInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntInpObject<TRef>? As_RefGnrcPrntParamPrntInp { get; }
}

public interface ItestRefGnrcPrntParamPrntInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamPrntInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntInpObject? As_AltGnrcPrntParamPrntInp { get; }
}

public interface ItestAltGnrcPrntParamPrntInpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntParamPrntOutp
  : ItestRefGnrcPrntParamPrntOutp<ItestAltGnrcPrntParamPrntOutp>
{
  ItestGnrcPrntParamPrntOutpObject? As_GnrcPrntParamPrntOutp { get; }
}

public interface ItestGnrcPrntParamPrntOutpObject
  : ItestRefGnrcPrntParamPrntOutpObject<ItestAltGnrcPrntParamPrntOutp>
{
}

public interface ItestRefGnrcPrntParamPrntOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? As_Parent { get; }
  ItestRefGnrcPrntParamPrntOutpObject<TRef>? As_RefGnrcPrntParamPrntOutp { get; }
}

public interface ItestRefGnrcPrntParamPrntOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestAltGnrcPrntParamPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestAltGnrcPrntParamPrntOutpObject? As_AltGnrcPrntParamPrntOutp { get; }
}

public interface ItestAltGnrcPrntParamPrntOutpObject
  : IGqlpInterfaceBase
{
  decimal Alt { get; }
}

public interface ItestGnrcPrntSmplEnumDual
  : ItestFieldGnrcPrntSmplEnumDual<testEnumGnrcPrntSmplEnumDual>
{
  ItestGnrcPrntSmplEnumDualObject? As_GnrcPrntSmplEnumDual { get; }
}

public interface ItestGnrcPrntSmplEnumDualObject
  : ItestFieldGnrcPrntSmplEnumDualObject<testEnumGnrcPrntSmplEnumDual>
{
}

public interface ItestFieldGnrcPrntSmplEnumDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntSmplEnumDualObject<TRef>? As_FieldGnrcPrntSmplEnumDual { get; }
}

public interface ItestFieldGnrcPrntSmplEnumDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumDual
{
  gnrcPrntSmplEnumDual,
}

public interface ItestGnrcPrntSmplEnumInp
  : ItestFieldGnrcPrntSmplEnumInp<testEnumGnrcPrntSmplEnumInp>
{
  ItestGnrcPrntSmplEnumInpObject? As_GnrcPrntSmplEnumInp { get; }
}

public interface ItestGnrcPrntSmplEnumInpObject
  : ItestFieldGnrcPrntSmplEnumInpObject<testEnumGnrcPrntSmplEnumInp>
{
}

public interface ItestFieldGnrcPrntSmplEnumInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntSmplEnumInpObject<TRef>? As_FieldGnrcPrntSmplEnumInp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumInp
{
  gnrcPrntSmplEnumInp,
}

public interface ItestGnrcPrntSmplEnumOutp
  : ItestFieldGnrcPrntSmplEnumOutp<testEnumGnrcPrntSmplEnumOutp>
{
  ItestGnrcPrntSmplEnumOutpObject? As_GnrcPrntSmplEnumOutp { get; }
}

public interface ItestGnrcPrntSmplEnumOutpObject
  : ItestFieldGnrcPrntSmplEnumOutpObject<testEnumGnrcPrntSmplEnumOutp>
{
}

public interface ItestFieldGnrcPrntSmplEnumOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntSmplEnumOutpObject<TRef>? As_FieldGnrcPrntSmplEnumOutp { get; }
}

public interface ItestFieldGnrcPrntSmplEnumOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public enum testEnumGnrcPrntSmplEnumOutp
{
  gnrcPrntSmplEnumOutp,
}

public interface ItestGnrcPrntStrDomDual
  : ItestFieldGnrcPrntStrDomDual<ItestDomGnrcPrntStrDomDual>
{
  ItestGnrcPrntStrDomDualObject? As_GnrcPrntStrDomDual { get; }
}

public interface ItestGnrcPrntStrDomDualObject
  : ItestFieldGnrcPrntStrDomDualObject<ItestDomGnrcPrntStrDomDual>
{
}

public interface ItestFieldGnrcPrntStrDomDual<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntStrDomDualObject<TRef>? As_FieldGnrcPrntStrDomDual { get; }
}

public interface ItestFieldGnrcPrntStrDomDualObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomDual
  : IGqlpDomainString
{
}

public interface ItestGnrcPrntStrDomInp
  : ItestFieldGnrcPrntStrDomInp<ItestDomGnrcPrntStrDomInp>
{
  ItestGnrcPrntStrDomInpObject? As_GnrcPrntStrDomInp { get; }
}

public interface ItestGnrcPrntStrDomInpObject
  : ItestFieldGnrcPrntStrDomInpObject<ItestDomGnrcPrntStrDomInp>
{
}

public interface ItestFieldGnrcPrntStrDomInp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntStrDomInpObject<TRef>? As_FieldGnrcPrntStrDomInp { get; }
}

public interface ItestFieldGnrcPrntStrDomInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomInp
  : IGqlpDomainString
{
}

public interface ItestGnrcPrntStrDomOutp
  : ItestFieldGnrcPrntStrDomOutp<ItestDomGnrcPrntStrDomOutp>
{
  ItestGnrcPrntStrDomOutpObject? As_GnrcPrntStrDomOutp { get; }
}

public interface ItestGnrcPrntStrDomOutpObject
  : ItestFieldGnrcPrntStrDomOutpObject<ItestDomGnrcPrntStrDomOutp>
{
}

public interface ItestFieldGnrcPrntStrDomOutp<TRef>
  : IGqlpInterfaceBase
{
  ItestFieldGnrcPrntStrDomOutpObject<TRef>? As_FieldGnrcPrntStrDomOutp { get; }
}

public interface ItestFieldGnrcPrntStrDomOutpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestDomGnrcPrntStrDomOutp
  : IGqlpDomainString
{
}

public interface ItestGnrcValueDual
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueDual<testEnumGnrcValueDual>? AsEnumGnrcValueDualgnrcValueDual { get; }
  ItestGnrcValueDualObject? As_GnrcValueDual { get; }
}

public interface ItestGnrcValueDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcValueDual<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueDualObject<TType>? As_RefGnrcValueDual { get; }
}

public interface ItestRefGnrcValueDualObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueDual
{
  gnrcValueDual,
}

public interface ItestGnrcValueInp
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueInp<testEnumGnrcValueInp>? AsEnumGnrcValueInpgnrcValueInp { get; }
  ItestGnrcValueInpObject? As_GnrcValueInp { get; }
}

public interface ItestGnrcValueInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcValueInp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueInpObject<TType>? As_RefGnrcValueInp { get; }
}

public interface ItestRefGnrcValueInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueInp
{
  gnrcValueInp,
}

public interface ItestGnrcValueOutp
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueOutp<testEnumGnrcValueOutp>? AsEnumGnrcValueOutpgnrcValueOutp { get; }
  ItestGnrcValueOutpObject? As_GnrcValueOutp { get; }
}

public interface ItestGnrcValueOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefGnrcValueOutp<TType>
  : IGqlpInterfaceBase
{
  ItestRefGnrcValueOutpObject<TType>? As_RefGnrcValueOutp { get; }
}

public interface ItestRefGnrcValueOutpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumGnrcValueOutp
{
  gnrcValueOutp,
}

public interface ItestInpFieldDescrNmbr
  : IGqlpInterfaceBase
{
  ItestInpFieldDescrNmbrObject? As_InpFieldDescrNmbr { get; }
}

public interface ItestInpFieldDescrNmbrObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestInpFieldEnum
  : IGqlpInterfaceBase
{
  ItestInpFieldEnumObject? As_InpFieldEnum { get; }
}

public interface ItestInpFieldEnumObject
  : IGqlpInterfaceBase
{
  testEnumInpFieldEnum Field { get; }
}

public enum testEnumInpFieldEnum
{
  inpFieldEnum,
}

public interface ItestInpFieldNull
  : IGqlpInterfaceBase
{
  ItestInpFieldNullObject? As_InpFieldNull { get; }
}

public interface ItestInpFieldNullObject
  : IGqlpInterfaceBase
{
  ItestFldInpFieldNull? Field { get; }
}

public interface ItestFldInpFieldNull
  : IGqlpInterfaceBase
{
  ItestFldInpFieldNullObject? As_FldInpFieldNull { get; }
}

public interface ItestFldInpFieldNullObject
  : IGqlpInterfaceBase
{
}

public interface ItestInpFieldNmbr
  : IGqlpInterfaceBase
{
  ItestInpFieldNmbrObject? As_InpFieldNmbr { get; }
}

public interface ItestInpFieldNmbrObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestInpFieldNmbrDescr
  : IGqlpInterfaceBase
{
  ItestInpFieldNmbrDescrObject? As_InpFieldNmbrDescr { get; }
}

public interface ItestInpFieldNmbrDescrObject
  : IGqlpInterfaceBase
{
  decimal Field { get; }
}

public interface ItestInpFieldStr
  : IGqlpInterfaceBase
{
  ItestInpFieldStrObject? As_InpFieldStr { get; }
}

public interface ItestInpFieldStrObject
  : IGqlpInterfaceBase
{
  string Field { get; }
}

public interface ItestOutpDescrParam
  : IGqlpInterfaceBase
{
  ItestOutpDescrParamObject? As_OutpDescrParam { get; }
}

public interface ItestOutpDescrParamObject
  : IGqlpInterfaceBase
{
  ItestFldOutpDescrParam? Field(ItestInOutpDescrParam parameter);
  ItestFldOutpDescrParam? Field();
}

public interface ItestFldOutpDescrParam
  : IGqlpInterfaceBase
{
  ItestFldOutpDescrParamObject? As_FldOutpDescrParam { get; }
}

public interface ItestFldOutpDescrParamObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpDescrParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpDescrParamObject? As_InOutpDescrParam { get; }
}

public interface ItestInOutpDescrParamObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestOutpParam
  : IGqlpInterfaceBase
{
  ItestOutpParamObject? As_OutpParam { get; }
}

public interface ItestOutpParamObject
  : IGqlpInterfaceBase
{
  ItestFldOutpParam? Field(ItestInOutpParam parameter);
  ItestFldOutpParam? Field();
}

public interface ItestFldOutpParam
  : IGqlpInterfaceBase
{
  ItestFldOutpParamObject? As_FldOutpParam { get; }
}

public interface ItestFldOutpParamObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamObject? As_InOutpParam { get; }
}

public interface ItestInOutpParamObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestOutpParamDescr
  : IGqlpInterfaceBase
{
  ItestOutpParamDescrObject? As_OutpParamDescr { get; }
}

public interface ItestOutpParamDescrObject
  : IGqlpInterfaceBase
{
  ItestFldOutpParamDescr? Field(ItestInOutpParamDescr parameter);
  ItestFldOutpParamDescr? Field();
}

public interface ItestFldOutpParamDescr
  : IGqlpInterfaceBase
{
  ItestFldOutpParamDescrObject? As_FldOutpParamDescr { get; }
}

public interface ItestFldOutpParamDescrObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpParamDescr
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamDescrObject? As_InOutpParamDescr { get; }
}

public interface ItestInOutpParamDescrObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestOutpParamModDmn
  : IGqlpInterfaceBase
{
  ItestOutpParamModDmnObject? As_OutpParamModDmn { get; }
}

public interface ItestOutpParamModDmnObject
  : IGqlpInterfaceBase
{
  ItestDomOutpParamModDmn? Field(IDictionary<ItestDomOutpParamModDmn, ItestInOutpParamModDmn> parameter);
  ItestDomOutpParamModDmn? Field();
}

public interface ItestInOutpParamModDmn
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamModDmnObject? As_InOutpParamModDmn { get; }
}

public interface ItestInOutpParamModDmnObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModDmn
  : IGqlpDomainNumber
{
}

public interface ItestOutpParamModParam<TMod>
  : IGqlpInterfaceBase
{
  ItestOutpParamModParamObject<TMod>? As_OutpParamModParam { get; }
}

public interface ItestOutpParamModParamObject<TMod>
  : IGqlpInterfaceBase
{
  ItestDomOutpParamModParam? Field(IDictionary<TMod, ItestInOutpParamModParam> parameter);
  ItestDomOutpParamModParam? Field();
}

public interface ItestInOutpParamModParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamModParamObject? As_InOutpParamModParam { get; }
}

public interface ItestInOutpParamModParamObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestDomOutpParamModParam
  : IGqlpDomainNumber
{
}

public interface ItestOutpParamTypeDescr
  : IGqlpInterfaceBase
{
  ItestOutpParamTypeDescrObject? As_OutpParamTypeDescr { get; }
}

public interface ItestOutpParamTypeDescrObject
  : IGqlpInterfaceBase
{
  ItestFldOutpParamTypeDescr? Field(ItestInOutpParamTypeDescr parameter);
  ItestFldOutpParamTypeDescr? Field();
}

public interface ItestFldOutpParamTypeDescr
  : IGqlpInterfaceBase
{
  ItestFldOutpParamTypeDescrObject? As_FldOutpParamTypeDescr { get; }
}

public interface ItestFldOutpParamTypeDescrObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpParamTypeDescr
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpParamTypeDescrObject? As_InOutpParamTypeDescr { get; }
}

public interface ItestInOutpParamTypeDescrObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestOutpPrntGnrc
  : IGqlpInterfaceBase
{
  ItestRefOutpPrntGnrc<testEnumOutpPrntGnrc>? AsEnumOutpPrntGnrcprnt_outpPrntGnrc { get; }
  ItestOutpPrntGnrcObject? As_OutpPrntGnrc { get; }
}

public interface ItestOutpPrntGnrcObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefOutpPrntGnrc<TType>
  : IGqlpInterfaceBase
{
  ItestRefOutpPrntGnrcObject<TType>? As_RefOutpPrntGnrc { get; }
}

public interface ItestRefOutpPrntGnrcObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
}

public enum testEnumOutpPrntGnrc
{
  prnt_outpPrntGnrc = testPrntOutpPrntGnrc.prnt_outpPrntGnrc,
  outpPrntGnrc,
}

public enum testPrntOutpPrntGnrc
{
  prnt_outpPrntGnrc,
}

public interface ItestOutpPrntParam
  : ItestPrntOutpPrntParam
{
  ItestOutpPrntParamObject? As_OutpPrntParam { get; }
}

public interface ItestOutpPrntParamObject
  : ItestPrntOutpPrntParamObject
{
  ItestFldOutpPrntParam? Field(ItestInOutpPrntParam parameter);
  ItestFldOutpPrntParam? Field();
}

public interface ItestPrntOutpPrntParam
  : IGqlpInterfaceBase
{
  ItestPrntOutpPrntParamObject? As_PrntOutpPrntParam { get; }
}

public interface ItestPrntOutpPrntParamObject
  : IGqlpInterfaceBase
{
  ItestFldOutpPrntParam? Field(ItestPrntOutpPrntParamIn parameter);
  ItestFldOutpPrntParam? Field();
}

public interface ItestFldOutpPrntParam
  : IGqlpInterfaceBase
{
  ItestFldOutpPrntParamObject? As_FldOutpPrntParam { get; }
}

public interface ItestFldOutpPrntParamObject
  : IGqlpInterfaceBase
{
}

public interface ItestInOutpPrntParam
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestInOutpPrntParamObject? As_InOutpPrntParam { get; }
}

public interface ItestInOutpPrntParamObject
  : IGqlpInterfaceBase
{
  decimal Param { get; }
}

public interface ItestPrntOutpPrntParamIn
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntOutpPrntParamInObject? As_PrntOutpPrntParamIn { get; }
}

public interface ItestPrntOutpPrntParamInObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntDual
  : ItestRefPrntDual
{
  ItestPrntDualObject? As_PrntDual { get; }
}

public interface ItestPrntDualObject
  : ItestRefPrntDualObject
{
}

public interface ItestRefPrntDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDualObject? As_RefPrntDual { get; }
}

public interface ItestRefPrntDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntInp
  : ItestRefPrntInp
{
  ItestPrntInpObject? As_PrntInp { get; }
}

public interface ItestPrntInpObject
  : ItestRefPrntInpObject
{
}

public interface ItestRefPrntInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntInpObject? As_RefPrntInp { get; }
}

public interface ItestRefPrntInpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntOutp
  : ItestRefPrntOutp
{
  ItestPrntOutpObject? As_PrntOutp { get; }
}

public interface ItestPrntOutpObject
  : ItestRefPrntOutpObject
{
}

public interface ItestRefPrntOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntOutpObject? As_RefPrntOutp { get; }
}

public interface ItestRefPrntOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntAltDual
  : ItestRefPrntAltDual
{
  decimal? AsNumber { get; }
  ItestPrntAltDualObject? As_PrntAltDual { get; }
}

public interface ItestPrntAltDualObject
  : ItestRefPrntAltDualObject
{
}

public interface ItestRefPrntAltDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntAltDualObject? As_RefPrntAltDual { get; }
}

public interface ItestRefPrntAltDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntAltInp
  : ItestRefPrntAltInp
{
  decimal? AsNumber { get; }
  ItestPrntAltInpObject? As_PrntAltInp { get; }
}

public interface ItestPrntAltInpObject
  : ItestRefPrntAltInpObject
{
}

public interface ItestRefPrntAltInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntAltInpObject? As_RefPrntAltInp { get; }
}

public interface ItestRefPrntAltInpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntAltOutp
  : ItestRefPrntAltOutp
{
  decimal? AsNumber { get; }
  ItestPrntAltOutpObject? As_PrntAltOutp { get; }
}

public interface ItestPrntAltOutpObject
  : ItestRefPrntAltOutpObject
{
}

public interface ItestRefPrntAltOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntAltOutpObject? As_RefPrntAltOutp { get; }
}

public interface ItestRefPrntAltOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntDescrDual
  : ItestRefPrntDescrDual
{
  ItestPrntDescrDualObject? As_PrntDescrDual { get; }
}

public interface ItestPrntDescrDualObject
  : ItestRefPrntDescrDualObject
{
}

public interface ItestRefPrntDescrDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDescrDualObject? As_RefPrntDescrDual { get; }
}

public interface ItestRefPrntDescrDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntDescrInp
  : ItestRefPrntDescrInp
{
  ItestPrntDescrInpObject? As_PrntDescrInp { get; }
}

public interface ItestPrntDescrInpObject
  : ItestRefPrntDescrInpObject
{
}

public interface ItestRefPrntDescrInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDescrInpObject? As_RefPrntDescrInp { get; }
}

public interface ItestRefPrntDescrInpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntDescrOutp
  : ItestRefPrntDescrOutp
{
  ItestPrntDescrOutpObject? As_PrntDescrOutp { get; }
}

public interface ItestPrntDescrOutpObject
  : ItestRefPrntDescrOutpObject
{
}

public interface ItestRefPrntDescrOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDescrOutpObject? As_RefPrntDescrOutp { get; }
}

public interface ItestRefPrntDescrOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntDualDual
  : ItestRefPrntDualDual
{
  ItestPrntDualDualObject? As_PrntDualDual { get; }
}

public interface ItestPrntDualDualObject
  : ItestRefPrntDualDualObject
{
}

public interface ItestRefPrntDualDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDualDualObject? As_RefPrntDualDual { get; }
}

public interface ItestRefPrntDualDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntDualInp
  : ItestRefPrntDualInp
{
  ItestPrntDualInpObject? As_PrntDualInp { get; }
}

public interface ItestPrntDualInpObject
  : ItestRefPrntDualInpObject
{
}

public interface ItestRefPrntDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDualInpObject? As_RefPrntDualInp { get; }
}

public interface ItestRefPrntDualInpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntDualOutp
  : ItestRefPrntDualOutp
{
  ItestPrntDualOutpObject? As_PrntDualOutp { get; }
}

public interface ItestPrntDualOutpObject
  : ItestRefPrntDualOutpObject
{
}

public interface ItestRefPrntDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntDualOutpObject? As_RefPrntDualOutp { get; }
}

public interface ItestRefPrntDualOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntFieldDual
  : ItestRefPrntFieldDual
{
  ItestPrntFieldDualObject? As_PrntFieldDual { get; }
}

public interface ItestPrntFieldDualObject
  : ItestRefPrntFieldDualObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntFieldDualObject? As_RefPrntFieldDual { get; }
}

public interface ItestRefPrntFieldDualObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntFieldInp
  : ItestRefPrntFieldInp
{
  ItestPrntFieldInpObject? As_PrntFieldInp { get; }
}

public interface ItestPrntFieldInpObject
  : ItestRefPrntFieldInpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntFieldInpObject? As_RefPrntFieldInp { get; }
}

public interface ItestRefPrntFieldInpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntFieldOutp
  : ItestRefPrntFieldOutp
{
  ItestPrntFieldOutpObject? As_PrntFieldOutp { get; }
}

public interface ItestPrntFieldOutpObject
  : ItestRefPrntFieldOutpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestRefPrntFieldOutpObject? As_RefPrntFieldOutp { get; }
}

public interface ItestRefPrntFieldOutpObject
  : IGqlpInterfaceBase
{
  decimal Parent { get; }
}

public interface ItestPrntParamDiffDual<TA>
  : ItestRefPrntParamDiffDual<TA>
{
  ItestPrntParamDiffDualObject<TA>? As_PrntParamDiffDual { get; }
}

public interface ItestPrntParamDiffDualObject<TA>
  : ItestRefPrntParamDiffDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffDual<TB>
  : IGqlpInterfaceBase
{
  TB? Asb { get; }
  ItestRefPrntParamDiffDualObject<TB>? As_RefPrntParamDiffDual { get; }
}

public interface ItestRefPrntParamDiffDualObject<TB>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntParamDiffInp<TA>
  : ItestRefPrntParamDiffInp<TA>
{
  ItestPrntParamDiffInpObject<TA>? As_PrntParamDiffInp { get; }
}

public interface ItestPrntParamDiffInpObject<TA>
  : ItestRefPrntParamDiffInpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffInp<TB>
  : IGqlpInterfaceBase
{
  TB? Asb { get; }
  ItestRefPrntParamDiffInpObject<TB>? As_RefPrntParamDiffInp { get; }
}

public interface ItestRefPrntParamDiffInpObject<TB>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntParamDiffOutp<TA>
  : ItestRefPrntParamDiffOutp<TA>
{
  ItestPrntParamDiffOutpObject<TA>? As_PrntParamDiffOutp { get; }
}

public interface ItestPrntParamDiffOutpObject<TA>
  : ItestRefPrntParamDiffOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamDiffOutp<TB>
  : IGqlpInterfaceBase
{
  TB? Asb { get; }
  ItestRefPrntParamDiffOutpObject<TB>? As_RefPrntParamDiffOutp { get; }
}

public interface ItestRefPrntParamDiffOutpObject<TB>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntParamSameDual<TA>
  : ItestRefPrntParamSameDual<TA>
{
  ItestPrntParamSameDualObject<TA>? As_PrntParamSameDual { get; }
}

public interface ItestPrntParamSameDualObject<TA>
  : ItestRefPrntParamSameDualObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameDual<TA>
  : IGqlpInterfaceBase
{
  TA? Asa { get; }
  ItestRefPrntParamSameDualObject<TA>? As_RefPrntParamSameDual { get; }
}

public interface ItestRefPrntParamSameDualObject<TA>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntParamSameInp<TA>
  : ItestRefPrntParamSameInp<TA>
{
  ItestPrntParamSameInpObject<TA>? As_PrntParamSameInp { get; }
}

public interface ItestPrntParamSameInpObject<TA>
  : ItestRefPrntParamSameInpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameInp<TA>
  : IGqlpInterfaceBase
{
  TA? Asa { get; }
  ItestRefPrntParamSameInpObject<TA>? As_RefPrntParamSameInp { get; }
}

public interface ItestRefPrntParamSameInpObject<TA>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntParamSameOutp<TA>
  : ItestRefPrntParamSameOutp<TA>
{
  ItestPrntParamSameOutpObject<TA>? As_PrntParamSameOutp { get; }
}

public interface ItestPrntParamSameOutpObject<TA>
  : ItestRefPrntParamSameOutpObject<TA>
{
  TA Field { get; }
}

public interface ItestRefPrntParamSameOutp<TA>
  : IGqlpInterfaceBase
{
  TA? Asa { get; }
  ItestRefPrntParamSameOutpObject<TA>? As_RefPrntParamSameOutp { get; }
}

public interface ItestRefPrntParamSameOutpObject<TA>
  : IGqlpInterfaceBase
{
}
