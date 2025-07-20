//HintName: Model_generic-parent-enum-child+Input.gen.cs
// Generated from generic-parent-enum-child+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_enum_child_Input;

public interface IGnrcPrntEnumChildInp
  : IFieldGnrcPrntEnumChildInp
{
}
public class InputGnrcPrntEnumChildInp
  : InputFieldGnrcPrntEnumChildInp
  , IGnrcPrntEnumChildInp
{
}

public interface IFieldGnrcPrntEnumChildInp<Tref>
{
  Tref field { get; }
}
public class InputFieldGnrcPrntEnumChildInp<Tref>
  : IFieldGnrcPrntEnumChildInp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent = ParentGnrcPrntEnumChildInp.gnrcPrntEnumChildInpParent,
  gnrcPrntEnumChildInpLabel,
}

public enum ParentGnrcPrntEnumChildInp
{
  gnrcPrntEnumChildInpParent,
}
