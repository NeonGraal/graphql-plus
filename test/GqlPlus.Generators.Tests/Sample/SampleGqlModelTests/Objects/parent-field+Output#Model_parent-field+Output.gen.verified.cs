//HintName: Model_parent-field+Output.gen.cs
// Generated from parent-field+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_field_Output;

public interface IPrntFieldOutp
  : IRefPrntFieldOutp
{
  Number field { get; }
}
public class OutputPrntFieldOutp
  : OutputRefPrntFieldOutp
  , IPrntFieldOutp
{
  public Number field { get; set; }
}

public interface IRefPrntFieldOutp
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefPrntFieldOutp
  : IRefPrntFieldOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
