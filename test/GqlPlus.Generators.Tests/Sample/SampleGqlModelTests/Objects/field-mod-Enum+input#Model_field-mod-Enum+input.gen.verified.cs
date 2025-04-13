//HintName: Model_field-mod-Enum+input.gen.cs
// Generated from field-mod-Enum+input.graphql+

/*
*/

namespace GqlTest.Model_field_mod_Enum_input;

public interface IInpFieldModEnum
{
  String field { get; }
}
public class InputInpFieldModEnum
  : IInpFieldModEnum
{
  public String field { get; set; }
}

public enum EnumInpFieldModEnum
{
  value,
}
