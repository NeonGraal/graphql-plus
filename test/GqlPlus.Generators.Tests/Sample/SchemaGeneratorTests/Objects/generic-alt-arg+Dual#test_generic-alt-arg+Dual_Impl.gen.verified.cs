﻿//HintName: test_generic-alt-arg+Dual_Impl.gen.cs
// Generated from generic-alt-arg+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_Dual;

public class DualtestGnrcAltArgDual<Ttype>
  : ItestGnrcAltArgDual<Ttype>
{
  public RefGnrcAltArgDual<Ttype> AsRefGnrcAltArgDual { get; set; }
}

public class DualtestRefGnrcAltArgDual<Tref>
  : ItestRefGnrcAltArgDual<Tref>
{
  public Tref Asref { get; set; }
}
