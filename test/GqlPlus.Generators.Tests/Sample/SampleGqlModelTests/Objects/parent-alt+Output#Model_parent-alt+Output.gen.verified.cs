//HintName: Model_parent-alt+Output.gen.cs
// Generated from parent-alt+Output.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_Output;

public interface IPrntAltOutp
  : IRefPrntAltOutp
{
  Number AsNumber { get; }
}
public class OutputPrntAltOutp
  : OutputRefPrntAltOutp
  , IPrntAltOutp
{
  public Number AsNumber { get; set; }
}

public interface IRefPrntAltOutp
{
  Number parent { get; }
  String AsString { get; }
}
public class OutputRefPrntAltOutp
  : IRefPrntAltOutp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
