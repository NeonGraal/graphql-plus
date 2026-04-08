//HintName: test_constraint-alt-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Output;

public interface ItestCnstAltDualOutp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp>? AsRefCnstAltDualOutp { get; }
  ItestCnstAltDualOutpObject? As_CnstAltDualOutp { get; }
}

public interface ItestCnstAltDualOutpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDualOutp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualOutpObject<TRef>? As_RefCnstAltDualOutp { get; }
}

public interface ItestRefCnstAltDualOutpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltDualOutp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualOutpObject? As_PrntCnstAltDualOutp { get; }
}

public interface ItestPrntCnstAltDualOutpObject
  : IGqlpInterfaceBase
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
