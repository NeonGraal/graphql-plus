//HintName: test_constraint-field-obj+Input_Intf.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp
{
  public testCnstFieldObjInp CnstFieldObjInp { get; set; }
}

public interface ItestCnstFieldObjInpField
  : ItestRefCnstFieldObjInpField
{
}

public interface ItestRefCnstFieldObjInp<Tref>
{
  public testRefCnstFieldObjInp RefCnstFieldObjInp { get; set; }
}

public interface ItestRefCnstFieldObjInpField<Tref>
{
  public Tref field { get; set; }
}

public interface ItestPrntCnstFieldObjInp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldObjInp PrntCnstFieldObjInp { get; set; }
}

public interface ItestPrntCnstFieldObjInpField
{
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  public testAltCnstFieldObjInp AltCnstFieldObjInp { get; set; }
}

public interface ItestAltCnstFieldObjInpField
  : ItestPrntCnstFieldObjInpField
{
  public testNumber alt { get; set; }
}
