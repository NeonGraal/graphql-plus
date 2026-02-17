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
  ItestOutpPrntParamObject AsOutpPrntParam { get; }
}

public interface ItestOutpPrntParamObject
  : ItestPrntOutpPrntParamObject
{
  ItestFldOutpPrntParam Field (ItestInOutpPrntParam parameter);
}

public interface ItestPrntOutpPrntParam
  : IGqlpModelImplementationBase
{
  ItestPrntOutpPrntParamObject AsPrntOutpPrntParam { get; }
}

public interface ItestPrntOutpPrntParamObject
{
  ItestFldOutpPrntParam Field (ItestPrntOutpPrntParamIn parameter);
}

public interface ItestFldOutpPrntParam
  : IGqlpModelImplementationBase
{
  ItestFldOutpPrntParamObject AsFldOutpPrntParam { get; }
}

public interface ItestFldOutpPrntParamObject
{
}

public interface ItestInOutpPrntParam
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestInOutpPrntParamObject AsInOutpPrntParam { get; }
}

public interface ItestInOutpPrntParamObject
{
  decimal Param { get; }
}

public interface ItestPrntOutpPrntParamIn
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntOutpPrntParamInObject AsPrntOutpPrntParamIn { get; }
}

public interface ItestPrntOutpPrntParamInObject
{
  decimal Parent { get; }
}
