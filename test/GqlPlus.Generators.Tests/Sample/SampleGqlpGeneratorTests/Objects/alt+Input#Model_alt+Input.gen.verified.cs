//HintName: Model_alt+Input.gen.cs
// Generated from alt+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_alt_Input;

public interface IAltInp
{
  AltAltInp AsAltAltInp { get; }
}
public class InputAltInp
  : IAltInp
{
  public AltAltInp AsAltAltInp { get; set; }
}

public interface IAltAltInp
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltAltInp
  : IAltAltInp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
