﻿//HintName: test_generic-alt-arg-descr+Dual_Impl.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public class DualtestGnrcAltArgDescrDual<Ttype>
  : ItestGnrcAltArgDescrDual<Ttype>
{
  public RefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; set; }
}

public class DualtestRefGnrcAltArgDescrDual<Tref>
  : ItestRefGnrcAltArgDescrDual<Tref>
{
  public Tref Asref { get; set; }
}
