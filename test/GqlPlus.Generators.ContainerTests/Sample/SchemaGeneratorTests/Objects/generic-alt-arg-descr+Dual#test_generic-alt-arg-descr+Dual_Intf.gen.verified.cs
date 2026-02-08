//HintName: test_generic-alt-arg-descr+Dual_Intf.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public interface ItestGnrcAltArgDescrDual<Ttype>
{
  public ItestRefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; set; }
  public ItestGnrcAltArgDescrDualObject AsGnrcAltArgDescrDual { get; set; }
}

public interface ItestGnrcAltArgDescrDualObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDescrDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefGnrcAltArgDescrDualObject AsRefGnrcAltArgDescrDual { get; set; }
}

public interface ItestRefGnrcAltArgDescrDualObject<Tref>
{
}
