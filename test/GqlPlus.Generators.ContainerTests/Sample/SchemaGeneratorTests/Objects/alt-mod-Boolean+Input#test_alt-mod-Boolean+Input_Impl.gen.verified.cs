//HintName: test_alt-mod-Boolean+Input_Impl.gen.cs
// Generated from alt-mod-Boolean+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public class testAltModBoolInp
  : ItestAltModBoolInp
{
  public IDictionary<testBoolean, ItestAltAltModBoolInp> AsAltAltModBoolInp { get; set; }
  public ItestAltModBoolInpObject AsAltModBoolInp { get; set; }
}

public class testAltAltModBoolInp
  : ItestAltAltModBoolInp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
  public ItestAltAltModBoolInpObject AsAltAltModBoolInp { get; set; }
}
