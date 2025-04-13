//HintName: Model_generic-parent-dual-parent+output.gen.cs
// Generated from generic-parent-dual-parent+output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_parent_output;

public interface IOutpGnrcPrntDualPrnt
  : IRefOutpGnrcPrntDualPrnt
{
}
public class OutputOutpGnrcPrntDualPrnt
  : OutputRefOutpGnrcPrntDualPrnt
  , IOutpGnrcPrntDualPrnt
{
}

public interface IRefOutpGnrcPrntDualPrnt<Tref>
  : Iref
{
}
public class OutputRefOutpGnrcPrntDualPrnt<Tref>
  : Outputref
  , IRefOutpGnrcPrntDualPrnt<Tref>
{
}

public interface IAltOutpGnrcPrntDualPrnt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltOutpGnrcPrntDualPrnt
  : IAltOutpGnrcPrntDualPrnt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
