//HintName: Model_generic-parent-dual+input.gen.cs
// Generated from generic-parent-dual+input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_input;

public interface IInpGnrcPrntDual
{
}
public class InputInpGnrcPrntDual
{
}

public interface IRefInpGnrcPrntDual
{
  $ref Asref { get; }
}
public class InputRefInpGnrcPrntDual
{
  public $ref Asref { get; set; }
}

public interface IAltInpGnrcPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltInpGnrcPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
