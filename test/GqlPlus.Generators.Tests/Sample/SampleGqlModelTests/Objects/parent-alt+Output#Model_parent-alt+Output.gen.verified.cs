//HintName: Model_parent-alt+Output.gen.cs
// Generated from parent-alt+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_Output;

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
