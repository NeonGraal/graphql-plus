//HintName: Model_alt-dual+Output.gen.cs
// Generated from alt-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_alt_dual_Output;

public interface IAltDualOutp
{
  ObjDualAltDualOutp AsObjDualAltDualOutp { get; }
}
public class OutputAltDualOutp
  : IAltDualOutp
{
  public ObjDualAltDualOutp AsObjDualAltDualOutp { get; set; }
}

public interface IObjDualAltDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualObjDualAltDualOutp
  : IObjDualAltDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
