//HintName: Model_parent-descr+Input.gen.cs
// Generated from parent-descr+Input.graphql+

/*
*/

namespace GqlTest.Model_parent_descr_Input;

public interface IInpPrntDescr
  : IRefInpPrntDescr
{
}
public class InputInpPrntDescr
  : InputRefInpPrntDescr
  , IInpPrntDescr
{
}

public interface IRefInpPrntDescr
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefInpPrntDescr
  : IRefInpPrntDescr
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
