//HintName: Model_alt+Output.gen.cs
// Generated from alt+Output.graphql+

/*
*/

namespace GqlTest.Model_alt_Output;

public interface IOutpAlt
{
  AltOutpAlt AsAltOutpAlt { get; }
}
public class OutputOutpAlt
  : IOutpAlt
{
  public AltOutpAlt AsAltOutpAlt { get; set; }
}

public interface IAltOutpAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpAlt
  : IAltOutpAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
