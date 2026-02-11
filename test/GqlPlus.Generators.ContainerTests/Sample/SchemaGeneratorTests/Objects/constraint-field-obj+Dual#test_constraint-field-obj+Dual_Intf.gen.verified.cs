//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
{
  ItestCnstFieldObjDualObject AsCnstFieldObjDual { get; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>
{
}

public interface ItestRefCnstFieldObjDual<TRef>
{
  ItestRefCnstFieldObjDualObject AsRefCnstFieldObjDual { get; }
}

public interface ItestRefCnstFieldObjDualObject<TRef>
{
  TRef Field { get; }
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
