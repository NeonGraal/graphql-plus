//HintName: test_parent-dual+Input_Intf.gen.cs
// Generated from parent-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_dual_Input;

public interface ItestPrntDualInp
  : ItestRefPrntDualInp
{
  ItestPrntDualInpObject AsPrntDualInp { get; }
}

public interface ItestPrntDualInpObject
  : ItestRefPrntDualInpObject
{
}

public interface ItestRefPrntDualInp
{
  string AsString { get; }
  ItestRefPrntDualInpObject AsRefPrntDualInp { get; }
}

public interface ItestRefPrntDualInpObject
{
  decimal Parent { get; }
}
