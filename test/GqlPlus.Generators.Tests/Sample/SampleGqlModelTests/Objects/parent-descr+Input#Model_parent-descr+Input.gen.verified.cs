//HintName: Model_parent-descr+Input.gen.cs
// Generated from parent-descr+Input.graphql+

/*
*/

namespace GqlTest.Model_parent_descr_Input;

public interface IPrntDescrInp
  : IRefPrntDescrInp
{
}
public class InputPrntDescrInp
  : InputRefPrntDescrInp
  , IPrntDescrInp
{
}

public interface IRefPrntDescrInp
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefPrntDescrInp
  : IRefPrntDescrInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
