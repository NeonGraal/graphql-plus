//HintName: test_generic-parent-enum-dom+Dual_Impl.gen.cs
// Generated from generic-parent-enum-dom+Dual.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public class testGnrcPrntEnumDomDual
  : testFieldGnrcPrntEnumDomDual<ItestDomGnrcPrntEnumDomDual>
  , ItestGnrcPrntEnumDomDual
{
  public ItestGnrcPrntEnumDomDualObject AsGnrcPrntEnumDomDual { get; set; }
}

public class testFieldGnrcPrntEnumDomDual<TRef>
  : ItestFieldGnrcPrntEnumDomDual<TRef>
{
  public TRef Field { get; set; }
  public ItestFieldGnrcPrntEnumDomDualObject AsFieldGnrcPrntEnumDomDual { get; set; }
}

public class testDomGnrcPrntEnumDomDual
  : DomainEnum
  , ItestDomGnrcPrntEnumDomDual
{
}
