//HintName: test_constraint-alt+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_Input;

public interface ItestCnstAltInp<TType>
  : IGqlpInterfaceBase
{
  TType? Astype { get; }
  ItestCnstAltInpObject<TType>? As_CnstAltInp { get; }
}

public interface ItestCnstAltInpObject<TType>
  : IGqlpInterfaceBase
{
}
