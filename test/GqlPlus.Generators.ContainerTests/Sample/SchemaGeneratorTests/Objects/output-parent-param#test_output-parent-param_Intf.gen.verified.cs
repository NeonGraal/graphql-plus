//HintName: test_output-parent-param_Intf.gen.cs
// Generated from {CurrentDirectory}output-parent-param.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
}

public interface ItestPrntOutpPrntParam
  : IGqlpModelImplementationBase
{
  ItestPrntOutpPrntParamObject? As_PrntOutpPrntParam { get; }
}

public interface ItestPrntOutpPrntParamObject
  : IGqlpModelImplementationBase
{
  ItestFldOutpPrntParam? Field(ItestPrntOutpPrntParamIn parameter);
}

public interface ItestFldOutpPrntParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpPrntParamObject? As_FldOutpPrntParam { get; }
}

public interface ItestFldOutpPrntParamObject
  : IGqlpModelImplementationBase
{
}

public interface ItestInOutpPrntParam
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestInOutpPrntParamObject? As_InOutpPrntParam { get; }
}

public interface ItestInOutpPrntParamObject
  : IGqlpModelImplementationBase
{
  decimal Param { get; }
}

public interface ItestPrntOutpPrntParamIn
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntOutpPrntParamInObject? As_PrntOutpPrntParamIn { get; }
}

public interface ItestPrntOutpPrntParamInObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
