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
  ItestRefCnstAltDualOutp<ItestAltCnstAltDualOutp> AsRefCnstAltDualOutp { get; }
  ItestCnstAltDualOutpObject AsCnstAltDualOutp { get; }
}

public interface ItestCnstAltDualOutpObject
{
}

public interface ItestRefCnstAltDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltDualOutpObject<TRef> AsRefCnstAltDualOutp { get; }
}

public interface ItestRefCnstAltDualOutpObject<TRef>
{
}

public interface ItestPrntCnstAltDualOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstAltDualOutpObject AsPrntCnstAltDualOutp { get; }
}

public interface ItestPrntCnstAltDualOutpObject
{
}

public interface ItestAltCnstAltDualOutp
  : ItestPrntCnstAltDualOutp
{
  ItestAltCnstAltDualOutpObject AsAltCnstAltDualOutp { get; }
}

public interface ItestAltCnstAltDualOutpObject
  : ItestPrntCnstAltDualOutpObject
{
  decimal Alt { get; }
}
