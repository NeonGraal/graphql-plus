//HintName: Model_generic-parent-dual+output.gen.cs
// Generated from generic-parent-dual+output.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_dual_output;

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
