//HintName: Model_generic-parent-dual-parent+Output.gen.cs
// Generated from generic-parent-dual-parent+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_parent_Output;

public interface IGnrcPrntDualPrntOutp
  : IRefGnrcPrntDualPrntOutp
{
}
public class OutputGnrcPrntDualPrntOutp
  : OutputRefGnrcPrntDualPrntOutp
  , IGnrcPrntDualPrntOutp
{
}

public interface IRefGnrcPrntDualPrntOutp<Tref>
  : Iref
{
}
public class OutputRefGnrcPrntDualPrntOutp<Tref>
  : Outputref
  , IRefGnrcPrntDualPrntOutp<Tref>
{
}

public interface IAltGnrcPrntDualPrntOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntDualPrntOutp
  : IAltGnrcPrntDualPrntOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
