//HintName: Model_parent-descr+input.gen.cs
// Generated from parent-descr+input.graphql+

/*
*/

namespace GqlTest.Model_parent_descr_input;

public interface IInpPrntDescr
{
}
public class InputInpPrntDescr
{
}

public interface IRefInpPrntDescr
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefInpPrntDescr
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
