//HintName: Model_alt-mod-param+output.gen.cs
// Generated from alt-mod-param+output.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_param_output;

public interface IOutpAltModParam
{
  AltOutpAltModParam AsAltOutpAltModParam { get; }
}
public class OutputOutpAltModParam
{
  public AltOutpAltModParam AsAltOutpAltModParam { get; set; }
}

public interface IAltOutpAltModParam
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpAltModParam
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
