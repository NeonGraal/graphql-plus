//HintName: test_constraint-field-obj+Output_Intf.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp
{
  public testCnstFieldObjOutp CnstFieldObjOutp { get; set; }
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject
{
}

public interface ItestRefCnstFieldObjOutp<Tref>
{
  public testRefCnstFieldObjOutp RefCnstFieldObjOutp { get; set; }
}

public interface ItestRefCnstFieldObjOutpObject<Tref>
{
  public Tref field { get; set; }
}

public interface ItestPrntCnstFieldObjOutp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldObjOutp PrntCnstFieldObjOutp { get; set; }
}

public interface ItestPrntCnstFieldObjOutpObject
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  public testAltCnstFieldObjOutp AltCnstFieldObjOutp { get; set; }
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  public testNumber alt { get; set; }
}
