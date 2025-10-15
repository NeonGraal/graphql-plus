//HintName: test_constraint-alt-obj+Output_Intf.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
{
  RefCnstAltObjOutp<AltCnstAltObjOutp> AsRefCnstAltObjOutp { get; }
}

public interface ItestRefCnstAltObjOutp<Tref>
{
  Tref Asref { get; }
}

public interface ItestPrntCnstAltObjOutp
{
  String AsString { get; }
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  Number alt { get; }
}
