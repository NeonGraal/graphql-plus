//HintName: Model_input-field-Enum.gen.cs
// Generated from input-field-Enum.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_input_field_Enum;

public interface IInpFieldEnum
{
  EnumInpFieldEnum field { get; }
}
public class InputInpFieldEnum
  : IInpFieldEnum
{
  public EnumInpFieldEnum field { get; set; }
}

public enum EnumInpFieldEnum
{
  inpFieldEnum,
}
