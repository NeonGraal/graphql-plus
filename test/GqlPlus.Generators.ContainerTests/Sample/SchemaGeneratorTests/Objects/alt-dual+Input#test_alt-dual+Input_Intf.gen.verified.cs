//HintName: test_alt-dual+Input_Intf.gen.cs
// Generated from alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public interface ItestAltDualInp
{
  ItestObjDualAltDualInp AsObjDualAltDualInp { get; }
  ItestAltDualInpObject AsAltDualInp { get; }
}

public interface ItestAltDualInpObject
{
}

public interface ItestObjDualAltDualInp
{
  string AsString { get; }
  ItestObjDualAltDualInpObject AsObjDualAltDualInp { get; }
}

public interface ItestObjDualAltDualInpObject
{
  decimal Alt { get; }
}
