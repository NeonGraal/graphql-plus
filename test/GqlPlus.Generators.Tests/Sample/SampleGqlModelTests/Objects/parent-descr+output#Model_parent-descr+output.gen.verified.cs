//HintName: Model_parent-descr+output.gen.cs
// Generated from parent-descr+output.graphql+

/*
*/

namespace GqlTest.Model_parent_descr_output;

public interface IOutpPrntDescr
  : IRefOutpPrntDescr
{
}
public class OutputOutpPrntDescr
  : OutputRefOutpPrntDescr
  , IOutpPrntDescr
{
}

public interface IRefOutpPrntDescr
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefOutpPrntDescr
  : IRefOutpPrntDescr
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
