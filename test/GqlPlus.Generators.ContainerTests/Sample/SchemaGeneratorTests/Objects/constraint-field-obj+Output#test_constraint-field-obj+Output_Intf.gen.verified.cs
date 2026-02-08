//HintName: test_constraint-field-obj+Output_Intf.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp
{
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject
{
}

public interface ItestRefCnstFieldObjOutp<Tref>
{
}

public interface ItestRefCnstFieldObjOutpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldObjOutp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstFieldObjOutpObject
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  public ItestNumber Alt { get; set; }
}
