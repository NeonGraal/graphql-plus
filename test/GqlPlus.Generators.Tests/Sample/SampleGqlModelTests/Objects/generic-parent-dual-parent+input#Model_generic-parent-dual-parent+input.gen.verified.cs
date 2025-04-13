//HintName: Model_generic-parent-dual-parent+input.gen.cs
// Generated from generic-parent-dual-parent+input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_parent_input;

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
