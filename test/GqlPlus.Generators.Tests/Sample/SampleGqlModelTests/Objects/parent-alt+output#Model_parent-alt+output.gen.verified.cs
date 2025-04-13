//HintName: Model_parent-alt+output.gen.cs
// Generated from parent-alt+output.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_output;

public interface IOutpPrntAlt
  : IRefOutpPrntAlt
{
  Number AsNumber { get; }
}
public class OutputOutpPrntAlt
  : OutputRefOutpPrntAlt
  , IOutpPrntAlt
{
  public Number AsNumber { get; set; }
}

public interface IRefOutpPrntAlt
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefOutpPrntAlt
  : IRefOutpPrntAlt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
