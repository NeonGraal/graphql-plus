//HintName: test_object-constraint+Input_Intf.gen.cs
// Generated from {CurrentDirectory}object-constraint+Input.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Input;

public interface ItestObjCnstInp<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstInpObject<TType> AsObjCnstInp { get; }
}

public interface ItestObjCnstInpObject<TType>
{
  TType Field { get; }
  TType Str { get; }
}
