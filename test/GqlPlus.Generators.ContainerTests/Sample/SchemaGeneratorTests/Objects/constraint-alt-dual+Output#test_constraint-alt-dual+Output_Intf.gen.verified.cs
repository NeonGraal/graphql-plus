//HintName: test_constraint-alt-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
  : IGqlpModelImplementationBase
{
  ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp>? AsRefCnstAltDualOutp { get; }
  ItestCnstAltDualOutpObject? As_CnstAltDualOutp { get; }
}

public interface ItestCnstAltDualOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstAltDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualOutpObject<TRef>? As_RefCnstAltDualOutp { get; }
}

public interface ItestRefCnstAltDualOutpObject<TRef>
  : IGqlpModelImplementationBase
{
}

public interface ItestPrntCnstAltDualOutp
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualOutpObject? As_PrntCnstAltDualOutp { get; }
}

public interface ItestPrntCnstAltDualOutpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  ItestAltCnstAltDualOutpObject? As_AltCnstAltDualOutp { get; }
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  decimal Alt { get; }
}
