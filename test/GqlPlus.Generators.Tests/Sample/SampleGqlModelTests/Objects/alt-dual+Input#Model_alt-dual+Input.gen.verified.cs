//HintName: Model_alt-dual+Input.gen.cs
// Generated from alt-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_alt_dual_Input;

public interface IInpAltDual
{
  InpDualAltDual AsInpDualAltDual { get; }
}
public class InputInpAltDual
  : IInpAltDual
{
  public InpDualAltDual AsInpDualAltDual { get; set; }
}

public interface IInpDualAltDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualInpDualAltDual
  : IInpDualAltDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
