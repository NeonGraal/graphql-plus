//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual
{
  public ItestCnstFieldObjDualObject AsCnstFieldObjDual { get; set; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject
{
}

public interface ItestRefCnstFieldObjDual<Tref>
{
  public ItestRefCnstFieldObjDualObject AsRefCnstFieldObjDual { get; set; }
}

public interface ItestRefCnstFieldObjDualObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldObjDual
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjDualObject AsPrntCnstFieldObjDual { get; set; }
}

public interface ItestPrntCnstFieldObjDualObject
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  public ItestAltCnstFieldObjDualObject AsAltCnstFieldObjDual { get; set; }
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  public decimal Alt { get; set; }
}
