//HintName: Model_parent+output.gen.cs
// Generated from parent+output.graphql+

/*
*/

namespace GqlTest.Model_parent_output;

public interface IOutpPrnt
  : IRefOutpPrnt
{
}
public class OutputOutpPrnt
  : OutputRefOutpPrnt
  , IOutpPrnt
{
}

public interface IRefOutpPrnt
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefOutpPrnt
  : IRefOutpPrnt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
