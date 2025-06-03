//HintName: Model_alt-mod-param+Input.gen.cs
// Generated from alt-mod-param+Input.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_param_Input;

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
