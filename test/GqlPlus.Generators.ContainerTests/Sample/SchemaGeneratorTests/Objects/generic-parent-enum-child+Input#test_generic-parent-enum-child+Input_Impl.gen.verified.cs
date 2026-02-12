//HintName: test_generic-parent-enum-child+Input_Impl.gen.cs
// Generated from generic-parent-enum-child+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_child_Input;

public class testGnrcPrntEnumChildInp
  : testFieldGnrcPrntEnumChildInp<testParentGnrcPrntEnumChildInp>
  , ItestGnrcPrntEnumChildInp
{
  public ItestGnrcPrntEnumChildInpObject AsGnrcPrntEnumChildInp { get; set; }
}

public class testFieldGnrcPrntEnumChildInp<TRef>
  : ItestFieldGnrcPrntEnumChildInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumChildInpObject<TRef> AsFieldGnrcPrntEnumChildInp { get; set; }
}
