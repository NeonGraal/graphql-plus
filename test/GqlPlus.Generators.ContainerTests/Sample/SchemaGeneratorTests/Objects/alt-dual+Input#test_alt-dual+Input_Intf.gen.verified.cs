//HintName: test_alt-dual+Input_Intf.gen.cs
// Generated from alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_dual_Input;

public interface ItestAltDualInp
{
  public ItestObjDualAltDualInp AsObjDualAltDualInp { get; set; }
  public ItestAltDualInpObject AsAltDualInp { get; set; }
}

public interface ItestAltDualInpObject
{
}

public interface ItestObjDualAltDualInp
{
  public ItestString AsString { get; set; }
  public ItestObjDualAltDualInpObject AsObjDualAltDualInp { get; set; }
}

public interface ItestObjDualAltDualInpObject
{
  public ItestNumber Alt { get; set; }
}
