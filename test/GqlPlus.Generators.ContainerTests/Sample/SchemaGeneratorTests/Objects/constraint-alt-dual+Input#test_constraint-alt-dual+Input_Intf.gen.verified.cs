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
  ItestRefCnstAltDualInp<ItestAltCnstAltDualInp> AsRefCnstAltDualInp { get; }
  ItestCnstAltDualInpObject AsCnstAltDualInp { get; }
}

public interface ItestCnstAltDualInpObject
{
}

public interface ItestRefCnstAltDualInp<TRef>
  : IGqlpModelImplementationBase
{
  TRef Asref { get; }
  ItestRefCnstAltDualInpObject<TRef> AsRefCnstAltDualInp { get; }
}

public interface ItestRefCnstAltDualInpObject<TRef>
{
}

public interface ItestPrntCnstAltDualInp
  : IGqlpModelImplementationBase
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
