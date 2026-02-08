//HintName: test_constraint-field-obj+Input_Impl.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public class testCnstFieldObjInp
  : testRefCnstFieldObjInp
  , ItestCnstFieldObjInp
{
}

public class testRefCnstFieldObjInp<Tref>
  : ItestRefCnstFieldObjInp<Tref>
{
  public Tref Field { get; set; }
}

public class testPrntCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  public ItestString AsString { get; set; }
}

public class testAltCnstFieldObjInp
  : testPrntCnstFieldObjInp
  , ItestAltCnstFieldObjInp
{
  public ItestNumber Alt { get; set; }
}
