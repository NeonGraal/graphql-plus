//HintName: test_generic-parent-enum-dom+Output_Impl.gen.cs
// Generated from generic-parent-enum-dom+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Output;

public class testGnrcPrntEnumDomOutp
  : testFieldGnrcPrntEnumDomOutp<ItestDomGnrcPrntEnumDomOutp>
  , ItestGnrcPrntEnumDomOutp
{
  public ItestGnrcPrntEnumDomOutpObject AsGnrcPrntEnumDomOutp { get; set; }
}

public class testFieldGnrcPrntEnumDomOutp<TRef>
  : ItestFieldGnrcPrntEnumDomOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumDomOutpObject<TRef> AsFieldGnrcPrntEnumDomOutp { get; set; }
}

public class testDomGnrcPrntEnumDomOutp
  : GqlpDomainEnum
  , ItestDomGnrcPrntEnumDomOutp
{
}
