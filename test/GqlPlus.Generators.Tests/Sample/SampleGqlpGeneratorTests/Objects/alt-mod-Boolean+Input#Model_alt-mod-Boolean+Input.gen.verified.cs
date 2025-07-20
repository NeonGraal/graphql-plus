//HintName: Model_alt-mod-Boolean+Input.gen.cs
// Generated from alt-mod-Boolean+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_alt_mod_Boolean_Input;

public interface IAltModBoolInp
{
  AltAltModBoolInp AsAltAltModBoolInp { get; }
}
public class InputAltModBoolInp
  : IAltModBoolInp
{
  public AltAltModBoolInp AsAltAltModBoolInp { get; set; }
}

public interface IAltAltModBoolInp
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltAltModBoolInp
  : IAltAltModBoolInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
