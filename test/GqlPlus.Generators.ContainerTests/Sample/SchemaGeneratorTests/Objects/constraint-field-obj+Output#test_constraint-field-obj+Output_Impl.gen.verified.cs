//HintName: test_constraint-field-obj+Output_Impl.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public class testCnstFieldObjOutp
  : testRefCnstFieldObjOutp<ItestAltCnstFieldObjOutp>
  , ItestCnstFieldObjOutp
{
  public ItestCnstFieldObjOutpObject AsCnstFieldObjOutp { get; set; }
}

public class testRefCnstFieldObjOutp<TRef>
  : ItestRefCnstFieldObjOutp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldObjOutpObject AsRefCnstFieldObjOutp { get; set; }
}

public class testPrntCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjOutpObject AsPrntCnstFieldObjOutp { get; set; }
}

public class testAltCnstFieldObjOutp
  : testPrntCnstFieldObjOutp
  , ItestAltCnstFieldObjOutp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldObjOutpObject AsAltCnstFieldObjOutp { get; set; }
}
