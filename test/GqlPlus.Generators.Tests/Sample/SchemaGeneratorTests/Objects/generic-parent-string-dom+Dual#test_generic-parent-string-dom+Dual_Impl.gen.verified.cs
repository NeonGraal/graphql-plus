﻿//HintName: test_generic-parent-string-dom+Dual_Impl.gen.cs
// Generated from generic-parent-string-dom+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_string_dom_Dual;

public class testGnrcPrntStrDomDual
  : testFieldGnrcPrntStrDomDual
  , ItestGnrcPrntStrDomDual
{
}

public class testFieldGnrcPrntStrDomDual<Tref>
  : ItestFieldGnrcPrntStrDomDual<Tref>
{
  public Tref field { get; set; }
}

public class testDomGnrcPrntStrDomDual
  : ItestDomGnrcPrntStrDomDual
{
}
