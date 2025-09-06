//HintName: Gqlp_constraint-field-obj+Dual_Impl.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_obj_Dual;

public class DualCnstFieldObjDual
  : DualRefCnstFieldObjDual
  , ICnstFieldObjDual
{
}

public class DualRefCnstFieldObjDual<Tref>
  : IRefCnstFieldObjDual<Tref>
{
  public Tref field { get; set; }
}

public class DualPrntCnstFieldObjDual
  : IPrntCnstFieldObjDual
{
  public String AsString { get; set; }
}

public class DualAltCnstFieldObjDual
  : DualPrntCnstFieldObjDual
  , IAltCnstFieldObjDual
{
  public Number alt { get; set; }
}
