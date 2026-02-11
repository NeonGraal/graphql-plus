//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual
{
  ItestCnstFieldObjDualObject AsCnstFieldObjDual { get; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject
{
}

public interface ItestRefCnstFieldObjDual<Tref>
{
  ItestRefCnstFieldObjDualObject AsRefCnstFieldObjDual { get; }
}

public interface ItestRefCnstFieldObjDualObject<Tref>
{
  Tref Field { get; }
}

public interface ItestPrntCnstFieldObjDual
{
  string AsString { get; }
  ItestPrntCnstFieldObjDualObject AsPrntCnstFieldObjDual { get; }
}

public interface ItestPrntCnstFieldObjDualObject
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  ItestAltCnstFieldObjDualObject AsAltCnstFieldObjDual { get; }
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  decimal Alt { get; }
}
