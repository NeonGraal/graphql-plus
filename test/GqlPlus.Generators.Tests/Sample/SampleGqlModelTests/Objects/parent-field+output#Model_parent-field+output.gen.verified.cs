//HintName: Model_parent-field+output.gen.cs
// Generated from parent-field+output.graphql+

/*
*/

namespace GqlTest.Model_parent_field_output;

public interface IOutpPrntField
  : IRefOutpPrntField
{
  Number field { get; }
}
public class OutputOutpPrntField
  : OutputRefOutpPrntField
  , IOutpPrntField
{
  public Number field { get; set; }
}

public interface IRefOutpPrntField
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefOutpPrntField
  : IRefOutpPrntField
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
