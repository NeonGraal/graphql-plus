//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp
{
  ItestCnstFieldDualInpObject AsCnstFieldDualInp { get; }
}

public interface ItestCnstFieldDualInpObject
  : ItestRefCnstFieldDualInpObject
{
}

public interface ItestRefCnstFieldDualInp<Tref>
{
  ItestRefCnstFieldDualInpObject AsRefCnstFieldDualInp { get; }
}

public interface ItestRefCnstFieldDualInpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestPrntCnstFieldDualInp
{
  string AsString { get; }
  ItestPrntCnstFieldDualInpObject AsPrntCnstFieldDualInp { get; }
}

public interface ItestPrntCnstFieldDualInpObject
{
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  ItestAltCnstFieldDualInpObject AsAltCnstFieldDualInp { get; }
}

public interface ItestAltCnstFieldDualInpObject
  : ItestPrntCnstFieldDualInpObject
{
  decimal Alt { get; }
}
