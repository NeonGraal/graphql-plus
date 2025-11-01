//HintName: test_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
{
  public testRefCnstAltObjDual<testAltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
  public testCnstAltObjDual CnstAltObjDual { get; set; }
}

public interface ItestCnstAltObjDualField
{
}

public interface ItestRefCnstAltObjDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltObjDual RefCnstAltObjDual { get; set; }
}

public interface ItestRefCnstAltObjDualField<Tref>
{
}

public interface ItestPrntCnstAltObjDual
{
  public testString AsString { get; set; }
  public testPrntCnstAltObjDual PrntCnstAltObjDual { get; set; }
}

public interface ItestPrntCnstAltObjDualField
{
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  public testAltCnstAltObjDual AltCnstAltObjDual { get; set; }
}

public interface ItestAltCnstAltObjDualField
  : ItestPrntCnstAltObjDualField
{
  public testNumber alt { get; set; }
}
