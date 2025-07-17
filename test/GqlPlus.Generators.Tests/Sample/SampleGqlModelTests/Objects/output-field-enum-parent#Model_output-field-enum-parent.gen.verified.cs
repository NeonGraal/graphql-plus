//HintName: Model_output-field-enum-parent.gen.cs
// Generated from output-field-enum-parent.graphql+

/*
*/

namespace GqlTest.Model_output_field_enum_parent;

public interface IOutpFieldEnumPrnt
{
  EnumOutpFieldEnumPrnt field { get; }
}
public class OutputOutpFieldEnumPrnt
  : IOutpFieldEnumPrnt
{
  public EnumOutpFieldEnumPrnt field { get; set; }
}

public enum EnumOutpFieldEnumPrnt
{
  prnt_outpFieldEnumPrnt = PrntOutpFieldEnumPrnt.prnt_outpFieldEnumPrnt,
  outpFieldEnumPrnt,
}

public enum PrntOutpFieldEnumPrnt
{
  prnt_outpFieldEnumPrnt,
}
