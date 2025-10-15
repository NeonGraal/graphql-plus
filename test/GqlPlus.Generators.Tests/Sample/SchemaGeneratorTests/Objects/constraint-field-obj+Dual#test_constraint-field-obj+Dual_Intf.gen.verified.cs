//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from constraint-field-obj+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual
{
}

public interface ItestRefCnstFieldObjDual<Tref>
{
  Tref field { get; }
}

public interface ItestPrntCnstFieldObjDual
{
  String AsString { get; }
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  Number alt { get; }
}
