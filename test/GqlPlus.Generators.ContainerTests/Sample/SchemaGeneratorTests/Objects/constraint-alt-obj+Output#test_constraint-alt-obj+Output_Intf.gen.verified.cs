//HintName: test_constraint-alt-obj+Output_Intf.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
{
  public ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; set; }
  public ItestCnstAltObjOutpObject AsCnstAltObjOutp { get; set; }
}

public interface ItestCnstAltObjOutpObject
{
}

public interface ItestRefCnstAltObjOutp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltObjOutpObject AsRefCnstAltObjOutp { get; set; }
}

public interface ItestRefCnstAltObjOutpObject<Tref>
{
}

public interface ItestPrntCnstAltObjOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltObjOutpObject AsPrntCnstAltObjOutp { get; set; }
}

public interface ItestPrntCnstAltObjOutpObject
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  public ItestAltCnstAltObjOutpObject AsAltCnstAltObjOutp { get; set; }
}

public interface ItestAltCnstAltObjOutpObject
  : ItestPrntCnstAltObjOutpObject
{
  public decimal Alt { get; set; }
}
