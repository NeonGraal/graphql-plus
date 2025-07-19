//HintName: Model_generic-parent-dual+Output.gen.cs
// Generated from generic-parent-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_Output;

public interface IGnrcPrntDualOutp
  : IRefGnrcPrntDualOutp
{
}
public class OutputGnrcPrntDualOutp
  : OutputRefGnrcPrntDualOutp
  , IGnrcPrntDualOutp
{
}

public interface IRefGnrcPrntDualOutp<Tref>
{
  Tref Asref { get; }
}
public class OutputRefGnrcPrntDualOutp<Tref>
  : IRefGnrcPrntDualOutp<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcPrntDualOutp
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntDualOutp
  : IAltGnrcPrntDualOutp
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
