//HintName: test_constraint-enum+Input_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-enum+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_enum_Input;

public interface ItestCnstEnumInp
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumInp<testEnumCnstEnumInp>? AsEnumCnstEnumInpcnstEnumInp { get; }
  ItestCnstEnumInpObject? As_CnstEnumInp { get; }
}

public interface ItestCnstEnumInpObject
  : IGqlpModelImplementationBase
{
}

public interface ItestRefCnstEnumInp<TType>
  : IGqlpModelImplementationBase
{
  ItestRefCnstEnumInpObject<TType>? As_RefCnstEnumInp { get; }
}

public interface ItestRefCnstEnumInpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
}
