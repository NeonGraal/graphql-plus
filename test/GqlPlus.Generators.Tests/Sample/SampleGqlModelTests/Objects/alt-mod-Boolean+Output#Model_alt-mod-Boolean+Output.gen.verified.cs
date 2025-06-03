//HintName: Model_alt-mod-Boolean+Output.gen.cs
// Generated from alt-mod-Boolean+Output.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_Boolean_Output;

public interface IAltModBoolOutp
{
  AltAltModBoolOutp AsAltAltModBoolOutp { get; }
}
public class OutputAltModBoolOutp
  : IAltModBoolOutp
{
  public AltAltModBoolOutp AsAltAltModBoolOutp { get; set; }
}

public interface IAltAltModBoolOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltAltModBoolOutp
  : IAltAltModBoolOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
