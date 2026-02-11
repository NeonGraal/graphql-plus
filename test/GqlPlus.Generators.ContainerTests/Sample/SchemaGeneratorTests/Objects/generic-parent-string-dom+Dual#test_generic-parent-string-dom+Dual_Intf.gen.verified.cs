//HintName: test_generic-parent-string-dom+Dual_Intf.gen.cs
// Generated from generic-parent-string-dom+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public interface ItestGnrcPrntStrDomDual
  : ItestFieldGnrcPrntStrDomDual
{
  ItestGnrcPrntStrDomDualObject AsGnrcPrntStrDomDual { get; }
}

public interface ItestGnrcPrntStrDomDualObject
  : ItestFieldGnrcPrntStrDomDualObject
{
}

public interface ItestFieldGnrcPrntStrDomDual<Tref>
{
  ItestFieldGnrcPrntStrDomDualObject AsFieldGnrcPrntStrDomDual { get; }
}

public interface ItestFieldGnrcPrntStrDomDualObject<Tref>
{
  Tref Field { get; }
}

public interface ItestDomGnrcPrntStrDomDual
  : IDomainString
{
}
