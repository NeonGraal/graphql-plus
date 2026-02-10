//HintName: test_constraint-field-obj+Output_Intf.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp
{
  public ItestCnstFieldObjOutpObject AsCnstFieldObjOutp { get; set; }
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject
{
}

public interface ItestRefCnstFieldObjOutp<Tref>
{
  public ItestRefCnstFieldObjOutpObject AsRefCnstFieldObjOutp { get; set; }
}

public interface ItestRefCnstFieldObjOutpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldObjOutp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjOutpObject AsPrntCnstFieldObjOutp { get; set; }
}

public interface ItestPrntCnstFieldObjOutpObject
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  public ItestAltCnstFieldObjOutpObject AsAltCnstFieldObjOutp { get; set; }
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  public decimal Alt { get; set; }
}
