//HintName: Model_generic-parent-dual+Input.gen.cs
// Generated from generic-parent-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_Input;

public interface IInpGnrcPrntDual
  : IRefInpGnrcPrntDual
{
}
public class InputInpGnrcPrntDual
  : InputRefInpGnrcPrntDual
  , IInpGnrcPrntDual
{
}

public interface IRefInpGnrcPrntDual<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcPrntDual<Tref>
  : IRefInpGnrcPrntDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltInpGnrcPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltInpGnrcPrntDual
  : IAltInpGnrcPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
