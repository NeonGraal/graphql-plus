//HintName: Model_generic-parent-simple-enum+Input.gen.cs
// Generated from generic-parent-simple-enum+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_simple_enum_Input;

public interface IGnrcPrntSmplEnumInp
  : IFieldGnrcPrntSmplEnumInp
{
}
public class InputGnrcPrntSmplEnumInp
  : InputFieldGnrcPrntSmplEnumInp
  , IGnrcPrntSmplEnumInp
{
}

public interface IFieldGnrcPrntSmplEnumInp<Tref>
{
  Tref field { get; }
}
public class InputFieldGnrcPrntSmplEnumInp<Tref>
  : IFieldGnrcPrntSmplEnumInp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntSmplEnumInp
{
  gnrcPrntSmplEnumInp,
}
