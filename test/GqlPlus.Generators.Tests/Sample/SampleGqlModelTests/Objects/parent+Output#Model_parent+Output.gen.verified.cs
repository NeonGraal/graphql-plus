//HintName: Model_parent+Output.gen.cs
// Generated from parent+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_Output;

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
