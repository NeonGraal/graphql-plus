//HintName: Model_alt-mod-param+output.gen.cs
// Generated from alt-mod-param+output.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_param_output;

public interface IOutpAltModParam<Tmod>
{
  AltOutpAltModParam AsAltOutpAltModParam { get; }
}
public class OutputOutpAltModParam<Tmod>
  : IOutpAltModParam<Tmod>
{
  public AltOutpAltModParam AsAltOutpAltModParam { get; set; }
}

public interface IAltOutpAltModParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpAltModParam
  : IAltOutpAltModParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
