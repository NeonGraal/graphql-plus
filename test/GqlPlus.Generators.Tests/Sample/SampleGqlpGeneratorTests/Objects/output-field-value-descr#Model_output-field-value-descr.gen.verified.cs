//HintName: Model_output-field-value-descr.gen.cs
// Generated from output-field-value-descr.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_field_value_descr;

public interface IOutpFieldValueDescr
{
  EnumOutpFieldValueDescr field { get; }
}
public class OutputOutpFieldValueDescr
  : IOutpFieldValueDescr
{
  public EnumOutpFieldValueDescr field { get; set; }
}

public enum EnumOutpFieldValueDescr
{
  outpFieldValueDescr,
}
