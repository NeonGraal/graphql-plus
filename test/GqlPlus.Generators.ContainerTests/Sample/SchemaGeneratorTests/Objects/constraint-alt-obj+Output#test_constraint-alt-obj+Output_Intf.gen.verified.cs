//HintName: test_constraint-alt-obj+Output_Intf.gen.cs
// Generated from constraint-alt-obj+Output.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Output;

public interface ItestCnstAltObjOutp
{
  ItestRefCnstAltObjOutp<ItestAltCnstAltObjOutp> AsRefCnstAltObjOutp { get; }
  ItestCnstAltObjOutpObject AsCnstAltObjOutp { get; }
}

public interface ItestCnstAltObjOutpObject
{
}

public interface ItestRefCnstAltObjOutp<Tref>
{
  Tref Asref { get; }
  ItestRefCnstAltObjOutpObject AsRefCnstAltObjOutp { get; }
}

public interface ItestRefCnstAltObjOutpObject<Tref>
{
}

public interface ItestPrntCnstAltObjOutp
{
  string AsString { get; }
  ItestPrntCnstAltObjOutpObject AsPrntCnstAltObjOutp { get; }
}

public interface ItestPrntCnstAltObjOutpObject
{
}

public interface ItestAltCnstAltObjOutp
  : ItestPrntCnstAltObjOutp
{
  ItestAltCnstAltObjOutpObject AsAltCnstAltObjOutp { get; }
}

public interface ItestAltCnstAltObjOutpObject
  : ItestPrntCnstAltObjOutpObject
{
  decimal Alt { get; }
}
