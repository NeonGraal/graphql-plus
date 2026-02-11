//HintName: test_constraint-alt-obj+Output_Impl.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public class testCnstAltObjOutp
  : ItestCnstAltObjOutp
{
  public ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
  public ItestCnstAltObjOutpObject AsCnstAltObjOutp { get; set; }
}

public class testRefCnstAltObjOutp<TRef>
  : ItestRefCnstAltObjOutp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltObjOutpObject AsRefCnstAltObjOutp { get; set; }
}

public class testPrntCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltObjOutpObject AsPrntCnstAltObjOutp { get; set; }
}

public class testAltCnstAltObjOutp
  : testPrntCnstAltObjOutp
  , ItestAltCnstAltObjOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltObjOutpObject AsAltCnstAltObjOutp { get; set; }
}
