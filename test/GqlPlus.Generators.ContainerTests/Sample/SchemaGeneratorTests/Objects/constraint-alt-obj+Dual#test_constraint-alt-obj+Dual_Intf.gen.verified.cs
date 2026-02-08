//HintName: test_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
{
  public ItestRefCnstAltObjDual<ItestAltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
  public ItestCnstAltObjDualObject AsCnstAltObjDual { get; set; }
}

public interface ItestCnstAltObjDualObject
{
}

public interface ItestRefCnstAltObjDual<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltObjDualObject AsRefCnstAltObjDual { get; set; }
}

public interface ItestRefCnstAltObjDualObject<Tref>
{
}

public interface ItestPrntCnstAltObjDual
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstAltObjDualObject AsPrntCnstAltObjDual { get; set; }
}

public interface ItestPrntCnstAltObjDualObject
{
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  public ItestAltCnstAltObjDualObject AsAltCnstAltObjDual { get; set; }
}

public interface ItestAltCnstAltObjDualObject
  : ItestPrntCnstAltObjDualObject
{
  public ItestNumber Alt { get; set; }
}
