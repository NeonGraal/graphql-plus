//HintName: test_constraint-alt-obj+Output_Impl.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public class OutputtestCnstAltObjOutp
  : ItestCnstAltObjOutp
{
  public RefCnstAltObjOutp<AltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
}

public class OutputtestRefCnstAltObjOutp<Tref>
  : ItestRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
}

public class OutputtestPrntCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  public String AsString { get; set; }
}

public class OutputtestAltCnstAltObjOutp
  : OutputtestPrntCnstAltObjOutp
  , ItestAltCnstAltObjOutp
{
  public Number alt { get; set; }
}
