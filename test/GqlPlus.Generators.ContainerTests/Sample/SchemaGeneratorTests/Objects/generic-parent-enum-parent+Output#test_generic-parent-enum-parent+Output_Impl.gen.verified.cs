//HintName: test_generic-parent-enum-parent+Output_Impl.gen.cs
// Generated from generic-parent-enum-parent+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_parent_Output;

public class testGnrcPrntEnumPrntOutp
  : testFieldGnrcPrntEnumPrntOutp<testEnumGnrcPrntEnumPrntOutp>
  , ItestGnrcPrntEnumPrntOutp
{
  public ItestGnrcPrntEnumPrntOutpObject AsGnrcPrntEnumPrntOutp { get; set; }
}

public class testFieldGnrcPrntEnumPrntOutp<TRef>
  : ItestFieldGnrcPrntEnumPrntOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumPrntOutpObject<TRef> AsFieldGnrcPrntEnumPrntOutp { get; set; }
}
