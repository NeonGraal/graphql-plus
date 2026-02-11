//HintName: test_constraint-alt-dual+Input_Intf.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public interface ItestCnstAltDualInp
{
  ItestRefCnstAltDualInp<ItestAltCnstAltDualInp> AsRefCnstAltDualInp { get; }
  ItestCnstAltDualInpObject AsCnstAltDualInp { get; }
}

public interface ItestCnstAltDualInpObject
{
}

public interface ItestRefCnstAltDualInp<TRef>
{
  TRef Asref { get; }
  ItestRefCnstAltDualInpObject AsRefCnstAltDualInp { get; }
}

public interface ItestRefCnstAltDualInpObject<TRef>
{
}

public interface ItestPrntCnstAltDualInp
{
  string AsString { get; }
  ItestPrntCnstAltDualInpObject AsPrntCnstAltDualInp { get; }
}

public interface ItestPrntCnstAltDualInpObject
{
}

public interface ItestAltCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  ItestAltCnstAltDualInpObject AsAltCnstAltDualInp { get; }
}

public interface ItestAltCnstAltDualInpObject
  : ItestPrntCnstAltDualInpObject
{
  decimal Alt { get; }
}
