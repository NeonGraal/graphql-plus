﻿//HintName: test_constraint-field-obj+Dual_Impl.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public class testCnstFieldObjDual
  : testRefCnstFieldObjDual
  , ItestCnstFieldObjDual
{
}

public class testRefCnstFieldObjDual<Tref>
  : ItestRefCnstFieldObjDual<Tref>
{
  public Tref field { get; set; }
}

public class testPrntCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  public String AsString { get; set; }
}

public class testAltCnstFieldObjDual
  : testPrntCnstFieldObjDual
  , ItestAltCnstFieldObjDual
{
  public Number alt { get; set; }
}
