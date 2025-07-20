//HintName: Model_output-field-value.gen.cs
// Generated from output-field-value.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_field_value;

public interface IOutpFieldValue
{
  EnumOutpFieldValue field { get; }
}
public class OutputOutpFieldValue
  : IOutpFieldValue
{
  public EnumOutpFieldValue field { get; set; }
}

public enum EnumOutpFieldValue
{
  outpFieldValue,
}
