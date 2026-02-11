//HintName: test_generic-parent-enum-parent+Input_Impl.gen.cs
// Generated from generic-parent-enum-parent+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Input;

public class testGnrcPrntEnumPrntInp
  : testFieldGnrcPrntEnumPrntInp<testEnumGnrcPrntEnumPrntInp>
  , ItestGnrcPrntEnumPrntInp
{
  public ItestGnrcPrntEnumPrntInpObject AsGnrcPrntEnumPrntInp { get; set; }
}

public class testFieldGnrcPrntEnumPrntInp<TRef>
  : ItestFieldGnrcPrntEnumPrntInp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumPrntInpObject AsFieldGnrcPrntEnumPrntInp { get; set; }
}
