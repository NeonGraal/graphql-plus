//HintName: test_alt-mod-Boolean+Input_Impl.gen.cs
// Generated from alt-mod-Boolean+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public class testAltModBoolInp
  : ItestAltModBoolInp
{
  public IDictionary<testBoolean, testAltAltModBoolInp> AsAltAltModBoolInp { get; set; }
  public testAltModBoolInp AltModBoolInp { get; set; }
}

public class testAltAltModBoolInp
  : ItestAltAltModBoolInp
{
  public testNumber alt { get; set; }
  public testString AsString { get; set; }
  public testAltAltModBoolInp AltAltModBoolInp { get; set; }
}
