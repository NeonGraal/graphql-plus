//HintName: Model_generic-dual+input.gen.cs
// Generated from generic-dual+input.graphql+

/*
*/

namespace GqlTest.Model_generic_dual_input;

public interface IInpGnrcDual
{
  InpGnrcDualRef < I@043/0001 InpGnrcDualAlt > field { get; }
}
public class InputInpGnrcDual
{
  public InpGnrcDualRef < I@043/0001 InpGnrcDualAlt > field { get; set; }
}

public interface IInpGnrcDualRef
{
  $ref Asref { get; }
}
public class InputInpGnrcDualRef
{
  public $ref Asref { get; set; }
}

public interface IInpGnrcDualAlt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualInpGnrcDualAlt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
