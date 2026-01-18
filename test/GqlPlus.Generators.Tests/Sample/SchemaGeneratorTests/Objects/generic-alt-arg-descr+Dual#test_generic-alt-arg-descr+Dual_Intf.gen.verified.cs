//HintName: test_generic-alt-arg-descr+Dual_Intf.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public interface ItestGnrcAltArgDescrDual<Ttype>
{
  public testRefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; set; }
  public testGnrcAltArgDescrDual GnrcAltArgDescrDual { get; set; }
}

public interface ItestGnrcAltArgDescrDualField<Ttype>
{
}

public interface ItestRefGnrcAltArgDescrDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltArgDescrDual RefGnrcAltArgDescrDual { get; set; }
}

public interface ItestRefGnrcAltArgDescrDualField<Tref>
{
}
