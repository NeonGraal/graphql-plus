//HintName: test_constraint-field-obj+Input_Intf.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp
{
  public ItestCnstFieldObjInpObject AsCnstFieldObjInp { get; set; }
}

public interface ItestCnstFieldObjInpObject
  : ItestRefCnstFieldObjInpObject
{
}

public interface ItestRefCnstFieldObjInp<Tref>
{
  public ItestRefCnstFieldObjInpObject AsRefCnstFieldObjInp { get; set; }
}

public interface ItestRefCnstFieldObjInpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldObjInp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjInpObject AsPrntCnstFieldObjInp { get; set; }
}

public interface ItestPrntCnstFieldObjInpObject
{
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  public ItestAltCnstFieldObjInpObject AsAltCnstFieldObjInp { get; set; }
}

public interface ItestAltCnstFieldObjInpObject
  : ItestPrntCnstFieldObjInpObject
{
  public decimal Alt { get; set; }
}
