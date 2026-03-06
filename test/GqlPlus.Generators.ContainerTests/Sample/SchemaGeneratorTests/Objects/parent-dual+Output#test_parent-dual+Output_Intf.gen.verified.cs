//HintName: test_parent-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}parent-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
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
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntDualOutpObject? As_RefPrntDualOutp { get; }
}

public interface ItestRefPrntDualOutpObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
