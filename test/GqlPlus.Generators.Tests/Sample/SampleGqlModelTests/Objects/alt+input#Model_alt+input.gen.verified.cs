//HintName: Model_alt+input.gen.cs
// Generated from alt+input.graphql+

/*
*/

namespace GqlTest.Model_alt_input;

public interface IInpAlt
{
  AltInpAlt AsAltInpAlt { get; }
}
public class InputInpAlt
  : IInpAlt
{
  public AltInpAlt AsAltInpAlt { get; set; }
}

public interface IAltInpAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpAlt
  : IAltInpAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
