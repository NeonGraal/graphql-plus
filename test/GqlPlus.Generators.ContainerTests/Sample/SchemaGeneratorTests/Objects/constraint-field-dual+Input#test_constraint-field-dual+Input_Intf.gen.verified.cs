//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp<ItestAltCnstFieldDualInp>
{
  ItestCnstFieldDualInpObject AsCnstFieldDualInp { get; }
}

public interface ItestCnstFieldDualInpObject
  : ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>
{
}

public interface ItestRefCnstFieldDualInp<TRef>
{
  ItestRefCnstFieldDualInpObject<TRef> AsRefCnstFieldDualInp { get; }
}

public interface ItestRefCnstFieldDualInpObject<TRef>
{
  TRef Field { get; }
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
