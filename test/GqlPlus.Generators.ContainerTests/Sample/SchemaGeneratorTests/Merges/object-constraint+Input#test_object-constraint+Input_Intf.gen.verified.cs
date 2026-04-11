//HintName: test_object-constraint+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-constraint+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public interface ItestObjCnstInp<TType>
  : IGqlpInterfaceBase
{
  ItestObjCnstInpObject<TType>? As_ObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
  : IGqlpInterfaceBase
{
  TType Field { get; }
  TType Str { get; }
}
