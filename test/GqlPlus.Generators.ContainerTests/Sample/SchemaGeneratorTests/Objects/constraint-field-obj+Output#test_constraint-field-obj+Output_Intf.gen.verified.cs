//HintName: test_constraint-field-obj+Output_Intf.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp
{
  ItestCnstFieldObjOutpObject AsCnstFieldObjOutp { get; }
}

public interface ItestCnstFieldObjOutpObject
  : ItestRefCnstFieldObjOutpObject
{
}

public interface ItestRefCnstFieldObjOutp<Tref>
{
  ItestRefCnstFieldObjOutpObject AsRefCnstFieldObjOutp { get; }
}

public interface ItestRefCnstFieldObjOutpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestPrntCnstFieldObjOutp
{
  string AsString { get; }
  ItestPrntCnstFieldObjOutpObject AsPrntCnstFieldObjOutp { get; }
}

public interface ItestPrntCnstFieldObjOutpObject
{
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  ItestAltCnstFieldObjOutpObject AsAltCnstFieldObjOutp { get; }
}

public interface ItestAltCnstFieldObjOutpObject
  : ItestPrntCnstFieldObjOutpObject
{
  decimal Alt { get; }
}
