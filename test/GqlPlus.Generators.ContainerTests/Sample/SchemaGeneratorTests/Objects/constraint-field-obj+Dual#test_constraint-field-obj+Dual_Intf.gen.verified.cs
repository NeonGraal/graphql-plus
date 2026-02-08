//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual
{
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject
{
}

public interface ItestRefCnstFieldObjDual<Tref>
{
}

public interface ItestRefCnstFieldObjDualObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldObjDual
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstFieldObjDualObject
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  public ItestNumber Alt { get; set; }
}
