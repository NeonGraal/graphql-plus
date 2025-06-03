//HintName: Model_generic-parent-dual+Output.gen.cs
// Generated from generic-parent-dual+Output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_Output;

public interface IOutpGnrcPrntDual
  : IRefOutpGnrcPrntDual
{
}
public class OutputOutpGnrcPrntDual
  : OutputRefOutpGnrcPrntDual
  , IOutpGnrcPrntDual
{
}

public interface IRefOutpGnrcPrntDual<Tref>
{
  Tref Asref { get; }
}
public class OutputRefOutpGnrcPrntDual<Tref>
  : IRefOutpGnrcPrntDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltOutpGnrcPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltOutpGnrcPrntDual
  : IAltOutpGnrcPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
