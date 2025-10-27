//HintName: test_constraint-alt-obj+Output_Impl.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public class testCnstAltObjOutp
  : ItestCnstAltObjOutp
{
  public RefCnstAltObjOutp<AltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
}

public class testRefCnstAltObjOutp<Tref>
  : ItestRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class testPrntCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  public String AsString { get; set; }
}

public class testAltCnstAltObjOutp
  : testPrntCnstAltObjOutp
  , ItestAltCnstAltObjOutp
{
  public Number alt { get; set; }
}
