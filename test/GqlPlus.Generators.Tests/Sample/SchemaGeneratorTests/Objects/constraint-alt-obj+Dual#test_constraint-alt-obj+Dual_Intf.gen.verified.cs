//HintName: test_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
{
  RefCnstAltObjDual<AltCnstAltObjDual> AsRefCnstAltObjDual { get; }
}

public interface ItestRefCnstAltObjDual<Tref>
{
  Tref Asref { get; }
}

public interface ItestPrntCnstAltObjDual
{
  String AsString { get; }
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  Number alt { get; }
}
