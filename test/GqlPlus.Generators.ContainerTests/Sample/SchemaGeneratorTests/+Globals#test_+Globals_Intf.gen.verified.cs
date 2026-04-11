//HintName: test_+Globals_Intf.gen.cs
// Generated from {CurrentDirectory}+Globals.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp__Globals;

public interface ItestCtgrDscrs
  : IGqlpInterfaceBase
{
  ItestCtgrDscrsObject? As_CtgrDscrs { get; }
}

public interface ItestCtgrDscrsObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrOutp
  : IGqlpInterfaceBase
{
  ItestCtgrOutpObject? As_CtgrOutp { get; }
}

public interface ItestCtgrOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrOutpDescr
  : IGqlpInterfaceBase
{
  ItestCtgrOutpDescrObject? As_CtgrOutpDescr { get; }
}

public interface ItestCtgrOutpDescrObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrOutpDict
  : IGqlpInterfaceBase
{
  ItestCtgrOutpDictObject? As_CtgrOutpDict { get; }
}

public interface ItestCtgrOutpDictObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrOutpList
  : IGqlpInterfaceBase
{
  ItestCtgrOutpListObject? As_CtgrOutpList { get; }
}

public interface ItestCtgrOutpListObject
  : IGqlpInterfaceBase
{
}

public interface ItestCtgrOutpOptl
  : IGqlpInterfaceBase
{
  ItestCtgrOutpOptlObject? As_CtgrOutpOptl { get; }
}

public interface ItestCtgrOutpOptlObject
  : IGqlpInterfaceBase
{
}

public interface ItestDescr
  : IGqlpInterfaceBase
{
  ItestDescrObject? As_Descr { get; }
}

public interface ItestDescrObject
  : IGqlpInterfaceBase
{
}

public interface ItestDescrBcks
  : IGqlpInterfaceBase
{
  ItestDescrBcksObject? As_DescrBcks { get; }
}

public interface ItestDescrBcksObject
  : IGqlpInterfaceBase
{
}

public interface ItestDescrBtwn
  : IGqlpInterfaceBase
{
  ItestDescrBtwnObject? As_DescrBtwn { get; }
}

public interface ItestDescrBtwnObject
  : IGqlpInterfaceBase
{
}

public interface ItestDescrCmpl
  : IGqlpInterfaceBase
{
  ItestDescrCmplObject? As_DescrCmpl { get; }
}

public interface ItestDescrCmplObject
  : IGqlpInterfaceBase
{
}

public interface ItestDescrDbl
  : IGqlpInterfaceBase
{
  ItestDescrDblObject? As_DescrDbl { get; }
}

public interface ItestDescrDblObject
  : IGqlpInterfaceBase
{
}

public interface ItestDescrSngl
  : IGqlpInterfaceBase
{
  ItestDescrSnglObject? As_DescrSngl { get; }
}

public interface ItestDescrSnglObject
  : IGqlpInterfaceBase
{
}

public interface ItestDscrs
  : IGqlpInterfaceBase
{
  ItestDscrsObject? As_Dscrs { get; }
}

public interface ItestDscrsObject
  : IGqlpInterfaceBase
{
}

public interface ItestInDrctParamDict
  : IGqlpInterfaceBase
{
  ItestInDrctParamDictObject? As_InDrctParamDict { get; }
}

public interface ItestInDrctParamDictObject
  : IGqlpInterfaceBase
{
}

public interface ItestInDrctParamIn
  : IGqlpInterfaceBase
{
  ItestInDrctParamInObject? As_InDrctParamIn { get; }
}

public interface ItestInDrctParamInObject
  : IGqlpInterfaceBase
{
}

public interface ItestInDrctParamList
  : IGqlpInterfaceBase
{
  ItestInDrctParamListObject? As_InDrctParamList { get; }
}

public interface ItestInDrctParamListObject
  : IGqlpInterfaceBase
{
}

public interface ItestInDrctParamOpt
  : IGqlpInterfaceBase
{
  ItestInDrctParamOptObject? As_InDrctParamOpt { get; }
}

public interface ItestInDrctParamOptObject
  : IGqlpInterfaceBase
{
}

public interface ItestCatOprCtgr
  : IGqlpModelImplementationBase
{
  ItestCatOprCtgrObject? As_CatOprCtgr { get; }
}

public interface ItestCatOprCtgrObject
  : IGqlpModelImplementationBase
{
}

public interface ItestCatOprType
  : IGqlpModelImplementationBase
{
  ItestCatOprTypeObject? As_CatOprType { get; }
}

public interface ItestCatOprTypeObject
  : IGqlpModelImplementationBase
{
  string First { get; }
  string Last { get; }
  ItestAddrOprType Address { get; }
}

public interface ItestAddrOprType
  : IGqlpModelImplementationBase
{
  ItestAddrOprTypeObject? As_AddrOprType { get; }
}

public interface ItestAddrOprTypeObject
  : IGqlpModelImplementationBase
{
  string Street { get; }
  string City { get; }
  string Country { get; }
}
