﻿//HintName: test_generic-alt-simple+Dual_Impl.gen.cs
// Generated from generic-alt-simple+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_simple_Dual;

public class DualtestGnrcAltSmplDual
  : ItestGnrcAltSmplDual
{
  public RefGnrcAltSmplDual<String> AsRefGnrcAltSmplDual { get; set; }
}

public class DualtestRefGnrcAltSmplDual<Tref>
  : ItestRefGnrcAltSmplDual<Tref>
{
  public Tref Asref { get; set; }
}
