//HintName: Model_alt-mod-Boolean+Output.gen.cs
// Generated from alt-mod-Boolean+Output.graphql+

/*
*/

namespace GqlTest.Model_alt_mod_Boolean_Output;

public interface IOutpAltModBool
{
  AltOutpAltModBool AsAltOutpAltModBool { get; }
}
public class OutputOutpAltModBool
  : IOutpAltModBool
{
  public AltOutpAltModBool AsAltOutpAltModBool { get; set; }
}

public interface IAltOutpAltModBool
{
  Number alt { get; }
  String AsString { get; }
}
public class OutputAltOutpAltModBool
  : IAltOutpAltModBool
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
