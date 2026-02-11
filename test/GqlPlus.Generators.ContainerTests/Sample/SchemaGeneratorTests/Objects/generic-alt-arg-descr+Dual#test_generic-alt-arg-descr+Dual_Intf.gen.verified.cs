//HintName: test_generic-alt-arg-descr+Dual_Intf.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public interface ItestGnrcAltArgDescrDual<Ttype>
{
  ItestRefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; }
  ItestGnrcAltArgDescrDualObject AsGnrcAltArgDescrDual { get; }
}

public interface ItestGnrcAltArgDescrDualObject<Ttype>
{
}

public interface ItestRefGnrcAltArgDescrDual<Tref>
{
  Tref Asref { get; }
  ItestRefGnrcAltArgDescrDualObject AsRefGnrcAltArgDescrDual { get; }
}

public interface ItestRefGnrcAltArgDescrDualObject<Tref>
{
}
