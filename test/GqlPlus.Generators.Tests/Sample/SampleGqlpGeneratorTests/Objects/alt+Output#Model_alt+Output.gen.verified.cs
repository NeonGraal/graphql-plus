//HintName: Model_alt+Output.gen.cs
// Generated from alt+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_alt_Output;

public interface IAltOutp
{
  AltAltOutp AsAltAltOutp { get; }
}
public class OutputAltOutp
  : IAltOutp
{
  public AltAltOutp AsAltAltOutp { get; set; }
}

public interface IAltAltOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltAltOutp
  : IAltAltOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
