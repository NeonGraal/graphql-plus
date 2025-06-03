//HintName: Model_alt-dual+Output.gen.cs
// Generated from alt-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_alt_dual_Output;

public interface IOutpAltDual
{
  OutpDualAltDual AsOutpDualAltDual { get; }
}
public class OutputOutpAltDual
  : IOutpAltDual
{
  public OutpDualAltDual AsOutpDualAltDual { get; set; }
}

public interface IOutpDualAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualOutpDualAltDual
  : IOutpDualAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
