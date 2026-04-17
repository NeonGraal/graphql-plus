//HintName: test_constraint-alt-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_dual_Input;

public interface ItestCnstAltDualInp
  : IGqlpInterfaceBase
{
  ItestRefCnstAltDualInp<ItestAltCnstAltDualInp>? AsRefCnstAltDualInp { get; }
  ItestCnstAltDualInpObject? As_CnstAltDualInp { get; }
}

public interface ItestCnstAltDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltDualInp<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltDualInpObject<TRef>? As_RefCnstAltDualInp { get; }
}

public interface ItestRefCnstAltDualInpObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltDualInpObject? As_PrntCnstAltDualInp { get; }
}

public interface ItestPrntCnstAltDualInpObject
  : IGqlpInterfaceBase
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
