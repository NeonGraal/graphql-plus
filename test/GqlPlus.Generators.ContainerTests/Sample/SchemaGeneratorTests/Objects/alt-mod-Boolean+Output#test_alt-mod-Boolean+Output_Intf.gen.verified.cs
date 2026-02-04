//HintName: test_alt-mod-Boolean+Output_Intf.gen.cs
// Generated from alt-mod-Boolean+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public interface ItestAltModBoolOutp
{
  public IDictionary<testBoolean, testAltAltModBoolOutp> AsAltAltModBoolOutp { get; set; }
  public testAltModBoolOutp AltModBoolOutp { get; set; }
}

public interface ItestAltModBoolOutpObject
{
}

public interface ItestAltAltModBoolOutp
{
  public testString AsString { get; set; }
  public testAltAltModBoolOutp AltAltModBoolOutp { get; set; }
}

public interface ItestAltAltModBoolOutpObject
{
  public testNumber alt { get; set; }
}
