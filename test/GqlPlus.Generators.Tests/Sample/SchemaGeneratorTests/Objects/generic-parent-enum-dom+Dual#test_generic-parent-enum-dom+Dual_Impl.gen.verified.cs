//HintName: test_generic-parent-enum-dom+Dual_Impl.gen.cs
// Generated from generic-parent-enum-dom+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_enum_dom_Dual;

public class DualtestGnrcPrntEnumDomDual
  : DualtestFieldGnrcPrntEnumDomDual
  , ItestGnrcPrntEnumDomDual
{
}

public class DualtestFieldGnrcPrntEnumDomDual<Tref>
  : ItestFieldGnrcPrntEnumDomDual<Tref>
{
  public Tref field { get; set; }
}

public class DomaintestDomGnrcPrntEnumDomDual
  : ItestDomGnrcPrntEnumDomDual
{
}
