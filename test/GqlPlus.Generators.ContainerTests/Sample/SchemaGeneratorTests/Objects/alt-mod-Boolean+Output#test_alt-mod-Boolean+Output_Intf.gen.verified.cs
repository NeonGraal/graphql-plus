//HintName: test_alt-mod-Boolean+Output_Intf.gen.cs
// Generated from alt-mod-Boolean+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public interface ItestAltModBoolOutp
{
  public IDictionary<testBoolean, ItestAltAltModBoolOutp> AsAltAltModBoolOutp { get; set; }
  public ItestAltModBoolOutpObject AsAltModBoolOutp { get; set; }
}

public interface ItestAltModBoolOutpObject
{
}

public interface ItestAltAltModBoolOutp
{
  public ItestString AsString { get; set; }
  public ItestAltAltModBoolOutpObject AsAltAltModBoolOutp { get; set; }
}

public interface ItestAltAltModBoolOutpObject
{
  public ItestNumber Alt { get; set; }
}
