//HintName: Model_parent-alt+Input.gen.cs
// Generated from parent-alt+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_alt_Input;

public interface IPrntAltInp
  : IRefPrntAltInp
{
  Number AsNumber { get; }
}
public class InputPrntAltInp
  : InputRefPrntAltInp
  , IPrntAltInp
{
  public Number AsNumber { get; set; }
}

public interface IRefPrntAltInp
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefPrntAltInp
  : IRefPrntAltInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
