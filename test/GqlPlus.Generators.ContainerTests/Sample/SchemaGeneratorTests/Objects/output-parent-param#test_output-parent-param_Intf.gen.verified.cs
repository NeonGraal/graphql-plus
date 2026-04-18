//HintName: test_output-parent-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_output_parent_param;

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
