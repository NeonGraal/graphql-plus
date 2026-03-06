//HintName: test_parent-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}parent-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

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
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestRefPrntDualInpObject? As_RefPrntDualInp { get; }
}

public interface ItestRefPrntDualInpObject
  : IGqlpModelImplementationBase
{
  decimal Parent { get; }
}
