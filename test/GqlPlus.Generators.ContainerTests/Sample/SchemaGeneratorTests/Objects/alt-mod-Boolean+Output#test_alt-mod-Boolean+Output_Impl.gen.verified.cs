//HintName: test_alt-mod-Boolean+Output_Impl.gen.cs
// Generated from alt-mod-Boolean+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_alt_mod_Boolean_Output;

public class testAltModBoolOutp
  : ItestAltModBoolOutp
{
  public IDictionary<testBoolean, ItestAltAltModBoolOutp> AsAltAltModBoolOutp { get; set; }
}

public class testAltAltModBoolOutp
  : ItestAltAltModBoolOutp
{
  public ItestNumber Alt { get; set; }
  public ItestString AsString { get; set; }
}
