//HintName: test_constraint-alt-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public interface ItestCnstAltDualInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltDualInp<ItestAltCnstAltDualInp>? AsRefCnstAltDualInp { get; }
  ItestCnstAltDualInpObject? As_CnstAltDualInp { get; }
}

public interface ItestCnstAltDualInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstAltDualInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualInpObject<TRef>? As_RefCnstAltDualInp { get; }
}

public interface ItestRefCnstAltDualInpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstAltDualInp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualInpObject? As_PrntCnstAltDualInp { get; }
}

public interface ItestPrntCnstAltDualInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstAltDualInp
  : ItestPrntCnstAltDualInp
{
  ItestAltCnstAltDualInpObject? As_AltCnstAltDualInp { get; }
}

public interface ItestAltCnstAltDualInpObject
  : ItestPrntCnstAltDualInpObject
{
  decimal Alt { get; }
}
