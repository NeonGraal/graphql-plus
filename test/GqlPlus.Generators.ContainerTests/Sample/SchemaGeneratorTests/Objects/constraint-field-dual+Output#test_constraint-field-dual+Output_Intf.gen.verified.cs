//HintName: test_constraint-field-dual+Output_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Output;

public interface ItestCnstFieldDualOutp
  : ItestRefCnstFieldDualOutp<ItestAltCnstFieldDualOutp>
{
  ItestCnstFieldDualOutpObject AsCnstFieldDualOutp { get; }
}

public interface ItestCnstFieldDualOutpObject
  : ItestRefCnstFieldDualOutpObject<ItestAltCnstFieldDualOutp>
{
}

public interface ItestRefCnstFieldDualOutp<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDualOutpObject<TRef> AsRefCnstFieldDualOutp { get; }
}

public interface ItestRefCnstFieldDualOutpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualOutp
  : IGqlpModelImplementationBase
{
  string AsString { get; }
  ItestPrntCnstFieldDualOutpObject AsPrntCnstFieldDualOutp { get; }
}

public interface ItestPrntCnstFieldDualOutpObject
{
}

public interface ItestAltCnstFieldDualOutp
  : ItestPrntCnstFieldDualOutp
{
  ItestAltCnstFieldDualOutpObject AsAltCnstFieldDualOutp { get; }
}

public interface ItestAltCnstFieldDualOutpObject
  : ItestPrntCnstFieldDualOutpObject
{
  decimal Alt { get; }
}
