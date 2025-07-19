//HintName: Model_output-field-enum.gen.cs
// Generated from output-field-enum.graphql+

/*
*/

namespace GqlTest.Model_output_field_enum;

public interface IOutpFieldEnum
{
  EnumOutpFieldEnum field { get; }
}
public class OutputOutpFieldEnum
  : IOutpFieldEnum
{
  public EnumOutpFieldEnum field { get; set; }
}

public enum EnumOutpFieldEnum
{
  outpFieldEnum,
}
