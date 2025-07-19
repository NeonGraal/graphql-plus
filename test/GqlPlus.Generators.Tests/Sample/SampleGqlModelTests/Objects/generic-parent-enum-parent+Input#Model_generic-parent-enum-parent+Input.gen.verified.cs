//HintName: Model_generic-parent-enum-parent+Input.gen.cs
// Generated from generic-parent-enum-parent+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_enum_parent_Input;

public interface IGnrcPrntEnumPrntInp
  : IFieldGnrcPrntEnumPrntInp
{
}
public class InputGnrcPrntEnumPrntInp
  : InputFieldGnrcPrntEnumPrntInp
  , IGnrcPrntEnumPrntInp
{
}

public interface IFieldGnrcPrntEnumPrntInp<Tref>
{
  Tref field { get; }
}
public class InputFieldGnrcPrntEnumPrntInp<Tref>
  : IFieldGnrcPrntEnumPrntInp<Tref>
{
  public Tref field { get; set; }
}

public enum EnumGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent = ParentGnrcPrntEnumPrntInp.gnrcPrntEnumPrntInpParent,
  gnrcPrntEnumPrntInpLabel,
}

public enum ParentGnrcPrntEnumPrntInp
{
  gnrcPrntEnumPrntInpParent,
}
