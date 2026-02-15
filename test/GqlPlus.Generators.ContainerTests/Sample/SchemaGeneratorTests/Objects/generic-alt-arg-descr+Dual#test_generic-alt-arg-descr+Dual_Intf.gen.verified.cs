//HintName: test_generic-alt-arg-descr+Dual_Intf.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public interface ItestGnrcAltArgDescrDual<TType>
{
  ItestRefGnrcAltArgDescrDual<TType> AsRefGnrcAltArgDescrDual { get; }
  ItestGnrcAltArgDescrDualObject<TType> AsGnrcAltArgDescrDual { get; }
}

public interface ItestGnrcAltArgDescrDualObject<TType>
{
}

public interface ItestRefGnrcAltArgDescrDual<TRef>
{
  TRef Asref { get; }
  ItestRefGnrcAltArgDescrDualObject<TRef> AsRefGnrcAltArgDescrDual { get; }
}

public interface ItestRefGnrcAltArgDescrDualObject<TRef>
{
}
