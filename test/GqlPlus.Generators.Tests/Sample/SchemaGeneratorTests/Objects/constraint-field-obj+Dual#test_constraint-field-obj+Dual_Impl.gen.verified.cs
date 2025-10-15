//HintName: test_constraint-field-obj+Dual_Impl.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public class DualtestCnstFieldObjDual
  : DualtestRefCnstFieldObjDual
  , ItestCnstFieldObjDual
{
}

public class DualtestRefCnstFieldObjDual<Tref>
  : ItestRefCnstFieldObjDual<Tref>
{
  public Tref field { get; set; }
}

public class DualtestPrntCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  public String AsString { get; set; }
}

public class DualtestAltCnstFieldObjDual
  : DualtestPrntCnstFieldObjDual
  , ItestAltCnstFieldObjDual
{
  public Number alt { get; set; }
}
