//HintName: test_constraint-field-dual+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-dual+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_dual_Input;

public interface ItestCnstFieldDualInp
  : ItestRefCnstFieldDualInp<ItestAltCnstFieldDualInp>
{
  ItestCnstFieldDualInpObject? As_CnstFieldDualInp { get; }
}

public interface ItestCnstFieldDualInpObject
  : ItestRefCnstFieldDualInpObject<ItestAltCnstFieldDualInp>
{
}

public interface ItestRefCnstFieldDualInp<TRef>
  : IGqlpInterfaceBase
{
  ItestRefCnstFieldDualInpObject<TRef>? As_RefCnstFieldDualInp { get; }
}

public interface ItestRefCnstFieldDualInpObject<TRef>
  : IGqlpInterfaceBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldDualInp
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstFieldDualInpObject? As_PrntCnstFieldDualInp { get; }
}

public interface ItestPrntCnstFieldDualInpObject
  : IGqlpInterfaceBase
{
}

public interface ItestAltCnstFieldDualInp
  : ItestPrntCnstFieldDualInp
{
  ItestAltCnstFieldDualInpObject? As_AltCnstFieldDualInp { get; }
}

public interface ItestAltCnstFieldDualInpObject
  : ItestPrntCnstFieldDualInpObject
{
  decimal Alt { get; }
}
