//HintName: test_object-constraint+Output_Intf.gen.cs
// Generated from {CurrentDirectory}object-constraint+Output.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_object_constraint_Output;

public interface ItestObjCnstOutp<TType>
  : IGqlpModelImplementationBase
{
  ItestObjCnstOutpObject<TType>? As_ObjCnstOutp { get; }
}

public interface ItestObjCnstOutpObject<TType>
  : IGqlpModelImplementationBase
{
  TType Field { get; }
  TType Str { get; }
}
