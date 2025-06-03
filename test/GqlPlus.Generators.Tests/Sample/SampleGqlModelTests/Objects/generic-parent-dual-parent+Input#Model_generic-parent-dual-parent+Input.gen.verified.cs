//HintName: Model_generic-parent-dual-parent+Input.gen.cs
// Generated from generic-parent-dual-parent+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_parent_Input;

public interface IInpGnrcPrntDualPrnt
  : IRefInpGnrcPrntDualPrnt
{
}
public class InputInpGnrcPrntDualPrnt
  : InputRefInpGnrcPrntDualPrnt
  , IInpGnrcPrntDualPrnt
{
}

public interface IRefInpGnrcPrntDualPrnt<Tref>
  : Iref
{
}
public class InputRefInpGnrcPrntDualPrnt<Tref>
  : Inputref
  , IRefInpGnrcPrntDualPrnt<Tref>
{
}

public interface IAltInpGnrcPrntDualPrnt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltInpGnrcPrntDualPrnt
  : IAltInpGnrcPrntDualPrnt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
