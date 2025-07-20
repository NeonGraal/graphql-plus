//HintName: Model_parent-field+Input.gen.cs
// Generated from parent-field+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_parent_field_Input;

public interface IPrntFieldInp
  : IRefPrntFieldInp
{
  Number field { get; }
}
public class InputPrntFieldInp
  : InputRefPrntFieldInp
  , IPrntFieldInp
{
  public Number field { get; set; }
}

public interface IRefPrntFieldInp
{
  Number parent { get; }
  String AsString { get; }
}
public class InputRefPrntFieldInp
  : IRefPrntFieldInp
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}
