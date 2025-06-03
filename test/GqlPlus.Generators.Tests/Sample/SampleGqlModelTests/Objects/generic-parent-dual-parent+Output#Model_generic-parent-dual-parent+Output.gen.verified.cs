//HintName: Model_generic-parent-dual-parent+Output.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_parent_Output;

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
