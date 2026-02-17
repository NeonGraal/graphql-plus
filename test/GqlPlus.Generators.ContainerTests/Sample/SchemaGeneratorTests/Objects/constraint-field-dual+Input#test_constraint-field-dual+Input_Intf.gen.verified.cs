//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
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
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldDualInpObject<TRef> AsRefCnstFieldDualInp { get; }
}

public interface ItestRefCnstFieldDualInpObject<TRef>
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualInp
  : IGqlpModelImplementationBase
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
