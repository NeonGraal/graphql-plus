//HintName: test_parent-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Output;

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
