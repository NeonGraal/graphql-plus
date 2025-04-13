//HintName: Model_alt-mod-param+input.gen.cs
// Generated from alt-mod-param+input.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_param_input;

public interface IInpAltModParam<Tmod>
{
  AltInpAltModParam AsAltInpAltModParam { get; }
}
public class InputInpAltModParam<Tmod>
  : IInpAltModParam<Tmod>
{
  public AltInpAltModParam AsAltInpAltModParam { get; set; }
}

public interface IAltInpAltModParam
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpAltModParam
  : IAltInpAltModParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
