//HintName: test_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
{
  ItestRefCnstAltObjDual<ItestAltCnstAltObjDual> AsRefCnstAltObjDual { get; }
  ItestCnstAltObjDualObject AsCnstAltObjDual { get; }
}

public interface ItestCnstAltObjDualObject
{
}

public interface ItestRefCnstAltObjDual<TRef>
{
  TRef Asref { get; }
  ItestRefCnstAltObjDualObject AsRefCnstAltObjDual { get; }
}

public interface ItestRefCnstAltObjDualObject<TRef>
{
}

public interface ItestPrntCnstAltObjDual
{
  string AsString { get; }
  ItestPrntCnstAltObjDualObject AsPrntCnstAltObjDual { get; }
}

public interface ItestPrntCnstAltObjDualObject
{
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  ItestAltCnstAltObjDualObject AsAltCnstAltObjDual { get; }
}

public interface ItestAltCnstAltObjDualObject
  : ItestPrntCnstAltObjDualObject
{
  decimal Alt { get; }
}
