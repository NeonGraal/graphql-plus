//HintName: test_alt-mod-Boolean+Input_Intf.gen.cs
// Generated from alt-mod-Boolean+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Input;

public interface ItestAltModBoolInp
{
  public IDictionary<testBoolean, testAltAltModBoolInp> AsAltAltModBoolInp { get; set; }
  public testAltModBoolInp AltModBoolInp { get; set; }
}

public interface ItestAltModBoolInpField
{
}

public interface ItestAltAltModBoolInp
{
  public testString AsString { get; set; }
  public testAltAltModBoolInp AltAltModBoolInp { get; set; }
}

public interface ItestAltAltModBoolInpField
{
  public testNumber alt { get; set; }
}
