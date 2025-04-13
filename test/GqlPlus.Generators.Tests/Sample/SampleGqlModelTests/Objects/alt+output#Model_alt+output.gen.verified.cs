//HintName: Model_alt+output.gen.cs
// Generated from alt+output.graphql+

/*
*/

namespace GqlTest.Model_alt_output;

public interface IOutpAlt
{
  AltOutpAlt AsAltOutpAlt { get; }
}
public class OutputOutpAlt
{
  public AltOutpAlt AsAltOutpAlt { get; set; }
}

public interface IAltOutpAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
