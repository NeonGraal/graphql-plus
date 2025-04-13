//HintName: Model_alt-dual+input.gen.cs
// Generated from alt-dual+input.graphql+

/*
*/

namespace GqlTest.Model_alt_dual_input;

public interface IInpAltDual
{
  InpDualAltDual AsInpDualAltDual { get; }
}
public class InputInpAltDual
{
  public InpDualAltDual AsInpDualAltDual { get; set; }
}

public interface IInpDualAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualInpDualAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
